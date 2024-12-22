#include <iostream>
#include <vector>
#include <math.h>
#include <iomanip>
#include "cuda_runtime.h"
#include "device_launch_parameters.h"

const double eps = 1e-7;

#define CSC(call)                                                   \
do {                                                                \
    cudaError_t res = call;                                         \
    if (res != cudaSuccess) {                                       \
        fprintf(stderr, "ERROR in %s:%d. Message: %s\n",            \
                __FILE__, __LINE__, cudaGetErrorString(res));       \
        exit(0);                                                    \
    }                                                               \
} while(0)

__device__ void atomic_max(double* const address, const double value)
{
    unsigned long long int* const _address = (unsigned long long int*)address;
    unsigned long long int prev = *_address, next;
    do {
        next = prev;
        if (__longlong_as_double(next) >= value) {
            break;
        }
        prev = atomicCAS(_address, next, __double_as_longlong(value));
    } while (next != prev);
}

__global__ void reduce_max_col(double *matrix, int sz, double *value, int *idx) {
    __shared__ double sh_val;
    __shared__ int sh_idx;
    if (threadIdx.x == 0) {
        sh_val = 0.0;
        sh_idx = 0;
    }
    __syncthreads();

    double max_val = 0.0;
    int max_idx = 0;
    for (int i = threadIdx.x; i < sz; i += blockDim.x) {
        if (fabs(max_val) < fabs(matrix[i])) {
            max_val = matrix[i];
            max_idx = i;
        }
    }

    atomic_max(&sh_val, max_val);
    __syncthreads();
    if (sh_val == max_val) {
        sh_idx = max_idx;
    }

    __syncthreads();
    if (threadIdx.x == 0) {
        *value = sh_val;
        *idx = sh_idx;
    }
}

__global__ void swap_rows(double *matrix, int n, int m, int row1, int row2) {
    int j = blockIdx.x * blockDim.x + threadIdx.x;
    int offset = blockDim.x * gridDim.x;

    while (j < m) {
        int idx1 = j * n + row1;
        int idx2 = j * n + row2;

        double tmp = matrix[idx1];
        matrix[idx1] = matrix[idx2];
        matrix[idx2] = tmp;

        j += offset;
    }
}

__global__ void gauss(double *matrix, int n, int m, int i) { 
    int idx = blockDim.x * blockIdx.x + threadIdx.x;
    int idy = blockDim.y * blockIdx.y + threadIdx.y;
    int offsetx = blockDim.x * gridDim.x;
    int offsety = blockDim.y * gridDim.y;

    int h = m - i - 1;
    int w = n - i - 1;

    for (int y = idy; y < h; y += offsety) {
        for (int x = idx; x < w; x += offsetx) {
            int k = i + 1 + y;
            int r = i + 1 + x;

            double coef = matrix[k * n + i];
            double num  = matrix[i * n + r];
            double div  = matrix[i * n + i];
            matrix[k * n + r] -= coef * num / div;
        }
    }
}

int main(int argc, char const *argv[])
{
    int n = 0, m = 0;
    scanf("%d %d", &n, &m);
    double *matrix = new double[n * (m + 1)];

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            std::cin >> matrix[j * n + i];
        }
    }
    for (int i = 0; i < n; i++) {
        std::cin >> matrix[m * n + i];
    }

    double *dev_matrix;
    CSC(cudaMalloc(&dev_matrix, sizeof(double) * n * (m + 1)));
    CSC(cudaMemcpy(dev_matrix, matrix, sizeof(double) * n * (m + 1), cudaMemcpyHostToDevice));

    double *max_elem;
    int    *max_ptr;
    CSC(cudaMalloc(&max_elem, sizeof(double)));
    CSC(cudaMalloc(&max_ptr,  sizeof(int)));

    std::vector<bool> rank_cols(m, false);

    int skip = 0;
    int iterCount = std::min(n, m);
    for (int i = 0; i < iterCount; i++) {
        int begin_col_idx = (i + skip) * n + (i - skip);
        int end_col_idx   = (i + 1 + skip) * n;
        int col_size      = end_col_idx - begin_col_idx;

        reduce_max_col<<<512, 512>>>(dev_matrix + begin_col_idx, col_size, max_elem, max_ptr);
        
        double h_max_elem;
        int    h_max_ptr;
        CSC(cudaMemcpy(&h_max_elem, max_elem, sizeof(double), cudaMemcpyDeviceToHost));
        CSC(cudaMemcpy(&h_max_ptr, max_ptr,   sizeof(int),    cudaMemcpyDeviceToHost));

        int shift  = begin_col_idx + h_max_ptr;
        int center = (i + skip) * n + (i - skip);

        int row1 = shift  % n;
        int row2 = center % n;
        if (row1 != row2) {
            swap_rows<<<1024, 1024>>>(dev_matrix, n, m + 1, row1, row2);
            CSC(cudaGetLastError());
            CSC(cudaDeviceSynchronize());
        }

        double main_elem;
        CSC(cudaMemcpy(&main_elem, dev_matrix + center, sizeof(double), cudaMemcpyDeviceToHost));

        if (fabs(main_elem) < eps) {
            skip++;
            continue;
        } else {
            rank_cols[i + skip] = true;
        }

        gauss<<<dim3(64, 64), dim3(16, 16)>>>(dev_matrix, n, m + 1, i);
        CSC(cudaGetLastError());
        CSC(cudaDeviceSynchronize());
    }
    
    CSC(cudaMemcpy(matrix, dev_matrix, sizeof(double) * n * (m + 1), cudaMemcpyDeviceToHost));

    int rank = 0;
    for (int j = 0; j < m; j++) {
        if (rank_cols[j]) {
            rank++;
        }
    }
    std::cout << rank << "\n";

    if (rank == m) {
        std::cout << "System has one solution:\n";
    } else {
        std::cout << "System has infinity solutions. One of them:\n";
    }

    double *square_matrix = new double[rank * (rank + 1)];

    int ri = 0;
    for (int row = 0; row < n; row++) {
        if (row >= m) {
            break;
        }
        if (!rank_cols[row]) {
            continue;
        }

        int rj = 0;
        for (int j = 0; j < m; j++) {
            if (rank_cols[j]) {
                square_matrix[rj * rank + ri] = matrix[j * n + row];
                rj++;
            }
        }
        square_matrix[rank * rank + ri] = matrix[m * n + row];

        ri++;
        if (ri == rank) {
            break;
        }
    }

    for (int y = rank - 1; y >= 0; y--) {
        double diag = square_matrix[y * rank + y];
        if (fabs(diag) > eps) {
            for (int x = y - 1; x >= 0; x--) {
                double f = square_matrix[y * rank + x];
                square_matrix[rank * rank + x] -= square_matrix[rank * rank + y] * f / diag;
                square_matrix[y * rank + x] = 0.0;
            }
        }
    }

    std::cout << std::scientific << std::setprecision(10);
    for (int i = 0; i < rank; i++) {
        double diag = square_matrix[i * rank + i];
        double rhs  = square_matrix[rank * rank + i];
        double val  = (fabs(diag) < eps ? 0.0 : (rhs / diag));
        std::cout << val << " ";
    }
    for (int i = rank; i < m; i++) {
        std::cout << 0.0 << " ";
    }
    std::cout << std::endl;

    CSC(cudaFree(dev_matrix));
    CSC(cudaFree(max_elem));
    CSC(cudaFree(max_ptr));

    delete[] square_matrix;
    delete[] matrix;

    return 0;
}

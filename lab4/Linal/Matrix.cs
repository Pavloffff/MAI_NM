﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Linal
{
    internal class Matrix
    {
        private double[,] _buffer;
        public List<Tuple<int, int>> _swapped = new List<Tuple<int, int>>();

        public Matrix Clone()
        {
            return new Matrix(this);
        }

        public Matrix(Matrix other)
        {
            int n = other._buffer.GetLength(0);
            int m = other._buffer.GetLength(1);
            _buffer = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    _buffer[i, j] = other._buffer[i, j];
                }
            }
        }

        public Matrix(int n)
        {
            _buffer = new double[n, n];
        }

        public Matrix(int n, int m)
        {
            _buffer = new double[n, m];
        }

        public Matrix()
        {
        }

        public double this[int row, int col]
        {
            get => _buffer[row, col];
            set => _buffer[row, col] = value;
        }

        public int Rows => _buffer.GetLength(0);
        public int Cols => _buffer.GetLength(1);

        public bool Equals(Matrix other)
        {
            if (Rows == 0 && other.Rows == 0)
            {
                return true;
            }
            if (Rows != other.Rows || Cols != other.Cols)
            {
                return false;
            }
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Cols; ++j)
                {
                    if (_buffer[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public double Determinant()
        {
            Matrix B = new Matrix(this);
            B = LU(B);
            double res = 1;
            for (int i = 0; i < B.Rows; i++)
            {
                res *= GetU(B, i, i);
            }
            return res;
        }

        public void SwapCols(int first, int second)
        {
            for (int i = 0; i < Rows; ++i)
            {
                _buffer[i, first] += _buffer[i, second];
                _buffer[i, second] = _buffer[i, first] - _buffer[i, second];
                _buffer[i, first] -= _buffer[i, second];
            }
        }

        public void SwapRows(int first, int second)
        {
            for (int j = 0; j < Cols; ++j)
            {
                _buffer[first, j] += _buffer[second, j];
                _buffer[second, j] = _buffer[first, j] - _buffer[second, j];
                _buffer[first, j] -= _buffer[second, j];
            }
        }

        public double Norm()
        {
            double max = 0;
            for (int i = 0; i < Rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < Cols; j++)
                {
                    sum += (_buffer[i, j] >= 0 ? _buffer[i, j] : -_buffer[i, j]);
                }
                if (sum > max)
                {
                    max = sum;
                }
            }
            return max;
        }

        public void Add(Matrix other)
        {
            for (int i = 0; i < other.Rows; i++)
            {
                for (int j = 0; j < other.Cols; j++)
                {
                    _buffer[i, j] += other[i, j];
                }
            }
        }

        public void Mul(double coef)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    _buffer[i, j] *= coef;
                }
            }
        }

        public static Matrix LU(Matrix A)
        {
            int n = A.Rows;
            for (int col = 0; col < n; ++col)
            {
                int maxIdx = col;
                for (int row = col + 1; row < n; ++row)
                {
                    if (A[row, col] * A[row, col] >
                        A[maxIdx, col] * A[maxIdx, col])
                    {
                        maxIdx = row;
                    }
                }
                if (maxIdx != col)
                {
                    A.SwapRows(col, maxIdx);
                    A._swapped.Add(new Tuple<int, int>(col, maxIdx));
                }
                double coef = A[col, col];
                for (int row = col + 1; row < n; row++)
                {
                    double div = A[row, col] / coef;
                    for (int iter = col; iter < n; iter++)
                    {
                        A[row, iter] -= div * A[col, iter];
                    }
                    A[row, col] = div;
                }
            }
            return A;
        }

        public static double GetL(Matrix LU, int row, int col)
        {
            if (row == col)
            {
                return 1.0;
            }
            else if (row > col)
            {
                return LU[row, col];
            }
            else
            {
                return 0.0;
            }
        }

        public static double GetU(Matrix LU, int row, int col)
        {
            if (row <= col)
            {
                return LU[row, col];
            }
            else
            {
                return 0.0;
            }
        }

        public static Matrix Inverse(Matrix A)
        {
            Matrix B = new Matrix(A);
            B = LU(B);
            Matrix res = new Matrix(B.Rows);
            int n = B.Cols;
            for (int col = 0; col < n; col++)
            {
                double[] e = new double[n];
                e[col] = 1;
                double[] z = new double[n];
                z[0] = e[0];
                for (int i = 1; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < i; j++)
                    {
                        sum += z[j] * GetL(B, i, j);
                    }
                    z[i] = e[i] - sum;
                }
                res[n - 1, col] = z[n - 1] / GetU(B, n - 1, n - 1);
                for (int i = n - 2; i >= 0; i--)
                {
                    double sum = 0;
                    for (int j = i + 1; j < n; j++)
                    {
                        sum += res[j, col] * GetU(B, i, j);
                    }
                    res[i, col] = (1 / GetU(B, i, i)) * (z[i] - sum);
                }
            }
            for (int i = B._swapped.Count - 1; i >= 0; --i)
            {
                res.SwapCols(B._swapped[i].Item1, B._swapped[i].Item2);
            }
            return res;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix res = new Matrix(A.Rows, B.Cols);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    res[i, j] = 0;
                    for (int k = 0; k < B.Rows; k++)
                    {
                        res[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return res;
        }

        public static Vector operator *(Matrix A, Vector B)
        {
            Vector res = new Vector(A.Rows);
            for (int i = 0; i < A.Rows; i++)
            {
                res[i] = 0;
                for (int k = 0; k < B.Rows; k++)
                {
                    res[i] += A[i, k] * B[k];
                }
            }
            return res;
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix res = new Matrix(A);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Cols; j++)
                {
                    res[i, j] += B[i, j];
                }
            }
            return res;
        }

        public static Matrix E(int n)
        {
            Matrix E = new Matrix(n);
            for (int i = 0; i < n; i++)
            {
                E[i, i] = 1;
            }
            return E;
        }

        public static Matrix T(Matrix A)
        {
            int n = A.Rows, m = A.Cols;
            Matrix res = new Matrix(m, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    res[j, i] = A[i, j];
                }
            }
            return res;
        }

        public override string ToString()
        {
            string res = string.Empty;
            int n = Rows, m = Cols;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    string value = Math.Round(_buffer[i, j], 4).ToString("0.0000");
                    value = value.PadRight(18);
                    res += value;
                }
                res += "\n";
            }
            return res;
        }
    }
}
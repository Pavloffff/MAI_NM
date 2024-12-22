#! /bin/bash
nvcc main.cu
for file in t*.txt; do
    echo "====================="
    echo "TEST: $file\n"
    echo "IN:\n"
    cat "$file"
    echo "\nOUT:\n"
    ./a.out < "$file"
    echo ""
done
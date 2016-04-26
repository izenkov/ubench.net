#!/bin/bash

function clean_dir() {
    rm -r ./$1/bin
    rm -r ./$1/obj
}

echo "Cleaning ..."

rm -r ./.vs

clean_dir UBench
clean_dir UBenchConsole
clean_dir UBenchDemo
clean_dir UBenchFibonacci
clean_dir UBenchForeach
clean_dir UBenchMethod

echo "Done"

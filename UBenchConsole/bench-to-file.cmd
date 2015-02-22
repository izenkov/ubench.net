@echo off

echo Running benchmark ...

pushd bin\Release 
UBenchConsole.exe > output.txt
popd
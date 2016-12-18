@echo off
set COMMON_BUILD_OPTIONS=/target:Build
call "%VS140COMNTOOLS%..\..\VC\vcvarsall.bat"
MSBuild "%~pd0.\Torrentizer.sln" %COMMON_BUILD_OPTIONS% /m /property:Configuration=Debug /property:Platform="Any CPU"
if errorlevel 1 goto batch_failed
MSBuild "%~pd0.\Torrentizer.sln" %COMMON_BUILD_OPTIONS% /m /property:Configuration=Release /property:Platform="Any CPU"
if errorlevel 1 goto batch_failed
call GitVersioner.bat ba
goto batch_ok

:batch_failed
echo Build failed
exit /b 1

:batch_ok
echo Built OK
exit /b 0

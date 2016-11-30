@echo off
set DOTNET_HOME=C:\Windows\Microsoft.NET\Framework\v4.0.30319
set COMMON_BUILD_OPTIONS=/target:Build
::/verbosity:detailed
:: build debug + release
call "%DOTNET_HOME%\MSBuild" "%~pd0.\Torrentizer.sln" %COMMON_BUILD_OPTIONS% /m /property:Configuration=Debug /property:Platform="Any CPU"
if errorlevel 1 goto batch_failed
call "%DOTNET_HOME%\MSBuild" "%~pd0.\Torrentizer.sln" %COMMON_BUILD_OPTIONS% /m /property:Configuration=Release /property:Platform="Any CPU"
if errorlevel 1 goto batch_failed
call GitVersioner.bat ba
goto batch_ok

:batch_failed
echo Build failed
exit /b 1

:batch_ok
echo Built OK
exit /b 0

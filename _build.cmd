@echo off
set DOTNET_HOME=C:\Windows\Microsoft.NET\Framework\v4.0.30319
set COMMON_BUILD_OPTIONS=/target:Build
::/verbosity:detailed
:: build debug + release
call "%DOTNET_HOME%\MSBuild" "%~pd0.\Torrentizer.sln" %COMMON_BUILD_OPTIONS% /property:configuration=Debug
if errorlevel 1 goto batch_failed
call "%DOTNET_HOME%\MSBuild" "%~pd0.\Torrentizer.sln" %COMMON_BUILD_OPTIONS% /property:configuration=Release
if errorlevel 1 goto batch_failed

goto batch_ok

:batch_failed
echo Build failed
exit /b 1

:batch_ok
echo Built OK
exit /b 0

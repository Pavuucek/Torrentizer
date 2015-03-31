@echo off
rem call _build.cmd
set zip="c:\program files\7-zip\7z.exe"
if not exist "%~pd0bin\debug\Torrentizer.exe" goto build_failed
if not exist "%~pd0bin\release\Torrentizer.exe" goto build_failed
echo @echo off >%~pd0\bin\zip.cmd
echo %zip% a Torrentizer_$Branch$-$MajorVersion$.$MinorVersion$.$Revision$-$Commit$-$ShortHash$(DEBUG).zip debug\*.*>>%~pd0\bin\zip.cmd
echo %zip% a Torrentizer_$Branch$-$MajorVersion$.$MinorVersion$.$Revision$-$Commit$-$ShortHash$(RELEASE).zip release\*.*>>%~pd0\bin\zip.cmd
echo exit >>%~pd0\bin\zip.cmd
pushd %~pd0\bin
..\gitversioner.exe w zip.cmd
if exist zip.cmd call start /wait zip.cmd
if exist zip.cmd del zip.cmd > nul
if exist zip.cmd.gwbackup del zip.cmd.gwbackup > nul
popd
echo.
echo. Packages created in %~pd0\bin directory!
echo.
exit /b 0

:build_failed
echo.
echo BUILD FAILED!
echo.
exit /b 1
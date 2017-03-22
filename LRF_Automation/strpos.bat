  @echo off & setlocal enableextensions
  call :InstrFN ""%1"" "%2" position_
  endlocal & SET strpos=%position_% & goto :EOF 

  :: ===============================================================
  :InstrFN
  setlocal enableextensions enabledelayedexpansion
  echo %1|findstr %2>nul
  if %errorlevel% EQU 1 (endlocal & set %3=0& goto :EOF)
  set rest_=%1
  set /a instr_=0
  :_loop
    set rest_=%rest_:~1%
    echo !rest_!|findstr %2>nul
    if %errorlevel% EQU 1 (endlocal & set %3=%instr_%& goto :EOF)
    set /a instr_ +=1
    goto _loop
  :: ===============================================================
  :InstrFN
  setlocal enableextensions enabledelayedexpansion
  echo %1|findstr %2>nul
  if %errorlevel% EQU 1 (endlocal & set %3=0& goto :EOF)
  set rest_=%1
  set /a instr_=0
  :_loop
    set rest_=%rest_:~1%
    echo !rest_!|findstr %2>nul
    if %errorlevel% EQU 1 (endlocal & set %3=%instr_%& goto :EOF)
    set /a instr_ +=1
    goto _loop


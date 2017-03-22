@ECHO OFF
SETLOCAL
SET WhatsLeft=%*
SET Count=0
:TestIt
IF "%WhatsLeft%"=="" GOTO RETURN
SET WhatsLeft=%WhatsLeft:~,-1%
SET /A Count=%Count%+1
GOTO TestIt
:RETURN
ENDLOCAL & SET strlen=%Count%
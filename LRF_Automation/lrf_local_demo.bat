@echo OFF
set myfolder=%date:~-4%%date:~4,2%%date:~7,2%%time:~0,2%%time:~3,2%%time:~6,2%
call pybot --outputdir "%~dp0\Report" --loglevel NONE "%~dp0\Test_Modules\LRF_Smoke_Test_Local_Demo.txt"
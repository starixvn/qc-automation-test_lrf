@echo OFF
call pybot --include CI --outputdir "%~dp0\Report" "%~dp0\Test_Modules\LRF_Smoke_Test.txt"
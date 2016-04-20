@echo OFF
call pybot --include CI --outputdir "%~dp0\Report_MNLServer" "%~dp0\Test_Modules\LRF_Smoke_Test_MNLServer.txt"
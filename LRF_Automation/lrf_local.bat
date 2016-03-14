@echo OFF
set myfolder=%date:~-4%%date:~4,2%%date:~7,2%%time:~0,2%%time:~3,2%%time:~6,2%
java -Dwebdriver.chrome.driver=D:\Tools\Python27\chromedriver.exe -browser "browserName=chrome"
call pybot --variable BROWSER:firefox --outputdir "%~dp0\Report" "%~dp0\Test_Modules\LRF_Smoke_Test_Local.txt"
call pybot --variable BROWSER:chrome --outputdir "%~dp0\Report" "%~dp0\Test_Modules\LRF_Smoke_Test_Local.txt"
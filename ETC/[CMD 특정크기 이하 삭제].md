[CMD 특정크기 이하 삭제]

C:\Users\CEO\Desktop\cmdTestFolder>@echo off
setlocal
:: Size is in bytes
set "min.size=1300"

for /f "usebackq delims=;" %A in (`dir /b /s *.png`) do If %~zA LSS %min.size% del "%A"
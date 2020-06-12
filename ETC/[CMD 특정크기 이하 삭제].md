[CMD 특정크기 이하 삭제]

C:\Users\CEO\Desktop\cmdTestFolder>@echo off
setlocal
:: Size is in bytes
set "min.size=1300"

for /f "usebackq delims=;" %A in (`dir /b /s *.png`) do If %~zA LSS %min.size% del "%A"



[power Shell]

//디렉토리 내부 특정 용량 삭제
Get-ChildItem $path -Filter *.png -recurse -file | ? {$_.length -lt 1300} | % {Remove-Item $_.fullname -WhatIf}

//디렉토리 내부 특정 용량 카운트
(Get-ChildItem $path -Filter *.png -recurse -file | ? {$_.length -lt 1300} | Measure-Object).Count
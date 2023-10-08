@echo off
setlocal

set "zip_file=C:\Users\ldamo\OneDrive\Desktop\test.zip"
set "destination_folder=C:\Users\ldamo\OneDrive\Desktop\test1"

set "password=%~1"

"C:\Program Files\7-Zip\7z.exe" x -p"%password%" -o"%destination_folder%" -y "%zip_file%" > NUL 2>&1 

if %errorlevel% equ 0 (
    exit /b 10
) else (
    exit /b 0
)

exit 0
endlocal

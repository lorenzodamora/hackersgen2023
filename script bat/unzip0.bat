@echo off
setlocal

rem "zip_file=C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023.zip"
rem "destination_folder=C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023"

set "zip_file=C:\Users\ldamo\OneDrive\Desktop\test.zip"
set "destination_folder=C:\Users\ldamo\OneDrive\Desktop\test1"

rem Verifica se la cartella di destinazione esiste, altrimenti la crea
if not exist "%destination_folder%" (
    mkdir "%destination_folder%"
)

set "password=%~1"
rem test

rem Utilizza la password per estrarre i file dall'archivio ZIP
"C:\Program Files\7-Zip\7z.exe" x -p"%password%" -o"%destination_folder%" -y "%zip_file%" > NUL 2>&1 


rem Controlla se l'operazione di estrazione ha avuto successo
if %errorlevel% equ 0 (
    rem echo Estrazione completata.
    exit /b 1
) else (
    rem echo Password errata o errore durante l'estrazione.
    exit /b 0
)

endlocal

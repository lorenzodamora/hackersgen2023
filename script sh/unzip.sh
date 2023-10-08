#!/bin/bash

# $zip_file = "C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023.zip"
# $destination_folder = "C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023"
sleep 3
zip_file="C:\Users\ldamo\OneDrive\Desktop\test.zip"
destination_folder="C:\Users\ldamo\OneDrive\Desktop\test1"

# Verifica se la cartella di destinazione esiste, altrimenti la crea
if [ ! -d "$destination_folder" ]; then
    mkdir -p "$destination_folder"
fi

password="$1"
echo "pass: $password"
# Utilizza la password per estrarre i file dall'archivio ZIP e sovrascrive automaticamente
unzip -o -P "$password" "$zip_file" -d "$destination_folder" > /dev/null 2>&1

# Controlla se l'operazione di estrazione ha avuto successo
if [ $? -eq 0 ]; then
  echo
  echo "Bruteforce completato in $ct tentativi. La password era \"$password\""
  echo -n "$password" > psw.txt
  echo "10"
  sleep 3
  exit 10 # Esci se l'estrazione ha successo
#else
#  echo "($c)password sbagliata: \"$password\""
fi

echo "20"
sleep 3
exit 20

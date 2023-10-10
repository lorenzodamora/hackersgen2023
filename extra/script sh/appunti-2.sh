#!/bin/bash

# $zip_file = "C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023.zip"
# $destination_folder = "C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023"

zip_file="C:\Users\ldamo\OneDrive\Desktop\test.zip"
destination_folder="C:\Users\ldamo\OneDrive\Desktop\test1"

# Verifica se la cartella di destinazione esiste, altrimenti la crea
if [ ! -d "$destination_folder" ]; then
    mkdir -p "$destination_folder"
fi

declare -a char_array
# Loop da 0 a 255 per tutti i valori possibili di un byte
for ((i=0; i<=255; i++))
do
    # Converti il valore in esadecimale
    hex_value=$(printf "%02X" $i)
    
    # Decodifica l'hex_value come carattere UTF-8 e lo aggiunge all'array
    char=$(printf "\\x$hex_value")
    char_array[$i]=$char
done

c=0
while true; do
    # Loop per creare stringhe di lunghezze variabili
    for ((length=1; length<=20; length++))
    do
        for char in "${char_array[@]}"
        do
            # Crea una stringa con il carattere corrente ripetuto "length" volte
            password=""
            for ((i=1; i<=length; i++))
            do
                password="$password$char"
            done
            ((c++))
            # Utilizza la password per estrarre i file dall'archivio ZIP e sovrascrive automaticamente
            unzip -o -P "$password" "$zip_file" -d "$destination_folder" > /dev/null 2>&1

            # Controlla se l'operazione di estrazione ha avuto successo
            if [ $? -eq 0 ]; then
                echo "Bruteforce completato. La password era \"$password\""
                echo -n "$password" > psw.txt
                exit # Esci se l'estrazione ha successo
            else
            echo "($c)password sbagliata: \"$password\""
            fi
        done
    done
done

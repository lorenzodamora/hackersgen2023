#!/bin/bash

# $zip_file = "C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023.zip"
# $destination_folder = "C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023"

$zip_file = "C:\Users\ldamo\OneDrive\Desktop\test.zip"
$destination_folder = "C:\Users\ldamo\OneDrive\Desktop\test1"

# Verifica se la cartella di destinazione esiste, altrimenti la crea
if [ ! -d "$destination_folder" ]; then
    mkdir -p "$destination_folder"
fi

while true; do
    echo "Inserisci la password dell'archivio ZIP:"
    read password

    # Utilizza la password per estrarre i file dall'archivio ZIP
    unzip -P "$password" "$zip_file" -d "$destination_folder"

    # Controlla se l'operazione di estrazione ha avuto successo
    if [ $? -eq 0 ]; then
        echo "Estrazione completata. La password era \"$password\""
        break  # Esci dal ciclo se l'estrazione ha successo
    else
        echo "Password errata. Riprova."
    fi
done

#!/bin/bash

# Dichiarazione dell'array
declare -a char_array

# Loop da 0 a 255 per tutti i valori possibili di un byte
for ((i=0; i<=255; i++))
do
  # Converti il valore in esadecimale
  hex_value=$(printf "%02X" $i)
  
  # Decodifica l'hex_value come carattere UTF-8 e lo aggiunge all'array
  char=$(echo -e "\x$hex_value")
  char_array[$i]=$char
done

# Stampare l'array per verificarne il contenuto
for ((i=0; i<=255; i++))
do
  echo "Carattere $i: ${char_array[$i]}"
done

#!/bin/bash

# Dichiarazione dell'array
declare -a string_array

# Definisci la lista di caratteri
char_array=("a" "b" "c" "d" "e" "f" "g" "h" "i" "j" "k" "l" "m" "n" "o" "p" "q" "r" "s" "t" "u" "v" "w" "x" "y" "z")

# Loop per creare stringhe di lunghezze variabili
for ((length=1; length<=4; length++))
do
  for char in "${char_array[@]}"
  do
    # Crea una stringa con il carattere corrente ripetuto "length" volte
    str=""
    for ((i=1; i<=length; i++))
    do
      str="$str$char"
    done
    string_array+=("$str")
  done
done

# Stampare l'array per verificarne il contenuto
for string in "${string_array[@]}"
do
  echo "$string"
done

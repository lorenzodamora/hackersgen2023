#!/bin/bash

# Funzione per calcolare la somma di un array
TotArray() {
  local -a array=("${!1}") # Ottiene l'array passato come argomento
  local tot=0
  for i in "${array[@]}"; do
    ((tot += i))
  done
  echo "$tot"
}

# $zip_file = "C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023.zip"
# $destination_folder = "C:\Users\ldamo\OneDrive\Desktop\hacking_challenge_2023"

zip_file="C:\Users\ldamo\OneDrive\Desktop\test.zip"
destination_folder="C:\Users\ldamo\OneDrive\Desktop\test1"

# Verifica se la cartella di destinazione esiste, altrimenti la crea
if [ ! -d "$destination_folder" ]; then
    mkdir -p "$destination_folder"
fi

a=256

chars=()
for ((i = 0; i < a; i++)); do
  chars[i]=$(printf "\\$(printf '%03o' "$i")")
done

# Calcolo del numero totale di combinazioni possibili
n=4
s=$((a * (1 - a ** n) / (1 - a)))
echo "Possibili combinazioni totali: $s"

ct=0 # Contatore di tentativi

for ((len = 1; len <= n; len++)); do
  echo "len: $len"
  ch=()
  for ((ic = 0; ic < len; ic++)); do
    ch[ic]=0
  done
  
  ia=1
  while [[ $(TotArray ch[@]) -ne $((a * len)) ]]; do
    ic=0
    for ((i = 0; i < len; i++)); do
      if [[ ${ch[$i]} -eq $a ]]; then
        ch[$i]=0
      fi
    done
    
    arg=""
    for ((i = 0; i < len; i++)); do
      arg="${chars[${ch[$ic]}]}$arg"

      if [[ $ic -eq $((len - 1)) ]]; then
        ic=0
      else
        ((ic++))
      fi
    done
    
    ((ct++))
    if (( ct % 10000 == 0)); then
      echo -n "$ct | "
    fi
#    echo "Tentativo $ct: $arg"
    
    # Utilizza la password per estrarre i file dall'archivio ZIP e sovrascrive automaticamente
    unzip -o -P "$password" "$zip_file" -d "$destination_folder" > /dev/null 2>&1

    # Controlla se l'operazione di estrazione ha avuto successo
    if [ $? -eq 0 ]; then
      echo
      echo "Bruteforce completato in $ct tentativi. La password era \"$password\""
      echo -n "$password" > psw.txt
      exit # Esci se l'estrazione ha successo
#    else
#      echo "($c)password sbagliata: \"$password\""
    fi

    for ((i = 0; i < len; i++)); do
      if ((ia % ((a ** i)) == 0)); then
        ((ch[i]++))
      fi
    done
    ((ia++))
  done
done

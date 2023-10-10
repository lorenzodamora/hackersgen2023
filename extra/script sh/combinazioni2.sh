#!/bin/bash

# senza array args

# Funzione per calcolare la somma di un array
TotArray() {
  local -a array=("${!1}") # Ottiene l'array passato come argomento
  local tot=0
  for i in "${array[@]}"; do
    ((tot += i))
  done
  echo "$tot"
}

a=3

chars=()
for ((i = 0; i < a; i++)); do
  chars[i]=$(printf "\\$(printf '%03o' "$i")")
done

chars=("A" "B" "C")

# Calcolo del numero totale di combinazioni possibili
n=3
s=$((a * (1 - a ** n) / (1 - a)))
echo "Possibili combinazioni totali: $s"

ct=0 # Contatore di tentativi

for ((len = 1; len <= n; len++)); do
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
    echo "Tentativo $ct: $arg"
    
    for ((i = 0; i < len; i++)); do
      if ((ia % ((a ** i)) == 0)); then
        ((ch[i]++))
      fi
    done
    ((ia++))
  done
done

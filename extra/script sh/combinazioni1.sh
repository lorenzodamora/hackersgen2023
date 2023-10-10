#!/bin/bash

# combinazioni

# Funzione per calcolare la somma di un array
TotArray() {
    local -a array=("${!1}") # Ottiene l'array passato come argomento
    local tot=0
    for i in "${array[@]}"; do
        ((tot += i))
    done
    echo "$tot"
}

a=256 # //(256)tot char da combinare

chars=()

for ((i=0; i<$a; i++)); do
  chars[$i]=$(printf "\\x$(printf %x $i)")
done
# chars=("A" "B" "C")

# //for(int i = 65; i-65 < chars.Length; i++) chars[i-65] = $"{(char)i}";
# //S = a * (1 - a^n) / (1 - a)
n=20
a_n=$((a ** n))
s=$((a * (1 - a_n) / (1 - a)))

args=()
for ((i=0; i<s; i++)); do
  args[i]=""
done

ca=0

for ((len = 1; len <= n; len++)); do
#  echo "len: $len"
  ch=() # Dichiarazione di un array vuoto ch

  for ((ic = 0; ic < len; ic++)); do
    ch[$ic]=0
  done

  ia=1
  while [[ $(TotArray ch[@]) -ne $((a * len)) ]]; do
    ic=0
#    echo "ia : $ia"
    for ((i = 0; i < len; i++)); do
      if [[ ${ch[$i]} -eq $a ]]; then
        ch[$i]=0
      fi
    done

    for ((i = 0; i < len; i++)); do
      args[$ca]="${chars[${ch[$ic]}]}${args[$ca]}"
#      echo "args ca($ca): $args[$ca]"

      if [[ $ic -eq $((len - 1)) ]]; then
        ic=0
      else
        ((ic++))
      fi
    done
    ((ca++))

    for ((i = 0; i < len; i++)); do
      pow=$((a ** i))
#      echo "pow: $pow"
      if ((ia % pow == 0)); then
        ((ch[$i]++))
      fi
    done
    ((ia++))
  done
done

for str in "${args[@]}"; do
    echo -n "$str | "
done

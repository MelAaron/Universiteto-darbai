#!/bin/sh

Funkcija(){
	for i in $* ; do
		a=`cat /home/arnsve2/lab2/shell/shell4/zodynas.txt | grep $i`;
		if [ $? -eq 1 ]; then
			echo $i >> /home/arnsve2/lab2/shell/shell4/zodynas.txt;
		fi;
	done;
}
Funkcija $*
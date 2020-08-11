#!/bin/sh
while read i
do
	a=`cat /home/arnsve2/lab2/shell/shell4/zodynas.txt | grep $i`;
	if [ $? -eq 1 ]; then
		echo $i >> /home/arnsve2/lab2/shell/shell4/zodynas.txt;
	fi;
done;
#a=$1;
#echo $a;
#if [ $# -ne 1 ]; then
#	echo "reikia paduoti viena faila";
#	exit 1;
#fi;
#if [ ! -f $1 ]; then
#	echo "Ne failas";
#	exit 1;
#fi;
#a<$1;
#echo $a;
#echo "pasieke gala";
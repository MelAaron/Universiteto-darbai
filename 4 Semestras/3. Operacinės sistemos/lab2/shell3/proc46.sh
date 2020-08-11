#!/bin/sh
#a=`ls | grep index.txt`;
#rez=$?;
#if [ rez -eq 1 ]; then #jei nėra index.txt
#	ls >> index.txt;
#fi;
#while < index.txt
#do
#	
#done;
temp=`pwd`;
script="/home/arnsve2/lab2/shell/shell4/proc46.sh";
p=$#;
if [ $p -eq 0 ]; then #pirma iteracija
	touch index.txt;
	files=`ls`;
	
	for i in $files ; do
		t=`cat index.txt | grep $i`;
		if [ $? -eq 1 ]; then #nera faile
			echo $i " aprasymas";
			read aprasymas;
			echo $i "/" $aprasymas >> index.txt;
		fi;
	done;
	
	touch temp.txt;
	while IFS=' / ' read i a
	do
	#a=`awk -F " / " '{print $1}' $i`;
	t=`ls | grep $i`;
	if [ $? -eq 0 ]; then
		cat index.txt | grep $i >> temp.txt;
	fi;
	done < "index.txt";
	rm index.txt;
	mv temp.txt index.txt;
	
	for i in $files ; do
		if [ -d $i ]; then #jei katalogas
			sh $script $i;
		fi;
	done;
else #gilesne iteracija
	dir=$1;
	cd $1;
	touch index.txt;
	files=`ls`;
	
	for i in $files ; do
		t=`cat index.txt | grep $i`;
		if [ $? -eq 1 ]; then #nera faile
			echo $i " aprasymas";
			read aprasymas;
			echo $i "/" $aprasymas >> index.txt;
		fi;
	done;
	
	touch temp.txt;
	while IFS=' / ' read i a
	do
	#a=`awk -F " / " '{print $1}' $i`;
	t=`ls | grep $i`;
	if [ $? -eq 0 ]; then
		cat index.txt | grep $i >> temp.txt;
	fi;
	done < "index.txt";
	rm index.txt;
	mv temp.txt index.txt;
	
	for i in $files ; do
		if [ -d $i ]; then #jei katalogas
			sh $script $i;
		fi;
	done;
fi;
cd $temp;
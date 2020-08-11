/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */

#include <dirent.h>
#include <stdio.h>
#include<stdlib.h>
#include <unistd.h>
#include <fcntl.h>

DIR *as_test_opendir();

DIR *as_test_opendir(){
	DIR *dir;
	struct dirent *dp;
	
	if((dir = opendir(".")) == NULL){
		printf("Katalogo negalima atidaryti");
		exit(1);
	}
	while((dp = readdir(dir)) != NULL){
		printf("i-node: %ld, vardas: %s \n",dp->d_ino, dp->d_name);
	}
	closedir(dir);
	return 0;
}

int main( int argc, char * argv[] ){
	printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
	//readdir(opendir("."));
	//DIR dir;
	//dir = as_test_opendir();
	as_test_opendir();
   return 0;
}
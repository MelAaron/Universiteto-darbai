/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

void as_fork3();

//tevas -->sunus
//tevas --> sunus2
void as_fork3(){
	int rez;
	rez = fork();
	if(rez == -1){
		puts( "Neveikia" );
		exit(1);
	}
	if(rez != 0){
		fork();
	}
}

int main( int argc, char * argv[] ){
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   
   as_fork3();
   return 0;
}
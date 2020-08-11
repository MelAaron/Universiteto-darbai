/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

void as_fork2();

//tevas -->sunus
//sunus --> anukas
void as_fork2(){
	//tevas->vaikas->anukas
	int rez;
	rez = fork();
	if(rez == -1){
		puts( "Neveikia" );
		exit(1);
	}
	if(rez == 0){
	//anukas
		fork();
	}
}

int main( int argc, char * argv[] ){
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   
   as_fork2();
   return 0;
}
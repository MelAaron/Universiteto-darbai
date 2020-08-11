/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/wait.h>

void as_fork();

//tevas -->sunus
//tevas --> sunus2
void as_fork(){
	int rez;
	rez = fork();
	if(rez == -1){
		puts( "Neveikia" );
		exit(1);
	}
	if(rez == 0){
		//vaiko operacijos
		return;
	}
	else{
		//tevo operacijos
		int st;
		system("ps");
		wait(&st);
	}
}

int main( int argc, char * argv[] ){
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   
   as_fork();
   return 0;
}
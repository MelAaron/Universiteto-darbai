/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

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
		pid_t parent;
		parent = getppid();
		printf("Proceso tevas pries sleep: %d\n", parent);
		sleep(5);
		parent = getppid();
		printf("Proceso tevas po sleep: %d\n", parent);
	}
	else{
		sleep(1);
		printf("ChildPID = %d\n", rez);
	}
}

int main( int argc, char * argv[] ){
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   
   as_fork();
   return 0;
}
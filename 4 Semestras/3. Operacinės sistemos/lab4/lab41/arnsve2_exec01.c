/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

void as_print(int sk);

void as_print(int sk){
	pid_t pid;
	pid = getpid();
	printf("PID = %d\n", pid);
	pid = getppid();
	printf("PPID = %d\n", pid);
	printf("Argumentas = %d\n", sk);
}

int main( int argc, char * argv[] ){
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   if(argc != 2){
	   printf( "Naudojimas:\n %s sveikas_skaicius\n", argv[0] );
	   exit( 255 );
   }
   int sk = atoi(argv[1]);
   as_print(sk);
   if(sk > 0){
	   int sk2 = sk-1;
	   char skString[sizeof(sk2)];
	   sprintf(skString, "%d", sk2); 
	   execl("./exec01.out", "./exec01.out", skString, NULL);
	   //char *myA[3];
	   //myA[0] = "exec01.out";
	   //myA[1] = (char *)sk2;
	   //myA[2] = NULL;
	   //execv("exec01.out", myA);
	   //execl("/home/arnsve2/lab4/exec", "./exec01.out", sk2, (char*)0);
	   //execlp("./exec01.out", "exec01.out", sk2, NULL);
	   //execve("exec01.out", "a", sk2);
	   //execle("./exec01.out", sk2, NULL);
	   //execl("/.exec01.out", skString, (char*)0);
   }
   //as_exec();
   return 0;
}
#include <stdlib.h>
#include <stdio.h>

void as_func1();
void as_func2();
void as_func3();

void as_func1(){
	 printf("Funkcija1\n");
}
void as_func2(){
	int a = 1;
	int b = 2;
	int c;
	c = a + b;
	 printf("Funkcija2\n");
	 printf("1 + 2 = %d\n", c );
}
void as_func3(){
	int a = 1;
	int b = 2;
	int c;
	c = a - b;
	printf("Funkcija3\n");
	printf("1 - 2 = %d\n", c );
}

int main( int argc, char *argv[] ){
  printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
  if( argc != 2 ){
      printf( "Naudojimas:\n %s sk\n", argv[0] );
      exit( 255 );
   }
   atexit(as_func1);
   atexit(as_func2);
   atexit(as_func3);
   if(atoi( argv[1] ) == 1)
	   _Exit(0);
   if(atoi( argv[1] ) == 2)
	   _exit(0);
   if(atoi( argv[1] ) == 3)
	   abort();
   else
	   return 0;
}
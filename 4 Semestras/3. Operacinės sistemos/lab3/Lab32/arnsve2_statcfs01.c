#include <sys/stat.h>
#include <stdio.h>
#include <stdlib.h>

int as_test_stat(const char *name);

int as_test_stat(const char *name){
	struct stat statbuf;
	stat( name, &statbuf );
	printf("Savininko id:%d\n", statbuf.st_uid);
	printf("Dydis: %ld\n", statbuf.st_size);
	printf("I-node numeris: %ld\n", statbuf.st_ino);
	printf("Leidimai: %d\n", statbuf.st_mode);
	//printf("Failo tipas: %d\n", S_IFMT(statbuf.st_mode)
	return 0;
}


int main( int argc, char *argv[] ){
	printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   if( argc != 2 ){
      printf( "Naudojimas:\n %s failas_ar_katalogas\n", argv[0] );
      exit( 255 );
   }
   as_test_stat(argv[1]);
   return 0;
}
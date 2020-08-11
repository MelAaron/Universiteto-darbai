#include <sys/stat.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/statvfs.h>
#include <ftw.h>

int as_test_rename(const char *name);

int as_test_rename(const char *name){
	rename(name, "renamed");
	return 0;
}

int main( int argc, char *argv[] ){
	printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
	if( argc != 2 ){
      printf( "Naudojimas:\n %s failas_ar_katalogas\n", argv[0] );
      exit( 255 );
   }
   as_test_rename(argv[1]);
   return 0;
}
/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */

#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>

int arnsve2_pathconf(const char *name);

int arnsve2_pathconf(const char *name){
	long namemax;
	namemax = pathconf(name, _PC_NAME_MAX);
	printf( "NAME_MAX = %ld\n", namemax );
	long pathmax;
	pathmax = pathconf(name, _PC_PATH_MAX);
	printf( "Path max = %ld\n", pathmax );
   return 0;
}

int main( int argc, char * argv[] ){
	if(argc != 2)
   {
	printf( "Naudojimas:\n %s failas_ar_katalogas\n", argv[0] );
    exit(255);
   }
   arnsve2_pathconf(argv[1]);
   return 0;
}

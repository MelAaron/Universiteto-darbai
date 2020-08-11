/* Arnas Švenčionis IFF-8/11 arnsve2 */
/* Failas: arnsve2_getcwd01.c */
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>

int as_test_getcwd();
int as_test_open();
int as_test_chdir();
int as_test_fchdir(int dskr);

int as_test_fchdir(int dskr){
	fchdir(dskr);
	as_test_getcwd();
   return 1;
}

int as_test_chdir(){
	chdir("/tmp");
	as_test_getcwd();
   return 1;
}

int as_test_open(){
	int dskr;
   dskr = open( ".", O_RDONLY );
   printf( "Deskriptorius: %d\n", dskr );
   return dskr;
}

int as_test_getcwd(){
   char *cwd;
   cwd = getcwd(NULL, pathconf( ".", _PC_PATH_MAX) );
   puts( cwd );
   free( cwd );
   return 1;
}
int main( int argc, char * argv[] ){
	printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   as_test_getcwd(argv[1]);
   int dskr;
   dskr = as_test_open();
   as_test_chdir();
   as_test_fchdir(dskr);
   return 0;
}
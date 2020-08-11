#include <sys/stat.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/statvfs.h>

int as_test_stat(const char *name);
int as_test_statvfs(const char *name);

int as_test_statvfs(const char *name){
	struct statvfs buffer;
	statvfs( name, &buffer );
	printf("statvfs:\n");
	printf("Failų sistemos bloko dydis: %ld\n", buffer.f_bsize);
	printf("Failų sistemos ID: %ld\n", buffer.f_fsid);
	printf("Failų sistemos dydis: %ld\n", buffer.f_frsize);
	printf("Maksimals failo kelio/vardo ilgis: %ld\n", buffer.f_namemax);
	return 0;
}

int as_test_stat(const char *name){
	struct stat statbuf;
	stat( name, &statbuf );
	printf("stat:\n");
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
   as_test_statvfs(argv[1]);
   return 0;
}
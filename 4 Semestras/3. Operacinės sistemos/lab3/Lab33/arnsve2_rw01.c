/* Kęstutis Paulikas KTK kespaul */
/* Failas: kespaul_open01.c */
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
int kp_test_open(const char *readff,const char *writef, int baitai);

int kp_test_open(const char *readff,const char *writef, int baitai){
   int dskr;
   dskr = open( readff, O_RDONLY );
   if( dskr == -1 ){
      perror( readff );
      exit(1);
   }
   //printf( "dskr = %d\n", dskr );
   //return dskr;
   int dskr2;
   dskr2 = open( writef, O_WRONLY | O_CREAT );
   if( dskr2 == -1 ){
      perror( writef );
      exit(1);
   }
   
   char buf[baitai];
   read(dskr, buf, baitai);
   write(dskr2, buf, baitai);
   
   return 0;
}

int main( int argc, char *argv[] ){
	printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   if( argc != 4 ){
      printf( "Naudojimas:\n %s failas_ar_katalogas failas_ar_katalogas2 sk\n", argv[0] );
      exit( 255 );
   }
   kp_test_open( argv[1], argv[2], atoi( argv[3] ) );
   //kp_test_close( d );
   //kp_test_close( d ); /* turi mesti close klaida */
   return 0;
}
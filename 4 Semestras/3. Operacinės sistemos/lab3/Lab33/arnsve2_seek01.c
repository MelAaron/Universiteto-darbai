/* Arnas Švenčionis IFF-8/11 arnsveč */
/* Failas: arnsve2_seek01.c */
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
int kp_test_open();

int kp_test_open(){
   int dskr;
   const char *readff = "sukurtas";
   dskr = open( readff, O_RDWR | O_CREAT);
   if( dskr == -1 ){
      perror( readff );
      exit(1);
   }
   
   //char* buf = "123456789012123123123";
   lseek( dskr, 1048576, SEEK_SET );
   write( dskr, "1", 1 );
   
   int rv;
   rv = close( dskr );
   if( rv != 0 ) perror ( "close() failed" );
   return rv;
}

int main( int argc, char *argv[] ){
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   kp_test_open();
   return 0;
}
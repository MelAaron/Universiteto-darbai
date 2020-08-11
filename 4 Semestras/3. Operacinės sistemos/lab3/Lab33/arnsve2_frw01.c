/* Arnas Švenčionis IFF-8/11 arnsve2 */
/* Failas: arnsve2_frw01.c */
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <unistd.h>
int kp_test_open(const char *readff,const char *writef, int baitai);

int kp_test_open(const char *readff,const char *writef, int baitai){
   FILE *fp;
   if ((fp = fopen(readff, "r")) == NULL){
	   return 1;
   }
        
	
	FILE *fp2;
	if ((fp2 = fopen(writef, "w")) == NULL){
		return 1;
	}
        
   
   char buf[baitai];
   fread( buf, sizeof(buf), 1, fp );
   
   fwrite( buf, sizeof(buf), 1, fp2 );
   
   fclose(fp);
   fclose(fp2);
   
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
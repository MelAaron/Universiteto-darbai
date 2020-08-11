/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <fcntl.h>
#include <string.h>

int main( int argc, char * argv[] ){
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   int dsrk;
   dsrk = open( "skriptas.sh", O_RDWR | O_CREAT, 0640 );
   char* buf = "#!/bin/sh \n m1=vardas \n m2='vartotojo numeris' \n m3='grupe' \n echo $m1 \n read vardas \n echo $m2 \n read numeris \n echo $m3 \n read grupe \n echo 'vardas ' $vardas ' numeris ' $numeris ' grupe ' $grupe";
   write(dsrk, buf, strlen(buf));
   close(dsrk);
   execl("chmod", "chmod", "+x", "skriptas.sh", NULL);
   execl("/bin/bash", "bash", "/home/arnsve2/lab4/exec/skriptas.sh", NULL);
   return 0;
}
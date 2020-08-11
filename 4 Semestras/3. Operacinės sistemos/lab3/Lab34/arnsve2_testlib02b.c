/* Arnas Švenčionis IFF-8/11 arnsve2 */
/* Failas: arnsve2_testlib02b.c */

#include <stdio.h>
#include <time.h>
#include "arnsve2_testlib02.h"

double arnsve2_libvar01;

int arnsve2_testlibfunc01( const char *s ){
    time_t seconds;
    seconds = time(NULL); 
    printf("Seconds since January 1, 1970 = %ld\n", seconds); 
	
	struct tm *info;
	info = localtime( &seconds );
	printf("Current local time and date: %s", asctime(info));
	
	return 0;
}
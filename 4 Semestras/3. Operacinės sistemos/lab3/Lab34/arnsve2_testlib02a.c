/* Arnas Švenčionis IFF-8/11 arnsve2 */
/* Failas: arnsve2_testlib02.c */

#include <stdio.h>
#include "arnsve2_testlib02.h"

double arnsve2_libvar01;

int arnsve2_testlibfunc01( const char *s ){
	printf( "\tparameter: \"%s\"\n", s );
	return 0;
}
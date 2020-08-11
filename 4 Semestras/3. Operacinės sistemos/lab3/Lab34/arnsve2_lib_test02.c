/* Arnas Švenčionis IFF-8/11 arnsve2 */
/* Failas: arnsve2_lib_test02.c */

#include <stdio.h>
#include "lib2/arnsve2_testlib02.h"

int main (){
	printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
	arnsve2_testlibfunc01("Hello World Library");
	arnsve2_libvar01 = 2;
	return 0;
}
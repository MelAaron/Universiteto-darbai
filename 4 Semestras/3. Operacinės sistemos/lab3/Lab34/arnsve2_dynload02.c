/* Arnas Švenčionis IFF-8/11 arnsve2 */
/* Failas: arnsve2_dynload02.c */
#include <stdio.h>
#include <stdlib.h>
#include <dlfcn.h>
int (*fptr)(const char *s);

double *pd;

int main(){
   void *dl;
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   dl = dlopen( "lib2/libarnsve202.so", RTLD_LAZY | RTLD_LOCAL );
   if( dl == NULL ){
      puts( dlerror() );
      exit(1);
   }
   pd = dlsym( dl, "arnsve2_libvar01" );
   if( pd == NULL ){
      puts( dlerror() );
      exit(1);
   }
   /* fptr = (int (*)(char*)) dlsym( dl, "kespaul_libfunc01" ); */
   *(void**)(&fptr) = dlsym( dl, "arnsve2_testlibfunc01" );
   if( fptr == NULL ){
      puts( dlerror() );
      exit(1);
   }
   *pd = 5.2;
   (*fptr)( "Library test (manualy loaded)" );
   dlclose( dl );
   return 0;
}
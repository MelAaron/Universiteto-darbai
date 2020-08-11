/* Kestutis Paulikas KTK kespaul */
/* Failas: arnsve2_cpulimit01.c */
#include <stdio.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <sys/resource.h>
int kp_change_filelimit( int nslimit, int nhlimit );
int kp_test_filelimit( const char *fn );

int kp_change_filelimit( int nslimit, int nhlimit ){
   struct rlimit rl;
   getrlimit( RLIMIT_CPU, &rl );
   printf( "RLIMIT_CPU %ld (soft) %ld (hard)\n", rl.rlim_cur, rl.rlim_max );
   rl.rlim_cur = nslimit;
   rl.rlim_max = nhlimit;
   setrlimit( RLIMIT_CPU, &rl );
   getrlimit( RLIMIT_CPU, &rl );
   printf( "RLIMIT_CPU %ld (soft) %ld (hard)\n", rl.rlim_cur, rl.rlim_max );
   
   rl.rlim_cur = 0;
   rl.rlim_max = 0;
   setrlimit( RLIMIT_CORE, &rl);
   getrlimit( RLIMIT_CORE, &rl );
   printf( "RLIMIT_CORE %ld (soft) %ld (hard)\n", rl.rlim_cur, rl.rlim_max );
   return 1;
}
int kp_test_filelimit( const char *fn ){
   int n;
   n = 1;
   int cn = 0;
   while (n > 0){
	   cn++;
	   //cn = 1 / 0;
   }
   for( n = 0; -1 != open( fn, O_RDONLY ); n++ );
   printf( "Can open %d files\n", n );
   return 1;
}
int main( int argc, char *argv[] ){
  printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   kp_change_filelimit( 1, 2 );
   kp_test_filelimit( argv[0] );
   return 0;
}
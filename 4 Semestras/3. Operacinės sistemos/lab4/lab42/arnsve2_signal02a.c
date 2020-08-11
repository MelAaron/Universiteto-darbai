/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */
#include <stdio.h>
#include <sys/types.h>
#include <unistd.h>
#include <wait.h>
#include <signal.h>
#include <stdlib.h>
static int received_sig = 0;
pid_t child_pid = -1;
void il_catch_USR1( int );       /* signalo apdorojimo f-ja */
int il_child( void );            /* vaiko proceso veiksmai */
int il_parent( pid_t pid );      /* tevo proceso veiksmai */
void as_catch_USR2();

int il_child( void ){
   sleep( 1 );
   printf( "        child: my ID = %d\n", getpid() );
   while( 1 )
      if ( received_sig == 1 ){
          printf( "        child: Received signal from parent!\n" );
          sleep( 1 );
		  system("who");
		  kill( getppid(), SIGUSR2 );
          printf( "        child: I'm exiting\n" );
          return 0;
      }
}
int il_parent( pid_t pid ){
   printf( "parent: my ID = %d\n", getpid() );
   printf( "parent: my child's ID = %d\n", pid );
   sleep( 3 );
   kill( pid, SIGUSR1 );
   printf( "parent: Signal was sent\n" );
   wait( NULL );
   printf( "parent: exiting.\n" );
   return 0;
}
void il_catch_USR1( int snum ) {
   received_sig = 1;
}
void as_catch_USR2(){
	kill(child_pid, SIGKILL);
	printf( "parent: child killed.\n" );
	sleep(5);
	printf( "parent: the work is done.\n" );
}
int main( int argc, char **arg ){
    printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   signal(SIGUSR1, il_catch_USR1);
   signal(SIGUSR2, as_catch_USR2);
   switch( child_pid = fork() ){
      case 0:                                         /* fork() grazina 0 vaiko procesui */
         il_child();
         break;
      default:                                        /* fork() grazina vaiko PID tevo procesui */
         il_parent(child_pid);
         break;
      case -1:                                        /* fork() nepavyko */
         perror("fork");
         exit(1);
   }
   exit(0);
}
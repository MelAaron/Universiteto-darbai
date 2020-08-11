/* Arnas Švenčionis arnsve2 */
/* Failas: loginas_sablonas.c */
#include <stdio.h>
#include <sys/types.h>
#include <unistd.h>
#include <wait.h>
#include <stdlib.h>
#include <fcntl.h>
#include <sys/stat.h>
int as_test_open(const char *name);

int as_test_open(const char *name){
   int dskr;
   dskr = open( name, O_RDONLY );
   if( dskr == -1 ){
      perror( name );
      exit(1);
   }
   printf( "dskr = %d\n", dskr );
   return dskr;
}

int main( int argc, char * argv[] ){
	printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
	if( argc != 2 ){
      printf( "Naudojimas:\n %s failas\n", argv[0] );
      exit( 255 );
	}
	int fd[2];
	if( pipe(fd) == -1 ){
	  fprintf( stderr, "Nepavyko sukurti programinio kanalo !\n" );
      exit( 1 );
	}
	pid_t pid;
	pid = getpid();
	int dydis;
	pid = fork();
	if(pid == 0){
		sleep( 1 );
		char buf[dydis];
		read(fd[0], &buf, sizeof( buf ));
		printf ( "(vaikas) Tevo paduota info per pipe: %s\n", buf );
	}
	else if(pid == -1){
		perror("fork");
		exit(1);
	}
	else{
		printf( "parent: my child's ID = %d\n", pid );
		int d;
		d = as_test_open(argv[1]);
		struct stat buffer;
		fstat( d, &buffer );
		dydis = buffer.st_size;
		char buf[dydis];
		read(d, buf, dydis);
		if( write( fd[1], buf, sizeof( buf ) ) != sizeof( buf ) ){
			fprintf( stderr, "Klaida rasant" );
			exit( 2 );
		}
		int sd;
		wait(&sd);
		close(d);
	}
    exit(0);
}
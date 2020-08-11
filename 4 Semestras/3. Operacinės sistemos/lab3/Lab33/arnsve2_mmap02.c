#include <stdio.h>
#include <stdlib.h>
#include <sys/mman.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/time.h>
#include <string.h>

int md_open(char *p);
int md_openw(const char *name);
int md_close(int fd);
void* md_mmapr( int d, int size );
void* md_mmapw( int d, int size );
int md_munamp( void *a, int size );
int md_usemaped( void *a, int size );

int md_open(char *p)
{
	int dskr;
	dskr = open(p, O_RDONLY);
	if(dskr == -1)
	{
		perror(p);
		exit(1);
	}
	printf("Deskriptorius = %d\n", dskr);
	return dskr;
}
int md_openw(const char *name){
   int dskr;
   dskr = open( name, O_RDWR | O_CREAT, 0640 );
   if( dskr == -1 ){
      perror( name );
      exit( 255 );
   }
   printf( "dskr = %d\n", dskr );
   return dskr;
}
int md_close(int fd){
   int rv;
   rv = close( fd );
   if( rv != 0 ) perror ( "close() failed" );
   else puts( "closed" );
   return rv;
}
void* md_mmapr( int d, int size ){
   void *a = NULL;
   a = mmap( NULL, size, PROT_READ, MAP_SHARED, d, 0 );
   if( a == MAP_FAILED ){
      perror( "mmap failed" );
      abort();
   }
   return a;
}
void* md_mmapw( int d, int size ){
   void *a = NULL;
   a = mmap( NULL, size, PROT_READ | PROT_WRITE, MAP_SHARED, d, 0 );
   if( a == MAP_FAILED ){
      perror( "mmap failed" );
      abort();
   }
   return a;
}
int md_munamp( void *a, int size ){
   int rv;
   rv = munmap( a, size );
   if( rv != 0 ){
      puts( "munmap failed" );
      abort();
   }
   return 1;
}

int main( int argc, char * argv[] ){
   int d;
   int d2;
   void *a = NULL;
   void *b = NULL;
   printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
   if( argc != 3 ){
      printf( "Naudojimas:\n %s failas failas2\n", argv[0] );
      exit( 255 );
   }
   d = md_open( argv[1] );
   d2 = md_openw(argv[2]);
   struct stat buffer;
   fstat(d, &buffer);
   int size = buffer.st_size;
   a = md_mmapr( d, size );
   b = md_mmapw(d2,size);
   ftruncate(d2, size);
   memcpy(b, a, size);
 md_munamp(a,size);
 md_munamp(b,size);
 md_close(d);
 md_close(d2);
   return 0;
}
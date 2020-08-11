#include <time.h>
#include <stdio.h>

time_t as_test_time();
void as_test_localtime(time_t secs);
void as_test_gmtime(time_t secs);

void as_test_gmtime(time_t secs){
	struct tm *gtime;
	gtime = gmtime(&secs);
	printf ("UTC: %2d:%02d\n", gtime->tm_hour % 24, gtime->tm_min);
}

void as_test_localtime(time_t secs){
	struct tm *info;
	info = localtime( &secs );
	printf("Current local time and date: %s", asctime(info));
}

time_t as_test_time(){
	time_t seconds;
    seconds = time(NULL); 
    printf("Seconds since January 1, 1970 = %ld\n", seconds); 
	return seconds;
}


int main( int argc, char *argv[] ){
  printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
  time_t secs;
  secs = as_test_time();
  as_test_localtime(secs);
  as_test_gmtime(secs);
  return 0;
}
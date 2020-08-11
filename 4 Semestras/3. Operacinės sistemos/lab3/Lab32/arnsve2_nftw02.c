#include <sys/stat.h>
#include <stdio.h>
#include <stdlib.h>
#include <sys/statvfs.h>
#include <ftw.h>

int as_test_nftw(const char *fpath, const struct stat *sb,
    int tflag, struct FTW *ftwbuf);

int as_test_display_info(const char *fpath, const struct stat *sb,
    int tflag, struct FTW *ftwbuf){
	printf("%s\n", fpath);
	return 0;
}

int main( int argc, char *argv[] ){
	printf( "(C) 2020 Arnas Švenčionis, %s\n", __FILE__ );
	nftw("/home/arnsve2", as_test_display_info, 20, FTW_PHYS);
   return 0;
}
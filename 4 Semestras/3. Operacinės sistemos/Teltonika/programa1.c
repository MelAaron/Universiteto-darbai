#define _XOPEN_SOURCE 500
//#include <sys/stat.h>
//#include <ctype.h>
//#include <sys/statvfs.h>
//#include <fcntl.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <ftw.h>
#include <string.h>

// gcc -Wall -Werror -pedantic -g -o programa1.out programa1.c

//the directory
char *pDirectory = "";
//the text
char *pText = "";
//stream
FILE *fp;
char temp[512];
//counts found results
int found_result = 0;

int find_text(const char *, const struct stat *,
    int , struct FTW *);
int open_file(const char *name);
int close_file();
void bad_parameters();

// open the file and associates a stream with it.
int open_file(const char *name){
	if((fp = fopen(name, "r")) == NULL)
		return -1;
	return 0;
}
//closes the stream, associated with the file
int close_file(){
	if(fp) {
		fclose(fp);
	}
	return 0;
}

int find_text(const char *fpath, const struct stat *sb,
     int tflag, struct FTW *ftwbuf){
	//SUBSTRING
	//Žinau, jog likęs būdas nėra geriausias, gali būti 
	//Nėra randamas tekstas jei jis yra ant nuskaitymo
	//stream ribos, arba eina per daugiau nei vieną eilutę
	int ret;
	//Only continues to read file if has permission to read the file
	if((ret = open_file(fpath)) != -1){
		int line_num = 1;
		//go through file line by line 
		while(fgets(temp, 512, fp) != NULL) {
			//if finds a substring of the text, prints it out and increases found_result
			if((strstr(temp, pText)) != NULL) {
				//printf("Žodis \"%s\" rastas faile %s eiluteje: %d\n", pText, fpath, line_num);
				printf("The word \"%s\" was found in file %s, on line: %d\n", pText, fpath, line_num);
				found_result++;
				break;
			}
			//increase line number by one
			line_num++;
		}
		close_file();
	}
	
	
	//EJIMAS SYMBOL BY SYMBOL
	//Nepavykęs bandymas tiksliau rasti tekstą faile be
	//nukirtimų
	/*
	int ret;
	if((ret = open_file(fpath)) != -1){
		struct stat statbuf;
		stat( fpath, &statbuf );
		//printf("PAV: %s\n", fpath);
		//printf("Dydis: %ld\n", statbuf.st_size);
		char buf[statbuf.st_size];
		fread(buf, sizeof(buf), 1, fp);
		int Ncount = 1;
		for( int i = 0; i < sizeof(buf); i++ ){
			if (buf[i] == '\n' ) Ncount++;
			if(buf[i] == pText[0] && buf[i+1] == pText[1]){
				int s = 0;
				int t = i;
				for( int j = 0; j < sizeof(pText); j++ ){
					if( pText[j] == buf[t] || isspace(buf[t]) && isspace(pText[j]))
						s++; 
					t++;
				}
				//printf("S: %ld\n", s);
				//printf("strlen(pText): %ld\n", strlen(pText));
				if ( s == strlen(pText) ){
					printf("The word \"%s\" was found in file %s, on line: %d \n", pText, fpath, Ncount);
					break;
				}
			}
		}
	}  */
	return 0;
}

int main( int argc, char *argv[] ){

	//if the directory is given before the text, read thext from 4th element
	if ( strcmp(argv[1], "-f") == 0 ){
		pDirectory = argv[2];
		if ( strcmp(pDirectory, "-t") == 0 || strcmp(argv[3], "-t") != 0 || argc <= 4 ){
			bad_parameters();
		}
		pText = argv[4];
		if(argc >= 5)
			for( int i = 5; i < argc; i++ ){
				char ts[] = " ";
				strcat(ts, argv[i]);
				strcat(pText, ts);
			}
	}
	//if the text is given before the directory, reads parameters until finds -f
	else if (strcmp(argv[1], "-t") == 0 ){
		int i = 3;
		pText = argv[2];
		if( strcmp(pText, "-f") == 0 )
			bad_parameters();
		while( i < argc ){
			if( strcmp(argv[i], "-f") == 0 ){
				if(argv[i + 1] == NULL)
					bad_parameters();
				pDirectory = argv[i + 1];
				break;
			}
			char ts[] = " ";
			strcat(ts, argv[i]);
			strcat(pText, ts);
			i++;
		}
	}
	//if there is no directory in the parameters
	if( strcmp(pDirectory, "-t") == 0 || strlen(pText) == 0 )
		bad_parameters();
	if( strcmp(pDirectory, "") == 0 )
		pDirectory = getcwd(NULL, pathconf( ".", _PC_PATH_MAX) );
	
	//goes through the given directory tree hierarchy
	nftw(pDirectory, find_text, 20, FTW_PHYS);
	
	//if there are no found results, prints out a message
	if(found_result == 0) {
		printf("Couldn't find \"%s\".\n", pText);
	}
	return 0;
}

void bad_parameters(){
printf( "Naudojimas:\n %s -f [APLANKALAS] -t [TEKSTAS]\n", __FILE__ );
	exit( 255 );
}
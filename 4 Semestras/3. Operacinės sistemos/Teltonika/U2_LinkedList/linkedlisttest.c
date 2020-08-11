#include <stdio.h>
#include "lib2/linkedlist.h"

#define COUNT  sizeof numbers / sizeof (int)
#define COUNT2 sizeof more_numbers / sizeof (int)
#define COUNT3  sizeof numbers2 / sizeof (float)
#define COUNT4 sizeof more_numbers2 / sizeof (float)
#define COUNT5 sizeof chars / sizeof (char)
#define COUNT6 sizeof more_chars / sizeof (char)

/* cd lib2
 gcc -fpic -Wall -pedantic -shared -o libLL.so linkedlist.c
 cd ../
 gcc -g -Wall -Werror -pedantic -Llib2 -o linkedlisttest2 linkedlisttest.c -lLL
 ./linkedlisttest2
 */
// export LD_LIBRARY_PATH=${PWD}/lib2


int numcmp(void *, void *);
void intprint(void *);
void floatprint(void *);
void charprint(void *);

int main(){
    int numbers[] = {3, 8, 23, 1, 8, 45, 3, 11, 15, 12, 42, 9, 0, 53, 15};
    int more_numbers[] = {7, 10, 4, 11};
    linkedlist *my_list = create(NULL);
    unsigned int i;

	printf("Print empty list\n");
    //Print list
    ll_print(my_list, intprint);
	
	printf("Push array of numbers\n");
    //Add all of the numbers
    for (i = 0; i < COUNT; i++)
        push(my_list, &numbers[i]);
	
    //Print out list
    ll_print(my_list, intprint);
	
	printf("Pop some numbers\n");
    //Remove first five numbers
    for (i = 0; i < COUNT2; i++)
        pop(my_list);
	
    //Print list
    ll_print(my_list, intprint);
	
	printf("Push other array of numbers\n");
    //Add numbers to front
    for (i = 0; i < COUNT2; i++)
        push(my_list, &more_numbers[i]);
	
    //Print list
    ll_print(my_list, intprint);
	
	printf("Remove some last numbers\n");
	//Remove last five numbers
	for (i = 0; i < COUNT2; i++)
        remove_last(my_list);
	
	//Print list
    ll_print(my_list, intprint);
	
	printf("Add some numbers to the end\n");
	//Add numbers to back
	for (i = 0; i < COUNT2; i++)
        add_last(my_list, &numbers[i]);
	
	//Print list
    ll_print(my_list, intprint);
	
	printf("Remove specific (middle) element\n");
	//Remove middle element
	remove_by_index(my_list, COUNT / 2);
	
	//Print list
    ll_print(my_list, intprint);

    //Free the list
    ll_free(my_list);
	
	//-----------------------------------------------
	
	float numbers2[] = {3.1, 8.65, 23.22, 1.02, 8.2, 45.6, 3.55, 11.95, 15.15, 12.26, 42.12, 9.22, 0, 53.26, 15.12};
    float more_numbers2[] = {7.15, 10.88, 4.45, 11.67};
    my_list = create(NULL);
    //unsigned int i;
	
	printf("Print empty list\n");
    //Print list
    ll_print(my_list, floatprint);
	
	printf("Push array of numbers\n");
    //Add all of the numbers
    for (i = 0; i < COUNT3; i++)
        push(my_list, &numbers2[i]);
	
    //Print list
    ll_print(my_list, floatprint);
	
	printf("Pop some numbers\n");
    //Remove first five numbers
    for (i = 0; i < COUNT4; i++)
        pop(my_list);
	
    //Print list
    ll_print(my_list, floatprint);
	
	printf("Push other array of numbers\n");
    //Add numbers to front
    for (i = 0; i < COUNT4; i++)
        push(my_list, &more_numbers2[i]);
	
    //Print list
    ll_print(my_list, floatprint);
	
	printf("Remove some last numbers\n");
	//Remove last five numbers
	for (i = 0; i < COUNT4; i++)
        remove_last(my_list);
	
	//Print list
    ll_print(my_list, floatprint);
	
	printf("Add some numbers to the end\n");
	//Add numbers to back
	for (i = 0; i < COUNT4; i++)
        add_last(my_list, &numbers2[i]);
	
	//Print list
    ll_print(my_list, floatprint);
	
	printf("Remove specific (middle) element\n");
	//Remove middle element
	remove_by_index(my_list, COUNT / 2);
	
	//Print list
    ll_print(my_list, floatprint);

    //Free list
    ll_free(my_list);
	
	//-----------------------------------------------
	
	char chars[] = {'a', 'b', 'b', 'i', 't', 'n', 'h', 'b', 'b', 'r', 'z', 'h'};
    char more_chars[] = {'v', 'p', 't', 'm'};
    my_list = create(NULL);
    //unsigned int i;
	
	printf("Print empty list\n");
    //Print list
    ll_print(my_list, charprint);
	
	printf("Push array of chars\n");
    //Add all of the numbers
    for (i = 0; i < COUNT5; i++)
        push(my_list, &chars[i]);
	
    //Print list
    ll_print(my_list, charprint);
	
	printf("Pop some chars\n");
    //Remove first five numbers
    for (i = 0; i < COUNT6; i++)
        pop(my_list);
	
    //Print list
    ll_print(my_list, charprint);
	
	printf("Push other array of chars\n");
    //Add numbers to front
    for (i = 0; i < COUNT6; i++)
        push(my_list, &more_chars[i]);
	
    //Print list
    ll_print(my_list, charprint);
	
	printf("Remove some last chars\n");
	//Remove last five numbers
	for (i = 0; i < COUNT6; i++)
        remove_last(my_list);
	
	//Print list
    ll_print(my_list, charprint);
	
	printf("Add some chars to the end\n");
	//Add numbers to back
	for (i = 0; i < COUNT6; i++)
        add_last(my_list, &chars[i]);
	
	//Print list
    ll_print(my_list, charprint);
	
	printf("Remove specific (middle) element\n");
	//Remove middle element
	remove_by_index(my_list, COUNT6 / 2);
	
	//Print list
    ll_print(my_list, charprint);

    //Free list
    ll_free(my_list);

    return 0;
}

void intprint(void *num){
    int *pnum = (int *)num;
    if (num == NULL) 
        return;
    
    printf("%d", *pnum);
}

void floatprint(void *num){
    float *pnum = (float *)num;
    if (num == NULL) 
        return;
    
    printf("%f", *pnum);
}

void charprint(void *chars){
	char *pchar = (char *)chars;
    if (chars == NULL) 
        return;
    
    printf("%c", *pchar);
}
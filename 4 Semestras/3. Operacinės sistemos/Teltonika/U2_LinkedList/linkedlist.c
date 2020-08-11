// linkedlist.c

#include <stdlib.h>
#include <stdio.h>
#include "linkedlist.h"

typedef struct node {
    void *data;
    struct node *next;
} * linkedlist;

//typedef struct node * linkedlist;

linkedlist *create(void *new_data){
    struct node *new_node;

	//create and allocate memory for new list
    linkedlist *new_list = (linkedlist *)malloc(sizeof (linkedlist));
    *new_list = (struct node *)malloc(sizeof (struct node));
    
	//insert data into new node and set the next value to null
    new_node = *new_list;
    new_node->data = new_data;
    new_node->next = NULL;
    return new_list;
}

void ll_free(linkedlist *list){
    struct node *curr = *list;
    struct node *next;
	//go through list and free each node
    while (curr != NULL) {
        next = curr->next;
        free(curr);
        curr = next;
    }
	//free the list at the end
    free(list);
}

void push(linkedlist *list, void *data){
    struct node *head = *list;
    struct node *new_node;
	//check if list is null
    if (list == NULL || *list == NULL){
        fprintf(stderr, "linkedlist_push: list is null\n");
    }

    //head = *list;
    
    //if head is empty
    if (head->data == NULL)
        head->data = data;

    //if head is not empty, add new node to front
    else {
		//allocate memory for a new node, set it's 
		//data and set it to be the first nodethe next node
        new_node = malloc(sizeof (struct node));
        new_node->data = data;
        new_node->next = head;
        *list = new_node;
    }
}

void add_last(linkedlist *list, void *data) {
    struct node *curr = *list;
	struct node *new_node;
	//check if list is null
	if (list == NULL || *list == NULL) {
        fprintf(stderr, "add_last: list is null\n");
    }
	//go to the end of the list
    while (curr->next != NULL) {
        curr = curr->next;
    }
	//allocate memory for a new node and add the node to the last element
	new_node = malloc(sizeof (struct node));
    curr->next = new_node;
    new_node->data = data;
    new_node->next = NULL;
}

void *pop(linkedlist *list){
    void *popped_data;
    struct node *head = *list;
	//check if list is null
    if (list == NULL || *list == NULL){
        fprintf(stderr, "linkedlist_pop: list is null\n");
		return NULL;
    }
	//if the list is empty, do nothing
	if(head->data == NULL) return NULL;
    //save the popped data and set the first element to the second node
    popped_data = head->data;
    *list = head->next;
	//free the first element
    free(head);
	//return popped data
    return popped_data;
}

void *remove_last(linkedlist *list) {
	//check if the list is null
	if (list == NULL || *list == NULL){
        fprintf(stderr, "remove_last: list is null\n");
		//printf("remove_last: list is null\n");
		return NULL;
    }
	
	void* retval = NULL;
	struct node *curr = *list;
	
	//if the list is empty, do nothing
	if(curr->data == NULL) return NULL;
	
    //if there is only one item in the list
    if (curr->next == NULL){
        retval = curr->data;
        free(curr);
        return retval;
    }

    //get to the second to last node in the list 
    while (curr->next->next != NULL){
        curr = curr->next;
    }
	//remove the last element by freeing it and setting the
	//second last element's next value to null
    retval = curr->next->data;
    free(curr->next);
    curr->next = NULL;
	//return removed element's data
    return retval;
}

void *remove_by_index(linkedlist *list, int n) {
    void *retval = NULL;
    struct node *curr = *list;
    struct node *temp_node = NULL;
	
	//if the list is empty, do nothing
	if(curr->data == NULL) return NULL;
	
	//check if list is null
	if (list == NULL || *list == NULL){
        fprintf(stderr, "remove_by_index: list is null\n");
		return NULL;
    }
	//if n is equal to the first element, just use the pop function
    if (n == 0){
        return pop(list);
    }
	//goes to the n element. If reaches the end of the list, returns null
    for (int i = 0; i < n-1; i++){
        if (curr->next == NULL){
            return NULL;
        }
        curr = curr->next;
    }
	//sets the return data to the deleting elements data
	//reasigns the current nodes next value
	//and frees the memory of the n'th element
    temp_node = curr->next;
    retval = temp_node->data;
    curr->next = temp_node->next;
    free(temp_node);
	//returns deleted nodes data
    return retval;
}

void ll_print(linkedlist *list, void (*print)(void *)){
    struct node *curr = *list;
	//goes through the list
    while (curr != NULL){
		//uses the function, given in the parameters
        print(curr->data);
        printf(" ");
        curr = curr->next;
    }
	//prints \n in the end
    putchar('\n');
}
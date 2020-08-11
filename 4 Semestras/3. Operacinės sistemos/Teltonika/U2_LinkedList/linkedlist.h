// linkedlist.h

//struct node;
/**
 * @brief struct node
 *
 * Contains the data of the node and a pointer to the next 
 * element in the list.
 */
typedef struct node * linkedlist;

/**
 * @brief Create a linked list
 *
 * Allocates memory for a new node and sets it up. The data 
 * parameter can be used to insert the first element into the 
 * list. Otherwise, use NULL to create a completely empty 
 * Linked List.
 */
linkedlist *create(void *data);

/**
 * @brief Frees the allocated memory for the list
 *
 * Goes through the complete list and frees the memory used 
 * by each element. At the end, the function frees the list 
 * itself.
 */
void ll_free(linkedlist *list);

/**
 * @brief Adds data element to the beginning (top) of the list
 *
 * Checks if the list has elements and according to the result, 
 * adds the given element into te beginning of the list
 */
void push(linkedlist *list, void *data);

/**
 * @brief Adds data element to the end of the list
 *
 * Goes to the end of the linked list and sets allocates memory 
 * and sets the next value to that of the given parameter.
 */
void add_last(linkedlist *list, void *data);

/**
 * @brief removes and returns head of linked list
 *
 * Frees the first element (head) of the list. And sets the next 
 * element to be the head. Returns the removed element.
 */
void *pop(linkedlist *list);

/**
 * @brief removes and returns last element of linked list
 *
 * Checks if the list has one element, and if so, removes it
 * If not, goes to the second to las node in the list and
 * removes (frees) the next (last) element
 */
void *remove_last(linkedlist *list);

/**
 * @brief removes and returns last element of linked list
 *
 * Checks if the list has one element, and if so, removes it
 * If not, goes to the second to las node in the list and
 * removes (frees) the next (last) element
 */
void *remove_by_index(linkedlist *list, int n);

/**
 * @brief print linked lis
 *
 * Goes through the list and prints each element. Uses the 
 * function, given in the parameters according to the type of the variables.
 */
void ll_print(linkedlist *list, void (*print)(void *data));
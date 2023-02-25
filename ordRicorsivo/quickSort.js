
// This function allows you to swap two components.
function swap(arr, i, j) {
    let temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}
 
/* This function uses the last element as the pivot, and moves all smaller items to the left of pivot and all larger elements to the right of pivot, and 
inserts pivot in the appropriate location in the sorted array. */

function partition(arr, start, end) {
 
    // pivot
    let pivot = arr[end];
 
/* Index of a smaller element that specifies the pivot's correct position so far. */
 
 let i = (start - 1);
 
    for (let j = start; j <= end - 1; j++) {
 
        // If current element is smaller than the pivot
        if (arr[j] < pivot) {
 
           
            i++;
            swap(arr, i, j);
        }
    }
    swap(arr, i + 1, end);
    return (i + 1);
}
 
/* The main function that implements QuickSort
          arr[] --> Array to be sorted,
          start --> Starting index,
          end --> Ending index
 */
function quickSort(arr, start, end) {
    if (start < end) {
 
        // The partitioning index is represented by pi.
        
        let pi = partition(arr, start, end);
 
        // Separately sort elements before
        // partition and after partition
        quickSort(arr, start, pi - 1);
        quickSort(arr, pi + 1, end);
    }
}
 
// Array printing function
function printArray(arr, size) {
    for (let i = 0; i < size; i++)
        document.write(arr[i] + " ");
 
    document.write("");
}
 
// Let's start by sorting the unsorted.
 
let arr  = [10,9,8,7,6,5,4,3,2,1];
let n = arr.length;
//for(let i=0; i<n; i++){
//    arr[i]= prompt("Inserisci un numero");
//}
 
document.write("Orginal array:" + arr + "<br/>");
quickSort(arr, 0, n - 1);
document.write("Sorted array (quick sort):"+arr + "<br/>");
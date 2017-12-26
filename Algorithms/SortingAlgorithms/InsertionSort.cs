using System;

namespace Algorithms.Sorting
{
    public class InsertionSort<T> : ISortingAlogrithm<T> where T : ICanBeCompared<T>
    {
        public void SortItemsAscending(T[] items)
        {   
            int indexOfAlreadySortedItems;
            T itemToBeSortedNext;

            if(items != null && items.Length != 0)
            {
                for(int indexOfItemToBeCompared = 1; indexOfItemToBeCompared<items.Length ;indexOfItemToBeCompared++)
                {
                    itemToBeSortedNext =  items[indexOfItemToBeCompared];
                    
                    indexOfAlreadySortedItems = indexOfItemToBeCompared -1 ;
                    
                    while(indexOfAlreadySortedItems >= 0 && itemToBeSortedNext.IsLessThan(items[indexOfAlreadySortedItems]))
                    {                        
                        items[indexOfAlreadySortedItems + 1 ] = items[indexOfAlreadySortedItems];
                     
                        indexOfAlreadySortedItems--;
                    }

                    items[indexOfAlreadySortedItems + 1] = itemToBeSortedNext;
                }
            }
        }
    }

}
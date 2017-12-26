using System; 
using Algorithms.Sorting;

namespace Algorithms 
{
    public static  class SortingAlgorithmsFactory<T>  where T : ICanBeCompared<T>
    {
        public static ISortingAlogrithm<T> CreateSortingInstnace(SortingAgorithmType sortingAgorithmType) 
        {
            ISortingAlogrithm<T> sortingAlgorithm = null; 

            switch (sortingAgorithmType) 
            {
                case SortingAgorithmType.InsertionSort:
                sortingAlgorithm = new InsertionSort<T>();
                break; 
            }

            return sortingAlgorithm; 
        }
    }
}
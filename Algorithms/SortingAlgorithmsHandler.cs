using System;

namespace Algorithms
{
    public interface ISortingListener<T> where T : ICanBeCompared<T>
    {
        SortingAgorithmType AlgorithmType { get; set; }
        
        T[] ItemsToBeSorted { get; set; }
        
        void ItemsSortedHandler();
    }

    public class SortingHanlder<T> where T : ICanBeCompared<T>
    {
        private ISortingListener<T> _sortingListener;

        public SortingHanlder(ISortingListener<T> sortingListener)
        {
            _sortingListener = sortingListener;            
        }

        public void StartSorting()
        {
            ISortingAlogrithm<T> sortingAlgorithm = SortingAlgorithmsFactory<T>.CreateSortingInstnace(_sortingListener.AlgorithmType);

            sortingAlgorithm.SortItemsAscending(_sortingListener.ItemsToBeSorted);

            _sortingListener.ItemsSortedHandler();
        }
    }
}
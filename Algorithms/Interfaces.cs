using System;

namespace Algorithms
{
    public interface ICanBeCompared<T>
    {
        bool IsLessThan(T otherElement);
    }
    
    public interface ISortingAlogrithm<T> where  T : ICanBeCompared<T>
    {
         void SortItemsAscending(T[] items);
    }
}

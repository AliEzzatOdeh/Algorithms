using System;

using Algorithms;

namespace AlgorithmsTest
{
    class Item : ICanBeCompared<Item>
    {
        public int Order{get; set;}

        public Item() {}

        public Item(int order) => Order = order;
        public bool IsLessThan(Item otherItem) => this.Order < otherItem.Order;
    }

    class SortingListener : ISortingListener<Item>
    {
        public SortingAgorithmType AlgorithmType { get; set; }
        
        public Item[] ItemsToBeSorted { get; set; }
        
        public void ItemsSortedHandler()
        {
            foreach(var item in ItemsToBeSorted)
            {
                Console.WriteLine("item with order : " + item.Order);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;

            while(input != -1)
            {
                Console.WriteLine("Please choose Algoritm categories:(-1 for exit)");
                Console.WriteLine(" 1) Sorting");
 
                if(int.TryParse(Console.ReadLine(), out input))
                {
                    switch(input)
                    {
                        case 1:
                        HandleSortingAlgorithms();
                        break;
                    }                   
                }
                else
                {
                    Console.WriteLine("Plese enter a valid number.");
                }
            }          
        }

        private static void HandleSortingAlgorithms()
        {
            Random random = new Random();  
            Item[] items = new Item[100];
            int input;
            SortingHanlder<Item> sortingHandler;
            object sortingAgorithmType;

            for(int i = 0; i < items.Length; i++)
            {
                items[i] = new Item();
                items[i].Order = random.Next(0, 100);  
            }

            SortingListener sortingListener = new SortingListener();
            
            sortingListener.ItemsToBeSorted  = items; 
            
            Console.WriteLine("Please choose Sorting Algoritm:");

            Array sortingAlgorithmsTypes =  Enum.GetValues(typeof(SortingAgorithmType));

            for(int i = 0; i< sortingAlgorithmsTypes.Length; i++)
            {
                Console.WriteLine(string.Format("{0}) {1}",i,sortingAlgorithmsTypes.GetValue(i)));
            }

            if(int.TryParse(Console.ReadLine(), out input))
            {
                  if(Enum.TryParse(typeof(SortingAgorithmType),input.ToString(),out sortingAgorithmType))
                  {
                        sortingListener.AlgorithmType = (SortingAgorithmType)sortingAgorithmType;

                        sortingHandler = new SortingHanlder<Item>(sortingListener);

                        sortingHandler.StartSorting();
                  }
                  else
                  {
                      Console.WriteLine("invalid number.");
                  }
            }
            else
            {
                Console.WriteLine("invalid number.");
            } 
        }
    }
}

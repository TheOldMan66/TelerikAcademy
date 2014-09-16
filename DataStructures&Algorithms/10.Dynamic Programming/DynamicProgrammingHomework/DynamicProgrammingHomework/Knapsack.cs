using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingHomework
{
    class Item
    {
        public string Description;
        public int Weight;
        public int Value;

        public Item(string description, int weight, int value)
        {
            Description = description;
            Weight = weight;
            Value = value;
        }

    }

    class Knapsack
    {
        static void Main(string[] args)
        {
            var items = new List<Item>(){
                 new Item("Apple", 139, 140),
                 new Item("Banana", 27, 60),
                 new Item("Beer", 52, 10),
                 new Item("Book", 130, 110),
                 new Item("Camera", 232, 230),
                 new Item("Cheese", 123, 130),
                 new Item("Chocolate Bar", 15, 60),
                 new Item("Compass", 13, 35),
                 new Item("Jeans", 48, 10),
                 new Item("Map", 9, 150),
                 new Item("Notebook", 322, 280),
                 new Item("Sandwich", 50, 60),
                 new Item("Ski Jacket", 143, 175),
                 new Item("Ski Pants", 42, 70),
                 new Item("Socks", 44, 50),
                 new Item("Sunglasses", 17, 20),
                 new Item("Suntan Lotion", 111, 117),
                 new Item("T-Shirt", 24, 15),
                 new Item("Tin", 68, 45),
                 new Item("Towel", 118, 112),
                 new Item("Umbrella", 73, 40),
                 new Item("Water", 153, 200)
            };

            /*            var items = new List<Item>() 
                        {
                            new Item ("beer", 3, 2,1),
                            new Item("vodka",8, 12,1),
                            new Item("cheese",4,5,1),
                            new Item("nuts",1,4,1),
                            new Item("ham",2,3,1),
                            new Item("whiskey",8,13,1)
                        }; */

            int numOfItems = items.Count;
            int maxWeight = 1000;
            int[,] values = new int[numOfItems, maxWeight + 1];
            bool[,] keep = new bool[numOfItems, maxWeight + 1];

            for (int item = 0; item < numOfItems; item++)
            {
                for (int currentWeight = 1; currentWeight <= maxWeight; currentWeight++)
                {
                    if (currentWeight < items[item].Weight) // item don't fit in knapsack
                    {
                        if (item > 0) // get previous better solutions (or zero)
                        {
                            values[item, currentWeight] = values[item - 1, currentWeight];
                        }
                    }
                    else // item fit in knapsack
                    {
                        if (item == 0) // it's a first item, so no better solution 
                        {
                            values[item, currentWeight] = items[item].Value;
                            keep[item, currentWeight] = true;
                        }
                        else
                        {
                            values[item, currentWeight] = values[item - 1, currentWeight];
                            if (currentWeight > items[item].Weight)
                            {
                                int newValue = items[item].Value + values[item - 1, currentWeight - items[item].Weight];
                                if (newValue > values[item - 1, currentWeight])
                                {
                                    values[item, currentWeight] = newValue;
                                    keep[item, currentWeight] = true;
                                }
                            }
                        }
                    }
                }
            }

            // let's collect items from "keep" table

            int i = items.Count;
            int w = maxWeight;
            int optimalWeight = 0;
            int optimalValue = 0;
            List<Item> itemsToKeep = new List<Item>();
            while (i > 0)
            {
                i--;
                if (keep[i, w]) // hmmm... i have to get this element
                {
                    itemsToKeep.Add(items[i]);
                    w -= items[i].Weight;
                    optimalValue += items[i].Value;
                    optimalWeight += items[i].Weight;
                }
            }

            // and print them
            foreach (var item in itemsToKeep)
            {
                Console.WriteLine("Item: {0}, Weight: {1}, Value {2}", item.Description, item.Weight, item.Value);
            }
            Console.WriteLine();
            Console.WriteLine("Maximum weight for knapsack: " + maxWeight);
            Console.WriteLine("Optimal weight: {0}. Optimal value: {1}", optimalWeight, optimalValue);
        }
    }
}

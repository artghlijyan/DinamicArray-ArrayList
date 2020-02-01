using System;

namespace DynamicArray
{
    class Program
    {
        public static void Print(System.Collections.IEnumerable coll)
        {
            Console.WriteLine("Dynamic Array");

            foreach (var element in coll)
            {
                Console.Write("    {0}", element);
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] arr = { };
            ArrayList<int> instance = new ArrayList<int>(arr);
            instance.Add(5);
            instance.Add(10);
            instance.Add(15);
            instance.Add(20);
            instance.Add(25);

            instance.Insert(2, 12);
            instance.RemoveAt(3);

            instance.Remove(15);

            Print(instance);
        }
    }
}

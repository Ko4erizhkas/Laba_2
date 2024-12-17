using System.Numerics;
using System.Xml.Linq;

namespace Laba_2
{
    public class List
    {
        private List<int> elements;
        public List() 
        {
            elements = new List<int>();
        }
        public List(IEnumerable<int> elements)
        {
            this.elements = new List<int>(elements);
        }
        public override string ToString()
        {
            return $"List({string.Join(", ", elements)})";
        }
        public static List operator +(int item, List list)
        {
            var newList = new List(list.elements);
            newList.elements.Insert(0, item);
            return newList;
        }
        public static List operator --(List list)
        {
            var newList = new List(list.elements);
            if (newList.elements.Count > 0)
            {
                list.elements.RemoveAt(0);
            }
            return newList;
        }
        public static bool operator !=(List list1, List list2)
        {
            return !list1.Equals(list2);
        }
        public static bool operator ==(List list1, List list2)
        {
            return list1.Equals(list2);
        }
        public static List operator *(List list1, List list2)
        {
            var newList = new List(list1.elements);
            newList.elements.AddRange(list2.elements);
            return newList;
        }
        public static void Run()
        {
            List list1 = new List(new int[] { 3, 6, 1 });
            List list2 = new List(new int[] { 1, 3, 6 });

            List list3 = 1 + list1;
            Console.WriteLine(list3);

            list3 = --list1;
            Console.WriteLine(list3);

            Console.WriteLine(list1 != list2);
            Console.WriteLine(list1 != new List(new int[] { 1, 23, 45 }));

            List list4 = list1 * list2;
            Console.WriteLine(list4);
        }
    }
    internal class Laba_2
    {
        static void Main(string[] args)
        {
            List list = new List();
            List.Run();
        }
    }
}

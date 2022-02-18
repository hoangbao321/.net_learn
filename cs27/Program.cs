using System;
using System.Collections.Generic;

namespace cs27
{
    class Product
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    class Program
    {
        //queue
        //stack
        //LinkedList 
        // dictionary
        //SortedList --key value
        static void Main(string[] args)
        {
            //queue
            Queue<string> cachoso = new Queue<string>();
            cachoso.Enqueue("ho so 1");
            cachoso.Enqueue("ho so 2");
            cachoso.Enqueue("ho so 3");

            for (int i = 0; i < cachoso.ToArray().Length; i++)
            {
                Console.WriteLine(cachoso.ToArray()[i]);
            }

            foreach (var item in cachoso)
            {
                Console.WriteLine(item);
            }
            var hoso = cachoso.Dequeue();
            Console.WriteLine($"Da Xu ly cac ho so: {hoso} -ho so con la: {cachoso.Count}");

            //linkedlist -- Linklistnode
            LinkedList<string> cacbaihoc = new();
            LinkedListNode<string> bh4 = cacbaihoc.AddLast("Bai hoc 4");
            LinkedListNode<string> bh3 = cacbaihoc.AddBefore(bh4, "Bai hoc 3");
            LinkedListNode<string> bh1 = cacbaihoc.AddBefore(bh3, "Bai hoc 1");
            LinkedListNode<string> bh5 = cacbaihoc.AddLast("Bai hoc 5");
            LinkedListNode<string> bh2 = cacbaihoc.AddAfter(bh1, "Bai hoc 2 ");
            Console.WriteLine("---------nut tu node 1 ve dau");

            LinkedListNode<string> node = bh2;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Previous;
            }
            Console.WriteLine("---test");
            LinkedListNode<string> node_5 = bh5;
            while (node_5 != null)
            {
                Console.WriteLine(node_5.Value);
                node_5 = node_5.Previous;
            }

            Console.WriteLine("--- node tu dau ve cuoi");
            LinkedListNode<string> node_1 = bh5;
            do
            {
                Console.WriteLine(node_1.Value);
                node_1 = node_1.Next;
            }
            while (node_1 != null);

            LinkedListNode<string> node_2 = cacbaihoc.First;
            do
            {
                Console.WriteLine(node_2.Value);
                node_2 = node_2.Next;
            }
            while (node_1 != null);

            Console.WriteLine("--------duyet tat ca phan tu cua mang");
            foreach (var item in cacbaihoc)
            {
                Console.WriteLine(item);
            }
            //Dictionary
            Console.WriteLine("---dictonary");
            Dictionary<string, Product> Dict_sp = new Dictionary<string, Product>()
            {
                ["one"] = new Product() { Name = "a", ID = 1 },
                ["two"] = new Product() { Name = "b", ID = 2 },
            };
            Dict_sp.Add("three", new Product() { Name = "c", ID = 3 });
            foreach (KeyValuePair<string, Product> item in Dict_sp)
            {
                Console.WriteLine(item.Key + " " + item.Value.Name);
            }
            // tìm = key #sorted list
            foreach (var key in Dict_sp.Keys)
            {
                var sp1 = Dict_sp[key];

                Console.WriteLine(sp1.Name + " " + sp1.ID + "key: " + key);
            }

            //Hashset
            Console.WriteLine("---Hashset");
            HashSet<string> set1 = new()
            {
                "a",
                "a",
                "b",
                "ccc"
            };
            HashSet<string> set2 = new()
            {
                "ccc",
                "d"
            };
            set2.ExceptWith(set1);
            foreach (var item in set2)
            {
                Console.WriteLine(item);
            }
            //ko thuc hanh voi product dc
            //HashSet<Product> set1 = new()
            //{
            //    new Product() { Name = "a", ID = 1 },
            //};
            //HashSet<Product> set2 = new()
            //{
            //    new Product() { Name = "a", ID = 1 },
            //};

            //set1.IntersectWith(set2);
            set1.IsSubsetOf(set2);// set1 co la tap con cua set2 return true/false
            set1.IsSupersetOf(set2); // set1 chứa set2 , set2 có phải là con của set1 


            //sorted list
            Console.WriteLine("---sortedlist");
            SortedList<string, Product> products = new SortedList<string, Product>();
            products.Add("sp1", new Product() { Name = "a", ID = 1 });
            products["sp2"] = new Product() { Name = "b", ID = 2 };
            //products.Remove("sp2");
            foreach (KeyValuePair<string, Product> item in products)
            {
                var key = item.Key;
                var sp = item.Value;
                Console.WriteLine(item.Key + " " + item.Value.Name + " " + item.Value.ID);
                Console.WriteLine(item.Key + " " + sp.Name + " " + sp.ID);
            }
            // tìm qua value
            for (int i = 0; i < products.Values.Count; i++)
            {
                var value = products.Values[i];
                var key = products.Keys[i];
                Console.WriteLine(key + " " + value.ID);
            }
            // tìm qua key
            for (int i = 0; i < products.Keys.Count; i++)
            {
                var key = products.Keys[i];
                var sp = products[key];
                Console.WriteLine(products.Keys[i] + " ");
            }

            //List<int> ds = new List<int>();
            //ds.AddRange(new int[] { 1, 3, 9, 9, 9 });
            //bool check;
            //do
            //{
            //    check = ds.Remove(9);
            //}
            //while (check == true);
            //ds.ForEach(x => Console.Write(x + " "));
        }
    }
}

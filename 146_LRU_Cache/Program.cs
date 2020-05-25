using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _146_LRU_Cache
{
    public class LRUCache
    {
        public class DoubleLinkedList
        {
            public DoubleLinkedList next;
            public DoubleLinkedList prev;
            public int key;
            public int val;

            public DoubleLinkedList(int k, int v)
            {
                key = k; val = v;
            }
        }
        Dictionary<int, DoubleLinkedList> map;
        DoubleLinkedList head;
        DoubleLinkedList tail;
        int size;
        int capacity;
        public LRUCache(int cap)
        {
            capacity = cap;
            map = new Dictionary<int, DoubleLinkedList>();
            head = new DoubleLinkedList(0, 0);
            tail = new DoubleLinkedList(0, 0);
            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {

                if (tail.prev.key != key)
                {
                    var node = map[key];
                    RemoveNode(node);
                    AddToEnd(node);
                }
                return map[key].val;
            }
            return -1;
        }
        public void AddToEnd(DoubleLinkedList node)
        {
            var before = tail.prev;
            before.next = node;
            node.prev = before;
            tail.prev = node;
            node.next = tail;
        }
        public void RemoveNode(DoubleLinkedList node)
        {
            var before = node.prev;
            before.next = node.next;
            node.next.prev = before;
        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                map[key].val = value;
                var node = map[key];
                RemoveNode(node);
                AddToEnd(node);
            }
            else
            {
                size++;
                if (size > capacity)
                {
                    var node = head.next;
                    RemoveNode(node);
                    map.Remove(node.key);
                    size--;
                }
                var newNode = new DoubleLinkedList(key, value);
                AddToEnd(newNode);
                map.Add(key, newNode);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Debug.Log("XXXXXXXXXXXXXXX");
            int capacity = 2;
            LRUCache cache = new LRUCache(capacity);
            cache.Put(1, 1);
            cache.Put(2, 2);
            int nNum = cache.Get(1);       // 返回  1
            Console.WriteLine("nNum: " + nNum);

            cache.Put(3, 3);    // 该操作会使得密钥 2 作废
            nNum = cache.Get(2);       // 返回 -1 (未找到)
            Console.WriteLine("nNum: " + nNum);

            cache.Put(4, 4);    // 该操作会使得密钥 1 作废
            nNum = cache.Get(1);       // 返回 -1 (未找到)
            Console.WriteLine("nNum: " + nNum);

            nNum = cache.Get(3);       // 返回  3
            Console.WriteLine("nNum: " + nNum);

            nNum = cache.Get(4);       // 返回  4
            Console.WriteLine("nNum: " + nNum);



            Console.WriteLine("XXXXXXXXXXX");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDelegate
{

    //委托声明
    delegate int PrintDelegate(int n);
    class ClassA
    {
        public delegate int PrintDelegate2(int n);
        int num = 10;
        private static ClassA _instance;
        public static ClassA Instance
        {
            get {
                if (_instance == null)
                    _instance = new ClassA();
                return _instance;
                }
        }

        public PrintDelegate2 OnPrint2 { set; get; }

        public int Add(int x)
        {
            return num + x;
        }

        public int Def(int x)
        {
            return num - x;
        }

        public int Print1(int n)
        {
            Console.WriteLine($"Print1: { Add(n)}");
            return Add(n);
        }

        public static int Print2(int n)
        {
            Console.WriteLine($"Print2: { ClassA.Instance.Add(n + 1)}");
            return ClassA.Instance.Add(n + 1);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ClassA a = new ClassA();
            PrintDelegate printDel;
            //直接方法赋值
            printDel = a.Print1;
            printDel += ClassA.Print2;
            printDel += a.Print1;
            printDel += ClassA.Print2;

            //减委托方法
            //printDel -= ClassA.Print2;
            //printDel -= ClassA.Print2;

            //lamada方法
            printDel += (x) => { return 20 + x; };

            //匿名委托
            printDel += delegate (int x) { return 30 + x; };

            
            if (null != printDel)
            {
                int n = printDel(4);
                Console.WriteLine($"Delegate Resoult: {n}");
            }
            else
                Console.WriteLine("Delegate Is Empty");


            //类内部委托 修改为属性
            a.OnPrint2 = a.Print1;
            if (null != a.OnPrint2)
            {
                int x = a.OnPrint2(2);
                Console.WriteLine($"Delegate Resoult OnPrint2: {x}");
            }

            Console.ReadKey();
        }
    }
}

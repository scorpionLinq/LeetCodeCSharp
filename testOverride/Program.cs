using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testOverride
{
    class TestA
    {
        public void Print1()
        {
            Console.WriteLine($"TestA Print1");
        }

        public virtual void Print2()
        {
            Console.WriteLine($"TestA Print2");
        }

        public virtual void Print3()
        {
            Console.WriteLine($"TestA Print3");
        }

        public void Print4()
        {
            Console.WriteLine($"TestA Print4");
        }

        public void Print5(string str)
        {
            Console.WriteLine($"TestA Print5 {str}");
        }

    }

class TestB : TestA
    {
        public void Print1()
        {
            Console.WriteLine($"TestB Print1");
        }

        public override void Print2()
        {
            //base.Print2();
            Console.WriteLine($"TestB Print2");
        }

        public new void Print3()
        {
            Console.WriteLine($"TestB Print3");
        }

        public new void Print4()
        {
            Console.WriteLine($"TestB Print4");
        }
    }

    class TestC : TestB
    {
        public void Print1()
        {
            Console.WriteLine($"TestC Print1");
        }

        public override void Print2()
        {
            //base.Print2();
            Console.WriteLine($"TestC Print2");
        }

        new public void Print3()
        {
            Console.WriteLine($"TestC Print3");
        }

        new public void Print4()
        {
            Console.WriteLine($"TestC Print4");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            TestA a = new TestA();  //基类
            TestB b = new TestB();//派生类
            TestC c = new TestC();//派生类
            TestA aC = new TestC();//派生类 强转 基类
            TestB bC = new TestC();//派生类 强转 基类

            //基本方法:各自调用各自，互不影响
            a.Print1(); //执行  TestA.Print1
            b.Print1(); //执行  TestB.Print1
            c.Print1(); //执行  TestC.Print1
            aC.Print1();//执行  TestA.Print1
                        //强转之后调用的是声明类(基类)方法，而不是实例类(派生类)方法
            Console.WriteLine("====================");

            //虚方法 + 覆写（override）: 各自调用各自
            a.Print2();     //执行  TestA.Print2
            b.Print2();     //执行  TestB.Print2
            c.Print2();     //执行  TestC.Print2
            aC.Print2();    //执行  TestC.Print2
            //强转之后调用的是实例类(派生类)方法，而不是声明类(基类)方法
            Console.WriteLine("====================");
            //虚方法 + 覆盖(new)
            a.Print3();     //执行  TestA.Print3
            b.Print3();     //执行  TestB.Print3
            c.Print3();     //执行  TestC.Print3
            aC.Print3();    //执行  TestA.Print3

            Console.WriteLine("====================");
            //覆盖
            a.Print4();     //执行  TestA.Print4
            b.Print4();     //执行  TestB.Print4
            c.Print4();     //执行  TestC.Print4
            aC.Print4();    //执行  TestA.Print4
            //Console.ReadKey();

            Console.WriteLine("====================");
            //当前类没有，直接调用基类方法
            a.Print5("TestA");     //执行  TestA.Print5
            b.Print5("TestB");     //执行  TestA.Print5
            c.Print5("TestC");     //执行  TestA.Print5
            aC.Print5("TestAC");    //执行  TestA.Print5
            bC.Print5("TestBC");    //执行  TestA.Print5

            Console.WriteLine("====================");

            //基类强转派生类，报错
            TestB ba = a as TestB;
            ba.Print1();
            ba.Print2();
            ba.Print3();
            ba.Print4();
            ba.Print5("TestBA");
            Console.ReadKey();

            //总结 基于相同方法名，参数类型和数量相同
            //覆写(重载): override 与 virtual 组成
            //              覆写会将基类的引用指向派生类(强制转换派生类为基类对象时，调用的是派生类方法)
            //覆盖(new): 没有new时，为隐式声明new
            //              覆盖不会修改引用，各自调用各自的方法（根据实例化对象的类型，强制转换也不会导致变更）
        }
    }
}

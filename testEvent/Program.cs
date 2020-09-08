using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testEvent
{
    delegate void Handler(object obj, EventArgsTest e);
    class EventArgsTest: EventArgs
    {
        public int x { set; get; }
        
    }
    struct structTest
    {
        int x;
    }
    class TestEvent
    {
        public TestEvent()
        {

        }

        ~TestEvent()
        {

        }

        public event Handler TestEvent1, TestEvent2, TestEvent3;

        public void DoCount()
        {
            for (int i = 1; i <= 10;++i)
            {
                if (null != TestEvent1)
                {

                    EventArgsTest e = new EventArgsTest();
                    e.x = 10;
                    TestEvent1(this, e);
                }
            }
        }
    }

    class Program
    {
        public static void PrintX(object sender, EventArgsTest e)
        {
            Console.WriteLine($"XXXXXXXXXXXXX:{e.x}");
        }

        static void Main(string[] args)
        {
            TestEvent testE = new TestEvent();
            testE.TestEvent1 += PrintX;
            testE.DoCount();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testAsync
{
    //测试方法1
    class MyDownloadString
    {
        Stopwatch sw = new Stopwatch();

        public void DoRun()
        {
            const int LargeNumber = 6000000;
            sw.Start();
            string strHttp1 = "https://www.baidu.com";
            string strHttp2 = "https://cn.bing.com";
            Task<int> t1 = CountCharacters(1, strHttp1);
            Task<int> t2 = CountCharacters(2, strHttp2);
            CountToALargeNumber(1,LargeNumber);
            CountToALargeNumber(2, LargeNumber);
            CountToALargeNumber(3, LargeNumber);
            CountToALargeNumber(4, LargeNumber);

            Console.WriteLine(" Char in {0} : {1}", strHttp1, t1);
            Console.WriteLine(" Char in {0} : {1}", strHttp2, t2);
        }

        private async Task<int> CountCharacters(int id,string uriString)
        {
            WebClient wc1 = new WebClient();
            Console.WriteLine("Starting call {0} :  {1,4:No} ms", id,sw.Elapsed.TotalMilliseconds);

            string result = await wc1.DownloadStringTaskAsync(new Uri(uriString));
            Console.WriteLine("  Call {0} completed: {1,4:No} ms",id,sw.Elapsed.TotalMilliseconds);
            return result.Length;
        }

        private void CountToALargeNumber(int id, int value)
        {
            for (long i = 0; i < value; ++i) ;
            Console.WriteLine(" End Counting {0} : {1,4:No} ms",id,sw.Elapsed.TotalMilliseconds);
        }
    }

    //测试方法2
    static class DoAsyncStuff
    {
        public static async Task<int> CalculateSumAsync(int n1,int n2)
        {
            int sum = await Task.Run(() => GetSum(n1, n2));
            Console.WriteLine($"Value: {sum}");
            return sum;
        }

        private static int GetSum(int n1,int n2)
        {
            return n1 + n2;
        }
    }

    //测试await
    class  TestAwait
    {
        public int Get10()
        {
            return 10;
        }

        public async Task DoWorkAsync()
        {
            Func<int> ten = new Func<int>(Get10);
            int a = await Task.Run(ten);
            int b = await Task.Run(new Func<int>(Get10));
            int c = await Task.Run(() => { return 10; });

            Console.WriteLine($"{a} {b} {c}");

            await Task.Run(() => Console.WriteLine(5.ToString()));

            Console.WriteLine((await Task.Run(() => 6)).ToString());

            await Task.Run(() => Task.Run(() => Console.WriteLine(7.ToString())));

            int value = await Task.Run(() => Task.Run(() => 8));
            Console.WriteLine(value.ToString());

        }
    }

    class CancelAsync
    {
        public async Task RunAsync(CancellationToken  ct)
        {
            if (ct.IsCancellationRequested)
                return;
            await Task.Run(() => CycleMethod(ct), ct);
        }

        void CycleMethod(CancellationToken ct)
        {
            Console.WriteLine("Starting CycleMethod ");
            const int max = 5;
            for (int i = 0; i < max; i++)
            {
                if (ct.IsCancellationRequested)
                    return;
                Thread.Sleep(1000);
                Console.WriteLine($"           {i+1} of {max} iteration completed");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //测试方法1
            //MyDownloadString ds = new MyDownloadString();
            //ds.DoRun();

            //测试方法2
            //var x = DoAsyncStuff.CalculateSumAsync(5, 6);
            //Console.WriteLine("Exiting 1111111111 ");
            //Thread.Sleep(1000);
            //Console.WriteLine("Exiting ");

            //测试await
            //TestAwait my = new TestAwait();
            //Task t = my.DoWorkAsync();
            //t.Wait();

            //测试
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            CancelAsync mc = new CancelAsync();
            Task t = mc.RunAsync(token);

            //Thread.Sleep(3000);
            //cts.Cancel();

            t.Wait();
            Console.WriteLine($"Was Cancelled:{token.IsCancellationRequested}");

            Console.ReadKey();
        }
    }
}

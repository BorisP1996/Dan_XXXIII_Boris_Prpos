using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Zadatak_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadClass tc = new ThreadClass();
            //creating list of threads, created thread will be added here
            List<Thread> threadList = new List<Thread>();

            for (int i = 0; i < 4; i++)
            {
                // creating temp string that will be part of thread name (1,22,3,44)
                int temp = i + 1;
                string tString = temp.ToString();
                if (temp == 2 || temp == 4)
                {
                    tString = temp.ToString() + temp.ToString();
                } 
                //creating threads and giving them methods via lambda expression
                Thread t = new Thread(new ThreadStart(() => tc.DoWork(Thread.CurrentThread)))
                {
                    //initializing threads name
                    Name = string.Format("THREAD_" + tString)
                };
                //displaying names
                Console.WriteLine("{0} is created.", t.Name);
                //inserting threads into list, it will be easier to acces them later
                threadList.Add(t);
            }
            Console.WriteLine();
            //creating stopwatch
            Stopwatch sw = new Stopwatch();
            //starting stopwatch, it needs to measure time that first two threads take to execute their work
            sw.Start();
            //starting first two threads
            threadList[0].Start();
            threadList[1].Start();
            //join on two first two threads
            threadList[0].Join();
            threadList[1].Join();
            //stoping stopwatch and displaying time
            sw.Stop();
            Console.WriteLine("Elapsed time after THREAD_1 and THREAD_22 is :{0}mS\n", sw.ElapsedMilliseconds);
            //starting last two threads
            threadList[2].Start();
            threadList[3].Start();

            Console.ReadLine();
        }
    }
}

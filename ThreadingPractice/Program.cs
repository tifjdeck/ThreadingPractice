//Title: Threading Practice
//Date: 03/06/2023
//Name: Tiffany Decker
//File: Main program

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dartsToThrow = 0;
            int threadsToRun = 0;
            int dartsInside = 0;
            int dartsTotal = 0; 
            double piEstimate = 0.0;
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Enter number of darts to throw (per thread):");
            dartsToThrow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of threads to run:");
            threadsToRun = Convert.ToInt32(Console.ReadLine());

            List<Thread> threads = new List<Thread>(threadsToRun);
            List<FindPiThread> findPiThreads = new List<FindPiThread>(threadsToRun);
            
            stopwatch.Start();
            for(int i = 0; i < threadsToRun; i++)
            {
                FindPiThread tempPiThread = new FindPiThread(dartsToThrow);
                findPiThreads.Add(tempPiThread);
                Thread tempThread = new Thread(new ThreadStart(findPiThreads[i].throwDarts));
                threads.Add(tempThread);
                threads[i].Start();
                Thread.Sleep(16);
            }

            foreach(Thread thread in threads)
            {
                thread.Join();
            }

            foreach(FindPiThread piThread in findPiThreads)
            {
                dartsInside += piThread.DartsInside;
            }

            dartsTotal = dartsToThrow * threadsToRun;
            piEstimate = (4.0 * (dartsInside / (double)dartsTotal));
            
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            //Code for the stopwatch is found at: https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-7.0 

            Console.WriteLine($"With {dartsTotal} darts thrown across {threadsToRun} threads, pi is estimated to be {piEstimate}");
            Console.WriteLine($"Estimation performed in {timeSpan.Minutes} minutes, {timeSpan.Seconds} seconds, and {timeSpan.Milliseconds} milliseconds.");
            Console.ReadKey();
        }
    }
}

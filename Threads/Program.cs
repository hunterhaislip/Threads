/*
 * Author: Hunter Haislip
 * Date: 3/14/19
 * File: Program.cs
 * Description: Simple PI project
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class FindPiThread // First FindPiThread Class
    {
        public int darts;
        public int count;
        public Random Throws;
        //Public so they can all be accessed

        public FindPiThread(int t) // Constructor that initializes the constructor
        {
            Throws = new Random();
            darts = t;
            count = 0;
        }

        public void throwDarts() // Function that throws the darts
        {
            double x, y;
            for (int i = 0; i < darts; i++)
            {
                x = Throws.NextDouble();
                y = Throws.NextDouble();

                if((x*x + y*y) <= 1) // Math to know when to run if statement
                {
                    count++;
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int Ask1;
            int Ask2;
            // Asks the user how many darts and threads
            Console.WriteLine("How many darts would you like a thread to throw?");
            Ask1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many threads would you like to have?");
            Ask2 = Convert.ToInt32(Console.ReadLine());

            List<Thread>List1 = new List<Thread>(Ask2);
            List<FindPiThread> List2 = new List<FindPiThread>(Ask2);

            for(int i = 0; i < Ask2; i++)
            {
                FindPiThread Add1 = new FindPiThread(Ask1);
                List2.Add(Add1);
                Thread Thread1 = new Thread(new ThreadStart(Add1.throwDarts));
                List1.Add(Thread1);
                List1[i].Start(); 
                Thread.Sleep(16); // Makes sure all threads get a value
            }

            foreach(Thread item in List1)
            {
                item.Join();
            }

            double total = 0;
            foreach(FindPiThread item in List2)
            {
                double Try1;
                double Try2;
                Try1 = item.count;
                Try2 = (Try1 / Ask1) * 4; // Math to find PI
                total = Try2;
            }

            Console.WriteLine("Approx Pi " + total); // Output for the approx of PI
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class FindPiThread
    {
        public int darts;
        public int count;
        public Random Throws;

        public FindPiThread(int t)
        {
            Throws = new Random();
            darts = t;
            count = 0;
        }

        public void throwDarts()
        {
            double x, y;
            for (int i = 0; i < darts; i++)
            {
                x = Throws.NextDouble();
                y = Throws.NextDouble();

                if(x*x + y*y <= 1)
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
                List1.Start(); ///////GUYHEFDHYGVHHJFDEBGVHJDEFBGJHBHJFDHJGHJDSFHJBGJHBFDHJB
                Thread.Sleep(16);
            }

        }
    }
}

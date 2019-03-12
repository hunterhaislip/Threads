using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class FindPiThread
    {
        public int darts;
        public int count;
        Random Throws = new Random();

        FindPiThread(int n)
        {
            n = Throws.Next(n);
            darts = 0;
            count = 0;
        }
    }
        


    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

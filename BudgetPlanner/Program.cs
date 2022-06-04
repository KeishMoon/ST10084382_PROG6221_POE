using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an object of the OrganiseInformation class
            OrganiseInformation oi = new OrganiseInformation();

            // Method call to execute the program
            oi.arrangeInformation();

            // Keep the console open
            Console.ReadLine();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // DisplauInformation extends the abstract Expense class
    public class DisplauInformation : Expense
    {
        // Method to display the user's inputted information
        public void displayInfo()
        {
            // Leave a ine
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Add Thread to load information to screen
            Console.WriteLine("Loading Data. . . ");

            // Countdown from 3
            for (int i = 3; i > 0; i--)
            {
                Console.Write(i + "\t");

                // Pause for 1 second between each number
                Thread.Sleep(1000);
            }

            // Leave a line
            Console.WriteLine();
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;

            // Housekeeping
            Console.WriteLine("***********************");
            Console.WriteLine("Information and totals:");
            Console.WriteLine("***********************");

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // Display the information
            Console.WriteLine("Your gross monthly income (before deductions) is R{0}", grossMonthlyIncome);

            Console.WriteLine("Your estimated monthly tax deducted is R{0}", mthlyTax);

            for (int i = 0; i < arrayListSize; i++)
            {
                Console.WriteLine("Your estimated monthly expenditure for {0} is R{1}", expensesType[i], expensesAmount[i]);
            }

            Console.WriteLine("Your estimated monthly housing payment is R{0}", mthlyHousingPayment);

            // Create an object of the UserInput class
            UserInformation ui = new UserInformation();

            // Method call
            moneyLeftOverPerMonth = ui.calculateAvailableMonthlyMoney();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            if (moneyLeftOverPerMonth > 0)
            {
                // If there is money available at the end of the month then display this following statement
                Console.WriteLine("The total amount of available monthly money after all the specified deductions have been made: R{0}", Math.Round(moneyLeftOverPerMonth, 2));
            }
            else
            {
                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;

                // If there is no money available at the end of the month then display this following statement
                Console.WriteLine("There is no money left over after all the specified deductions have been made! \nThe amount that you are over by is: R{0}", Math.Round(Math.Abs(moneyLeftOverPerMonth), 2));
            }

        }

    }
}

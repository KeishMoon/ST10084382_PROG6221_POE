using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // DisplayInformation extends the abstract Expense class
    public class DisplayInformation : Expense
    {
        // Globally declare the delegate that will notify the user when the total expenses exceed 75% of their income, including loan repayments
        public delegate void notifyUserDelegate();

        // Globally declare the delegate that will display the user's expenses in descending order
        public delegate void displayExpensesInDescendingOrderDelegate();

        // Method to display the user's inputted information
        public void displayInfo()
        {
            // Leave a ine
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Thread to load expenses to screen
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

            // Use a delegate to display the expenses to the user in descending order by value
            // Create an object of the delegate
            displayExpensesInDescendingOrderDelegate displayExpDescDel = new displayExpensesInDescendingOrderDelegate(displayExpensesInDescendingOrder);

            // Use the object to display the expenses to the user in descending order by value
            displayExpDescDel();

            // Pause for 2 seconds 
            Thread.Sleep(2000);

            // Leave a line
            Console.WriteLine();
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Thread to load all information to screen
            Console.WriteLine("Loading All Data. . . ");

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

            for (int i = 0; i < expensesListSize; i++)
            {
                Console.WriteLine("Your estimated monthly expenditure for {0} is R{1}", expensesType.ElementAt(i), expensesAmount.ElementAt(i));
            }

            Console.WriteLine("Your estimated monthly housing payment is R{0}", mthlyHousingPayment);

            // If the user chose to buy a vehicle, display the following
            if (carPurchaseChoice.Equals(true))
            {
                Console.WriteLine("Your estimated monthly vehicle payment for your {0} model {1} is R{2}", carMake, carModel, totalMthlyCarCost);
            }
            // If the user chose not to buy a vehicle, then display the following
            else
            {
                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkBlue;

                Console.WriteLine("You chose the option not to purchase a vehicle and therefore estimated monthly vehicle payment is R{0}", totalMthlyCarCost);
            }

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // Create an object of the UserInput class
            UserInformation ui = new UserInformation();

            // Method call
            netIncome = ui.calculateAvailableMonthlyMoney();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            // Display the amount of money left over at the end of the month
            if (netIncome > 0)
            {
                // If there is money available at the end of the month then display this following statement
                Console.WriteLine("The total amount of available monthly money after all the specified deductions have been made: R{0}", Math.Round(netIncome, 2));
            }
            else
            {
                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;

                // If there is no money available at the end of the month then display this following statement
                Console.WriteLine("There is no money left over after all the specified deductions have been made! \nThe amount that you are over by is: R{0}", Math.Round(Math.Abs(netIncome), 2));
            }

            // Leave a line
            Console.WriteLine();

            // The software shall notify the user when the total expenses exceed 75% of their income, including loan repayments using a delegate
            // Create an object of the delegate
            notifyUserDelegate nud = new notifyUserDelegate(notifyUser);

            // Use the object to  notify the user when the total expenses exceed 75% of their income, including loan repayments
            nud();

        }

        // Method to display the user's expenses in descending order
        public void displayExpensesInDescendingOrder()
        {
            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;

            // Housekeeping
            Console.WriteLine("*********************************************");
            Console.WriteLine("Expenses listed in descending order by value:");
            Console.WriteLine("*********************************************");

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Display the expenses in descending order 
            // First using the Sort() to display the expenses in ascending order  
            expensesDoubleAmount.Sort();
            // Then the Reverse() method to order them in descending order
            expensesDoubleAmount.Reverse();

            // Print out the expenses in descending order using a for loop
            for (int i = 0; i < expensesListSize; i++)
            {
                Console.WriteLine((i + 1) + ". " + expensesDoubleAmount.ElementAt(i));
            }

            // Display monthly housing payment
            Console.Write("Monthly housing payment:");

            Console.WriteLine(" R{0}", mthlyHousingPayment);

            // Display monthly vehicle payment
            // If the user chose to buy a vehicle, display the following
            if (carPurchaseChoice.Equals(true))
            {
                Console.Write("Monthly vehicle payment:");

                Console.WriteLine(" R{0}", totalMthlyCarCost);
            }
            // If the user chose not to buy a vehicle, then display the following
            else
            {
                Console.Write("You did not choose to purchase a vehicle, therefore estimated monthly vehicle payment is:");

                Console.WriteLine(" R{0}", totalMthlyCarCost);
            }

            // Leave a line
            Console.WriteLine();
        }

        // Method to notify the user when the total expenses exceed 75% of their NET income, including loan repayments
        public void notifyUser()
        {
            // Constant to store the 75%
            const double SEVENTY_FIVE_PERCENT = 0.75;

            // If the user's total expenses and their loan repayments are greater than 75% their net income, then display the warning messgae
            if (totalExpensePlusLoans > (netIncome * SEVENTY_FIVE_PERCENT))
            {
                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;

                // Warning Message
                Console.WriteLine("Warning!");

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;

                // Warning Message continued
                Console.WriteLine("Your total expenses exceed 75% of your net income, including loan repayments!");
            }
            // If the user's total expenses and their loan repayments are less than 75% their net income, then display the following
            else
            {
                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Note:" +
                    "\nYour total expenses are under 75% of your net income, including loan repayments!");
            }
        }

        // Method to override the abstract method
        public override void getUserInput()
        {

        }
    }
}

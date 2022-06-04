using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // OrganiseInformation extends the abstract Expense class
    class OrganiseInformation : Expense
    {
        // Method to put program in order
        public void arrangeInformation()
        {
            // Boolean that will determine if the progam is run multiple times
            bool userContChoice;

            // Do while loop to execute the program atleast once and if the user wants to run it again then it will do so
            do
            {
                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;

                // Housekeeping
                Console.WriteLine("**************");
                Console.WriteLine("BUDGET PLANNER");
                Console.WriteLine("**************");

                // Create an object of the UserInput class
                UserInformation ui = new UserInformation();

                // Method call
                ui.getUserInput();

                // Create an object of the DisplauInformation class
                DisplayInformation di = new DisplayInformation();

                // Method call
                di.displayInfo();

                // Leave a line
                Console.WriteLine();

                // Holds the screen for 2 seconds
                Thread.Sleep(2000);

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;

                // Housekeeping
                Console.WriteLine("**********************************");
                Console.WriteLine("Thank you for using Budget Planner");
                Console.WriteLine("**********************************");

                // Leave a line
                Console.WriteLine();

                // Assigns the users choice on whether or not the want to run the program again to the boolean userContChoice
                userContChoice = rerunApp();

                // If userContChoice, then the program executes again
            } while (userContChoice == true);


        }

        // Method to clear the program if the user wishes to run the program again
        public bool rerunApp()
        {
            // Boolean to store whether or not the program will rerun or not
            bool rerunChoice;

            // Pauses the screen for 1 second
            Thread.Sleep(1000);

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Ask the user if they would like to reuse the app
            Console.WriteLine("Would you like to use the Budget Planner app again?");
            Console.Write("Enter *1* for Yes or press any other key to exit: ");
            userRunAgin = Console.ReadLine();

            // If the user wants to reuse the app, then clear the previous users input and the console
            if (userRunAgin.Equals("1"))
            {
                // Change the background colour
                Console.BackgroundColor = ConsoleColor.Black;

                // Clear values and set to null
                grossMonthlyIncome = null;
                mthlyTax = null;
                expensesType.Clear();
                expensesAmount.Clear();
                expensesDoubleAmount.Clear();
                expensesListSize = 0;
                mthlyHousingPayment = 0;
                propertyPurchasePrice = null;
                totalDepositAmt = null;
                interestRatePercentage = null;
                numOfMonths = null;
                propertyPurchasePriceDouble = 0;
                totalDepositAmtDouble = 0;
                interestRatePercentageDouble = 0;
                numOfMonthsDouble = 0;
                totalExpenses = 0;
                netIncome = 0;
                carPurchaseChoice = false;
                carModel = null;
                carMake = null;
                carTotalDeposit = null;
                carPurchasePrice = null;
                carInterestRatePercentage = null;
                estimatedInsurancePremium = null;
                totalMthlyCarCost = 0;

                // Clear teh console window
                Console.Clear();

                // If the user wants to rerun the program, then assign the rerunChoice boolean the value of true
                rerunChoice = true;

            }
            else
            {
                // If the user does not want to rerun the program, then assign the rerunChoice boolean the value of flase
                rerunChoice = false;

                // Leave a line
                Console.WriteLine();

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                
                // Housekeeping to end the program
                Console.WriteLine("**************");
                Console.WriteLine("End of Program");
                Console.WriteLine("**************");
            }

            // return the boolean value of true or false, based on the user's choice
            return rerunChoice;

        }

        // Method to override the abstract method 
        public override void getUserInput()
        {

        }
    }
}

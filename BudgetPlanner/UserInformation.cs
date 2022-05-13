using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // UserInformation extends the abstract Expense class
    public class UserInformation : Expense
    {
        // Method to get user's input
        public void getUserInput()
        {
            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // Get the user's gross mothly income before deductions
            Console.Write("Enter your gross monthly income (before deductions): R");
            grossMonthlyIncome = Console.ReadLine();

            // Get the user's estimated monthly tax deducted
            Console.Write("Enter your estimated monthly tax deducted: R");
            mthlyTax = Console.ReadLine();

            // Populate the expensesType ArrayList with the given expenditure categories
            expensesType.Add("groceries");
            expensesType.Add("water and lights");
            expensesType.Add("travel costs (including petrol)");
            expensesType.Add("cell phone and telephone");

            // Get the user's estimated monthly expenditure for each expense category
            Console.Write("Enter your estimated monthly expenditure for {0}: R", expensesType[0]);
            expensesAmount.Add(Console.ReadLine());

            Console.Write("Enter your estimated monthly expenditure for {0}: R", expensesType[1]);
            expensesAmount.Add(Console.ReadLine());

            Console.Write("Enter your estimated monthly expenditure for {0}: R", expensesType[2]);
            expensesAmount.Add(Console.ReadLine());

            Console.Write("Enter your estimated monthly expenditure for {0}: R", expensesType[3]);
            expensesAmount.Add(Console.ReadLine());

            // Leave a line
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // Other expenses:
            // Get the user's estimated monthly expenditure for each expense category to help handle the arraysize
            Console.Write("Do you have any other expenses? Enter *1* for YES or any other key for NO: ");
            string userChoice = (Console.ReadLine());

            // Leave a line
            Console.WriteLine();

            // If the user has other expenses, do the following
            if (userChoice.Equals("1"))
            {
                // Determine how many other expenses the user has 
                Console.Write("Enter how many other expenses you have: ");
                string userNumberOfExpenses = Console.ReadLine();

                // Check that the user entered a valid number for the number other expenses they have
                // variables
                int checkOtherExpenses = 0;

                // Check that the user's input is valid 
                bool canConvertOtherExpenses = Int32.TryParse(userNumberOfExpenses, out checkOtherExpenses);

                // If the user did not enter a valid number, then reprompt them for a valid number.
                while (canConvertOtherExpenses == false || (double.Parse(userNumberOfExpenses) < 0))
                {
                    // Leave a line
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;

                    // Error Message
                    Console.WriteLine("Error!");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number!", userNumberOfExpenses);

                    // Leave a line
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    // Reprompt the user for a valid number
                    Console.Write("Enter how many other expenses you have: ");
                    userNumberOfExpenses = Console.ReadLine();

                    // Check that the user's new input is valid 
                    canConvertOtherExpenses = Int32.TryParse(userNumberOfExpenses, out checkOtherExpenses);
                }

                // Calculate the size of what the arrayList will be with the other expenses
                arrayListSize = Int32.Parse(userNumberOfExpenses) + expensesAmount.Count;

                // Add the other expenses names and amounts to each array list
                for (int i = 4; i < arrayListSize; i++)
                {
                    // Leave a line
                    Console.WriteLine();

                    // Change the text and background colours
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    Console.Write("Enter the name of your other expense: ");
                    expensesType.Add(Console.ReadLine());

                    Console.Write("Enter your estimated monthly expenditure for {0}: R", expensesType[i]);
                    expensesAmount.Add(Console.ReadLine());

                }

                // Leave a line
                Console.WriteLine();

            }
            // If the user does not have other expenses, do the following
            else
            {
                // set the array list size to the array list capacity
                arrayListSize = expensesAmount.Count;

            }

            // Leave a line
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Validating Inputted Data. . . ");

            // Leave a line
            Console.WriteLine();

            // Countdown from 5
            for (int i = 5; i > 0; i--)
            {
                Console.Write(i + "\t");

                // Pause for 1 second between each number
                Thread.Sleep(1000);
            }

            // Method call to check for any errors
            expensesExceptionHandling();

            // Leave a line
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            // User should choose between renting accommodation or buying a property:
            Console.Write("Enter *1* if you are renting accommodation or *2* for buying a property: ");
            string accommType = Console.ReadLine();

            // If the user does not enter a 1 or a 2, then prompt the user to enter a valid option
            while (!accommType.Equals("1") && !accommType.Equals("2"))
            {
                // Leave a line
                Console.WriteLine();

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Error! Invalid option.");

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write("Enter *1* if you are renting accommodation or *2* for buying a property: ");
                accommType = Console.ReadLine();
            }

            // If the user selects to rent, the user shall be able to enter the monthly rental amount:
            if (accommType.Equals("1"))
            {
                Rental r = new Rental();
                mthlyHousingPayment = r.rentingAccommodation();
            }
            else
            // If the user selects to buy a property, the user shall be required to enter the following values for a home loan:
            if (accommType.Equals("2"))
            {
                HomeLoan hl = new HomeLoan();
                mthlyHousingPayment = hl.calcHomeLoanMthlyRepayment();
            }

            // Leave a line
            Console.WriteLine();

        }

        // Method to check that all data inputted by the user is valid
        public void expensesExceptionHandling()
        {
            // Leave a line
            Console.WriteLine();

            // Variables
            double checkMthlyIncome;
            double checkMthlyTax;
            double checkExpenses;

            // Check that the user entered a valid number for their gross monthly income (before deductions)
            // Check that the user's input is valid 
            bool canConvertMthlyIncome = double.TryParse(grossMonthlyIncome, out checkMthlyIncome);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertMthlyIncome == false || (double.Parse(grossMonthlyIncome) < 0))
            {
                // Leave a line
                Console.WriteLine();

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;

                // Error Message
                Console.WriteLine("Error!");

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;

                // If the decimal point was a "." then indicate to the user that this is not valid and it must be a "," instead
                if (grossMonthlyIncome.Contains('.'))
                {
                    Console.WriteLine("Please use \',\' instead of \'.\'!", grossMonthlyIncome);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number!", grossMonthlyIncome);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter your gross monthly income (before deductions): R");
                grossMonthlyIncome = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertMthlyIncome = double.TryParse(grossMonthlyIncome, out checkMthlyIncome);
            }

            // Check that the user entered a valid number for their estimated monthly tax deducted
            // Check that the user's input is valid 
            bool canConvertMthlyTax = double.TryParse(mthlyTax, out checkMthlyTax);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertMthlyTax == false || (double.Parse(mthlyTax) < 0))
            {
                // Leave a line
                Console.WriteLine();

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;

                // Error Message
                Console.WriteLine("Error!");

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkRed;

                // If the decimal point was a "." then indicate to the user that this is not valid and it must be a "," instead
                if (mthlyTax.Contains('.'))
                {
                    Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", mthlyTax);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number", mthlyTax);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter your estimated monthly tax deducted: R");
                mthlyTax = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertMthlyTax = double.TryParse(mthlyTax, out checkMthlyTax);
            }

            // Check that the user entered a valid number for each expense category
            for (int i = 0; i < arrayListSize; i++)
            {
                // Check that the user's input is valid 
                bool canConvertExpenses = double.TryParse(expensesAmount[i].ToString(), out checkExpenses);

                // If the user did not enter a valid number, then reprompt them for a valid number.
                while (canConvertExpenses == false || (double.Parse(expensesAmount[i].ToString()) < 0))
                {
                    // Leave a line
                    Console.WriteLine();

                    // Change the text and background colours
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;

                    // Error Message
                    Console.WriteLine("Error!");

                    // Change the text and background colours
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    // If the decimal point was a "." then indicate to the user that this is not valid and it must be a "," instead
                    if (expensesAmount[i].ToString().Contains('.'))
                    {
                        Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", expensesAmount[i]);
                    }
                    else
                    {
                        // Statement that displays the user's input indicating that there is an error
                        Console.WriteLine("\"{0}\" is not a valid number!", expensesAmount[i]);
                    }

                    // Change the text and background colours
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    // Reprompt the user for a valid number
                    Console.Write("Enter your estimated monthly expenditure for {0}: R", expensesType[i]);
                    // Removes the user's invalid input for that expense 
                    expensesAmount.Remove(i);
                    expensesAmount[i] = Console.ReadLine();

                    // Check that the user's new input is valid 
                    canConvertExpenses = double.TryParse(expensesAmount[i].ToString(), out checkExpenses);
                }

            }

            // Leave a line
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;

            // Holds the screen for 1 second
            Thread.Sleep(1000);

            // Display message that the numbers inputted are all valid
            Console.WriteLine("The inputted data is valid!");
        }

        // Method to calculate the user's the available monthly money after all the specified deductions have been made
        public double calculateAvailableMonthlyMoney()
        {
            // Add up the various expense amounts
            for (int i = 0; i < arrayListSize; i++)
            {
                totalExpenses += Double.Parse(expensesAmount[i].ToString());

            }

            // calculation to determine how much of money is left over after all the deductions have been made
            moneyLeftOverPerMonth = Double.Parse(grossMonthlyIncome) - Double.Parse(mthlyTax) - totalExpenses - mthlyHousingPayment;

            return moneyLeftOverPerMonth;
        }

    }
}

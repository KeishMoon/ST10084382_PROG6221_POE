using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // HomeLoan extends the abstract Expense class
    public class HomeLoan : Expense
    {
        // Method to get information about the user's home loan
        public void getHomeLoanInfo()
        {
            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.Write("Enter the purchase price of your property: R");
            propertyPurchasePrice = Console.ReadLine();

            Console.Write("Enter the total deposit amount for your property: R");
            totalDepositAmt = Console.ReadLine();

            Console.Write("Enter the interest rate (percentage) for your property: ");
            interestRatePercentage = Console.ReadLine();

            Console.Write("Enter the number of months (between 240 and 360) to repay your property: ");
            numOfMonths = Console.ReadLine();

            // Leave a line
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Thread
            Console.WriteLine("Validating Home Loan Data. . . ");

            // Countdown from 5
            for (int i = 5; i > 0; i--)
            {
                Console.Write(i + "\t");

                // Pause for 1 second between each number
                Thread.Sleep(1000);
            }

            // Leave a line
            Console.WriteLine();

            // Method call to check for any errors
            homeLoanExceptionHandling();

        }

        // Method to check that all data inputted by the user is valid
        public void homeLoanExceptionHandling()
        {
            // Leave a line
            Console.WriteLine();

            // Variables
            double checkPropertyPurchasePrice = 0;
            double checkTotalDepositAmt = 0;
            double checkInterestRatePercentage = 0;
            double checkNumOfMonths = 0;

            // Check that the user entered a valid number for purchase price of your property
            // Check that the user's input is valid 
            bool canConvertPropertyPurchasePrice = double.TryParse(propertyPurchasePrice, out checkPropertyPurchasePrice);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertPropertyPurchasePrice == false || (double.Parse(propertyPurchasePrice) < 0))
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

                // Statement that displays the user's input indicating that there is an error
                Console.WriteLine("\"{0}\" is not a valid number!", propertyPurchasePrice);

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter the purchase price of your property: R");
                propertyPurchasePrice = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertPropertyPurchasePrice = double.TryParse(propertyPurchasePrice, out checkPropertyPurchasePrice);
            }

            // If the user's input is a valid number, then convert it to a double
            if (canConvertPropertyPurchasePrice == true)
            {
                propertyPurchasePriceDouble = Double.Parse(propertyPurchasePrice);
            }

            // Check that the user entered a valid number for their total deposit amount for their property
            // Check that the user's input is valid 
            bool canConvertTotalDepositAmt = double.TryParse(totalDepositAmt, out checkTotalDepositAmt);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertTotalDepositAmt == false || (double.Parse(totalDepositAmt) < 0))
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
                if (totalDepositAmt.Contains('.'))
                {
                    Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", totalDepositAmt);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number!", totalDepositAmt);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter the total deposit amount for your property: R");
                totalDepositAmt = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertTotalDepositAmt = double.TryParse(totalDepositAmt, out checkTotalDepositAmt);
            }

            // If the user's input is a valid number, then convert it to a double
            if (canConvertTotalDepositAmt == true)
            {
                totalDepositAmtDouble = Double.Parse(totalDepositAmt);
            }

            // Check that the user entered a valid interest rate (percentage) 
            // Check that the user's input is valid 
            bool canConvertInterestRatePercentage = double.TryParse(interestRatePercentage, out checkInterestRatePercentage);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertInterestRatePercentage == false || (double.Parse(interestRatePercentage) < 0))
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
                if (interestRatePercentage.Contains('.'))
                {
                    Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", interestRatePercentage);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number!", interestRatePercentage);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter the interest rate (percentage) for your property: ");
                interestRatePercentage = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertInterestRatePercentage = double.TryParse(interestRatePercentage, out checkInterestRatePercentage);
            }

            // If the user's input is a valid number, then convert it to a double
            if (canConvertInterestRatePercentage == true)
            {
                interestRatePercentageDouble = Double.Parse(interestRatePercentage);
            }

            // Check that the user entered a valid number for their property purchase price
            // Check that the user's input is valid 
            bool canConvertNumOfMonths = double.TryParse(numOfMonths, out checkNumOfMonths);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertNumOfMonths == false || (double.Parse(numOfMonths) < 0))
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

                // Statement that displays the user's input indicating that there is an error
                Console.WriteLine("\"{0}\" is not a valid number!", numOfMonths);

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter the number of months (between 240 and 360) to repay your property: ");
                numOfMonths = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertNumOfMonths = double.TryParse(numOfMonths, out checkNumOfMonths);
            }

            // If the user's input is a valid number and between 240 and 360, then convert it to a double
            if (canConvertNumOfMonths == true)
            {
                // Leave a line
                Console.WriteLine();

                // Check that the number of months to repay the loan is between 240 and 360
                while ((double.Parse(numOfMonths) < 240) || (double.Parse(numOfMonths) > 360))
                {
                    // Change the text and background colours
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;

                    // Error Message
                    Console.WriteLine("Error!");

                    // Change the text and background colours
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not within the 240-360 range!", numOfMonths);

                    // Change the text and background colours
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    // Reprompt the user for a valid number
                    Console.Write("Enter the number of months (between 240 and 360) to repay your property: ");
                    numOfMonths = Console.ReadLine();

                    // Check that the user's new input is valid 
                    canConvertNumOfMonths = double.TryParse(numOfMonths, out checkNumOfMonths);

                    // If the user did not enter a valid number, then reprompt them for a valid number.
                    while (canConvertNumOfMonths == false || (double.Parse(numOfMonths) < 0))
                    {
                        // Change the text and background colours
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;

                        // Error Message
                        Console.WriteLine("Error!");

                        // Change the text and background colours
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        // Statement that displays the user's input indicating that there is an error
                        Console.WriteLine("\"{0}\" is not a valid number!", numOfMonths);

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        // Reprompt the user for a valid number
                        Console.Write("Enter the number of months (between 240 and 360) to repay your property: ");
                        numOfMonths = Console.ReadLine();

                        // Check that the user's new input is valid 
                        canConvertNumOfMonths = double.TryParse(numOfMonths, out checkNumOfMonths);
                    }
                }

                // If the user's input is a valid number, then convert it to a double
                numOfMonthsDouble = Double.Parse(numOfMonths);

            }

            // Leave a line
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;

            // Thread that holds the screen for 1 second
            Thread.Sleep(1000);

            // Display message that the numbers inputted are all valid
            Console.WriteLine("The inputted home loan data is valid!");

        }

        // The software shall calculate the monthly home loan repayment for buying a property based on the values that the user entered
        // Method to calculate the home loan amount
        public double calcHomeLoanMthlyRepayment()
        {
            // variables
            double totalLoanAmt;

            // method call
            getHomeLoanInfo();

            // calculate the property Purchase Price without the deposit
            double propertyPriceMinusDeposit = propertyPurchasePriceDouble - totalDepositAmtDouble;

            // calculate how long the loan will take to repay in years
            double loanYearsRepayment = numOfMonthsDouble / 12;

            // formula: 𝐴=𝑃(1 +𝑖𝑛)
            totalLoanAmt = propertyPriceMinusDeposit * (1 + ((interestRatePercentageDouble / 100) * loanYearsRepayment));

            double mthlyHomeLoanRepayment = Math.Round((totalLoanAmt / numOfMonthsDouble), 2);

            // Leave a line
            Console.WriteLine();

            // If the monthly home loan repayment is more than a third of the user’s gross monthly income, a message is displayed indicating that the approval of the home loan is unlikely
            if (mthlyHomeLoanRepayment > (Double.Parse(grossMonthlyIncome) / 3))
            {
                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;

                // Warning Message
                Console.WriteLine("Warning!");

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine("Please note that the approval of your home loan is unlikely as the monthly repayments are more than a third of your gross monthly income!");
            }

            // Assign mthlyHousingPayment the value of mthlyHomeLoanRepayment and return mthlyHousingPayment
            mthlyHousingPayment = mthlyHomeLoanRepayment;

            return mthlyHousingPayment;
        }
    }
}

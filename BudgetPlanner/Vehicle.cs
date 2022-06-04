using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // Vehicle extends the abstract Expense class
    public class Vehicle : Expense
    {
        // Method to override the abstract method and get information from the user for vehicle financing
        public override void getUserInput()
        {
            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // Get the car make from the user
            Console.Write("Enter the make of your car: ");
            carMake = Console.ReadLine();

            // Get the car model from the user
            Console.Write("Enter the model of your car: ");
            carModel = Console.ReadLine();

            // Get the car purchase price from the user
            Console.Write("Enter the purchase price of your car: R");
            carPurchasePrice = Console.ReadLine();

            // Get the car total deposit from the user
            Console.Write("Enter the total deposit of your car: R");
            carTotalDeposit = Console.ReadLine();

            // Get the car loan interest rate percentage from the user
            Console.Write("Enter the interest rate (percentage) of your car: ");
            carInterestRatePercentage = Console.ReadLine();

            // Get the car loan estimated insurance premium from the user
            Console.Write("Enter the estimated insurance premium of your car: R");
            estimatedInsurancePremium = Console.ReadLine();

            // Leave a line
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Thread
            Console.WriteLine("Validating Vehicle Loan Data. . . ");

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
            vehicleExceptionHandling();

            // Leave a line
            Console.WriteLine();

            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;

            // Thread that holds the screen for 1 second
            Thread.Sleep(1000);

            // Display message that the numbers inputted are all valid
            Console.WriteLine("The inputted vehicle loan data is valid!");

        }

        // Method to check that all vehicle data inputted by the user is valid
        public void vehicleExceptionHandling()
        {
            // Leave a line
            Console.WriteLine();

            // Check that the user entered a valid number for their car purchase price 
            // Variables
            double checkCarPurchasePrice = 0;

            // Check that the user's input is valid 
            bool canConvertCarPurchasePrice = double.TryParse(carPurchasePrice, out checkCarPurchasePrice);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertCarPurchasePrice == false || (double.Parse(carPurchasePrice) < 0))
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
                if (carPurchasePrice.Contains("."))
                {
                    Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", carPurchasePrice);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number", carPurchasePrice);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter the purchase price of your car: R");
                carPurchasePrice = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertCarPurchasePrice = double.TryParse(carPurchasePrice, out checkCarPurchasePrice);

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Check that the user entered a valid number for their car total deposit
            // Variables
            double checkCarTotalDeposit = 0;

            // Check that the user's input is valid 
            bool canConvertCarTotalDeposit = double.TryParse(carTotalDeposit, out checkCarTotalDeposit);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertCarTotalDeposit == false || (double.Parse(carTotalDeposit) < 0))
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
                if (carTotalDeposit.Contains("."))
                {
                    Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", carTotalDeposit);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number", carTotalDeposit);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter the total deposit of your car: R");
                carTotalDeposit = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertCarTotalDeposit = double.TryParse(carTotalDeposit, out checkCarTotalDeposit);

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Check that the user entered a valid number for their car interest rate (percentage)
            // Variables
            double checkCarInterestRatePercentage = 0;

            // Check that the user's input is valid 
            bool canConvertCarInterestRatePercentage = double.TryParse(carInterestRatePercentage, out checkCarInterestRatePercentage);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertCarInterestRatePercentage == false || (double.Parse(carInterestRatePercentage) < 0))
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
                if (carInterestRatePercentage.Contains("."))
                {
                    Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", carInterestRatePercentage);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number", carInterestRatePercentage);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter the interest rate (percentage) of your car: ");
                carInterestRatePercentage = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertCarInterestRatePercentage = double.TryParse(carInterestRatePercentage, out checkCarInterestRatePercentage);
            }

            // Check that the user entered a valid number for their Estimated Insurance Premium
            // Variables
            double checkEstimatedInsurancePremium = 0;

            // Check that the user's input is valid 
            bool canConvertEstimatedInsurancePremium = double.TryParse(estimatedInsurancePremium, out checkEstimatedInsurancePremium);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertEstimatedInsurancePremium == false || (double.Parse(estimatedInsurancePremium) < 0))
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
                if (estimatedInsurancePremium.Contains("."))
                {
                    Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", estimatedInsurancePremium);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number", estimatedInsurancePremium);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter the estimated insurance premium of your car: R");
                estimatedInsurancePremium = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertEstimatedInsurancePremium = double.TryParse(estimatedInsurancePremium, out checkEstimatedInsurancePremium);
            }
        }

        // Method to calculate the total monthly cost for buying a car
        public double calcTotalyMonthlyCostForBuyingACar()
        {
            // variables
            double totalCarAmt;

            // constant
            const double REPAYMENT_YEARS = 5;
            const double REPAYMENT_MONTHS = 60;

            // method call
            getUserInput();

            // calculate the car Purchase Price without the deposit
            double carPriceMinusDeposit = Double.Parse(carPurchasePrice) - Double.Parse(carTotalDeposit);

            // formula: 𝐴=𝑃(1 +𝑖𝑛) 
            totalCarAmt = (carPriceMinusDeposit * (1 + ((Double.Parse(carInterestRatePercentage) / 100) * REPAYMENT_YEARS)));

            // the total monthly car cost is equal to the total car amount / 60 and then adds the insurance
            totalMthlyCarCost = Math.Round(((totalCarAmt / REPAYMENT_MONTHS) + Double.Parse(estimatedInsurancePremium)), 2);

            // Leave a line
            Console.WriteLine();

            return totalMthlyCarCost;
        }

    }
}

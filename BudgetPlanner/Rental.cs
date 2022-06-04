using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // Rental extends the abstract Expense class
    public class Rental : Expense
    {
        // Method to get the user's monthly rental amount
        public double rentingAccommodation()
        {
            // Change the text and background colours
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;

            // Get user's monthly rent amount
            Console.Write("Enter your monthly rental amount: R");
            string mthlyRentalAmt = Console.ReadLine();

            // Check that the user entered a valid number for their monthly rental amount
            // Variables
            double checkNumberRentalAmt = 0;

            // Check that the user's input is valid 
            bool canConvertRentalAmt = double.TryParse(mthlyRentalAmt, out checkNumberRentalAmt);

            // If the user did not enter a valid number, then reprompt them for a valid number.
            while (canConvertRentalAmt == false || (double.Parse(mthlyRentalAmt) < 0))
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
                if (mthlyRentalAmt.Contains('.'))
                {
                    Console.WriteLine("Please use \',\' in R{0} instead of \'.\'!", mthlyRentalAmt);
                }
                else
                {
                    // Statement that displays the user's input indicating that there is an error
                    Console.WriteLine("\"{0}\" is not a valid number", mthlyRentalAmt);
                }

                // Change the text and background colours
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;

                // Reprompt the user for a valid number
                Console.Write("Enter your monthly rental amount: R");
                mthlyRentalAmt = Console.ReadLine();

                // Check that the user's new input is valid 
                canConvertRentalAmt = double.TryParse(mthlyRentalAmt, out checkNumberRentalAmt);
            }

            // Assign the mthlyHousingPayment the mthlyRentalAmt value if its a valid double
            if (canConvertRentalAmt == true)
            {
                mthlyHousingPayment = Math.Round((Double.Parse(mthlyRentalAmt)), 2);
            }

            return mthlyHousingPayment;
        }

        // Method to override the abstract method
        public override void getUserInput()
        {

        }
    }
}

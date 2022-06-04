using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // Abstract class Expense
    public abstract class Expense
    {
        // Getters and Setters related to the user's incomes and expenses
        public static string grossMonthlyIncome { get; set; }
        public static string mthlyTax { get; set; }

        // Using a generic collection to store the expenses
        // List <T> to store the expenses categories
        public static List<string> expensesType = new List<string>();

        // List <T>  to store the expenses amounts
        public static List<string> expensesAmount = new List<string>();

        // List <T>  to store the final expenses amounts
        public static List<double> expensesDoubleAmount = new List<double>();

        // Stores the number of expenses that the user has
        public static int expensesListSize { get; set; }

        // Getters and Setters related to the user's living arangement 
        public static double mthlyHousingPayment { get; set; }
        public static string propertyPurchasePrice { get; set; }
        public static string totalDepositAmt { get; set; }
        public static string interestRatePercentage { get; set; }
        public static string numOfMonths { get; set; }
        public static double propertyPurchasePriceDouble { get; set; }
        public static double totalDepositAmtDouble { get; set; }
        public static double interestRatePercentageDouble { get; set; }
        public static double numOfMonthsDouble { get; set; }

        // Getters and Setters to save the available money per month once the deductions have been made
        public static double totalExpenses { get; set; }
        public static double totalExpensePlusLoans { get; set; }
        public static double netIncome { get; set; }

        // Getters and Setters to determine if the user would like to rerun the application
        public static string userRunAgin { get; set; }

        // Getters and Setters related to the user's vehicle choice
        public static bool carPurchaseChoice = false;
        public static string carModel { get; set; }
        public static string carMake { get; set; }
        public static string carTotalDeposit { get; set; }
        public static string carPurchasePrice { get; set; }
        public static string carInterestRatePercentage { get; set; }
        public static string estimatedInsurancePremium { get; set; }
        public static double totalMthlyCarCost { get; set; }

        // Abstract Method
        public abstract void getUserInput();
    }
}

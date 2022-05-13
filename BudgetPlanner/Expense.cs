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

        // Arraylist to store the expenses categories
        public static ArrayList expensesType = new ArrayList();

        // Arraylist to store the expenses amounts
        public static ArrayList expensesAmount = new ArrayList();

        public static int arrayListSize { get; set; }

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

        // Getter and Setter to save the available money per month once the deductions have been made
        public double totalExpenses { get; set; }
        public double moneyLeftOverPerMonth { get; set; }

        // Getters and Setters to determine if the user would like to rerun the application
        public static string userRunAgin { get; set; }

    }
}

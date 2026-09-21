using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace personal_budget_system
{
    public class Budget
    {
        public decimal Income { get; set; }

        public decimal Rent { get; set; }

        public decimal Food { get; set; }

        public decimal Travel { get; set; }

        public decimal Shopping { get; set; }

        public decimal TotalExpenses()
        {
            return Rent + Food + Travel + Shopping;
        }

        public decimal RemainingBudget()
        {
            return Income - TotalExpenses();
        }

        public decimal ExpensePercentage()
        {
            if (Income == 0)
                return 0;

            return (TotalExpenses() / Income) * 100;
        }

        public string GetBudgetStatus()
        {
            if (Income == 0)
                return "No income entered.";

            if (TotalExpenses() > Income)
                return "Over Budget";

            if (ExpensePercentage() >= 80)
                return "High Spending";

            return "Budget is under control";
        }
    }
}
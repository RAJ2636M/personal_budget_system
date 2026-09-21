using System;
using System.Web.UI;

namespace personal_budget_system
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal income;
            decimal rent;
            decimal food;
            decimal travel;
            decimal shopping;

            if (!decimal.TryParse(txtIncome.Text, out income) ||
                !decimal.TryParse(txtRent.Text, out rent) ||
                !decimal.TryParse(txtFood.Text, out food) ||
                !decimal.TryParse(txtTravel.Text, out travel) ||
                !decimal.TryParse(txtShopping.Text, out shopping))
            {
                lblMessage.Text = "Please enter valid numbers in all fields.";
                return;
            }

            if (income <= 0)
            {
                lblMessage.Text = "Income must be greater than zero.";
                return;
            }

            if (rent < 0 || food < 0 ||
                travel < 0 || shopping < 0)
            {
                lblMessage.Text = "Expense values cannot be negative.";
                return;
            }

            Budget budget = new Budget();

            budget.Income = income;
            budget.Rent = rent;
            budget.Food = food;
            budget.Travel = travel;
            budget.Shopping = shopping;

            decimal totalExpenses = budget.TotalExpenses();
            decimal remaining = budget.RemainingBudget();
            decimal expensePercentage = budget.ExpensePercentage();

            lblExpenses.Text = totalExpenses.ToString("0.00");
            lblRemaining.Text = remaining.ToString("0.00");
            lblPercentage.Text = expensePercentage.ToString("0.00") + "%";
            lblStatus.Text = budget.GetBudgetStatus();

            lblMessage.Text = "";
        }
    }
}
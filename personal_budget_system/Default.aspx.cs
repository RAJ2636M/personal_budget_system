using System;
using System.Web.UI;

namespace personal_budget_system
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnCalculate_Click(object sender, EventArgs e)
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

            string budgetSituation;

            if (remaining < 0)
            {
                budgetSituation = "The user is OVER BUDGET because expenses are greater than income.";
            }
            else
            {
                budgetSituation = "The user is WITHIN BUDGET because some money remains after expenses.";
            }

            string prompt =
                "You are a personal budgeting assistant. " +
                "Analyse the monthly budget and give a short, practical recommendation. " +
                "Use the calculated values provided below as facts. " +
                "Do not contradict the remaining budget or expense percentage. " +
                "If Remaining Budget is greater than zero, clearly state that the user is within budget. " +
                "If Remaining Budget is negative, clearly state that the user is over budget. " +
                "Mention one or two areas where the user can improve spending or saving. " +
                "Use Indian Rupees (₹). " +
                "Keep the answer within 3 to 5 sentences.\n\n" +

                "Budget Situation: " + budgetSituation + "\n" +
                "Monthly Income: ₹" + income + "\n" +
                "Rent: ₹" + rent + "\n" +
                "Food: ₹" + food + "\n" +
                "Travel: ₹" + travel + "\n" +
                "Shopping: ₹" + shopping + "\n" +
                "Total Expenses: ₹" + totalExpenses + "\n" +
                "Remaining Budget: ₹" + remaining + "\n" +
                "Expense Percentage: " + expensePercentage.ToString("0.00") + "%";

            lblAIAdvice.Text = "Generating AI recommendation...";

            OllamaService ollama = new OllamaService();

            string advice = await ollama.GetBudgetAdvice(prompt);

            lblAIAdvice.Text = advice;

            lblMessage.Text = "";
        }
    }
}
<%@ Page Title="Personal Budget System" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="personal_budget_system._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .budget-container {
            max-width: 1100px;
            margin: 30px auto;
        }

        .budget-header {
            background: #f5f7fa;
            padding: 30px;
            border-radius: 12px;
            margin-bottom: 25px;
        }

        .budget-header h1 {
            margin-bottom: 10px;
        }

        .input-section,
        .summary-section {
            background: white;
            padding: 25px;
            border: 1px solid #ddd;
            border-radius: 12px;
            margin-bottom: 20px;
        }

        .summary-box {
            padding: 18px;
            background: #f5f7fa;
            border-radius: 10px;
            margin-bottom: 15px;
        }

        .summary-box h4 {
            margin-bottom: 8px;
        }

        .summary-value {
            font-size: 22px;
            font-weight: bold;
        }

        .status-box {
            padding: 18px;
            background: #f5f7fa;
            border-radius: 10px;
        }

        .calculate-btn {
            margin-top: 10px;
        }
    </style>

    <div class="budget-container">

        <!-- Header -->
        <div class="budget-header">
            <h1>Personal Budget System</h1>

            <p class="lead">
                Manage your monthly income and expenses easily.
            </p>

            <p>
                Enter your income and expenses to calculate your remaining
                budget and analyse your spending.
            </p>
        </div>

        <div class="row">

            <!-- Input Section -->
            <div class="col-md-6">

                <div class="input-section">

                    <h2>Monthly Budget</h2>

                    <hr />

                    <label>Monthly Income</label>

                    <asp:TextBox ID="txtIncome"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter monthly income">
                    </asp:TextBox>

                    <br />

                    <h3>Monthly Expenses</h3>

                    <label>Rent</label>

                    <asp:TextBox ID="txtRent"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter rent">
                    </asp:TextBox>

                    <br />

                    <label>Food</label>

                    <asp:TextBox ID="txtFood"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter food expenses">
                    </asp:TextBox>

                    <br />

                    <label>Travel</label>

                    <asp:TextBox ID="txtTravel"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter travel expenses">
                    </asp:TextBox>

                    <br />

                    <label>Shopping</label>

                    <asp:TextBox ID="txtShopping"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter shopping expenses">
                    </asp:TextBox>

                    <br />

                    <asp:Button ID="btnCalculate"
                        runat="server"
                        Text="Calculate Budget"
                        CssClass="btn btn-primary calculate-btn"
                        OnClick="btnCalculate_Click" />

                    <br /><br />

                    <asp:Label ID="lblMessage"
                        runat="server"
                        CssClass="text-danger">
                    </asp:Label>

                </div>

            </div>


            <!-- Summary Section -->
            <div class="col-md-6">

                <div class="summary-section">

                    <h2>Budget Summary</h2>

                    <hr />

                    <div class="summary-box">

                        <h4>Total Expenses</h4>

                        <div class="summary-value">
                            ₹<asp:Label ID="lblExpenses"
                                runat="server"
                                Text="0.00">
                            </asp:Label>
                        </div>

                    </div>


                    <div class="summary-box">

                        <h4>Remaining Budget</h4>

                        <div class="summary-value">
                            ₹<asp:Label ID="lblRemaining"
                                runat="server"
                                Text="0.00">
                            </asp:Label>
                        </div>

                    </div>


                    <div class="summary-box">

                        <h4>Expense Percentage</h4>

                        <div class="summary-value">
                            <asp:Label ID="lblPercentage"
                                runat="server"
                                Text="0.00%">
                            </asp:Label>
                        </div>

                    </div>


                    <div class="status-box">

                        <h4>Budget Status</h4>

                        <asp:Label ID="lblStatus"
                            runat="server"
                            Text="No calculation yet.">
                        </asp:Label>

                    </div>
                    <div class="status-box">

                        <h4>AI Budget Recommendation</h4>

                        <asp:Label ID="lblAIAdvice"
                            runat="server"
                            Text="Calculate your budget to get an AI recommendation.">
                        </asp:Label>

                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Deposit.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row vertical-margin">
        <div class="col-md-10 col-md-offset-1">
            <h1>Deposit Fund</h1>
        </div>
    </div>
    <br />
    <div class="row vertical-margin form-group">
        <div class="col-md-4 col-md-offset-1">
            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name: "></asp:Label>
        </div>
        <div class="col-md-2">
            <asp:DropDownList ID="drpCustomer" runat="server" CssClass="focus-control" OnSelectedIndexChanged="drpCustomer_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Select Customer ..." Value="0"></asp:ListItem>
                <%-- ??? Value="0" --%>
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="drpCustomer" InitialValue="0" runat="server" ErrorMessage="Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />
    <div class="row vertical-margin form-group">
        <div class="col-md-4 col-md-offset-1">
            <asp:label ID="lblCheckingBalance" runat="server" text="Checking Account Balance: "></asp:label>
        </div>
        <div class="col-md-4">
            <asp:label ID="lblCheckingAccountBalance" runat="server"></asp:label>
        </div>
        <br />
        <div class="col-md-4 col-md-offset-1">
            <asp:label ID="lblSavingBalance" runat="server" text="Saving Account Balance: "></asp:label>
        </div>
        <div class="col-md-4">
            <asp:label ID="lblSavingAccountBalance" runat="server"></asp:label>
        </div>
        <br />
        <br />
        <br />
        <div class="col-md-4 col-md-offset-1">
            <asp:radiobuttonlist runat="server" ID="rdbAccountType">
                <asp:ListItem Text="To Checking Account" Value="checking" Selected="True"></asp:ListItem>
                <asp:ListItem Text="To Saving Account" Value="saving"></asp:ListItem>
            </asp:radiobuttonlist>
        </div>
    </div>
    <br />
    <div class="row vertical-margin form-group">
        <div class="col-md-4 col-md-offset-1">
            <asp:label ID="lblAmount" runat="server" text="Deposit Amount: "></asp:label>
        </div>
        <div class="col-md-2">
            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-5">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAmount" runat="server" ErrorMessage="Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtAmount" Type="Currency" Operator="GreaterThan" ValueToCompare="0" runat="server" ErrorMessage="Must be greater than 0!" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
        </div>
    </div>
    <br />
    <div class="row vertical-margin form-group">
        <div class="col-md-4 col-md-offset-1">
            <asp:button ID="btnDeposit" OnClick="btnDeposit_Click" runat="server" text="Deposit" CssClass="btn btn-primary"/>
        </div>
        <div class="col-md-6">
            <asp:label ID="lblConfirmation" runat="server" CssClass="distinct"></asp:label>
        </div>
    </div>
</asp:Content>


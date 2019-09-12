<%@ Page Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="CustomerManagement.aspx.cs" Inherits="CustomerManagement" %>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row vertical-margin">
        <div class="col-md-10 col-md-offset-1">
            <h1>Customer Management</h1>
        </div>
    </div>
    <br />
    <div class="row vertical-margin form-group">
        <div class="col-md-3 col-md-offset-1">
            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name: "></asp:Label>
        </div>
        <div class="col-md-5">
            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCustomerName" runat="server" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row vertical-margin">
        <div class="col-md-3 col-md-offset-1">
            <asp:Label ID="lblInitialDeposit" runat="server" Text="Initial Deposit: "></asp:Label>
        </div>
        <div class="col-md-5">
            <asp:TextBox ID="txtInitialDeposit" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtInitialDeposit" runat="server" ErrorMessage="Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtInitialDeposit" Type="Currency" Operator="GreaterThan" ValueToCompare="0" runat="server" ErrorMessage="Must be greater than 0!" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
        </div>
    </div>
    <br />
    <div class="row vertical-margin">
        <div class="col-md-3 col-md-offset-1">
            <asp:button ID="btnAddCustomer" onclick="btnAddCustomer_Click" runat="server" CssClass="btn btn-primary" text="Add Customer" />
        </div>
    </div>
    <div class="row vertical-margin">
        <div class="col-md-10 col-md-offset-1">
            <h3>The following customers are currently in the system:</h3>
        </div>
    </div>
    <div class="row vertical-margin">
        <div class="col-md-10 col-md-offset-1">
            <asp:table ID="tblCourses" runat="server" CssClass="table">
                <asp:TableRow>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Checking Account Balance</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Saving Account Balance</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                </asp:TableRow>
            </asp:table>
        </div>
    </div>
</asp:Content>
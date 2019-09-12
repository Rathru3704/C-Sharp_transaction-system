<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Activity.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row vertical-margin">
        <div class="col-md-10 col-md-offset-1">
            <h1>Account Activities</h1>
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
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="drpCustomer" InitialValue="0" runat="server" ErrorMessage="Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
    </div>
    <br />

    <!-- Result -->
    <asp:Panel ID="pnlResult" runat="server">
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <asp:Label ID="lblCheckingActivities" runat="server" Text="Checking Account Activities:"></asp:Label>
            </div>
            <br />
            <div class="col-md-7 col-md-offset-1">
                <asp:Table ID="tblCheckingResult" runat="server" CssClass="table">
                <asp:TableRow>
                    <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Transaction Type</asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
            </div>
        </div>
        <br />
        <div class="row vertical-margin form-group">
            <div class="col-md-4 col-md-offset-1">
                <asp:Label ID="lblSavingActivities" runat="server" Text="Saving Account Activities:"></asp:Label>
            </div>
            <br />
            <div class="col-md-7 col-md-offset-1">
                <asp:Table ID="tblSavingResult" runat="server" CssClass="table">
                <asp:TableRow>
                    <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Transaction Type</asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
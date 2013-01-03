<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BankTransferWeb.BankTransferWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Bank Transfer Demo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: User.Identity.Name %>&#8217;s Account </h2>

    <p class="reminder">Demo Reminder: Check your email!</p>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Id: 
            <asp:Literal ID="Literal1" runat="server" Text="<%# Account.Id %>" />
        </p>
        <p>
            <strong style="color:#000;">Balance:
            <asp:Literal ID="Literal2" runat="server" Text="<%# Account.Id %>" /></strong>
        </p>
        <p>
            Username: 
            <asp:Literal ID="Literal3" runat="server" Text="<%# Account.Username %>" />
        </p>
    </fieldset>
    
    <fieldset>
        <legend>Transfer Money</legend>
        
        <p>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="amountTextBox" Text="Amount:" />
            <asp:TextBox runat="server" ID="amountTextBox" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="amountTextBox" Text="Destination Account:" />
            <asp:DropDownList ID="destinationAccountDropDown" runat="server" DataValueField="Value" DataTextField="Text">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="submitButton" runat="server" Text="Transfer" OnClick="OnSubmitClick" />
        </p>
    </fieldset>
</asp:Content>


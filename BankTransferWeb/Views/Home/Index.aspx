<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BankTransferWeb.Models.Account>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: User.Identity.Name %>&#8217;s Account </h2>

    <p class="reminder">Demo Reminder: Check your email!</p>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Id: 
            <%: Model.Id %>
        </p>
        <p>
            <strong style="color:#000;">Balance:
            <%: Model.Balance.ToString("c") %></strong>
        </p>
        <p>
            Username: 
            <%: Model.Username %>
        </p>
    </fieldset>
    
    <fieldset>
        <legend>Transfer Money</legend>
        <% using (Html.BeginForm("Transfer", "Home")) { %>
        <p>
            <label for="Amount">Amount:</label>
            <%: Html.TextBox("Amount")%>
        </p>
        <p>
            <label for="destinationAccountId">Destination Account:</label>
            <%: Html.DropDownList("destinationAccountId", "Select an Account") %>
        </p>
        <p>
            <input type="submit" value="transfer" />
        </p>
        <% } %>
    </fieldset>

</asp:Content>


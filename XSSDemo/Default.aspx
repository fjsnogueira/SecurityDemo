﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XSSDemo._Default"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>
        Employee Information</h1>
    <% if (Page.IsPostBack)
       {
           
            %>
    <asp:Label ID="lblEntered" runat="server"></asp:Label>
    <% } %>
    <div>
        Name :
        <asp:TextBox ID="txtName" runat="server" />
        Email :
        <asp:TextBox ID="txtEmail" runat="server" />
        <input type="submit" value="Submit" />
    </div>
    </form>
</body>
</html>

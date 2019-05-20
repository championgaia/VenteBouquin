﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF01_01_Init.aspx.cs" Inherits="WF01_01_MyFirstWF.WF01_01_Init" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="jumbotron text-center">
        <h1>This is my page</h1>
    </div>
    <div class="form-group">
        <label>LastName</label>
        <asp:TextBox runat="server" ID="txbName" ValidateRequestMode="Enabled"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvbox1" ControlToValidate="txbName" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" ID="revbox1" ControlToValidate="txbName" 
            ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$"
            ErrorMessage="not valid name"></asp:RegularExpressionValidator>
    </div>
    <div>
        <label>FirstName</label>
        <asp:TextBox runat="server" ID="txbFirstName" ValidateRequestMode="Enabled"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvbox2" ControlToValidate="txbFirstName" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" ID="revbox2" ControlToValidate="txbFirstName" 
            ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$"
            ErrorMessage="not valid name"></asp:RegularExpressionValidator>
    </div>
    <div>
        <label>BirthDay</label>
        <asp:Calendar runat="server" ID="cldBirthday"></asp:Calendar>
   
    </div>
    <div class="form-group">
        <asp:DropDownList runat="server" ID="ddlNumber" CssClass="btn">
            <asp:ListItem Text="Choose your number" Value="" Selected="True"></asp:ListItem>
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rdvDdlNumber" ControlToValidate="ddlNumber" ErrorMessage="Required a number" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <br />

    <div>
        <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-danger" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    <div>
        <asp:Repeater ID="rptEvents" runat="server">
            <ItemTemplate>
                <h3><%# DataBinder.Eval(Container.DataItem, "DateNaissance")%>
                    <strong><%# DataBinder.Eval(Container.DataItem, "Nom") %></strong>
                    <strong><%# DataBinder.Eval(Container.DataItem, "Prenom") %></strong>
                </h3>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

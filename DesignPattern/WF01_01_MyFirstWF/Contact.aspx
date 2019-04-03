<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WF01_01_MyFirstWF.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div runat="server" id="divMessage" class="message" name="myMessage" values="TellMe">Welcome</div>
    <h3>Tell us about your self</h3>
    <div>
        <label>Name</label>
        <asp:TextBox ID="txtName"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="txtName" ErrorMessage="Required" Display="Dynamic" />
    </div>
    <div>
        <label>Email</label>
        <asp:TextBox ID="txtEmail"  runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator  runat="server" ID="revEmail" ControlToValidate="txtEmail" ErrorMessage="valid email is required" ValidationExpression="^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$" Display="Dynamic" />
        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" ErrorMessage="Required" Display="Dynamic" />
    </div>
    <div>
        <label>Age</label>
        <asp:TextBox ID="txtAge"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvAge" ControlToValidate="txtAge" ErrorMessage="Required" Display="Dynamic"  />
    </div>
    <div>
        <label>Your Favorite color</label>
        <asp:DropDownList ID="ddlColor" runat="server">
            <asp:ListItem Text="Please choose a color" Value="" />
            <asp:ListItem Text="Blue" Value="Blue"/>
            <asp:ListItem Text="Red" Value="Red"/>
            <asp:ListItem Text="Yellow" Value="Yellow"/>
            <asp:ListItem Text="Green" Value="Green"/>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvColor" ControlToValidate="ddlColor" ErrorMessage="Color required" Display="Dynamic" />
    </div>
    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Info" OnClick="btnSubmit_Click" />
    </div>
    <div class="message">
        <asp:Literal ID="ltMessage" runat="server" />
    </div>
</asp:Content>

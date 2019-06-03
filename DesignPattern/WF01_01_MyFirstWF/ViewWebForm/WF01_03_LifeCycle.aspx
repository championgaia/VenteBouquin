<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF01_03_LifeCycle.aspx.cs" Inherits="WF01_01_MyFirstWF.ViewWebForm.WF01_03_LifeCycle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Advanced ASP.NET Web Server</h2>
    <h3>Creat a list of event in a repeater from calendar control.</h3>
    <div class="form-group">
        <div class="form-group">
            <label>PreInit</label>
            <asp:TextBox ID="txtPreInit" Text="" CssClass="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label>Init</label>
            <asp:TextBox runat="server" Text="" CssClass="form-control" ID="txtInit"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>InitComplet</label>
            <asp:TextBox ID="txtInitComplet" Text="" CssClass="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label>PreLoad</label>
            <asp:TextBox runat="server" Text="" CssClass="form-control" ID="txtPreLoad"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>PageLoad</label>
            <asp:TextBox ID="txtPageLoad" Text="" CssClass="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label>LoadComplet</label>
            <asp:TextBox runat="server" Text="" CssClass="form-control" ID="txtLoadComplet"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Rendering</label>
            <asp:TextBox ID="txtRendering" Text="" CssClass="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label>UnLoad</label>
            <asp:TextBox runat="server" Text="" CssClass="form-control" ID="txtUnLoad"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Button cliqué</label>
            <asp:TextBox runat="server" Text="" CssClass="form-control" ID="txtBtn"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Button ID="btnEvent" runat="server" CssClass="btn btn-primary bat-large" Text="Add Event" OnClick="btnEvent_Click" />
    </div>
</asp:Content>

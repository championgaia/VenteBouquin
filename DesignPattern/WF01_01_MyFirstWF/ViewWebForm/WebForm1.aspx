<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WF01_01_MyFirstWF.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Advanced ASP.NET Web Server</h2>
    <h3>Creat a list of event in a repeater from calendar control.</h3>
    <div class="form-group">
        <label>Event Name</label>
        <asp:TextBox ID="txtEvent" CssClass="form-control" runat="server" />
    </div>
    <div class="form-group">
        <label>Event Date:</label>
        <asp:Calendar ID="calendarEvents" runat="server" />
    </div>
    <div class="form-group">
        <asp:Button ID="btnEvent" runat="server" CssClass="btn btn-primary bat-large" Text="Add Event" OnClick="btnEvent_Click" />
    </div>
    <h3>Event Repeater.</h3>
    <div>
        <asp:Repeater ID="rptEvents" runat="server">
            <ItemTemplate>
                <h3><%# DataBinder.Eval(Container.DataItem, "EventDate")%>
                    <strong><%# DataBinder.Eval(Container.DataItem, "EventName") %></strong>

                </h3>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

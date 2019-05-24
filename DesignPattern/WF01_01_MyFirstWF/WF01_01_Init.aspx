<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WF01_01_Init.aspx.cs" Inherits="WF01_01_MyFirstWF.WF01_01_Init" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="jumbotron text-center">
        <h1>This is my page</h1>
    </div>
    <div class="form-group">
        <div>
            <label>LastName</label>
            <asp:TextBox runat="server" ID="txbName" ValidateRequestMode="Enabled" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvbox1" ControlToValidate="txbName" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="revbox1" ControlToValidate="txbName"
                ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$"
                ErrorMessage="not valid name"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label>FirstName</label>
            <asp:TextBox runat="server" ID="txbFirstName" ValidateRequestMode="Enabled"  CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvbox2" ControlToValidate="txbFirstName" ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="revbox2" ControlToValidate="txbFirstName"
                ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$"
                ErrorMessage="not valid name"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label>BirthDay</label>
            <asp:Calendar runat="server" ID="cldBirthday"  CssClass="calendar"></asp:Calendar>

        </div>
        <div class="form-control-static">
            <asp:DropDownList runat="server" ID="ddlNumber" CssClass="btn">
                <asp:ListItem Text="Choose your number" Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ID="rdvDdlNumber" ControlToValidate="ddlNumber" ErrorMessage="Required a number" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div>
        <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-success" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
    </div>
    <br />
    <div>
        <%--<asp:Repeater ID="rptEvents" runat="server">
            <ItemTemplate>
                <h3><%# DataBinder.Eval(Container.DataItem, "DateNaissance")%>
                    <strong><%# DataBinder.Eval(Container.DataItem, "Nom") %></strong>
                    <strong><%# DataBinder.Eval(Container.DataItem, "Prenom") %></strong>
                </h3>
            </ItemTemplate>
        </asp:Repeater>--%>
        <asp:DropDownList ID="ddlPersonne" runat="server" DataTextField="Nom" DataValueField="Prenom">
        </asp:DropDownList>
        <asp:ListView ID="lvPersonne" runat="server">
            <LayoutTemplate>
                <div id="Div1" runat="server">
                    <div id="itemPlaceholder" runat="server">
                    </div>
                </div>
            </LayoutTemplate>
            <EmptyDataTemplate>
                <div id="Div2" runat="server">
                    <div id="itemPlaceholder" runat="server">
                        No data was returned.             
                    </div>
                </div>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table>
                        <tr>
                            <td>
                                <a><%# DataBinder.Eval(Container.DataItem, "NomM")%></a>&nbsp;
                            </td>
                            <td>
                                <a><%# DataBinder.Eval(Container.DataItem, "PrenomM")%></a>&nbsp;
                            </td>
                            <td>
                                <a><%# DataBinder.Eval(Container.DataItem, "DateNaissanceM")%></a>&nbsp;
                            </td>
                        </tr>
                    </table>
                    </p>
                </td>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ViewStateMode="Enabled" CodeBehind="WF01_05_GridViewControl_DataBinding.aspx.cs" Inherits="WF01_01_MyFirstWF.ViewWebForm.WF01_05_GridViewControl_DataBinding" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="jumbotron text-center">
        <h1>This is my second page</h1>
    </div>
    <div>
        <asp:ListView ID="lvBook" runat="server">
            <LayoutTemplate>
                <div id="Div1" runat="server">
                    <div id="itemPlaceholder" runat="server">
                    </div>
                </div>
            </LayoutTemplate>
            <EmptyDataTemplate>
                <div id="Div2" runat="server">
                    <div id="Div3" runat="server">
                        No data was returned.             
                    </div>
                </div>
            </EmptyDataTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table>
                        <tr>
                            <td>
                                <a><%# DataBinder.Eval(Container.DataItem, "CodeISBNM")%></a>&nbsp;
                            </td>
                            <td>
                                <a><%# DataBinder.Eval(Container.DataItem, "NomLivreM")%></a>&nbsp;
                            </td>
                            <td>
                                <a><%# DataBinder.Eval(Container.DataItem, "AuteurM")%></a>&nbsp;
                            </td>
                            <td>
                                <a><%# DataBinder.Eval(Container.DataItem, "EditeurM")%></a>&nbsp;
                            </td>
                            <td>
                                <a><%# DataBinder.Eval(Container.DataItem, "PrixM")%></a>&nbsp;
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnLivre" text="Detail" 
                                    OnClick="btnLivre_Click" 
                                    CommandName="thisClick" 
                                    CommandArgument=<%# DataBinder.Eval(Container.DataItem, "CodeISBNM")%>
                                    />
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnPanier" text="addPanier"
                                    OnClick="btnPanier_Click" ValidateRequestMode="Disabled"
                                    CommandName="thisPanier" 
                                    CommandArgument=<%# DataBinder.Eval(Container.DataItem, "PrixM")%>
                                    />
                            </td>
                        </tr>
                    </table>
                    </p>
                </td>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div>
        <h4><asp:Literal ID="ltError" runat="server"></asp:Literal></h4>
        <asp:GridView runat="server" ID="gvBook" CssClass="table table-striped color-table" AutoGenerateColumns="true" 
            OnRowDeleting="gvBook_RowDeleting" 
            OnRowEditing="gvBook_RowEditing" 
            OnRowUpdating="gvBook_RowUpdating" 
            OnRowCancelingEdit="gvBook_RowCancelingEdit">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnBookId" runat="server" 
                            Value='<%#DataBinder.Eval(Container.DataItem, "CodeLivreM") %>' />
                    </ItemTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnBookISBN" runat="server" 
                            Value='<%#DataBinder.Eval(Container.DataItem, "CodeISBNM") %>' />
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:BoundField DataField="NomLivreM" HeaderText="NomLivre" />
                <asp:BoundField DataField="PrixM" HeaderText="Prix" />
                <asp:CommandField ShowEditButton="true" />
                <asp:CommandField ShowDeleteButton="true" />
            </Columns>
            <EmptyDataTemplate>
                <div id="Div4" runat="server">
                    <div id="Div5" runat="server">
                        No data was returned.             
                    </div>
                </div>
            </EmptyDataTemplate>
            
        </asp:GridView>
    </div>
    <div>
        <asp:Literal ID="txbTotal" Text="text" runat="server" />
    </div>
</asp:Content>

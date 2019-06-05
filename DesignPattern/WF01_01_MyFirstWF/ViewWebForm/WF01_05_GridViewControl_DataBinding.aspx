<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="WF01_05_GridViewControl_DataBinding.aspx.cs" Inherits="WF01_01_MyFirstWF.ViewWebForm.WF01_05_GridViewControl_DataBinding" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="jumbotron text-center">
        <h1>This is my second page</h1>
    </div>
    <div>
        <h4><asp:Literal ID="ltError" runat="server"></asp:Literal></h4>
        <asp:GridView runat="server" ID="gvBook" CssClass="table table-striped color-table" AutoGenerateColumns="false" 
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
                </asp:TemplateField>
<%--                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnBookISBN" runat="server" 
                            Value='<%#DataBinder.Eval(Container.DataItem, "CodeISBNM") %>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
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
    <div class="row color-table">
        <asp:Button ID="btnAddRow" runat="server" Text="Add new Row" CssClass="btn btn-primary" OnClick="btnAddRow_Click" />
        <asp:Literal ID="txbTotal" Text="text" runat="server" />
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="WF01_04_Validation.aspx.cs" Inherits="WF01_01_MyFirstWF.ViewWebForm.WF01_04_Validation" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Advanced ASP.NET Web Server Validation</h2>
    <h3>Creat a form with validation.</h3>
   <div class="form-group">
        <div>
            <asp:Literal runat="server" ID="ltValidationSummary" Visible="false" ></asp:Literal>
            <asp:ValidationSummary runat="server" ID="vsForm" ValidationGroup="valForm" DisplayMode="BulletList" HeaderText="verifier les errors suivant" Visible="true"/>
        </div>
       <div><asp:Literal runat="server" Text="*Obligatoire"></asp:Literal></div>
        <div>
            <label>Civilité</label>
            <asp:RadioButtonList runat="server" ID="rblCivil" CssClass="btn-radio" >
                <asp:ListItem>M</asp:ListItem>
                <asp:ListItem>Mme</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="form-group">
            <label>*Nom</label>
            <asp:TextBox runat="server" ID="txbNom" CssClass="form-control" ValidationGroup="valForm"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvNom" ControlToValidate="txbNom" ValidationGroup="valForm"
                ErrorMessage="obligatoire" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="revNom" ControlToValidate="txbNom" ValidationGroup="valForm"
                ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$" 
                ErrorMessage="pas valide" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label>*Prenom</label>
            <asp:TextBox runat="server" ID="txbPrenom" CssClass="form-control" ValidationGroup="valForm"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvPrenom" ControlToValidate="txbPrenom" ValidationGroup="valForm" 
                ErrorMessage="obligatoire" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="revPrenom" ControlToValidate="txbPrenom" ValidationGroup="valForm"
                ValidationExpression="^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$" 
                ErrorMessage="pas valide" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label>*DateNaissance</label>
            <asp:TextBox runat="server" ID="txbDateNaissance" CssClass="form-control" Text="" ValidationGroup="valForm"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvDateNaissance" ControlToValidate="txbDateNaissance" ValidationGroup="valForm"
                ErrorMessage="obligatoire" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="revDateNaissance" ControlToValidate="txbDateNaissance" ValidationGroup="valForm"
                ValidationExpression="^(((0[1-9]|[12][0-9]|30)[-/]?(0[13-9]|1[012])|31[-/]?(0[13578]|1[02])|(0[1-9]|1[0-9]|2[0-8])[-/]?02)[-/]?[0-9]{4}|29[-/]?02[-/]?([0-9]{2}(([2468][048]|[02468][48])|[13579][26])|([13579][26]|[02468][048]|0[0-9]|1[0-6])00))$" 
                ErrorMessage="pas valide" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
        <div>
            <label>*Email</label>
            <asp:TextBox runat="server" ID="txbEmail" CssClass="form-control" ValidationGroup="valForm"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txbEmail" ValidationGroup="valForm"
                ErrorMessage="obligatoire" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="revEmail" ControlToValidate="txbEmail" ValidationGroup="valForm"
                ValidationExpression="^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$" 
                ErrorMessage="pas valide" Display="Dynamic"></asp:RegularExpressionValidator>
        </div>
       <div>
            <label>*Total</label>
            <asp:TextBox runat="server" ID="txbTotal" CssClass="form-control" ValidationGroup="valForm"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvTotal" ControlToValidate="txbTotal" ValidationGroup="valForm"
                ErrorMessage="obligatoire" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" ID="revTotal" ControlToValidate="txbTotal" ValidationGroup="valForm" 
                Operator="DataTypeCheck" 
                Type="Currency"
                ErrorMessage="pas valide" Display="Dynamic"></asp:CompareValidator>
        </div>
        <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" ValidationGroup="valForm"
            OnClick="btnSubmit_Click"/>
    </div>
</asp:Content>
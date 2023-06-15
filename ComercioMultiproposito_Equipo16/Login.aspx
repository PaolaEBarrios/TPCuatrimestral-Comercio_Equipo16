<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="padding:30px">
    <form>
        <div class="mb-3">
            <asp:Label for="txtUser" cssclass="form-label" ID="lblUser" runat="server"> Usuario</asp:Label>
           
            <asp:TextBox type="text" cssclass="form-control" aria-describedby="userHelp" ID="txtUser" runat="server" placeholder="Ingrese usuario..."></asp:TextBox>
          
            <div id="userHelp" class="form-text">No compartas tu usuario y contraseña con cualquiera.</div>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblContraseña" for="txtContraseña" cssclass="form-label" runat="server" >Contraseña</asp:Label>
           
            <asp:TextBox type="password" cssclass="form-control" ID="txtContraseña" runat="server" placeholder="Ingrese contraseña..." ></asp:TextBox>
        </div>
        <div class="mb-3 form-check">
            

            <asp:CheckBox ID="chckRecordame" runat="server" CssClass="form-check-input" />
            <asp:Label Cssclass="form-check-label" ID="lblRecordame" runat="server" for="chckRecordame">Recordame</asp:Label>
            
        </div>
        
        <asp:Button ID="btnLogin" cssclass="btn btn-primary" runat="server" Text="Ingresar" />
    </form>

</div>
    

</asp:Content>

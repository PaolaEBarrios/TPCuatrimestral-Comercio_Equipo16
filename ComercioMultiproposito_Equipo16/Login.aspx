<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div style="padding:30px;display:flex;align-items:center; flex-direction:column;justify-content:center;height: 100vh">
    
    
    <form>
        <div class="mb-3">
            <asp:Label for="txtUser" cssclass="form-label" ID="lblUser" runat="server"> Usuario</asp:Label>
           
            <asp:TextBox type="text" cssclass="form-control" aria-describedby="userHelp" ID="txtUser" runat="server" placeholder="Ingrese usuario..." style="width:200px"></asp:TextBox>
          
           
        </div>
        <div class="mb-3">
            <asp:Label ID="lblContraseña" for="txtContraseña" cssclass="form-label" runat="server" >Contraseña</asp:Label>
           
            <asp:TextBox type="password" cssclass="form-control" ID="txtContraseña" runat="server" placeholder="Ingrese contraseña..." style="width:200px"></asp:TextBox>
        </div>
        <div class="mb-3 form-check">
            

            <asp:CheckBox ID="chckRecordame" runat="server" CssClass="form-check-input" style="" />
            <asp:Label Cssclass="form-check-label" ID="lblRecordame" runat="server" for="chckRecordame">Recordame</asp:Label>
            
        </div>
        
        <asp:Button ID="btnLogin" cssclass="btn btn-info" OnClick="btnLogin_Click" runat="server" Text="Ingresar"   />
    </form>

</div>
    

</asp:Content>

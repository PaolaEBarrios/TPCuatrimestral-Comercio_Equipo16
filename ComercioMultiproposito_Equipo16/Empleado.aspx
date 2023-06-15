<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Empleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido</h1>
    <div  style="display:flex;">
        
        <div>
            <asp:LinkButton ID="lbtnPerfil" runat="server">Perfil</asp:LinkButton>
        </div>
        <div> 
            <asp:LinkButton ID="lbtnConfiguracion" runat="server">Configuracion</asp:LinkButton>
        </div>
        <div></div>
    </div>
    

    <asp:Button ID="btnAdmistrar" runat="server" Text="Administrar" OnClick="btnAdmistrar_Click"/>

    <asp:Button ID="btnVentas" runat="server" Text="Ventas" />
    <asp:Button ID="btnCompras" runat="server" Text="Compras" />

</asp:Content>

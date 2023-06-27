<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div >
        <asp:TextBox ID="txtFiltrarClientes" runat="server"></asp:TextBox>
        <asp:Button ID="btnFiltrarCliente" runat="server" Text="Buscar"  CssClass="btn btn primary"/>
    </div>

    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>



</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <p></p>
    <p>VER UN TOTAL COMPRAS ESTE MES</p>
<p>PRODUCTO MAS comprados y menos comprado</p>
    <p>productos con stock en minimo</p>
    <p>compras pedidas a fecha limite dar aviso que no fue concluida- comunicarse con el proveedor X</p>

    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Cuando se ingresa una compra, se debe registrar en qué proveedor se compró y qué; de ésta
    manera se deben generar las líneas de stock correspondientes, el "stock actual" y el registro de los precios de compra. 

    <div>

        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblComprar" runat="server" Text="Compras"></asp:Label>


    </div>

    <div>

        <asp:Button ID="btnAgregar" runat="server" Text="Agregar nueva compra"  CssClass="btn btn-primary" OnClick="btnAgregar_Click"/>
        <asp:Button ID="btnMostrar" runat="server" Text="Mostrar todas las compras" CssClass="btn btn-primary" OnClick="btnMostrar_Click"/>
        

    </div>

</asp:Content>

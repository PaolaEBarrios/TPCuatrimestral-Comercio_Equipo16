<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Venta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        formulario para el cliente que este registrado en sistema para poder vender, ademas formar una factura con toda la venta ya confirmada, 
        hacer ventas canceladas=?
    </p>

    <p>
        total de ventas del mes para admin todos los vendedores, para vendedores, mostrar lo total vendido, 
    </p>

    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>

</asp:Content>

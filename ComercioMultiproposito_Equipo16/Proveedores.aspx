<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvProveedor" runat="server">


    </asp:GridView>

    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>
   

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="display:flex; flex-direction: column; align-items: center; justify-content: center; height: 100vh;"">
    <div style="padding:20px">
        <h1>Bienvenido a Mi comercio</h1>
        
    </div>
    <div>
       
    </div>
    <div>
        <asp:Button ID="btnPaginaLogin" runat="server" CssClass="btn btn-primary" Text="Acceder" OnClick="btnPaginaLogin_Click" />
    </div>
</div>
    


</asp:Content>

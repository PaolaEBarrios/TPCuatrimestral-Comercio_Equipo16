<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="display:flex; flex-direction: column; align-items: center; justify-content: center; height: 100vh;"">
         <div>
            <img src="miComercio.png" style="background-color:aqua; border-radius:50%;width:200px"/>
        </div>
    <div style="padding:20px">
    
        <h1>Bienvenido a Mi comercio</h1>
        
    </div>

    <div>
        <asp:Button ID="btnPaginaLogin" runat="server" CssClass="btn btn-primary" Text="Acceder" OnClick="btnPaginaLogin_Click" style="background-color:aqua;border-color:black;color:black;"/>
    </div>
</div>
    


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
           
        .exito
        {
            display:flex;
            align-items:center;
            justify-items:center;

        }
    
    </style>

    <div class="exito">

        <asp:Label id="lblAviso" runat="server" Text=""></asp:Label>

    </div>
    <div>
        <asp:Button id="btnVolver" runat="server" Text="" OnClick="btnVolver_Click" />
    </div>

</asp:Content>

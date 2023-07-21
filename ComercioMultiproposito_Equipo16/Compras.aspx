<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <style>
        .tituloCompras
        {
            display:flex;
            align-items:center;
            justify-items:center;
            justify-content:center;

            font-size:30px;
        }

        .contenedorBotones
        {
            display:flex;
            align-items:center;
            justify-content:center;
            justify-items:center;

        }

        .contenedorBotones-btnAgregar
        {
            padding:20px;
        }

        .contenedorBotones-btnMostrar
        {
            padding:20px;
        }

    </style>

    <div class="tituloCompras">

        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblComprar" runat="server" Text="Compras"></asp:Label>


    </div>

    <div class="contenedorBotones">
        <div class="contenedorBotones-btnAgregar">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar nueva compra"  CssClass="btn btn-info" OnClick="btnAgregar_Click"/>
        </div>
        <div class="contenedorBotones-btnMostrar">
            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar todas las compras" CssClass="btn btn-info" OnClick="btnMostrar_Click"/>
        </div>
        
        
    </div>
    <div class="contenedorBotones">
            <asp:Button ID="btnVolver" runat="server" Text="Volver al menu" CssClass="btn btn-info" OnClick="btnVolver_Click" />
        </div>
</asp:Content>

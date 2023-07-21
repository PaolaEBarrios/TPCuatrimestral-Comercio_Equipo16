<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <style>

        .botonboton
        {
            display:inline-block;
            padding-right:10px;
            padding-bottom:10px;
            margin:10px;
            
        }

        .botonboton:hover
        {
           
        }

        .contenedor
        {
             display: flex;
                flex-wrap: wrap; 
                justify-content: center; 
                margin: 0 auto; 
        }
        .Titulo
        {
            display:flex;
            align-content:center;
            flex-direction:column;
            justify-content:center;
            justify-items:center;
            align-items:center;
        }

        .botonvolver
        {
            display:flex;
            justify-content:center;
            justify-items:center;
            align-content:center;
        }
    </style>
    
    <div class="Titulo">
        
        <asp:Label ID="lblTitulo" runat="server" Text="Ventas" style="font-size:30px;font-family:Arial;font-weight:bold"></asp:Label>

    </div>
    <div class="contenedor">
        <div class="botonboton">
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Nueva Venta" CssClass="btn btn-info" OnClick="btnAgregar_Click" />
    </div>


    <div class="botonboton">
        <asp:Button ID="btnMostrar" runat="server" Text="Mostrar todas las ventas" CssClass="btn btn-info" OnClick="btnMostrar_Click" />
    </div>
    </div>
    <div class="botonvolver">
        <asp:Button ID="btnVolver" runat="server" Text="Volver al menu de administacion" CssClass="btn btn-info" OnClick="btnVolver_Click"/>
    </div>
    

</asp:Content>

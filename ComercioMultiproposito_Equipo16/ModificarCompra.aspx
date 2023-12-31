﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="ModificarCompra.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.ModificarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <style>
        .contenedora {
            display: flex;
            align-items: center;
            justify-content: center;
            align-content: center;
            justify-items: center;
            flex-direction: column;
        }

        .LabelRegistrar {
            display: flex;
            width: 300px;
            align-items: center;
            justify-content: center;
            align-content: center;
            justify-items: center;
            flex-direction: column;
        }

        .form-compra {
            display: flex;
            width: 300px;
            align-items: center;
            justify-content: center;
            align-content: center;
            justify-items: center;
            flex-direction: column;
        }

        .botonCompra {
            display: flex;
            width: 300px;
            align-items: center;
            justify-content: center;
            align-content: center;
            justify-items: center;
            flex-direction: column;
            padding:20px;
        }
    </style>

    <div class="contenedora">
        <div class="LabelRegistrar">
            <asp:Label Text="" runat="server" ID="lblAviso" />
            <asp:Label ID="lblModificarCompra" runat="server" Text="Modificar compra"></asp:Label>
        </div>
        <div class="form-compra">

            <asp:Label ID="lblSeleccionProveedor" runat="server" Text="Seleccione al proveedor: "></asp:Label>
            <asp:DropDownList ID="ddlProveedores" CssClass="btn-group" runat="server" OnSelectedIndexChanged="ddlProveedores_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:Label ID="lblSeleccionProducto" runat="server" Text="Seleccione el producto: "></asp:Label>
            <asp:DropDownList ID="ddlProductos" CssClass="btn-group" runat="server" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad de unidades: "></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form form-control" class="textbox"></asp:TextBox>
            <asp:Label ID="lblMediosPago" runat="server" Text="Medios de pago: "></asp:Label>
            <asp:DropDownList ID="ddlMediosPago" runat="server" CssClass="form form-control"></asp:DropDownList>
            <asp:Label ID="lblEstado" runat="server" Text="Estado del pedido: "></asp:Label>
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="btn-group"></asp:DropDownList>

        </div>
        <div class="botonCompra">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar compra" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
        </div>
        <div>
            <asp:Button ID="btnVolver" runat="server" Text="Volver a la pagina anterior" OnClick="btnVolver_Click" cssclass="btn btn-primary"/>
        </div>
    </div>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="AgregarCompras.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.AgregarCompras" %>

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
        .divbtn
        {
            padding:10px;
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
        }
    </style>

    <div class="contenedora">
        <div class="LabelRegistrar">
            <asp:Label Text="" runat="server" ID="lblAviso" />
            <asp:Label ID="lblAgregarCompra" runat="server" Text="Registrar nueva compra"></asp:Label>
        </div>
        <div class="form-compra">

            <asp:Label ID="lblSeleccionProveedor" runat="server" Text="Seleccione al proveedor: "></asp:Label>
            <asp:DropDownList ID="ddlProveedores" CssClass="btn-group" runat="server" OnSelectedIndexChanged="ddlProveedores_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:Label ID="lblchk" runat="server" Text="Desea seleccionar otro proveedor?">
                <asp:CheckBox ID="ChkProveedor"  runat="server" Checked="false" AutoPostBack="true" OnCheckedChanged="ChkProveedor_CheckedChanged" />
            </asp:Label>
            
            <asp:Label ID="lblSeleccionProducto" runat="server" Text="Seleccione el producto: "></asp:Label>
            <asp:DropDownList ID="ddlProductos" CssClass="btn-group" runat="server" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad de unidades: "></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form form-control" class="textbox"></asp:TextBox>
            <div class="divbtn">
            <asp:Button ID="btnAgregarMasProductos" runat="server" Text="Agregar producto a la compra" CssClass="btn btn-info" OnClick="btnAgregarMasProductos_Click" />

            </div>

            <asp:Label ID="lblMediosPago" runat="server" Text="Medios de pago: "></asp:Label>
            <asp:DropDownList ID="ddlMediosPago" runat="server" CssClass="form form-control"></asp:DropDownList>


        </div>
        <div class="botonCompra">
            <div class="divbtn">
                <asp:Button ID="btnAgregar" runat="server" Text="Registrar compra" OnClick="btnAgregar_Click" CssClass="btn btn-info" />
            </div>
            
            <asp:Button ID="btnVolver" CssClass="btn btn-info" runat="server" Text="Volver a la pagina compras" OnClick="btnVolver_Click" />
        </div>
    </div>



</asp:Content>

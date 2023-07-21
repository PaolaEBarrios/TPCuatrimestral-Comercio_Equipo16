<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="AgregarVentas.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.AgregarVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .formulario-ventas {
            
            display:flex;
            flex-direction:inherit;
            justify-content: center;
            align-items: center;
        }

        .div-botones {
                        display:flex;
            align-content:center;
            justify-content:center;
        }

        .btnMas
        {
            padding:10px;
        }
        .titulo {
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 30px;
        }

        .formulario-ventas_dni
        {
            padding:10px;
        }

        .divDetalles
        {
            padding-left:10px;
        }

        .totalVenta
        {
            display:flex;
            align-content:center;
            justify-content:center;
            
        }

        .formulario-ventas_prod
        {
            padding:10px;
        }

        .div-botones_btnAgregar
        {
            padding-right:10px;
        }
    </style>


    <div>
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
    </div>
    <div class="titulo">
        <asp:Label ID="lblAgregarVenta" runat="server" Text="Registrar nueva venta"></asp:Label>
    </div>

    <div class="formulario-ventas">
        
        <div>
            <asp:TextBox ID="txtCodigoVenta" runat="server" CssClass="form form-control" Visible="false"></asp:TextBox>
        <div class="formulario-ventas_dni">
            <asp:Label ID="lblDniCliente" runat="server" Text="DNI O CUIT CUIL del cliente: "></asp:Label>
            <asp:TextBox ID="txtDni" runat="server" placeholder="Dni del cliente..." CssClass="form form-control" Style="width: 200px"></asp:TextBox>
        </div>
            <div class="formulario-ventas_prod">
                <asp:Label ID="lblDdlProductos" runat="server" Text="Seleccione producto/s"></asp:Label>
                <asp:DropDownList ID="ddlProductos" runat="server" CssClass="" AutoPostBack="true"  OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged"></asp:DropDownList>
                <br />
                <asp:Label ID="lblPrecioActual" runat="server" Text="Precio actual: " for="txtPrecio">
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form form-control" Style="width: 150px;" ReadOnly="true" ></asp:TextBox>
                </asp:Label>
                
                <asp:Label ID="lblPrecioGanancia" runat="server" Text="Precio con ganancia: % "></asp:Label>
                <asp:TextBox ID="txtPrecioImpuestos" runat="server" CssClass="form form-control" Style="width: 150px;" ReadOnly="true"></asp:TextBox>

                <asp:Label ID="lblcantidad" runat="server" Text="Unidades: "></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server" placeholder="Unidades..." CssClass="form form-control" Style="width: 100px; " OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true"></asp:TextBox>
                
                <div class="btnMas">
                    <asp:Button ID="btnMasProductos" runat="server" Text="Agregar producto a la venta"  CssClass="btn btn-info"  OnClick="btnMasProductos_Click" style="padding:10px"/>
                </div>
                
            </div>


        </div>

            <div class="divDetalles">
                 <asp:ListBox ID="lboxProductos" CssClass="list-group" runat="server" AutoPostBack="true" style="width:200px; height:200px" Visible="false"></asp:ListBox>
        
                <asp:Label ID="lblistBoxProductos" runat="server" Text="Producto agregado, cantidad y total"></asp:Label>
                <asp:ListBox ID="lboxCantidades" CssClass="list-group list-group-flush" runat="server" Enabled="false" AutoPostBack="true" style="width:300px; height:200px"></asp:ListBox>


                <asp:Label ID="lblPrecioxTotal" runat="server" Text="Total x producto: "></asp:Label>
                <asp:TextBox ID="txtTotalxProducto" runat="server" CssClass="form form-control" Style="width: 100px" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="totalVenta">
        <asp:Label ID="lblTotalVenta" runat="server" Text="Total Venta: "></asp:Label>
        <asp:TextBox ID="txtTotalVenta" runat="server" CssClass="form form-control" style="width:150px;height:50px"></asp:TextBox>
    </div>
    </div>

    <div class="div-botones">
        <div class="div-botones_btnAgregar">
            <asp:Button CssClass="btn btn-info" ID="btnAgregar" runat="server" Text="Registrar Venta" OnClick="btnAgregar_Click" Style="" />
        </div>
        <asp:Button ID="btnVolver" CssClass="btn btn-info" runat="server" Text="Volver a la pagina Ventas" OnClick="btnVolver_Click" />
    </div>

</asp:Content>

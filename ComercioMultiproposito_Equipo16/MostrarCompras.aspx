<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="MostrarCompras.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.MostrarCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .tituloMostrar
        {
            display:flex;
            align-items:center;
            justify-content:center;
            font-size:30px;
        }

        .buscarConText
        {
            display:flex;
            align-items:center;
            justify-content:center;
            align-content:center;
            justify-items:center;
            
            padding:30px;
        }
        .btnvolver
        {
            display:flex;
            align-content:center;
            justify-content:center;
            padding-bottom:10px;
        }
    </style>

    <div class="tituloMostrar">
        <asp:Label ID="lblMostrarCompras" runat="server" Text="Listado de todas las compras"></asp:Label>
    </div>
    <div class="buscarConText">
        <asp:TextBox ID="txtBuscar" AutoPostBack="true" placeholder="Buscar por id compra" runat="server" CssClass="form form-control" style="width:300px;" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
    </div>
        <div class="btnvolver">
        <asp:Button ID="btnVolver" runat="server" Text="Volver a la pagina de compras"  CssClass="btn btn-info" OnClick="btnVolver_Click"/>
    </div>
            <div class="row">
            <div class="col">
                <asp:GridView ID="dgvCompras" OnRowCommand="dgvCompras_RowCommand" DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">
                    <Columns>

                        <asp:BoundField HeaderText="ID de compra" DataField="Codigo" />
                        <asp:BoundField HeaderText=" CUIT/CUIL/DNI PROVEEDOR " DataField="Proveedor.dni"/>
                        <asp:BoundField HeaderText="Nombre del proveedor" DataField="Proveedor.Nombre"/>
                        
                        <asp:BoundField HeaderText="Forma de pago" DataField="FormaPago"/>
                        <asp:BoundField HeaderText=" Fecha de compra " DataField="FechaCompra" />
                        <asp:ButtonField CommandName="Detalle" ButtonType="Button" Text="Detalles de la compra"/>
                    </Columns>

                </asp:GridView>

                </div>
        </div>

</asp:Content>

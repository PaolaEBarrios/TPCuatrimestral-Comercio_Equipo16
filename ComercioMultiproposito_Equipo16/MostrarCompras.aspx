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

    </style>

    <div class="tituloMostrar">
        <asp:Label ID="lblMostrarCompras" runat="server" Text="Listado de todas las compras"></asp:Label>
    </div>
    <div class="buscarConText">
        <asp:TextBox ID="txtBuscar" placeholder="Buscar por id compra" runat="server" CssClass="form form-control" style="width:300px;"></asp:TextBox>
    </div>
            <div class="row">
            <div class="col">
                <asp:GridView ID="dgvCompras" OnRowCommand="dgvCompras_RowCommand" DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">
                    <Columns>

                        <asp:BoundField HeaderText="ID de compra" DataField="Codigo" />
                        
                        <asp:BoundField HeaderText=" Forma de pago " DataField="FormaPago"  />
                        <asp:BoundField HeaderText=" Proveedor " DataField="Proveedor"/>
                        <asp:BoundField HeaderText=" Productos " DataField="Producto" />
                        <asp:BoundField HeaderText=" Estado de la compra" DataField="Estado"/>
                        <asp:BoundField HeaderText=" Fecha de compra " DataField="FechaCompra" />
                        <asp:ButtonField CommandName="Modificar"  ButtonType="Button" Text="Modificar Compra" />
                        <asp:ButtonField CommandName="Eliminar" ButtonType="Button" Text="Eliminar compra" />
                    </Columns>

                </asp:GridView>

                </div>
        </div>

</asp:Content>

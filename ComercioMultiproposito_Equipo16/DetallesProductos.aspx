<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="DetallesProductos.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.DetallesProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
    </div>

   <div class="row">
            <div class="col">
                <asp:GridView ID="dgvDetalleProductos" OnRowCommand="dgvDetalleProductos_RowCommand"  DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">

                    <Columns>

                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" Visible="false" />
                        <asp:BoundField HeaderText="Producto" DataField="NombreProducto" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca"/>
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio"/>
                        <asp:BoundField HeaderText="Stock Actual" DataField="Stock"/>
                        <asp:BoundField HeaderText="Stock minimo" DataField="StockMin"/>
                        <asp:BoundField HeaderText="Ganancia" DataField="Ganancia"/>
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>

                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                       
                   
                   </Columns>

                </asp:GridView>

            </div>
        </div>

    <div>
        <asp:Button ID="btnVolver" runat="server" Text="Volver a la pagina de Productos"  OnClick="btnVolver_Click"/>
    </div>

</asp:Content>

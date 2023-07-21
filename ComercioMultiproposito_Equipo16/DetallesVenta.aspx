<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="DetallesVenta.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.DetallesVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .Volver
        {
            padding:5px;
        }

        .h3
        {
            display:flex;
            align-content:center;
            justify-content:center;
        }
        .div-clientes
        {
            display:flex;
            flex-direction:column;
            padding:20px;
        }

        .cajaTotal
        {
            display:flex;
            align-content:end;
            justify-content:end;
        }

    </style>

    <div class="Volver">
        <asp:Button runat="server" id="btnVolver" OnClick="btnVolver_Click" Text="Volver al listado ventas" CssClass="btn btn-info"  />
    </div>

    <div class="h3">
        <h3>Detalles de la venta: <asp:Label runat="server" id="lblIDcompra" Text=""></asp:Label> </h3>
    </div>
    
    <div class="contenedor">

        <div class="div-clientes">
            
            <asp:Label ID="lblInformacion" runat="server" Text="Informacion del cliente"></asp:Label>
            <asp:Label ID="lblNombre" runat="server" Text="Apellido y nombre: "> 
                <asp:Label ID="lblApellidoNombre" runat="server" Text=""></asp:Label>
            </asp:Label>
            <asp:Label ID="lbldeDNI" runat="server" Text="DNI/CUIT/CUIL: ">
                <asp:Label ID="lbldni" runat="server" Text=""></asp:Label>
            </asp:Label>
            <asp:Label ID="lblcontactoemail" runat="server" Text="Email: ">
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </asp:Label>
            <asp:Label ID="lblcontactotelefono" runat="server" Text="Telefono/celular: ">
                <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label>
            </asp:Label>
            

        </div>

         <div class="row">
            <div class="col">
                <asp:GridView ID="dgvDetalles"  DataKeyNames="Codigo" runat="server" CssClass="table table-info " AutoGenerateColumns="false">
                    <Columns>

                        <asp:BoundField HeaderText="Producto" DataField="Producto.NombreProducto" />
                        
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"  />
                        
                        <asp:BoundField HeaderText="Precio unitario" DataField="PrecioUnidad"/>
                        
                        <asp:BoundField HeaderText="Subtotal" DataField="total"/>

                    </Columns>

                </asp:GridView>

             </div>
        </div>

    </div>

    <div class="cajaTotal">
        <asp:Label ID="lblTotal" runat="server" Text="Total venta:  " style="font-size:30px;"></asp:Label>
        <asp:Label ID="lblTotalVenta" runat="server" Text="" style="font-size:30px;"></asp:Label>
    </div>
</asp:Content>

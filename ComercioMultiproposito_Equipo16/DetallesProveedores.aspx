<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="DetallesProveedores.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.DetallesProveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
    </div>

   <div class="row">
            <div class="col">
                <asp:GridView ID="dgvDetalleProductos"   DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">

                    <Columns>

                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" Visible="false" />
                        <asp:BoundField HeaderText="Nombre Proveedor" DataField="Nombre" />
                        <asp:BoundField HeaderText="Domicilio" DataField="Domicilio"/>
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Correo electronico" DataField="Email"/>
                        <asp:BoundField HeaderText="CUIT/CUIL/DNI" DataField="Dni"/>
                        

                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                       
                   
                   </Columns>

                </asp:GridView>

            </div>
        </div>

    <div>
        <asp:Button ID="btnVolver" runat="server" Text="Volver a la pagina de Productos"  OnClick="btnVolver_Click" CssClass="btn btn-info"/>
    </div>
</asp:Content>

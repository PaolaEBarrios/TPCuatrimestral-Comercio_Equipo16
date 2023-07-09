<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="MostrarCompras.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.MostrarCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>


    </style>

            <div class="row">
            <div class="col">
                <asp:GridView ID="dgvCompras"   DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">
                    <Columns>

                        <asp:BoundField HeaderText="ID de compra" DataField="Codigo" />
                        
                        <asp:BoundField HeaderText=" Forma de pago " DataField="FormaPago"  />
                        <asp:BoundField HeaderText=" Proveedor " DataField="Proveedor"/>
                        <asp:BoundField HeaderText=" Productos " DataField="Producto" />
                        <asp:BoundField HeaderText=" Estado de la compra" DataField="Estado"/>
                        <asp:BoundField HeaderText=" Fecha de compra " DataField="FechaCompra" />

                    </Columns>

                </asp:GridView>

                </div>
        </div>

</asp:Content>

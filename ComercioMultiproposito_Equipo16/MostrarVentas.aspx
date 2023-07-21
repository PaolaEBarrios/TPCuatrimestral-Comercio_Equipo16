<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="MostrarVentas.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.MostrarVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .btnVolver
        {
            padding:10px;
        }

        .form-buscar
        {
            display:flex;
            align-content:center;

            padding:10px;
        }
    </style>
    <div class="form-buscar">
        <asp:TextBox ID="txtBuscar" runat="server" OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" CssClass="form form-control" style="width:300px;" placeholder="Buscar venta por id..."></asp:TextBox>
    </div>
    <div class="btnVolver">
        <asp:Button ID="btnVolver" runat="server" Text="Volver a Ventas" CssClass="btn btn-info" OnClick="btnVolver_Click" />
        <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar todas las ventas" CssClass="btn btn-info" OnClick="btnMostrarTodos_Click" />
    </div>
     <div class="row">
            <div class="col">
                <asp:GridView ID="dgvVentas" OnRowCommand="dgvVentas_RowCommand" DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">
                    <Columns>

                        <asp:BoundField HeaderText="ID Venta" DataField="Codigo" />
                        
                        <asp:BoundField HeaderText="DNI cliente " DataField="Cliente.dni"  />
                        
                        <asp:BoundField HeaderText=" Apellido" DataField="Cliente.Apellido"/>
                        
                        <asp:BoundField HeaderText="Fecha de la venta" DataField="fechaVenta"/>

                        <asp:ButtonField CommandName="Detalle" ButtonType="Button" Text="Detalles..." />
                    </Columns>

                </asp:GridView>

             </div>
        </div>

</asp:Content>

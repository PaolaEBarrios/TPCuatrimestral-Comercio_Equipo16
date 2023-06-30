<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <style>
        .btn {
            display: flex;
            border-color: aqua;
            background-color: aquamarine;
            padding: 10px;
            margin: 5px;
        }


        .h2_Productos {
            padding: 5px;
            display: flex;
            align-items: center;
            flex-direction: column;
        }

        .cajabotones {
            padding: 10px;
            display: flex;
            align-items: center;
            align-content: center;
            justify-content: center;
        }

        .cajaDGV {
            display: flex;
            align-content: center;
            justify-content: center;
        }

        .col {
            width: 400px;
        }

        .row {
        }

        .cajaBuscar {
            padding: 10px;
            display: flex;
            align-items: center;
            align-content: center;
            justify-content: center;
        }
    </style>


    <div class="h2_Productos">
        <h2>Productos</h2>
    </div>

    <div class="cajaBuscar">
        <asp:TextBox ID="txtBuscarProductos" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" class="btn" />
    </div>



    <div class="cajabotones">
        <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar nueva Marca" CssClass="btn btn-Primary" class="btn" OnClick="btnAgregarProducto_Click" />
    </div>


    <div class="cajaDGV">
        <div class="row">
            <div class="col">
                <asp:GridView ID="dgvProductos" OnRowCommand="dgvProductos_RowCommand"   DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">

                    <Columns>

                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" Visible="false" />
                        <asp:BoundField HeaderText="Producto" DataField="NombreProducto" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca"/>
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio"/>
                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Detalles" Text="Detalles" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                   
                   </Columns>

                </asp:GridView>

            </div>
        </div>

    </div>

    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>

</asp:Content>

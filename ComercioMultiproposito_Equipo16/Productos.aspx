<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <style>
        .btn {
            display: flex;

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
        <asp:TextBox ID="txtBuscarProductos" AutoPostBack="true" runat="server" OnTextChanged="txtBuscarProductos_TextChanged"></asp:TextBox>

    </div>



    <div class="cajabotones">
        <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar nuevo Producto" CssClass="btn btn-info" class="btn" OnClick="btnAgregarProducto_Click" />
            <asp:Button ID="btnEmpleado" runat="server" Text="Volver al menu" cssclass="btn btn-info" OnClick="btnEmpleado_Click"/>
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
                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button"  />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button"  />
                        <asp:ButtonField CommandName="Detalles" Text="Detalles" ButtonType="Button"  />
                   
                   </Columns>

                </asp:GridView>

            </div>
        </div>

    </div>



</asp:Content>

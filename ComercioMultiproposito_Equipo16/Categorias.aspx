<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Categorias" %>
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


        .h2_Categoria {
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


    <div class="h2_Categoria">
        <h2>Categorias</h2>
    </div>

    <div class="cajaBuscar">
        <asp:TextBox ID="txtBuscarCategoria" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" class="btn" />
    </div>


    <div class="cajabotones">
        <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar nueva Categoria" CssClass="btn btn-Primary" class="btn" OnClick="btnAgregarCategoria_Click" />
    </div>



    <div class="cajaDGV">
        <div class="row">
            <div class="col">
                <asp:GridView ID="dgvCategorias" OnRowCommand="dgvCategoria_RowCommand"   DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">

                    <Columns>

                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" Visible="false" />
                        <asp:BoundField HeaderText="Categoria" DataField="NombreCategoria" />
                       
                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                    </Columns>

                </asp:GridView>

            </div>
        </div>

    </div>

    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>

</asp:Content>

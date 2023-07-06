<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Marcas" %>

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


        .h2_marca {
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


    <div class="h2_marca">
        <h2>Marcas</h2>
    </div>

    <div class="cajaBuscar">
        <asp:TextBox ID="txtBuscarMarca" runat="server" AutoPostBack="true" OnTextChanged="txtBuscarMarca_TextChanged"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" class="btn" />
    </div>

    <%  if (Session["usuario"]!= null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN) {

%>

    <div class="cajabotones">
        <asp:Button ID="btnAgregarMarca" runat="server" Text="Agregar nueva Marca" CssClass="btn btn-Primary" class="btn" OnClick="btnAgregarMarca_Click" />
    </div>


      <% } %>
    <div class="cajaDGV">
        <div class="row">
            <div class="col">
                <asp:GridView ID="dgvMarcas" OnRowCommand="dgvMarcas_RowCommand"  OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged" DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">

                    <Columns>

                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" Visible="false" />
                        <asp:BoundField HeaderText="Marca" DataField="NombreMarca" />
                        <%--<asp:CommandField ShowSelectButton="true" SelectText="Modificar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv"/>
                        <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" ButtonType="Button"  ItemStyle-CssClass="estiloBTNdgv" />--%>
                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                    </Columns>

                </asp:GridView>

            </div>
        </div>

    </div>

    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>


</asp:Content>

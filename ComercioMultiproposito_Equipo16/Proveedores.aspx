<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .btn {
            display: flex;

            padding: 10px;
            margin: 5px;
        }


        .h2_Proveedores {
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

    <div class="h2_Proveedores">
        <h2>Proveedores</h2>
    </div>

    <div class="cajaBuscar">
        <asp:TextBox ID="txtBuscarProveedores" runat="server" OnTextChanged="txtBuscarProveedores_TextChanged" AutoPostBack="true" CssClass="form form-control" style="width:250px" placeholder="Buscar proveedor por Cuit/Dni/CUIL"></asp:TextBox>
    </div>

    <%  if (Session["usuario"]!= null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN) {

%>

    <div class="cajabotones">
        <asp:Button ID="btnAgregarProveedores" runat="server" Text="Agregar nuevo Proveedor" CssClass="btn btn-info" class="btn" OnClick="btnAgregarProveedores_Click" />
    </div>


      <% } %>

    <div class="cajabotones">
            <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-info" OnClick="btnEmpleado_Click"/>
    </div>

    <div class="cajaDGV">
        <div class="row">
            <div class="col">
    <asp:GridView ID="dgvProveedores" OnRowCommand="dgvProveedores_RowCommand"  OnSelectedIndexChanged="dgvProveedores_SelectedIndexChanged" DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">
        <Columns>

                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" Visible="false" />
                        <asp:BoundField HeaderText="Proveedores" DataField="Nombre" />
                        <asp:BoundField HeaderText="CUIT/DNI" DataField="Dni"/>
                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" />
                        <asp:ButtonField CommandName="Detalle" Text="Detalles" ButtonType="Button" />
         </Columns>

    </asp:GridView>

                </div>
        </div>

    </div>


   

</asp:Content>

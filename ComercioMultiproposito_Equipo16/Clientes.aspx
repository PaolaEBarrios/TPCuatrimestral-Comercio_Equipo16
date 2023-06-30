<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Clientes" %>
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


        .h2_Clientes {
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

    <div class="h2_Clientes">
        <h2>Clientes</h2>
    </div>

    <div class="cajaBuscar">
        <asp:TextBox ID="txtBuscarClientes" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" class="btn" />
    </div>

    <%  if (Session["usuario"]!= null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN) {

%>

    <div class="cajabotones">
        <asp:Button ID="btnAgregarClientes" runat="server" Text="Agregar nuevo Cliente" CssClass="btn btn-Primary" class="btn" OnClick="btnAgregarClientes_Click" />
    </div>


      <% } %>
    <div class="cajaDGV">
        <div class="row">
            <div class="col">
    <asp:GridView ID="dgvClientes" OnRowCommand="dgvClientes_RowCommand"  OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" DataKeyNames="Id" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">
        <Columns>

                        <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                        <asp:BoundField HeaderText=" Nombre " DataField="Nombre" />
                        <asp:BoundField HeaderText=" Apellido " DataField="Apellido"  />
                        <asp:BoundField HeaderText=" DNI " DataField="DNI"/>
                        
                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Detalles" Text="Detalles" ButtonType="Button" />
                    </Columns>

    </asp:GridView>

                </div>
        </div>

    </div>

    <asp:Button ID="btnEmpleado" runat="server" Text="Volver" cssclass="btn btn-primary" OnClick="btnEmpleado_Click"/>
   

</asp:Content>

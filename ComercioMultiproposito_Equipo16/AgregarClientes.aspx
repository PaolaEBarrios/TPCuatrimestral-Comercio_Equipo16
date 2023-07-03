<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="AgregarClientes.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.AgregarClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .form_agregar
        {
            display:flex;
            flex-direction:column;
            justify-content:center; 
            align-items:center;
            
        }

        .h2_AddClientes
        {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding:20px;
        }

        .form_agregar-txtNombre
        {
            width:350px;
            padding:20px;
        }

        .form_agregar-btn
        {
            padding:20px;
        }

        .h2_ModificarClientes
        {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding:20px;
        }

        .form_agregar-btnModificar
        {
            padding:10px;
        }

    </style>

    <div class="h2_AddClientes">
        <asp:Label ID="lblAgregarClientes" runat="server" Text="Agregar Clientes"></asp:Label>

    </div>

    <div class="h2_ModificarClientes">
        <asp:Label ID="lblModificarClientes" runat="server" Text="Modificar Clientes: "></asp:Label>
    </div>

    <div class="form_agregar">

        
        <asp:Label ID="lblAvisoClientes" runat="server" Text=""></asp:Label>
        <div class="form_agregar-txtNombre">
            <asp:Label Text="DNI/CUIT: " runat="server" id="lblDni" for="txtDni"/>
            <asp:TextBox runat="server" placeholder="Ingrese dni O CUIT..." ID="txtDni" CssClass="form-control" />

            <asp:Label ID="lblClientes" cssclass="form-label" runat="server" Text=" Nombres: " for="txtNombreClientes"></asp:Label>
            <asp:TextBox cssclass="form-control" placeholder="Ingrese nombres..." ID="txtNombreClientes" runat="server"></asp:TextBox>
            <asp:Label Text="Apellidos: " runat="server"  ID="lblApellido"/>
            <asp:TextBox runat="server" placeholder="Ingrese apellidos..." ID="txtApellido" CssClass="form-control"/>
            <asp:Label ID="lblCodigoPostal" runat="server" Text="Codigo postal: " For="txtCP"></asp:Label>
            <asp:TextBox ID="txtCP" CssClass="form-control" runat="server"></asp:TextBox>

        </div>
        <%  if (Session["usuario"]!= null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN) {

%>
        <div class="form_agregar-btn">
            <asp:Button ID="btnAgregarClientes" cssclass="btn btn-primary" runat="server" Text="Añadir nuevo Cliente" Onclick="btnAgregarClientes_Click"/>
        </div>
        
        <div class="form_agregar-btnModificar">
            <asp:Button ID="btnModificarClientes" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificarClientes_Click" />
        </div>
        
        <% } %>
        <div class="form_agregar-btnVolver">
            <asp:Button ID="btnVolverClientes" runat="server" cssclass="btn btn-primary" Text="Volver atras" OnClick="btnVolverClientes_Click"   />
        </div>
        
    </div>
</asp:Content>

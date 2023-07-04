<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="AgregarProveedores.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.AgregarProveedores" %>
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

        .h2_AddProveedores
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

        .h2_ModificarProveedores
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

    <div class="h2_AddProveedores">
        <asp:Label ID="lblAgregarProveedores" runat="server" Text="Agregar Proveedores"></asp:Label>

    </div>

    <div class="h2_ModificarProveedores">
        <asp:Label ID="lblModificar" runat="server" Text="Modificar Proveedores: "></asp:Label>
    </div>

    <div class="form_agregar">

        
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
        <div class="form_agregar-txtNombre">
            <asp:Label ID="lblProveedores" cssclass="form-label" runat="server" Text=" Proveedores: " for="txtNombreProveedores"></asp:Label>
            <asp:TextBox cssclass="form-control" placeholder="Nombre de el Proveedor" ID="txtNombreProveedores" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>


        </div>
        <%  if (Session["usuario"]!= null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN) {

%>
        <div class="form_agregar-btn">
            <asp:Button ID="btnAgregarProveedores" cssclass="btn btn-primary" runat="server" Text="Añadir nuevo Proveedor" Onclick="btnAgregarProveedores_Click"/>
        </div>
        
        <div class="form_agregar-btnModificar">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" />
        </div>
        
        <% } %>
        <div class="form_agregar-btnVolver">
            <asp:Button ID="btnVolver" runat="server" cssclass="btn btn-primary" Text="Volver atras" OnClick="btnVolver_Click"   />
        </div>
        
    </div>
</asp:Content>

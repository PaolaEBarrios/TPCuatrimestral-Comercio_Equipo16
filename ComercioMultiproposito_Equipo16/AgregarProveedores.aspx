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
            <asp:Label ID="lblProveedores" cssclass="form-label" runat="server" Text=" Nombre del proveedor: " for="txtNombreProveedores"></asp:Label>
            <asp:TextBox cssclass="form-control" placeholder="Nombre de el Proveedor" ID="txtNombreProveedores" runat="server"></asp:TextBox>
            <asp:Label ID="Productos" runat="server" Text="Apellidos: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido del proveedor" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lbldni" runat="server" Text="Dni/Cuil/CUIT:"></asp:Label>
            <asp:TextBox ID="txtDni" runat="server" placeholder="Ingrese DNI/CUIT O CUIL" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono/Celular: "></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" placeholder="Ingrese numero de contacto" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio: "></asp:Label>
            <asp:TextBox ID="txtDomicilio" runat="server" placeholder="Ingrese el domicilio: " CssClass="form-control"></asp:TextBox>

            <div>
                <asp:Label ID="lblAsociarProductos" runat="server" Text="Asociar productos" Font-Size="20px"></asp:Label>
                
            </div>
            
            <div >
                <asp:Label Text="¿Desea asociar productos a este proveedor?" runat="server" />
                <asp:CheckBox ID="chkBoxProductos" runat="server" CssClass="" OnCheckedChanged="chkBoxProductos_CheckedChanged" AutoPostBack="true"/>
                
                <asp:CheckBoxList ID="chkBoxListProductos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chkBoxListProductos_SelectedIndexChanged" Visible="false">
                    <asp:ListItem Text="Seleccionar un producto existente" Value="1" />
                    <asp:ListItem Text="Agregar nuevo producto" Value="2"/>
                </asp:CheckBoxList>
            </div>
            



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

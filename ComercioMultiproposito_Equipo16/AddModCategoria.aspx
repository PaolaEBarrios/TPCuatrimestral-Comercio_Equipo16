<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="AddModCategoria.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.AddModCategoria" %>
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

        .h2_AddMarca
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

        .h2_ModificarMarca
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


    <div class="h2_AddMarca">
        <asp:Label ID="lblAgregarCategoria" runat="server" Text="Agregar Categoria"></asp:Label>

    </div>

    <div class="h2_ModificarMarca">
        <asp:Label ID="lblModificarCategoria" runat="server" Text="Modificar Categoria: "></asp:Label>
    </div>

    <div class="form_agregar">

        
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
        <div class="form_agregar-txtNombre">
            <asp:Label ID="lblCategoria" cssclass="form-label" runat="server" Text=" Categoria: " for="txtNombreCategoria"></asp:Label>
            <asp:TextBox cssclass="form-control" placeholder="Nombre de la categoria " ID="txtNombreCategoria" runat="server"></asp:TextBox>
        </div>

        <div class="form_agregar-btn">
            <asp:Button ID="btnAgregarCategoria" cssclass="btn btn-primary" runat="server" Text="Añadir nueva categoria " Onclick="btnAgregarCategoria_Click"/>
        </div>
        
        <div class="form_agregar-btnModificar">
            <asp:Button ID="btnModificarCategoria" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificarCategoria_Click" />
        </div>
        
      
        <div class="form_agregar-btnVolver">
            <asp:Button ID="btnVolver" runat="server" cssclass="btn btn-primary" Text="Volver atras" OnClick="btnVolver_Click"   />
        </div>
        
    </div>

</asp:Content>

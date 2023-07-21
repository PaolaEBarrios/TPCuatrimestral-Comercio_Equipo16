<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>

        .Contenedor
        {
            display:flex;
            flex-direction:column;
            align-items:center;
            justify-content:center;

        }

    </style>

    <script>
            function soloNumeros(event) {
              var tecla = event.which || event.keyCode;
              if (tecla < 48 || tecla > 57) {
                event.preventDefault();
              }
            }
    </script>


    <div class="Contenedor">
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>

        <div>
            <asp:Label ID="lblAgregar" runat="server" Text="AGREGAR NUEVO PRODUCTO"></asp:Label>
            <asp:Label Text="MODIFICAR PRODUCTO: " runat="server" ID="lblModificar" />
        </div>

        <div class="formulario_productos">


            <asp:Label ID="lblCodigo" runat="server" Text="Codigo: " for="txtCodigo"></asp:Label>
            <asp:TextBox runat="server" ID="txtCodigo" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        
            <asp:Label runat="server" Text="Producto: " for="txtProducto"></asp:Label>
            <asp:TextBox runat="server" ID="txtProducto" MaxLength="50" CssClass="form-control"></asp:TextBox>
        
            <asp:Label ID="lblMarca" runat="server" Text="Marca: "></asp:Label>
            <asp:DropDownList ID="ddListMarca" CssClass="btn-group" runat="server"></asp:DropDownList>
        
            <asp:Label ID="lblCategoria" runat="server" Text="Categoria: "></asp:Label>
            <asp:DropDownList ID="ddListCategoria" CssClass="btn-group" runat="server"></asp:DropDownList>
        
            <asp:Label runat="server" ID="lblPrecio" Text="Precio" For="txtPrecio"></asp:Label>
            <asp:TextBox runat="server" ID="txtPrecio" MaxLength="6" CssClass="form-control"></asp:TextBox>
        
            <asp:Label ID="lblGanancia" runat="server" Text="Ganancia: % " for="txtGanancia"></asp:Label>
            <asp:TextBox ID="txtGanancia" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="3" CssClass="form-control"></asp:TextBox>
        
            <asp:Label ID="lblStock" runat="server" Text="Stock: " for="txtStock"></asp:Label>
            <asp:TextBox ID="txtStock" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="5" cssclass="form-control"></asp:TextBox>

            <asp:Label ID="lblStockMin" runat="server" Text="Stock Minimo: " for="txtStockMin"></asp:Label>
            <asp:TextBox ID="txtStockMin" runat="server" onKeypress="return soloNumeros(event)" MaxLength="4" CssClass="form-control"></asp:TextBox>
        
            <asp:Label Text="Descripcion: " runat="server" />
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" CssClass="btn btn-primary"  OnClick="btnAgregar_Click"/>
        </div>
        <div>
            <asp:Button Text="Modificar Producto" ID="btnModificar" runat="server" CssClass="btn btn-primary" OnClick="btnModificar_Click"/>
        </div>
        <div>
            <asp:Button ID="btnVolver" runat="server" Text="Volver a la pagina anterior" OnClick="btnVolver_Click" CssClass="btn btn-info"/>
        </div>
    </div>

    
</asp:Content>

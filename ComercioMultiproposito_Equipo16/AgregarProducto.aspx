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
        <div class="formulario_productos">
       <%-- public int Codigo { get; set; }
        public string NombreProducto { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Ganancia { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }--%>

            <asp:Label ID="lblCodigo" runat="server" Text="Codigo: " for="txtCodigo"></asp:Label>
            <asp:TextBox runat="server" ID="txtCodigo" ReadOnly="true"></asp:TextBox>
        
            <asp:Label runat="server" Text="Producto: " for="txtProducto"></asp:Label>
            <asp:TextBox runat="server" ID="txtProducto" MaxLength="50"></asp:TextBox>
        
            <asp:Label ID="lblMarca" runat="server" Text="Marca: "></asp:Label>
            <asp:DropDownList ID="ddListMarca" runat="server"></asp:DropDownList>
        
            <asp:Label ID="lblCategoria" runat="server" Text="Categoria: "></asp:Label>
            <asp:DropDownList ID="ddListCategoria" runat="server"></asp:DropDownList>
        
            <asp:Label runat="server" ID="lblPrecio" Text="Precio" For="txtPrecio"></asp:Label>
            <asp:TextBox runat="server" ID="txtPrecio" MaxLength="6"></asp:TextBox>
        
            <asp:Label ID="lblGanancia" runat="server" Text="Ganancia: % " for="txtGanancia"></asp:Label>
            <asp:TextBox ID="txtGanancia" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="3"></asp:TextBox>
        
            <asp:Label ID="lblStock" runat="server" Text="Stock: " for="txtStock"></asp:Label>
            <asp:TextBox ID="txtStock" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="5" ></asp:TextBox>

            <asp:Label ID="lblStockMin" runat="server" Text="Stock Minimo: " for="txtStockMin"></asp:Label>
            <asp:TextBox ID="txtStockMin" runat="server" onKeypress="return soloNumeros(event)" MaxLength="4"></asp:TextBox>
        
            <asp:Label Text="Descripcion: " runat="server" />
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto"  OnClick="btnAgregar_Click"/>
        </div>
        <div>
            <asp:Button Text="Modificar Producto" ID="btnModificar" runat="server" OnClick="btnModificar_Click"/>
        </div>
        <div>
            <asp:Button ID="btnVolver" runat="server" Text="Volver a la pagina anterior" OnClick="btnVolver_Click" />
        </div>
    </div>

    
</asp:Content>

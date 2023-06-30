<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.AgregarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>

        .Contenedor
        {
            display:flex;
        }

    </style>


    <div class="Contenedor">

       <%-- public int Codigo { get; set; }
        public string NombreProducto { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Ganancia { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }--%>

        
        <p>HACER EL AGREGADO DE TODOS LOS ATRIBUTOS DE PRODUCTOS INCLUYENDO MARCAS Y CATEGORIAS(DROP DOWN LIST)</p>

        <asp:Label runat="server" Text="Label"></asp:Label>
        <asp:TextBox runat="server"></asp:TextBox>
        <asp:Label runat="server" Text="Label"></asp:Label>
        <asp:TextBox runat="server"></asp:TextBox>
        <asp:Label runat="server" Text="Label"></asp:Label>
        <asp:TextBox runat="server"></asp:TextBox>


    </div>


</asp:Content>

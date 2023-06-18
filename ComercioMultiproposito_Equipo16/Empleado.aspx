<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="display: flex; padding:20px; justify-content:end">

        <div style="margin:10px">
            <asp:LinkButton ID="lbtnPerfil" runat="server">Perfil</asp:LinkButton>
        </div>
        <div style="margin:10px;">
            <asp:LinkButton ID="lbtnConfiguracion" runat="server">Configuracion</asp:LinkButton>
        </div>
        <div></div>
    </div>


    <h1 style="justify-content:center; display:flex;">Bienvenido</h1>


    <div class="row row-cols-1 row-cols-md-3 g-4" style="">
        <div class="col" style="padding-left:30px">
            <div class="card" >
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Compras</h5>
                    <p class="card-text">Acceder a la admninistracion de compras, compras de productos a proveedores...etc</p>
                </div>
                <div class="botonboton" style="padding:10px">
                    <asp:Button ID="btnCompra" runat="server" Text="Abrir" cssclass="btn btn-primary"/>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card" >
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Ventas</h5>
                    <p class="card-text">Acceder a la administracion de ventas, ventas a clientes, facturas... etc</p>
                </div>
                 <div class="botonboton" style="padding:10px">
                    <asp:Button ID="btnVentas" runat="server" Text="Abrir" cssclass="btn btn-primary"/>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Proveedores</h5>
                    <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Marcas</h5>
                    <p class="card-text">Administrar las  marcas </p>
                </div>
            </div>
        </div>

        <div class="col">
            <div class="card">
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Categorias</h5>
                    <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="card">
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Clientes</h5>
                    <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                </div>
            </div>
        </div>

    </div>





</asp:Content>

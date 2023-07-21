<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Empleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <style>

        .botonboton
        {
            display:inline-block;
            
            padding-right:10px;
            padding-bottom:10px;
            margin:10px;
            
        }

        .botonboton:hover
        {
           
        }

        .contenedor
        {
             display: flex;
                flex-wrap: wrap; 
                justify-content: center; 
                margin: 0 auto; 
        }

    </style>

    <div style="display: flex; padding:20px; justify-content:end">

        <div style="margin:10px">
            <asp:LinkButton ID="lbtnPerfil" runat="server" Visible="false">Perfil</asp:LinkButton>
        </div>
        <div style="margin:10px;">
            <asp:LinkButton ID="lbtnConfiguracion" runat="server" Visible="false">Configuracion</asp:LinkButton>
        </div>
        
    </div>


    <div class="contenedor">

            <div class="botonboton" >
                    <asp:Button ID="btnCompra" runat="server" Text="Administrar compras" cssclass="btn btn-info" OnClick="btnCompra_Click" style="width:300px;height:100px; display:flex;align-items:center;text-align:center;justify-content:center; font-size:20px;font-weight:bold; font-family:Arial "/>
            </div>


              <div class="botonboton" >
                    <asp:Button ID="btnClientes" runat="server" Text="Administrar clientes" cssclass="btn btn-info" OnClick="btnClientes_Click" style="width:300px;height:100px; display:flex;align-items:center;text-align:center;justify-content:center; font-size:20px;font-weight:bold; font-family:Arial;"/>
                </div>

                

            <div class="botonboton" >
                    <asp:Button ID="btnProveedores" runat="server" Text="Administrar proveedores" cssclass="btn btn-info" OnClick="btnProveedores_Click" style="width:300px;height:100px; display:flex;align-items:center;text-align:center;justify-content:center; font-size:20px;font-weight:bold; font-family:Arial "/>
             </div>
  
           

            <div class="botonboton">
                    <asp:Button ID="btnMarcas" runat="server" Text="Administrar marcas" cssclass="btn btn-info" OnClick="btnMarcas_Click" style="width:300px;height:100px; display:flex;align-items:center;text-align:center;justify-content:center; font-size:20px;font-weight:bold; font-family:Arial "/>
                </div>



            <div class="botonboton">
                    <asp:Button ID="btnCategoria" runat="server" Text="Administrar categorias" cssclass="btn btn-info" OnClick="btnCategoria_Click" style="width:300px;height:100px; display:flex;align-items:center;text-align:center;justify-content:center; font-size:20px;font-weight:bold; font-family:Arial "/>
            </div>

                
            <div class="botonboton" >
                    <asp:Button ID="btnProductos" runat="server" Text="Adminstrar productos" cssclass="btn btn-info" OnClick="btnProductos_Click" style="width:300px;height:100px; display:flex;align-items:center;text-align:center;justify-content:center; font-size:20px;font-weight:bold; font-family:Arial "/>
           </div>
           <div class="botonboton">
                    <asp:Button ID="btnVentas" runat="server" Text="Administrar ventas" cssclass="btn btn-info" OnClick="btnVentas_Click" style="width:300px;height:100px; display:flex;align-items:center;text-align:center;justify-content:center; font-size:20px;font-weight:bold; font-family:Arial "/>
           </div>
    </div>
        
            
        


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="row">
     <div class="col">
        <asp:GridView ID="dgvMarcas" runat="server" CssClass="table table-dark table-bordered" AutoGenerateColumns="false" >

            <Columns>

                <asp:BoundField  HeaderText="Codigo" DataField="Codigo"/>
                <asp:BoundField HeaderText="Marca" DataField="NombreMarca"/>
            </Columns>

        </asp:GridView>
     </div>
   </div>
    
    

</asp:Content>

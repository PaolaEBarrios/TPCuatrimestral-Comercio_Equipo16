<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="ClienteDetalles.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.ClienteDetalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
    </div>

   <div class="row">
            <div class="col">
                <asp:GridView ID="dgvClienteDetalle" OnRowCommand="dgvClienteDetalle_RowCommand"  DataKeyNames="id" runat="server" CssClass="table table-dark " AutoGenerateColumns="false">

                    <Columns>
                        <asp:BoundField HeaderText="id" DataField="Codigo" Visible="false" />
                        <asp:BoundField HeaderText="Dni" DataField="Dni" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                        <asp:BoundField HeaderText="Domicilio" DataField="Contacto" />
                        <asp:BoundField HeaderText="Cp" DataField="Contacto"/>
                        <asp:BoundField HeaderText="Telefono" DataField="Contacto"  />
                        <asp:BoundField HeaderText="Email" DataField="Contacto"/>
                        <asp:ButtonField CommandName="Modificar" Text="Modificar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                        <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Button" ItemStyle-CssClass="estiloBTNdgv" />
                       
                   
                   </Columns>

                </asp:GridView>
                <div>
                    <asp:Button Text="Volver" CssClass="btn btn-primary" runat="server" id="btnVolver" OnClick="btnVolver_Click"/>
                </div>
            </div>
        </div>
</asp:Content>

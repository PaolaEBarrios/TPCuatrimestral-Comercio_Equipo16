<%@ Page Title="" Language="C#" MasterPageFile="~/NuestraMaster.Master" AutoEventWireup="true" CodeBehind="AgregarProveedores.aspx.cs" Inherits="ComercioMultiproposito_Equipo16.AgregarProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .form_agregar {
            display: flex;
            flex-direction:inherit;
            justify-content: center;
            align-items: center;
        }

        .h2_AddProveedores {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 20px;
        }

        .form_agregar-txtNombre {
            width: 350px;
            padding: 20px;
        }

        .form_agregar-btn {
            padding: 20px;
        }

        .h2_ModificarProveedores {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 20px;
        }

        .form_agregar-btnModificar {
            padding: 10px;
        }

        .form_agregar-txtTelefono
        {

        }


        .formulario_productos
        {
            display:flex;
            flex-direction:column;
            width:400px;
            align-content:center;
            justify-content:center;
            align-items:end;
        }

        .formulario_productos_mas
        {

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

    <div class="h2_AddProveedores">
        <asp:Label ID="lblAgregarProveedores" runat="server" Text="Agregar Proveedores" style="font-size:30px;font-family:Arial;"></asp:Label>

    </div>

    <div class="h2_ModificarProveedores">
        <asp:Label ID="lblModificar" runat="server" Text="Modificar Proveedores: "></asp:Label>
    </div>

    <div class="form_agregar">


        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label>
        



        <div class="form_agregar-txtNombre">

            <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox>
            <asp:Label ID="lblProveedores" CssClass="form-label" runat="server" Text=" Nombre del proveedor: " for="txtNombreProveedores"></asp:Label>
            <asp:TextBox CssClass="form-control" placeholder="Nombre de el Proveedor" ID="txtNombreProveedores" runat="server"></asp:TextBox>
            <asp:Label ID="lblEmail" runat="server" Text="Correo electronico: "></asp:Label>

            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email del proveedor" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lbldni" runat="server" Text="Dni/Cuil/CUIT:"></asp:Label>
            <asp:TextBox ID="txtDni" runat="server" placeholder="Ingrese DNI/CUIT O CUIL" MaxLength="10" CssClass="form-control" ></asp:TextBox>


        </div>

        <div class="form_agregar-txtTelefono">
            <asp:Label ID="lblTelefono" runat="server" Text="Telefono/Celular: "></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" placeholder="Ingrese numero de contacto" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio: "></asp:Label>
            <asp:TextBox ID="txtDomicilio" runat="server" placeholder="Ingrese el domicilio: " CssClass="form-control"></asp:TextBox>

            <div>
                <asp:Label ID="lblAsociarProductos" runat="server" Text="Asociar productos" Font-Size="20px"></asp:Label>

            </div>

            <div>
                    <asp:Label Text="¿Desea asociar productos a este proveedor?" runat="server" />
                    <asp:CheckBox ID="chkBoxProductos" runat="server" CssClass="" OnCheckedChanged="chkBoxProductos_CheckedChanged" AutoPostBack="true" />

            </div>
                <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-info" Text="Agregar nuevo producto" Visible="false" OnClick="btnNuevo_Click"  />
                <asp:Button ID="btnExiste" runat="server" CssClass="btn btn-info" Text="Seleccionar producto existente" Visible="false" OnClick="btnExiste_Click"/>
          </div>


        <%  if (Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.ADMIN)
            {

        %>
        <div class="form_agregar-btn">
            <asp:Button ID="btnAgregarProveedores" CssClass="btn btn-info" runat="server" Text="Añadir nuevo Proveedor" OnClick="btnAgregarProveedores_Click" />
        </div>

        <div class="form_agregar-btnModificar">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-info" OnClick="btnModificar_Click" />
        </div>

        <% } %>
        <div class="form_agregar-btnVolver">
            <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-info" Text="Volver atras" OnClick="btnVolver_Click" />
        </div>

    </div>

    <div class="formulario_productos">

        <div class="formulario_productos_mas">
                <asp:Label ID="lblCodigo" runat="server" Text="Codigo: " for="txtCodigo" Visible="false"></asp:Label>
                <asp:TextBox runat="server" ID="txtCodigo" ReadOnly="true" CssClass="form-control" Visible="false"></asp:TextBox>

                <asp:Label runat="server" id="lblnombreproducto" Text="Producto: " for="txtProducto" Visible="false"></asp:Label>
                <asp:TextBox runat="server" ID="txtProducto" MaxLength="50" CssClass="form-control" Visible="false"></asp:TextBox>

                <asp:Label ID="lblMarca" runat="server" Text="Marca: " Visible="false"></asp:Label>
                <asp:DropDownList ID="ddListMarca" CssClass="btn-group" runat="server" Visible="false"></asp:DropDownList>

                <asp:Label ID="lblCategoria" runat="server" Text="Categoria: " Visible="false"></asp:Label>
                <asp:DropDownList ID="ddListCategoria" CssClass="btn-group" runat="server" Visible="false"></asp:DropDownList>

        </div>
        <div class="formulario_productos_mas">
                <asp:Label runat="server" ID="lblPrecio" Text="Precio" For="txtPrecio" Visible="false"></asp:Label>
            <asp:TextBox runat="server" ID="txtPrecio" MaxLength="6" CssClass="form-control" Visible="false"></asp:TextBox>

            <asp:Label ID="lblGanancia" runat="server" Text="Ganancia: % " for="txtGanancia" Visible="false"></asp:Label>
            <asp:TextBox ID="txtGanancia" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="3" CssClass="form-control" Visible="false"></asp:TextBox>

            <asp:Label ID="lblStock" runat="server" Text="Stock: " for="txtStock" Visible="false"></asp:Label>
            <asp:TextBox ID="txtStock" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="5" cssclass="form-control" Visible="false"></asp:TextBox>

            <asp:Label ID="lblStockMin" runat="server" Text="Stock Minimo: " for="txtStockMin" Visible="false"></asp:Label>
            <asp:TextBox ID="txtStockMin" runat="server" onKeypress="return soloNumeros(event)" MaxLength="4" CssClass="form-control" Visible="false"></asp:TextBox>

            <asp:Label Text="Descripcion: " ID="lblDescripcion" runat="server" Visible="false" />
            <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="100" CssClass="form-control" Visible="false"></asp:TextBox>
        </div>
            <div>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar nuevo producto" Cssclass="btn btn-info" OnClick="btnAgregar_Click" Visible="false"/>
            </div>
     </div>
    

            <div class="row">
            <div class="col">
                <asp:GridView ID="dgvProductos" OnRowCommand="dgvProductos_RowCommand"   DataKeyNames="Codigo" runat="server" CssClass="table table-dark " AutoGenerateColumns="false" Visible="false">

                    <Columns>

                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" Visible="false" />
                        <asp:BoundField HeaderText="Producto" DataField="NombreProducto" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca"/>
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio"/>

                        <asp:ButtonField CommandName="Seleccionar" Text="Seleccionar" ButtonType="Button"  />
                   
                   </Columns>

                </asp:GridView>

            </div>
        </div>

</asp:Content>

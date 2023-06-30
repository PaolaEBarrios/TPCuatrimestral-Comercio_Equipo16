Create Database Comercio_DB
Go
Use Comercio_DB
Go
CREATE TABLE Clientes (
  id INT PRIMARY KEY,
  nombre VARCHAR(100),
  direccion VARCHAR(200),
  telefono VARCHAR(20),
  correo VARCHAR(100)
)
Go
CREATE TABLE Proveedores (
  id INT PRIMARY KEY,
  nombre VARCHAR(100),
  direccion VARCHAR(200),
  telefono VARCHAR(20),
  correo VARCHAR(100)
)
Go
CREATE TABLE Marcas (
  id INT PRIMARY KEY,
  nombre VARCHAR(100)
)
Go
CREATE TABLE Categorias (
  id INT PRIMARY KEY,
  nombre VARCHAR(100)
)
Go
CREATE TABLE Productos (
  id INT PRIMARY KEY,
  nombre VARCHAR(100),
  precio DECIMAL(10, 2),
  id_marca INT,
  id_categoria INT,
  stock_actual INT,
  stock_minimo INT,
  FOREIGN KEY (id_marca) REFERENCES Marcas(id),
  FOREIGN KEY (id_categoria) REFERENCES Categorias(id)
)

ALTER TABLE productos
ADD descripcion varchar(100)

alter table productos
add ganancia int

Go
CREATE TABLE Proveedores_Productos ( --RELACIONAR PRODUCTOS Y PROVEEDORES--
  id_proveedor INT,
  id_producto INT,
  PRIMARY KEY (id_proveedor, id_producto),
  FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id),
  FOREIGN KEY (id_producto) REFERENCES Productos(id)
)
Go
CREATE TABLE Compras (
  id INT PRIMARY KEY,
  id_proveedor INT,
  fecha DATE,
  FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id)
)
Go
CREATE TABLE Detalles_Compra (
  id_compra INT,
  id_producto INT,
  cantidad INT,
  precio DECIMAL(10, 2),
  FOREIGN KEY (id_compra) REFERENCES Compras(id),
  FOREIGN KEY (id_producto) REFERENCES Productos(id)
)
Go
CREATE TABLE Ventas (
  id INT PRIMARY KEY,
  id_cliente INT,
  fecha DATE,
  FOREIGN KEY (id_cliente) REFERENCES Clientes(id)
)
Go
CREATE TABLE Detalles_Venta ( --Productos Vendidos---
  id_venta INT,
  id_producto INT,
  cantidad INT,
  precio DECIMAL(10, 2),
  FOREIGN KEY (id_venta) REFERENCES Ventas(id),
  FOREIGN KEY (id_producto) REFERENCES Productos(id)
)
Go
CREATE TABLE Usuarios (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Usuario]  VARCHAR (50) NULL,
    [Pass]     VARCHAR (50) NULL,
    [TipoUser] INT          NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
)

insert into Usuarios VALUES ('admin', 'admin', 2)
Select id, usuario, pass, tipouser from Usuarios Where usuario = 'test' AND pass = 'test'
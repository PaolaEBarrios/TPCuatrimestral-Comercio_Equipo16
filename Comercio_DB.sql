Create Database Comercio_DB
Go
Use Comercio_DB
Go

delete from Compras 


select c.apellido as apellido,c.nombre as nombre,c.dni as dni, c.telefono as telefono, c.correo as email from Clientes as c
inner join Ventas as v on v.id_cliente=c.id
where v.id=1


select p.nombre,dv.cantidad,dv.precio,dv.total,v.fecha as fecha from Detalles_Venta as dv
inner join Ventas as v on v.id=dv.id_venta
inner join Productos as p on dv.id_producto=p.id
where dv.id_venta=1

select * from Productos


create table factura
(
	idfactura bigint identity(1,1),
	idcliente int not null foreign key  references clientes(id),
	condicion varchar(20),
	formadepago varchar(20),
	fecha date not null,
	primary key(idfactura),
)


create table detalles_factura
(
	idfactura bigint not null foreign key references factura(idfactura),
	idproducto int not null foreign key references productos(id),
	cantidad int not null check(cantidad>0),
	preciounitario money check(preciounitario>0),
	subtotal money not null,

	primary key (idfactura,idproducto)

)
select * from Ventas
Select * from Detalles_Venta



alter table compras
drop column estado
alter table compras
drop column fechafin
alter table compras
drop column totalcompra


select * from Compras
select * from Detalles_Compra

select p.nombre,dc.cantidad,dc.precio,dc.Total  from Compras as c inner join Detalles_Compra as dc on dc.id_compra=c.id inner join productos as p on p.id=dc.id_producto
where dc.


select * from proveedores

select * from Proveedores_Productos


select * from Productos

Select c.id as id, p.dni as dni, p.nombre as nombre,c.fecha as fecha, c.formaPago as formapago from Compras as c inner join Proveedores as p on p.id=c.id_proveedor

Select p.nombre as nombre,p.dni as dni,p.correo as correo,p.telefono  from Compras as c inner join Proveedores as p on p.id=c.id_proveedor where c.id=1

select * from Proveedores
select * from Proveedores_Productos
select * from Productos

insert into Compras (id,id_proveedor,fecha,formaPago,FechaFin,estado,TotalCompra)
values (1,1,'12-05-2023','Efectivo','1753-1-1','P',118000)

insert into Detalles_Compra (id_compra,id_producto,cantidad,precio,total)
values(1,1,5,600.00,3000),(1,2,5,23000,115000.00)

select * from Productos

CREATE TABLE Clientes (
  id INT PRIMARY KEY,
  nombre VARCHAR(100),
  direccion VARCHAR(200),
  telefono VARCHAR(20),
  correo VARCHAR(100)
)
Go
alter table clientes
add dni varchar(9)
go

alter table clientes 
add apellido varchar(100)
go

alter table clientes
add codigoPostal varchar(6)
go

ALTER TABLE clientes
ADD CONSTRAINT UK_DNI UNIQUE (DNI)
go

ALTER TABLE Clientes
ALTER COLUMN dni VARCHAR(11)
go

CREATE TABLE Proveedores (
  id INT PRIMARY KEY,
  nombre VARCHAR(100),
  direccion VARCHAR(200),
  telefono VARCHAR(20),
  correo VARCHAR(100)
)
Go
alter table compras 
add formaPago varchar(30) not null
go
alter table compras 
add FechaFin date
go
alter table compras
add estado char(1) not null
go

alter table compras
add TotalCompra decimal(10,2)

alter table Proveedores
Add dni varchar(11)
go

ALTER TABLE Proveedores
ADD CONSTRAINT uc_dni UNIQUE (dni)

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
go
ALTER TABLE productos
ADD descripcion varchar(100)
go
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


select * from Detalles_Compra


CREATE TABLE Compras (
  id INT PRIMARY KEY,
  id_proveedor INT,
  fecha DATE,
  FOREIGN KEY (id_proveedor) REFERENCES Proveedores(id)
)
Go

drop table Compras

CREATE TABLE Detalles_Compra (
  id_compra INT,
  id_producto INT,
  cantidad INT,
  precio DECIMAL(10, 2),
  FOREIGN KEY (id_compra) REFERENCES Compras(id),
  FOREIGN KEY (id_producto) REFERENCES Productos(id)
)
Go

alter table detalles_compra
add Total money
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


 select * from Detalles_venta
alter table detalles_venta
add total money check(total > 0)

alter table detalles_venta
alter column precio money 

CREATE TABLE Usuarios (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Usuario]  VARCHAR (50) NULL,
    [Pass]     VARCHAR (50) NULL,
    [TipoUser] INT          NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO
Create table tipo_persona
(
	id tinyint primary key check(id = 1 or id = 2),
	tipo char(1)  null check(tipo = 'J' or tipo = 'F')
)

INSERT INTO tipo_persona VALUES(1,'J'),(2,'F')

insert into Usuarios VALUES ('admin', 'admin', 2)
Select id, usuario, pass, tipouser from Usuarios Where usuario = 'test' AND pass = 'test'

SELECT * FROM tipo_persona


-- Insertar valores en la tabla Clientes
INSERT INTO Clientes (id, nombre, direccion, telefono, correo, dni, apellido, codigoPostal)
VALUES
  (1, 'Cliente 1', 'Dirección 1', '123456789', 'cliente1@example.com', '123456789', 'Apellido 1', '123456'),
  (2, 'Cliente 2', 'Dirección 2', '987654321', 'cliente2@example.com', '987654321', 'Apellido 2', '654321');

-- Insertar valores en la tabla Proveedores
INSERT INTO Proveedores (id, nombre, direccion, telefono, correo)
VALUES
  (1, 'Proveedor 1', 'Dirección 1', '111111111', 'proveedor1@example.com'),
  (2, 'Proveedor 2', 'Dirección 2', '222222222', 'proveedor2@example.com');

-- Insertar valores en la tabla Marcas
INSERT INTO Marcas (id, nombre)
VALUES
  (1, 'Marca 1'),
  (2, 'Marca 2');

-- Insertar valores en la tabla Categorias
INSERT INTO Categorias (id, nombre)
VALUES
  (1, 'Categoría 1'),
  (2, 'Categoría 2');

-- Insertar valores en la tabla Productos
INSERT INTO Productos (id, nombre, precio, id_marca, id_categoria, stock_actual, stock_minimo, descripcion, ganancia)
VALUES
  (1, 'Producto 1', 10.99, 1, 1, 100, 20, 'Descripción 1', 5),
  (2, 'Producto 2', 19.99, 2, 2, 50, 10, 'Descripción 2', 8);

-- Insertar valores en la tabla Proveedores_Productos
INSERT INTO Proveedores_Productos (id_proveedor, id_producto)
VALUES
  (1, 1),
  (2, 2);

-- Insertar valores en la tabla Compras
INSERT INTO Compras (id, id_proveedor, fecha)
VALUES
  (1, 1, '2023-07-01'),
  (2, 2, '2023-07-02');

-- Insertar valores en la tabla Detalles_Compra
INSERT INTO Detalles_Compra (id_compra, id_producto, cantidad, precio)
VALUES
  (1, 1, 5, 10.99),
  (2, 2, 3, 19.99);

-- Insertar valores en la tabla Ventas
INSERT INTO Ventas (id, id_cliente, fecha)
VALUES
  (1, 1, '2023-07-03'),
  (2, 2, '2023-07-04');

-- Insertar valores en la tabla Detalles_Venta
INSERT INTO Detalles_Venta (id_venta, id_producto, cantidad, precio)
VALUES
  (1, 1, 2, 10.99),
  (2, 2, 1, 19.99);

-- Insertar valores en la tabla Usuarios
INSERT INTO Usuarios (Usuario, Pass, TipoUser)
VALUES
  ('Usuario1', '123456', 1),
  ('admin', 'admin', 2);
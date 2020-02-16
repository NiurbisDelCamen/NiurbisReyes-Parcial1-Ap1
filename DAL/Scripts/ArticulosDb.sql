create database ArticulosDb
use ArticulosDb

create table ArticulosDb
(
ProductoId int primary key identity,
Descripcion varchar(30),
Existencia int,
Costo int,
ValorInventario int
);
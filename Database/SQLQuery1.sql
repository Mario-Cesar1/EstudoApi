use master
go
create database dbAlmoxarifado
go
use dbAlmoxarifado
go
create table Produto(
   id int identity(1,1) primary key,
   nome  varchar(100) not null,
   estoque int null default(0),
   photourl varchar(255) null
)
go
Create table Categoria
(
	id int identity(1,1) primary key,
	descricao varchar(100) not null
)
go
create table Departamento
(
	id int identity(1,1) primary key,
	descricao varchar(100) not null,
	situacao bit null
)
go
alter table Produto add codigoCategoria int FOREIGN KEY REFERENCES Categoria(id)  
go
Insert Produto (nome, estoque,photourl) values ('HP Turbo',20,null)
go
Insert Produto (nome, estoque,photourl) values ('MONITOR GOT',40,null)

go
Insert Produto (nome, estoque,photourl) values ('mouse',100,null)
go
Insert Categoria (descricao) values ('Comida')
go
Insert Categoria (descricao) values ('Eletronicos')
go
Insert Categoria (descricao) values ('Bebidas')
go
Insert Departamento (descricao, situacao) values ('Financeiro', 1)
go
Insert Departamento (descricao, situacao) values ('Administrativo', 1)
go
Insert Departamento (descricao, situacao) values ('Segurança', 0)
go
Select * from Produto
Select * from Categoria
select * from Departamento
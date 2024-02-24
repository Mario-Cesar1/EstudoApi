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
Insert Produto (nome, estoque,photourl) values ('HP Turbo',20,null)

go
Insert Produto (nome, estoque,photourl) values ('MONITOR GOT',40,null)

go
Insert Produto (nome, estoque,photourl) values ('mouse',100,null)

go
Select * from Produto
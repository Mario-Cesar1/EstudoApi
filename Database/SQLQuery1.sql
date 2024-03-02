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
create table Funcionario
(
	id int identity(1,1) primary key,
	nome varchar(100) not null,
	cargo varchar(100) not null,
	DataNascimento date not null,
	salario float not null,
	endereco varchar(200),
	cidade varchar(100),
	UF varchar(2)
)
go
alter table Produto add codigoCategoria int FOREIGN KEY REFERENCES Categoria(id)  
go
go
Insert Categoria (descricao) values ('Comida')
go
Insert Categoria (descricao) values ('Eletronicos')
go
Insert Categoria (descricao) values ('Bebidas')
go
Insert Produto (nome, estoque,photourl, codigoCategoria) values ('HP Turbo',20,null,2)
go
Insert Produto (nome, estoque,photourl, codigoCategoria) values ('MONITOR GOT',40,null,2)
go
Insert Produto (nome, estoque,photourl, codigoCategoria) values ('mouse',100,null,2)
Insert Departamento (descricao, situacao) values ('Financeiro', 1)
go
Insert Departamento (descricao, situacao) values ('Administrativo', 1)
go
Insert Departamento (descricao, situacao) values ('Segurança', 0)
go
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Pedro', 'Garoto de Programa', '01/02/2000', 2000.96, 'Rua da gota serena, 200', 'Cidade da gota', 'GT')
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Cleiton', 'Administrador Financeiro', '05/10/2000', 2000.96, 'Rua da gota serena, 210', 'Cidade da gota', 'GT')
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Mário', 'Gerente', '09/11/2000', 2000.96, 'Rua da gota serena, 220', 'Cidade da gota', 'GT')
go
select * from Funcionario
Select * from Produto
Select * from Categoria
select * from Departamento
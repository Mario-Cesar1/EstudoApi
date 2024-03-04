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
	DataNascimento varchar(10) not null,
	salario float not null,
	endereco varchar(200),
	cidade varchar(100),
	UF varchar(2)
)
go
create table CategoriaMotivo
(
	CAMID int identity(1,1) primary key,
	CAMDESCRICAO varchar(100) not null
)
go
create table MotivoSaida
(
	MOTID int identity(1,1) primary key,
	MOTDESCRICAO varchar(100) not null,
	CAMID int,
	Constraint FK_CAMID foreign key (CAMID) references CategoriaMotivo(CAMID)
)
go
create table Requisicao
(
	REQID int identity(1,1) primary key,
	REQDATA varchar(10) not null,
	REQOBSERVACAO varchar(250) null
)
go
alter table Produto add codigoCategoria int FOREIGN KEY REFERENCES Categoria(id)  
go
Insert Categoria (descricao) values ('Comida')
Insert Categoria (descricao) values ('Eletronicos')
Insert Categoria (descricao) values ('Bebidas')
go
Insert Produto (nome, estoque,photourl, codigoCategoria) values ('HP Turbo',20,null,2)
Insert Produto (nome, estoque,photourl, codigoCategoria) values ('MONITOR GOT',40,null,2)
Insert Produto (nome, estoque,photourl, codigoCategoria) values ('mouse',100,null,2)
go
Insert Departamento (descricao, situacao) values ('Financeiro', 1)
Insert Departamento (descricao, situacao) values ('Administrativo', 1)
Insert Departamento (descricao, situacao) values ('Segurança', 0)
go
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Pedro', 'Garoto de Programa', '01/02/2000', 2000.96, 'Rua da gota serena, 200', 'Cidade da gota', 'GT')
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Cleiton', 'Administrador Financeiro', '05/10/2000', 2000.96, 'Rua da gota serena, 210', 'Cidade da gota', 'GT')
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Mário', 'Gerente', '09/11/2000', 2000.96, 'Rua da gota serena, 220', 'Cidade da gota', 'GT')
go
insert CategoriaMotivo(CAMDESCRICAO) values ('Administração')
insert CategoriaMotivo(CAMDESCRICAO) values ('Dúvida')
insert CategoriaMotivo(CAMDESCRICAO) values ('TI')
go
insert MotivoSaida(MOTDESCRICAO, CAMID) values ('Solicitar Revisão', 1)
insert MotivoSaida(MOTDESCRICAO, CAMID) values ('Dúvida sobre a requisição', 2)
insert MotivoSaida(MOTDESCRICAO, CAMID) values ('Falha técnica', 3)
go
insert Requisicao(REQDATA, REQOBSERVACAO) values ('04/03/2024', null)
insert Requisicao(REQDATA, REQOBSERVACAO) values ('25/11/2022', 'Falha encontrada no computador do setor 2')
insert Requisicao(REQDATA, REQOBSERVACAO) values ('15/09/2023', 'Computadores novos requisitados para setor 4')
select * from Funcionario
Select * from Produto
Select * from Categoria
select * from Departamento
select * from CategoriaMotivo
select * from MotivoSaida
select * from Requisicao
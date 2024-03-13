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
create table Cargo
(
	id int identity(1,1) primary key,
	Descricao varchar(100) not null,
	Localizacao varchar(100) null
)
go
create table Funcionario
(
	id int identity(1,1) primary key,
	nome varchar(100) not null,
	cargo int not null,
	DataNascimento varchar(10) not null,
	salario float not null,
	endereco varchar(200),
	cidade varchar(100),
	UF varchar(2),

	constraint FK_cargoCodigo foreign key (cargo) references Cargo(id)
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
Create table Requisicao
(
  Codigo  int identity(1,1) primary key,
  DataRequisicao datetime null
)
go
Create table itensRequisicao
(
   IteID int primary key identity(1,1),
   CodigoRequisicao int not null,
   CodigoProduto int not null,
   Preco float not null default(0),
   Quantidade int not null default(0),
   CONSTRAINT FK_itenRequisicao FOREIGN KEY (CodigoRequisicao)
    REFERENCES Requisicao(Codigo),
	CONSTRAINT FK_ItenProdutoReq FOREIGN KEY (CodigoProduto)
    REFERENCES Produto(id)
)
go
create table FuncionarioProduto
(
	codFuncionario int not null,
	codProduto int not null,
	Primary key(codFuncionario, codProduto),

	Constraint FK_codFuncionario foreign key (codFuncionario) references Funcionario(id),
	Constraint FK_codProduto foreign key (codProduto) references Produto(id)
)
go
create table Escolaridade
(
	id int identity(1,1) primary key,
	descricao varchar(100) not null,
)
alter table Funcionario add idEscolaridade int
alter table funcionario add Constraint FK_idEscolaridade foreign key (idEscolaridade) references Escolaridade(id)
go
create table Entrada
(
	id int identity(1,1) primary key,
	dataEntrada datetime not null
)
go
create table itensEntrada
(
	id int identity(1,1) primary key,
	codigoEntrada int not null,
	codigoProdutoEntrada int not null,
	quantidadeEntrada int not null,

	Constraint FK_CodifoProdutoEntrada foreign key (codigoProdutoEntrada) references produto(id),
	  Constraint FK_CodigoEntrada foreign key (codigoEntrada) references Entrada(id)
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
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Pedro', 1, '01/02/2000', 2000.96, 'Rua da gota serena, 200', 'Cidade da gota', 'GT')
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Cleiton', 2, '05/10/2000', 2000.96, 'Rua da gota serena, 210', 'Cidade da gota', 'GT')
Insert Funcionario(nome, cargo, DataNascimento, salario, endereco, cidade, UF) values ('Mário', 3, '09/11/2000', 2000.96, 'Rua da gota serena, 220', 'Cidade da gota', 'GT')
go
insert CategoriaMotivo(CAMDESCRICAO) values ('Uso Diário')
insert CategoriaMotivo(CAMDESCRICAO) values ('Substituição')
insert CategoriaMotivo(CAMDESCRICAO) values ('TI')
go
insert MotivoSaida(MOTDESCRICAO, CAMID) values ('Solicitar Revisão', 1)
insert MotivoSaida(MOTDESCRICAO, CAMID) values ('Dúvida sobre a requisição', 2)
insert MotivoSaida(MOTDESCRICAO, CAMID) values ('Falha técnica', 3)
go
insert cargo (Descricao, Localizacao) values ('Garoto de Programa', 'Laboratório 1')
insert cargo (Descricao, Localizacao) values ('Administrador financeiro', 'Prédio 10')
insert cargo (Descricao, Localizacao) values ('Gerente', 'Prédio 11')
go
insert Escolaridade (descricao) values ('Ensino Superior')
insert Escolaridade (descricao) values ('Ensino Médio')
insert Escolaridade (descricao) values ('Mestrado')
insert Escolaridade (descricao) values ('Doutorado')
insert Escolaridade (descricao) values ('Graduado')
insert Escolaridade (descricao) values ('Pós-Graduado')
--selects
select * from Funcionario
Select * from Produto
Select * from Categoria
select * from Departamento
select * from CategoriaMotivo
select * from MotivoSaida
select * from Requisicao
select * from ItensRequisicao
select * from Entrada
select * from itensEntrada
select * from Escolaridade
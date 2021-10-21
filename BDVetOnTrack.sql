create database BDVetOnTrack;
use BDVetOnTrack;
CREATE TABLE dbo.dado(
id_dado int identity (1,1) primary key not null,
nome VARCHAR(50) NOT NULL,
data_nascimento varchar(8) not null,
);

---------------------------------------------------------
CREATE TABLE dbo.endereco(
id_endereco int identity(1,1) primary Key not null,
rua VARCHAR(50) NOT NULL,
numero int not null,
bairro varchar(50),
estado varchar(2) not null,
cidade varchar(50) not null,
cep varchar(8) not null,
complemento varchar(50) not null
);
----------------------------------------------------------
CREATE TABLE dbo.acesso(
id_acesso int identity(1,1) primary Key not null,
email VARCHAR(50) NOT NULL,
senha VARCHAR(50) NOT NULL,
nivel int not null
);
---------------------------------------------------------
create table dbo.pessoa(
id_pessoa int identity(1,1) primary Key not null,
id_endereco_fk int,
id_acesso_fk int,
id_dado_fk int,
cpf varchar(11) not null,
telefone_1 varchar(15) not null,
telefone_2 varchar(15)null, ------------------- opcional

constraint fk_id_dado_pessoa foreign key (id_dado_fk) references dbo.dado (id_dado),
constraint fk_id_endereco_pessoa foreign key (id_endereco_fk) references dbo.endereco (id_endereco),
constraint fk_id_acesso_pessoa foreign key (id_acesso_fk) references dbo.acesso (id_acesso)
ON DELETE CASCADE
ON UPDATE CASCADE
);
----------------------------------------------------------
create table dbo.cliente(
id_cliente int identity(1,1) primary Key not null,
id_pessoa_fk int,
constraint fk_id_pessoa_cliente foreign key (id_pessoa_fk) references dbo.pessoa (id_pessoa)
ON DELETE CASCADE
ON UPDATE CASCADE
);
----------------------------------------------------------
create table dbo.funcionario(
id_funcionario int identity(1,1) primary Key not null,
id_pessoa_fk int,
salario money not null,
cargo varchar(100) not null,
crmv varchar(50) null, --------------------------- opcional
constraint fk_id_pessoa_func foreign key (id_pessoa_fk) references dbo.pessoa (id_pessoa)
ON DELETE CASCADE
ON UPDATE CASCADE
);
----------------------------------------------------------
create table dbo.pet(
id_pet int identity(1,1) primary Key not null,
id_dado_fk int,
id_cliente int,
sexo char not null,
peso varchar(10) not null,
altura varchar(10) not null,
comprimento varchar(10) not null,
especie varchar(100) not null,
raca varchar(100) not null,
reg_animal varchar(100) null,--------------------------- opcional
observacao varchar(MAX) null,--------------------------- opcional
constraint fk_id_dado_pet foreign key (id_dado_fk) references dbo.dado (id_dado)
ON DELETE CASCADE
ON UPDATE CASCADE
);

------------------------------------------------------------

create table dbo.agenda(
id_agenda int identity(1,1) primary key not null,
id_servico int not null,
id_funcionario int not null,
id_cliente int not null,
id_pet int not null,
hr_agenda datetime not null,
);

----------------------------------------------------------

create table dbo.servico(
id_servico int identity(1,1) primary key not null,
nome varchar(50) not null,
valor money,
descricao varchar(100), 
);
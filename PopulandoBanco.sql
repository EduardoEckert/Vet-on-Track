use BDVetOnTrack;

--Cliente

insert into dbo.dado (nome, data_nascimento) values('Carlos','30101993'); 
insert into dbo.dado (nome, data_nascimento) values('Daniela','29101979'); 
insert into dbo.dado (nome, data_nascimento) values('Marcelo','28102001'); 
insert into dbo.dado (nome, data_nascimento) values('Diego','27102006'); 
insert into dbo.dado (nome, data_nascimento) values('Eduarda','26101990'); 
insert into dbo.dado (nome, data_nascimento) values('Arthur','25102003'); 
insert into dbo.dado (nome, data_nascimento) values('Rafaela','24102000'); 
insert into dbo.dado (nome, data_nascimento) values('Vitoria','23101980'); 
insert into dbo.dado (nome, data_nascimento) values('Sandro','22101999'); 
insert into dbo.dado (nome, data_nascimento) values('Julio','22101999');

select * from dbo.dado;

insert into dbo.acesso (email, senha, nivel) values('carlos@admin.com','12345678',2); 
insert into dbo.acesso (email, senha, nivel) values('daniela@daniela.com','12345678',0); 
insert into dbo.acesso (email, senha, nivel) values('marcelo@marcelo.com','12345678',0); 
insert into dbo.acesso (email, senha, nivel) values('diego@diego.com','12345678',0); 
insert into dbo.acesso (email, senha, nivel) values('eduarda@eduarda.com','12345678',0); 
insert into dbo.acesso (email, senha, nivel) values('arthur@arthur.com','12345678',0); 
insert into dbo.acesso (email, senha, nivel) values('rafaela@rafaela.com','12345678',0); 
insert into dbo.acesso (email, senha, nivel) values('vitoria@vitoria.com','12345678',0); 
insert into dbo.acesso (email, senha, nivel) values('sandro@sandro.com','12345678',0); 
insert into dbo.acesso (email, senha, nivel) values('julio@julio.com','12345678',0); 

select * from dbo.acesso;

insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Sao Sebastiao', 100, 'Água Verde','SC','Blumenau','89065090','Casa');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Vinte', 101,'Badenfurt','SC','Blumenau','89065050','Apartamento');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Parana', 102,'Boa Vista','SC','Blumenau','89065520','Apartamento');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Castro Alves', 103,'Bom Retiro','SC','Blumenau','89065120','Apartamento');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Projetada', 104,'Centro','SC','Blumenau','82065020','Casa');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Minas Gerais', 105,'Garcia','SC','Blumenau','89065220','Apartamento');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Santos Dumont', 106,'Itoupavazinha','SC','Blumenau','89965020','Apartamento');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Espirito Santo', 108,'Fortaleza','SC','Blumenau','89066020','Apartamento');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Belo Horizonte', 109,'Tribess','SC','Blumenau','89065220','Casa');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua José Bonifácio', 110,'Valparaíso','SC','Blumenau','89865020','Apartamento');
select * from dbo.endereco;

insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(1,1,1, '11663654789','47992331564');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(2,2,2, '22365447895', '47992331155');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(3,3,3, '65789456310', '47991331564');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(4,4,4, '54631204561', '47992331764');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(5,5,5, '49786435210', '47996331564');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(6,6,6, '12036457891', '47992631564');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(7,7,7, '11023456798', '47992351564');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(8,8,8, '22031456798', '47992315648');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(9,9,9, '55563210221', '47984331564');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(10,10,10, '22036541062', '47984335641');

select * from dbo.pessoa;

insert into dbo.cliente (id_pessoa_fk) values(1);
insert into dbo.cliente (id_pessoa_fk) values(2);
insert into dbo.cliente (id_pessoa_fk) values(3);
insert into dbo.cliente (id_pessoa_fk) values(4);
insert into dbo.cliente (id_pessoa_fk) values(5);
insert into dbo.cliente (id_pessoa_fk) values(6);
insert into dbo.cliente (id_pessoa_fk) values(7);
insert into dbo.cliente (id_pessoa_fk) values(8);
insert into dbo.cliente (id_pessoa_fk) values(9);
insert into dbo.cliente (id_pessoa_fk) values(10);
select * from dbo.cliente;

--Funcionario
-----------------------------------------------------------------------

insert into dbo.dado (nome, data_nascimento) values('Danilo','10102020'); 
insert into dbo.dado (nome, data_nascimento) values('Thiago','11102020'); 
insert into dbo.dado (nome, data_nascimento) values('Matheus','12102020'); 
insert into dbo.dado (nome, data_nascimento) values('João','13102020'); 

select * from dbo.dado;

-----Acesso Funcionarios
insert into dbo.acesso (email, senha, nivel) values('danilo@funcionario.com','12345678','1'); 
insert into dbo.acesso (email, senha, nivel) values('thiago@funcionario.com','12345678','1'); 
insert into dbo.acesso (email, senha, nivel) values('matheus@funcionario.com','12345678','1'); 
insert into dbo.acesso (email, senha, nivel) values('joao@funcionario.com','12345678','1'); 

select * from dbo.acesso;

insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Treze De Maio', 500, 'Nova Esperança','SC','Blumenau','89665090','Apartamento');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua 8', 501,'Salto','SC','Blumenau','89065050','Apartamento');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Da Paz', 502,'Salto do Norte','SC','Blumenau','89065620','Casa');
insert into dbo.endereco (rua, numero, bairro, estado, cidade, cep, complemento) values('Rua Rio De Janeiro', 503,'Salto Weissbach','SC','Blumenau','86065120','Apartamento');

select * from dbo.endereco;

insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(11,11,11, '44563214521','47992335604');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(12,12,12, '46552154444', '47985331155');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(13,13,13, '98445545455', '47991355564');
insert into dbo.pessoa (id_endereco_fk, id_acesso_fk, id_dado_fk, cpf, telefone_1) values(14,14,14, '10223621444', '47992331787');

select * from dbo.pessoa;

insert into dbo.funcionario (id_pessoa_fk, salario, cargo, crmv) values(11, 5000, 'veterinário', 012301);
insert into dbo.funcionario (id_pessoa_fk, salario, cargo, crmv) values(12, 10000, 'estagiário', 520012);
insert into dbo.funcionario (id_pessoa_fk, salario, cargo, crmv) values(13, 3000, 'anestesista', 605110);
insert into dbo.funcionario (id_pessoa_fk, salario, cargo, crmv) values(14, 1000, 'recuros humanos', 545651);

select * from dbo.funcionario;


--Pet
------------------------------------------------------------------

insert into dbo.dado (nome, data_nascimento) values('Rex','10092020');
insert into dbo.dado (nome, data_nascimento) values('Baby','10082020');
insert into dbo.dado (nome, data_nascimento) values('Bob ','10072020');
insert into dbo.dado (nome, data_nascimento) values('Drake ','10062020');
insert into dbo.dado (nome, data_nascimento) values('Dudu','10052020');
insert into dbo.dado (nome, data_nascimento) values('Daisy ','10042020');
insert into dbo.dado (nome, data_nascimento) values('Cácau ','10032020');
insert into dbo.dado (nome, data_nascimento) values('Lobinho ','10022020');
insert into dbo.dado (nome, data_nascimento) values('Boneca ','10012020');
insert into dbo.dado (nome, data_nascimento) values('Abelhinha ','19102020'); 
select * from dbo.dado;


insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(15,1, 'M', '15', '40', '20', 'Canis familiaris','Beagle', '100200', 'Dócil'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(16,2, 'M', '16', '41', '24', 'Canis familiaris','Boxer', '100201', 'Bravo'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(17,2, 'M', '17', '42', '28', 'Canis familiaris','Buldogue francês', '100203', 'Dócil'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(18,4, 'M', '18', '43', '32', 'Canis familiaris','Dachshund', '100204', 'Bravo'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(19,5, 'M', '19', '44', '24', 'Canis familiaris','Husky siberiano', '100205', 'Dócil'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(20,5, 'F', '20', '45', '20', 'Canis familiaris','Maltês', '100206', 'Dócil'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(21,7, 'F', '21', '46', '32', 'Canis familiaris','Mastim tibetano', '100207', 'Bravo'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(22,8, 'M', '22', '47', '20', 'Canis familiaris','Poodle', '100208', 'Dócil'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(23,5, 'F', '23', '48', '28', 'Canis familiaris','Pug', '100209', 'Bravo'); 
insert into dbo.pet (id_dado_fk, id_cliente, sexo, peso, altura, comprimento, especie, raca, reg_animal, observacao) values(24,10, 'F', '24', '49', '32', 'Canis familiaris','Pastor alemão', '100210', 'Dócil'); 
select * from dbo.pet;

--Sevicos 
-------------------------------------------------------------------

insert into dbo.servico (nome, valor, descricao) values ('Vacinação', 200, 'Valor varia de vacina para vacina');
insert into dbo.servico (nome, valor, descricao) values ('Exame de sangue', 20, 'Exames rotineiros');
insert into dbo.servico (nome, valor, descricao) values ('Exame de ultrassom', 65, 'Identificar tumores');
insert into dbo.servico (nome, valor, descricao) values ('Exame de raio-x', 65, 'Identificar fraturas nos ossos dos animais');
insert into dbo.servico (nome, valor, descricao) values ('Cirurgia', 800, 'Remoção de tumores etc');
insert into dbo.servico (nome, valor, descricao) values ('Internação', 350, 'Valor referente a diária');
insert into dbo.servico (nome, valor, descricao) values ('Remoção de tártaro', 290, 'Servico odontologico');
insert into dbo.servico (nome, valor, descricao) values ('Castração', 500, 'Castração do pet');

--Agenda
-------------------------------------------------------------------
use BDVetOnTrack;
----Func 1
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (1, 1, 1, 1,'20211020 10:00:00 AM');
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (8, 1, 2, 2,'20211020 11:00:00 AM');
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (4, 1, 3, 3,'20211020 09:00:00 AM');
----Func 2
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (7, 2, 1, 12,'20211020 10:00:00 AM');
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (1, 2, 2, 18,'20211020 11:00:00 AM');
----Func 3																										
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (1, 3, 1, 26,'20211020 10:00:00 AM');
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (3, 3, 3, 22,'20211020 11:00:00 AM');
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (2, 3, 3, 25,'20211020 09:00:00 AM');
----Func 4																										
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (8, 4, 1, 23,'20211020 10:00:00 AM');
insert into dbo.agenda (id_servico, id_funcionario, id_cliente, id_pet, hr_agenda) values (6, 4, 2, 24,'20211020 11:00:00 AM');

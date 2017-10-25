drop database if exists URNAteste;
create database URNAteste;
use URNAteste;

create table Eleitor_candidato
(
	ID int auto_increment,
    nome varchar(50),
    CPF  int(11),
    turma_cargo varchar(30),
    candidato varchar(30),
    primary key(ID)
);

create table Eleicao
(
	ID_eleicao int auto_increment,
    ID_eleitor int,
    eleicao_data date,
    vota boolean,
    primary key(ID_eleicao)
);

create table Eleitor_eleicao
(
	ID_eleitor int,
    ID_eleicao int,
    chapa int,
    foto int,
    primary key(ID_eleitor, ID_eleicao)
);

create table admin #EXECUTAR ESTA LINHA // BANCO NAO ESTAVA CONECTADO
(
user varchar(20),
nome varchar(50),
senha varchar(30),
ID_admin int auto_increment,
primary key(ID_admin)
);


alter table Eleitor_eleicao #tabela que vai
add constraint eleitor_eleicao_eleicao foreign key (ID_eleitor) #local que vai
references Eleitor_candidato (ID); #tabela que vai 

alter table Eleicao #tabela que vai
add constraint eleit_eleic foreign key (ID_eleicao) #local que vai
references Eleicao (ID_eleicao); #tabela que vai 

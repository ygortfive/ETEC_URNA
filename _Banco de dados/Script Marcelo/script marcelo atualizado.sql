DROP DATABASE IF EXISTS URNA_BD;
CREATE DATABASE URNA_BD;

use URNA_BD;

CREATE TABLE Administrador (
id_adm INT PRIMARY KEY AUTO_INCREMENT,
nome VARCHAR(100) not null,
user VARCHAR(50) not null,
senha VARCHAR(20) not null);

CREATE TABLE Eleitor (
id_eleitor INT PRIMARY KEY AUTO_INCREMENT,
nome VARCHAR(100) not null,
cpf VARCHAR(11) not null,
turma_cargo VARCHAR(30),
candidato bool
);

CREATE TABLE Eleicao (
id_eleicao INT PRIMARY KEY AUTO_INCREMENT,
data_eleicao date,
eleicao_valida bool not null);

CREATE TABLE Candidato_Eleicao (
id_eleicao INT,
id_candidato INT,
chapa int,
foto varchar(100),

PRIMARY KEY (id_eleicao, id_candidato),
CONSTRAINT id_eleicao_fk FOREIGN KEY (id_eleicao) REFERENCES Eleicao(id_eleicao),
CONSTRAINT id_candidato_fk FOREIGN KEY (id_candidato) REFERENCES Eleitor(id_eleitor));

CREATE TABLE Eleitor_Eleicao (
id_eleicao INT,
id_eleitor INT,
votou bool,
escolha int,

PRIMARY KEY (id_eleicao, id_eleitor),
CONSTRAINT id_eleicao_fk FOREIGN KEY (id_eleicao) REFERENCES Eleicao(id_eleicao),
CONSTRAINT id_eleitor_fk FOREIGN KEY (id_eleitor) REFERENCES Eleitor(id_eleitor));

select count(id_eleitor) from eleitor;
select count(votou) from Eleitor_Eleicao;

select count(escolha)


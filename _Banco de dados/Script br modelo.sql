-- Gera��o de Modelo f�sico
-- Sql ANSI 2003 - brModelo.



CREATE TABLE ELEITOR (
ID_ELEITOR VARCHAR(50) PRIMARY KEY,
NOME VARCHAR(50),
CPF VARCHAR(50),
TURMA/CARGO VARCHAR(50),
CANDIDATO VARCHAR(50),
VOTOU VARCHAR(50)
)

CREATE TABLE ADMINISTRADOR (
ID_ADM VARCHAR(50) PRIMARY KEY,
NOME VARCHAR(50),
USER VARCHAR(50),
SENHA VARCHAR(50)
)

CREATE TABLE ELEI��O (
ID_ELEI��O VARCHAR(50) PRIMARY KEY,
DATA VARCHAR(50),
ID_ELEITOR VARCHAR(50),
FOREIGN KEY(ID_ELEITOR) REFERENCES ELEITOR (ID_ELEITOR)
)

CREATE TABLE PARTICIPA (
CHAPA VARCHAR(50),
FOTO VARCHAR(50),
VOTOS VARCHAR(50),
ID_ELEI��O VARCHAR(50),
ID_ELEITOR VARCHAR(50),
FOREIGN KEY(ID_ELEI��O) REFERENCES ELEI��O (ID_ELEI��O),
FOREIGN KEY(ID_ELEITOR) REFERENCES ELEITOR (ID_ELEITOR)
)


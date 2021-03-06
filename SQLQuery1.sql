
Select * FROM CLIENTES


CREATE TABLE FUNCIONARIOS
(
ID INT PRIMARY KEY IDENTITY,
NOME VARCHAR(60) NOT NULL,
CPF CHAR(11) UNIQUE NOT NULL,
RG VARCHAR(9) NOT NULL,
ENDERECO INT,
TELEFONE VARCHAR(15) NOT NULL,
EMAIL VARCHAR(50) NOT NULL,
SENHA VARCHAR(6) NOT NULL,
EHADMIN BIT NOT NULL,
ATIVO BIT NOT NULL
)

CREATE TABLE CLIENTES
(
ID INT PRIMARY KEY IDENTITY,
NOME VARCHAR(60) NOT NULL,
CPF CHAR(11) UNIQUE NOT NULL,
RG VARCHAR(9) NOT NULL,
TELEFONE VARCHAR(15) NOT NULL,
CELULAR VARCHAR(15) NOT NULL,
EMAIL VARCHAR(50) NOT NULL
)

CREATE TABLE PRODUTOS
(
ID INT PRIMARY KEY IDENTITY,
NOME VARCHAR(40) NOT NULL,
DESCRICAO VARCHAR (100) NOT NULL,
PRECO INT NOT NULL,
ESTOQUE INT NOT NULL
)

CREATE TABLE FORNECEDORES
(
ID INT PRIMARY KEY IDENTITY,
RAZAOSOCIAL VARCHAR(50) NOT NULL,
CNPJ CHAR(14) UNIQUE NOT NULL,
NOMECONTATO VARCHAR(50) NOT NULL,
TELEFONE VARCHAR(15) NOT NULL,
EMAIL VARCHAR(50) NOT NULL
)

CREATE TABLE ENTRADAPRODUTOS
(
ID INT PRIMARY KEY IDENTITY,
DATAENTRADA DATETIME NOT NULL,
IDFUNCIONARIO INT NOT NULL REFERENCES FUNCIONARIOS,
VALORTOTAL REAL NOT NULL
)

CREATE TABLE ENTRADAPRODUTODETALHES
(
IDPRODUTO INT NOT NULL REFERENCES PRODUTOS,
IDENTRADA INT NOT NULL REFERENCES ENTRADAPRODUTOS,
PRECO REAL NOT NULL,
QUANTIDADE INT NOT NULL
PRIMARY KEY (IDPRODUTO,IDENTRADA)
)

CREATE TABLE QUARTOS
(
ID INT PRIMARY KEY IDENTITY,
TIPO VARCHAR(60) NOT NULL,
PRECO REAL NOT NULL,
OCUPADO BIT NOT NULL
)

CREATE TABLE RESERVAS 
(
ID INT PRIMARY KEY IDENTITY,
IDQUARTO INT NOT NULL REFERENCES QUARTOS,
IDCLIENTE INT NOT NULL REFERENCES CLIENTES
)


CREATE TABLE SAIDAPRODUTOS
(
ID INT PRIMARY KEY IDENTITY,
DATASAIDA DATETIME NOT NULL,
IDFUNCIONARIO INT NOT NULL REFERENCES FUNCIONARIOS,
VALORTOTAL REAL NOT NULL
)

CREATE TABLE ENTRADAPRODUTODETALHES
(
IDPRODUTO INT NOT NULL REFERENCES PRODUTOS,
IDENTRADA INT NOT NULL REFERENCES ENTRADAPRODUTOS,
PRECO REAL NOT NULL,
QUANTIDADE INT NOT NULL
PRIMARY KEY (IDPRODUTO,IDENTRADA)
)
/*Inserindo na Tabela de Produtos*/
INSERT INTO TABELA_PRODUTOS (NOME_PRODUTO, EMBALAGEM, TAMANHO, SABOR, PRECO_DE_LISTA) 
VALUES ('Suco Natural', 'Garrafa', '600 ml', 'Laranja', 5.50)

INSERT INTO TABELA_PRODUTOS (NOME_PRODUTO, EMBALAGEM, TAMANHO, SABOR, PRECO_DE_LISTA) 
VALUES ('Refrigerante', 'PET', '2 lts', 'Coca', 13.99)


/*Inserindo na Tabela de Vendedores*/
INSERT INTO TABELA_VENDEDORES (NOME_VENDEDOR, PERCENTUAL_COMISSAO, DATA_ADMISSAO, STATUS_FERIAS, USUARIO, SENHA) 
VALUES ('Carlos Marinho', 0.1, '2013-03-25', 0, 'carlos', 123)

INSERT INTO TABELA_VENDEDORES (NOME_VENDEDOR, PERCENTUAL_COMISSAO, DATA_ADMISSAO, STATUS_FERIAS, USUARIO, SENHA) 
VALUES ('Maria de Lurdes', 0.11, '2014-01-01', 0, 'maria', 123)

INSERT INTO TABELA_VENDEDORES (NOME_VENDEDOR, PERCENTUAL_COMISSAO, DATA_ADMISSAO, STATUS_FERIAS, USUARIO, SENHA) 
VALUES ('Ana Brand�o', 0.07, '2019-01-12', 0, 'ana', 123)


/*Inserindo na Tabela de Clientes*/
USE CONTROLE_VENDAS
INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA) 
VALUES ('Carlos Alberto', '27398909830', 'Rua A', 'A', 'Vila', 'S�o Paulo', 'SP', '00111000', '30/03/1993', 'M', 20000, 1000)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA) 
VALUES ('Marco Alves', '27398909070', 'Rua B', 'A', 'Vila', 'S�o Paulo', 'SP', '00132100', '21/03/1993', 'M', 10000, 8000)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Ver�nica Alves', '27398903330', 'Rua C', 'A', 'Vila', 'S�o Paulo', 'SP', '00123000', '12/03/1993', 'F', 10.000, 4.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Marina Magalh�es', '27398943830', 'Rua D', 'A', 'Vila', 'S�o Paulo', 'SP', '00112000', '11/03/1993', 'F', 10.000, 5.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Roberto Magalh�es', '45398909830', 'Rua E', 'A', 'Vila', 'S�o Paulo', 'SP', '00143000', '21/03/1993', 'M', 20.000, 6.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Pedro Alberto', '27393219830', 'Rua F', 'A', 'Vila', 'S�o Paulo', 'SP', '00231000', '22/03/1993', 'M', 40.000, 1.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Fernanda Alves', '27390009830', 'Rua G', 'A', 'Vila', 'S�o Paulo', 'SP', '02121000', '24/03/1993', 'F', 50.000, 1.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('M�nica Maria', '27398009830', 'Rua H', 'A', 'Vila', 'S�o Paulo', 'SP', '02341000', '30/11/1993', 'F', 20.000, 5.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Valdir Justino', '12090909830', 'Rua I', 'A', 'Vila', 'S�o Paulo', 'SP', '00165500', '30/11/1993', 'M', 20.000, 1.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Jorge Vitor', '27378909830', 'Rua J', 'A', 'Vila', 'S�o Paulo', 'SP', '00123000', '30/12/1993', 'M', 23.000, 3.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Maria Alves', '27398809830', 'Rua K', 'A', 'Vila', 'S�o Paulo', 'SP', '00143000', '30/04/1993', 'F', 27.000, 3.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Jo�o Abreu', '27397879830', 'Rua L', 'A', 'Vila', 'S�o Paulo', 'SP', '00232000', '30/03/1997', 'M', 29.000, 9.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Jo�o Alves', '27398909340', 'Rua M', 'A', 'Vila', 'S�o Paulo', 'SP', '00100000', '30/03/1998', 'M', 20.000, 1.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Jos� Adalberto', '27948909830', 'Rua N', 'A', 'Vila', 'S�o Paulo', 'SP', '07811000', '30/03/1990', 'M', 20.000, 1.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Maria Fel�cia', '27398909809', 'Rua O', 'A', 'Vila', 'S�o Paulo', 'SP', '00119000', '30/03/1990', 'F', 21.000, 2.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Marcus dos Anjos', '87398909830', 'Rua P', 'A', 'Vila', 'S�o Paulo', 'SP', '00111090', '30/03/1990', 'M', 22.000, 2.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Maria Albuquerque', '27398923561', 'Rua Q', 'A', 'Vila', 'S�o Paulo', 'SP', '06111000', '30/03/1991', 'F', 20.000, 6.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Carlos Farias', '84586873645', 'Rua A', 'R', 'Vila', 'S�o Paulo', 'SP', '00112200', '30/03/1992', 'M', 34.000, 1.000, 1)

INSERT INTO TABELA_CLIENTES (NOME, CPF, ENDERECO_1, ENDERECO_2, BAIRRO, CIDADE, UF, CEP, DATA_NASCIMENTO, SEXO, LIMITE_CREDITO, VOLUME_COMPRA, PRIMEIRA_COMPRA) 
VALUES ('Jorge Alberto', '48730292394', 'Rua A', 'S', 'Vila', 'S�o Paulo', 'SP', '00111320', '30/03/1993', 'M', 56.000, 2.000, 1)

-- 1) Cria o banco e seleciona
DROP database IF exists locadora_veiculos;
CREATE DATABASE IF NOT EXISTS locadora_veiculos
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_unicode_ci;
USE locadora_veiculos;

-- 2) Tabela UF
CREATE TABLE uf (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nome VARCHAR(100) NOT NULL,
  sigla VARCHAR(2) NOT NULL,
  created_at DATE,
  updated_at DATE
) ENGINE=InnoDB;

-- 3) Tabela Cidade
CREATE TABLE cidade (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nome VARCHAR(100) NOT NULL,
  uf_id INT NOT NULL,
  created_at DATE,
  updated_at DATE,
  INDEX (uf_id),
  CONSTRAINT fk_cidade_uf FOREIGN KEY (uf_id) REFERENCES uf(id)
) ENGINE=InnoDB;

-- 4) Tabela Endereco
CREATE TABLE endereco (
  id INT AUTO_INCREMENT PRIMARY KEY,
  logradouro VARCHAR(255) NOT NULL,
  numero INT NOT NULL,
  complemento VARCHAR(255),
  bairro VARCHAR(100),
  cep VARCHAR(20),
  cidade_id INT NOT NULL,
  created_at DATE,
  updated_at DATE,
  INDEX (cidade_id),
  CONSTRAINT fk_endereco_cidade FOREIGN KEY (cidade_id) REFERENCES cidade(id)
) ENGINE=InnoDB;

-- 5) Tabela Pessoa
CREATE TABLE pessoa (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nome VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  cpf VARCHAR(14) NOT NULL,
  senha VARCHAR(255) NOT NULL,
  data_nascimento DATE,
  status TINYINT(1) DEFAULT 1,
  endereco_id INT NOT NULL,
  created_at DATE,
  updated_at DATE,
  UNIQUE KEY uq_pessoa_email (email),
  UNIQUE KEY uq_pessoa_cpf (cpf),
  INDEX (endereco_id),
  CONSTRAINT fk_pessoa_endereco FOREIGN KEY (endereco_id) REFERENCES endereco(id)
) ENGINE=InnoDB;

-- 6) Tabela Veiculo
CREATE TABLE veiculo (
  id INT AUTO_INCREMENT PRIMARY KEY,
  marca VARCHAR(100) NOT NULL,
  descricao TEXT,
  modelo VARCHAR(100),
  situacao VARCHAR(50),
  placa VARCHAR(20) NOT NULL,
  renavam VARCHAR(20) NOT NULL,
  ano_fabricacao DATE,
  tipo VARCHAR(50),
  chassi VARCHAR(50) NOT NULL,
  capacidade_passageiros INT,
  potencia VARCHAR(50),
  cor VARCHAR(50),
  valor_diaria DECIMAL(10,2),
  created_at DATE,
  updated_at DATE,
  UNIQUE KEY uq_veiculo_placa  (placa),
  UNIQUE KEY uq_veiculo_renavam(renavam),
  UNIQUE KEY uq_veiculo_chassi (chassi)
) ENGINE=InnoDB;

-- 7) Tabela Locacao
CREATE TABLE locacao (
  id INT AUTO_INCREMENT PRIMARY KEY,
  valor DECIMAL(10,2) NOT NULL,
  forma_pagamento VARCHAR(50),
  data_pedido DATE,
  status VARCHAR(50),
  numero VARCHAR(100) NOT NULL,
  pessoa_id INT NOT NULL,
  created_at DATE,
  updated_at DATE,
  UNIQUE KEY uq_locacao_numero (numero),
  INDEX (pessoa_id),
  CONSTRAINT fk_locacao_pessoa FOREIGN KEY (pessoa_id) REFERENCES pessoa(id)
) ENGINE=InnoDB;

-- 8) Tabela Locacao_Veiculo
CREATE TABLE locacao_veiculo (
  id INT AUTO_INCREMENT PRIMARY KEY,
  locacao_id INT NOT NULL,
  veiculo_id INT NOT NULL,
  data_inicio DATE,
  data_fim DATE,
  valor DECIMAL(10,2),
  created_at DATE,
  updated_at DATE,
  INDEX (locacao_id),
  INDEX (veiculo_id),
  CONSTRAINT fk_locacao_veiculo_locacao FOREIGN KEY (locacao_id) REFERENCES locacao(id),
  CONSTRAINT fk_locacao_veiculo_veiculo FOREIGN KEY (veiculo_id) REFERENCES veiculo(id)
) ENGINE=InnoDB;

-- 9) Tabela Seguro
CREATE TABLE seguro (
  id INT AUTO_INCREMENT PRIMARY KEY,
  descricao VARCHAR(255),
  seguradora VARCHAR(100),
  tipo VARCHAR(50),
  valor_seguro DECIMAL(10,2),
  valor_franquia DECIMAL(10,2),
  created_at DATE,
  updated_at DATE
) ENGINE=InnoDB;

-- 10) Tabela Seguro_Locacao_Veiculo (associação N-N)
CREATE TABLE seguro_locacao_veiculo (
  id INT AUTO_INCREMENT PRIMARY KEY,
  seguro_id INT NOT NULL,
  locacao_veiculo_id INT NOT NULL,
  created_at DATE,
  updated_at DATE,
  INDEX (seguro_id),
  INDEX (locacao_veiculo_id),
  CONSTRAINT fk_slv_seguro    FOREIGN KEY (seguro_id)             REFERENCES seguro(id),
  CONSTRAINT fk_slv_locacao   FOREIGN KEY (locacao_veiculo_id)    REFERENCES locacao_veiculo(id)
) ENGINE=InnoDB;

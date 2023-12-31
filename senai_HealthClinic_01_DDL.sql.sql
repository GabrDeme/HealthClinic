CREATE DATABASE [HealthClinic_Manha];
USE [HealthClinic_Manha];


CREATE TABLE TipoUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(20) NOT NULL
)

CREATE TABLE Descricao
(
	IdDescricao INT PRIMARY KEY IDENTITY,
	DescricaoConsulta VARCHAR(256) NOT NULL
)

CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(50) NOT NULL,
	CNPJ VARCHAR(14) NOT NULL UNIQUE,
	Endereco VARCHAR(50) NOT NULL,
	HoraAbertura TIME(0) NOT NULL,
	HoraFechamento TIME(0) NOT NULL,
	RazaoSocial BIT DEFAULT 1
)

CREATE TABLE EspecialidadeMedico
(
	IdEspecialidadeMedico INT PRIMARY KEY IDENTITY,
	Especialidade VARCHAR(20) NOT NULL UNIQUE
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Senha VARCHAR(25) NOT NULL
)

CREATE TABLE Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEspecialidadeMedico INT FOREIGN KEY REFERENCES EspecialidadeMedico(IdEspecialidadeMedico) NOT NULL,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
	CRM VARCHAR(6) NOT NULL UNIQUE
)

CREATE TABLE Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	DataNascimento DATETIME NOT NULL,
	Telefone VARCHAR(14) NOT NULL,
	RG VARCHAR(9) NOT NULL UNIQUE,
	CPF VARCHAR(11) NOT NULL UNIQUE,
	Endereco VARCHAR(50) NOT NULL
)

CREATE TABLE Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
	IdDescricao INT FOREIGN KEY REFERENCES Descricao(IdDescricao) NOT NULL,
	DataAgendamento DATETIME NOT NULL,
	HoraConsulta TIME(0) NOT NULL
)

CREATE TABLE Comentario
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdConsulta INT FOREIGN KEY REFERENCES Consulta(IdConsulta) NOT NULL,
	Descricao VARCHAR(50) NOT NULL,
)

CREATE TABLE Prontuario
(
	IdProntuario INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
	IdConsulta INT FOREIGN KEY REFERENCES Consulta(IdConsulta) NOT NULL,
	Descricao VARCHAR(50) NOT NULL
)


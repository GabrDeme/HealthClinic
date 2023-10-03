

INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES 
	('Administrador'),
	('Médico'),
	('Paciente')

INSERT INTO Descricao(DescricaoConsulta)
VALUES 
	('a'),
	('b'),
	('c'),
	('d')

INSERT INTO Clinica(NomeFantasia,CNPJ,Endereco,HoraAbertura,HoraFechamento,RazaoSocial)
VALUES ('Clínica quatro corações','12345678900987','Av. Pereira Barreto, 400 - Baeta Neves','06:00:00','00:00:00','1')

INSERT INTO EspecialidadeMedico(Especialidade)
VALUES 
	('Cardiologista'),
	('Neurologista'),
	('Psiquiatra'),
	('Dermatologista'),
	('Oftalmologista')

INSERT INTO Usuario(IdTipoUsuario,Nome,Email,Senha)
VALUES 
	(1,'Maya','Maya@gmail.com','1234'),
	(3,'Lily','Lily@gmail.com','0987'),
	(2,'Téo','Téo@gmail.com','6543'),
	(2,'Vera','Vera@gmail.com','2340'),
	(3,'Jeremias','Jeremias@gmail.com','9213'),
	(3,'Heitor','Heitor@gmail.com','9463'),
	(2,'Helena','Helena@gmail.com','0213')

INSERT INTO Medico(IdUsuario,IdEspecialidadeMedico,IdClinica,CRM)
VALUES 
	(3,1,1,'098765'),
	(4,5,1,'123456'),
	(7,4,1,'043166')

INSERT INTO Paciente(IdUsuario,DataNascimento,Telefone,RG,CPF,Endereco)
VALUES 
	(2,2000-11-01,'1112345678','032426164','87901347431','R. Moreira de Godói, 226 - Ipiranga'),
	(6,1957-10-08,'1109876543','234672198','98013284138','R. Boa Vista, 825 - Boa Vista'),
	(5,1997-04-22,'1159382513','895420931','43289017843','R. Guatemala, 19 - Jardim Canhema')

INSERT INTO Consulta(IdMedico,IdPaciente,IdDescricao,DataAgendamento,HoraConsulta)
VALUES 
	(3,2,4,2023-08-16,'09:00:00'),
	(2,1,2,2023-11-20,'11:30:00'),
	(1,3,3,2023-01-12,'08:00:00')

INSERT INTO Comentario(IdConsulta,Descricao)
VALUES 
	(3,'Consulta Excelente, muito atencioso'),
	(1,'Não gostei, péssimo atendimento'),
	(2,'Mediano')

INSERT INTO Prontuario(IdClinica,IdConsulta,Descricao)
VALUES 
	(1,2,'Paciente está com febre'),
	(1,3,'Paciente está com diabetes'),
	(1,1,'Paciente tem 1 semana de vida')

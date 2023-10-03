
SELECT * FROM TipoUsuario
SELECT * FROM Descricao
SELECT * FROM Clinica
SELECT * FROM Usuario
SELECT * FROM Medico
SELECT * FROM Paciente
SELECT * FROM Consulta
SELECT * FROM Comentario
SELECT * FROM Prontuario


-- Id Consulta
-- Data da Consulta
-- Horario da Consulta
-- Nome da Clinica
-- Nome do Paciente
-- Nome do Medico
-- Especialidade do Medico
-- CRM
-- Prontuário ou Descricao
-- FeedBack(Comentario da consulta)

SELECT 
	Consulta.IdConsulta,
	CONCAT(Consulta.DataAgendamento,', ',Consulta.HoraConsulta) as DataConsulta,
	Clinica.NomeFantasia as NomeClinica,
	PacienteUsuario.Nome as Paciente,
	MedicoUsuario.Nome as Medico,
	EspecialidadeMedico.Especialidade,
	Medico.CRM,
	Prontuario.Descricao as Prontuario,
	Comentario.Descricao as Comentario
FROM 
	Consulta 
JOIN
	Comentario ON Comentario.IdConsulta = Consulta.IdConsulta
JOIN
	Prontuario ON Prontuario.IdConsulta = Consulta.IdConsulta
JOIN
	Medico ON Consulta.IdMedico = Medico.IdMedico
JOIN 
	EspecialidadeMedico ON Medico.IdEspecialidadeMedico = EspecialidadeMedico.IdEspecialidadeMedico
JOIN
	Clinica ON Medico.Idclinica = Clinica.IdClinica
JOIN 
	Descricao ON Consulta.IdDescricao = Descricao.IdDescricao
JOIN 
	Paciente ON Consulta.IdPaciente = Paciente.IdPaciente
JOIN 
	Usuario as PacienteUsuario ON PacienteUsuario.IdUsuario = Paciente.IdUsuario
JOIN 
	Usuario as MedicoUsuario ON MedicoUsuario.IdUsuario = Medico.IdUsuario



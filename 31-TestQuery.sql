CREATE TABLE ADM_Perfil (
    PER_Id smallint PRIMARY KEY,
    PER_SIS_Id tinyint,
    PER_Nome varchar(50)
);

CREATE TABLE ADM_Sistema (
    SIS_Id tinyint PRIMARY KEY,
    SIS_Nome varchar(50),
    SIS_Link varchar(50)
);

CREATE TABLE ADM_Entidade (
    ENT_Id smallint PRIMARY KEY,
    ENT_Nome varchar(50),
    ENT_Responsavel varchar(50),
    ENT_TerminalPrefixo smallint
);

CREATE TABLE ADM_Usuario (
    USU_Id smallint PRIMARY KEY,
    USU_ENT_Id smallint,
    USU_Nome varchar(50),
    USU_Login varchar(16),
    USU_Senha varchar(100),
    USU_Bloqueado bit,
    USU_DataAcesso datetime,
    FOREIGN KEY (USU_ENT_Id) REFERENCES ADM_Entidade(ENT_Id)
);

CREATE TABLE ADM_UsuarioXPerfil (
    USP_USU_Id smallint,
    USP_PER_Id smallint,
    PRIMARY KEY (USP_USU_Id, USP_PER_Id),
    FOREIGN KEY (USP_USU_Id) REFERENCES ADM_Usuario(USU_Id),
    FOREIGN KEY (USP_PER_Id) REFERENCES ADM_Perfil(PER_Id)
);

ALTER TABLE ADM_Perfil
ADD FOREIGN KEY (PER_SIS_Id) REFERENCES ADM_Sistema(SIS_Id);

INSERT INTO ADM_Sistema (SIS_Id, SIS_Nome, SIS_Link) VALUES
(1, 'Sistema A', 'http://sistema-a.com'),
(2, 'Sistema B', 'http://sistema-b.com');

INSERT INTO ADM_Perfil (PER_Id, PER_SIS_Id, PER_Nome) VALUES
(10, 1, 'Administrador'),
(20, 2, 'Usuário Comum');

INSERT INTO ADM_Entidade (ENT_Id, ENT_Nome, ENT_Responsavel, ENT_TerminalPrefixo) VALUES
(100, 'Entidade X', 'Responsável X', 123),
(200, 'Entidade Y', 'Responsável Y', 456);

INSERT INTO ADM_Usuario (USU_Id, USU_ENT_Id, USU_Nome, USU_Login, USU_Senha, USU_Bloqueado, USU_DataAcesso) VALUES
(1000, 100, 'João Silva', 'joaos', 'senha123', 0, '2024-04-04 08:30:00'),
(2000, 200, 'Maria Oliveira', 'maria', 'senha321', 1, '2024-04-04 09:00:00');

INSERT INTO ADM_UsuarioXPerfil (USP_USU_Id, USP_PER_Id) VALUES
(1000, 10),
(2000, 20);

--Resposta da 3.1
SELECT
    *
FROM
    ADM_Usuario U
LEFT JOIN ADM_UsuarioXPerfil UP ON U.USU_Id = UP.USP_USU_Id
LEFT JOIN ADM_Perfil P ON UP.USP_PER_Id = P.PER_Id
LEFT JOIN ADM_Entidade E ON U.USU_ENT_Id = E.ENT_Id
LEFT JOIN ADM_Sistema S ON P.PER_SIS_Id = S.SIS_Id;

CREATE TABLE [dbo].[Employe] (
    [IdE] INT NOT NULL PRIMARY KEY IDENTITY,

    [NomE]           NCHAR (10) NOT NULL,
    [PrenomE]        NCHAR (10) NOT NULL,
    [Mot_PassE]      NCHAR (10) NOT NULL,
    [Date_Naissance] DATE       NOT NULL,
    [Sexe]           NCHAR (10) NOT NULL,
    [Date_DbTravail] DATE       NOT NULL,
    [Statut]         NCHAR (50) NOT NULL,
    [Poste]          NCHAR (50) NOT NULL,
    [Salaire]        NCHAR (10) NOT NULL,
    [Email]          NCHAR (50) NOT NULL,
    [Tel]            INT        NOT NULL,
);


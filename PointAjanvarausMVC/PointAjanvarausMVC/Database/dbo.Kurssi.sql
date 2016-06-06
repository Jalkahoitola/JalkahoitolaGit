CREATE TABLE [dbo].[Kurssi] (
    [Kurssi_ID]           INT           IDENTITY (1, 1) NOT NULL,
    [Etunimi]             NVARCHAR (20) NULL,
    [Sukunimi]            NVARCHAR (20) NULL,
    [Kurssinimike]        NVARCHAR (20) NULL,
    [Opintopisteet]       NVARCHAR (20) NULL,
    [Kurssin aloitus pvm] DATETIME      NULL,
    [Kurssin lopetus pvm] DATETIME      NULL,
    [Rekisterointi_ID]    INT           NULL,
    [Hoitaja_ID]          INT           NULL,
    PRIMARY KEY CLUSTERED ([Kurssi_ID] ASC),
    CONSTRAINT [FK_Kurssi_ToTable] FOREIGN KEY ([Hoitaja_ID]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID]),
	CONSTRAINT [FK_Kurssi_ToTable_1] FOREIGN KEY ([Rekisterointi_ID]) REFERENCES [dbo].[Rekisterointi] ([Rekisterointi_ID]),
);


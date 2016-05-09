CREATE TABLE [dbo].[Hoitajat] (
    [Hoitaja_ID]    INT           IDENTITY (1, 1) NOT NULL,
	[Tunnus] NVARCHAR (6) NULL,
    [Etunimi]       NVARCHAR (20) NULL,
	[Toinen nimi] NVARCHAR (20) NULL,
    [Sukunimi]      NVARCHAR (20) NULL,
    [Henkilotunnus] NVARCHAR (20) NULL,
    [Osoite_id]     INT           NULL,
    [Puhelin_id]    INT           NULL,
	[Kurssi_id]    INT           NULL,
	[Aloituspvm] DATE NULL,
	[Valmistumispvm] DATE NULL,
	[Keskeytyspvm] DATE NULL,
    [Huomio]        INT           NULL,
    PRIMARY KEY CLUSTERED ([Hoitaja_ID] ASC), 
    CONSTRAINT [FK_Hoitajat_ToTable] FOREIGN KEY ([Osoite_id]) REFERENCES [Osoite]([Osoite_ID]), 
    CONSTRAINT [FK_Hoitajat_ToTable_1] FOREIGN KEY ([Puhelin_id]) REFERENCES [Puhelin]([Puhelin_ID]), 
    CONSTRAINT [FK_Hoitajat_ToTable_2] FOREIGN KEY ([Huomio]) REFERENCES [Huomiot]([Huomio_ID])
	);
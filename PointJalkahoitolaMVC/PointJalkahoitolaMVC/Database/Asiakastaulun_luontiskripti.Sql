CREATE TABLE [dbo].[Asiakkaat] (
    [Asiakas_ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Etunimi]       NVARCHAR (20) NULL,
    [Sukunimi]      NVARCHAR (20) NULL,
    [Henkilotunnus] NVARCHAR (20) NULL,
    [Osoite_id]     INT           NULL,
    [Puhelin_id]    INT           NULL,
    [Huomio]        INT           NULL,
    PRIMARY KEY CLUSTERED ([Asiakas_ID] ASC), 
    CONSTRAINT [FK_Asiakkaat_ToTable] FOREIGN KEY ([Osoite_id]) REFERENCES [Osoite]([Osoite_ID]), 
    CONSTRAINT [FK_Asiakkaat_ToTable_1] FOREIGN KEY ([Puhelin_id]) REFERENCES [Puhelin]([Puhelin_ID]), 
    CONSTRAINT [FK_Asiakkaat_ToTable_2] FOREIGN KEY ([Huomio]) REFERENCES [Huomiot]([Huomio_ID])
	);
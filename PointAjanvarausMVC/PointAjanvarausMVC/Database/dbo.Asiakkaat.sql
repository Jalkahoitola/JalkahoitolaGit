﻿CREATE TABLE [dbo].[Asiakkaat] (
    [Asiakas_ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Etunimi]          NVARCHAR (20)  NULL,
    [Sukunimi]         NVARCHAR (20)  NULL,
    [Katuosoite]       NVARCHAR (100) NULL,
    [Postinumero]      VARCHAR (5)    NULL,
    [Postitoimipaikka] VARCHAR (50)   NULL,
    [Henkilotunnus]    NVARCHAR (20)  NULL,
    [Puhelinnumero_1]  NVARCHAR (20)  NULL,
    [Huomiot]          NVARCHAR (200) NULL,
    [Osoite_id]        INT            NULL,
    [Huomio_id]        INT            NULL,
    [Puhelin_id]       INT            NULL,
    [Hoitaja_ID]       INT            NULL,
    [Varaus_ID]        INT            NULL,
    [Palvelu_ID]       INT            NULL,
    [Asiakastunnus]    NVARCHAR (100) NULL,
	[Sahkoposti]	NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Asiakas_ID] ASC),
    CONSTRAINT [FK_Asiakkaat_ToTable] FOREIGN KEY ([Osoite_id]) REFERENCES [dbo].[Osoite] ([Osoite_ID]),
    CONSTRAINT [FK_Asiakkaat_ToTable_1] FOREIGN KEY ([Puhelin_id]) REFERENCES [dbo].[Puhelin] ([Puhelin_ID]),
    CONSTRAINT [FK_Asiakkaat_ToTable_2] FOREIGN KEY ([Huomio_id]) REFERENCES [dbo].[Huomiot] ([Huomio_ID]),
    CONSTRAINT [FK_Asiakkaat_ToTable_3] FOREIGN KEY ([Hoitaja_ID]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID]),
    CONSTRAINT [FK_Asiakkaat_ToTable_4] FOREIGN KEY ([Varaus_ID]) REFERENCES [dbo].[Varaus] ([Varaus_ID]),
    CONSTRAINT [FK_Asiakkaat_ToTable_5] FOREIGN KEY ([Palvelu_ID]) REFERENCES [dbo].[Palvelut] ([Palvelu_ID])
);


CREATE TABLE [dbo].[Osoite] (
    [Osoite_ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Katuosoite]       NVARCHAR (100) NULL,
    [Postinumero]      NVARCHAR (20)  NULL,
    [Postitoimipaikka] NVARCHAR (20)  NULL,
	[Asiakas_ID]      INT           NULL,
    [Hoitaja_ID]      INT           NULL,
    [Henkilokunta_ID] INT           NULL,
	[Toimipiste_ID] INT NULL,
    [Shipper_ID]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Osoite_ID] ASC),
	CONSTRAINT [FK_Osoite_ToTable] FOREIGN KEY ([Asiakas_ID]) REFERENCES [dbo].[Asiakkaat] ([Asiakas_ID]),
	CONSTRAINT [FK_Osoite_ToTable_1] FOREIGN KEY ([Hoitaja_ID]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID]),
    CONSTRAINT [FK_Osoite_ToTable_2] FOREIGN KEY ([Henkilokunta_ID]) REFERENCES [dbo].[Henkilokunta] ([Henkilokunta_ID]),
	CONSTRAINT [FK_Osoite_ToTable_3] FOREIGN KEY ([Toimipiste_ID]) REFERENCES [dbo].[Toimipisteet] ([Toimipiste_ID]),
    CONSTRAINT [FK_Osoite_ToTable_4] FOREIGN KEY ([Shipper_ID]) REFERENCES [dbo].[Shippers] ([Shipper_ID])
);


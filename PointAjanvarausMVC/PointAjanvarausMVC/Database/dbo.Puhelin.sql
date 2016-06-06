CREATE TABLE [dbo].[Puhelin] (
    [Puhelin_ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Puhelinnumero_1] NVARCHAR (20) NULL,
    [Puhelinnumero_2] NVARCHAR (20) NULL,
    [Puhelinnumero_3] NVARCHAR (20) NULL,
    [Asiakas_ID]      INT           NULL,
    [Hoitaja_ID]      INT           NULL,
    [Henkilokunta_ID] INT           NULL,
	[Toimipiste_ID] INT NULL,
    [Shipper_ID]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Puhelin_ID] ASC),
    CONSTRAINT [FK_Puhelin_ToTable] FOREIGN KEY ([Asiakas_ID]) REFERENCES [dbo].[Asiakkaat] ([Asiakas_ID]),
    CONSTRAINT [FK_Puhelin_ToTable_1] FOREIGN KEY ([Hoitaja_ID]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID]),
    CONSTRAINT [FK_Puhelin_ToTable_2] FOREIGN KEY ([Henkilokunta_ID]) REFERENCES [dbo].[Henkilokunta] ([Henkilokunta_ID]),
	CONSTRAINT [FK_Puhelin_ToTable_3] FOREIGN KEY ([Toimipiste_ID]) REFERENCES [dbo].[Toimipisteet] ([Toimipiste_ID]),
    CONSTRAINT [FK_Puhelin_ToTable_4] FOREIGN KEY ([Shipper_ID]) REFERENCES [dbo].[Shippers] ([Shipper_ID])
);


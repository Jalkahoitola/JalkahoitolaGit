CREATE TABLE [dbo].[Palvelut] (
    [Palvelu_ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Palvelun nimi]  NVARCHAR (20) NULL,
    [Palvelun_kesto] VARCHAR (20)  NULL,
    [Asiakas_ID]     INT           NULL,
    [Hoitaja_ID]     INT           NULL,
    [Toimipiste_ID]  INT           NULL,
    [Varaus_ID]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Palvelu_ID] ASC),
	CONSTRAINT [FK_Palvelut_ToTable] FOREIGN KEY ([Asiakas_ID]) REFERENCES [dbo].[Asiakkaat] ([Asiakas_ID]),
    CONSTRAINT [FK_Palvelut_ToTable_1] FOREIGN KEY ([Hoitaja_ID]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID]),  
    CONSTRAINT [FK_Palvelut_ToTable_2] FOREIGN KEY ([Toimipiste_ID]) REFERENCES [dbo].[Toimipisteet] ([Toimipiste_ID]),
    CONSTRAINT [FK_Palvelut_ToTable_3] FOREIGN KEY ([Varaus_ID]) REFERENCES [dbo].[Event] ([Varaus_ID])
);


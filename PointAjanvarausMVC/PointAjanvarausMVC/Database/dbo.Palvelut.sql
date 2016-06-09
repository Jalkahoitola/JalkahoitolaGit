CREATE TABLE [dbo].[Palvelut] (
    [Palvelu_ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Palvelun nimi]  NVARCHAR (20) NULL,
    [Palvelun_kesto] VARCHAR (20)  NULL,
    [Asiakas_id]     INT           NULL,
    [Hoitaja_id]     INT           NULL,
    [Toimipiste_id]  INT           NULL,
    [Varaus_id]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Palvelu_ID] ASC),
    CONSTRAINT [FK_Palvelut_ToTable_1] FOREIGN KEY ([Hoitaja_id]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID]),
    CONSTRAINT [FK_Palvelut_ToTable] FOREIGN KEY ([Asiakas_id]) REFERENCES [dbo].[Asiakkaat] ([Asiakas_ID]),
    CONSTRAINT [FK_Palvelut_ToTable_2] FOREIGN KEY ([Toimipiste_id]) REFERENCES [dbo].[Toimipisteet] ([Toimipiste_ID]),
    CONSTRAINT [FK_Palvelut_ToTable_3] FOREIGN KEY ([Varaus_id]) REFERENCES [dbo].[Varaus] ([Varaus_ID])
);


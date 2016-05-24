CREATE TABLE [dbo].[Event] (
    [Varaus_ID]      INT            IDENTITY (1, 1) NOT NULL,
    [Päivämäärä]     DATETIME       NULL,
    [Varausaika]     DATETIME       NULL,
    [Asiakas_ID]     INT            NULL,
    [Palvelu_ID]     INT            NULL,
    [Hoitopaikka_ID] INT            NULL,
    [Hoitaja_ID]     INT            NULL,
    [Info]           NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([Varaus_ID] ASC),
    CONSTRAINT [FK_Event_ToTable_1] FOREIGN KEY ([Palvelu_ID]) REFERENCES [dbo].[Palvelut] ([Palvelu_ID]),
    CONSTRAINT [FK_Event_ToTable_3] FOREIGN KEY ([Hoitopaikka_ID]) REFERENCES [dbo].[Hoitopaikat] ([Hoitopaikka_ID]),
    CONSTRAINT [FK_Event_ToTable] FOREIGN KEY ([Asiakas_ID]) REFERENCES [dbo].[Asiakkaat] ([Asiakas_ID]),
    CONSTRAINT [FK_Event_ToTable_4] FOREIGN KEY ([Hoitaja_ID]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID])
);


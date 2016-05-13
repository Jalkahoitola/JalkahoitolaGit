CREATE TABLE [dbo].[Hoitopaikat] (
    [Hoitopaikka_ID]   INT           IDENTITY (1000, 1) NOT NULL,
    [Hoitopaikan_Nimi] NVARCHAR (20) NULL,
	[Hoitaja_ID] INT NULL,
    [Huomio_ID]        INT           NULL,
    PRIMARY KEY CLUSTERED ([Hoitopaikka_ID] ASC),
	CONSTRAINT [FK_Hoitopaikat_ToTable] FOREIGN KEY ([Hoitaja_id]) REFERENCES [Hoitajat]([Hoitaja_ID]),
    CONSTRAINT [FK_Hoitopaikat_ToTable1] FOREIGN KEY ([Huomio_ID]) REFERENCES [dbo].[Huomiot] ([Huomio_ID])
);
CREATE TABLE [dbo].[Toimipisteet] (
    [Toimipiste_ID]     INT           IDENTITY (1000, 1) NOT NULL,
    [Toimipisteen_Nimi] NVARCHAR (20) NULL,
    [Hoitopaikka_ID]    INT           NULL,
    [Osoite_ID]         INT           NULL,
    [Puhelin_ID]        INT           NULL,
    [Huomio_ID]         INT           NULL,
	[Varaus_ID] INT NULL,
    PRIMARY KEY CLUSTERED ([Toimipiste_ID] ASC),
    CONSTRAINT [FK_Toimipisteet_ToTable] FOREIGN KEY ([Hoitopaikka_ID]) REFERENCES [dbo].[Hoitopaikat] ([Hoitopaikka_ID]),
    CONSTRAINT [FK_Toimipisteet_ToTable1] FOREIGN KEY ([Osoite_ID]) REFERENCES [dbo].[Osoite] ([Osoite_ID]),
    CONSTRAINT [FK_Toimipisteet_ToTable_2] FOREIGN KEY ([Puhelin_ID]) REFERENCES [dbo].[Puhelin] ([Puhelin_ID]),
    CONSTRAINT [FK_Toimipisteet_ToTable_3] FOREIGN KEY ([Huomio_ID]) REFERENCES [dbo].[Huomiot] ([Huomio_ID]),
	CONSTRAINT [FK_Toimipisteet_ToTable_4] FOREIGN KEY ([Varaus_ID]) REFERENCES [dbo].[Varaus] ([Varaus_ID]),
);


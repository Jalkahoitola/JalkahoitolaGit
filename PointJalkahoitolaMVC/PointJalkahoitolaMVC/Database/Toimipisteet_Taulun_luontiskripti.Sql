CREATE TABLE [dbo].[Toimipisteet] (
    [Toimipiste_ID]    INT           IDENTITY (1000, 1) NOT NULL,
    [Toimipisteen_Nimi]       NVARCHAR (20) NULL,
	[Hoitopaikka_ID] INT NULL,
    [Osoite_ID]     INT           NULL,
    [Puhelin_ID]    INT           NULL,
    [Huomio_ID]     INT           NULL,
    PRIMARY KEY CLUSTERED ([Toimipiste_ID] ASC), 
    CONSTRAINT [FK_Toimipisteet_ToTable] FOREIGN KEY ([Hoitopaikka_id]) REFERENCES [Hoitopaikat]([Hoitopaikka_ID]),
	CONSTRAINT [FK_Toimipisteet_ToTable1] FOREIGN KEY ([Osoite_id]) REFERENCES [Osoite]([Osoite_ID]),  
    CONSTRAINT [FK_Toimipisteet_ToTable_2] FOREIGN KEY ([Puhelin_id]) REFERENCES [Puhelin]([Puhelin_ID]), 
    CONSTRAINT [FK_Toimipisteet_ToTable_3] FOREIGN KEY ([Huomio_id]) REFERENCES [Huomiot]([Huomio_ID])
	);
CREATE TABLE [dbo].[Hoitopaikat] (
    [Hoitopaikka_ID]     INT           IDENTITY (1000, 1) NOT NULL,
    [Hoitopaikan_Nimi]   NVARCHAR (20) NULL,
    [Hoitopaikan_Numero] NVARCHAR (10) NULL,
    [Toimipiste_ID]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Hoitopaikka_ID] ASC),
    CONSTRAINT [FK_Hoitopaikat_ToTable] FOREIGN KEY ([Toimipiste_ID]) REFERENCES [dbo].[Toimipisteet] ([Toimipiste_ID])
);


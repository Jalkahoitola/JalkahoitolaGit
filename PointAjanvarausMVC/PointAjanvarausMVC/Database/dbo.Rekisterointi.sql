CREATE TABLE [dbo].[Rekisterointi] (
    [Rekisterointi_ID] INT           IDENTITY (1, 1) NOT NULL,
    [Kurssi_ID]        INT           NULL,
    [Kurssi]           NVARCHAR (20) NULL,
    [Hoitaja_ID]       INT           NULL,
    PRIMARY KEY CLUSTERED ([Rekisterointi_ID] ASC),
    CONSTRAINT [FK_Rekisterointi_ToTable_1] FOREIGN KEY ([Hoitaja_ID]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID]),
    CONSTRAINT [FK_Rekisterointi_ToTable] FOREIGN KEY ([Kurssi_ID]) REFERENCES [dbo].[Kurssit] ([Kurssi_ID])
);


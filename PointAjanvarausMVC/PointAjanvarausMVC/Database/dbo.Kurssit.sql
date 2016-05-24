CREATE TABLE [dbo].[Kurssit] (
    [Kurssi_ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Kurssinimike]  NVARCHAR (20) NULL,
    [Opintopisteet] NVARCHAR (20) NULL,
    [Rekisterointi] INT           NULL,
    PRIMARY KEY CLUSTERED ([Kurssi_ID] ASC),
    CONSTRAINT [FK_Kurssit_ToTable1] FOREIGN KEY ([Rekisterointi]) REFERENCES [dbo].[Rekisterointi] ([Rekisterointi_ID])
);


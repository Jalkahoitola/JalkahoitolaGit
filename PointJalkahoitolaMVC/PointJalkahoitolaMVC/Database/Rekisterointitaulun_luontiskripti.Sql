CREATE TABLE [dbo].[Rekisterointi] (
	[Rekisterointi_ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Kurssi_ID]    INT           NULL,
    [Kurssi]       NVARCHAR (20) NULL,
    [Hoitaja_ID]      INT NULL,
 
    PRIMARY KEY CLUSTERED ([Rekisterointi_ID] ASC), 
    CONSTRAINT [FK_Rekisterointi_ToTable] FOREIGN KEY ([Kurssi_ID]) REFERENCES [Kurssit]([Kurssi_ID]), 
    CONSTRAINT [FK_Rekisterointi_ToTable_1] FOREIGN KEY ([Hoitaja_id]) REFERENCES [Hoitajat]([Hoitaja_ID]), 
    
	);
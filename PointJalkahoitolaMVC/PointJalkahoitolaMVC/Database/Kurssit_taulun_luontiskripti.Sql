CREATE TABLE [dbo].[Kurssit] (
    [Kurssi_ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Nimike]       NVARCHAR (20) NULL,
    [Opintopisteet]      NVARCHAR (20) NULL,
    [Arviointi] NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Kurssi_ID] ASC), 
    CONSTRAINT [FK_Kurssit_ToTable] FOREIGN KEY ([hoitaja_id]) REFERENCES [Hoitajat]([Hoitaja_ID]), 
  
	);
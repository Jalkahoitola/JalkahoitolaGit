CREATE TABLE [dbo].[Rekisterointi] (
    [Rekisterointi_ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Vuosikurssi]             NVARCHAR (20) NULL,
    [Vuosikurssi aloitus pvm] DATETIME      NULL,
    [Vuosikurssi lopetus pvm] DATETIME      NULL,
    [Kurssi_ID]               INT           NULL,
    [Hoitaja_ID]              INT           NULL,
    PRIMARY KEY CLUSTERED ([Rekisterointi_ID] ASC),
	CONSTRAINT [FK_Rekisterointi_ToTable] FOREIGN KEY ([Hoitaja_ID]) REFERENCES [dbo].[Hoitajat] ([Hoitaja_ID])
);


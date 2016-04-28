CREATE TABLE [dbo].[Asiakkaat]
(
[AsiakasID] INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
[Etunimi] NVARCHAR (50) NULL,
[Sukunimi] NVARCHAR (50) NULL,
[Osoite] NVARCHAR (100) NULL,
[Postinumero] VARCHAR (5) NOT NULL
	
) 

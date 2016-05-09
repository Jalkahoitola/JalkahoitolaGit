CREATE TABLE [dbo].[Osoite](
	[Osoite_ID] [int] IDENTITY(1,1) NOT NULL,
	[Katuosoite] [nvarchar](100),
	[Postinumero] [nvarchar](20),
	[Postitoimipaikka] [nvarchar](20),
    PRIMARY KEY CLUSTERED ([Osoite_ID] ASC)
);

GO
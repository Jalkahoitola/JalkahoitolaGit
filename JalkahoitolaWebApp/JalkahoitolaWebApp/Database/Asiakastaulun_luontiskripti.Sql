CREATE TABLE [dbo].[Asiakkaat](
	[Asiakas_Id] [int] IDENTITY(1,1) NOT NULL,
	[Etunimi] [nvarchar](20),
	[Sukunimi] [nvarchar](20),	
	[Osoite_id] [int] NULL,
	[Puhelin_id] [int] NULL,
	[Huomiot] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Asiakas_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
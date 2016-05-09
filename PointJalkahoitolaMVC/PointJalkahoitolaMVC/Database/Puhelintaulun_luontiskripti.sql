CREATE TABLE [dbo].[Puhelin](
	[Puhelin_ID] [int] IDENTITY(1,1) NOT NULL,
	[Puhelinnumero_1] [nvarchar](20),
	[Puhelinnumero_2] [nvarchar](20),
	[Puhelinnumero_3] [nvarchar](20),
    PRIMARY KEY CLUSTERED ([Puhelin_ID] ASC)
);

GO
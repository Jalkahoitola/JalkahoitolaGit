CREATE TABLE [dbo].[Huomiot](
	[Huomio_ID] [int] IDENTITY(1,1) NOT NULL,
	[Sairaudet] [nvarchar](100),
	[Muut] [nvarchar](100),
    PRIMARY KEY CLUSTERED ([Huomio_ID] ASC)
);

GO
CREATE TABLE [dbo].[Huomiot] (
    [Huomio_ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Huomioitavat asiat] NVARCHAR (100) NULL,
    [Muut]               NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Huomio_ID] ASC)
);


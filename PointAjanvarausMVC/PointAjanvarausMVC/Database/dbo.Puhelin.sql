CREATE TABLE [dbo].[Puhelin] (
    [Puhelin_ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Puhelinnumero_1] NVARCHAR (20) NULL,
    [Puhelinnumero_2] NVARCHAR (20) NULL,
    [Puhelinnumero_3] NVARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Puhelin_ID] ASC)
);


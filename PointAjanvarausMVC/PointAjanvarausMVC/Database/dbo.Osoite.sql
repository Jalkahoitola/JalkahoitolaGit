CREATE TABLE [dbo].[Osoite] (
    [Osoite_ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Katuosoite]       NVARCHAR (100) NULL,
    [Postinumero]      NVARCHAR (20)  NULL,
    [Postitoimipaikka] NVARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Osoite_ID] ASC)
);


CREATE TABLE [dbo].[Hoitajat] (
    [Hoitaja_ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Tunnus]            NVARCHAR (10)  NULL,
    [Etunimi]           NVARCHAR (20)  NULL,
    [Toinen nimi]       NVARCHAR (20)  NULL,
    [Sukunimi]          NVARCHAR (20)  NULL,
    [Katuosoite]        NVARCHAR (100) NULL,
    [Postinumero]       NVARCHAR (5)   NULL,
    [Postitoimipaikka]  NVARCHAR (100) NULL,
    [Henkilotunnus]     NVARCHAR (20)  NULL,
    [Aloituspvm]        DATE           NULL,
    [Valmistumispvm]    DATE           NULL,
    [Keskeytyspvm]      DATE           NULL,
    [Tiedot arkistoitu] VARCHAR (5)    NULL,
    [Huomio]            INT            NULL,
    [Osoite_id]         INT            NULL,
    [Puhelin_id]        INT            NULL,
    [Kurssi_id]         INT            NULL,
    PRIMARY KEY CLUSTERED ([Hoitaja_ID] ASC),
    CONSTRAINT [FK_Hoitajat_ToTable] FOREIGN KEY ([Osoite_id]) REFERENCES [dbo].[Osoite] ([Osoite_ID]),
    CONSTRAINT [FK_Hoitajat_ToTable_1] FOREIGN KEY ([Puhelin_id]) REFERENCES [dbo].[Puhelin] ([Puhelin_ID]),
    CONSTRAINT [FK_Hoitajat_ToTable_2] FOREIGN KEY ([Huomio]) REFERENCES [dbo].[Huomiot] ([Huomio_ID])
);


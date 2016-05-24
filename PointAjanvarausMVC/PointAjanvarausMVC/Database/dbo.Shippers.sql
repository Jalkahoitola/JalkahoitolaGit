CREATE TABLE [dbo].[Shippers] (
    [Shipper_ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Yritysnimi]          NVARCHAR (20)  NULL,
    [Puhelinnumero_1]  NVARCHAR (20)  NULL,
    [Huomiot]          NVARCHAR (200) NULL,
    [Osoite_id]        INT            NULL,
    [Huomio_id]        INT            NULL,
    [Puhelin_id]       INT            NULL,
    PRIMARY KEY CLUSTERED ([Shipper_ID] ASC),
    CONSTRAINT [FK_Shippers_ToTable] FOREIGN KEY ([Osoite_id]) REFERENCES [dbo].[Osoite] ([Osoite_ID]),
    CONSTRAINT [FK_Shippers_ToTable_1] FOREIGN KEY ([Puhelin_id]) REFERENCES [dbo].[Puhelin] ([Puhelin_ID]),
    CONSTRAINT [FK_Shippers_ToTable_2] FOREIGN KEY ([Huomio_id]) REFERENCES [dbo].[Huomiot] ([Huomio_ID])
);
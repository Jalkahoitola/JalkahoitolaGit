CREATE TABLE [dbo].[Tilaukset] (
    [Tilaus_ID]       INT            IDENTITY (1, 1) NOT NULL,
	[Toimittaja_ID]		INT NULL,
	[Tuote_ID] INT  NULL,
    [Henkilokunta_ID] INT NULL,
	[Tilausm‰‰r‰] INT NULL,
    [Tilausp‰iv‰]      DATETIME    NULL,
    [Toimitus pvm] DATETIME   NULL,
    [Saapumispvm]		DATETIME  NULL,
	[ShipName] VARCHAR (50) NULL,
	[ShipAddress] VARCHAR (60) NULL,
	[Shipper_ID] INT NULL,
   
    PRIMARY KEY CLUSTERED ([Tilaus_ID] ASC),
    CONSTRAINT [FK_Tilaukset_ToTable] FOREIGN KEY ([Tuote_ID]) REFERENCES [dbo].[Tuotteet] ([Tuote_ID]),
    CONSTRAINT [FK_Tilaukset_ToTable_1] FOREIGN KEY ([Henkilokunta_ID]) REFERENCES [dbo].[Henkilokunta] ([Henkilokunta_ID]),
    --CONSTRAINT [FK_Tilaukset_ToTable_2] FOREIGN KEY ([Shipper_ID]) REFERENCES [dbo].[Shippers] ([Shipper_ID])
);
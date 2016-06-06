CREATE TABLE [dbo].[Tuotteet] (
    [Tuote_ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Tuotenimi]        NVARCHAR (100)  NULL,
	[Toimittaja_ID]		INT NULL,
    [Varastom‰‰r‰]     INT  NULL,
    [Ostohinta]			DECIMAL (10,2) NULL,
	[Tilausm‰‰r‰]		INT,
    [Tilausp‰iv‰]      DATETIME    NULL,
    [Arvioitu saapumis pvm] DATETIME   NULL,
    [Saapumispvm]		DATETIME  NULL,
	[Valikoimasta poisto] BIT(1),
	[Tilaus_ID] INT NULL,
	[Shipper_ID] INT NULL,
   
    PRIMARY KEY CLUSTERED ([Tuote_ID] ASC),
    CONSTRAINT [FK_Tuotteet_ToTable] FOREIGN KEY ([Tilaus_ID]) REFERENCES [dbo].[Tilaukset] ([Tilaus_ID]),
    CONSTRAINT [FK_Tuotteet_ToTable_1] FOREIGN KEY ([Toimittaja_ID]) REFERENCES [dbo].[Toimitaja] ([Toimittaja_ID]),
    CONSTRAINT [FK_Tuotteet_ToTable_2] FOREIGN KEY ([Shipper_ID]) REFERENCES [dbo].[Shippers] ([Shipper_ID])
);

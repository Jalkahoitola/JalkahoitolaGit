CREATE TABLE [dbo].[Postitoimipaikat] (
    [Posti_id]         INT          IDENTITY (1, 1) NOT NULL,
    [Postinumero]      VARCHAR (5)  NOT NULL,
    [Postitoimipaikka] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Postinumero] ASC)
);


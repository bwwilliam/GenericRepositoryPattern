CREATE TABLE [dbo].[Contact] (
    [Phone]   NVARCHAR (50) NULL,
    [Address] NVARCHAR (50) NULL,
    [Id]      INT           NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC)
);


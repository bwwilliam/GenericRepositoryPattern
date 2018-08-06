CREATE TABLE [dbo].[Customer] (
    [Name]   NVARCHAR (50) NULL,
    [Age]    INT           NULL,
    [ID]     INT           NOT NULL,
    [Gender] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([ID] ASC)
);


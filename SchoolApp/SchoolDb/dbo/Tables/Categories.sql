CREATE TABLE [dbo].[Categories] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [DeletedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);


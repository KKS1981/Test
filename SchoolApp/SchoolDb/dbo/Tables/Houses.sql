CREATE TABLE [dbo].[Houses] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    [DeletedDate]  DATETIME       NULL,
    CONSTRAINT [PK_dbo.Houses] PRIMARY KEY CLUSTERED ([Id] ASC)
);


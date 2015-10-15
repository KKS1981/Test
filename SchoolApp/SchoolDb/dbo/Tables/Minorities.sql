CREATE TABLE [dbo].[Minorities] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [DeletedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.Minorities] PRIMARY KEY CLUSTERED ([Id] ASC)
);


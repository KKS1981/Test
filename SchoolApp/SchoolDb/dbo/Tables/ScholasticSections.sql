CREATE TABLE [dbo].[ScholasticSections] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Type]         NVARCHAR (MAX) NULL,
    [Order]        INT            NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    [DeletedDate]  DATETIME       NULL,
    CONSTRAINT [PK_dbo.ScholasticSections] PRIMARY KEY CLUSTERED ([Id] ASC)
);


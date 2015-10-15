CREATE TABLE [dbo].[ClassLabels] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [DeletedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [NumericCode]  INT            NOT NULL,
    CONSTRAINT [PK_dbo.ClassLabels] PRIMARY KEY CLUSTERED ([Id] ASC)
);


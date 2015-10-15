CREATE TABLE [dbo].[SectionLabels] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NOT NULL,
    [DeletedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.SectionLabels] PRIMARY KEY CLUSTERED ([Id] ASC)
);


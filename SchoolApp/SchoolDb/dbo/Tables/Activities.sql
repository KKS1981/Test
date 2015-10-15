CREATE TABLE [dbo].[Activities] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (MAX) NULL,
    [DeletedDate]          DATETIME       NULL,
    [ModifiedDate]         DATETIME       NULL,
    [CreatedDate]          DATETIME       NOT NULL,
    [DisplayOrder]         INT            NULL,
    [Optional]             BIT            NOT NULL,
    [CBSECode]             NVARCHAR (MAX) NULL,
    [CBSEName]             NVARCHAR (MAX) NULL,
    [ScholasticSection_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Activities] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Activities_dbo.ScholasticSections_ScholasticSection_Id] FOREIGN KEY ([ScholasticSection_Id]) REFERENCES [dbo].[ScholasticSections] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ScholasticSection_Id]
    ON [dbo].[Activities]([ScholasticSection_Id] ASC);


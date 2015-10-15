CREATE TABLE [dbo].[Subjects] (
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [Name]                 NVARCHAR (MAX)  NULL,
    [ShortName]            NVARCHAR (MAX)  NULL,
    [Weightage]            DECIMAL (18, 2) NULL,
    [CreatedDate]          DATETIME        NOT NULL,
    [ModifiedDate]         DATETIME        NULL,
    [DeletedDate]          DATETIME        NULL,
    [DisplayOrder]         INT             NULL,
    [CBSECode]             NVARCHAR (MAX)  NULL,
    [CBSEName]             NVARCHAR (MAX)  NULL,
    [ScholasticSection_Id] INT             NULL,
    [Parent_Id]            INT             NULL,
    CONSTRAINT [PK_dbo.Subjects] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Subjects_dbo.ScholasticSections_ScholasticSection_Id] FOREIGN KEY ([ScholasticSection_Id]) REFERENCES [dbo].[ScholasticSections] ([Id]),
    CONSTRAINT [FK_dbo.Subjects_dbo.Subjects_Parent_Id] FOREIGN KEY ([Parent_Id]) REFERENCES [dbo].[Subjects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ScholasticSection_Id]
    ON [dbo].[Subjects]([ScholasticSection_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Id]
    ON [dbo].[Subjects]([Parent_Id] ASC);


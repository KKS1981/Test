CREATE TABLE [dbo].[Classes] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Label]           NVARCHAR (MAX) NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [ModifiedDate]    DATETIME       NULL,
    [DeletedDate]     DATETIME       NULL,
    [Term1Path]       NVARCHAR (MAX) NULL,
    [Term2Path]       NVARCHAR (MAX) NULL,
    [Orientation]     NVARCHAR (MAX) NULL,
    [SectionLabel_Id] INT            NOT NULL,
    [ClassLabel_Id]   INT            NOT NULL,
    CONSTRAINT [PK_dbo.Classes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Classes_dbo.ClassLabels_ClassLabel_Id] FOREIGN KEY ([ClassLabel_Id]) REFERENCES [dbo].[ClassLabels] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Classes_dbo.SectionLabels_SectionLabel_Id] FOREIGN KEY ([SectionLabel_Id]) REFERENCES [dbo].[SectionLabels] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SectionLabel_Id]
    ON [dbo].[Classes]([SectionLabel_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ClassLabel_Id]
    ON [dbo].[Classes]([ClassLabel_Id] ASC);


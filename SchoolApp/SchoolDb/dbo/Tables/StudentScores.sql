CREATE TABLE [dbo].[StudentScores] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [XmlData]        NVARCHAR (MAX) NULL,
    [CreatedDate]    DATETIME       NOT NULL,
    [ModifiedDate]   DATETIME       NULL,
    [DeletedDate]    DATETIME       NULL,
    [StudentId]      INT            NOT NULL,
    [ApprovedBy]     SMALLINT       NULL,
    [ApprovedSchema] INT            NULL,
    CONSTRAINT [PK_dbo.StudentScores] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.StudentScores_dbo.Students_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StudentId]
    ON [dbo].[StudentScores]([StudentId] ASC);


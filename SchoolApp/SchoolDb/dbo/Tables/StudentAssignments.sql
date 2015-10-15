CREATE TABLE [dbo].[StudentAssignments] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FilePath]     NVARCHAR (MAX) NULL,
    [Title]        NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    [DeletedDate]  DATETIME       NULL,
    [Student_Id]   INT            NULL,
    [Subject_Id]   INT            NULL,
    [File_Id]      INT            NULL,
    CONSTRAINT [PK_dbo.StudentAssignments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.StudentAssignments_dbo.Files_File_Id] FOREIGN KEY ([File_Id]) REFERENCES [dbo].[Files] ([Id]),
    CONSTRAINT [FK_dbo.StudentAssignments_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id]),
    CONSTRAINT [FK_dbo.StudentAssignments_dbo.Subjects_Subject_Id] FOREIGN KEY ([Subject_Id]) REFERENCES [dbo].[Subjects] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[StudentAssignments]([Student_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Subject_Id]
    ON [dbo].[StudentAssignments]([Subject_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_File_Id]
    ON [dbo].[StudentAssignments]([File_Id] ASC);


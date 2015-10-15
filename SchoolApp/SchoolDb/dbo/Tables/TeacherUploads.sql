CREATE TABLE [dbo].[TeacherUploads] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NULL,
    [DeletedDate]  DATETIME       NULL,
    [File_Id]      INT            NULL,
    [Teacher_Id]   INT            NULL,
    CONSTRAINT [PK_dbo.TeacherUploads] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.TeacherUploads_dbo.Files_File_Id] FOREIGN KEY ([File_Id]) REFERENCES [dbo].[Files] ([Id]),
    CONSTRAINT [FK_dbo.TeacherUploads_dbo.Teachers_Teacher_Id] FOREIGN KEY ([Teacher_Id]) REFERENCES [dbo].[Teachers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_File_Id]
    ON [dbo].[TeacherUploads]([File_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Teacher_Id]
    ON [dbo].[TeacherUploads]([Teacher_Id] ASC);


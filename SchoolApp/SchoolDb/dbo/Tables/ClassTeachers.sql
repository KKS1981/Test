CREATE TABLE [dbo].[ClassTeachers] (
    [Id]               INT      IDENTITY (1, 1) NOT NULL,
    [DeletedDate]      DATETIME NULL,
    [ModifiedDate]     DATETIME NULL,
    [CreatedDate]      DATETIME NOT NULL,
    [TeacherMaster_Id] INT      NOT NULL,
    [Class_Id]         INT      NOT NULL,
    CONSTRAINT [PK_dbo.ClassTeachers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ClassTeachers_dbo.Classes_Class_Id] FOREIGN KEY ([Class_Id]) REFERENCES [dbo].[Classes] ([Id]),
    CONSTRAINT [FK_dbo.ClassTeachers_dbo.Teachers_TeacherMaster_Id] FOREIGN KEY ([TeacherMaster_Id]) REFERENCES [dbo].[Teachers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TeacherMaster_Id]
    ON [dbo].[ClassTeachers]([TeacherMaster_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Class_Id]
    ON [dbo].[ClassTeachers]([Class_Id] ASC);


CREATE TABLE [dbo].[TeacherClassSubjectMaps] (
    [Id]              INT      IDENTITY (1, 1) NOT NULL,
    [Class_Id]        INT      NOT NULL,
    [AcademicYear_Id] INT      NOT NULL,
    [DeletedDate]     DATETIME NULL,
    [ModifiedDate]    DATETIME NULL,
    [CreatedDate]     DATETIME NOT NULL,
    [Teacher_Id]      INT      NULL,
    CONSTRAINT [PK_dbo.TeacherClassSubjectMaps] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.TeacherClassSubjectMaps_dbo.AcademicYears_AcademicYear_Id] FOREIGN KEY ([AcademicYear_Id]) REFERENCES [dbo].[AcademicYears] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.TeacherClassSubjectMaps_dbo.Classes_Class_Id] FOREIGN KEY ([Class_Id]) REFERENCES [dbo].[Classes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.TeacherClassSubjectMaps_dbo.Teachers_Teacher_Id] FOREIGN KEY ([Teacher_Id]) REFERENCES [dbo].[Teachers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Teacher_Id]
    ON [dbo].[TeacherClassSubjectMaps]([Teacher_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Class_Id]
    ON [dbo].[TeacherClassSubjectMaps]([Class_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AcademicYear_Id]
    ON [dbo].[TeacherClassSubjectMaps]([AcademicYear_Id] ASC);


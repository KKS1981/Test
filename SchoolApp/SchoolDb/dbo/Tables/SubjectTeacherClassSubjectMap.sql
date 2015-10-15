CREATE TABLE [dbo].[SubjectTeacherClassSubjectMap] (
    [Subjects_Id]                INT NOT NULL,
    [TeacherClassSubjectMaps_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.SubjectTeacherClassSubjectMap] PRIMARY KEY CLUSTERED ([Subjects_Id] ASC, [TeacherClassSubjectMaps_Id] ASC),
    CONSTRAINT [FK_dbo.SubjectTeacherClassSubjectMap_dbo.Subjects_Subjects_Id] FOREIGN KEY ([Subjects_Id]) REFERENCES [dbo].[Subjects] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.SubjectTeacherClassSubjectMap_dbo.TeacherClassSubjectMaps_TeacherClassSubjectMaps_Id] FOREIGN KEY ([TeacherClassSubjectMaps_Id]) REFERENCES [dbo].[TeacherClassSubjectMaps] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Subjects_Id]
    ON [dbo].[SubjectTeacherClassSubjectMap]([Subjects_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TeacherClassSubjectMaps_Id]
    ON [dbo].[SubjectTeacherClassSubjectMap]([TeacherClassSubjectMaps_Id] ASC);


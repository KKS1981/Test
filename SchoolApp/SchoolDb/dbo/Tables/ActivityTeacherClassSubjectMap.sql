CREATE TABLE [dbo].[ActivityTeacherClassSubjectMap] (
    [Activities_Id]              INT NOT NULL,
    [TeacherClassSubjectMaps_Id] INT NOT NULL,
    CONSTRAINT [PK_dbo.ActivityTeacherClassSubjectMap] PRIMARY KEY CLUSTERED ([Activities_Id] ASC, [TeacherClassSubjectMaps_Id] ASC),
    CONSTRAINT [FK_dbo.ActivityTeacherClassSubjectMap_dbo.Activities_Activities_Id] FOREIGN KEY ([Activities_Id]) REFERENCES [dbo].[Activities] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ActivityTeacherClassSubjectMap_dbo.TeacherClassSubjectMaps_TeacherClassSubjectMaps_Id] FOREIGN KEY ([TeacherClassSubjectMaps_Id]) REFERENCES [dbo].[TeacherClassSubjectMaps] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Activities_Id]
    ON [dbo].[ActivityTeacherClassSubjectMap]([Activities_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TeacherClassSubjectMaps_Id]
    ON [dbo].[ActivityTeacherClassSubjectMap]([TeacherClassSubjectMaps_Id] ASC);


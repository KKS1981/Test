CREATE TABLE [dbo].[StudentAttendancesStudents] (
    [StudentAttendances_Id] INT NOT NULL,
    [Student_Id]            INT NOT NULL,
    CONSTRAINT [PK_dbo.StudentAttendancesStudents] PRIMARY KEY CLUSTERED ([StudentAttendances_Id] ASC, [Student_Id] ASC),
    CONSTRAINT [FK_dbo.StudentAttendancesStudents_dbo.StudentAttendances_StudentAttendances_Id] FOREIGN KEY ([StudentAttendances_Id]) REFERENCES [dbo].[StudentAttendances] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.StudentAttendancesStudents_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_StudentAttendances_Id]
    ON [dbo].[StudentAttendancesStudents]([StudentAttendances_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[StudentAttendancesStudents]([Student_Id] ASC);


CREATE TABLE [dbo].[Attendances] (
    [Id]              INT      IDENTITY (1, 1) NOT NULL,
    [Jan]             INT      NULL,
    [Feb]             INT      NULL,
    [Mar]             INT      NULL,
    [Apr]             INT      NULL,
    [May]             INT      NULL,
    [Jun]             INT      NULL,
    [Jul]             INT      NULL,
    [Aug]             INT      NULL,
    [Sep]             INT      NULL,
    [Oct]             INT      NULL,
    [Nov]             INT      NULL,
    [Dec]             INT      NULL,
    [CreatedDate]     DATETIME NOT NULL,
    [ModifiedDate]    DATETIME NULL,
    [DeletedDate]     DATETIME NULL,
    [ClassId]         INT      NULL,
    [AcademicYear_Id] INT      NULL,
    [Student_Id]      INT      NULL,
    CONSTRAINT [PK_dbo.Attendances] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Attendances_dbo.AcademicYears_AcademicYear_Id] FOREIGN KEY ([AcademicYear_Id]) REFERENCES [dbo].[AcademicYears] ([Id]),
    CONSTRAINT [FK_dbo.Attendances_dbo.Classes_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [dbo].[Classes] ([Id]),
    CONSTRAINT [FK_dbo.Attendances_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AcademicYear_Id]
    ON [dbo].[Attendances]([AcademicYear_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ClassId]
    ON [dbo].[Attendances]([ClassId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[Attendances]([Student_Id] ASC);


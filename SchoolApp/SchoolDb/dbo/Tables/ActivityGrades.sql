CREATE TABLE [dbo].[ActivityGrades] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Grade]           NVARCHAR (MAX) NULL,
    [DisplayText]     NVARCHAR (MAX) NULL,
    [CreatedDate]     DATETIME       NOT NULL,
    [ModifiedDate]    DATETIME       NULL,
    [DeletedDate]     DATETIME       NULL,
    [Activity_Id]     INT            NULL,
    [Student_Id]      INT            NULL,
    [AcademicTerm_Id] INT            NULL,
    CONSTRAINT [PK_dbo.ActivityGrades] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ActivityGrades_dbo.AcademicTerms_AcademicTerm_Id] FOREIGN KEY ([AcademicTerm_Id]) REFERENCES [dbo].[AcademicTerms] ([Id]),
    CONSTRAINT [FK_dbo.ActivityGrades_dbo.Activities_Activity_Id] FOREIGN KEY ([Activity_Id]) REFERENCES [dbo].[Activities] ([Id]),
    CONSTRAINT [FK_dbo.ActivityGrades_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Activity_Id]
    ON [dbo].[ActivityGrades]([Activity_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[ActivityGrades]([Student_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AcademicTerm_Id]
    ON [dbo].[ActivityGrades]([AcademicTerm_Id] ASC);


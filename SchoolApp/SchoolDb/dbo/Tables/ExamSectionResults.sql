CREATE TABLE [dbo].[ExamSectionResults] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [ExamSection_Id] INT             NOT NULL,
    [MarkObtained]   DECIMAL (18, 2) NOT NULL,
    [Student_Id]     INT             NOT NULL,
    [CreatedDate]    DATETIME        NOT NULL,
    [ModifiedDate]   DATETIME        NULL,
    [DeletedDate]    DATETIME        NULL,
    CONSTRAINT [PK_dbo.ExamSectionResults] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ExamSectionResults_dbo.ExamSections_ExamSection_Id] FOREIGN KEY ([ExamSection_Id]) REFERENCES [dbo].[ExamSections] ([Id]),
    CONSTRAINT [FK_dbo.ExamSectionResults_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ExamSection_Id]
    ON [dbo].[ExamSectionResults]([ExamSection_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[ExamSectionResults]([Student_Id] ASC);


CREATE TABLE [dbo].[AssessmentSchemas] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX)  NULL,
    [Type]            INT             NOT NULL,
    [Weightage]       DECIMAL (18, 2) NOT NULL,
    [DeletedDate]     DATETIME        NULL,
    [ModifiedDate]    DATETIME        NULL,
    [CreatedDate]     DATETIME        NOT NULL,
    [StartMonth]      INT             NULL,
    [EndMonth]        INT             NULL,
    [Value]           INT             NOT NULL,
    [AcademicTerm_Id] INT             NOT NULL,
    CONSTRAINT [PK_dbo.AssessmentSchemas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AssessmentSchemas_dbo.AcademicTerms_AcademicTerm_Id] FOREIGN KEY ([AcademicTerm_Id]) REFERENCES [dbo].[AcademicTerms] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_AcademicTerm_Id]
    ON [dbo].[AssessmentSchemas]([AcademicTerm_Id] ASC);


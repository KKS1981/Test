CREATE TABLE [dbo].[Students] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [DeletedDate]         DATETIME       NULL,
    [ModifiedDate]        DATETIME       NULL,
    [CreatedDate]         DATETIME       NOT NULL,
    [BoardRegistrationNo] NVARCHAR (MAX) NULL,
    [RollNo]              NVARCHAR (MAX) NULL,
    [CBSERollNo]          NVARCHAR (MAX) NULL,
    [IsPromoted]          BIT            NOT NULL,
    [StudentMaster_Id]    INT            NOT NULL,
    [AcademicYear_Id]     INT            NOT NULL,
    [Class_Id]            INT            NOT NULL,
    [House_Id]            INT            NULL,
    CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Students_dbo.AcademicYears_AcademicYear_Id] FOREIGN KEY ([AcademicYear_Id]) REFERENCES [dbo].[AcademicYears] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Students_dbo.Classes_Class_Id] FOREIGN KEY ([Class_Id]) REFERENCES [dbo].[Classes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Students_dbo.Houses_House_Id] FOREIGN KEY ([House_Id]) REFERENCES [dbo].[Houses] ([Id]),
    CONSTRAINT [FK_dbo.Students_dbo.StudentMasters_StudentMaster_Id] FOREIGN KEY ([StudentMaster_Id]) REFERENCES [dbo].[StudentMasters] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_StudentMaster_Id]
    ON [dbo].[Students]([StudentMaster_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AcademicYear_Id]
    ON [dbo].[Students]([AcademicYear_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Class_Id]
    ON [dbo].[Students]([Class_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_House_Id]
    ON [dbo].[Students]([House_Id] ASC);


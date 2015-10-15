CREATE TABLE [dbo].[StudentAttendances] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [CreatedDate]  DATETIME NOT NULL,
    [ModifiedDate] DATETIME NULL,
    [DeletedDate]  DATETIME NULL,
    [Date]         DATETIME NOT NULL,
    CONSTRAINT [PK_dbo.StudentAttendances] PRIMARY KEY CLUSTERED ([Id] ASC)
);


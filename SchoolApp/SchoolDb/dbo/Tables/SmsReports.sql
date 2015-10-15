CREATE TABLE [dbo].[SmsReports] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [SendDate]         DATETIME       NOT NULL,
    [DeliveryDate]     DATETIME       NOT NULL,
    [CreatedDate]      DATETIME       NOT NULL,
    [ModifiedDate]     DATETIME       NULL,
    [DeletedDate]      DATETIME       NULL,
    [SmsShortCode]     NVARCHAR (MAX) NULL,
    [MobileNo]         NVARCHAR (MAX) NULL,
    [Message]          NVARCHAR (MAX) NOT NULL,
    [SenderId]         NVARCHAR (MAX) NULL,
    [Status]           BIT            NOT NULL,
    [TeacherMaster_ID] INT            NULL,
    [Student_Id]       INT            NULL,
    CONSTRAINT [PK_dbo.SmsReports] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.SmsReports_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id]),
    CONSTRAINT [FK_dbo.SmsReports_dbo.Teachers_TeacherMaster_ID] FOREIGN KEY ([TeacherMaster_ID]) REFERENCES [dbo].[Teachers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TeacherMaster_ID]
    ON [dbo].[SmsReports]([TeacherMaster_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[SmsReports]([Student_Id] ASC);


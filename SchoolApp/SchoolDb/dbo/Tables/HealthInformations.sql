CREATE TABLE [dbo].[HealthInformations] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Height]       DECIMAL (18, 2) NULL,
    [Weight]       DECIMAL (18, 2) NULL,
    [VisionL]      DECIMAL (18, 2) NULL,
    [VisionR]      DECIMAL (18, 2) NULL,
    [Dental]       INT             NULL,
    [CreatedDate]  DATETIME        NOT NULL,
    [ModifiedDate] DATETIME        NULL,
    [DeletedDate]  DATETIME        NULL,
    [Teeth]        INT             NULL,
    [Student_Id]   INT             NOT NULL,
    CONSTRAINT [PK_dbo.HealthInformations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.HealthInformations_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[HealthInformations]([Student_Id] ASC);


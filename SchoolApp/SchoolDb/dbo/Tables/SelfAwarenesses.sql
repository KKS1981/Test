CREATE TABLE [dbo].[SelfAwarenesses] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Goals]            NVARCHAR (MAX) NULL,
    [Strengths]        NVARCHAR (MAX) NULL,
    [Interests]        NVARCHAR (MAX) NULL,
    [Responsibilities] NVARCHAR (MAX) NULL,
    [CreatedDate]      DATETIME       NOT NULL,
    [ModifiedDate]     DATETIME       NULL,
    [DeletedDate]      DATETIME       NULL,
    [Student_Id]       INT            NOT NULL,
    CONSTRAINT [PK_dbo.SelfAwarenesses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.SelfAwarenesses_dbo.Students_Student_Id] FOREIGN KEY ([Student_Id]) REFERENCES [dbo].[Students] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Student_Id]
    ON [dbo].[SelfAwarenesses]([Student_Id] ASC);


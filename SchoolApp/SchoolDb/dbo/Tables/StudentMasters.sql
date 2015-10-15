CREATE TABLE [dbo].[StudentMasters] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (MAX)  NULL,
    [LastName]      NVARCHAR (MAX)  NULL,
    [DOB]           DATETIME        NOT NULL,
    [Gender]        BIT             NOT NULL,
    [MotherName]    NVARCHAR (MAX)  NULL,
    [FatherName]    NVARCHAR (MAX)  NULL,
    [PhoneNo]       NVARCHAR (MAX)  NULL,
    [MobileNo]      NVARCHAR (MAX)  NULL,
    [EmailId]       NVARCHAR (MAX)  NULL,
    [Nationality]   NVARCHAR (MAX)  NULL,
    [AdmissionNo]   NVARCHAR (MAX)  NULL,
    [StreetAddress] NVARCHAR (MAX)  NULL,
    [City]          NVARCHAR (MAX)  NULL,
    [State]         NVARCHAR (MAX)  NULL,
    [Country]       NVARCHAR (MAX)  NULL,
    [PinCode]       NVARCHAR (MAX)  NULL,
    [DeletedDate]   DATETIME        NULL,
    [ModifiedDate]  DATETIME        NULL,
    [CreatedDate]   DATETIME        NOT NULL,
    [BloodGroup]    NVARCHAR (MAX)  NULL,
    [ImagePath]     NVARCHAR (MAX)  NULL,
    [FamilyIncome]  DECIMAL (18, 2) NULL,
    [Transport]     NVARCHAR (MAX)  NULL,
    [EWS]           BIT             NULL,
    [UserId]        NVARCHAR (MAX)  NULL,
    [UserName]      NVARCHAR (MAX)  NULL,
    [Category_Id]   INT             NULL,
    [Minority_Id]   INT             NULL,
    CONSTRAINT [PK_dbo.StudentMasters] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.StudentMasters_dbo.Categories_Category_Id] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Categories] ([Id]),
    CONSTRAINT [FK_dbo.StudentMasters_dbo.Minorities_Minority_Id] FOREIGN KEY ([Minority_Id]) REFERENCES [dbo].[Minorities] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Category_Id]
    ON [dbo].[StudentMasters]([Category_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Minority_Id]
    ON [dbo].[StudentMasters]([Minority_Id] ASC);


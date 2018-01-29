CREATE TABLE [dbo].[Users] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [Email]        NVARCHAR (50) NOT NULL,
    [Mobile]       NVARCHAR (50) NOT NULL,
    [UserName]     NVARCHAR (50) NOT NULL,
    [Password]     NVARCHAR (50) NOT NULL,
    [CustomerId]   INT           NOT NULL,
    [DepartmentId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_toDepartment] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([Id]),
    CONSTRAINT [FK_User_toCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);


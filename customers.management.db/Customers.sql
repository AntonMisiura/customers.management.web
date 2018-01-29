CREATE TABLE [dbo].[Customers] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50) NOT NULL,
    [Address]  NVARCHAR (50) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    [Phone]    NVARCHAR (50) NOT NULL,
    [Comments] NVARCHAR (50) NULL,
    [TypeId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_toType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Types] ([Id])
);


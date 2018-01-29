CREATE TABLE [dbo].[Contacts] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [Role]       NVARCHAR (50) NOT NULL,
    [Email]      NVARCHAR (50) NOT NULL,
    [Phone]      NVARCHAR (50) NOT NULL,
    [CustomerId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contact_toCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);


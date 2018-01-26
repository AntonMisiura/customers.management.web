CREATE TABLE [dbo].[Departments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR (50) NOT NULL,
	[Address] NVARCHAR (50) NOT NULL,
	[CustomerId] INT NULL,
	[UserId] INT NULL, 
	CONSTRAINT [FK_Department_toUser] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
	ON DELETE SET NULL,
	CONSTRAINT [FK_Departments_toCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
	ON DELETE SET NULL
)

CREATE TABLE [dbo].[SchoolNumbers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CustomerId] INT NULL,
	[Number] INT,
	CONSTRAINT [FK_Number_toCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
	ON DELETE SET NULL
)

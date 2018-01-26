CREATE TABLE [dbo].[SchoolNumbers]
(
	[CustomerId] INT NULL,
	[Number] INT,
	CONSTRAINT [FK_Number_toCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
	ON DELETE SET NULL
)

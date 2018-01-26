CREATE TABLE [dbo].[CustomerContact]
(
	 [CustomerId] INT NULL,
	 [ContactId] INT NULL,
	 CONSTRAINT [FK_Contact_toCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE SET NULL,
	 CONSTRAINT [FK_Customer_toContact] FOREIGN KEY ([ContactId]) REFERENCES [Contacts] ([Id]) ON DELETE SET NULL
)

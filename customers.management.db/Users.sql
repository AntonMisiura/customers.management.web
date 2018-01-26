CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR (50) NOT NULL,
	[Email] NVARCHAR (50) NOT NULL,
	[Mobile] NVARCHAR (50) NOT NULL,
	[UserName] NVARCHAR (50) NOT NULL,
	[Password] NVARCHAR (50) NOT NULL,
	[CustomerId] INT NULL,
	[DepartmentId] INT NULL,
	CONSTRAINT [FK_User_toDepartment] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id])
	ON DELETE SET NULL,
	CONSTRAINT [FK_Users_toCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id])
	ON DELETE SET NULL
)

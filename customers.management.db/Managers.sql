CREATE TABLE [dbo].[Managers] (
    [UserId]       INT NOT NULL,
    [DepartmentId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [DepartmentId] ASC),
    CONSTRAINT [FK_Manager_toDepartment] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([Id]),
    CONSTRAINT [FK_Manager_toUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


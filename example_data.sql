USE [ProjectX]
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([Id], [Name]) VALUES (1, N'Bees Knees AB')
GO
INSERT [dbo].[Companies] ([Id], [Name]) VALUES (2, N'Cats payjamas LLC')
GO
INSERT [dbo].[Companies] ([Id], [Name]) VALUES (3, N'Cool beans Inc.')
GO
INSERT [dbo].[Companies] ([Id], [Name]) VALUES (4, N'Scotts tots Corporation')
GO
INSERT [dbo].[Companies] ([Id], [Name]) VALUES (5, N'Schrute Farm Collective')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId]) VALUES (1, N'Michael Scott', 1)
GO
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId]) VALUES (2, N'Dwight Schrute', 5)
GO
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId]) VALUES (3, N'Kevin Malone', 2)
GO
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId]) VALUES (4, N'Creed Bratton', 3)
GO
INSERT [dbo].[Employees] ([Id], [Name], [CompanyId]) VALUES (5, N'Jan Lewinson', 4)
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 
GO
INSERT [dbo].[Assignments] ([Id], [Name], [Description], [Cost], [WorkingHoursPercentage], [CreationDate], [StartDate], [EndDate], [CompanyId], [EmployeeId]) VALUES (1, N'First assignment', N'Get candy from the kitchen', 100, 1, CAST(N'2020-03-09T20:21:50.9980000' AS DateTime2), CAST(N'2020-03-09T20:21:50.9980000' AS DateTime2), CAST(N'2020-03-09T20:21:50.9980000' AS DateTime2), 2, 3)
GO
INSERT [dbo].[Assignments] ([Id], [Name], [Description], [Cost], [WorkingHoursPercentage], [CreationDate], [StartDate], [EndDate], [CompanyId], [EmployeeId]) VALUES (5, N'Second Assignment', N'Brush cats whiskers', 50, 30, CAST(N'2020-03-20T10:00:00.0000000' AS DateTime2), CAST(N'2020-03-20T10:00:00.0000000' AS DateTime2), CAST(N'2020-03-20T19:00:00.0000000' AS DateTime2), 1, 1)
GO
INSERT [dbo].[Assignments] ([Id], [Name], [Description], [Cost], [WorkingHoursPercentage], [CreationDate], [StartDate], [EndDate], [CompanyId], [EmployeeId]) VALUES (6, N'Third Assignment', N'Stich Home Sweet Home sign', 200, 50, CAST(N'2020-03-19T07:00:00.0000000' AS DateTime2), CAST(N'2020-05-01T10:00:00.0000000' AS DateTime2), CAST(N'2020-06-01T17:00:00.0000000' AS DateTime2), 4, 5)
GO
INSERT [dbo].[Assignments] ([Id], [Name], [Description], [Cost], [WorkingHoursPercentage], [CreationDate], [StartDate], [EndDate], [CompanyId], [EmployeeId]) VALUES (7, N'Fourth Assignment', N'Learn how to make a paper hexagon', 500, 1000, CAST(N'2020-02-01T12:00:00.0000000' AS DateTime2), CAST(N'2020-09-01T08:30:00.0000000' AS DateTime2), CAST(N'2021-06-01T07:00:00.0000000' AS DateTime2), 3, 4)
GO
INSERT [dbo].[Assignments] ([Id], [Name], [Description], [Cost], [WorkingHoursPercentage], [CreationDate], [StartDate], [EndDate], [CompanyId], [EmployeeId]) VALUES (8, N'Fifth Assignment', N'Reread all Terry Pratchetts books', 300, 10001, CAST(N'1973-09-01T07:00:00.0000000' AS DateTime2), CAST(N'2021-09-01T08:00:00.0000000' AS DateTime2), CAST(N'2025-05-31T10:00:00.0000000' AS DateTime2), 5, 2)
GO
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200309201855_InitialCreate', N'3.1.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200309201940_Init', N'3.1.2')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200328164734_AddEmployeeToAssignment', N'3.1.2')
GO

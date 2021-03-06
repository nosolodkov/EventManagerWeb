USE [EventsDb]
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [Name], [Description], [EventTypeId], [DateAdded], [DateHappens], [Location], [MaxGuestsCount]) VALUES (1, N'BLACK HAT ASIA 2021', N'Security conference, Online', 0, CAST(N'2021-04-05T14:33:52.6782958' AS DateTime2), CAST(N'2021-05-04T14:33:11.8650000' AS DateTime2), N'Online', 20)
INSERT [dbo].[Events] ([Id], [Name], [Description], [EventTypeId], [DateAdded], [DateHappens], [Location], [MaxGuestsCount]) VALUES (2, N'DOTNEXT 2021', N'.NET conference, Online', 0, CAST(N'2021-04-05T14:34:40.1912958' AS DateTime2), CAST(N'2021-04-20T20:34:07.4800000' AS DateTime2), N'Online', 150)
INSERT [dbo].[Events] ([Id], [Name], [Description], [EventTypeId], [DateAdded], [DateHappens], [Location], [MaxGuestsCount]) VALUES (3, N'DEVOPSCON LONDON', N'DevOps conference in London', 0, CAST(N'2021-04-05T14:35:22.3322958' AS DateTime2), CAST(N'2021-04-20T14:34:41.6820000' AS DateTime2), N'London, United Kingdom', 32)
INSERT [dbo].[Events] ([Id], [Name], [Description], [EventTypeId], [DateAdded], [DateHappens], [Location], [MaxGuestsCount]) VALUES (4, N'JETBRAINS .NET DAYS', N'.NET conference, Online', 1, CAST(N'2021-04-05T14:35:58.1612958' AS DateTime2), CAST(N'2021-05-11T14:35:27.1110000' AS DateTime2), N'Online', 500)
INSERT [dbo].[Events] ([Id], [Name], [Description], [EventTypeId], [DateAdded], [DateHappens], [Location], [MaxGuestsCount]) VALUES (5, N'RUHRSEC', N'Security conference', 2, CAST(N'2021-04-05T14:36:38.8892958' AS DateTime2), CAST(N'2021-05-18T14:35:59.8520000' AS DateTime2), N'Bochum, Germany', 10)
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Guests] ON 

INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Patronymic], [Email], [Comment]) VALUES (1, N'Nikolay', N'Osolodkov', N'Nikolaevich', N'nnosolodkov@bk.ru', N'.NET developer')
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Patronymic], [Email], [Comment]) VALUES (2, N'Adnrew', N'Bogov', N'Petrovich', N'and@rambler.ru', N'QA')
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Patronymic], [Email], [Comment]) VALUES (3, N'Kseniya', N'Novikova', NULL, N'kseny@yandex.ru', NULL)
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Patronymic], [Email], [Comment]) VALUES (4, N'Nikolay', N'Osolodkov', N'Nikolaevich', N'nosolodkov@bk.ru', NULL)
INSERT [dbo].[Guests] ([Id], [FirstName], [LastName], [Patronymic], [Email], [Comment]) VALUES (5, N'Valentin', N'Popov', NULL, N'vpopov@mail.ru', NULL)
SET IDENTITY_INSERT [dbo].[Guests] OFF
GO
INSERT [dbo].[EventGuest] ([ListOfEventsId], [ListOfGuestsId]) VALUES (1, 1)
INSERT [dbo].[EventGuest] ([ListOfEventsId], [ListOfGuestsId]) VALUES (4, 1)
INSERT [dbo].[EventGuest] ([ListOfEventsId], [ListOfGuestsId]) VALUES (1, 2)
INSERT [dbo].[EventGuest] ([ListOfEventsId], [ListOfGuestsId]) VALUES (3, 2)
INSERT [dbo].[EventGuest] ([ListOfEventsId], [ListOfGuestsId]) VALUES (1, 3)
INSERT [dbo].[EventGuest] ([ListOfEventsId], [ListOfGuestsId]) VALUES (2, 3)
INSERT [dbo].[EventGuest] ([ListOfEventsId], [ListOfGuestsId]) VALUES (3, 3)
GO

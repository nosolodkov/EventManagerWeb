USE [EventsDb]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 05.04.2021 10:43:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[EventTypeId] [int] NOT NULL,
	[DateAdded] [datetime2](7) NOT NULL,
	[DateHappens] [datetime2](7) NOT NULL,
	[Location] [nvarchar](max) NULL,
	[MaxGuestsCount] [int] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([Id], [Name], [Description], [EventTypeId], [DateAdded], [DateHappens], [Location], [MaxGuestsCount]) VALUES (1, N'DOTNEXT 2021', N'.NET conference, Online', 0, CAST(N'2021-04-05T10:40:45.2179234' AS DateTime2), CAST(N'2021-04-20T10:40:01.1720000' AS DateTime2), N'Online', 20)
INSERT [dbo].[Events] ([Id], [Name], [Description], [EventTypeId], [DateAdded], [DateHappens], [Location], [MaxGuestsCount]) VALUES (2, N'CONF42: CLOUD NATIVE 2021', N'DevOps conference, Online', 0, CAST(N'2021-04-05T10:41:36.0110022' AS DateTime2), CAST(N'2021-04-29T10:40:55.8820000' AS DateTime2), N'Online', 120)
SET IDENTITY_INSERT [dbo].[Events] OFF
GO

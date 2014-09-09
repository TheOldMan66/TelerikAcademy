/*USE [Data_Modeling_And_ER_Diagrams_Task_1] */
CREATE DATABASE Task1
GO

CHECKPOINT

GO

USE Task1
GO

/****** Object:  Table [dbo].[Addresses]    Script Date: 20.8.2014 ã. 23:04:57 ÷. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[TownID] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 20.8.2014 ã. 23:04:58 ÷. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 20.8.2014 ã. 23:04:58 ÷. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 20.8.2014 ã. 23:04:58 ÷. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[AddressID] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 20.8.2014 ã. 23:04:58 ÷. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TonwID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TonwID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (1, N'Tyananman square', 1)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (2, N'HoShiMin Street', 1)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (3, N'Tazr Asen str', 4)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (4, N'Saborna str', 4)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (5, N'Great pyramids street', 7)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (6, N'Royal Casino str', 10)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (7, N'Canada square', 12)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (8, N'Black man str.', 2)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (9, N'Shan''z Elizee', 5)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (10, N'Chansone str.', 5)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (11, N'Football str', 3)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (12, N'Marakana square', 3)
INSERT [dbo].[Addresses] ([AddressID], [Address], [TownID]) VALUES (13, N'Maina str', 9)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (1, N'Africa')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (3, N'Europa')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (4, N'North Amercia')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (5, N'South America')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (6, N'Australia')
INSERT [dbo].[Continents] ([ContinentID], [Name]) VALUES (7, N'Antarctide')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (1, N'Bulgaria', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (2, N'Mexico', 5)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (3, N'Canada', 4)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (4, N'France', 3)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (5, N'China', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (6, N'Egypt', 1)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (7, N'Japan', 2)
INSERT [dbo].[Countries] ([CountryID], [Name], [ContinentID]) VALUES (8, N'Nigeria', 1)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonID], [FirstName], [Lastname], [AddressID]) VALUES (1, N'Peshko', N'Mainichkata', 13)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [Lastname], [AddressID]) VALUES (2, N'Cristiano', N'Ronaldo', 11)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [Lastname], [AddressID]) VALUES (3, N'Charle', N'De Gole', 9)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [Lastname], [AddressID]) VALUES (4, N'Bear', N'White', 7)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [Lastname], [AddressID]) VALUES (5, N'Sphynx', N'Pharaone', 5)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [Lastname], [AddressID]) VALUES (6, N'Gosho', N'Sofiyancheto', 3)
INSERT [dbo].[Persons] ([PersonID], [FirstName], [Lastname], [AddressID]) VALUES (7, N'Xiao', N'Min', 1)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (1, N'Beijing', 5)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (2, N'Lagos', 8)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (3, N'Mexico city', 2)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (4, N'Sofia', 1)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (5, N'Paris', 4)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (6, N'Quebec', 3)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (7, N'Gizza', 6)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (8, N'Tokyo', 7)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (9, N'Plovdiv', 1)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (10, N'Monaco', 4)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (11, N'Abudja', 8)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (12, N'Otava', 3)
INSERT [dbo].[Towns] ([TonwID], [Name], [CountryID]) VALUES (13, N'Taipe', 5)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownID])
REFERENCES [dbo].[Towns] ([TonwID])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continents] ([ContinentID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Addresses] ([AddressID])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO

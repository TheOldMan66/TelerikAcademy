USE [master]
GO
/****** Object:  Database [Olympiads]    Script Date: 9/2/2014 7:31:48 PM ******/
CREATE DATABASE [Olympiads]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Olympiads', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Olympiads.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Olympiads_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Olympiads_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Olympiads] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Olympiads].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Olympiads] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Olympiads] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Olympiads] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Olympiads] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Olympiads] SET ARITHABORT OFF 
GO
ALTER DATABASE [Olympiads] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Olympiads] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Olympiads] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Olympiads] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Olympiads] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Olympiads] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Olympiads] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Olympiads] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Olympiads] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Olympiads] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Olympiads] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Olympiads] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Olympiads] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Olympiads] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Olympiads] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Olympiads] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Olympiads] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Olympiads] SET RECOVERY FULL 
GO
ALTER DATABASE [Olympiads] SET  MULTI_USER 
GO
ALTER DATABASE [Olympiads] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Olympiads] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Olympiads] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Olympiads] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Olympiads] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Olympiads', N'ON'
GO
USE [Olympiads]
GO
/****** Object:  Table [dbo].[Athletes]    Script Date: 9/2/2014 7:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Athletes](
	[AthleteId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](80) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[NationalityId] [int] NULL,
 CONSTRAINT [PK_Athletes] PRIMARY KEY CLUSTERED 
(
	[AthleteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 9/2/2014 7:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Disciplines]    Script Date: 9/2/2014 7:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Disciplines](
	[DisciplineId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[SportId] [int] NULL,
 CONSTRAINT [PK_Disciplines] PRIMARY KEY CLUSTERED 
(
	[DisciplineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Events]    Script Date: 9/2/2014 7:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DisciplineId] [int] NOT NULL,
	[SummerOlympiadId] [int] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nationalities]    Script Date: 9/2/2014 7:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationalities](
	[NationalityId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_Nationalities] PRIMARY KEY CLUSTERED 
(
	[NationalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rankings]    Script Date: 9/2/2014 7:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rankings](
	[RankId] [int] IDENTITY(1,1) NOT NULL,
	[AthleteId] [int] NULL,
	[EventId] [int] NULL,
	[Rank] [int] NOT NULL,
 CONSTRAINT [PK_Rankings] PRIMARY KEY CLUSTERED 
(
	[RankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sports]    Script Date: 9/2/2014 7:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sports](
	[SportId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sports] PRIMARY KEY CLUSTERED 
(
	[SportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SummerOlympiads]    Script Date: 9/2/2014 7:31:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SummerOlympiads](
	[SummerOlympiadId] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[CityId] [int] NULL,
	[NotableAnthem] [varchar](50) NULL,
 CONSTRAINT [PK_SummerOlympiads] PRIMARY KEY CLUSTERED 
(
	[SummerOlympiadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Athletes]  WITH CHECK ADD  CONSTRAINT [FK_Athletes_Nationalities] FOREIGN KEY([NationalityId])
REFERENCES [dbo].[Nationalities] ([NationalityId])
GO
ALTER TABLE [dbo].[Athletes] CHECK CONSTRAINT [FK_Athletes_Nationalities]
GO
ALTER TABLE [dbo].[Disciplines]  WITH CHECK ADD  CONSTRAINT [FK_Disciplines_Sports] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sports] ([SportId])
GO
ALTER TABLE [dbo].[Disciplines] CHECK CONSTRAINT [FK_Disciplines_Sports]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Disciplines] FOREIGN KEY([DisciplineId])
REFERENCES [dbo].[Disciplines] ([DisciplineId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Disciplines]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_SummerOlympiads] FOREIGN KEY([SummerOlympiadId])
REFERENCES [dbo].[SummerOlympiads] ([SummerOlympiadId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_SummerOlympiads]
GO
ALTER TABLE [dbo].[Rankings]  WITH CHECK ADD  CONSTRAINT [FK_Rankings_Athletes] FOREIGN KEY([AthleteId])
REFERENCES [dbo].[Athletes] ([AthleteId])
GO
ALTER TABLE [dbo].[Rankings] CHECK CONSTRAINT [FK_Rankings_Athletes]
GO
ALTER TABLE [dbo].[Rankings]  WITH CHECK ADD  CONSTRAINT [FK_Rankings_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Rankings] CHECK CONSTRAINT [FK_Rankings_Events]
GO
ALTER TABLE [dbo].[SummerOlympiads]  WITH CHECK ADD  CONSTRAINT [FK_SummerOlympiads_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([CityId])
GO
ALTER TABLE [dbo].[SummerOlympiads] CHECK CONSTRAINT [FK_SummerOlympiads_Cities]
GO
ALTER TABLE [dbo].[Athletes]  WITH CHECK ADD  CONSTRAINT [CHK_Gender] CHECK  (([Gender]='M' OR [Gender]='W'))
GO
ALTER TABLE [dbo].[Athletes] CHECK CONSTRAINT [CHK_Gender]
GO
ALTER TABLE [dbo].[Rankings]  WITH CHECK ADD  CONSTRAINT [CHK_Rank] CHECK  (([Rank]>(0)))
GO
ALTER TABLE [dbo].[Rankings] CHECK CONSTRAINT [CHK_Rank]
GO
USE [master]
GO
ALTER DATABASE [Olympiads] SET  READ_WRITE 
GO

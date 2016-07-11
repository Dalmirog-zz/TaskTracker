/****** Object:  Table [dbo].[Projects]    Script Date: 7/2/2016 4:11:18 PM ******/
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL
) ON [PRIMARY]

/****** Object:  Table [dbo].[Tasks]    Script Date: 7/2/2016 4:12:03 PM ******/
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NULL,
	[TagID] [varchar](50) NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NULL
) ON [PRIMARY]

USE [TaskTracker]
GO

/****** Object:  Table [dbo].[Tags]    Script Date: 7/2/2016 4:12:59 PM ******/
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
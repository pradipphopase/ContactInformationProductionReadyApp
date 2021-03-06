USE [master]
GO
/****** Object:  Database [DB_Production]    Script Date: 28-03-2021 10:18:18 ******/
CREATE DATABASE [DB_Production]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Production', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Production.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Production_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Production_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_Production] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Production].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Production] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Production] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Production] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Production] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Production] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Production] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Production] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Production] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Production] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Production] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Production] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Production] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Production] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Production] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Production] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Production] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Production] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Production] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Production] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Production] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Production] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Production] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Production] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Production] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Production] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Production] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Production] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Production] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Production] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Production] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_Production] SET QUERY_STORE = OFF
GO
USE [DB_Production]
GO
/****** Object:  Table [dbo].[tbl_ContactInfo]    Script Date: 28-03-2021 10:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ContactInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_ContactInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_ContactInfo] ON 

INSERT [dbo].[tbl_ContactInfo] ([ID], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (1, N'Dipti', N'Phopase', N'dipti@gmail.com', N'8735625342', N'active')
INSERT [dbo].[tbl_ContactInfo] ([ID], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (2, N'Pradip', N'Phopase', N'pradip@gmail.com', N'9302938493', N'active')
INSERT [dbo].[tbl_ContactInfo] ([ID], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (3, N'Shravan', N'Shindhe', N'shravan@gmail.com', N'9489393000', N'inactive')
INSERT [dbo].[tbl_ContactInfo] ([ID], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (8, N'Ram', N'Varma', N'ram@gmail.com', N'7856234567', N'inactive')
INSERT [dbo].[tbl_ContactInfo] ([ID], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (9, N'Ram', N'Ram', N'ram@gmail.com', N'7682345678', N'active')
SET IDENTITY_INSERT [dbo].[tbl_ContactInfo] OFF
GO
USE [master]
GO
ALTER DATABASE [DB_Production] SET  READ_WRITE 
GO

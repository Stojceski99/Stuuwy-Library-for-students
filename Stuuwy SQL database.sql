USE [master]
GO
/****** Object:  Database [Stuuwy]    Script Date: 07.6.2020 20:42:13 ******/
CREATE DATABASE [Stuuwy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Stuuwy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Stuuwy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Stuuwy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Stuuwy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Stuuwy] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Stuuwy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Stuuwy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Stuuwy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Stuuwy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Stuuwy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Stuuwy] SET ARITHABORT OFF 
GO
ALTER DATABASE [Stuuwy] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Stuuwy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Stuuwy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Stuuwy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Stuuwy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Stuuwy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Stuuwy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Stuuwy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Stuuwy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Stuuwy] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Stuuwy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Stuuwy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Stuuwy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Stuuwy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Stuuwy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Stuuwy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Stuuwy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Stuuwy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Stuuwy] SET  MULTI_USER 
GO
ALTER DATABASE [Stuuwy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Stuuwy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Stuuwy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Stuuwy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Stuuwy] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Stuuwy] SET QUERY_STORE = OFF
GO
USE [Stuuwy]
GO
/****** Object:  Table [dbo].[Book_Information]    Script Date: 07.6.2020 20:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Information](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[bookName] [varchar](50) NULL,
	[bookAuthor] [varchar](50) NULL,
	[bookPublisherName] [varchar](50) NULL,
	[bookPurchaseDate] [varchar](50) NULL,
	[bookPrice] [int] NULL,
	[bookQuantity] [int] NULL,
	[availableQuantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book_Issue]    Script Date: 07.6.2020 20:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_Issue](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[studentIndeks] [int] NULL,
	[studentFirstName] [varchar](50) NULL,
	[studentLastName] [varchar](50) NULL,
	[studentPrograma] [varchar](50) NULL,
	[studentSemestar] [int] NULL,
	[studentEmail] [varchar](50) NULL,
	[bookName] [varchar](50) NULL,
	[bookIssueDate] [varchar](50) NULL,
	[bookReturnDate] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Librarian]    Script Date: 07.6.2020 20:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Librarian](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Information]    Script Date: 07.6.2020 20:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Information](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[studentFirstName] [varchar](50) NULL,
	[studentLastName] [varchar](50) NULL,
	[studentIndeks] [int] NULL,
	[studentPrograma] [varchar](50) NULL,
	[studentSemestar] [int] NULL,
	[studentEmail] [varchar](50) NULL,
	[studentPassword] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book_Information] ON 

INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (21, N'The 5am club', N'Robin Sharma', N'Harper Collins', N'01.01.2020', 500, 1000, 998)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (22, N'Jonathan Livingston Seagull', N'Richard Bah', N'Tri', N'04.08.1970', 200, 1000, 998)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (23, N'Namesti si go krevetot', N'Vilijam Mekrejven', N'Tri', N'05.09.2019', 400, 600, 598)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (24, N'10x', N'Grand Kardon', N'Tri', N'24.12.2009 00:00:00', 350, 200, 201)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (25, N'Ili si prv ili posleden', N'Grand Kardon', N'Prosvetno delo', N'12.2.2015 00:00:00', 400, 601, 599)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (26, N'The subtle art of not giving a f*', N'Mark Manson', N'Tri', N'12.11.2018 13:54:30', 600, 1000, 999)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (27, N'12 zivotni pravila', N'Jordan Peterson', N'Harper Collins', N'10.5.2017 13:54:30', 600, 1200, 1199)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (28, N'Farenhajt 451', N'Rej Bredberi', N'Tri', N'10.5.2017 13:54:30', 299, 600, 598)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (29, N'Pocni so zosto', N'Sajmon Senek', N'333312321', N'26.12.2016 13:54:30', 499, 600, 599)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (30, N'Tom Soer', N'Mark Tven', N'Maks Print', N'10.5.2016 13:54:30', 400, 900, 899)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (31, N'Bedni Lugje', N'Fyodor Dostoevski', N'Citaj Kniga', N'20.11.2013 13:54:30', 1000, 100, 98)
INSERT [dbo].[Book_Information] ([ID], [bookName], [bookAuthor], [bookPublisherName], [bookPurchaseDate], [bookPrice], [bookQuantity], [availableQuantity]) VALUES (32, N'C# FOR DUMMIES', N'Rboin Sharma', N'Tri', N'02.6.2020 18:22:04', 500, 500, 499)
SET IDENTITY_INSERT [dbo].[Book_Information] OFF
GO
SET IDENTITY_INSERT [dbo].[Book_Issue] ON 

INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (15, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'The subtle art of not giving a f*', N'04.6.2020', N'04.6.2020 15:50:42')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (16, 555, N'David', N'Davidoski', N'KTI', 5, N'david.davidoski@gmail.com', N'Jonathan Livingston Seagull', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (17, 123, N'Milan', N'Milanoski', N'KF', 7, N'milan.milanoski@gmail.com', N'Farenhajt 451', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (18, 555, N'David', N'Davidoski', N'KTI', 5, N'david.davidoski@gmail.com', N'Tom Soer', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (19, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'Bedni Lugje', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (20, 555, N'David', N'Davidoski', N'KTI', 5, N'david.davidoski@gmail.com', N'Namesti si go krevetot', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (21, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'The 5am club', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (22, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'12 zivotni pravila', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (23, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'Pocni so zosto', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (24, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'The subtle art of not giving a f*', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (25, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'Ili si prv ili posleden', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (26, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'Bedni Lugje', N'04.6.2020', N'25.6.2020 18:20:07')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (27, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'Farenhajt 451', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (28, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'Jonathan Livingston Seagull', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (29, 123, N'Milan', N'Milanoski', N'KF', 7, N'milan.milanoski@gmail.com', N'Bedni Lugje', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (30, 123, N'Milan', N'Milanoski', N'KF', 7, N'milan.milanoski@gmail.com', N'The 5am club', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (31, 123, N'Milan', N'Milanoski', N'KF', 7, N'milan.milanoski@gmail.com', N'Namesti si go krevetot', N'04.6.2020', N'')
INSERT [dbo].[Book_Issue] ([ID], [studentIndeks], [studentFirstName], [studentLastName], [studentPrograma], [studentSemestar], [studentEmail], [bookName], [bookIssueDate], [bookReturnDate]) VALUES (32, 482, N'Hristijan', N'Stojceski', N'INKI', 4, N'hristijan.stojceski@uklo.edu.mk', N'C# FOR DUMMIES', N'04.6.2020', N'')
SET IDENTITY_INSERT [dbo].[Book_Issue] OFF
GO
SET IDENTITY_INSERT [dbo].[Librarian] ON 

INSERT [dbo].[Librarian] ([ID], [firstName], [lastName], [userName], [password], [email]) VALUES (1, N'admin', N'admin', N'admin', N'admin', N'hristijan.stojceski@uklo.edu.mk')
INSERT [dbo].[Librarian] ([ID], [firstName], [lastName], [userName], [password], [email]) VALUES (2, N'admin1', N'admin1', N'admin1', N'admin', N'admin@gmail.com')
SET IDENTITY_INSERT [dbo].[Librarian] OFF
GO
SET IDENTITY_INSERT [dbo].[Student_Information] ON 

INSERT [dbo].[Student_Information] ([ID], [studentFirstName], [studentLastName], [studentIndeks], [studentPrograma], [studentSemestar], [studentEmail], [studentPassword]) VALUES (29, N'Hristijan', N'Stojceski', 482, N'INKI', 7, N'kiko.stojceski99@gmail.com', N'123')
INSERT [dbo].[Student_Information] ([ID], [studentFirstName], [studentLastName], [studentIndeks], [studentPrograma], [studentSemestar], [studentEmail], [studentPassword]) VALUES (30, N'Mile', N'Mileski', 555, N'KTI', 3, N'mile.mileski@gmail.com', N'123')
INSERT [dbo].[Student_Information] ([ID], [studentFirstName], [studentLastName], [studentIndeks], [studentPrograma], [studentSemestar], [studentEmail], [studentPassword]) VALUES (31, N'Trajce', N'Trajceski', 314, N'IKT', 6, N'trajce.trajceski@gmail.com', N'123')
INSERT [dbo].[Student_Information] ([ID], [studentFirstName], [studentLastName], [studentIndeks], [studentPrograma], [studentSemestar], [studentEmail], [studentPassword]) VALUES (32, N'Zoki', N'Poki', 131, N'INKI', 2, N'zoki.poki@gmail.com', N'123')
INSERT [dbo].[Student_Information] ([ID], [studentFirstName], [studentLastName], [studentIndeks], [studentPrograma], [studentSemestar], [studentEmail], [studentPassword]) VALUES (33, N'Crven', N'Kapa', 1232, N'KTI', 5, N'crven.kapa@gmail.com', N'123')
SET IDENTITY_INSERT [dbo].[Student_Information] OFF
GO
USE [master]
GO
ALTER DATABASE [Stuuwy] SET  READ_WRITE 
GO

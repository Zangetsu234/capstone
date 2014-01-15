USE [capstone]
GO
ALTER TABLE [dbo].[Statistics] DROP CONSTRAINT [FK__Statistics__c_id__25869641]
GO
ALTER TABLE [dbo].[Character] DROP CONSTRAINT [FK__Character__u_id__24927208]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF__Users__Active__239E4DCF]
GO
ALTER TABLE [dbo].[Character] DROP CONSTRAINT [DF__Character__Activ__22AA2996]
GO
ALTER TABLE [dbo].[Character] DROP CONSTRAINT [DF__Character__Align__21B6055D]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Statistics]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP TABLE [dbo].[Statistics]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP TABLE [dbo].[Character]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[UpdateUser]
GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[RemoveUser]
GO
/****** Object:  StoredProcedure [dbo].[RemoveCharacter]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[RemoveCharacter]
GO
/****** Object:  StoredProcedure [dbo].[GetUserCharacters]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[GetUserCharacters]
GO
/****** Object:  StoredProcedure [dbo].[GetUserByUsername]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[GetUserByUsername]
GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[GetUserByID]
GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[GetUserByEmail]
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[GetUser]
GO
/****** Object:  StoredProcedure [dbo].[GetCharacterStats]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[GetCharacterStats]
GO
/****** Object:  StoredProcedure [dbo].[GetCharacterByName]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[GetCharacterByName]
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[GetAllUsers]
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[CreateUser]
GO
/****** Object:  StoredProcedure [dbo].[CreateStats]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[CreateStats]
GO
/****** Object:  StoredProcedure [dbo].[CreateCharacter]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP PROCEDURE [dbo].[CreateCharacter]
GO
USE [master]
GO
/****** Object:  Database [capstone]    Script Date: 1/15/2014 4:49:25 PM ******/
DROP DATABASE [capstone]
GO
/****** Object:  Database [capstone]    Script Date: 1/15/2014 4:49:25 PM ******/
CREATE DATABASE [capstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'capstone', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\capstone.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'capstone_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\capstone_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [capstone] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [capstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [capstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [capstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [capstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [capstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [capstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [capstone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [capstone] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [capstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [capstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [capstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [capstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [capstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [capstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [capstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [capstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [capstone] SET  DISABLE_BROKER 
GO
ALTER DATABASE [capstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [capstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [capstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [capstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [capstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [capstone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [capstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [capstone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [capstone] SET  MULTI_USER 
GO
ALTER DATABASE [capstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [capstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [capstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [capstone] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [capstone]
GO
/****** Object:  StoredProcedure [dbo].[CreateCharacter]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateCharacter]
	-- Add the parameters for the stored procedure here
	@Name varchar(25),
	@Alignment bit,
	@u_id int
AS
BEGIN
insert into Character(Name, Alignment, u_id)
values(@Name, @Alignment, @u_id)
END





GO
/****** Object:  StoredProcedure [dbo].[CreateStats]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateStats]
	-- Add the parameters for the stored procedure here
	@c_id int
AS
BEGIN
insert into [Statistics](Strength, Intelligence, Dexterity, c_id)
values(5, 5, 5, @c_id)
END





GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser] 
	@Username varchar(50),
	@Email varchar(100),
	@Password varchar(50)
AS
BEGIN
insert into Users(Username, Email, [Password])
values(@Username, @Email, @Password)
END





GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetAllUsers]

AS
BEGIN
SELECT * FROM Users
WHERE Active=1
END












GO
/****** Object:  StoredProcedure [dbo].[GetCharacterByName]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetCharacterByName] 
	-- Add the parameters for the stored procedure here
	@Name varchar(25)
AS
BEGIN
	select * from [Character]
	where Name = @Name and Active = 1
END











GO
/****** Object:  StoredProcedure [dbo].[GetCharacterStats]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCharacterStats]
	@c_id int
AS
BEGIN
SELECT * FROM [Statistics]
WHERE c_id = @c_id
END












GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetUser] 
	-- Add the parameters for the stored procedure here
	@Email varchar(100),
	@Username varchar(50)
AS
BEGIN
	select * from Users
	where Email = @Email
	or Username = @Username
	and Active = 1
END











GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetUserByEmail] 
	-- Add the parameters for the stored procedure here
	@Email varchar(100)
AS
BEGIN
	select * from Users
	where Email = @Email and Active = 1
END











GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetUserByID]
@u_id INT
AS
BEGIN
SELECT * FROM Users
WHERE Active=1 AND u_id = @u_id
END












GO
/****** Object:  StoredProcedure [dbo].[GetUserByUsername]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetUserByUsername] 
	-- Add the parameters for the stored procedure here
	@Username varchar(50)
AS
BEGIN
	select * from Users
	where Username = @Username and Active = 1
END











GO
/****** Object:  StoredProcedure [dbo].[GetUserCharacters]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserCharacters]
	@u_id int
AS
BEGIN
SELECT * FROM Character
WHERE u_id = @u_id and Active=1
END












GO
/****** Object:  StoredProcedure [dbo].[RemoveCharacter]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[RemoveCharacter] 
	-- Add the parameters for the stored procedure here
	@c_id int
AS
BEGIN
update Character
set Active = 0
where c_id = @c_id
END





GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RemoveUser] 
	-- Add the parameters for the stored procedure here
	@u_id int
AS
BEGIN
update Users
set Active = 0
where u_id = @u_id
END





GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[UpdateUser]
	@Email varchar(100), @Password varchar(50), @u_id int
AS
BEGIN
	update Users
	set Email = @Email, Password = @Password
	where u_id = @u_id and Active = 1
END











GO
/****** Object:  Table [dbo].[Character]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Character](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[Alignment] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[u_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Statistics]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistics](
	[stat_id] [int] IDENTITY(1,1) NOT NULL,
	[Strength] [int] NOT NULL,
	[Intelligence] [int] NOT NULL,
	[Dexterity] [int] NOT NULL,
	[c_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[stat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/15/2014 4:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[u_id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Character] ADD  DEFAULT ((1)) FOR [Alignment]
GO
ALTER TABLE [dbo].[Character] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Character]  WITH CHECK ADD FOREIGN KEY([u_id])
REFERENCES [dbo].[Users] ([u_id])
GO
ALTER TABLE [dbo].[Statistics]  WITH CHECK ADD FOREIGN KEY([c_id])
REFERENCES [dbo].[Character] ([c_id])
GO
USE [master]
GO
ALTER DATABASE [capstone] SET  READ_WRITE 
GO

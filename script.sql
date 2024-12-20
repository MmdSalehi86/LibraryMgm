USE [master]
GO
/****** Object:  Database [LibraryMgm]    Script Date: 11/19/2024 7:24:09 PM ******/
CREATE DATABASE [LibraryMgm]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'LibraryMgm', FILENAME = N'D:\sql_server_db\LibraryMgm\LibraryMgm.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'LibraryMgm_log', FILENAME = N'D:\sql_server_db\LibraryMgm\LibraryMgm_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
COLLATE Arabic_CI_AI
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LibraryMgm] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryMgm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
--ALTER DATABASE [LibraryMgm] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET AUTO_CLOSE OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [LibraryMgm] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET CURSOR_DEFAULT  GLOBAL 
--GO
--ALTER DATABASE [LibraryMgm] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET  DISABLE_BROKER 
--GO
--ALTER DATABASE [LibraryMgm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET DATE_CORRELATION_OPTIMIZATION OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET TRUSTWORTHY OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [LibraryMgm] SET READ_COMMITTED_SNAPSHOT OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET HONOR_BROKER_PRIORITY OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET RECOVERY FULL 
--GO
--ALTER DATABASE [LibraryMgm] SET  MULTI_USER 
--GO
--ALTER DATABASE [LibraryMgm] SET PAGE_VERIFY CHECKSUM  
--GO
--ALTER DATABASE [LibraryMgm] SET DB_CHAINING OFF 
--GO
--ALTER DATABASE [LibraryMgm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
--GO
--ALTER DATABASE [LibraryMgm] SET TARGET_RECOVERY_TIME = 60 SECONDS 
--GO
--ALTER DATABASE [LibraryMgm] SET DELAYED_DURABILITY = DISABLED 
--GO
--ALTER DATABASE [LibraryMgm] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LibraryMgm', N'ON'
GO
ALTER DATABASE [LibraryMgm] SET QUERY_STORE = ON
GO
ALTER DATABASE [LibraryMgm] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LibraryMgm]
GO
/****** Object:  UserDefinedFunction [dbo].[CHECK_EXISTS_BOOK]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CHECK_EXISTS_BOOK]
(
	@Name NVARCHAR(128),
	@Id INT = NULL
)
RETURNS BIT
AS
BEGIN

	IF (EXISTS
	(SELECT Id FROM dbo.Book
		WHERE [Name] = @Name AND (@Id IS NULL OR Id <> @Id)))
		RETURN 1;
	RETURN 0
	
END
GO
/****** Object:  UserDefinedFunction [dbo].[CHECK_EXISTS_TRANSLATOR]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CHECK_EXISTS_TRANSLATOR]
(
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@Id INT = NULL
)
RETURNS BIT
AS
BEGIN

	IF (EXISTS
	(SELECT Id FROM dbo.Translator
		WHERE FirstName = @FirstName AND LastName = @LastName AND
		(@Id IS NULL OR Id <> @Id)))
		RETURN 1;
	RETURN 0
	
END
GO
/****** Object:  Table [dbo].[Book]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) COLLATE Arabic_CI_AI NOT NULL,
	[Year] [int] NOT NULL,
	[Publisher] [nvarchar](128) COLLATE Arabic_CI_AI NOT NULL,
	[TranslatorId] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Translator]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](32) COLLATE Arabic_CI_AI NOT NULL,
	[LastName] [nvarchar](32) COLLATE Arabic_CI_AI NOT NULL,
	[Location] [nvarchar](128) COLLATE Arabic_CI_AI NULL,
 CONSTRAINT [PK_Translator] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([Id], [Name], [Year], [Publisher], [TranslatorId]) VALUES (1, N'کتاب تست', 1390, N'ناشر 1', 1)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Translator] ON 

INSERT [dbo].[Translator] ([Id], [FirstName], [LastName], [Location]) VALUES (1, N'علی', N'نصیری', N'کاشان')
SET IDENTITY_INSERT [dbo].[Translator] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Translator] FOREIGN KEY([TranslatorId])
REFERENCES [dbo].[Translator] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Translator]
GO
/****** Object:  StoredProcedure [dbo].[DELETE_BOOK]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETE_BOOK]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Book WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DELETE_TRANSLATOR]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DELETE_TRANSLATOR]
	@id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Translator WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_BOOK]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_BOOK]
	@Name nvarchar(128),
	@Year INT,
	@Publisher nvarchar(128),
	@TranslatorId int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Book
	(
	    [Name],
	    [Year],
	    Publisher,
	    TranslatorId
	)
	VALUES
	(   @Name, -- Name - nvarchar(128)
	    @Year,   -- Year - int
	    @Publisher, -- Publisher - nvarchar(128)
	    @TranslatorId    -- TranslatorId - int
	    )
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_TRANSLATOR]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERT_TRANSLATOR]
	@FirstName nvarchar(32),
	@LastName nvarchar(32),
	@Location nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Translator
	(
	    FirstName,
	    LastName,
	    Location
	)
	VALUES
	(   @FirstName, -- FirstName - nvarchar(32)
	    @LastName, -- LastName - nvarchar(32)
	    @Location -- Location - nvarchar(128)
	    )
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_BOOK]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECT_BOOK]
AS
BEGIN
	SELECT b.Id,
           b.Name,
           b.Year,
           b.Publisher,

           t.FirstName + ' ' + t.LastName TranslatorName
		   FROM dbo.Book b
		   INNER JOIN dbo.Translator t ON t.Id = b.TranslatorId
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_TRANSLATOR]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECT_TRANSLATOR]


AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id,
           FirstName,
           LastName,
           [Location]
		   FROM dbo.Translator
END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_BOOK]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_BOOK]
	@Id INT,
	@Name nvarchar(128),
	@Year INT,
	@Publisher nvarchar(128),
	@TranslatorId INT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Book SET
	[Name] = @Name,
	[Year] = @Year,
	Publisher = @Publisher,
	TranslatorId = @TranslatorId
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_TRANSLATOR]    Script Date: 11/19/2024 7:24:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_TRANSLATOR]
	@Id INT,
	@FirstName nvarchar(32),
	@LastName nvarchar(32),
	@Location nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Translator SET
		FirstName = @FirstName,
	    LastName = @LastName,
	    [Location] = @Location
	WHERE Id = @Id
END
GO
USE [master]
GO
ALTER DATABASE [LibraryMgm] SET  READ_WRITE 
GO

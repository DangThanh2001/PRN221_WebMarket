USE [master]
GO
/****** Object:  Database [ShopMarket]    Script Date: 3/27/2023 10:20:09 PM ******/
CREATE DATABASE [ShopMarket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopMarket', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopMarket.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopMarket_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ShopMarket_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ShopMarket] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopMarket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopMarket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopMarket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopMarket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopMarket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopMarket] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopMarket] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopMarket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopMarket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopMarket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopMarket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopMarket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopMarket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopMarket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopMarket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopMarket] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopMarket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopMarket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopMarket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopMarket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopMarket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopMarket] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ShopMarket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopMarket] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopMarket] SET  MULTI_USER 
GO
ALTER DATABASE [ShopMarket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopMarket] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopMarket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopMarket] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopMarket] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopMarket] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopMarket', N'ON'
GO
ALTER DATABASE [ShopMarket] SET QUERY_STORE = ON
GO
ALTER DATABASE [ShopMarket] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ShopMarket]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/27/2023 10:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 3/27/2023 10:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[DayCreated] [datetime2](7) NULL,
	[DayUpdated] [datetime2](7) NULL,
	[AvatarImage] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[Balance] [float] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[Gender] [bit] NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 3/27/2023 10:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[ProductIdAndQuantity] [nvarchar](max) NULL,
	[UserID] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/27/2023 10:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NOT NULL,
	[CategoryDescription] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companys]    Script Date: 3/27/2023 10:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companys](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Companys] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/27/2023 10:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[DayCreated] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Quantity] [int] NOT NULL,
	[Success] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[Payed] [float] NOT NULL,
	[DayPayedDone] [datetime2](7) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[DayRecive] [datetime2](7) NOT NULL,
	[DaySend] [datetime2](7) NOT NULL,
	[Shipped] [bit] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/27/2023 10:20:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[ProductCategory] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[CompanyId] [int] NOT NULL,
	[QuantityPerUnit] [int] NOT NULL,
	[ImportDay] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[AccountId] [int] NOT NULL,
	[BuyTimes] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230304141524_abc', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230304180147_add_entity_card_and_alert_colum_table_order', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230304181108_alert_column_Card', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230325062232_name', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230325135924_adf', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230325142815_update cart', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230326092616_add property', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230327064037_bui', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230327070745_add address', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230327085923_add properti', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230327100343_addd', N'7.0.3')
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountId], [LastName], [FirstName], [Email], [Password], [PhoneNumber], [Address], [City], [DayCreated], [DayUpdated], [AvatarImage], [Type], [Balance], [IsActive], [IsDelete], [Gender], [UserName]) VALUES (4, N'Boooker', N'Shop', N'shopbooker@gmail.com', N'KcmGceZ7OdA1u7T5gId915/vT9KkC4aC58TKUwS6oww=', N'0827523006', N'Ha Noi', N'Viet Nam', CAST(N'2023-03-27T21:46:29.1531633' AS DateTime2), CAST(N'2023-03-27T21:46:29.1531644' AS DateTime2), NULL, 1, 0, 1, 0, 1, N'Boooker')
INSERT [dbo].[Accounts] ([AccountId], [LastName], [FirstName], [Email], [Password], [PhoneNumber], [Address], [City], [DayCreated], [DayUpdated], [AvatarImage], [Type], [Balance], [IsActive], [IsDelete], [Gender], [UserName]) VALUES (1002, N'tuananh', N'', N'ptuananh170@gmail.com', N'hyaAs1sh3aCliotSa2U9qDFEpUn1l9uD2o/TtopeXHY=', NULL, NULL, NULL, CAST(N'2023-03-27T13:30:05.5428985' AS DateTime2), CAST(N'2023-03-27T13:30:05.3988068' AS DateTime2), NULL, 2, 0, 1, 0, 1, N'test')
INSERT [dbo].[Accounts] ([AccountId], [LastName], [FirstName], [Email], [Password], [PhoneNumber], [Address], [City], [DayCreated], [DayUpdated], [AvatarImage], [Type], [Balance], [IsActive], [IsDelete], [Gender], [UserName]) VALUES (1005, N'admin', N'admin', N'admin@admin.com', N'RsSaRsuSc+lVwRH5FYlko0JFSDUB6kEH0FN8X0MLwUk=', NULL, NULL, NULL, CAST(N'2023-03-27T16:05:12.4457907' AS DateTime2), CAST(N'2023-03-27T16:05:12.1947727' AS DateTime2), NULL, 0, 0, 1, 0, 1, N'admin')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (1, N'Công Nghệ Thông Tin', N'', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (2, N'Tâm Lý - Kĩ Năng Sống', N'Tâm lý - Kĩ năng sống là một lĩnh vực nghiên cứu và áp dụng nhằm giúp con người hiểu và quản lý tốt hơn cảm xúc, suy nghĩ và hành vi của mình trong cuộc sống.', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (3, N'Phát Triển Tâm Thức', N'Tâm th?c phát tri?n ch? khi cùng d?ng th?i v?i ba s? bi?n d?i: S? phát tri?n trí tu?, s? buông b? tâm trí và s? khoi m? ti?m th?c.', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (4, N'Học Ngoại Ngữ', N' Vai trò của ngoại ngữ là giúp sinh viên hiểu biết thêm về ngôn ngữ của loài người thông qua sự so sánh của các ngôn ngữ với nhau.', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (5, N'Tài Liệu Học Tập - Giáo Án', N'Giáo án là một tài liệu đưa ra cấu trúc của một buổi học và phác thảo nội dung mà bạn định sử dụng. ', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (6, N'Văn Học', N' là một hình thức nghệ thuật, hoặc bất kỳ một bài viết nào được coi là có giá trị nghệ thuật', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (7, N'Toán Học', N'Toán học là một ngành, một môn học đòi hỏi suy luận và trí thông minh cao. Nó chứa tất cả những gì thách thức đến bộ não của chúng ta.', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (8, N'Kỹ Năng Học Tập - Làm Việc', N'Kỹ năng học tập sẽ giúp bạn tiếp thu và học hỏi các kỹ năng mới trong quá trình làm việc nhanh hơn.', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (9, N'Truyện Cười - Tiếu Lâm', N'Truyện cười Việt Nam (còn gọi là truyện tiếu lâm) là một lĩnh vực truyện kể dân gian rộng lớn, đa dạng, phức tạp bao gồm những hình thức được gọi bằng những danh từ khác nhau như truyện tiếu lâm, truyện khôi hài, truyện trào phúng, truyện trạng, giai thoại hài hước.', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (10, N'Truyện Tranh', N'Truyện tranh, hoặc là mạn họa, là một loại sách được sử dụng để thể hiện ý tưởng bằng hình ảnh, thường kết hợp với các văn bản hoặc thông tin hình ảnh khác.', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (11, N'Chính Trị - Xã Hội Quốc Tế', N'Quan hệ chính trị quốc tế là một môn khoa học mới, trang bị cho người học những tri thức cơ bản về chính trị thế giới, hiểu rõ sự đa dạng và tính phức tạp', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (12, N'Chủ Tịch Hồ Chí Minh', N'Kể về cuộc đời của Chủ Tịch Hồ Chí Minh', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (13, N'Chăm Sóc Sức Khỏe', N'Dạy cách Chăm Sóc Sức Khỏe, nâng cao chất lượng cuộc sống', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (14, N'Tôn Giáo', N'Một cách định nghĩa, đôi khi được gọi là "lối theo chức năng", định nghĩa tôn giáo là bất cứ hệ thống tín ngưỡng và phong tục ', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (15, N'Pháp Luật', N'Pháp luật là một hệ thống các quy tắc xử sự do Nhà nước đặt ra (hoặc thừa nhận) có tính quy phạm phổ biến, tính xác định chặt chẽ', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (16, N'Thiết Kế Mĩ Thuật', N'Thiết kế Mỹ thuật số/ Nghệ thuật số là ngành tạo ra những sản phẩm thiết kế phục vụ truyền thông quảng cáo, game, phim ảnh bằng cách ứng dụng các công nghệ kỹ thuật số hiện đại như Motion Capture (Công nghệ ghi hình chuyển động), Visual Effects (Hiệu ứng hình ảnh), Animation (Hoạt họa)...', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (17, N'Địa Lý ,Thiên Văn', N'Nó nghiên cứu sự phát triển, tính chất vật lý, hoá học, khí tượng học, và chuyển động của các vật thể vũ trụ, cũng như sự hình thành và phát triển của vũ trụ.', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (18, N'Khoa Học Tự Nhiên', N'Khoa học tự nhiên, hay Tự nhiên học, (tiếng Anh:Natural science) là một nhánh của khoa học, có mục đích nhận thức, mô tả, giải thích và tiên đoán', 0)
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [CategoryDescription], [IsDeleted]) VALUES (19, N'Kiến Trúc - Xây Dựng', N'Kiến trúc xây dựng là sự triển khai sáng tạo các công trình xây dựng dựa trên một mục đích cụ thể nào đó.', 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Companys] ON 

INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (1, N'Magna Praesent Interdum Incorporated', N'The company produces a wide range of electronics, including desktop and laptop computers, tablets, smartphones, networking equipment, and gaming devices.', N'1-433-763-4450', N'faucibus.morbi@protonmail.edu', N'Adipiscing, Street', N'Galway', 0, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (2, N'Eget Ipsum Donec Incorporated', N'designs, manufactures, and markets smartphones, tablets, personal computers (PCs), portable and wearable devices. The company also offers software and related services, accessories, and third-party digital content and applications.', N'1-408-561-6306', N'laoreet.ipsum@yahoo.couk', N'Neque Road', N'Bengkulu', 0, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (3, N'Sed PC', N'engages in the research and development of user interface, industrial design, information and communication technologies related software and hardware, and electronic sports related applications.', N'1-732-137-8743', N'sit.amet@google.couk', N'P.O. Box 807, 4672 Mi Rd.', N'Chepén', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (4, N'Semper Tellus Associates', N'Semper Tellus Associates is a communications and information technology company that operates in the areas of network infrastructure and advanced technologies. It offers fixed networks, mobile phones, WiFi systems, IP routing, subscriber data management, network implementation, network modernization, IoT, and 5G services.', N'1-305-527-2142', N'eu.nibh@hotmail.net', N'Amet Rd.', N'Ceuta', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (5, N'Lectus A Sollicitudin PC', N'The company produces a wide range of electronics, including desktop and laptop computers, tablets, smartphones, networking equipment, and gaming devices.', N'1-866-818-3345', N'risus.a@aol.org', N'599-5299 Sed Rd.', N'Seevetal', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (6, N'Apple Inc.', N'Apple is one of the technology giants that gains the users’ interests most. Not just a company or corporation, over the years, the way Apple operates and its leadership style has created a cultural trend that many modern technology companies follow.', N'42350-2344', N'apple@gmail.com', N'Cupertino', N'California', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (7, N'Microsoft Corp.', N'Microsoft strived to lead the home computer operating system market with MS-DOS in the mid-1980s. The company’s stock after its release went up in price rapidly, which has created 4 billionaires and 12,000 millionaires in the company.', N'8285-2895', N'microsoft@gmail.com', N'Redmond', N'Washington', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (8, N'Alphabet Inc.', N'Alphabet Inc. is a parent company of an American multinational technology corporation headquartered in Mountain View, California.', N'58282-2822', N'Alphabet.com', N'Adipiscing', N'Seevetal', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (9, N'Amazon.com Inc.', N'Amazon.com, Inc is an American multinational technology company focusing on e-commerce, cloud computing, online advertising, digital streaming, and artificial intelligence. ', N'28256-7822', N'Amazon@gmail.com', N'Minato', N'Tokyo', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (10, N'NVIDIA Corp.', N'NVIDIA is a multinational corporation that develops graphics processing units (GPUs), and chipset technology for workstations, personal computers, and mobile devices. The Santa Clara, California-based company became a major supplier of integrated circuits (ICS) such as graphics processing units (GPUs), graphics chipsets used in cards, delivered video game consoles, and personal computer motherboards.', N'4892-2423', N'nvidia@gmail.com', N'Casano', N'Italia', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (11, N'Berkshire Hathaway Inc.', N'Berkshire Hathaway Inc. is an American multinational conglomerate holding company headquartered in Omaha, Nebraska, United States. Its main business and source of capital is insurance, from which it invests the float (the retained premiums) in a broad portfolio of subsidiaries, equity positions and other securities.', N'3833-2452', N'Berkshire@gmail.com', N'Sydney', N'Sydney', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (12, N'Tesla Inc.', N'Tesla, Inc. is an American multinational automotive and clean energy company headquartered in Austin, Texas. Tesla designs and manufactures electric vehicles (electric cars and trucks), battery energy storage from home to grid-scale, solar panels and solar roof tiles, and related products and services. Tesla is one of the world most valuable companies and is, as of 2023, the world most valuable automaker. ', N'39393-234', N'tesla@gmail.com', N'Silicon', N'New York', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (13, N'Nestle.', N'Nestle is a Swiss multinational food and drink processing conglomerate corporation headquartered in Vevey, Vaud, Switzerland. It is the largest publicly held food company in the world, measured by revenue and other metrics, since 2014.', N'37347-3832', N'Nestle@gmail.com', N'Tukey', N'Turkey', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (14, N'Archer Daniels Midland Company.', N'The Archer-Daniels-Midland Company, commonly known as ADM, is an American multinational food processing and commodities trading corporation founded in 1902 and headquartered in Chicago, Illinois. The company operates more than 270 plants and 420 crop procurement facilities worldwide, where cereal grains and oilseeds are processed into products used in food, beverage, nutraceutical, industrial, and animal feed markets worldwide.', N'3832-2342', N'Archer@gmail.com', N'New York', N'New York', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (15, N'Cargill', N'Cargill, Incorporated, is a privately held American global food corporation based in Minnetonka, Minnesota, and incorporated in Wilmington, Delaware. Founded in 1865, it is the largest privately held corporation in the United States in terms of revenue.', N'3822-3424', N'Cargill@gmail.com', N'Galway', N'London', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (16, N'Sysco Corporation', N'Sysco Corporation (short for Systems and Services Company) is an American multinational corporation involved in marketing and distributing food products, smallwares, kitchen equipment and tabletop items to restaurants, healthcare and educational facilities, hospitality businesses like hotels and inns, and wholesale to other companies that provide foodservice (like Aramark and Sodexo).', N'28498-2424', N'sysco@gmail.com', N'Texas', N'Sydney', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (17, N'Viettel', N'Viettel or Viettel Group, formally the Viettel Military Industry and Telecoms Group the Army Industry - Telecommunications Group) is a Vietnamese multinational telecommunications company headquartered in Hanoi, Vietnam. Viettel is the largest mobile network operator in Vietnam. It is a state-owned enterprise and operated by the Ministry of National Defence, make it practically a military-associated corporation.', N'9510-1924', N'viettel@gmail.com', N'Galway', N'Manago', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (18, N'Huawei Technologies Co. Ltd.', N'Huawei Technologies Co., Ltd is a Chinese multinational technology corporation headquartered in Shenzhen, Guangdong province, that designs, develops, manufactures and sells telecommunications equipment, consumer electronics, smart devices and various rooftop solar power products.', N'1923-2522', N'huawei@gmail.com', N'Manchester', N'London', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (19, N'Baidu Inc', N'Baidu, Inc. is a Chinese multinational technology company specializing in Internet-related services, products, and artificial intelligence (AI), headquartered in Beijing s Haidian District. It is one of the largest AI and Internet companies in the world. The holding company of the group is incorporated in the Cayman Islands', N'141-1424', N'baidu@gmail.com', N'Asenal', N'London', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (20, N'HP Inc.', N'The second incarnation of Hewlett-Packard, Inc. is an American multinational information technology company headquartered in Palo Alto, California, that develops personal computers (PCs), printers and related supplies, as well as 3D printing solutions.', N'1315-8181', N'hpinc@gmail.com', N'Notingham', N'Mexico', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (21, N'Intel Corporation', N'Intel Corporation (commonly known as Intel) is an American multinational corporation and technology company headquartered in Santa Clara, California.', N'9456-2821', N'intel@gmail.com', N'Ohio', N'Mexico', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (22, N'Oracle Corporation', N'Oracle Corporation is an American multinational computer technology corporation headquartered in Austin, Texas. ... In 2020, Oracle was the third-largest software ...', N'1940-2832', N'Oracle@gmail.com', N'Huiy', N'Brazil', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (23, N'Samsung Electronics Co. Ltd.', N'Samsung Electronics Co., Ltd is a South Korean multinational electronics corporation headquartered in Yeongtong-gu, Suwon, South Korea. ', N'5492-3831', N'Electronics@gmail.com', N'Yeongtong-gu', N'Suwon', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (24, N'Sony Corporation', N'Sony Group Corporation commonly known as simply Sony (stylized as SONY), is a Japanese multinational conglomerate corporation headquartered in Minato, ...', N'1900-1292', N'sony@gmail.com', N'Minato', N'Tokyo', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (25, N'Coca-Cola Company', N'The Coca-Cola Company is an American multinational corporation founded in 1892, best known as the producer of Coca-Cola.', N'1231-3421', N'cocacola@gmail.com', N'Atlanta', N'Georgia', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (26, N'PepsiCo Inc.', N'PepsiCo, Inc. is an American multinational food, snack, and beverage corporation headquartered in Harrison, New York, in the hamlet of Purchase.', N'1313-12312', N'pepsi@gmail.com', N'Harrison', N'New York', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (27, N'Keurig Dr Pepper Inc.', N'Keurig Dr Pepper Inc., formerly Green Mountain Coffee Roasters (1981–2014) and Keurig Green Mountain (2014–2018), is a publicly traded American beverage and coffeemaker conglomerate with headquarters in Burlington, Massachusetts. Formed in July 2018 with the merger of Keurig Green Mountain and Dr Pepper Snapple Group', N'4843-2423', N'peper@gmail.com', N'Burlington', N'Massachusetts', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (28, N'Diageo plc', N'Diageo plc is a British multinational alcoholic beverage company, with its headquarters in London, England. It operates from 132 sites around the world.', N'8295-2785', N'diageo@gmail.com', N'London', N'London', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (29, N'7UP', N'Up or Seven Up is an American brand of lemon-lime-flavored non-caffeinated soft drink. The brand and formula are owned by Keurig Dr Pepper although the', N'9495-1834', N'sevenup@gmail.com', N'Lagos', N'Nigeria', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (30, N'Unilever', N'Unilever plc is a British multinational consumer goods company with headquarters in London, England. Unilever products include food, condiments.', N'9376-1264', N'unilever', N'London', N'London', 1, 0)
INSERT [dbo].[Companys] ([CompanyId], [Name], [Description], [PhoneNumber], [Email], [Address], [City], [IsActive], [IsDelete]) VALUES (31, N'Carlsberg Group', N'Carlsberg A/S is a Danish multinational brewer. Founded in 1847 by J. C. Jacobsen, the companys headquarters is in Copenhagen, Denmark.', N'3784-4127', N'carl@gmail.com', N'Copenhagen', N'Denmark', 1, 0)
SET IDENTITY_INSERT [dbo].[Companys] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [ProductId], [AccountId], [DayCreated], [ModifiedDate], [Quantity], [Success], [TotalPrice], [Payed], [DayPayedDone], [IsDelete], [DayRecive], [DaySend], [Shipped], [Address]) VALUES (1, 1, 1002, CAST(N'2023-03-27T14:08:58.6354846' AS DateTime2), CAST(N'2023-03-27T14:08:58.6355494' AS DateTime2), 3, 0, 151.5, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Ha Noi')
INSERT [dbo].[Orders] ([OrderId], [ProductId], [AccountId], [DayCreated], [ModifiedDate], [Quantity], [Success], [TotalPrice], [Payed], [DayPayedDone], [IsDelete], [DayRecive], [DaySend], [Shipped], [Address]) VALUES (2, 2, 1002, CAST(N'2023-03-27T15:22:15.3792354' AS DateTime2), CAST(N'2023-03-27T15:22:15.3793932' AS DateTime2), 1, 0, 70.2, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Ha Noi, Thanh Nhan')
INSERT [dbo].[Orders] ([OrderId], [ProductId], [AccountId], [DayCreated], [ModifiedDate], [Quantity], [Success], [TotalPrice], [Payed], [DayPayedDone], [IsDelete], [DayRecive], [DaySend], [Shipped], [Address]) VALUES (3, 3, 1002, CAST(N'2023-03-27T15:22:15.3910863' AS DateTime2), CAST(N'2023-03-27T15:22:15.3910867' AS DateTime2), 1, 0, 23.5, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'Ha Noi, Thanh Nhan')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (1, N'Vào cõi Bác xưa', N'Tuyển thơ tập hợp 141 tác phẩm của 115 nhà thơ đương đại Việt Nam và nước ngoài viết về Bác Hồ trong suốt hơn 75 năm qua, kể từ Cách mạng mùa thu tháng Tám năm 1945 cho đến nay.', N'2;3;4', 50.5, 100, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 15, 1, CAST(N'2022-06-18T00:00:00.0000000' AS DateTime2), 1, 1, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (2, N'Những dấu ấn lịch sử về Hồ Chí Minh và Đảng do Người sáng lập', N'Cuốn sách được viết bởi PGS.TS Đàm Đức Vượng, người đã có 40 năm nghiên cứu về Đảng Cộng sản Việt Nam và Chủ tịch Hồ Chí Minh; ông từng giữ nhiều cương vị quan trọng trong các cơ quan Trung ương như Chuyên viên cao cấp Ban Nghiên cứu lịch sử Đảng Trung ương.', N'1;4;5', 70.2, 100, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 2, 1, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 1, 1, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (3, N'Thế Giới Trong Bạn', N'Thế Giới Trong Bạn” (tựa Gốc: “The World Within”) Tổng Hợp Những Cuộc Hỏi Đáp Giữa Jiddu Krishnamurti Với Những Người Đã Tìm Đến Ông Vào Giai Đoạn Ông Sống “lánh Đời” Hồi Thế Chiến Thứ 2. Dù Vậy, Cuốn Sách Vẫn Mang Tính Thời Đại Và Có Liên Hệ Trực Tiếp Với Cuộc Sống Ngày Nay.', N'5;6;2', 23.5, 100, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 19, 1, CAST(N'2023-01-14T00:00:00.0000000' AS DateTime2), 1, 1, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (4, N'Âm Dương Cuộc Sống Đời Thường', N'Từ Xưa Đến Nay, Hai Thái Cực Âm Dương Đã Trở Thành Cái Hồn, Cái Thiêng Trong Văn Hóa Đời Sống Việt. Nó Không Đơn Thuần Chỉ Là Quan Niệm Mà Cao Hơn Còn Là Triết Lý Của Người Á Đông. Theo Thời Gian, Những Biểu Hiện Sinh Động Của Tư Tưởng Âm Dương Vẫn Hằn Sâu Trong Nếp Nghĩ Truyền Thống Và Hiện Đại. Điều Đó Minh Chứng Sức Ảnh Hưởng Không Cùng Của Triết Lý Này Cả Trên Chiều Rộng Và Chiều Sâu Của Một Nền Văn Hóa.', N'4;2;5', 34.2, 80, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 12, 1, CAST(N'2022-09-08T00:00:00.0000000' AS DateTime2), 1, 1, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (5, N'Từ Làng Sen', N'Từ Làng Sen Là Cuốn Sách Gồm 25 Bức Tranh Về Cuộc Đời Của Chủ Tịch Hồ Chí Minh, Tác Phẩm Có Mối Quan Hệ Gắn Bó Với Búp Sen Xanh - Cuốn Tiểu Thuyết Đầu Tiên Viết Một Cách Trọn Vẹn Về Thời Niên Thiếu Cho Đến Khi Ra Đi Tìm Đường Cứu Nước Của Hồ Chủ Tịch.', N'1;2;3', 64.4, 57, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 14, 1, CAST(N'2022-09-26T00:00:00.0000000' AS DateTime2), 1, 1, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (6, N'An Toàn Thông Tin', N'“An Toàn Thông Tin” Giới Thiệu Tổng Quan Nhất Về ATTT, Cơ Sở Toán Học, Mã Hóa Thông Tin, Vấn Đề Xác Nhận Và Chữ Ký Số, Quản Lý Khóa Và Ẩn-Giấu Tin Trong ATTT.', N'3;4;5;6;7;8;9', 73.2, 36, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 15, 1, CAST(N'2023-02-19T00:00:00.0000000' AS DateTime2), 0, 0, 0, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (7, N'An Ninh Mạng Trong Cuộc Cách Mạng Công Nghiệp 4.0', N'Trước Tình Hình An Ninh Mạng Trong Môi Trường Của Cuộc Cách Mạng Công Nghiệp 4.0 Hiện Nay, Đặt Ra Nhiệm Vụ Hết Sức Cấp Bách Là Bảo Vệ An Ninh Mạng Và Phòng Chống.', N'1;3;5', 84.3, 47, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 11, 1, CAST(N'2022-06-06T00:00:00.0000000' AS DateTime2), 0, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (8, N'Cấu Trúc Dữ Liệu Và Thuật Toán', N'Cấu Trúc Dữ Liệu Và Giải Thuật(CTDL & GT) Là Sự Kết Hợp Và Áp Dụng Một Hoặc Nhiều Cấu Trúc Dữ Liệu Nào Đó Vào Một Hoặc Nhiều Thuật Toán Nào Đó Để Có Được Đầu Ra Mong Muốn Một Cách Tối Ưu Và Tốt Nhất Khi Dữ Liệu Có Số Lượng Cực Lớn.', N'2;3;5', 24.6, 12, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 10, 2, CAST(N'2023-02-01T00:00:00.0000000' AS DateTime2), 1, 1, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (9, N'Thương Mại Điện Tử Căn Bản', N'Tổ Chức Thương Mại Thế Giới WTO Định Nghĩa: “ TMĐT Bao Gồm Việc Sản Xuất, Quảng Cáo, Bán Hàng Và Phân Phối Sản Phẩm Được Mua Bán Và Thanh Toán Trên Mạng ...', N'5;4;6', 52.6, 73, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 29, 2, CAST(N'2022-08-29T00:00:00.0000000' AS DateTime2), 0, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (10, N'Internet Vạn Vật (IoT) Chuyển Đổi Số Hay Là Chết', N'Cuốn sách giải thích những quy tắc mới trong “cuộc chơi” chuyển đổi số; gợi ý những bước đi đơn giản và thực tế để bạn không chỉ có thể tồn tại mà còn thành công với sự chuyển đổi số; đồng thời cung cấp cho những kiến thức cần thiết để bạn nắm bắt được những quy tắc mới.', N'10;11;12', 24.6, 47, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 12, 2, CAST(N'2022-08-22T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (11, N'Đương Đầu Với Thất Bại', N'Trong cuộc sống, ai trong chúng ta cũng sợ thất bại. Nhưng nếu bạn để cho nỗi sợ hãi kiểm soát sự lựa chọn của mình, thì bạn đang xây dựng tương lai của bạn trên nỗi sợ hãi.', N'5;6;8', 12.6, 62, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 23, 3, CAST(N'2022-01-18T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (12, N'Tuổi Teen Đáng Giá Bao Nhiêu?', N'Tuổi thiếu niên là tuổi của ước mơ và hoài bão. Nó gắn liền với khát vọng chinh phục thử thách và giải được mật mã cuộc đời. Khát vọng luôn xanh và cuộc sống luôn đẹp, nhưng trong một thời khắc nào đó, có thể nhiều bạn trẻ đã thấy cuộc đời như một mớ bòng bong của những điều bỡ ngỡ với bao trăn trở không dễ tỏ bày. Đi qua tuổi thơ, cuộc đời mở ra trước mắt bạn một hành trình dài, nhiều hoa hồng nhưng cũng không ít chông gai.', N'1;15;18', 73.2, 62, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 4, 1, CAST(N'2022-08-21T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (13, N'Sách Hướng Dẫn Nói Lời Cảm Ơn', N'Trong cuốn Sách hướng dẫn nói lời cảm ơn rất được hoan nghênh của mình, tác giả Robyn Spizman cung cấp cho độc giả hàng trăm cách thể hiện lòng biết ơn', N'3;5;7', 84.3, 71, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 7, 1, CAST(N'2022-01-17T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (14, N'Những Kỹ Năng Để Sống Hạnh Phúc', N'Cách tạo ra một kế hoạch hạnh phúc: - Làm rõ lý do tại sao bản thân muốn có một cuộc sống hạnh phúc', N'6;15;18', 24.6, 14, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 6, 1, CAST(N'2022-06-26T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (15, N'Thức Tỉnh Điều Vô Hình', N'Hiếm có cuốn sách nào viết về tâm linh lại được kể với ngôn ngữ lôi cuốn độc giả như Thức tỉnh điều vô hình , thậm chí còn đạt đến vẻ đẹp ngôn từ như một tác phẩm văn chương thực thụ, giàu cảm xúc.', N'12;13;14', 52.6, 63, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 3, 1, CAST(N'2023-02-15T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (16, N'Viết Lên Hy Vọng', N'Đối với người giáo viên, cần phải có kiến thức, có hiểu biết sư phạm về quy luật xã hội, có khả năng dùng lời nói để tác động đến tâm hồn học sinh, có kỹ năng đặc sắc nhìn nhận con người và cảm thấy những rung động tinh tế nhất của trái tim con người', N'5;7;9', 24.6, 37, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 10, 1, CAST(N'2022-03-28T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (17, N'Đắc Nhân Tâm', N'Đắc nhân tâm (Được lòng người), tên tiếng Anh là How to Win Friends and Influence People là một quyển sách nhằm tự giúp bản thân (self-help)', N'1;3;5', 12.6, 84, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 4, 1, CAST(N'2023-02-07T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (18, N'Trở Về Từ Cõi Sáng', N'Trở Về Từ Cõi Sáng viết về đời sống sau khi chết. Nếu khi còn sống chúng ta biết và hiểu về sự chết thì chết không có gì là đáng sợ nữa.', N'2;3;5', 24.6, 36, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 12, 1, CAST(N'2022-06-06T00:00:00.0000000' AS DateTime2), 1, 0, 4, 1000)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (19, N'Tiếng Nhật Cho Mọi Người', N'Nguyên gốc bộ này là bộ "Minna no nihongo" vô cùng nổi tiếng để học tiếng Nhật sơ cấp.', N'5;4;6', 52.6, 25, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 14, 1, CAST(N'2022-12-25T00:00:00.0000000' AS DateTime2), 1, 0, 4, 10004)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (20, N'Thay Đổi Cuộc Sống Với Nhân Số Học', N'Cuốn sách Thay đổi cuộc sống với Nhân số học là tác phẩm được chị Lê Đỗ Quỳnh Hương phát triển từ tác phẩm gốc “The Complete Book of Numerology”', N'10;11;12', 24.6, 73, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 16, 1, CAST(N'2022-10-26T00:00:00.0000000' AS DateTime2), 1, 0, 4, 10002)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (21, N'Cách Mạng Bản Thân', N'Cuốn sách này sẽ đưa bạn vào cuộc hành trình khám phá dấu ấn hình thành nên con người bạn hôm nay từ đó học cách nhận thức rõ về chính mình để có một cái nhìn khách quan hơn trong cuộc sống.', N'4;6;7', 12.6, 83, N'https://usth.edu.vn/wp-content/uploads/2022/05/nganh-an-toan-thong-tin-usth-tuyen-sinh_1.jpg;https://www.evn.com.vn/userfile/User/minhhanh/images/2022/9/15922antt.jpg;https://cdn.tgdd.vn/Files/2021/12/19/1405372/antoanmang_1280x720-800-resize.jpg', 13, 1, CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), 1, 0, 4, 100034)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (24, N'Sach Moi', NULL, N'1;3;5;6;7;9', 50, 0, N'https://phutungnhapkhauchinhhang.com/wp-content/uploads/2020/06/default-thumbnail.jpg;https://phutungnhapkhauchinhhang.com/wp-content/uploads/2020/06/default-thumbnail.jpg;https://phutungnhapkhauchinhhang.com/wp-content/uploads/2020/06/default-thumbnail.jpg', 0, 0, CAST(N'2023-03-27T22:13:49.8247354' AS DateTime2), 1, 0, 0, 100034)
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [ProductCategory], [Price], [Quantity], [Image], [CompanyId], [QuantityPerUnit], [ImportDay], [IsActive], [IsDelete], [AccountId], [BuyTimes]) VALUES (25, N'New Booker', NULL, N'1;3', 50, 0, N'https://phutungnhapkhauchinhhang.com/wp-content/uploads/2020/06/default-thumbnail.jpg;https://phutungnhapkhauchinhhang.com/wp-content/uploads/2020/06/default-thumbnail.jpg;https://phutungnhapkhauchinhhang.com/wp-content/uploads/2020/06/default-thumbnail.jpg', 0, 0, CAST(N'2023-03-27T22:16:37.0648319' AS DateTime2), 1, 0, 4, 10003)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Gender]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DayRecive]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DaySend]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Shipped]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [Address]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [AccountId]
GO
USE [master]
GO
ALTER DATABASE [ShopMarket] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [BANVEMAYBAY]    Script Date: 12/10/2021 10:16:47 PM ******/
CREATE DATABASE [BANVEMAYBAY]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BANVEMAYBAY', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BANVEMAYBAY.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BANVEMAYBAY_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BANVEMAYBAY_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BANVEMAYBAY] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BANVEMAYBAY].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BANVEMAYBAY] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET ARITHABORT OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BANVEMAYBAY] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BANVEMAYBAY] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BANVEMAYBAY] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BANVEMAYBAY] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BANVEMAYBAY] SET  MULTI_USER 
GO
ALTER DATABASE [BANVEMAYBAY] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BANVEMAYBAY] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BANVEMAYBAY] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BANVEMAYBAY] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BANVEMAYBAY] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BANVEMAYBAY] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BANVEMAYBAY] SET QUERY_STORE = OFF
GO
USE [BANVEMAYBAY]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 12/10/2021 10:16:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[type] [varchar](255) NOT NULL,
	[link] [varchar](255) NULL,
	[tableid] [int] NULL,
	[parentid] [int] NOT NULL,
	[orders] [int] NOT NULL,
	[position] [varchar](255) NOT NULL,
	[created_at] [smalldatetime] NOT NULL,
	[created_by] [int] NULL,
	[updated_at] [smalldatetime] NOT NULL,
	[updated_by] [int] NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 12/10/2021 10:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[guestTotal] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[CusId] [int] NULL,
	[gioitinh] [nvarchar](255) NOT NULL,
	[quoctich] [nvarchar](255) NULL,
	[mess] [nvarchar](255) NULL,
	[phone] [varchar](255) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[total] [float] NOT NULL,
	[created_ate] [smalldatetime] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordersdetail]    Script Date: 12/10/2021 10:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordersdetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[orderid] [int] NOT NULL,
	[ticketId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
 CONSTRAINT [PK_ordersdetail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[post]    Script Date: 12/10/2021 10:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[post](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[topid] [int] NULL,
	[title] [nvarchar](max) NOT NULL,
	[slug] [varchar](255) NOT NULL,
	[detail] [ntext] NULL,
	[img] [varchar](255) NULL,
	[type] [varchar](50) NULL,
	[created_at] [smalldatetime] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_at] [smalldatetime] NOT NULL,
	[updated_by] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_post] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 12/10/2021 10:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[parentId] [int] NOT NULL,
	[accessName] [varchar](255) NOT NULL,
	[description] [nvarchar](225) NULL,
	[GropID] [varchar](50) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[parentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ticket]    Script Date: 12/10/2021 10:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ticket](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[description] [ntext] NULL,
	[flightCode] [char](50) NULL,
	[airline] [nvarchar](255) NULL,
	[airport] [nvarchar](255) NULL,
	[ticketType] [nvarchar](255) NULL,
	[img] [nvarchar](255) NULL,
	[departure_address] [nvarchar](255) NULL,
	[arrival_address] [nvarchar](255) NULL,
	[departure_date] [date] NULL,
	[guestTotal] [int] NULL,
	[price] [float] NULL,
	[priceSale] [float] NULL,
	[Sold] [int] NOT NULL,
	[created_at] [date] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_at] [date] NOT NULL,
	[updated_by] [int] NOT NULL,
	[status] [int] NOT NULL,
	[departure_time] [time](7) NULL,
	[arrival_time] [time](7) NULL,
 CONSTRAINT [PK__ticket__3213E83F9A39E097] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[topic]    Script Date: 12/10/2021 10:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[topic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[slug] [varchar](255) NOT NULL,
	[parentid] [int] NOT NULL,
	[orders] [int] NOT NULL,
	[created_at] [smalldatetime] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_at] [smalldatetime] NOT NULL,
	[updated_by] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_topic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 12/10/2021 10:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[fullname] [nvarchar](max) NULL,
	[username] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[gender] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[img] [nvarchar](max) NULL,
	[access] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[created_by] [int] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[updated_by] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[menu]  WITH CHECK ADD  CONSTRAINT [FK_menu_to_user] FOREIGN KEY([created_by])
REFERENCES [dbo].[user] ([ID])
GO
ALTER TABLE [dbo].[menu] CHECK CONSTRAINT [FK_menu_to_user]
GO
ALTER TABLE [dbo].[ordersdetail]  WITH CHECK ADD  CONSTRAINT [FK_orderDetail_to_order11] FOREIGN KEY([orderid])
REFERENCES [dbo].[order] ([ID])
GO
ALTER TABLE [dbo].[ordersdetail] CHECK CONSTRAINT [FK_orderDetail_to_order11]
GO
ALTER TABLE [dbo].[ordersdetail]  WITH CHECK ADD  CONSTRAINT [FK_orderDetail_to_product] FOREIGN KEY([ticketId])
REFERENCES [dbo].[ticket] ([id])
GO
ALTER TABLE [dbo].[ordersdetail] CHECK CONSTRAINT [FK_orderDetail_to_product]
GO
ALTER TABLE [dbo].[post]  WITH CHECK ADD  CONSTRAINT [FK_topic_to_post1] FOREIGN KEY([topid])
REFERENCES [dbo].[topic] ([ID])
GO
ALTER TABLE [dbo].[post] CHECK CONSTRAINT [FK_topic_to_post1]
GO
ALTER TABLE [dbo].[topic]  WITH CHECK ADD  CONSTRAINT [FK_topic_to_user] FOREIGN KEY([created_by])
REFERENCES [dbo].[user] ([ID])
GO
ALTER TABLE [dbo].[topic] CHECK CONSTRAINT [FK_topic_to_user]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_to_role] FOREIGN KEY([access])
REFERENCES [dbo].[role] ([parentId])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_to_role]
GO
USE [master]
GO
ALTER DATABASE [BANVEMAYBAY] SET  READ_WRITE 
GO

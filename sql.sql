USE [BookStore]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 6/8/2023 5:56:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[last_name] [varchar](50) NULL,
	[first_name] [varchar](50) NULL,
	[phone] [varchar](20) NULL,
	[address] [varchar](100) NULL,
	[city] [varchar](50) NULL,
	[state] [varchar](50) NULL,
	[zip] [varchar](10) NULL,
	[email_address] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 6/8/2023 5:56:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NULL,
	[type] [varchar](50) NULL,
	[pub_id] [int] NULL,
	[price] [decimal](10, 2) NULL,
	[advance] [decimal](10, 2) NULL,
	[royalty] [int] NULL,
	[ytd_sales] [int] NULL,
	[notes] [varchar](max) NULL,
	[published_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookAuthor]    Script Date: 6/8/2023 5:56:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookAuthor](
	[author_id] [int] NOT NULL,
	[book_id] [int] NOT NULL,
	[author_order] [int] NULL,
	[royalty_percentage] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[author_id] ASC,
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 6/8/2023 5:56:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[pub_id] [int] IDENTITY(1,1) NOT NULL,
	[publisher_name] [varchar](255) NULL,
	[city] [varchar](100) NULL,
	[state] [varchar](100) NULL,
	[country] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[pub_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/8/2023 5:56:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_desc] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/8/2023 5:56:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[email_address] [varchar](255) NULL,
	[password] [varchar](100) NULL,
	[source] [varchar](50) NULL,
	[first_name] [varchar](50) NULL,
	[middle_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[role_id] [int] NULL,
	[pub_id] [int] NULL,
	[hire_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (1, N'Thang', N'Nguyen Dinh', N'0357775073', N'Xa Lien Ha', N'Ha Noi', N'Viet Nam', N'0508', N'thangga05082001@gmail.com')
INSERT [dbo].[Author] ([author_id], [last_name], [first_name], [phone], [address], [city], [state], [zip], [email_address]) VALUES (2, N'Dinh Nam', N'Nguyen', N'1', N'1', N'Ha Tay', N'1', N'1', N'thang@gmail.com')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (1, N'Co gai ban dam', N'Truyen thieu nhi', 1, CAST(1.30 AS Decimal(10, 2)), NULL, 1, 500, N'Hay', CAST(N'2023-06-01' AS Date))
INSERT [dbo].[Book] ([book_id], [title], [type], [pub_id], [price], [advance], [royalty], [ytd_sales], [notes], [published_date]) VALUES (4, N'1', N'1', 2, CAST(1.00 AS Decimal(10, 2)), NULL, 1, 1, N'1', CAST(N'2023-06-01' AS Date))
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (1, N'Nguyen Dinh Thang', N'Ha Tay', N'Ha Noi', N'Viet Nam')
INSERT [dbo].[Publisher] ([pub_id], [publisher_name], [city], [state], [country]) VALUES (2, N'Nguyen Thuy Nga', N'Ha Noi', N'Ha Noi', N'Viet Nam')
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([role_id], [role_desc]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([role_id], [role_desc]) VALUES (2, N'Editor')
INSERT [dbo].[Role] ([role_id], [role_desc]) VALUES (3, N'Contributor')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (1, N'thangga05082001@gmail.com', N'123456', N'google.com', N'Nguyen', N'Dinh', N'Thang', 1, NULL, CAST(N'2023-06-07' AS Date))
INSERT [dbo].[User] ([user_id], [email_address], [password], [source], [first_name], [middle_name], [last_name], [role_id], [pub_id], [hire_date]) VALUES (2, N'thang@gmail.com', N'123', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([pub_id])
REFERENCES [dbo].[Publisher] ([pub_id])
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD FOREIGN KEY([author_id])
REFERENCES [dbo].[Author] ([author_id])
GO
ALTER TABLE [dbo].[BookAuthor]  WITH CHECK ADD FOREIGN KEY([book_id])
REFERENCES [dbo].[Book] ([book_id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([pub_id])
REFERENCES [dbo].[Publisher] ([pub_id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO

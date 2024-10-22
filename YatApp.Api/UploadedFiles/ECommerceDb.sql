
/****** Object:  Table [dbo].[Categories]    Script Date: 6/26/2024 6:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[Description] [nvarchar](150) NULL,
	[defaultImage] [varchar](50) NULL,
	[SuperCategoryId] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 6/26/2024 6:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 6/26/2024 6:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Recid] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[amount] [int] NULL,
	[UnitPrice] [decimal](5, 2) NULL,
	[Discount] [decimal](2, 2) NULL,
 CONSTRAINT [PK_Order_Details] PRIMARY KEY CLUSTERED 
(
	[Recid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/26/2024 6:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/26/2024 6:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[UnitPrice] [decimal](5, 2) NOT NULL,
	[DefaultImage] [nvarchar](50) NULL,
	[Imgs] [varchar](250) NULL,
	[Rate] [decimal](2, 1) NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description], [defaultImage], [SuperCategoryId]) VALUES (1, N'Electronics', N'Category for electronic devices', N'electronics.jpg', NULL)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description], [defaultImage], [SuperCategoryId]) VALUES (2, N'Clothing', N'Category for clothing items', N'clothing.jpg', NULL)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description], [defaultImage], [SuperCategoryId]) VALUES (3, N'Books', N'Category for books', N'books.jpg', NULL)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description], [defaultImage], [SuperCategoryId]) VALUES (4, N'Home & Kitchen', N'Category for home and kitchen products', N'home_kitchen.jpg', 3)
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description], [defaultImage], [SuperCategoryId]) VALUES (5, N'Toys & Games', N'Category for toys and games', N'toys_games.jpg', 4)
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (1, N'Ahmed')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (2, N'Mohamed')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (3, N'Mona')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (4, N'Ali')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (5, N'Adel')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([Recid], [OrderId], [ProductId], [amount], [UnitPrice], [Discount]) VALUES (1, 1, 1, 2, CAST(25.00 AS Decimal(5, 2)), CAST(0.05 AS Decimal(2, 2)))
GO
INSERT [dbo].[OrderDetails] ([Recid], [OrderId], [ProductId], [amount], [UnitPrice], [Discount]) VALUES (2, 1, 2, 1, CAST(15.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(2, 2)))
GO
INSERT [dbo].[OrderDetails] ([Recid], [OrderId], [ProductId], [amount], [UnitPrice], [Discount]) VALUES (3, 2, 3, 3, CAST(10.00 AS Decimal(5, 2)), CAST(0.10 AS Decimal(2, 2)))
GO
INSERT [dbo].[OrderDetails] ([Recid], [OrderId], [ProductId], [amount], [UnitPrice], [Discount]) VALUES (4, 2, 4, 1, CAST(50.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(2, 2)))
GO
INSERT [dbo].[OrderDetails] ([Recid], [OrderId], [ProductId], [amount], [UnitPrice], [Discount]) VALUES (5, 3, 1, 2, CAST(30.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(2, 2)))
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [OrderDate]) VALUES (1, 1, CAST(N'2024-06-21T10:30:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [OrderDate]) VALUES (2, 2, CAST(N'2024-06-20T15:45:00.000' AS DateTime))
GO
INSERT [dbo].[Orders] ([OrderId], [CustomerId], [OrderDate]) VALUES (3, 1, CAST(N'2024-06-25T10:30:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [UnitPrice], [DefaultImage], [Imgs], [Rate], [CategoryId]) VALUES (1, N'Screen', N'High-performance smartphone with advanced features.', CAST(100.00 AS Decimal(5, 2)), N'phone_x.jpg', N'phone_x.jpg,phone_x_back.jpg', CAST(4.5 AS Decimal(2, 1)), 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [UnitPrice], [DefaultImage], [Imgs], [Rate], [CategoryId]) VALUES (2, N'Keyboard', N'Comfortable cotton T-shirt for men.', CAST(19.99 AS Decimal(5, 2)), N'tshirt_men.jpg', N'tshirt_men.jpg', CAST(4.2 AS Decimal(2, 1)), 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [UnitPrice], [DefaultImage], [Imgs], [Rate], [CategoryId]) VALUES (3, N'Mouse', N'Comprehensive guide to SQL fundamentals.', CAST(29.95 AS Decimal(5, 2)), N'sql_book.jpg', N'sql_book.jpg', CAST(4.8 AS Decimal(2, 1)), 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [UnitPrice], [DefaultImage], [Imgs], [Rate], [CategoryId]) VALUES (4, N'Printer', N'Powerful blender for preparing smoothies and soups.', CAST(79.99 AS Decimal(5, 2)), N'blender.jpg', N'blender.jpg,blender_parts.jpg', CAST(4.0 AS Decimal(2, 1)), 2)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [UnitPrice], [DefaultImage], [Imgs], [Rate], [CategoryId]) VALUES (5, N'Power Supply', N'Engaging board game for strategy enthusiasts.', CAST(39.99 AS Decimal(5, 2)), N'board_game.jpg', N'board_game.jpg,board_game_box.jpg', CAST(4.6 AS Decimal(2, 1)), 3)
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Rate]  DEFAULT ((1)) FOR [Rate]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories1] FOREIGN KEY([SuperCategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories1]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_Order_Details_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
USE [master]
GO
ALTER DATABASE [myttask] SET  READ_WRITE 
GO

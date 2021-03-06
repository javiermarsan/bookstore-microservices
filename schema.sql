USE [BookStore]
GO

CREATE TABLE [dbo].[Book](
	[BookId] [uniqueidentifier] NOT NULL,
	[Title] [varchar](500) NOT NULL,
	[PublicationDate] [date] NULL,
	[AuthorId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book] ADD  DEFAULT (newid()) FOR [BookId]
GO

CREATE TABLE [dbo].[Author](
	[AuthorId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](250) NOT NULL
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Author] ADD  DEFAULT (newid()) FOR [AuthorId]
GO

CREATE TABLE [dbo].[Basket](
	[BasketId] [uniqueidentifier] NOT NULL,
	[CreationDate] [datetime] NOT NULL
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED 
(
	[BasketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Basket] ADD  DEFAULT (newid()) FOR [BasketId]
GO

CREATE TABLE [dbo].[BasketItem](
	[Id] [uniqueidentifier] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[BasketId] [uniqueidentifier] NOT NULL
 CONSTRAINT [PK_BasketItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BasketItem] ADD  DEFAULT (newid()) FOR [Id]
GO
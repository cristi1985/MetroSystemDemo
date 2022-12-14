USE [master]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 19/09/2022 10:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[RowID] [int] IDENTITY(1,1) NOT NULL,
	[BasketId] [uniqueidentifier] NOT NULL,
	[AggregateIdentifier] [uniqueidentifier] NOT NULL,
	[BuyerName] [nvarchar](max) NOT NULL,
	[Products] [nvarchar](max) NULL,
	[TotalNet] [decimal](18, 0) NULL,
	[TotalGross] [decimal](18, 0) NULL,
	[PaysVat] [bit] NOT NULL,
	[Closed] [bit] NOT NULL,
	[Payed] [bit] NOT NULL,
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasketAggregates]    Script Date: 19/09/2022 10:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasketAggregates](
	[AggregateIdentifier] [uniqueidentifier] NOT NULL,
	[AggregateClass] [varchar](max) NOT NULL,
	[AggregateType] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasketEvents]    Script Date: 19/09/2022 10:18:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasketEvents](
	[AggregateIdentifier] [uniqueidentifier] NOT NULL,
	[AggregateVersion] [bigint] NOT NULL,
	[EventTime] [bigint] NOT NULL,
	[EventType] [nvarchar](max) NULL,
	[EventData] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

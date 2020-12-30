USE [Colmena_Salud]
GO
/****** Object:  Table [dbo].[Apuesta]    Script Date: 30/12/2020 3:21:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apuesta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[number] [int] NULL,
	[color] [varchar](20) NULL,
	[money] [int] NULL,
	[idRuleta] [int] NULL,
	[state] [varchar](15) NULL,
	[winMoney] [numeric](10, 5) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HUELLA]
) ON [HUELLA]
GO
/****** Object:  Table [dbo].[Ruleta]    Script Date: 30/12/2020 3:21:35 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruleta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[estado] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [HUELLA]
) ON [HUELLA]
GO
SET IDENTITY_INSERT [dbo].[Ruleta] ON 
GO
INSERT [dbo].[Ruleta] ([id], [estado]) VALUES (1, N'cerrada')
GO
INSERT [dbo].[Ruleta] ([id], [estado]) VALUES (2, N'abierta')
GO
INSERT [dbo].[Ruleta] ([id], [estado]) VALUES (3, N'abierta')
GO
SET IDENTITY_INSERT [dbo].[Ruleta] OFF
GO
ALTER TABLE [dbo].[Apuesta]  WITH CHECK ADD FOREIGN KEY([idRuleta])
REFERENCES [dbo].[Ruleta] ([id])
GO

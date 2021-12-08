USE [WebAutoparkDB]
GO
/****** Object:  Table [dbo].[Components]    Script Date: 08.12.2021 21:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Components](
	[ComponentId] [int] NOT NULL,
	[Name] [nchar](50) NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

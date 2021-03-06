USE [Corsaro.Cristian.TPFinal]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 10/7/2021 17:41:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[costo] [float] NULL,
	[calidad] [int] NOT NULL,
	[tipoComputadora] [int] NULL,
	[sistemaComputadora] [int] NULL,
	[sistemaCelular] [int] NULL,
	[tipoClase] [int] NOT NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

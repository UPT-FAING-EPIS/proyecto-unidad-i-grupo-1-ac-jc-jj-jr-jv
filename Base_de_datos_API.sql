USE [API_DATABASE]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/09/2023 04:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellido_Paterno] [varchar](50) NOT NULL,
	[Apellido_Materno] [varchar](50) NOT NULL,
	[Numero] [int] NOT NULL,
	[Género] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLienteDetalle]    Script Date: 29/09/2023 04:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLienteDetalle](
	[idDetalle] [int] NOT NULL,
	[fkCli] [int] NULL,
	[Correo] [nvarchar](200) NULL,
	[Seguro] [nvarchar](100) NULL,
	[Direccion] [nvarchar](50) NULL,
	[Documento] [nvarchar](25) NULL,
	[Residencia] [nvarchar](50) NULL,
 CONSTRAINT [PK_CLienteDetalle] PRIMARY KEY CLUSTERED 
(
	[idDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Correo]    Script Date: 29/09/2023 04:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Correo](
	[idCorreo] [int] NOT NULL,
	[IdCli] [int] NULL,
	[TipoCorreo] [int] NOT NULL,
	[Correo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Correo] PRIMARY KEY CLUSTERED 
(
	[idCorreo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 29/09/2023 04:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direccion](
	[idDireccion] [int] NOT NULL,
	[IdClI] [int] NULL,
	[TipoDireccion] [nvarchar](50) NOT NULL,
	[Calle] [nvarchar](100) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Referencia] [text] NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[idDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 29/09/2023 04:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[IdDocumento] [int] NOT NULL,
	[idCli] [int] NULL,
	[TipoDocumento] [nvarchar](100) NOT NULL,
	[FechaEmisión] [date] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[ArchivoAdjunto] [image] NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Residencia]    Script Date: 29/09/2023 04:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Residencia](
	[idPais] [int] NOT NULL,
	[idCli] [int] NULL,
	[Pais] [nvarchar](50) NOT NULL,
	[Ciudad] [nvarchar](50) NOT NULL,
	[Provincia] [nvarchar](50) NOT NULL,
	[Distrito] [nvarchar](50) NOT NULL,
	[Prefijo_Celular] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_Residencia] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguro]    Script Date: 29/09/2023 04:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguro](
	[IdSeguro] [int] NOT NULL,
	[IdCli] [int] NULL,
	[TipoSeguro] [nvarchar](100) NULL,
	[Poliza] [nvarchar](50) NOT NULL,
	[Cobertura] [int] NOT NULL,
	[DocumentoSeguro] [image] NULL,
 CONSTRAINT [PK_Seguro] PRIMARY KEY CLUSTERED 
(
	[IdSeguro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CLienteDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CLienteDetalle_Cliente] FOREIGN KEY([fkCli])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[CLienteDetalle] CHECK CONSTRAINT [FK_CLienteDetalle_Cliente]
GO
ALTER TABLE [dbo].[Correo]  WITH CHECK ADD  CONSTRAINT [FK_Correo_Cliente] FOREIGN KEY([IdCli])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Correo] CHECK CONSTRAINT [FK_Correo_Cliente]
GO
ALTER TABLE [dbo].[Direccion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Cliente] FOREIGN KEY([IdClI])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Direccion] CHECK CONSTRAINT [FK_Direccion_Cliente]
GO
ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Cliente] FOREIGN KEY([idCli])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_Documento_Cliente]
GO
ALTER TABLE [dbo].[Residencia]  WITH CHECK ADD  CONSTRAINT [FK_Residencia_Cliente] FOREIGN KEY([idCli])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Residencia] CHECK CONSTRAINT [FK_Residencia_Cliente]
GO
ALTER TABLE [dbo].[Seguro]  WITH CHECK ADD  CONSTRAINT [FK_Seguro_Cliente] FOREIGN KEY([IdCli])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Seguro] CHECK CONSTRAINT [FK_Seguro_Cliente]
GO

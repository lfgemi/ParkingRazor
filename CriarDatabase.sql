USE [master]
GO
/****** Object:  Database [ParkingDB]    Script Date: 26/06/2020 00:54:27 ******/
CREATE DATABASE [ParkingDB]
GO
USE [ParkingDB]
GO
/****** Object:  Table [dbo].[Carros]    Script Date: 26/06/2020 00:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carros](
	[IdCarro] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[Placa] [nchar](8) NULL,
	[DtAlteracao] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Carros] PRIMARY KEY CLUSTERED 
(
	[IdCarro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manobras]    Script Date: 26/06/2020 00:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manobras](
	[IdManobra] [int] IDENTITY(1,1) NOT NULL,
	[IdManobrista] [int] NULL,
	[IdCarro] [int] NULL,
	[DtInclusao] [datetime] NOT NULL,
	[IdTipoManobra] [int] NOT NULL,
 CONSTRAINT [PK_Manobra] PRIMARY KEY CLUSTERED 
(
	[IdManobra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manobristas]    Script Date: 26/06/2020 00:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manobristas](
	[IdManobrista] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NULL,
	[Cpf] [nchar](11) NULL,
	[DataNascimento] [date] NULL,
	[DtAlteracao] [datetime] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Manobristas] PRIMARY KEY CLUSTERED 
(
	[IdManobrista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoManobra]    Script Date: 26/06/2020 00:54:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoManobra](
	[IdTipoManobra] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_TipoManobra] PRIMARY KEY CLUSTERED 
(
	[IdTipoManobra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carros] ADD  CONSTRAINT [DF_Carros_DtAlteracao]  DEFAULT (getdate()) FOR [DtAlteracao]
GO
ALTER TABLE [dbo].[Carros] ADD  CONSTRAINT [DF_Carros_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Manobras] ADD  CONSTRAINT [DF_Manobra_DtInclusao]  DEFAULT (getdate()) FOR [DtInclusao]
GO
ALTER TABLE [dbo].[Manobristas] ADD  CONSTRAINT [DF_Manobristas_DtAlteracao]  DEFAULT (getdate()) FOR [DtAlteracao]
GO
ALTER TABLE [dbo].[Manobristas] ADD  CONSTRAINT [DF_Manobristas_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Manobras]  WITH CHECK ADD  CONSTRAINT [FK_Manobras_Carros] FOREIGN KEY([IdCarro])
REFERENCES [dbo].[Carros] ([IdCarro])
GO
ALTER TABLE [dbo].[Manobras] CHECK CONSTRAINT [FK_Manobras_Carros]
GO
ALTER TABLE [dbo].[Manobras]  WITH CHECK ADD  CONSTRAINT [FK_Manobras_Manobristas1] FOREIGN KEY([IdManobrista])
REFERENCES [dbo].[Manobristas] ([IdManobrista])
GO
ALTER TABLE [dbo].[Manobras] CHECK CONSTRAINT [FK_Manobras_Manobristas1]
GO
USE [master]
GO
ALTER DATABASE [ParkingDB] SET  READ_WRITE 
GO

-- tipos manobra
insert into ParkingDB.dbo.TipoManobra (Descricao) values 
('Entrada'), 
('Saída')

-- carros exemplo
insert into Carros (Marca, Modelo, Placa) values
('Volkswagen', 'Fox', 'FQM-8822'),
('Honda', 'Fit', 'NAT-1220')

-- manobristas exemplo
insert into Manobristas(Nome, Cpf, DataNascimento) values
('Luiz Fernando', '38022261104', '1988-11-28'),
('Pedro Garcia', '20411161102', '1982-03-22')
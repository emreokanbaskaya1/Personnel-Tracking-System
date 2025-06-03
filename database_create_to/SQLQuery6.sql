USE [PersonelVeriTabani]
GO

/****** Object:  Table [dbo].[Tbl_Personel]    Script Date: 6/3/2025 1:02:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tbl_Personel](
	[Perid] [smallint] IDENTITY(1,1) NOT NULL,
	[PerAd] [varchar](10) NULL,
	[PerSoyad] [varchar](10) NULL,
	[PerSehir] [varchar](13) NULL,
	[PerMaas] [smallint] NULL,
	[PerDurum] [bit] NULL,
	[PerMeslek] [varchar](15) NULL
) ON [PRIMARY]
GO



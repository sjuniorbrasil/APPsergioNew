USE [master]
GO
/****** Object:  Database [ducaun]    Script Date: 14/07/2017 08:42:25 ******/
CREATE DATABASE [ducaun]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ducaun', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ducaun.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ducaun_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ducaun_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ducaun] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ducaun].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ducaun] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ducaun] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ducaun] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ducaun] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ducaun] SET ARITHABORT OFF 
GO
ALTER DATABASE [ducaun] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ducaun] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ducaun] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ducaun] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ducaun] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ducaun] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ducaun] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ducaun] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ducaun] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ducaun] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ducaun] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ducaun] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ducaun] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ducaun] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ducaun] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ducaun] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ducaun] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ducaun] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ducaun] SET  MULTI_USER 
GO
ALTER DATABASE [ducaun] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ducaun] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ducaun] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ducaun] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ducaun] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ducaun]
GO
/****** Object:  Table [dbo].[agenda]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[agenda](
	[age_codigo] [int] IDENTITY(1,1) NOT NULL,
	[age_data] [nchar](10) NOT NULL,
	[age_hora] [nchar](10) NOT NULL,
	[age_concluidos] [nchar](10) NULL,
	[age_todos] [nchar](10) NULL,
	[age_descricao] [nvarchar](max) NULL,
	[cod_funcionario] [int] NULL,
	[cod_cliente] [int] NULL,
 CONSTRAINT [PK_agenda] PRIMARY KEY CLUSTERED 
(
	[age_codigo] ASC,
	[age_data] ASC,
	[age_hora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[atendimentos]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[atendimentos](
	[cod_atendimento] [int] IDENTITY(1,1) NOT NULL,
	[data_atendimento] [varchar](20) NULL,
	[cod_cliente] [int] NULL,
	[cod_funcionario] [int] NULL,
	[observacoes] [nchar](1000) NULL,
	[cod_procedimento] [int] NULL,
 CONSTRAINT [pkatendimentos] PRIMARY KEY CLUSTERED 
(
	[cod_atendimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CFOP]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CFOP](
	[cfo_codigo] [int] NOT NULL,
	[cfo_descricao] [nvarchar](60) NULL,
 CONSTRAINT [PK_CFOP] PRIMARY KEY CLUSTERED 
(
	[cfo_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cidades]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cidades](
	[cid_codigo] [int] IDENTITY(1,1) NOT NULL,
	[cid_nome] [nvarchar](50) NULL,
	[cid_uf] [nvarchar](50) NULL,
	[cid_ibge] [nvarchar](50) NULL,
	[cid_descUf] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientes]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clientes](
	[cod_cliente] [int] IDENTITY(1,1) NOT NULL,
	[n_cliente] [varchar](30) NULL,
	[endereco] [varchar](40) NULL,
	[bairro] [varchar](20) NULL,
	[cidade] [int] NULL,
	[telefone] [varchar](20) NULL,
	[celular] [varchar](20) NULL,
	[cep] [varchar](20) NULL,
	[obs] [varchar](1000) NULL,
	[cpf] [varchar](20) NULL,
	[email] [varchar](80) NULL,
	[data_nas] [varchar](20) NULL,
	[numero] [varchar](50) NULL,
 CONSTRAINT [pkclienetes] PRIMARY KEY CLUSTERED 
(
	[cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[compra]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[compra](
	[com_codigo] [int] IDENTITY(1,1) NOT NULL,
	[com_data] [nchar](10) NULL,
	[com_totalbruto] [decimal](18, 2) NULL,
	[com_percdesconto] [decimal](18, 2) NULL,
	[com_desconto] [decimal](18, 2) NULL,
	[com_totalliq] [decimal](18, 2) NULL,
	[com_obs] [varchar](1000) NULL,
	[cod_fornecedor] [int] NULL,
 CONSTRAINT [PK_compra] PRIMARY KEY CLUSTERED 
(
	[com_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[compraitem]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compraitem](
	[com_codigo] [int] NOT NULL,
	[cod_produto] [int] NOT NULL,
	[itp_valor] [decimal](18, 2) NULL,
	[itp_qtde] [decimal](18, 2) NULL,
	[itp_total] [decimal](18, 2) NULL,
	[itp_vloriginal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_compraitem] PRIMARY KEY CLUSTERED 
(
	[com_codigo] ASC,
	[cod_produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CPAGAR]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CPAGAR](
	[pag_codigo] [int] IDENTITY(1,1) NOT NULL,
	[cod_cliente] [int] NULL,
	[pag_valor] [decimal](18, 2) NULL,
	[pag_recebido] [decimal](18, 2) NULL,
	[pag_dtVenc] [nvarchar](50) NULL,
	[pag_dtBaixa] [nvarchar](50) NULL,
	[pag_situacao] [nchar](10) NULL,
	[pag_obs] [nvarchar](300) NULL,
	[pag_juros] [decimal](18, 2) NULL,
	[com_codigo] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CRECEBER]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRECEBER](
	[rec_codigo] [int] IDENTITY(1,1) NOT NULL,
	[cod_cliente] [int] NULL,
	[rec_valor] [decimal](18, 2) NULL,
	[rec_valorRec] [decimal](18, 2) NULL,
	[rec_dtVenc] [nvarchar](50) NULL,
	[rec_dtBaixa] [nvarchar](50) NULL,
	[rec_situacao] [nchar](10) NULL,
	[rec_obs] [nvarchar](300) NULL,
	[rec_vlacrescimo] [decimal](18, 2) NULL,
	[ven_codigo] [int] NULL,
	[rec_vencido] [int] NULL,
 CONSTRAINT [PK_CRECEBER] PRIMARY KEY CLUSTERED 
(
	[rec_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ESTOQUE]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ESTOQUE](
	[FIL_CODIGO] [int] NULL,
	[EST_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[EST_DATA] [date] NULL,
	[COM_CODIGO] [int] NULL,
	[VEN_CODIGO] [int] NULL,
	[PRO_CODIGO] [int] NULL,
	[INV_CODIGO] [int] NULL,
	[EST_MOTIVO] [varchar](500) NULL,
	[EST_CODSAIDA] [int] NULL,
	[TRA_CODIGO] [int] NULL,
	[EST_QTDE] [decimal](15, 4) NULL,
	[EST_CODCONVERSAO] [int] NULL,
	[CPP_CODIGO] [int] NULL,
	[VEP_CODIGO] [int] NULL,
	[NOT_CODIGO] [int] NULL,
	[NOP_CODIGO] [int] NULL,
	[REQ_CODIGO] [int] NULL,
	[RQP_CODIGO] [int] NULL,
	[PRD_CODIGO] [int] NULL,
	[PRP_CODIGO] [int] NULL,
 CONSTRAINT [PK__ESTOQUE__6FBFC2002144B252] PRIMARY KEY CLUSTERED 
(
	[EST_CODIGO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[filial]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[filial](
	[fil_codigo] [int] IDENTITY(1,1) NOT NULL,
	[fil_razao] [varchar](30) NULL,
	[fil_fantasia] [varchar](30) NULL,
	[fil_endereco] [varchar](40) NULL,
	[fil_bairro] [varchar](20) NULL,
	[fil_cidade] [int] NULL,
	[fil_telefone] [varchar](30) NULL,
	[fil_celular] [varchar](30) NULL,
	[fil_cep] [varchar](30) NULL,
	[fil_obs] [varchar](1000) NULL,
	[fil_cnpj] [varchar](20) NULL,
	[fil_IE] [varchar](20) NULL,
	[fil_contador] [varchar](40) NULL,
	[fil_contCnpj] [varchar](20) NULL,
	[fil_numero] [varchar](20) NULL,
	[fil_email] [varchar](80) NULL,
	[fil_certificado] [varchar](20) NULL,
	[fil_crt] [nvarchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fornecedores]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fornecedores](
	[cod_fornecedor] [int] IDENTITY(1,1) NOT NULL,
	[razão] [varchar](30) NULL,
	[fantasia] [varchar](30) NULL,
	[endereco] [varchar](40) NULL,
	[bairro] [varchar](20) NULL,
	[cidade] [int] NULL,
	[telefone] [varchar](30) NULL,
	[celular] [varchar](30) NULL,
	[cep] [varchar](30) NULL,
	[obs] [varchar](1000) NULL,
	[cnpj] [varchar](20) NULL,
	[numero] [varchar](20) NULL,
	[email] [varchar](80) NULL,
 CONSTRAINT [pkfornecedor] PRIMARY KEY CLUSTERED 
(
	[cod_fornecedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[funcionarios]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[funcionarios](
	[cod_funcionario] [int] IDENTITY(1,1) NOT NULL,
	[n_funcionario] [varchar](30) NULL,
	[endereco] [varchar](40) NULL,
	[bairro] [varchar](20) NULL,
	[cidade] [varchar](20) NULL,
	[telefone] [varchar](10) NULL,
	[celular] [varchar](10) NULL,
	[cep] [varchar](8) NULL,
	[data_contratacao] [varchar](20) NULL,
	[obs] [varchar](1000) NULL,
	[ctps] [varchar](30) NULL,
	[cnpj] [varchar](20) NULL,
	[cpf] [varchar](20) NULL,
	[email] [varchar](80) NULL,
 CONSTRAINT [pkfuncionarios] PRIMARY KEY CLUSTERED 
(
	[cod_funcionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ITEMPEDIDO]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITEMPEDIDO](
	[PED_CODIGO] [int] NOT NULL,
	[cod_produto] [int] NOT NULL,
	[ITP_VALOR] [decimal](15, 2) NULL,
	[ITP_QTDE] [decimal](15, 2) NULL,
	[ITP_TOTAL] [decimal](15, 2) NULL,
	[ITP_VLORIGINAL] [decimal](15, 2) NULL,
 CONSTRAINT [PK_ITEMPEDIDO] PRIMARY KEY CLUSTERED 
(
	[PED_CODIGO] ASC,
	[cod_produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[itens]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itens](
	[cod_venda] [int] NOT NULL,
	[nritem] [int] IDENTITY(1,1) NOT NULL,
	[cod_produto] [int] NOT NULL,
	[qtvenda] [decimal](16, 2) NOT NULL,
	[vlproduto] [decimal](16, 2) NOT NULL,
 CONSTRAINT [pkitens] PRIMARY KEY CLUSTERED 
(
	[cod_venda] ASC,
	[nritem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nota]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nota](
	[not_codigo] [int] NOT NULL,
	[not_dtemissao] [nvarchar](15) NULL,
	[not_numero] [int] NULL,
	[not_modelo] [nvarchar](5) NULL,
	[not_serie] [nvarchar](6) NULL,
	[not_finalidade] [int] NULL,
	[cadastro] [int] NULL,
	[cfo_codigo] [int] NULL,
	[not_referenciada] [nvarchar](50) NULL,
	[not_subtotal] [decimal](18, 2) NULL,
	[not_desconto] [decimal](18, 2) NULL,
	[not_nfetotal] [decimal](18, 2) NULL,
	[not_obs] [nvarchar](1000) NULL,
	[cod_forncedor] [int] NULL,
	[not_vencimento] [nvarchar](15) NULL,
	[not_chave] [nvarchar](100) NULL,
	[not_protocolo] [nvarchar](50) NULL,
	[not_recibo] [nvarchar](50) NULL,
	[not_statusnota] [nvarchar](10) NULL,
	[not_dthoraprotocolo] [nvarchar](30) NULL,
	[not_cancelada] [int] NULL,
	[not_inutilizada] [int] NULL,
	[not_motivocancel] [nvarchar](100) NULL,
	[not_peso] [nvarchar](30) NULL,
	[not_volume] [nvarchar](30) NULL,
	[not_marca] [nvarchar](30) NULL,
	[not_icmsbase] [decimal](18, 2) NULL,
	[not_icmsvalor] [decimal](18, 2) NULL,
	[not_icmspercentual] [decimal](18, 2) NULL,
	[not_icmsstvalor] [decimal](18, 2) NULL,
	[not_xml] [xml] NULL,
	[not_ipi] [decimal](18, 2) NULL,
 CONSTRAINT [PK_nota] PRIMARY KEY CLUSTERED 
(
	[not_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NOTAPRODUTO]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOTAPRODUTO](
	[NOT_CODIGO] [int] NOT NULL,
	[NOP_CODIGO] [int] NOT NULL,
	[NOP_TIPO] [smallint] NULL,
	[PRO_CODIGO] [int] NULL,
	[NOP_DESCRICAO] [nvarchar](100) NULL,
	[NOP_QTDE] [decimal](15, 4) NULL,
	[NOP_VALOR] [decimal](15, 4) NULL,
	[NOP_TOTAL] [decimal](15, 2) NULL,
	[NOP_ICMSBASE] [decimal](15, 2) NULL,
	[NOP_ICMSALIQ] [decimal](15, 2) NULL,
	[NOP_ICMSVALOR] [decimal](15, 2) NULL,
	[NOP_PERCDESC] [decimal](15, 4) NULL,
	[NOP_CANCELADO] [smallint] NULL,
	[CFO_CODIGO] [int] NULL,
	[NOP_IIBASE] [decimal](15, 2) NULL,
	[NOP_IIVALOR] [decimal](15, 2) NULL,
	[NOP_IIIOF] [decimal](15, 2) NULL,
	[NOP_IIDESPADUAN] [decimal](15, 2) NULL,
	[NOP_ICMSCST] [nvarchar](10) NULL,
	[NOP_SUBTOTAL] [decimal](15, 2) NULL,
	[NOP_ICMSSTBASE] [decimal](15, 2) NULL,
	[NOP_ICMSSTALIQ] [decimal](15, 2) NULL,
	[NOP_ICMSSTMVA] [decimal](15, 2) NULL,
	[NOP_ICMSSTVALOR] [decimal](15, 2) NULL,
	[NOP_PISCST] [nvarchar](10) NULL,
	[NOP_PISBASE] [decimal](15, 2) NULL,
	[NOP_PISALIQ] [decimal](15, 2) NULL,
	[NOP_PISVALOR] [decimal](15, 2) NULL,
	[NOP_COFINSCST] [nvarchar](10) NULL,
	[NOP_COFINSBASE] [decimal](15, 2) NULL,
	[NOP_COFINSALIQ] [decimal](15, 2) NULL,
	[NOP_COFINSVALOR] [decimal](15, 2) NULL,
	[NOP_CSOSN] [nvarchar](10) NULL,
	[NOP_IPIBASE] [decimal](15, 2) NULL,
	[NOP_IPIALIQ] [decimal](15, 2) NULL,
	[NOP_IPIVALOR] [decimal](15, 2) NULL,
	[NOP_AVULSO] [smallint] NULL,
	[FIL_CODIGO] [int] NULL,
	[NOP_DATA] [datetime] NULL,
	[NOP_IPICST] [nvarchar](10) NULL,
	[NOP_TOTIMPOSTO] [decimal](15, 2) NULL,
	[NOP_DIFAL_VBCUFDEST] [decimal](15, 2) NULL,
	[NOP_DIFAL_PFCPUFDEST] [decimal](15, 2) NULL,
	[NOP_DIFAL_PICMSUFDEST] [decimal](15, 2) NULL,
	[NOP_DIFAL_PICMSINTER] [decimal](15, 2) NULL,
	[NOP_DIFAL_PICMSINTERPART] [decimal](15, 2) NULL,
	[NOP_DIFAL_VFCPUFDEST] [decimal](15, 2) NULL,
	[NOP_DIFAL_VICMSUFDEST] [decimal](15, 2) NULL,
	[NOP_DIFAL_VICMSUFREMET] [decimal](15, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[NOT_CODIGO] ASC,
	[NOP_CODIGO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PEDIDO]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PEDIDO](
	[PED_CODIGO] [int] IDENTITY(1,1) NOT NULL,
	[PED_DTEMISSAO] [varchar](20) NULL,
	[PED_TOTALBRUTO] [decimal](15, 2) NULL,
	[PED_PERCDESC] [decimal](15, 2) NULL,
	[PED_DESCONTO] [decimal](15, 2) NULL,
	[PED_TOTALLIQ] [decimal](15, 2) NULL,
	[PED_OBS] [varchar](250) NULL,
	[cod_funcionario] [int] NULL,
	[cod_cliente] [int] NULL,
	[bloblob] [xml] NULL,
 CONSTRAINT [PK__PEDIDO__03C8A5CBE7C03148] PRIMARY KEY CLUSTERED 
(
	[PED_CODIGO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[procedimentos]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[procedimentos](
	[cod_procedimento] [int] IDENTITY(1,1) NOT NULL,
	[des_procedimento] [varchar](30) NULL,
 CONSTRAINT [pkprocedimentos] PRIMARY KEY CLUSTERED 
(
	[cod_procedimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[produtos]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[produtos](
	[cod_produto] [int] IDENTITY(1,1) NOT NULL,
	[des_produto] [varchar](30) NULL,
	[ean] [varchar](20) NULL,
	[cod_fornecedor] [int] NULL,
	[vl_produto] [decimal](18, 2) NULL,
	[est_produto] [decimal](18, 2) NULL,
	[un_medida] [nchar](10) NULL,
	[desc_reduzida] [varchar](30) NULL,
	[margem] [decimal](18, 2) NULL,
	[custo] [decimal](18, 2) NULL,
	[cfo_codigo] [int] NULL,
	[cest] [nvarchar](10) NULL,
	[ncm] [nvarchar](20) NULL,
	[cstIcms] [nvarchar](6) NULL,
	[cstipi] [nvarchar](6) NULL,
	[cstpis] [nvarchar](6) NULL,
	[cstcofins] [nvarchar](6) NULL,
	[aliqinter] [decimal](18, 2) NULL,
	[aliqIcms] [decimal](18, 2) NULL,
	[aliqipi] [decimal](18, 2) NULL,
	[aliqpis] [decimal](18, 2) NULL,
	[aliqcofins] [decimal](18, 2) NULL,
	[origem] [int] NULL,
	[situacao] [int] NULL,
	[Icms_aliq_inter] [decimal](18, 2) NULL,
	[MVA] [decimal](18, 2) NULL,
	[Icms_StValor] [decimal](18, 2) NULL,
 CONSTRAINT [pkprodutos] PRIMARY KEY CLUSTERED 
(
	[cod_produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios](
	[usu_codigo] [int] IDENTITY(1,1) NOT NULL,
	[usu_nome] [nchar](30) NOT NULL,
	[usu_senha] [varchar](50) NOT NULL,
	[usu_cadPessoa] [int] NULL,
	[usu_cadProduto] [int] NULL,
	[usu_cadFiscal] [int] NULL,
	[usu_compra] [int] NULL,
	[usu_venda] [int] NULL,
	[usu_relatorios] [int] NULL,
	[usu_cadusuario] [int] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[usu_codigo] ASC,
	[usu_nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vendas]    Script Date: 14/07/2017 08:42:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendas](
	[cod_venda] [int] IDENTITY(1,1) NOT NULL,
	[dtvenda] [date] NULL,
	[cod_cliente] [int] NULL,
 CONSTRAINT [pkvendas] PRIMARY KEY CLUSTERED 
(
	[cod_venda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [FK_agendaclientes]    Script Date: 14/07/2017 08:42:25 ******/
CREATE NONCLUSTERED INDEX [FK_agendaclientes] ON [dbo].[agenda]
(
	[age_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NOTAPRODUTO] ADD  DEFAULT ((0)) FOR [NOP_AVULSO]
GO
ALTER TABLE [dbo].[agenda]  WITH CHECK ADD  CONSTRAINT [FK_agenda_clientes] FOREIGN KEY([cod_cliente])
REFERENCES [dbo].[clientes] ([cod_cliente])
GO
ALTER TABLE [dbo].[agenda] CHECK CONSTRAINT [FK_agenda_clientes]
GO
ALTER TABLE [dbo].[agenda]  WITH CHECK ADD  CONSTRAINT [FK_agenda_funcionarios] FOREIGN KEY([cod_funcionario])
REFERENCES [dbo].[funcionarios] ([cod_funcionario])
GO
ALTER TABLE [dbo].[agenda] CHECK CONSTRAINT [FK_agenda_funcionarios]
GO
ALTER TABLE [dbo].[atendimentos]  WITH CHECK ADD  CONSTRAINT [FK_atendimentos_procedimento] FOREIGN KEY([cod_atendimento])
REFERENCES [dbo].[procedimentos] ([cod_procedimento])
GO
ALTER TABLE [dbo].[atendimentos] CHECK CONSTRAINT [FK_atendimentos_procedimento]
GO
ALTER TABLE [dbo].[atendimentos]  WITH CHECK ADD  CONSTRAINT [fkatendimentosclientes] FOREIGN KEY([cod_cliente])
REFERENCES [dbo].[clientes] ([cod_cliente])
GO
ALTER TABLE [dbo].[atendimentos] CHECK CONSTRAINT [fkatendimentosclientes]
GO
ALTER TABLE [dbo].[atendimentos]  WITH CHECK ADD  CONSTRAINT [fkvendasfuncionarios] FOREIGN KEY([cod_funcionario])
REFERENCES [dbo].[funcionarios] ([cod_funcionario])
GO
ALTER TABLE [dbo].[atendimentos] CHECK CONSTRAINT [fkvendasfuncionarios]
GO
ALTER TABLE [dbo].[ITEMPEDIDO]  WITH CHECK ADD  CONSTRAINT [fk_ITEMPEDIDO] FOREIGN KEY([cod_produto])
REFERENCES [dbo].[produtos] ([cod_produto])
GO
ALTER TABLE [dbo].[ITEMPEDIDO] CHECK CONSTRAINT [fk_ITEMPEDIDO]
GO
ALTER TABLE [dbo].[itens]  WITH CHECK ADD  CONSTRAINT [FK_itens_itens] FOREIGN KEY([cod_venda], [nritem])
REFERENCES [dbo].[itens] ([cod_venda], [nritem])
GO
ALTER TABLE [dbo].[itens] CHECK CONSTRAINT [FK_itens_itens]
GO
ALTER TABLE [dbo].[itens]  WITH CHECK ADD  CONSTRAINT [FK_itens_itens1] FOREIGN KEY([cod_venda], [nritem])
REFERENCES [dbo].[itens] ([cod_venda], [nritem])
GO
ALTER TABLE [dbo].[itens] CHECK CONSTRAINT [FK_itens_itens1]
GO
ALTER TABLE [dbo].[itens]  WITH CHECK ADD  CONSTRAINT [fkitensprodutos] FOREIGN KEY([cod_produto])
REFERENCES [dbo].[produtos] ([cod_produto])
GO
ALTER TABLE [dbo].[itens] CHECK CONSTRAINT [fkitensprodutos]
GO
ALTER TABLE [dbo].[itens]  WITH CHECK ADD  CONSTRAINT [fkitensvendas] FOREIGN KEY([cod_venda])
REFERENCES [dbo].[vendas] ([cod_venda])
GO
ALTER TABLE [dbo].[itens] CHECK CONSTRAINT [fkitensvendas]
GO
ALTER TABLE [dbo].[produtos]  WITH CHECK ADD  CONSTRAINT [fkprodutosfornecedores] FOREIGN KEY([cod_fornecedor])
REFERENCES [dbo].[fornecedores] ([cod_fornecedor])
GO
ALTER TABLE [dbo].[produtos] CHECK CONSTRAINT [fkprodutosfornecedores]
GO
ALTER TABLE [dbo].[vendas]  WITH CHECK ADD  CONSTRAINT [fkvendasclientes] FOREIGN KEY([cod_cliente])
REFERENCES [dbo].[clientes] ([cod_cliente])
GO
ALTER TABLE [dbo].[vendas] CHECK CONSTRAINT [fkvendasclientes]
GO
USE [master]
GO
ALTER DATABASE [ducaun] SET  READ_WRITE 
GO

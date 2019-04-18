
--selectionner toutes les values de 
--VALUET1, VALUET3





CREATE TABLE [dbo].[table1](
	[Id] [int] NOT NULL,
	[VaLueT1] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[table3]    Script Date: 15/04/2019 14:26:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[table3](
	[Id] [int] NOT NULL,
	[VaLueT3] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





CREATE TABLE [dbo].[table2](
	[Id] [int] NOT NULL,
	[VaLueT2] [varchar](100) NULL,
	[IdTable1] [int] NULL,
	[IdTable3] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into table1(id,valuet1)
values(1,'toto')

insert into table1(id,valuet1)
values(2,'toto2')

insert into table2(id,valuet2,idtable1,idtable3)
values(1,'table2_value',1,1)

insert into table2(id,valuet2,idtable1,idtable3)
values(2,'table2_value',2,2)

insert into table3(id,valuet3)
values(1,'toto3_toto')

insert into table3(id,valuet3)
values(2,'toto3_toto')
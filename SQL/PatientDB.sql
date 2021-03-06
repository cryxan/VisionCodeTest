USE [Patient]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 27/08/2020 14:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[ID] [uniqueidentifier] NOT NULL,
	[Line1] [nvarchar](50) NOT NULL,
	[Line2] [nvarchar](50) NULL,
	[Line3] [nvarchar](50) NULL,
	[PostCode] [nvarchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 27/08/2020 14:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[PatientID] [uniqueidentifier] NOT NULL,
	[DateTime] [datetimeoffset](7) NOT NULL,
	[Type] [nvarchar](10) NOT NULL,
	[Notes] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 27/08/2020 14:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[ID] [uniqueidentifier] NOT NULL,
	[Forename] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[PrimaryContactPhoneID] [uniqueidentifier] NOT NULL,
	[PrimaryAddressID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 27/08/2020 14:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[ID] [uniqueidentifier] NOT NULL,
	[Number] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27/08/2020 14:42:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Patient] ADD  CONSTRAINT [DF_Patient_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[Phone] ADD  CONSTRAINT [DF_Phone_ID]  DEFAULT (newid()) FOR [ID]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_ID]  DEFAULT (newid()) FOR [ID]
GO

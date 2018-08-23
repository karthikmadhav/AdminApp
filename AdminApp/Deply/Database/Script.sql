USE [master]
GO
/****** Object:  Database [AdminApp]    Script Date: 23-08-2018 20:07:57 ******/
CREATE DATABASE [AdminApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AdminApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AdminApp.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AdminApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\AdminApp_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AdminApp] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AdminApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AdminApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AdminApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AdminApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AdminApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AdminApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [AdminApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AdminApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AdminApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AdminApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AdminApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AdminApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AdminApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AdminApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AdminApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AdminApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AdminApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AdminApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AdminApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AdminApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AdminApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AdminApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AdminApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AdminApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AdminApp] SET  MULTI_USER 
GO
ALTER DATABASE [AdminApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AdminApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AdminApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AdminApp] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AdminApp] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AdminApp]
GO
/****** Object:  Table [dbo].[CompanyDetails]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyDetails](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[PrimaryMailID] [nvarchar](50) NULL,
	[PrimaryPhoneNo] [nvarchar](50) NULL,
	[Fax] [nvarchar](10) NULL,
	[Website] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Address1] [nvarchar](50) NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](20) NULL,
	[Country] [nvarchar](50) NULL,
	[Pincode] [nvarchar](20) NULL,
	[GSTNO] [nvarchar](20) NULL,
	[ImageExt] [nvarchar](20) NULL,
 CONSTRAINT [PK_CompanyDetails] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDetails](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[CEOName] [nvarchar](50) NULL,
	[ContactPersonName] [nvarchar](50) NULL,
	[ContactPersonNumber] [nvarchar](50) NULL,
	[Notes] [nvarchar](150) NULL,
	[GSTNO] [nvarchar](50) NULL,
	[PAN] [nvarchar](50) NULL,
	[Adhar] [nvarchar](50) NULL,
	[PrimaryMailID] [nvarchar](50) NULL,
	[PrimaryPhoneNo] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Website] [nvarchar](25) NULL,
	[BillingAddress] [nvarchar](50) NULL,
	[BillingAddress1] [nvarchar](50) NULL,
	[BillingCity] [nvarchar](50) NULL,
	[BillingState] [nvarchar](50) NULL,
	[BillingCountry] [nvarchar](50) NULL,
	[BillingPincode] [nvarchar](50) NULL,
	[ShippingAddress] [nvarchar](50) NULL,
	[ShippingAddress1] [nvarchar](50) NULL,
	[ShippingCity] [nvarchar](50) NULL,
	[ShippingState] [nvarchar](50) NULL,
	[ShippingCountry] [nvarchar](50) NULL,
	[ShippingPincode] [nvarchar](50) NULL,
	[AdharExt] [nvarchar](20) NULL,
	[PanExt] [nvarchar](20) NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MenuMaster]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MenuMaster](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](50) NULL,
	[MenuUrl] [varchar](200) NULL,
	[MenuParentId] [int] NULL,
	[Active] [bit] NULL,
	[ControllerName] [varchar](100) NULL,
	[ActionName] [varchar](100) NULL,
	[IconStyle] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuPrivilege]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuPrivilege](
	[PrivilegeID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[CanView] [bit] NULL,
	[CanEdit] [bit] NULL,
	[CanDelete] [bit] NULL,
	[CanCreate] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PrivilegeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAuthentication]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAuthentication](
	[UserAuthID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserAuthentication] PRIMARY KEY CLUSTERED 
(
	[UserAuthID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[EmployeeCode] [nvarchar](10) NULL,
	[CompanyID] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Active] [bit] NULL,
	[Address] [nvarchar](50) NULL,
	[Address1] [nvarchar](50) NULL,
	[City] [nvarchar](20) NULL,
	[State] [nvarchar](20) NULL,
	[Country] [nvarchar](20) NULL,
	[Pincode] [nvarchar](10) NULL,
	[PrimaryEmailID] [nvarchar](20) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CompanyDetails] ON 

INSERT [dbo].[CompanyDetails] ([CompanyID], [CompanyName], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [Address], [Address1], [City], [State], [Country], [Pincode], [GSTNO], [ImageExt]) VALUES (3, N'Amazon Ind Pvt Ltd', N'info@amazon.com', N'9629207469', N'044338797', N'www.amazon.com', N'SP Infocity', N'Perungudi', N'Chennai', N'Tamilnadu', N'India', N'600062', N'GSTN4582', N'png')
INSERT [dbo].[CompanyDetails] ([CompanyID], [CompanyName], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [Address], [Address1], [City], [State], [Country], [Pincode], [GSTNO], [ImageExt]) VALUES (4, N'Flipkart', N'info@flipkart.com', N'9894169630', N'044736388', N'www.flipkart.com', N'Ramanujan IT City', N'Thiruvanmyur', N'Chennai', N'Tamilnadu', N'India', N'600063', N'GSTN890', N'jpg')
INSERT [dbo].[CompanyDetails] ([CompanyID], [CompanyName], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [Address], [Address1], [City], [State], [Country], [Pincode], [GSTNO], [ImageExt]) VALUES (5, N'Walmart', N'service@walmart.com', N'9551882666', N'0448392092', N'www.wallmart.com', N'Tidel Park', N'Guindy', N'Chennai', N'Tamilnadu', N'India', N'600483', N'GST82098', N'jpg')
INSERT [dbo].[CompanyDetails] ([CompanyID], [CompanyName], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [Address], [Address1], [City], [State], [Country], [Pincode], [GSTNO], [ImageExt]) VALUES (6, N'Mynthra', N'info@mynthra.com', N'993874928', N'0447839879', N'www.mynthra.com', N'SP Infocity', N'Near Perungudi', N'Chennai', N'Tamilnadu', N'India', N'600068', N'GST93479', N'jpg')
SET IDENTITY_INSERT [dbo].[CompanyDetails] OFF
SET IDENTITY_INSERT [dbo].[CustomerDetails] ON 

INSERT [dbo].[CustomerDetails] ([CustomerID], [CompanyName], [CEOName], [ContactPersonName], [ContactPersonNumber], [Notes], [GSTNO], [PAN], [Adhar], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [BillingAddress], [BillingAddress1], [BillingCity], [BillingState], [BillingCountry], [BillingPincode], [ShippingAddress], [ShippingAddress1], [ShippingCity], [ShippingState], [ShippingCountry], [ShippingPincode], [AdharExt], [PanExt]) VALUES (1, N'Hero MotoCorp Ltd', N'Pawan Munjal', N'Nisanth', N'9639207589', NULL, N'GST3547', N'PAN37838', N'ADHAR12846', N'info@hero.com', N'044839830', NULL, N'www.herocorp.com', N'34,Community Centre, ', N'Basant Lok, Vasant Vihar, ', N' New Delhi ', N'Delhi', N'India', N'110057', N'34,Community Centre, ', N'Basant Lok, Vasant Vihar, ', N' New Delhi ', N'Delhi', N'India', N'110057', NULL, NULL)
INSERT [dbo].[CustomerDetails] ([CustomerID], [CompanyName], [CEOName], [ContactPersonName], [ContactPersonNumber], [Notes], [GSTNO], [PAN], [Adhar], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [BillingAddress], [BillingAddress1], [BillingCity], [BillingState], [BillingCountry], [BillingPincode], [ShippingAddress], [ShippingAddress1], [ShippingCity], [ShippingState], [ShippingCountry], [ShippingPincode], [AdharExt], [PanExt]) VALUES (2, N'Yamaha Motor Finance Corporation', N'Hiroyuki Yanagi', N'Harish', N'7811048498', NULL, N'GST9808', N'CS3849QW', N'8393788293789', N'info@yamaha.com', N'8348499388', NULL, N'www.yamaha.com', N'Katella Avenue', N'Cypress', N'New Jersey', N'Washington', N'USA', N'94834098', N'Katella Avenue', N'Cypress', N'New Jersey', N'USA', N'USA', N'94834098', NULL, NULL)
INSERT [dbo].[CustomerDetails] ([CustomerID], [CompanyName], [CEOName], [ContactPersonName], [ContactPersonNumber], [Notes], [GSTNO], [PAN], [Adhar], [PrimaryMailID], [PrimaryPhoneNo], [Fax], [Website], [BillingAddress], [BillingAddress1], [BillingCity], [BillingState], [BillingCountry], [BillingPincode], [ShippingAddress], [ShippingAddress1], [ShippingCity], [ShippingState], [ShippingCountry], [ShippingPincode], [AdharExt], [PanExt]) VALUES (6, N'Royal Enfield ', N'Siddhartha Lal', N'Jack', N'9629207469', NULL, N'GST83037', N'CST8494KN', N'ADHAR970O', N'info@re.com', N'0376498983', NULL, N'www.royalenfield.com', N'Devi Kripa', N'New No.9', N'Chennai', N'Tamilnadu', N'India', N'600053', N'Devi Kripa', N'New No.9', N'Chennai', N'Tamilnadu', N'India', N'600053', N'pdf', N'CST8494KN')
SET IDENTITY_INSERT [dbo].[CustomerDetails] OFF
SET IDENTITY_INSERT [dbo].[MenuMaster] ON 

INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (1, N'Dashboard', N'Home/Index', 0, 1, N'Home', N'Index', N'app-menu__icon fa fa-dashboard')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (2, N'Customer', N'#', 0, 1, N'Customer', NULL, N'app-menu__icon fa fa-user')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (3, N'New Customer', N'Customer/NewCustomer', 2, 1, N'Customer', N'NewCustomer', N'icon fa fa-circle-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (4, N'View Customer', N'Customer/ViewCustomer', 2, 1, N'Customer', N'ViewCustomer', N'icon fa fa-circle-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (5, N'Quote', N'#', 0, 1, N'Quote', NULL, N'app-menu__icon fa fa-copy')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (6, N'New Quote', N'Quote/NewQuote', 5, 1, N'Quote', N'NewQuote', N'icon fa fa-circle-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (7, N'View Quote', N'Quote/ViewQuote', 5, 1, N'Quote', N'ViewQuote', N'icon fa fa-circle-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (8, N'Invoice', N'#', 0, 1, NULL, NULL, N'app-menu__icon fa fa-file')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (9, N'New Invoice', N'Invoice/NewInvoice', 8, 1, N'Invoice', N'NewInvoice', N'icon fa fa-circle-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (10, N'View Invoice', N'Invoice/ViewInvoice', 8, 1, N'Invoice', N'ViewInvoice', N'icon fa fa-circle-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (11, N'Payments', N'Payments/ViewPayments', 0, 1, N'Customer', N'Payments', N'app-menu__icon ffa fa-credit-card')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (12, N'Settings', N'#', 0, 1, N'MasterSettings', NULL, N'app-menu__icon fa fa-cog')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (13, N'Company Details', N'CompanySettings/Company', 12, 1, N'MasterSettings', N'Company', N'icon fa fa-circle-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (14, N'Role Details', N'MasterSettings/Role', 12, 1, N'MasterSettings', N'Role', N'icon fa fa-circle-o')
INSERT [dbo].[MenuMaster] ([MenuId], [MenuName], [MenuUrl], [MenuParentId], [Active], [ControllerName], [ActionName], [IconStyle]) VALUES (15, N'UserDetails', N'UserDetails/ViewUser', 12, 1, N'MasterSettings', N'ViewUser', N'icon fa fa-circle-o')
SET IDENTITY_INSERT [dbo].[MenuMaster] OFF
SET IDENTITY_INSERT [dbo].[MenuPrivilege] ON 

INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (2, 8, 1, 0, 0, 0, 0)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (4, 1, 2, 1, 1, 0, 0)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (5, 5, 1, 1, 1, 1, 1)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (6, 11, 1, 1, 1, 1, 1)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (7, 2, 4, 1, 1, 1, 1)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (8, 5, 8, 1, 0, 0, 1)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (9, 1, 9, 1, 0, 0, 0)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (10, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (11, 2, 1, 1, 1, 1, 1)
INSERT [dbo].[MenuPrivilege] ([PrivilegeID], [MenuID], [RoleID], [CanView], [CanEdit], [CanDelete], [CanCreate]) VALUES (12, 12, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[MenuPrivilege] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (1, N'Super Admin', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (2, N'Admin', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (3, N'Country Manager', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (4, N'Branch Manager', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (5, N'Executive', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (6, N'Sales Manager', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (7, N'Air Executive', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (8, N'Sea Executive', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (9, N'Suppliers', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (10, N'HR Manager', 1)
INSERT [dbo].[Role] ([RoleId], [Name], [Active]) VALUES (12, N'Test', 1)
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[UserAuthentication] ON 

INSERT [dbo].[UserAuthentication] ([UserAuthID], [UserID], [UserName], [Password]) VALUES (3, 3, N'karthik', N'welcome')
INSERT [dbo].[UserAuthentication] ([UserAuthID], [UserID], [UserName], [Password]) VALUES (8, 6, N'deva', N'welcome')
INSERT [dbo].[UserAuthentication] ([UserAuthID], [UserID], [UserName], [Password]) VALUES (9, 7, N'vinoth', N'welcome')
SET IDENTITY_INSERT [dbo].[UserAuthentication] OFF
SET IDENTITY_INSERT [dbo].[UserDetails] ON 

INSERT [dbo].[UserDetails] ([UserID], [FirstName], [LastName], [EmployeeCode], [CompanyID], [RoleId], [Active], [Address], [Address1], [City], [State], [Country], [Pincode], [PrimaryEmailID], [PhoneNumber]) VALUES (3, N'Karthik', N'Madhavan', N'EMP001', 3, 1, 1, N'No 4/2,Kattabomman Street,', N'Parvathy Nagar,Old Perungalathur,', N'Chennai', N'Tamilnadu', N'India', N'600063', N'karthik@gmail.com', N'9629207469')
INSERT [dbo].[UserDetails] ([UserID], [FirstName], [LastName], [EmployeeCode], [CompanyID], [RoleId], [Active], [Address], [Address1], [City], [State], [Country], [Pincode], [PrimaryEmailID], [PhoneNumber]) VALUES (6, N'Deva', N'Kumar', N'EMP002', 3, 7, 1, N'Perungudi', N'Perungudi', N'Chennai', N'Tamilnadu', N'India', N'600453', N'arun@gmail.com', N'7811098046')
INSERT [dbo].[UserDetails] ([UserID], [FirstName], [LastName], [EmployeeCode], [CompanyID], [RoleId], [Active], [Address], [Address1], [City], [State], [Country], [Pincode], [PrimaryEmailID], [PhoneNumber]) VALUES (7, N'Vinoth', N'Kumar', N'EMP001', 4, 2, 1, N'Parvathy Nagar', N'Parvathy Nagar', N'Chennai', N'Tamilandu', N'India', N'600063', N'karthik@gmail.com', N'9629207469')
SET IDENTITY_INSERT [dbo].[UserDetails] OFF
ALTER TABLE [dbo].[MenuPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_MenuPrivilege_MenuMaster] FOREIGN KEY([MenuID])
REFERENCES [dbo].[MenuMaster] ([MenuId])
GO
ALTER TABLE [dbo].[MenuPrivilege] CHECK CONSTRAINT [FK_MenuPrivilege_MenuMaster]
GO
ALTER TABLE [dbo].[MenuPrivilege]  WITH CHECK ADD  CONSTRAINT [FK_MenuPrivilege_Role1] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[MenuPrivilege] CHECK CONSTRAINT [FK_MenuPrivilege_Role1]
GO
ALTER TABLE [dbo].[UserAuthentication]  WITH CHECK ADD  CONSTRAINT [FK_UserAuthentication_UserDetails] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[UserAuthentication] CHECK CONSTRAINT [FK_UserAuthentication_UserDetails]
GO
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_CompanyDetails] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[CompanyDetails] ([CompanyID])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_CompanyDetails]
GO
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_Role]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllCompany]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetAllCompany]
AS
BEGIN

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  [CompanyID]
      ,[CompanyName]
      ,[PrimaryMailID]
      ,[PrimaryPhoneNo]
      ,[Fax]
      ,[Website]
      ,[Address]
      ,[Address1]
      ,[City]
      ,[State]
      ,[Country]
      ,[Pincode]
      ,[GSTNO]
  FROM [AdminApp].[dbo].[CompanyDetails]

  END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetAllRoles]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetAllRoles]
AS
BEGIN
SELECT RoleId,Name,Active FROM dbo.Role
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetCompanyByID]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetCompanyByID]
@CompanyID INT
AS
BEGIN

/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  [CompanyID]
      ,[CompanyName]
      ,[PrimaryMailID]
      ,[PrimaryPhoneNo]
      ,[Fax]
      ,[Website]
      ,[Address]
      ,[Address1]
      ,[City]
      ,[State]
      ,[Country]
      ,[Pincode]
      ,[GSTNO]
  FROM [AdminApp].[dbo].[CompanyDetails] WHERE CompanyID=@CompanyID

  END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserAuthByName]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_GetUserAuthByName]
(
@UserID int

)  
as  
begin  
SELECT[UserAuthID]
      ,[UserID]
      ,[UserName]
      ,[Password]
  FROM [dbo].[UserAuthentication] WHERE UserID=@UserID
End  
GO
/****** Object:  StoredProcedure [dbo].[usp_SaveNewCompany]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SaveNewCompany]
 
@CompanyName NVARCHAR(50)  
,@PrimaryMailID NVARCHAR(50)  
,@PrimaryPhoneNo NVARCHAR(50)  
,@Fax NVARCHAR(10)
,@Website nvarchar(50)
,@Address nvarchar(50)
,@Address1 nvarchar(50)
,@City nvarchar(20)
,@State nvarchar(20)
,@Country nvarchar(50)
,@Pincode nvarchar(20)
,@GSTNO nvarchar(20)
,@ImageExt nvarchar(20)
,@Myout INT OUTPUT  
AS  
BEGIN  
INSERT INTO [dbo].[CompanyDetails]
           ([CompanyName]
           ,[PrimaryMailID]
           ,[PrimaryPhoneNo]
           ,[Fax]
           ,[Website]
           ,[Address]
           ,[Address1]
           ,[City]
           ,[State]
           ,[Country]
           ,[Pincode]
           ,[GSTNO]
		   ,[ImageExt])
     VALUES
           (
		    @CompanyName
           ,@PrimaryMailID
           ,@PrimaryPhoneNo
           ,@Fax
           ,@Website
           ,@Address
           ,@Address1
           ,@City
           ,@State
           ,@Country
           ,@Pincode
           ,@GSTNO
		   ,@ImageExt
		   )
  
SET @Myout = @@IDENTITY  
END  
GO
/****** Object:  StoredProcedure [dbo].[usp_SaveRoles]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SaveRoles]
(
@Active bit,
@Name nvarchar (50),
@RoleId int
,@Myout INT OUTPUT 

)
as
begin
IF(@RoleId>0)
BEGIN
UPDATE  Role set Name=@Name where RoleId=@RoleId
END
IF(@RoleId<0)
BEGIN
Insert into Role(Name,Active) values(@Name,1)
SET @Myout = @@IDENTITY  
End 
  


END

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateCompanyDetails]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_UpdateCompanyDetails]
(
@CompanyID int,
@CompanyName NVARCHAR(50)  
,@PrimaryMailID NVARCHAR(50)  
,@PrimaryPhoneNo NVARCHAR(50)  
,@Fax NVARCHAR(10)
,@Website nvarchar(50)
,@Address nvarchar(50)
,@Address1 nvarchar(50)
,@City nvarchar(20)
,@State nvarchar(20)
,@Country nvarchar(50)
,@Pincode nvarchar(20)
,@GSTNO nvarchar(30)
,@ImagePath nvarchar(10)
,@ImageExt nvarchar(20)
)
as
begin
update CompanyDetails
set CompanyName=@CompanyName,
PrimaryMailID=@PrimaryMailID,
PrimaryPhoneNo=@PrimaryPhoneNo,
Fax=@Fax,
Website=@Website,
Address=@Address,
Address1=@Address1,
City=@City,
State=@State,
Country=@Country,
Pincode=@Pincode,
GSTNO=@GSTNO,
ImageExt=@ImageExt
where CompanyID=@CompanyID
End 
GO
/****** Object:  StoredProcedure [dbo].[usp_ValidateUser]    Script Date: 23-08-2018 20:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[usp_ValidateUser]
(
@UserName varchar(50),
@Password varchar(50)
)  
as  
begin  
SELECT[UserAuthID]
      ,[UserID]
      ,[UserName]
      ,[Password]
  FROM [dbo].[UserAuthentication] WHERE UserName=@UserName AND [Password]=@Password
End  

GO
USE [master]
GO
ALTER DATABASE [AdminApp] SET  READ_WRITE 
GO

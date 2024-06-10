 
CREATE TABLE [dbo].[MasterCategoryMenu](
	[MasterCategoryMenuId] [int] NOT NULL,
	[MasterCategoryMenuName] [nvarchar](3000) NULL,
 CONSTRAINT [PK_MasterCategoryMenu] PRIMARY KEY CLUSTERED 
(
	[MasterCategoryMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterContactUsInformation]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterContactUsInformation](
	[MasterContactUsInformationId] [int] NOT NULL,
	[MasterContactUsInformationIDesc] [nvarchar](max) NULL,
	[MasterContactUsInformationImageUrl] [nvarchar](max) NULL,
	[MasterContactUsInformationRedirect] [nvarchar](max) NULL,
 CONSTRAINT [PK_MasterContactUsInformation] PRIMARY KEY CLUSTERED 
(
	[MasterContactUsInformationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterItemMenu]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterItemMenu](
	[MasterItemMenuId] [int] NOT NULL,
	[MasterCategoryMenuId] [int] NULL,
	[MasterItemMenuTitle] [nvarchar](3000) NULL,
	[MasterItemMenuBreef] [nvarchar](max) NULL,
	[MasterItemMenuDesc] [nvarchar](max) NULL,
	[MasterItemMenuPrice] [money] NULL,
	[MasterItemMenuImageUrl] [nvarchar](max) NULL,
	[MasterItemMenuDate] [datetime] NULL,
 CONSTRAINT [PK_MasterItemMenu] PRIMARY KEY CLUSTERED 
(
	[MasterItemMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterMenu]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterMenu](
	[MasterMenuId] [int] NOT NULL,
	[MasterMenuName] [nvarchar](1000) NOT NULL,
	[MasterMenuUrl] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_MasterMenu] PRIMARY KEY CLUSTERED 
(
	[MasterMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterOffer]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterOffer](
	[MasterOfferId] [int] NOT NULL,
	[MasterOfferTitle] [nvarchar](max) NULL,
	[MasterOfferBreef] [nvarchar](max) NULL,
	[MasterOfferDesc] [nvarchar](max) NULL,
	[MasterOfferImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_MasterOffer] PRIMARY KEY CLUSTERED 
(
	[MasterOfferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterPartner]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterPartner](
	[MasterPartnerId] [int] NOT NULL,
	[MasterPartnerName] [nvarchar](1000) NULL,
	[MasterPartnerLogoImageUrl] [nvarchar](max) NULL,
	[MasterPartnerWebsiteUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_MasterPartner] PRIMARY KEY CLUSTERED 
(
	[MasterPartnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterServices]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterServices](
	[MasterServicesId] [int] NOT NULL,
	[MasterServicesTitle] [nvarchar](3000) NULL,
	[MasterServicesDesc] [nvarchar](max) NULL,
	[MasterServicesImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_MasterServices] PRIMARY KEY CLUSTERED 
(
	[MasterServicesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterSlider]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterSlider](
	[MasterSliderId] [int] NOT NULL,
	[MasterSliderTitle] [nvarchar](1000) NULL,
	[MasterSliderBreef] [nvarchar](1000) NULL,
	[MasterSliderDesc] [nvarchar](1000) NULL,
	[MasterSliderUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_MasterSlider] PRIMARY KEY CLUSTERED 
(
	[MasterSliderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterSocialMedia]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterSocialMedia](
	[MasterSocialMediaId] [int] NOT NULL,
	[MasterSocialMediaImageUrl] [nvarchar](max) NOT NULL,
	[MasterSocialMediaUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MasterSocialMedia] PRIMARY KEY CLUSTERED 
(
	[MasterSocialMediaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterWorkingHours]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterWorkingHours](
	[MasterWorkingHoursId] [int] NOT NULL,
	[MasterWorkingHoursIdName] [nvarchar](1000) NULL,
	[MasterWorkingHoursIdTimeFormTo] [nvarchar](3000) NULL,
 CONSTRAINT [PK_MasterWorkingHours] PRIMARY KEY CLUSTERED 
(
	[MasterWorkingHoursId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemSetting]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemSetting](
	[SystemSettingId] [int] NOT NULL,
	[SystemSettingLogoImageUrl] [nvarchar](max) NULL,
	[SystemSettingLogoImageUrl2] [nvarchar](max) NULL,
	[SystemSettingCopyright] [nvarchar](max) NULL,
	[SystemSettingWelcomeNoteTitle] [nvarchar](max) NULL,
	[SystemSettingWelcomeNoteBreef] [nvarchar](max) NULL,
	[SystemSettingWelcomeNoteDesc] [nvarchar](max) NULL,
	[SystemSettingWelcomeNoteUrl] [nvarchar](max) NULL,
	[SystemSettingWelcomeNoteImageUrl] [nvarchar](max) NULL,
	[SystemSettingMapLocation] [nvarchar](max) NULL,
 CONSTRAINT [PK_SystemSetting] PRIMARY KEY CLUSTERED 
(
	[SystemSettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionBookTable]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionBookTable](
	[TransactionBookTableId] [int] NOT NULL,
	[TransactionBookTableFullName] [nvarchar](1000) NULL,
	[TransactionBookTableEmail] [nvarchar](1000) NULL,
	[TransactionBookTableMobileNumber] [nvarchar](1000) NULL,
	[TransactionBookTableDate] [datetime] NULL,
 CONSTRAINT [PK_TransactionBookTable] PRIMARY KEY CLUSTERED 
(
	[TransactionBookTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionContactUs]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionContactUs](
	[TransactionContactUsID] [int] NOT NULL,
	[TransactionContactUsFullName] [nvarchar](1000) NULL,
	[TransactionContactUsEmail] [nvarchar](1000) NULL,
	[TransactionContactUsSubject] [nvarchar](1000) NULL,
	[TransactionContactUsMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_TransactionContactUs] PRIMARY KEY CLUSTERED 
(
	[TransactionContactUsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionNewsletter]    Script Date: 06/12/2022 7:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionNewsletter](
	[TransactionNewsletterId] [int] NOT NULL,
	[TransactionNewsletterEmail] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TransactionNewsletter] PRIMARY KEY CLUSTERED 
(
	[TransactionNewsletterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MasterItemMenu]  WITH CHECK ADD  CONSTRAINT [FK_MasterItemMenu_MasterCategoryMenu] FOREIGN KEY([MasterCategoryMenuId])
REFERENCES [dbo].[MasterCategoryMenu] ([MasterCategoryMenuId])
GO
ALTER TABLE [dbo].[MasterItemMenu] CHECK CONSTRAINT [FK_MasterItemMenu_MasterCategoryMenu]
GO

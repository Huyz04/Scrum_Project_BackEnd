Create Database BackEndScrum
GO
Use BackEndScrum
-- Create Table
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Userr](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Name] [varchar](255) NULL,
	[Birthday] [datetime] NULL,
	[Class] [varchar](255) NULL,
	[Role] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
-- Campaign
CREATE TABLE [dbo].[Campaign](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NULL,
	[Description] [varchar](255) NULL,
	[CreatedAt] [datetime] NULL,
	[Status] [varchar](255) NULL,
 CONSTRAINT [PK_campaign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Register

CREATE TABLE [dbo].[RegisterCampain](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[Status] [varchar](255) NULL,
	[UserId] [uniqueidentifier] NULL,
	[CampaignId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RegisterCampain]  WITH CHECK ADD  CONSTRAINT [FK_Register_Campaign] FOREIGN KEY([CampaignId])
REFERENCES [dbo].[Campaign] ([Id])
GO

ALTER TABLE [dbo].[RegisterCampain] CHECK CONSTRAINT [FK_Register_Campaign]
GO

ALTER TABLE [dbo].[RegisterCampain]  WITH CHECK ADD  CONSTRAINT [FK_Register_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Userr] ([Id])
GO

ALTER TABLE [dbo].[RegisterCampain] CHECK CONSTRAINT [FK_Register_User]
GO

-- data
INSERT INTO [dbo].[Userr]
           ([Id], [UserName], [Password], [Name], [Birthday], [Class], [Role])
     VALUES
           ('c5b3f8d5-7635-42a7-a365-2ed16f12e1d3', 'john_doe', 'P@ssw0rd123', 'John Doe', '1995-04-12', 'Class A', 'University'),
           ('ed7c857f-fc35-49bb-ae0a-6119c4b9cfae', 'jane_smith', 'P@ssJane123', 'Jane Smith', '1997-09-21', 'Class B', 'Student'),
           ('a6f7d58b-4e4f-4c2c-986f-c6c23498fb59', 'mark_jones', 'P@ssMark456', 'Mark Jones', '1998-02-15', 'Class C', 'Community');


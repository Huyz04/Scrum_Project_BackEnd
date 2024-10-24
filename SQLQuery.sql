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
INSERT INTO [dbo].[Userr]
           ([Id], [UserName], [Password], [Name], [Birthday], [Class], [Role])
     VALUES
           ('c5b3f8d5-7635-42a7-a365-2ed16d12e1d7', 'Community', '123', 'Do Van Nho', '2004-04-12', 'Null', 'Community')
Alter table Campaign
add University nvarchar(255)

select * from Userr

INSERT INTO [dbo].[Campaign]
           ([Id]
           ,[Name]
           ,[Description]
           ,[CreatedAt]
           ,[Status]
           ,[Time]
           ,[Quantity]
           ,[University])
     VALUES
           (NEWID(), N'??i hình C? Chi', N'"Chi?n d?ch ''Mùa Hè Xanh'' t?i C? Chi ???c t? ch?c v?i m?c tiêu mang l?i s? h? tr? thi?t th?c cho bà con nghèo, thông qua các ho?t ??ng nh? s?a ch?a nhà, cung c?p n??c s?ch và t? ch?c các l?p h?c k? n?ng s?ng."', GETDATE(), 'Active', '8-10-2024 - 15-10-2024', 70, N'??i h?c Công Ngh? Thông Tin'),
           (NEWID(), 'Campaign B', 'Description B', GETDATE(), 'Active', '2024-11-01 14:00:00', 200, N'University B'),
           (NEWID(), 'Campaign C', 'Description C', GETDATE(), 'Inactive', '2024-12-15 09:00:00', 300, N'University C');
GO

select * from Campaign

Alter table Campaign
add Location nvarchar(255)
alter column Name nvarchar(255)
alter column Time varchar(255)

update Campaign
set Status = 'Waiting'
where Id ='B9AB72DF-4DBB-487D-B947-E31308752C8A'
;

alter table RegisterCampain
alter column MSSV varchar(255) not null
add MSSV nvarchar(255),
SDT varchar(11),
Email varchar(255),
Major nvarchar(255),
Address nvarchar(255),
SDTParent varchar(11),
Reason nvarchar(255),
Aim nvarchar(255)

alter table Userr
add constraint PK_user primary key (UserName)


alter table RegisterCampain
add constraint fk_user_register foreign key (MSSV) references Userr(UserName)
alter column UserName varchar(255) not null

select * from Userr

select * from RegisterCampain

select * from Campaign

update RegisterCampain
set Status = 'Accepted'
where 
Id ='BC41618E-532C-448D-379E-08DCF3D4DC34'
USE [Pertemps]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 06/08/2020 10:30:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Skills]') AND type in (N'U'))
DROP TABLE [dbo].[Skills]
GO
/****** Object:  Table [dbo].[CandidateSkills]    Script Date: 06/08/2020 10:30:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CandidateSkills]') AND type in (N'U'))
DROP TABLE [dbo].[CandidateSkills]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 06/08/2020 10:30:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Candidates]') AND type in (N'U'))
DROP TABLE [dbo].[Candidates]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 06/08/2020 10:30:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Position] [varchar](max) NOT NULL,
	[Contract] [bit] NOT NULL,
	[Available] [bit] NOT NULL,
	[Match] [float] NOT NULL,
 CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CandidateSkills]    Script Date: 06/08/2020 10:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CandidateId] [int] NOT NULL,
	[SkillId] [int] NOT NULL,
 CONSTRAINT [PK_CandidateSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 06/08/2020 10:30:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

Insert into [dbo].[Skills] Values ('C#');
Insert into [dbo].[Skills] Values ('Java');
Insert into [dbo].[Skills] Values ('Angular');          
Insert into [dbo].[Skills] Values ('React');
Insert into [dbo].[Skills] Values ('Project Management');
Insert into [dbo].[Skills] Values ('Azure');
Insert into [dbo].[Skills] Values ('Front End');
Insert into [dbo].[Skills] Values ('SQL');
Insert into [dbo].[Skills] Values ('WPF');
Insert into [dbo].[Skills] Values ('VB .net');
Insert into [dbo].[Skills] Values ('JavaScript');
Insert into [dbo].[Skills] Values ('Mobile Development');
Insert into [dbo].[Skills] Values ('HTML');
Insert into [dbo].[Skills] Values ('C++');
     
GO

insert into [dbo].[Candidates] values ('Sam Lad', 'Contract Front End Developer', 1,1, 5);
insert into [dbo].[Candidates] values ('John Doe', 'Front End Developer', 0,0, 4);
insert into [dbo].[Candidates] values ('Mary Moe', 'Back End Developer', 0,1, 3.5);
insert into [dbo].[Candidates] values ('John Smith', 'Angular Developer', 1,1, 2.5);
insert into [dbo].[Candidates] values ('Mandy Smith', 'C# Developer', 1,0, 4.5);
insert into [dbo].[Candidates] values ('John Fake', 'Java Developer', 0,1, 1.5);

GO

insert into [dbo].[CandidateSkills] values (1, 1);
insert into [dbo].[CandidateSkills] values (1, 3);
insert into [dbo].[CandidateSkills] values (1, 4);
insert into [dbo].[CandidateSkills] values (2, 3);
insert into [dbo].[CandidateSkills] values (2, 5);
insert into [dbo].[CandidateSkills] values (2, 6);
insert into [dbo].[CandidateSkills] values (3, 7);
insert into [dbo].[CandidateSkills] values (3, 8);
insert into [dbo].[CandidateSkills] values (3, 1);
insert into [dbo].[CandidateSkills] values (4, 8);
insert into [dbo].[CandidateSkills] values (4, 9);
insert into [dbo].[CandidateSkills] values (4, 10);
insert into [dbo].[CandidateSkills] values (5, 11);
insert into [dbo].[CandidateSkills] values (5, 12);
insert into [dbo].[CandidateSkills] values (5, 13);
insert into [dbo].[CandidateSkills] values (6, 5);
insert into [dbo].[CandidateSkills] values (6, 8);
insert into [dbo].[CandidateSkills] values (6, 14);

GO


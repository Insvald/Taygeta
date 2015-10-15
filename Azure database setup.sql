/* 
	The Taygeta Project
	(c) 2015 Ilya Rovensky
*/

use taygeta_db

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (450)     NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [dbo].[AspNetUsers]([NormalizedEmail] ASC);


GO
CREATE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[AspNetUsers]([NormalizedUserName] ASC);

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               NVARCHAR (450) NOT NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    CONSTRAINT [PK_IdentityRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

GO
CREATE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([NormalizedName] ASC);

CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    [RoleId]     NVARCHAR (450) NULL,
    CONSTRAINT [PK_IdentityRoleClaim<string>] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IdentityRoleClaim<string>_IdentityRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id])
);

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    [UserId]     NVARCHAR (450) NULL,
    CONSTRAINT [PK_IdentityUserClaim<string>] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IdentityUserClaim<string>_ApplicationUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider]       NVARCHAR (450) NOT NULL,
    [ProviderKey]         NVARCHAR (450) NOT NULL,
    [ProviderDisplayName] NVARCHAR (MAX) NULL,
    [UserId]              NVARCHAR (450) NULL,
    CONSTRAINT [PK_IdentityUserLogin<string>] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_IdentityUserLogin<string>_ApplicationUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (450) NOT NULL,
    [RoleId] NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_IdentityUserRole<string>] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_IdentityUserRole<string>_ApplicationUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_IdentityUserRole<string>_IdentityRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id])
);

CREATE TABLE [dbo].[Logs] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Date]      DATETIME        NOT NULL,
    [Thread]    VARCHAR (255)   NOT NULL,
    [Level]     VARCHAR (50)    NOT NULL,
    [Logger]    VARCHAR (255)   NOT NULL,
    [Message]   NVARCHAR (4000) NOT NULL,
    [Exception] NVARCHAR (2000) NULL,
    CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Pages] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [Content]       NTEXT          NULL,
    [HomePageTitle] NVARCHAR (MAX) NULL,
    [LastModified]  DATETIME2 (7)  NOT NULL,
    [Url]           NVARCHAR (MAX) NULL,
    [Wrapped]       DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Resources] (
    [Name]        NVARCHAR (440) NOT NULL,
    [CultureName] NVARCHAR (5)   NOT NULL,
    [Value]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED ([Name] ASC, [CultureName] ASC)
);

CREATE TABLE [dbo].[Vacancies] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [Closed]       DATETIME2 (7)  NULL,
    [CompanyName]  NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [EMail]        NVARCHAR (254) NULL,
    [Location]     NVARCHAR (MAX) NULL,
    [Position]     NVARCHAR (MAX) NULL,
    [Published]    DATETIME2 (7)  NOT NULL,
    [Requirements] NVARCHAR (MAX) NULL,
    [Url]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Vacancy] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Wrappers] (
    [PageId]    BIGINT         NOT NULL,
    [RecordNo]  INT            NOT NULL,
    [FieldName] NVARCHAR (256) NOT NULL,
    [ValuePath] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Wrapper] PRIMARY KEY CLUSTERED ([PageId] ASC, [RecordNo] ASC, [FieldName] ASC),
    CONSTRAINT [FK_Wrapper_Page_PageId] FOREIGN KEY ([PageId]) REFERENCES [dbo].[Pages] ([Id])
);


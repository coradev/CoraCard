-- ****************** Sql: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [Tag]
CREATE TABLE [Tag]
(
 [TAGID] int IDENTITY (1, 1) NOT NULL ,
 [NAME]  varchar(50) NOT NULL ,


 CONSTRAINT [PK_tag] PRIMARY KEY CLUSTERED ([TAGID] ASC)
);
GO
-- ************************************** [Status]
CREATE TABLE [Status]
(
 [STATUSID] int IDENTITY (1, 1) NOT NULL ,
 [NAME]     varchar(50) NOT NULL ,


 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED ([STATUSID] ASC)
);
GO
-- ************************************** [Social]
CREATE TABLE [Social]
(
 [SOCIALID] int IDENTITY (1, 1) NOT NULL ,
 [NAME]     varchar(500) NOT NULL ,
 [LINK]     varchar(500) NOT NULL ,
 [IMAGE]    varchar(max) NOT NULL ,


 CONSTRAINT [PK_social] PRIMARY KEY CLUSTERED ([SOCIALID] ASC)
);
GO
-- ************************************** [Role]
CREATE TABLE [Role]
(
 [ROLEID] int IDENTITY (1, 1) NOT NULL ,
 [NAME]   nvarchar(50) NOT NULL ,


 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED ([ROLEID] ASC)
);
GO
-- ************************************** [Category]
CREATE TABLE [Category]
(
 [CATEGORYID] int IDENTITY (1, 1) NOT NULL ,
 [NAME]       varchar(100) NOT NULL ,


 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED ([CATEGORYID] ASC)
);
GO
-- ************************************** [User]
CREATE TABLE [User]
(
 [USERID]    int IDENTITY (1, 1) NOT NULL ,
 [USERNAME]  varchar(50) NOT NULL ,
 [PASSWORD]  varchar(500) NOT NULL ,
 [EMAIL]     varchar(100) NOT NULL ,
 [FULLNAME]  nvarchar(100) NOT NULL ,
 [BIOGRAPHY] nvarchar(max) NOT NULL ,
 [STATUSID]  int NOT NULL ,


 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([USERID] ASC),
 CONSTRAINT [FK_95] FOREIGN KEY ([STATUSID])  REFERENCES [Status]([STATUSID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_96] ON [User] 
 (
  [STATUSID] ASC
 )

GO
-- ************************************** [UserSocial]
CREATE TABLE [UserSocial]
(
 [USERID]   int NOT NULL ,
 [SOCIALID] int NOT NULL ,


 CONSTRAINT [FK_47] FOREIGN KEY ([USERID])  REFERENCES [User]([USERID]),
 CONSTRAINT [FK_50] FOREIGN KEY ([SOCIALID])  REFERENCES [Social]([SOCIALID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_48] ON [UserSocial] 
 (
  [USERID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_51] ON [UserSocial] 
 (
  [SOCIALID] ASC
 )

GO
-- ************************************** [UserRole]
CREATE TABLE [UserRole]
(
 [USERID] int NOT NULL ,
 [ROLEID] int NOT NULL ,


 CONSTRAINT [FK_100] FOREIGN KEY ([USERID])  REFERENCES [User]([USERID]),
 CONSTRAINT [FK_103] FOREIGN KEY ([ROLEID])  REFERENCES [Role]([ROLEID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_101] ON [UserRole] 
 (
  [USERID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_104] ON [UserRole] 
 (
  [ROLEID] ASC
 )

GO
-- ************************************** [Post]
CREATE TABLE [Post]
(
 [POSTID]      int IDENTITY (1, 1) NOT NULL ,
 [TITLE]       nvarchar(500) NOT NULL ,
 [DESCRIPTION] nvarchar(max) NOT NULL ,
 [CONTENT]     nvarchar(max) NOT NULL ,
 [UPDATETIME]  date NOT NULL ,
 [CATEGORYID]  int NOT NULL ,
 [USERID]      int NOT NULL ,


 CONSTRAINT [PK_post] PRIMARY KEY CLUSTERED ([POSTID] ASC),
 CONSTRAINT [FK_71] FOREIGN KEY ([CATEGORYID])  REFERENCES [Category]([CATEGORYID]),
 CONSTRAINT [FK_83] FOREIGN KEY ([USERID])  REFERENCES [User]([USERID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_72] ON [Post] 
 (
  [CATEGORYID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_84] ON [Post] 
 (
  [USERID] ASC
 )

GO
-- ************************************** [Contact]
CREATE TABLE [Contact]
(
 [CONTACTID] int IDENTITY (1, 1) NOT NULL ,
 [NAME]      nvarchar(100) NOT NULL ,
 [EMAIL]     varchar(100) NOT NULL ,
 [CONTENT]   nvarchar(500) NOT NULL ,
 [USERID]    int NOT NULL ,


 CONSTRAINT [PK_contact] PRIMARY KEY CLUSTERED ([CONTACTID] ASC),
 CONSTRAINT [FK_87] FOREIGN KEY ([USERID])  REFERENCES [User]([USERID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_88] ON [Contact] 
 (
  [USERID] ASC
 )

GO
-- ************************************** [PostTag]
CREATE TABLE [PostTag]
(
 [POSTID] int NOT NULL ,
 [TAGID]  int NOT NULL ,


 CONSTRAINT [FK_77] FOREIGN KEY ([POSTID])  REFERENCES [Post]([POSTID]),
 CONSTRAINT [FK_80] FOREIGN KEY ([TAGID])  REFERENCES [Tag]([TAGID])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_78] ON [PostTag] 
 (
  [POSTID] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_81] ON [PostTag] 
 (
  [TAGID] ASC
 )

GO

/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2015/3/11 8:30:57                            */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('T_Category')
            and   type = 'U')
   drop table T_Category
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Config')
            and   type = 'U')
   drop table T_Config
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_FriendLink')
            and   type = 'U')
   drop table T_FriendLink
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Joke')
            and   type = 'U')
   drop table T_Joke
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_User')
            and   type = 'U')
   drop table T_User
go

/*==============================================================*/
/* Table: T_Category                                            */
/*==============================================================*/
create table T_Category (
   ID                   int                  not null,
   Name                 nvarchar(100)        not null default '',
   AddDate              datetime             not null default getdate(),
   State                int                  not null default 1,
   PinYin               nvarchar(100)        not null default '',
   constraint PK_T_CATEGORY primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Category') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Category' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '分类', 
   'user', @CurrentUser, 'table', 'T_Category'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '分类名称',
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '有效状态',
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Category')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PinYin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'PinYin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '分类拼音',
   'user', @CurrentUser, 'table', 'T_Category', 'column', 'PinYin'
go

/*==============================================================*/
/* Table: T_Config                                              */
/*==============================================================*/
create table T_Config (
   ID                   int                  identity,
   constraint PK_T_CONFIG primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Config') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Config' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '系统配置', 
   'user', @CurrentUser, 'table', 'T_Config'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '系统配置',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'ID'
go

/*==============================================================*/
/* Table: T_FriendLink                                          */
/*==============================================================*/
create table T_FriendLink (
   ID                   int                  identity,
   Name                 nvarchar(100)        not null default '',
   LinkUrl              nvarchar(100)        not null,
   LinkMan              nvarchar(100)        not null default '',
   State                int                  not null default 1,
   AddDate              datetime             not null default getdate(),
   UserID               int                  not null default 0,
   constraint PK_T_FRIENDLINK primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_FriendLink') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_FriendLink' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '友情链接', 
   'user', @CurrentUser, 'table', 'T_FriendLink'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '网站名称',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LinkUrl')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'LinkUrl'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '链接',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'LinkUrl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LinkMan')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'LinkMan'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系人',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'LinkMan'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '有效状态',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加时间',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_FriendLink')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'UserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加人id',
   'user', @CurrentUser, 'table', 'T_FriendLink', 'column', 'UserID'
go

/*==============================================================*/
/* Table: T_Joke                                                */
/*==============================================================*/
create table T_Joke (
   ID                   int                  identity,
   Title                nvarchar(500)        not null default '',
   Content              nvarchar(500)        not null default '0',
   Type                 int                  not null,
   State                int                  not null default 0,
   CheckUserId          int                  not null default 0,
   AddDate              datetime             not null default getdate(),
   CheckDate            datetime             not null default '1900-1-1',
   LikeCount            int                  not null default 0,
   HateCount            int                  not null default 0,
   PostID               int                  not null default 0,
   CommentCount         int                  not null default 0,
   Category             int                  not null default 0,
   ReadCount            int                  not null default 0,
   constraint PK_T_JOKE primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Joke') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Joke' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '笑话信息', 
   'user', @CurrentUser, 'table', 'T_Joke'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Title')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'Title'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '标题',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'Title'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'Content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '内容',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Type')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'Type'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '类型',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'Type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '审核状态',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CheckUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'CheckUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '审核人id',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'CheckUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'AddDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '添加日期',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'AddDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CheckDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'CheckDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '审核日期',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'CheckDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LikeCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'LikeCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '点赞次数',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'LikeCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HateCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'HateCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '踩次数',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'HateCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'PostID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布人id',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'PostID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommentCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'CommentCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '评论次数',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'CommentCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Category')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'Category'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '笑话分类',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'Category'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Joke')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ReadCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'ReadCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '阅读次数',
   'user', @CurrentUser, 'table', 'T_Joke', 'column', 'ReadCount'
go

/*==============================================================*/
/* Table: T_User                                                */
/*==============================================================*/
create table T_User (
   ID                   int                  identity,
   UserName             nvarchar(100)        not null,
   NikeName             nvarchar(100)        not null,
   Email                nvarchar(100)        not null,
   Password             nvarchar(200)        not null,
   RegisterDate         datetime             not null default getdate(),
   LastLogin            datetime             not null default '1900-01-01',
   Photo                nvarchar(100)        not null default '',
   State                int                  not null default 1,
   IsAdmin              int                  not null default 0,
   constraint PK_T_USER primary key (ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_User') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_User' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '用户信息表', 
   'user', @CurrentUser, 'table', 'T_User'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户ID',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'UserName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   ' 用户名',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'UserName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NikeName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'NikeName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '昵称',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'NikeName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Email')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'Email'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '电子邮件',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'Email'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Password')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'Password'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '密码',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'Password'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RegisterDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'RegisterDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '注册日期',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'RegisterDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastLogin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'LastLogin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '上次登录时间',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'LastLogin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Photo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'Photo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户头像',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'Photo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'State')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'State'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户状态',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'State'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_User')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsAdmin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_User', 'column', 'IsAdmin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否是管理员',
   'user', @CurrentUser, 'table', 'T_User', 'column', 'IsAdmin'
go



-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/26/2013 11:12:13
-- Generated from EDMX file: C:\Docs\MSSE680\MvcPointApp\PointSiteTest\DataLayer\PointAppDBContainer.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PointAppDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_contact_member_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[contact] DROP CONSTRAINT [FK_contact_member_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_contactemail_contact_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[contactemail] DROP CONSTRAINT [FK_contactemail_contact_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_feerequest_member_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[feerequest] DROP CONSTRAINT [FK_feerequest_member_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_member2activity_act_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2activity] DROP CONSTRAINT [FK_member2activity_act_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_member2activity_member_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2activity] DROP CONSTRAINT [FK_member2activity_member_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_profile_dependent_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[profile] DROP CONSTRAINT [FK_profile_dependent_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_profile_family_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[profile] DROP CONSTRAINT [FK_profile_family_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_profile_member_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[profile] DROP CONSTRAINT [FK_profile_member_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_profile_role_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member] DROP CONSTRAINT [FK_profile_role_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_profile_student_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[profile] DROP CONSTRAINT [FK_profile_student_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_sessioncal_type_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sessioncal] DROP CONSTRAINT [FK_sessioncal_type_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_signup_member_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[signup] DROP CONSTRAINT [FK_signup_member_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_signup_sessioncal_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[signup] DROP CONSTRAINT [FK_signup_sessioncal_fk];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[activity];
GO
IF OBJECT_ID(N'[dbo].[approle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[approle];
GO
IF OBJECT_ID(N'[dbo].[contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[contact];
GO
IF OBJECT_ID(N'[dbo].[contactemail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[contactemail];
GO
IF OBJECT_ID(N'[dbo].[family]', 'U') IS NOT NULL
    DROP TABLE [dbo].[family];
GO
IF OBJECT_ID(N'[dbo].[feerequest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[feerequest];
GO
IF OBJECT_ID(N'[dbo].[member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[member];
GO
IF OBJECT_ID(N'[dbo].[member2activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[member2activity];
GO
IF OBJECT_ID(N'[dbo].[profile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[profile];
GO
IF OBJECT_ID(N'[dbo].[sessioncal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sessioncal];
GO
IF OBJECT_ID(N'[dbo].[sessiontype]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sessiontype];
GO
IF OBJECT_ID(N'[dbo].[signup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[signup];
GO
IF OBJECT_ID(N'[dbo].[student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[student];
GO
IF OBJECT_ID(N'[PointAppDBContainerStoreContainer].[v_point_bal]', 'U') IS NOT NULL
    DROP TABLE [PointAppDBContainerStoreContainer].[v_point_bal];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'activities'
CREATE TABLE [dbo].[activities] (
    [activityid] int IDENTITY(1,1) NOT NULL,
    [actname] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'approles'
CREATE TABLE [dbo].[approles] (
    [approleid] int IDENTITY(1,1) NOT NULL,
    [rolename] nvarchar(50)  NOT NULL,
    [note] nvarchar(250)  NULL
);
GO

-- Creating table 'contacts'
CREATE TABLE [dbo].[contacts] (
    [contactid] int IDENTITY(1,1) NOT NULL,
    [memberid] int  NOT NULL,
    [firstname] nvarchar(30)  NOT NULL,
    [lastname] nvarchar(30)  NOT NULL,
    [middlename] nvarchar(30)  NULL,
    [address] nvarchar(100)  NOT NULL,
    [altaddress] nvarchar(100)  NULL,
    [city] nvarchar(30)  NOT NULL,
    [state] nchar(2)  NULL,
    [zip] nvarchar(10)  NULL,
    [homephone] nvarchar(20)  NULL,
    [workphone] nvarchar(20)  NULL,
    [mobilephone] nvarchar(20)  NULL
);
GO

-- Creating table 'contactemails'
CREATE TABLE [dbo].[contactemails] (
    [contactemailid] int IDENTITY(1,1) NOT NULL,
    [contactid] int  NULL,
    [emailaddress] nvarchar(50)  NULL
);
GO

-- Creating table 'families'
CREATE TABLE [dbo].[families] (
    [familyid] int IDENTITY(1,1) NOT NULL,
    [familyname] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'feerequests'
CREATE TABLE [dbo].[feerequests] (
    [feerequestid] int IDENTITY(1,1) NOT NULL,
    [memberid] int  NULL,
    [requestdate] datetime  NULL,
    [requestamt] decimal(19,4)  NULL,
    [pointbal] int  NULL
);
GO

-- Creating table 'members'
CREATE TABLE [dbo].[members] (
    [memberid] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(30)  NOT NULL,
    [userpass] nvarchar(200)  NOT NULL,
    [passsalt] nvarchar(200)  NOT NULL,
    [approleid] int  NULL
);
GO

-- Creating table 'profiles'
CREATE TABLE [dbo].[profiles] (
    [profileid] int IDENTITY(1,1) NOT NULL,
    [memberid] int  NOT NULL,
    [memberstatus] nvarchar(10)  NOT NULL,
    [studentid] int  NULL,
    [dependentid] int  NULL,
    [familyid] int  NOT NULL
);
GO

-- Creating table 'sessioncals'
CREATE TABLE [dbo].[sessioncals] (
    [sessioncalid] int IDENTITY(1,1) NOT NULL,
    [sessiondate] datetime  NULL,
    [sessiontypeid] int  NULL,
    [sessionnum] int  NULL,
    [sessionamt] decimal(19,4)  NULL,
    [sessionpoint] int  NULL
);
GO

-- Creating table 'sessiontypes'
CREATE TABLE [dbo].[sessiontypes] (
    [sessiontypeid] int IDENTITY(1,1) NOT NULL,
    [typename] nvarchar(50)  NOT NULL,
    [note] nvarchar(250)  NULL
);
GO

-- Creating table 'signups'
CREATE TABLE [dbo].[signups] (
    [signupid] int IDENTITY(1,1) NOT NULL,
    [memberid] int  NULL,
    [sessioncalid] int  NULL,
    [pointearn] int  NULL,
    [isshow] nchar(1)  NULL
);
GO

-- Creating table 'students'
CREATE TABLE [dbo].[students] (
    [studentid] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(30)  NOT NULL,
    [lastname] nvarchar(30)  NULL,
    [middlename] nvarchar(30)  NOT NULL,
    [grade] int  NULL,
    [active] nchar(1)  NULL
);
GO

-- Creating table 'v_point_bal'
CREATE TABLE [dbo].[v_point_bal] (
    [familyid] int  NOT NULL,
    [family_earn] int  NULL
);
GO

-- Creating table 'member2activity'
CREATE TABLE [dbo].[member2activity] (
    [activities_activityid] int  NOT NULL,
    [members_memberid] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [activityid] in table 'activities'
ALTER TABLE [dbo].[activities]
ADD CONSTRAINT [PK_activities]
    PRIMARY KEY CLUSTERED ([activityid] ASC);
GO

-- Creating primary key on [approleid] in table 'approles'
ALTER TABLE [dbo].[approles]
ADD CONSTRAINT [PK_approles]
    PRIMARY KEY CLUSTERED ([approleid] ASC);
GO

-- Creating primary key on [contactid] in table 'contacts'
ALTER TABLE [dbo].[contacts]
ADD CONSTRAINT [PK_contacts]
    PRIMARY KEY CLUSTERED ([contactid] ASC);
GO

-- Creating primary key on [contactemailid] in table 'contactemails'
ALTER TABLE [dbo].[contactemails]
ADD CONSTRAINT [PK_contactemails]
    PRIMARY KEY CLUSTERED ([contactemailid] ASC);
GO

-- Creating primary key on [familyid] in table 'families'
ALTER TABLE [dbo].[families]
ADD CONSTRAINT [PK_families]
    PRIMARY KEY CLUSTERED ([familyid] ASC);
GO

-- Creating primary key on [feerequestid] in table 'feerequests'
ALTER TABLE [dbo].[feerequests]
ADD CONSTRAINT [PK_feerequests]
    PRIMARY KEY CLUSTERED ([feerequestid] ASC);
GO

-- Creating primary key on [memberid] in table 'members'
ALTER TABLE [dbo].[members]
ADD CONSTRAINT [PK_members]
    PRIMARY KEY CLUSTERED ([memberid] ASC);
GO

-- Creating primary key on [profileid] in table 'profiles'
ALTER TABLE [dbo].[profiles]
ADD CONSTRAINT [PK_profiles]
    PRIMARY KEY CLUSTERED ([profileid] ASC);
GO

-- Creating primary key on [sessioncalid] in table 'sessioncals'
ALTER TABLE [dbo].[sessioncals]
ADD CONSTRAINT [PK_sessioncals]
    PRIMARY KEY CLUSTERED ([sessioncalid] ASC);
GO

-- Creating primary key on [sessiontypeid] in table 'sessiontypes'
ALTER TABLE [dbo].[sessiontypes]
ADD CONSTRAINT [PK_sessiontypes]
    PRIMARY KEY CLUSTERED ([sessiontypeid] ASC);
GO

-- Creating primary key on [signupid] in table 'signups'
ALTER TABLE [dbo].[signups]
ADD CONSTRAINT [PK_signups]
    PRIMARY KEY CLUSTERED ([signupid] ASC);
GO

-- Creating primary key on [studentid] in table 'students'
ALTER TABLE [dbo].[students]
ADD CONSTRAINT [PK_students]
    PRIMARY KEY CLUSTERED ([studentid] ASC);
GO

-- Creating primary key on [familyid] in table 'v_point_bal'
ALTER TABLE [dbo].[v_point_bal]
ADD CONSTRAINT [PK_v_point_bal]
    PRIMARY KEY CLUSTERED ([familyid] ASC);
GO

-- Creating primary key on [activities_activityid], [members_memberid] in table 'member2activity'
ALTER TABLE [dbo].[member2activity]
ADD CONSTRAINT [PK_member2activity]
    PRIMARY KEY NONCLUSTERED ([activities_activityid], [members_memberid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [approleid] in table 'members'
ALTER TABLE [dbo].[members]
ADD CONSTRAINT [FK_profile_role_fk]
    FOREIGN KEY ([approleid])
    REFERENCES [dbo].[approles]
        ([approleid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_profile_role_fk'
CREATE INDEX [IX_FK_profile_role_fk]
ON [dbo].[members]
    ([approleid]);
GO

-- Creating foreign key on [memberid] in table 'contacts'
ALTER TABLE [dbo].[contacts]
ADD CONSTRAINT [FK_contact_member_fk]
    FOREIGN KEY ([memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_contact_member_fk'
CREATE INDEX [IX_FK_contact_member_fk]
ON [dbo].[contacts]
    ([memberid]);
GO

-- Creating foreign key on [contactid] in table 'contactemails'
ALTER TABLE [dbo].[contactemails]
ADD CONSTRAINT [FK_contactemail_contact_fk]
    FOREIGN KEY ([contactid])
    REFERENCES [dbo].[contacts]
        ([contactid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_contactemail_contact_fk'
CREATE INDEX [IX_FK_contactemail_contact_fk]
ON [dbo].[contactemails]
    ([contactid]);
GO

-- Creating foreign key on [familyid] in table 'profiles'
ALTER TABLE [dbo].[profiles]
ADD CONSTRAINT [FK_profile_family_fk]
    FOREIGN KEY ([familyid])
    REFERENCES [dbo].[families]
        ([familyid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_profile_family_fk'
CREATE INDEX [IX_FK_profile_family_fk]
ON [dbo].[profiles]
    ([familyid]);
GO

-- Creating foreign key on [memberid] in table 'feerequests'
ALTER TABLE [dbo].[feerequests]
ADD CONSTRAINT [FK_feerequest_member_fk]
    FOREIGN KEY ([memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_feerequest_member_fk'
CREATE INDEX [IX_FK_feerequest_member_fk]
ON [dbo].[feerequests]
    ([memberid]);
GO

-- Creating foreign key on [memberid] in table 'profiles'
ALTER TABLE [dbo].[profiles]
ADD CONSTRAINT [FK_profile_member_fk]
    FOREIGN KEY ([memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_profile_member_fk'
CREATE INDEX [IX_FK_profile_member_fk]
ON [dbo].[profiles]
    ([memberid]);
GO

-- Creating foreign key on [memberid] in table 'signups'
ALTER TABLE [dbo].[signups]
ADD CONSTRAINT [FK_signup_member_fk]
    FOREIGN KEY ([memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_signup_member_fk'
CREATE INDEX [IX_FK_signup_member_fk]
ON [dbo].[signups]
    ([memberid]);
GO

-- Creating foreign key on [dependentid] in table 'profiles'
ALTER TABLE [dbo].[profiles]
ADD CONSTRAINT [FK_profile_dependent_fk]
    FOREIGN KEY ([dependentid])
    REFERENCES [dbo].[students]
        ([studentid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_profile_dependent_fk'
CREATE INDEX [IX_FK_profile_dependent_fk]
ON [dbo].[profiles]
    ([dependentid]);
GO

-- Creating foreign key on [studentid] in table 'profiles'
ALTER TABLE [dbo].[profiles]
ADD CONSTRAINT [FK_profile_student_fk]
    FOREIGN KEY ([studentid])
    REFERENCES [dbo].[students]
        ([studentid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_profile_student_fk'
CREATE INDEX [IX_FK_profile_student_fk]
ON [dbo].[profiles]
    ([studentid]);
GO

-- Creating foreign key on [sessiontypeid] in table 'sessioncals'
ALTER TABLE [dbo].[sessioncals]
ADD CONSTRAINT [FK_sessioncal_type_fk]
    FOREIGN KEY ([sessiontypeid])
    REFERENCES [dbo].[sessiontypes]
        ([sessiontypeid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_sessioncal_type_fk'
CREATE INDEX [IX_FK_sessioncal_type_fk]
ON [dbo].[sessioncals]
    ([sessiontypeid]);
GO

-- Creating foreign key on [sessioncalid] in table 'signups'
ALTER TABLE [dbo].[signups]
ADD CONSTRAINT [FK_signup_sessioncal_fk]
    FOREIGN KEY ([sessioncalid])
    REFERENCES [dbo].[sessioncals]
        ([sessioncalid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_signup_sessioncal_fk'
CREATE INDEX [IX_FK_signup_sessioncal_fk]
ON [dbo].[signups]
    ([sessioncalid]);
GO

-- Creating foreign key on [activities_activityid] in table 'member2activity'
ALTER TABLE [dbo].[member2activity]
ADD CONSTRAINT [FK_member2activity_activity]
    FOREIGN KEY ([activities_activityid])
    REFERENCES [dbo].[activities]
        ([activityid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [members_memberid] in table 'member2activity'
ALTER TABLE [dbo].[member2activity]
ADD CONSTRAINT [FK_member2activity_member]
    FOREIGN KEY ([members_memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_member2activity_member'
CREATE INDEX [IX_FK_member2activity_member]
ON [dbo].[member2activity]
    ([members_memberid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
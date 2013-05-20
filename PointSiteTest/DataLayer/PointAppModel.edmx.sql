
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2013 20:23:28
-- Generated from EDMX file: C:\Docs\MSSE680\MvcPointApp\PointSiteTest\DataLayer\PointAppModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_contactemail_contact_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[contactemails] DROP CONSTRAINT [FK_contactemail_contact_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_feerequest_member_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[feerequests] DROP CONSTRAINT [FK_feerequest_member_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_signup_member_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[signups] DROP CONSTRAINT [FK_signup_member_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_sessioncal_type_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sessioncals] DROP CONSTRAINT [FK_sessioncal_type_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_signup_sessioncal_fk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[signups] DROP CONSTRAINT [FK_signup_sessioncal_fk];
GO
IF OBJECT_ID(N'[dbo].[FK_member2activity_activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2activity] DROP CONSTRAINT [FK_member2activity_activity];
GO
IF OBJECT_ID(N'[dbo].[FK_member2activity_member]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2activity] DROP CONSTRAINT [FK_member2activity_member];
GO
IF OBJECT_ID(N'[dbo].[FK_member2contact_contact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2contact] DROP CONSTRAINT [FK_member2contact_contact];
GO
IF OBJECT_ID(N'[dbo].[FK_member2contact_member]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2contact] DROP CONSTRAINT [FK_member2contact_member];
GO
IF OBJECT_ID(N'[dbo].[FK_member2dependent_member]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2dependent] DROP CONSTRAINT [FK_member2dependent_member];
GO
IF OBJECT_ID(N'[dbo].[FK_member2dependent_member1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2dependent] DROP CONSTRAINT [FK_member2dependent_member1];
GO
IF OBJECT_ID(N'[dbo].[FK_member2student_member]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2student] DROP CONSTRAINT [FK_member2student_member];
GO
IF OBJECT_ID(N'[dbo].[FK_member2student_student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[member2student] DROP CONSTRAINT [FK_member2student_student];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[activities];
GO
IF OBJECT_ID(N'[dbo].[contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[contacts];
GO
IF OBJECT_ID(N'[dbo].[contactemails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[contactemails];
GO
IF OBJECT_ID(N'[dbo].[feerequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[feerequests];
GO
IF OBJECT_ID(N'[dbo].[members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[members];
GO
IF OBJECT_ID(N'[dbo].[sessioncals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sessioncals];
GO
IF OBJECT_ID(N'[dbo].[sessiontypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sessiontypes];
GO
IF OBJECT_ID(N'[dbo].[signups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[signups];
GO
IF OBJECT_ID(N'[dbo].[students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[students];
GO
IF OBJECT_ID(N'[dbo].[member2activity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[member2activity];
GO
IF OBJECT_ID(N'[dbo].[member2contact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[member2contact];
GO
IF OBJECT_ID(N'[dbo].[member2dependent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[member2dependent];
GO
IF OBJECT_ID(N'[dbo].[member2student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[member2student];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'activities'
CREATE TABLE [dbo].[activities] (
    [activityid] int IDENTITY(1,1) NOT NULL,
    [actname] int  NOT NULL
);
GO

-- Creating table 'contacts'
CREATE TABLE [dbo].[contacts] (
    [contactid] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(30)  NOT NULL,
    [lastname] nvarchar(30)  NOT NULL,
    [middlename] nvarchar(30)  NULL,
    [address] nvarchar(100)  NULL,
    [altaddress] nvarchar(100)  NULL,
    [city] nvarchar(30)  NULL,
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
    [emailaddress] nvarchar(30)  NULL
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
    [username] nvarchar(30)  NULL,
    [userpass] nvarchar(32)  NULL,
    [passphrase] nvarchar(50)  NULL,
    [memberstatus] nvarchar(10)  NULL
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
    [typename] nvarchar(50)  NULL,
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
    [firstname] nvarchar(30)  NULL,
    [lastname] nvarchar(30)  NULL,
    [middlename] nvarchar(30)  NULL,
    [grade] int  NULL,
    [active] nchar(1)  NULL
);
GO

-- Creating table 'member2activity'
CREATE TABLE [dbo].[member2activity] (
    [activities_activityid] int  NOT NULL,
    [members_memberid] int  NOT NULL
);
GO

-- Creating table 'member2contact'
CREATE TABLE [dbo].[member2contact] (
    [contacts_contactid] int  NOT NULL,
    [members_memberid] int  NOT NULL
);
GO

-- Creating table 'member2dependent'
CREATE TABLE [dbo].[member2dependent] (
    [members_memberid] int  NOT NULL,
    [member1_memberid] int  NOT NULL
);
GO

-- Creating table 'member2student'
CREATE TABLE [dbo].[member2student] (
    [members_memberid] int  NOT NULL,
    [students_studentid] int  NOT NULL
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

-- Creating primary key on [activities_activityid], [members_memberid] in table 'member2activity'
ALTER TABLE [dbo].[member2activity]
ADD CONSTRAINT [PK_member2activity]
    PRIMARY KEY NONCLUSTERED ([activities_activityid], [members_memberid] ASC);
GO

-- Creating primary key on [contacts_contactid], [members_memberid] in table 'member2contact'
ALTER TABLE [dbo].[member2contact]
ADD CONSTRAINT [PK_member2contact]
    PRIMARY KEY NONCLUSTERED ([contacts_contactid], [members_memberid] ASC);
GO

-- Creating primary key on [members_memberid], [member1_memberid] in table 'member2dependent'
ALTER TABLE [dbo].[member2dependent]
ADD CONSTRAINT [PK_member2dependent]
    PRIMARY KEY NONCLUSTERED ([members_memberid], [member1_memberid] ASC);
GO

-- Creating primary key on [members_memberid], [students_studentid] in table 'member2student'
ALTER TABLE [dbo].[member2student]
ADD CONSTRAINT [PK_member2student]
    PRIMARY KEY NONCLUSTERED ([members_memberid], [students_studentid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [contacts_contactid] in table 'member2contact'
ALTER TABLE [dbo].[member2contact]
ADD CONSTRAINT [FK_member2contact_contact]
    FOREIGN KEY ([contacts_contactid])
    REFERENCES [dbo].[contacts]
        ([contactid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [members_memberid] in table 'member2contact'
ALTER TABLE [dbo].[member2contact]
ADD CONSTRAINT [FK_member2contact_member]
    FOREIGN KEY ([members_memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_member2contact_member'
CREATE INDEX [IX_FK_member2contact_member]
ON [dbo].[member2contact]
    ([members_memberid]);
GO

-- Creating foreign key on [members_memberid] in table 'member2dependent'
ALTER TABLE [dbo].[member2dependent]
ADD CONSTRAINT [FK_member2dependent_member]
    FOREIGN KEY ([members_memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [member1_memberid] in table 'member2dependent'
ALTER TABLE [dbo].[member2dependent]
ADD CONSTRAINT [FK_member2dependent_member1]
    FOREIGN KEY ([member1_memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_member2dependent_member1'
CREATE INDEX [IX_FK_member2dependent_member1]
ON [dbo].[member2dependent]
    ([member1_memberid]);
GO

-- Creating foreign key on [members_memberid] in table 'member2student'
ALTER TABLE [dbo].[member2student]
ADD CONSTRAINT [FK_member2student_member]
    FOREIGN KEY ([members_memberid])
    REFERENCES [dbo].[members]
        ([memberid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [students_studentid] in table 'member2student'
ALTER TABLE [dbo].[member2student]
ADD CONSTRAINT [FK_member2student_student]
    FOREIGN KEY ([students_studentid])
    REFERENCES [dbo].[students]
        ([studentid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_member2student_student'
CREATE INDEX [IX_FK_member2student_student]
ON [dbo].[member2student]
    ([students_studentid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
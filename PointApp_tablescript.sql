GO
CREATE DATABASE PointAppDB
GO
use PointAppDB
go
-- student table
create table student 
(
  studentid int not null, 
  firstname nvarchar(30), 
  lastname nvarchar(30),
  middlename nvarchar(30),  
  grade int,
  active nchar(1) DEFAULT 'Y'
);

-- constraint
go
alter table student add constraint student_pk primary key (studentid);

------------------------------------
-- contact table
-- contact information for all member
go
create table contact 
(
  contactid int not null,
  firstname nvarchar(30) not null,
  lastname nvarchar(30) not null,
  middlename nvarchar(30),
  address nvarchar(100),
  altaddress nvarchar(100),
  city nvarchar(30),
  state nchar(2) default 'co',
  zip nvarchar(10),
  homephone nvarchar(20),
  workphone nvarchar(20),
  mobilephone nvarchar(20)
);

-- constraint
go
alter table contact add constraint contact_pk primary key (contactid);

--------------------------------
-- contact_email table
-- multiple email
go
create table contactemail 
(
  contactemailid int not null,
  contactid int,
  emailaddress nvarchar(30) 
);

-- constraint
go
alter table contactemail add constraint contactemail_pk primary key (contactemailid);
go
alter table contactemail add constraint contactemail_contact_fk foreign key (contactid) references contact(contactid);

-------------------------------------------
-- activity table
-- member has join in different activity such as volunteer, administrative member, jazz, etc.
GO
CREATE TABLE [dbo].[activity] (
    [activityid]    INT NOT NULL,
    [actname] INT NOT NULL,
	CONSTRAINT [activity_pk] PRIMARY KEY ([activityid])
);
	
	
-----------------------
-- session_type table
-- event type including pizza, empty bowl
go
create table sessiontype 
(
  sessiontypeid int not null,
  typename nvarchar(50),
  note nvarchar(250)
);

-- constraint
go
alter table sessiontype add constraint sessiontype_pk primary key (sessiontypeid);

-----------------------------------------
-- member table
-- member status is parent or student
go
create table member 
(
  memberid int not null,
  username nvarchar(30),
  userpass nvarchar(32),
  passphrase nvarchar(50),
  memberstatus nvarchar(10)
);

-- constraint
go
alter table member add constraint member_pk primary key (memberid);

---------------------------
-- member2student
-- assign student
go
create table member2student 
(
  memberid int not null,
  studentid int not null  
);

-- constraint
go
alter table member2student add constraint member2student_pk primary key (memberid, studentid);
go
alter table member2student add constraint member2student_member_fk foreign key (memberid) references member(memberid);
go
alter table member2student add constraint member2student_student_fk foreign key (studentid) references student(studentid);

---------------------------
-- member2contact
-- assign contact
GO
CREATE TABLE [dbo].[member2contact] (
    [memberid]    INT NOT NULL,
    [contactid] INT NOT NULL,
	CONSTRAINT [member2contact_pk] PRIMARY KEY ([memberid], [contactid]),
    CONSTRAINT [member2contact_member_fk] FOREIGN KEY ([memberid]) REFERENCES [dbo].[member] ([memberid]),
	CONSTRAINT [member2contact_contact_fk] FOREIGN KEY ([contactid]) REFERENCES [dbo].[contact] ([contactid])
);

---------------------------
-- member2dependent
-- assign dependent
GO
CREATE TABLE [dbo].[member2dependent] (
    [memberid]    INT NOT NULL,
    [dependentid] INT NOT NULL,
	CONSTRAINT [member2dependent_pk] PRIMARY KEY ([memberid], [dependentid]),
    CONSTRAINT [member2dependent_member_fk] FOREIGN KEY ([memberid]) REFERENCES [dbo].[member] ([memberid]),
	CONSTRAINT [member2dependent_dependent_fk] FOREIGN KEY ([dependentid]) REFERENCES [dbo].[member] ([memberid])
);

--------------------------------------
-- session_cal table
-- session calendar
go
create table sessioncal 
(
  sessioncalid int not null,
  sessiondate date,
  sessiontypeid int,
  sessionnum int,
  sessionamt money,
  sessionpoint int
);

-- constraint
go
alter table sessioncal add constraint sessioncal_pk primary key (sessioncalid);
go
alter table sessioncal add constraint sessioncal_type_fk foreign key (sessiontypeid) references sessiontype(sessiontypeid);

-----------------------
-- signup table
go
create table signup 
(
  signupid int not null, 
  memberid int, 
  sessioncalid int,
  pointearn int,
  isshow nchar(1)
);

-- constraint
go
alter table signup add constraint signup_pk primary key (signupid);
go
alter table signup add constraint signup_member_fk foreign key (memberid) references member(memberid);
go
alter table signup add constraint signup_sessioncal_fk foreign key (sessioncalid) references sessioncal(sessioncalid);

---------------------------------------
-- member2activity table
GO
CREATE TABLE [dbo].[member2activity]
(
	[memberid] INT NOT NULL, 
    [activityid] INT NOT NULL,
	CONSTRAINT [member2activity_pk] PRIMARY KEY ([memberid], [activityid]),
	CONSTRAINT [member2activity_member_fk] FOREIGN KEY ([memberid]) REFERENCES [dbo].[member] ([memberid]),
	CONSTRAINT [member2activity_act_fk] FOREIGN KEY ([activityid]) REFERENCES [dbo].[activity] ([activityid])
)

	

-------------------------
-- fee_request table
go
create table feerequest 
(
  feerequestid int not null,
  memberid int,
  requestdate date,
  requestamt money,
  pointbal int
);

-- constraint
go
alter table feerequest add constraint feerequest_pk primary key (feerequestid);
go
alter table feerequest add constraint feerequest_member_fk foreign key (memberid) references member(memberid);

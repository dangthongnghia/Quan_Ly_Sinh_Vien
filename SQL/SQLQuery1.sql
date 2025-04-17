﻿-- ----------------------------
-- Table 1 - structure for Subject
-- ----------------------------
CREATE TABLE [Subject] (
	[Id] varchar(10) NOT NULL primary key,
	[Name] nvarchar(50) NOT NULL 
)
GO

-- ----------------------------
-- Records of Subject
-- ----------------------------
INSERT INTO [Subject]([Id], [Name]) VALUES (N'MHCTT00001', N'Cấu trúc dữ liệu')
INSERT INTO [Subject]([Id], [Name]) VALUES (N'MHCTT00002', N'Kỹ thuật lập trình')
INSERT INTO [Subject]([Id], [Name]) VALUES (N'MHCTT00003', N'Lập trình Web')
INSERT INTO [Subject]([Id], [Name]) VALUES (N'MHCTT00004', N'Lập trình Ứng dụng quản lý')
INSERT INTO [Subject]([Id], [Name]) VALUES (N'MHCTT00005', N'Phát triển Ứng dụng CSDL')
INSERT INTO [Subject]([Id], [Name]) VALUES (N'MHCTT00006', N'Công cụ kiểm chứng phần mềm')
INSERT INTO [Subject]([Id], [Name]) VALUES (N'MHCTT00007', N'Phân tích thiết kế phần mềm')
GO

-- ----------------------------
-- Table 2 - structure for Province
-- ----------------------------
CREATE TABLE [Province] (
	[Id] int NOT NULL primary key,
	[Name] nvarchar(MAX) NOT NULL 
)
GO

-- ----------------------------
-- Records of Province
-- ----------------------------
INSERT INTO [Province] ([Id], [Name]) VALUES (N'2', N'TP Hồ Chí Minh') 
INSERT INTO [Province] ([Id], [Name]) VALUES (N'3', N'TP Hà Nội')
INSERT INTO [Province] ([Id], [Name]) VALUES (N'4', N'Hải Phòng')
INSERT INTO [Province] ([Id], [Name]) VALUES (N'5', N'Đà Nẵng')
INSERT INTO [Province] ([Id], [Name]) VALUES (N'6', N'Bến Tre')
INSERT INTO [Province] ([Id], [Name]) VALUES (N'7', N'Long An')
INSERT INTO [Province] ([Id], [Name]) VALUES (N'8', N'Bình Dương'), (N'9', N'Khánh Hòa'), (N'10', N'Lâm Đồng')
GO

-- ----------------------------
-- Table 3 - structure for Student
-- ----------------------------
CREATE TABLE [Student] (
	[Id] varchar(7) NOT NULL primary key,
	[Name] nvarchar(50) NOT NULL ,
	[BOF] datetime NOT NULL ,
	[IdProvince] int NOT NULL ,
	[Gender] bit NOT NULL 
	
	foreign key ([IdProvince]) references [Province]([Id]),
)
GO

-- ----------------------------
-- Records of SinhVien
-- ----------------------------
INSERT INTO [Student] ([Id], [Name], [BOF], [IdProvince], [Gender]) VALUES (N'1361001', N'Phạm Thạch A', N'1997-01-02 05:35:00.000', N'4', N'0'), (N'1361002', N'Lê Thanh X', N'1996-07-10 12:30:00.000', N'8', N'0'), (N'1361003', N'Ngô Anh R', N'1997-09-08 19:50:00.000', N'7', N'1'), (N'1361004', N'Lê Văn M', N'1996-04-22 05:03:20.000', N'9', N'1'), (N'1361005', N'Nguyễn Thị I', N'1996-02-16 23:31:40.000', N'5', N'0'), (N'1361006', N'Nguyễn Anh N', N'1994-01-28 11:46:40.000', N'8', N'1'), (N'1361007', N'Nguyễn Văn T', N'1996-10-16 22:28:20.000', N'4', N'1'), (N'1361008', N'Nguyễn Thanh F', N'1997-11-09 11:08:20.000', N'4', N'1'), (N'1361009', N'Nguyễn Anh A', N'1996-06-13 01:58:20.000', N'8', N'0'), (N'1361010', N'Phạm Thanh J', N'1997-01-31 17:00:00.000', N'6', N'1'), (N'1361011', N'Hoàng Minh C', N'1995-10-26 20:23:20.000', N'4', N'0'), (N'1361012', N'Nguyễn Thanh K', N'1995-07-15 01:31:40.000', N'9', N'0'), (N'1361013', N'Hoàng Văn K', N'1996-04-25 09:26:40.000', N'10', N'1'), (N'1361014', N'Lê Văn H', N'1995-09-03 08:48:20.000', N'2', N'0'), (N'1361015', N'Phạm Văn S', N'1996-08-28 10:58:20.000', N'6', N'1'), (N'1361016', N'Nguyễn Văn I', N'1996-03-15 20:41:40.000', N'10', N'0'), (N'1361017', N'Nguyễn Minh F', N'1994-04-02 21:20:00.000', N'4', N'1'), (N'1361018', N'Hoàng Thị B', N'1995-03-30 21:11:40.000', N'6', N'0'), (N'1361019', N'Nguyễn Thị X', N'1996-02-01 23:06:40.000', N'8', N'1'), (N'1361020', N'Nguyễn Thạch I', N'1994-09-11 15:56:40.000', N'5', N'1'), (N'1361021', N'Lê Anh Y', N'1996-11-09 17:01:40.000', N'4', N'0'), (N'1361022', N'Phạm Thanh P', N'1994-02-24 11:08:20.000', N'10', N'1'), (N'1361023', N'Ngô Minh Y', N'1994-11-15 05:23:20.000', N'3', N'1'), (N'1361024', N'Hoàng Văn T', N'1995-12-08 05:43:20.000', N'6', N'1'), (N'1361025', N'Lê Thạch O', N'1994-05-19 01:56:40.000', N'8', N'0'), (N'1361026', N'Lê Văn M', N'1995-09-09 23:56:40.000', N'8', N'0'), (N'1361027', N'Nguyễn Thạch O', N'1997-01-20 19:08:20.000', N'8', N'0'), (N'1361028', N'Hoàng Thạch D', N'1996-12-27 02:48:20.000', N'9', N'0'), (N'1361029', N'Ngô Thị P', N'1994-03-02 22:30:00.000', N'2', N'0'), (N'1361030', N'Lê Thị V', N'1995-07-10 07:16:40.000', N'9', N'1'), (N'1361031', N'Ngô Minh M', N'1997-09-04 20:43:20.000', N'10', N'1'), (N'1361032', N'Phạm Thạch G', N'1996-08-11 11:23:20.000', N'4', N'1'), (N'1361033', N'Lê Thị J', N'1995-10-26 04:23:20.000', N'7', N'0'), (N'1361034', N'Nguyễn Anh C', N'1997-08-11 12:18:20.000', N'10', N'1'), (N'1361035', N'Trần Thị CB', N'1995-01-04 12:13:20.000', N'3', N'1'), (N'1361036', N'Ngô Minh N', N'1994-07-04 23:20:00.000', N'10', N'1'), (N'1361037', N'Nguyễn Thạch W', N'1996-09-19 00:13:20.000', N'9', N'0'), (N'1361038', N'Lê Anh N', N'1996-11-09 19:25:00.000', N'9', N'1'), (N'1361039', N'Lê Thanh T', N'1994-10-17 09:10:00.000', N'10', N'1'), (N'1361040', N'Ngô Thạch W', N'1997-05-15 03:26:40.000', N'7', N'0'), (N'1361041', N'Ngô Thạch P', N'1995-11-16 07:21:40.000', N'9', N'1'), (N'1361042', N'Ngô Minh B', N'1997-05-01 06:01:40.000', N'6', N'1'), (N'1361043', N'Ngô Văn U', N'1994-12-05 14:45:00.000', N'6', N'0'), (N'1361044', N'Phạm Minh P', N'1997-07-22 02:56:40.000', N'8', N'1'), (N'1361045', N'Phạm Thanh P', N'1997-12-14 21:23:20.000', N'3', N'0'), (N'1361046', N'Trần Thanh CA', N'1995-11-19 17:21:40.000', N'9', N'1'), (N'1361047', N'Nguyễn Anh Y', N'1996-07-14 12:53:20.000', N'10', N'1'), (N'1361048', N'Ngô Văn R', N'1996-01-14 14:01:40.000', N'3', N'0'), (N'1361049', N'Trần Thanh Q', N'1994-12-26 01:16:40.000', N'3', N'0'), (N'1361050', N'Hoàng Thanh Y', N'1996-07-14 19:50:00.000', N'9', N'1'), (N'1361051', N'Nguyễn Văn U', N'1995-09-22 15:10:00.000', N'3', N'1'), (N'1361052', N'Phạm Anh O', N'1997-10-14 06:01:40.000', N'8', N'0'), (N'1361053', N'Phạm Thanh B', N'1995-11-01 04:08:20.000', N'8', N'0'), (N'1361054', N'Trần Thị B', N'1996-03-24 07:23:20.000', N'6', N'1'), (N'1361055', N'Lê Thanh J', N'1995-05-28 17:36:40.000', N'10', N'1'), (N'1361056', N'Ngô Anh U', N'1995-12-31 03:11:40.000', N'7', N'0'), (N'1361057', N'Trần Thạch S', N'1997-04-11 06:05:00.000', N'3', N'1'), (N'1361058', N'Lê Văn O', N'1997-10-28 10:30:00.000', N'7', N'1'), (N'1361059', N'Trần Thị C', N'1997-06-24 16:05:00.000', N'5', N'0'), (N'1361060', N'Ngô Minh M', N'1995-03-15 14:46:40.000', N'9', N'1'), (N'1361061', N'Ngô Anh B', N'1994-09-26 04:48:20.000', N'7', N'1'), (N'1361062', N'Hoàng Anh D', N'1996-04-18 04:56:40.000', N'6', N'0'), (N'1361063', N'Trần Thanh J', N'1997-08-20 19:13:20.000', N'6', N'1'), (N'1361064', N'Hoàng Thanh P', N'1997-08-19 22:15:00.000', N'2', N'0'), (N'1361065', N'Hoàng Thanh M', N'1995-02-18 21:08:20.000', N'8', N'0'), (N'1361066', N'Trần Minh Q', N'1996-08-25 08:26:40.000', N'5', N'0'), (N'1361067', N'Trần Thạch W', N'1997-11-19 15:28:20.000', N'6', N'1'), (N'1361068', N'Phạm Thanh R', N'1995-01-01 06:38:20.000', N'5', N'1'), (N'1361069', N'Trần Thạch U', N'1995-09-29 05:25:00.000', N'7', N'0'), (N'1361070', N'Nguyễn Văn N', N'1997-03-26 05:10:00.000', N'7', N'0'), (N'1361071', N'Trần Thanh D', N'1995-10-07 05:46:40.000', N'9', N'1'), (N'1361072', N'Hoàng Văn V', N'1997-08-03 23:25:00.000', N'10', N'1'), (N'1361073', N'Lê Thạch Q', N'1995-04-04 02:08:20.000', N'5', N'0'), (N'1361074', N'Phạm Thị H', N'1995-04-28 21:41:40.000', N'6', N'0'), (N'1361075', N'Hoàng Văn I', N'1996-06-25 19:50:00.000', N'7', N'1'), (N'1361076', N'Ngô Văn C', N'1997-11-25 18:48:20.000', N'5', N'1'), (N'1361077', N'Phạm Văn C', N'1996-11-01 16:20:00.000', N'2', N'0'), (N'1361078', N'Phạm Văn X', N'1996-01-24 23:13:20.000', N'6', N'0'), (N'1361079', N'Trần Thị S', N'1996-07-01 08:43:20.000', N'6', N'0'), (N'1361080', N'Nguyễn Thạch F', N'1995-10-10 16:10:00.000', N'5', N'0'), (N'1361081', N'Phạm Thạch M', N'1994-11-17 23:10:00.000', N'9', N'0'), (N'1361082', N'Hoàng Thị W', N'1996-08-01 04:51:40.000', N'4', N'0'), (N'1361083', N'Nguyễn Anh O', N'1996-10-13 13:31:40.000', N'4', N'0'), (N'1361084', N'Lê Văn M', N'1997-11-28 01:13:20.000', N'5', N'1'), (N'1361085', N'Hoàng Thanh L', N'1997-11-25 06:01:40.000', N'3', N'1'), (N'1361086', N'Nguyễn Minh P', N'1995-12-01 04:01:40.000', N'9', N'1'), (N'1361087', N'Lê Thị U', N'1997-10-04 02:05:00.000', N'4', N'1'), (N'1361088', N'Lê Minh N', N'1997-09-28 00:11:40.000', N'3', N'0'), (N'1361089', N'Hoàng Văn E', N'1994-09-16 08:55:00.000', N'5', N'0'), (N'1361090', N'Hoàng Thanh W', N'1995-07-22 11:38:20.000', N'7', N'1'), (N'1361091', N'Phạm Thị G', N'1994-02-02 16:13:20.000', N'10', N'0'), (N'1361092', N'Lê Thanh X', N'1996-06-03 18:51:40.000', N'6', N'0'), (N'1361093', N'Phạm Anh E', N'1994-08-10 06:53:20.000', N'3', N'1'), (N'1361094', N'Hoàng Anh Q', N'1996-05-12 10:58:20.000', N'9', N'0'), (N'1361095', N'Hoàng Thị O', N'1996-12-27 20:48:20.000', N'9', N'0'), (N'1361096', N'Hoàng Thanh U', N'1997-02-16 23:05:00.000', N'7', N'1'), (N'1361097', N'Trần Thạch S', N'1997-08-27 19:15:00.000', N'5', N'0'), (N'1361098', N'Nguyễn Thị M', N'1995-10-26 14:30:00.000', N'9', N'0'), (N'1361099', N'Nguyễn Minh M', N'1994-08-26 06:51:40.000', N'2', N'0'), (N'1361100', N'Hoàng Văn S', N'1997-05-24 23:03:20.000', N'8', N'1')
GO

-- -------------------------------
-- Table 4 - structure for User
-- -------------------------------
create table [User] (
	[IdStudent] varchar(7) NOT NULL primary key,
	[Username] varchar(60) not null,
	[Password] varchar(60) not null,
	
	[Note] ntext null default(''),
	[Status] bit not null default(1),
	[CreatedAt] DateTime not null,
	[ModifiedAt] DateTime not null,
	
	foreign key ([IdStudent]) references [Student]([Id])
)

-- -------------------------------
-- Table 5 - structure for Role
-- -------------------------------
create table [Role] (
	[Id] varchar(10) not null primary key,
	[Name] nvarchar(60) not null,

	[Status] bit not null default(1),
)

-- ----------------------------
-- Records of Role
-- ----------------------------
insert into [Role] ([Id], [Name], [Status])
values
	('R1', N'admin', 1),
	('R2', N'user', 1)
	
-- -------------------------------
-- Table 6 - structure for UserRole
-- -------------------------------
create table [UserRole] (
	[Id] varchar(10) not null primary key,
	[IdStudent] varchar(7) not null,
	[IdRole] varchar(10) not null,
	
	foreign key ([IdStudent]) references [User]([IdStudent]),
	foreign key ([IdRole]) references [Role]([Id]),
)

-- ----------------------------
-- Table 7 - structure for Enrol (ghi danh môn học), register (đăng kí tài khoản)
-- ----------------------------
CREATE TABLE [Enrol](
	[IdStudent] varchar(7) NOT NULL ,
	[IdSubject] varchar(10) NOT NULL ,
	[Mark] decimal(18) NULL 
	
	foreign key ([IdStudent]) references [Student]([Id]),
	foreign key ([IdSubject]) references [Subject]([Id]),
)
GO

-- ----------------------------
-- Records of Enrol
-- ----------------------------
INSERT INTO [Enrol] ([IdStudent], [IdSubject], [Mark]) VALUES (N'1361001', N'MHCTT00002', N'6'), (N'1361001', N'MHCTT00003', N'2'), (N'1361001', N'MHCTT00004', N'8'), (N'1361002', N'MHCTT00003', N'2'), (N'1361002', N'MHCTT00004', N'7'), (N'1361002', N'MHCTT00005', N'2'), (N'1361003', N'MHCTT00002', N'3'), (N'1361003', N'MHCTT00003', N'9'), (N'1361003', N'MHCTT00004', N'3'), (N'1361004', N'MHCTT00001', N'9'), (N'1361004', N'MHCTT00002', N'9'), (N'1361004', N'MHCTT00005', N'6'), (N'1361005', N'MHCTT00001', N'5'), (N'1361005', N'MHCTT00003', N'6'), (N'1361005', N'MHCTT00004', N'2'), (N'1361006', N'MHCTT00003', N'2'), (N'1361006', N'MHCTT00004', N'7'), (N'1361006', N'MHCTT00005', N'8'), (N'1361007', N'MHCTT00002', N'4'), (N'1361007', N'MHCTT00004', N'4'), (N'1361007', N'MHCTT00005', N'2'), (N'1361008', N'MHCTT00001', N'8'), (N'1361008', N'MHCTT00004', N'7'), (N'1361008', N'MHCTT00005', N'5'), (N'1361009', N'MHCTT00001', N'4'), (N'1361009', N'MHCTT00002', N'7'), (N'1361009', N'MHCTT00004', N'6'), (N'1361009', N'MHCTT00005', N'7'), (N'1361010', N'MHCTT00001', N'8'), (N'1361010', N'MHCTT00004', N'9'), (N'1361010', N'MHCTT00005', N'3'), (N'1361011', N'MHCTT00002', N'4'), (N'1361011', N'MHCTT00003', N'6'), (N'1361011', N'MHCTT00005', N'7'), (N'1361012', N'MHCTT00002', N'5'), (N'1361012', N'MHCTT00003', N'4'), (N'1361012', N'MHCTT00004', N'6'), (N'1361012', N'MHCTT00005', N'9'), (N'1361013', N'MHCTT00001', N'5'), (N'1361013', N'MHCTT00003', N'7'), (N'1361013', N'MHCTT00004', N'9'), (N'1361013', N'MHCTT00005', N'3'), (N'1361014', N'MHCTT00001', N'7'), (N'1361014', N'MHCTT00004', N'5'), (N'1361014', N'MHCTT00005', N'3'), (N'1361015', N'MHCTT00003', N'3'), (N'1361015', N'MHCTT00004', N'4'), (N'1361015', N'MHCTT00005', N'8'), (N'1361016', N'MHCTT00001', N'7'), (N'1361016', N'MHCTT00003', N'4'), (N'1361016', N'MHCTT00004', N'3'), (N'1361016', N'MHCTT00005', N'3'), (N'1361017', N'MHCTT00002', N'3'), (N'1361017', N'MHCTT00003', N'5'), (N'1361017', N'MHCTT00005', N'5'), (N'1361018', N'MHCTT00001', N'6'), (N'1361018', N'MHCTT00004', N'7'), (N'1361018', N'MHCTT00005', N'2'), (N'1361019', N'MHCTT00002', N'6'), (N'1361019', N'MHCTT00004', N'8'), (N'1361019', N'MHCTT00005', N'5'), (N'1361020', N'MHCTT00002', N'5'), (N'1361020', N'MHCTT00003', N'7'), (N'1361020', N'MHCTT00004', N'2'), (N'1361020', N'MHCTT00005', N'6'), (N'1361021', N'MHCTT00002', N'8'), (N'1361021', N'MHCTT00003', N'3'), (N'1361021', N'MHCTT00004', N'3'), (N'1361022', N'MHCTT00002', N'3'), (N'1361022', N'MHCTT00003', N'3'), (N'1361022', N'MHCTT00004', N'8'), (N'1361022', N'MHCTT00005', N'3'), (N'1361023', N'MHCTT00001', N'4'), (N'1361023', N'MHCTT00002', N'8'), (N'1361023', N'MHCTT00004', N'5'), (N'1361023', N'MHCTT00005', N'7'), (N'1361024', N'MHCTT00002', N'8'), (N'1361024', N'MHCTT00003', N'7'), (N'1361024', N'MHCTT00004', N'5'), (N'1361024', N'MHCTT00005', N'8'), (N'1361025', N'MHCTT00002', N'9'), (N'1361025', N'MHCTT00003', N'8'), (N'1361025', N'MHCTT00004', N'2'), (N'1361026', N'MHCTT00002', N'7'), (N'1361026', N'MHCTT00003', N'4'), (N'1361026', N'MHCTT00004', N'8'), (N'1361026', N'MHCTT00005', N'6'), (N'1361027', N'MHCTT00001', N'7'), (N'1361027', N'MHCTT00003', N'8'), (N'1361027', N'MHCTT00004', N'6'), (N'1361027', N'MHCTT00005', N'6'), (N'1361028', N'MHCTT00003', N'5'), (N'1361028', N'MHCTT00004', N'2'), (N'1361028', N'MHCTT00005', N'5'), (N'1361029', N'MHCTT00002', N'4'), (N'1361029', N'MHCTT00003', N'3'), (N'1361029', N'MHCTT00004', N'3'), (N'1361029', N'MHCTT00005', N'3'), (N'1361030', N'MHCTT00002', N'8'), (N'1361030', N'MHCTT00003', N'5')
GO
INSERT INTO [Enrol] ([IdStudent], [IdSubject], [Mark]) VALUES (N'1361030', N'MHCTT00004', N'8'), (N'1361030', N'MHCTT00005', N'2'), (N'1361031', N'MHCTT00003', N'8'), (N'1361031', N'MHCTT00004', N'2'), (N'1361031', N'MHCTT00005', N'6'), (N'1361032', N'MHCTT00002', N'6'), (N'1361032', N'MHCTT00003', N'7'), (N'1361032', N'MHCTT00004', N'6'), (N'1361032', N'MHCTT00005', N'4'), (N'1361033', N'MHCTT00002', N'6'), (N'1361033', N'MHCTT00004', N'5'), (N'1361033', N'MHCTT00005', N'5'), (N'1361034', N'MHCTT00002', N'2'), (N'1361034', N'MHCTT00003', N'8'), (N'1361034', N'MHCTT00004', N'3'), (N'1361034', N'MHCTT00005', N'6'), (N'1361035', N'MHCTT00002', N'2'), (N'1361035', N'MHCTT00003', N'7'), (N'1361035', N'MHCTT00004', N'7'), (N'1361035', N'MHCTT00005', N'5'), (N'1361036', N'MHCTT00001', N'7'), (N'1361036', N'MHCTT00002', N'5'), (N'1361036', N'MHCTT00004', N'3'), (N'1361037', N'MHCTT00002', N'6'), (N'1361037', N'MHCTT00003', N'4'), (N'1361037', N'MHCTT00004', N'7'), (N'1361037', N'MHCTT00005', N'8'), (N'1361038', N'MHCTT00002', N'9'), (N'1361038', N'MHCTT00003', N'7'), (N'1361038', N'MHCTT00004', N'6'), (N'1361038', N'MHCTT00005', N'4'), (N'1361039', N'MHCTT00001', N'6'), (N'1361039', N'MHCTT00002', N'7'), (N'1361039', N'MHCTT00004', N'5'), (N'1361039', N'MHCTT00005', N'9'), (N'1361040', N'MHCTT00002', N'8'), (N'1361040', N'MHCTT00003', N'5'), (N'1361040', N'MHCTT00004', N'8'), (N'1361040', N'MHCTT00005', N'6'), (N'1361041', N'MHCTT00003', N'4'), (N'1361041', N'MHCTT00004', N'9'), (N'1361041', N'MHCTT00005', N'3'), (N'1361042', N'MHCTT00002', N'8'), (N'1361042', N'MHCTT00003', N'7'), (N'1361042', N'MHCTT00004', N'6'), (N'1361042', N'MHCTT00005', N'8'), (N'1361043', N'MHCTT00003', N'7'), (N'1361043', N'MHCTT00004', N'2'), (N'1361043', N'MHCTT00005', N'5'), (N'1361044', N'MHCTT00002', N'8'), (N'1361044', N'MHCTT00004', N'9'), (N'1361044', N'MHCTT00005', N'5'), (N'1361045', N'MHCTT00001', N'3'), (N'1361045', N'MHCTT00004', N'9'), (N'1361045', N'MHCTT00005', N'2'), (N'1361046', N'MHCTT00001', N'7'), (N'1361046', N'MHCTT00002', N'2'), (N'1361046', N'MHCTT00003', N'7'), (N'1361046', N'MHCTT00004', N'4'), (N'1361047', N'MHCTT00003', N'6'), (N'1361047', N'MHCTT00004', N'8'), (N'1361047', N'MHCTT00005', N'2'), (N'1361048', N'MHCTT00002', N'4'), (N'1361048', N'MHCTT00003', N'2'), (N'1361048', N'MHCTT00004', N'3'), (N'1361048', N'MHCTT00005', N'3'), (N'1361049', N'MHCTT00003', N'8'), (N'1361049', N'MHCTT00004', N'5'), (N'1361049', N'MHCTT00005', N'6'), (N'1361050', N'MHCTT00002', N'5'), (N'1361050', N'MHCTT00003', N'9'), (N'1361050', N'MHCTT00004', N'9'), (N'1361050', N'MHCTT00005', N'8'), (N'1361051', N'MHCTT00001', N'7'), (N'1361051', N'MHCTT00003', N'5'), (N'1361051', N'MHCTT00004', N'7'), (N'1361051', N'MHCTT00005', N'9'), (N'1361052', N'MHCTT00003', N'6'), (N'1361052', N'MHCTT00004', N'2'), (N'1361052', N'MHCTT00005', N'6'), (N'1361053', N'MHCTT00001', N'3'), (N'1361053', N'MHCTT00003', N'8'), (N'1361053', N'MHCTT00004', N'8'), (N'1361054', N'MHCTT00002', N'2'), (N'1361054', N'MHCTT00003', N'4'), (N'1361054', N'MHCTT00004', N'2'), (N'1361054', N'MHCTT00005', N'7'), (N'1361055', N'MHCTT00002', N'9'), (N'1361055', N'MHCTT00003', N'5'), (N'1361055', N'MHCTT00004', N'8'), (N'1361056', N'MHCTT00002', N'2'), (N'1361056', N'MHCTT00003', N'8'), (N'1361056', N'MHCTT00004', N'2'), (N'1361056', N'MHCTT00005', N'7'), (N'1361057', N'MHCTT00002', N'7'), (N'1361057', N'MHCTT00004', N'7'), (N'1361057', N'MHCTT00005', N'9'), (N'1361058', N'MHCTT00002', N'6'), (N'1361058', N'MHCTT00004', N'4'), (N'1361058', N'MHCTT00005', N'4')
GO
INSERT INTO [Enrol] ([IdStudent], [IdSubject], [Mark]) VALUES (N'1361059', N'MHCTT00002', N'7'), (N'1361059', N'MHCTT00003', N'2'), (N'1361059', N'MHCTT00004', N'2'), (N'1361059', N'MHCTT00005', N'2'), (N'1361060', N'MHCTT00002', N'3'), (N'1361060', N'MHCTT00004', N'7'), (N'1361060', N'MHCTT00005', N'2'), (N'1361061', N'MHCTT00001', N'7'), (N'1361061', N'MHCTT00002', N'6'), (N'1361061', N'MHCTT00003', N'5'), (N'1361061', N'MHCTT00005', N'9'), (N'1361062', N'MHCTT00001', N'4'), (N'1361062', N'MHCTT00004', N'9'), (N'1361062', N'MHCTT00005', N'6'), (N'1361063', N'MHCTT00003', N'2'), (N'1361063', N'MHCTT00004', N'3'), (N'1361063', N'MHCTT00005', N'9'), (N'1361064', N'MHCTT00001', N'5'), (N'1361064', N'MHCTT00002', N'6'), (N'1361064', N'MHCTT00003', N'6'), (N'1361064', N'MHCTT00005', N'3'), (N'1361065', N'MHCTT00003', N'8'), (N'1361065', N'MHCTT00004', N'6'), (N'1361065', N'MHCTT00005', N'7'), (N'1361066', N'MHCTT00003', N'3'), (N'1361066', N'MHCTT00004', N'4'), (N'1361066', N'MHCTT00005', N'7'), (N'1361067', N'MHCTT00002', N'3'), (N'1361067', N'MHCTT00003', N'2'), (N'1361067', N'MHCTT00005', N'7'), (N'1361068', N'MHCTT00002', N'3'), (N'1361068', N'MHCTT00003', N'9'), (N'1361068', N'MHCTT00004', N'3'), (N'1361068', N'MHCTT00005', N'8'), (N'1361069', N'MHCTT00001', N'6'), (N'1361069', N'MHCTT00002', N'5'), (N'1361069', N'MHCTT00003', N'2'), (N'1361070', N'MHCTT00002', N'4'), (N'1361070', N'MHCTT00003', N'5'), (N'1361070', N'MHCTT00004', N'2'), (N'1361070', N'MHCTT00005', N'6'), (N'1361071', N'MHCTT00001', N'5'), (N'1361071', N'MHCTT00003', N'5'), (N'1361071', N'MHCTT00004', N'5'), (N'1361071', N'MHCTT00005', N'6'), (N'1361072', N'MHCTT00003', N'6'), (N'1361072', N'MHCTT00004', N'7'), (N'1361072', N'MHCTT00005', N'6'), (N'1361073', N'MHCTT00002', N'9'), (N'1361073', N'MHCTT00003', N'8'), (N'1361073', N'MHCTT00004', N'4'), (N'1361073', N'MHCTT00005', N'2'), (N'1361074', N'MHCTT00001', N'8'), (N'1361074', N'MHCTT00002', N'3'), (N'1361074', N'MHCTT00004', N'8'), (N'1361074', N'MHCTT00005', N'3'), (N'1361075', N'MHCTT00001', N'7'), (N'1361075', N'MHCTT00002', N'5'), (N'1361075', N'MHCTT00003', N'9'), (N'1361075', N'MHCTT00004', N'6'), (N'1361076', N'MHCTT00001', N'5'), (N'1361076', N'MHCTT00002', N'4'), (N'1361076', N'MHCTT00003', N'2'), (N'1361076', N'MHCTT00004', N'2'), (N'1361077', N'MHCTT00001', N'8'), (N'1361077', N'MHCTT00003', N'7'), (N'1361077', N'MHCTT00004', N'9'), (N'1361078', N'MHCTT00003', N'7'), (N'1361078', N'MHCTT00004', N'5'), (N'1361078', N'MHCTT00005', N'5'), (N'1361079', N'MHCTT00002', N'2'), (N'1361079', N'MHCTT00003', N'8'), (N'1361079', N'MHCTT00004', N'2'), (N'1361079', N'MHCTT00005', N'6'), (N'1361080', N'MHCTT00001', N'2'), (N'1361080', N'MHCTT00003', N'7'), (N'1361080', N'MHCTT00004', N'5'), (N'1361080', N'MHCTT00005', N'5'), (N'1361081', N'MHCTT00002', N'8'), (N'1361081', N'MHCTT00004', N'4'), (N'1361081', N'MHCTT00005', N'9'), (N'1361082', N'MHCTT00002', N'3'), (N'1361082', N'MHCTT00004', N'4'), (N'1361082', N'MHCTT00005', N'3'), (N'1361083', N'MHCTT00002', N'6'), (N'1361083', N'MHCTT00003', N'3'), (N'1361083', N'MHCTT00005', N'3'), (N'1361084', N'MHCTT00001', N'6'), (N'1361084', N'MHCTT00002', N'5'), (N'1361084', N'MHCTT00004', N'7'), (N'1361084', N'MHCTT00005', N'4'), (N'1361085', N'MHCTT00001', N'9'), (N'1361085', N'MHCTT00003', N'4'), (N'1361085', N'MHCTT00004', N'7'), (N'1361085', N'MHCTT00005', N'5'), (N'1361086', N'MHCTT00001', N'7'), (N'1361086', N'MHCTT00002', N'9'), (N'1361086', N'MHCTT00004', N'4'), (N'1361086', N'MHCTT00005', N'5'), (N'1361087', N'MHCTT00002', N'2')
GO
INSERT INTO [Enrol] ([IdStudent], [IdSubject], [Mark]) VALUES (N'1361087', N'MHCTT00003', N'3'), (N'1361087', N'MHCTT00004', N'3'), (N'1361087', N'MHCTT00005', N'3'), (N'1361088', N'MHCTT00001', N'9'), (N'1361088', N'MHCTT00003', N'4'), (N'1361088', N'MHCTT00005', N'8'), (N'1361089', N'MHCTT00001', N'4'), (N'1361089', N'MHCTT00002', N'8'), (N'1361089', N'MHCTT00003', N'7'), (N'1361089', N'MHCTT00005', N'2'), (N'1361090', N'MHCTT00002', N'5'), (N'1361090', N'MHCTT00003', N'2'), (N'1361090', N'MHCTT00004', N'3'), (N'1361090', N'MHCTT00005', N'9'), (N'1361091', N'MHCTT00002', N'3'), (N'1361091', N'MHCTT00003', N'5'), (N'1361091', N'MHCTT00004', N'2'), (N'1361091', N'MHCTT00005', N'8'), (N'1361092', N'MHCTT00001', N'5'), (N'1361092', N'MHCTT00002', N'4'), (N'1361092', N'MHCTT00005', N'4'), (N'1361093', N'MHCTT00001', N'9'), (N'1361093', N'MHCTT00003', N'7'), (N'1361093', N'MHCTT00005', N'9'), (N'1361094', N'MHCTT00001', N'5'), (N'1361094', N'MHCTT00002', N'8'), (N'1361094', N'MHCTT00004', N'2'), (N'1361094', N'MHCTT00005', N'9'), (N'1361095', N'MHCTT00003', N'6'), (N'1361095', N'MHCTT00004', N'6'), (N'1361095', N'MHCTT00005', N'5'), (N'1361096', N'MHCTT00002', N'6'), (N'1361096', N'MHCTT00003', N'4'), (N'1361096', N'MHCTT00004', N'6'), (N'1361097', N'MHCTT00002', N'4'), (N'1361097', N'MHCTT00003', N'2'), (N'1361097', N'MHCTT00004', N'3'), (N'1361097', N'MHCTT00005', N'3'), (N'1361098', N'MHCTT00001', N'4'), (N'1361098', N'MHCTT00002', N'9'), (N'1361098', N'MHCTT00004', N'4'), (N'1361098', N'MHCTT00005', N'7'), (N'1361099', N'MHCTT00003', N'5'), (N'1361099', N'MHCTT00004', N'8'), (N'1361099', N'MHCTT00005', N'7'), (N'1361100', N'MHCTT00002', N'4'), (N'1361100', N'MHCTT00003', N'2'), (N'1361100', N'MHCTT00004', N'7'), (N'1361100', N'MHCTT00005', N'9')
GO







-- Thêm sinh viên Admin (cần có bản ghi trong bảng Student trước vì có khóa ngoại)
INSERT INTO [Student] ([Id], [Name], [BOF], [IdProvince], [Gender])
VALUES (N'ADMIN01', N'System Administrator', N'1990-01-01 00:00:00.000', N'2', N'1');

-- Thêm tài khoản Admin vào bảng User
INSERT INTO [User] ([IdStudent], [Username], [Password], [Note], [Status], [CreatedAt], [ModifiedAt])
VALUES (N'ADMIN01', N'admin', N'Admin@123', N'Tài khoản quản trị hệ thống', 1, GETDATE(), GETDATE());

-- Thêm bản ghi UserRole để gán quyền Admin cho tài khoản này
INSERT INTO [UserRole] ([Id], [IdStudent], [IdRole])
VALUES (N'UR001', N'ADMIN01', N'R1');


SELECT COUNT(*) FROM [UserRole] WHERE IdStudent = @IdStudent AND IdRole = @IdRole


SELECT ur.Id, ur.IdStudent, ur.IdRole, 
       u.Username,                     
       u.IdStudent as StudentId,      
       s.Name as StudentName,         
       r.Name as RoleName 
FROM UserRole ur
INNER JOIN [User] u ON ur.IdStudent = u.IdStudent  -- Đã sửa điều kiện này
INNER JOIN Role r ON ur.IdRole = r.Id
LEFT JOIN Student s ON u.IdStudent = s.Id;
       
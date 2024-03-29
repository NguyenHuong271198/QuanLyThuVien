USE [master]
GO
/****** Object:  Database [Library]    Script Date: 5/31/2019 11:04:22 AM ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Library.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Library_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Library]
GO
/****** Object:  UserDefinedFunction [dbo].[ufn_removeMark]    Script Date: 5/31/2019 11:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufn_removeMark] (@text nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
	SET @text = LOWER(@text)
	DECLARE @textLen int = LEN(@text)
	IF @textLen > 0
	BEGIN
		DECLARE @index int = 1
		DECLARE @lPos int
		DECLARE @SIGN_CHARS nvarchar(100) = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýđð'
		DECLARE @UNSIGN_CHARS varchar(100) = 'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyydd'

		WHILE @index <= @textLen
		BEGIN
			SET @lPos = CHARINDEX(SUBSTRING(@text,@index,1),@SIGN_CHARS)
			IF @lPos > 0
			BEGIN
				SET @text = STUFF(@text,@index,1,SUBSTRING(@UNSIGN_CHARS,@lPos,1))
			END
			SET @index = @index + 1
		END
	END
	RETURN @text
END

GO
/****** Object:  Table [dbo].[tblDocGia]    Script Date: 5/31/2019 11:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblDocGia](
	[MADG] [varchar](10) NOT NULL,
	[HOTEN] [nvarchar](100) NOT NULL,
	[NGAYSINH] [varchar](50) NOT NULL,
	[GIOITINH] [nvarchar](10) NOT NULL,
	[LOP] [varchar](50) NOT NULL,
	[DIACHI] [nvarchar](100) NOT NULL,
	[EMAIL] [varchar](50) NOT NULL,
	[GHICHU] [nvarchar](max) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__tblDocGi__603F004691AC70BA] PRIMARY KEY CLUSTERED 
(
	[MADG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLinhVuc]    Script Date: 5/31/2019 11:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLinhVuc](
	[MALV] [varchar](10) NOT NULL,
	[TENLV] [nvarchar](100) NOT NULL,
	[GHICHU] [nvarchar](max) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK__tblLinhV__603F415351441711] PRIMARY KEY CLUSTERED 
(
	[MALV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 5/31/2019 11:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[TENTAIKHOAN] [varchar](50) NOT NULL,
	[MATKHAU] [varchar](50) NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TENTAIKHOAN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblSach]    Script Date: 5/31/2019 11:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblSach](
	[MASACH] [varchar](10) NOT NULL,
	[TENSACH] [nvarchar](100) NOT NULL,
	[TACGIA] [nvarchar](100) NOT NULL,
	[NHAXUATBAN] [nvarchar](100) NOT NULL,
	[NAMXB] [varchar](50) NOT NULL,
	[SOTRANG] [int] NOT NULL,
	[SOLUONG] [int] NOT NULL,
	[NGAYNHAP] [varchar](50) NOT NULL,
	[GHICHU] [nvarchar](max) NULL,
	[MALV] [varchar](10) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SOSACHHONG] [nchar](10) NULL,
 CONSTRAINT [PK__tblSach__3FC48E4CBA3759E4] PRIMARY KEY CLUSTERED 
(
	[MASACH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblThongTinMuon]    Script Date: 5/31/2019 11:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblThongTinMuon](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SOLUONGMUON] [int] NOT NULL,
	[NGAYMUON] [varchar](50) NOT NULL,
	[NGAYTRA] [varchar](50) NOT NULL,
	[XACNHANTRA] [nvarchar](50) NULL,
	[GHICHU] [nvarchar](max) NULL,
	[MASACH] [varchar](10) NOT NULL,
	[MADG] [varchar](10) NOT NULL,
 CONSTRAINT [PK__tblThong__3214EC279004800E] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblDocGia] ON 

INSERT [dbo].[tblDocGia] ([MADG], [HOTEN], [NGAYSINH], [GIOITINH], [LOP], [DIACHI], [EMAIL], [GHICHU], [ID]) VALUES (N'dg01', N'Lê Văn Dũng', N'08-12-1998', N'Nam', N'khmt15', N'Hà Nội', N'dung@gmail.com', N'note 1', 1)
INSERT [dbo].[tblDocGia] ([MADG], [HOTEN], [NGAYSINH], [GIOITINH], [LOP], [DIACHI], [EMAIL], [GHICHU], [ID]) VALUES (N'dg02', N'Nguyễn Thị Hường', N'27-11-1998', N'Nữ', N'httt15', N'Đặng Thùy Trâm', N'huong@gmail.com', N'note 2', 5)
INSERT [dbo].[tblDocGia] ([MADG], [HOTEN], [NGAYSINH], [GIOITINH], [LOP], [DIACHI], [EMAIL], [GHICHU], [ID]) VALUES (N'dg03', N'Nguyễn Chiến Thắng', N'21-02-1998', N'Nam', N'khmt15', N'Trần Cung', N'thang@gmail.com', N'note 3', 6)
INSERT [dbo].[tblDocGia] ([MADG], [HOTEN], [NGAYSINH], [GIOITINH], [LOP], [DIACHI], [EMAIL], [GHICHU], [ID]) VALUES (N'dg04', N'Hà Thị Kim Biên', N'31-08-1998', N'Nữ', N'httt15', N'Đặng Thùy Trâm', N'bien@gmail.com', N'note4', 8)
INSERT [dbo].[tblDocGia] ([MADG], [HOTEN], [NGAYSINH], [GIOITINH], [LOP], [DIACHI], [EMAIL], [GHICHU], [ID]) VALUES (N'dg05', N'Đỗ Thị Quyên', N'29-08-1998', N'Nữ', N'httt15', N'Đặng Thùy Trâm', N'quyen@gmail.com', N'note5', 9)
SET IDENTITY_INSERT [dbo].[tblDocGia] OFF
SET IDENTITY_INSERT [dbo].[tblLinhVuc] ON 

INSERT [dbo].[tblLinhVuc] ([MALV], [TENLV], [GHICHU], [ID]) VALUES (N'lv01', N'lập trình', N'note 1', 1)
INSERT [dbo].[tblLinhVuc] ([MALV], [TENLV], [GHICHU], [ID]) VALUES (N'lv02', N'giáo dục', N'note 2', 4)
INSERT [dbo].[tblLinhVuc] ([MALV], [TENLV], [GHICHU], [ID]) VALUES (N'lv03', N'đời sống', N'note 3', 1003)
INSERT [dbo].[tblLinhVuc] ([MALV], [TENLV], [GHICHU], [ID]) VALUES (N'lv04', N'công nghệ', N'note 4', 1006)
INSERT [dbo].[tblLinhVuc] ([MALV], [TENLV], [GHICHU], [ID]) VALUES (N'lv05', N'Toán học', N'note5', 1007)
SET IDENTITY_INSERT [dbo].[tblLinhVuc] OFF
SET IDENTITY_INSERT [dbo].[tblNhanVien] ON 

INSERT [dbo].[tblNhanVien] ([TENTAIKHOAN], [MATKHAU], [ID]) VALUES (N'dung', N'12345', 2)
INSERT [dbo].[tblNhanVien] ([TENTAIKHOAN], [MATKHAU], [ID]) VALUES (N'huong', N'271198', 3)
INSERT [dbo].[tblNhanVien] ([TENTAIKHOAN], [MATKHAU], [ID]) VALUES (N'nv01', N'aaaaa', 1)
SET IDENTITY_INSERT [dbo].[tblNhanVien] OFF
SET IDENTITY_INSERT [dbo].[tblSach] ON 

INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book03', N'Tin học văn phòng', N'Nguyễn Kim Thu', N'thời đại', N'2007', 120, 20, N'05-03-2018', N'note3', N'lv04', 1003, N'0         ')
INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book04', N'Cấu trúc máy tính', N'Phan Minh', N'Lao động', N'2017', 200, 29, N'05-03-2018', N'note', N'lv04', 1004, N'0         ')
INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book05', N'Lý thuyết hệ điều hành', N'Hoàng Cầu', N'kim đồng', N'2018', 300, 29, N'05-02-2018', N'note4', N'lv01', 1005, N'0         ')
INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book06', N'Toán rời rạc', N'Thu Tuyết', N'Đại học quốc gia', N'2019', 200, 30, N'05-03-2019', N'note5', N'lv05', 1008, N'0         ')
INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book07', N'Mạng máy tính', N'Hoàng Mạnh', N'Lao động', N'2018', 300, 20, N'03-06-2018', N'note6', N'lv01', 1009, N'0         ')
INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book08', N'Đại số tuyến tính ', N'Vũ Minh', N'Đại học sư phạm', N'2017', 200, 25, N'06-09-2018', N'note7', N'lv05', 1010, N'0         ')
INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book09', N'Kiến trúc máy tính', N'Thu Trang ', N'Kim đồng', N'2017', 150, 30, N'09-02-2018', N'note8', N'lv01', 1011, N'0         ')
INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book10', N'Tư tưởng Hồ Chí Minh', N'nhiều tác giả ', N'lao động', N'2017', 250, 20, N'09-01-2018', N'note9', N'lv02', 1012, N'0         ')
INSERT [dbo].[tblSach] ([MASACH], [TENSACH], [TACGIA], [NHAXUATBAN], [NAMXB], [SOTRANG], [SOLUONG], [NGAYNHAP], [GHICHU], [MALV], [ID], [SOSACHHONG]) VALUES (N'book11', N'Giải tích', N'Nguyễn Hữu Công', N'lao động', N'2017', 300, 20, N'03-03-2018', N'note10', N'lv02', 1013, NULL)
SET IDENTITY_INSERT [dbo].[tblSach] OFF
SET IDENTITY_INSERT [dbo].[tblThongTinMuon] ON 

INSERT [dbo].[tblThongTinMuon] ([ID], [SOLUONGMUON], [NGAYMUON], [NGAYTRA], [XACNHANTRA], [GHICHU], [MASACH], [MADG]) VALUES (29, 1, N'22-05-2019', N'22-06-2019', N'Chưa trả', N'', N'book04', N'dg02')
INSERT [dbo].[tblThongTinMuon] ([ID], [SOLUONGMUON], [NGAYMUON], [NGAYTRA], [XACNHANTRA], [GHICHU], [MASACH], [MADG]) VALUES (31, 1, N'06-05-2019', N'26-06-2019', N'Chưa trả', N'', N'book05', N'dg01')
INSERT [dbo].[tblThongTinMuon] ([ID], [SOLUONGMUON], [NGAYMUON], [NGAYTRA], [XACNHANTRA], [GHICHU], [MASACH], [MADG]) VALUES (32, 1, N'06-05-2019', N'31-05-2019', N'Chưa trả', N'', N'book04', N'dg03')
SET IDENTITY_INSERT [dbo].[tblThongTinMuon] OFF
ALTER TABLE [dbo].[tblSach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_LinhVuc] FOREIGN KEY([MALV])
REFERENCES [dbo].[tblLinhVuc] ([MALV])
GO
ALTER TABLE [dbo].[tblSach] CHECK CONSTRAINT [FK_Sach_LinhVuc]
GO
ALTER TABLE [dbo].[tblThongTinMuon]  WITH CHECK ADD  CONSTRAINT [FK_TTM_DocGia] FOREIGN KEY([MADG])
REFERENCES [dbo].[tblDocGia] ([MADG])
GO
ALTER TABLE [dbo].[tblThongTinMuon] CHECK CONSTRAINT [FK_TTM_DocGia]
GO
ALTER TABLE [dbo].[tblThongTinMuon]  WITH CHECK ADD  CONSTRAINT [FK_TTM_Sach] FOREIGN KEY([MASACH])
REFERENCES [dbo].[tblSach] ([MASACH])
GO
ALTER TABLE [dbo].[tblThongTinMuon] CHECK CONSTRAINT [FK_TTM_Sach]
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO

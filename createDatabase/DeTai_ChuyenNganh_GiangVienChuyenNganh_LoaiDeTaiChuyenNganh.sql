USE [QuanLyDeTai]
GO
CREATE TABLE DeTai
(
	maDeTai [int] IDENTITY(1,1) NOT NULL,
	tenDeTai [nvarchar](256) NULL,
	mucTieu [nvarchar](256) NULL,
	yeuCau [nvarchar](256) NULL,
	sanPham [nvarchar](256) NULL,
	chuThich [nvarchar](256) NULL,
	soLuongSinhVienToiDa [int] NULL,
	duocDangKyKhacChuyenNganh [bit] NULL,
	nienKhoa [nvarchar](256) NULL,
	loaiDeTai [nvarchar](256) NULL,
	diem [float] NULL,
	truongNhom [int] NULL,
	gvHuongDan [int] NULL,
	CONSTRAINT PK_DeTai_maDeTai PRIMARY KEY (maDeTai),
	CONSTRAINT FK_DeTai_LoaiDeTai_loaiDeTai FOREIGN KEY (loaiDeTai) REFERENCES LoaiDeTai (maLoaiDeTai),
	CONSTRAINT FK_DeTai_GiangVien_gvHuongDan FOREIGN KEY (gvHuongDan) REFERENCES GiangVien (maGiangVien),
	CONSTRAINT FK_DeTai_SinhVien_truongNhom FOREIGN KEY (truongNhom) REFERENCES SinhVien (MSSV)
)

CREATE TABLE ChuyenNganh
(
	maChuyenNganh [int] IDENTITY(1,1) NOT NULL,
	tenChuyenNganh [nvarchar](256) NULL,
	truongBoMon [int] NULL,
	CONSTRAINT PK_ChuyenNganh_maChuyenNganh PRIMARY KEY (maChuyenNganh),
	CONSTRAINT FK_ChuyenNganh_GiangVien_truongBoMon FOREIGN KEY (truongBoMon) REFERENCES GiangVien (maGiangVien),
)

CREATE TABLE LoaiDeTaiChuyenNganh
(
	maChuyenNganh [int] NOT NULL,
	maLoaiDeTai [int] NOT NULL,
	CONSTRAINT PK_LoaiDeTaiChuyenNganh_maChuyenNganh_maLoaiDeTai PRIMARY KEY (maChuyenNganh, maLoaiDeTai),
	CONSTRAINT FK_LoaiDeTaiChuyenNganh_ChuyenNganh_maChuyenNganh FOREIGN KEY (maChuyenNganh) REFERENCES ChuyenNganh (maChuyenNganh),
	CONSTRAINT FK_LoaiDeTaiChuyenNganh_LoaiDeTai_maLoaiDeTai FOREIGN KEY (maLoaiDeTai) REFERENCES LoaiDeTai (maLoaiDeTai),
)

CREATE TABLE GiangVienChuyenNganh
(
	maChuyenNganh [int] NOT NULL,
	maGiangVien [int] NOT NULL,
	CONSTRAINT PK_GiangVienChuyenNganh_maChuyenNganh_maGiangVien PRIMARY KEY (maChuyenNganh, maGiangVien),
	CONSTRAINT FK_GiangVienChuyenNganh_ChuyenNganh_maChuyenNganh FOREIGN KEY (maChuyenNganh) REFERENCES ChuyenNganh (maChuyenNganh),
	CONSTRAINT FK_GiangVienChuyenNganh_GiangVien_maGiangVien FOREIGN KEY (maGiangVien) REFERENCES GiangVien (maGiangVien),
)

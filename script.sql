USE [CSDL]
GO
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'11  ', N'Bui Van A', N'Hai Phong', N'0456555533', CAST(N'1990-01-14T00:00:00' AS SmallDateTime), CAST(N'2020-01-01T00:00:00' AS SmallDateTime), 150000.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'12  ', N'Tran Van B', N'Ha Noi', N'0123789955', CAST(N'1990-02-04T00:00:00' AS SmallDateTime), CAST(N'2020-01-03T00:00:00' AS SmallDateTime), 20000.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'13  ', N'Le Thi C', N'Ha Noi', N'0559897777', CAST(N'1990-04-05T00:00:00' AS SmallDateTime), CAST(N'2020-03-11T00:00:00' AS SmallDateTime), 45000.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'14  ', N'Pham Van D', N'Ha Nam', N'0362656999', CAST(N'1991-04-16T00:00:00' AS SmallDateTime), CAST(N'2020-04-07T00:00:00' AS SmallDateTime), 60000.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'15  ', N'Le Van Nam', N'Da Nang', N'0445898953', CAST(N'1995-02-27T00:00:00' AS SmallDateTime), CAST(N'2021-01-29T00:00:00' AS SmallDateTime), 78000.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'16  ', N'Lo Thi Mai', N'Nam Dinh', N'0332159779', CAST(N'1996-03-24T00:00:00' AS SmallDateTime), CAST(N'2021-06-08T00:00:00' AS SmallDateTime), 12000.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'17  ', N'Dang Van Hieu', N'Thanh Hoa', N'0478898999', CAST(N'1997-06-19T00:00:00' AS SmallDateTime), CAST(N'2021-05-02T00:00:00' AS SmallDateTime), 80000.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'18  ', N'Do Van Anh', N'Quang Ninh', N'0369251000', CAST(N'1992-04-18T00:00:00' AS SmallDateTime), CAST(N'2021-03-09T00:00:00' AS SmallDateTime), 14500.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'19  ', N'Khoa Thi Hy', N'Cao Bang', N'0179877741', CAST(N'1993-02-19T00:00:00' AS SmallDateTime), CAST(N'2021-02-22T00:00:00' AS SmallDateTime), 19000.0000)
INSERT [dbo].[KHACHHANG] ([MAKH], [HOTEN], [DCHI], [SODT], [NGSINH], [NGDK], [DOANHSO]) VALUES (N'20  ', N'Doan Van Minh', N'Hai Phong', N'0235684441', CAST(N'1998-05-05T00:00:00' AS SmallDateTime), CAST(N'2021-04-14T00:00:00' AS SmallDateTime), 25000.0000)
GO
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'01  ', N'Nguyen Van A', N'0332562145', CAST(N'2020-08-02T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'02  ', N'Nguyen Van B', N'0125487785', CAST(N'2020-02-25T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'03  ', N'Pham Van Nam', N'0456599895', CAST(N'2020-04-14T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'04  ', N'Le  Thi My', N'0125488995', CAST(N'2020-04-07T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'05  ', N'Doan Khanh Van', N'0332651404', CAST(N'2020-05-05T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'06  ', N'Tran Trung Nghia', N'0229645789', CAST(N'2020-08-07T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'07  ', N'Le Thanh long', N'0145897565', CAST(N'2020-09-19T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'08  ', N'Bui Van Phuong', N'0336964784', CAST(N'2020-10-06T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'09  ', N'Cao Van Khoa', N'0445898799', CAST(N'2020-04-27T00:00:00' AS SmallDateTime))
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [SODT], [NGVL]) VALUES (N'10  ', N'Le Trong Son', N'0187989842', CAST(N'2020-02-23T00:00:00' AS SmallDateTime))
GO
INSERT [dbo].[HOADON] ([SOHD], [NGHD], [MAKH], [MANV], [TRIGIA]) VALUES (31, CAST(N'2007-01-01T00:00:00' AS SmallDateTime), N'11  ', N'01  ', 100.0000)
INSERT [dbo].[HOADON] ([SOHD], [NGHD], [MAKH], [MANV], [TRIGIA]) VALUES (32, CAST(N'2006-10-28T00:00:00' AS SmallDateTime), N'13  ', N'02  ', 120.0000)
INSERT [dbo].[HOADON] ([SOHD], [NGHD], [MAKH], [MANV], [TRIGIA]) VALUES (33, CAST(N'2007-01-11T00:00:00' AS SmallDateTime), N'14  ', N'07  ', 110.0000)
INSERT [dbo].[HOADON] ([SOHD], [NGHD], [MAKH], [MANV], [TRIGIA]) VALUES (34, CAST(N'2007-02-01T00:00:00' AS SmallDateTime), N'16  ', N'05  ', 150.0000)
INSERT [dbo].[HOADON] ([SOHD], [NGHD], [MAKH], [MANV], [TRIGIA]) VALUES (35, CAST(N'2007-01-26T00:00:00' AS SmallDateTime), N'19  ', N'08  ', 200.0000)
INSERT [dbo].[HOADON] ([SOHD], [NGHD], [MAKH], [MANV], [TRIGIA]) VALUES (36, CAST(N'2006-10-28T00:00:00' AS SmallDateTime), N'13  ', N'02  ', 14000.0000)
INSERT [dbo].[HOADON] ([SOHD], [NGHD], [MAKH], [MANV], [TRIGIA]) VALUES (37, CAST(N'2006-10-10T00:00:00' AS SmallDateTime), N'11  ', N'02  ', 24000.0000)
INSERT [dbo].[HOADON] ([SOHD], [NGHD], [MAKH], [MANV], [TRIGIA]) VALUES (38, CAST(N'2006-01-12T00:00:00' AS SmallDateTime), N'13  ', N'02  ', 12000.0000)
GO
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'21  ', N'a1', N'cay', N'Singapore', 10000.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'22  ', N'a2', N'cay', N'Thai Lan', 34000.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'23  ', N'a3', N'kilogam', N'Singapore', 12000.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'24  ', N'a4', N'chiec', N'Trung Quoc', 33000.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'25  ', N'a5', N'quyen', N'Thai Lan', 20.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'26  ', N'a6', N'quyen', N'VietNam', 22.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'27  ', N'a7', N'chiec', N'VietNam', 29.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'28  ', N'a8', N'Ta', N'Trung Quoc', 35000.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'29  ', N'a9', N'chiec', N'Trung Quoc', 150.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'BB01', N'a10', N'cay', N'Trung Quoc', 45000.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'BB02', N'a11', N'cay', N'Trung Quoc', 50000.0000)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DVT], [NUOCSX], [GIA]) VALUES (N'BC01', N'a12', N'Ta', N'Trung Quoc', 36000.0000)
GO
INSERT [dbo].[CTHD] ([SOHD], [MASP], [SL]) VALUES (31, N'21  ', 10)
INSERT [dbo].[CTHD] ([SOHD], [MASP], [SL]) VALUES (31, N'23  ', 8)
INSERT [dbo].[CTHD] ([SOHD], [MASP], [SL]) VALUES (32, N'23  ', 15)
INSERT [dbo].[CTHD] ([SOHD], [MASP], [SL]) VALUES (33, N'25  ', 17)
INSERT [dbo].[CTHD] ([SOHD], [MASP], [SL]) VALUES (36, N'21  ', 10)
INSERT [dbo].[CTHD] ([SOHD], [MASP], [SL]) VALUES (36, N'23  ', 5)
GO

USE [ThucTap]
GO
INSERT [dbo].[Khoa] ([makhoa], [tenkhoa], [dienthoai]) VALUES (N'01        ', N'Dia ly va QLTN                ', N'154545    ')
INSERT [dbo].[Khoa] ([makhoa], [tenkhoa], [dienthoai]) VALUES (N'02        ', N'Toan                          ', N'1547854   ')
INSERT [dbo].[Khoa] ([makhoa], [tenkhoa], [dienthoai]) VALUES (N'03        ', N'Ngu Van                       ', N'25448     ')
GO
INSERT [dbo].[GiangVien] ([magv], [hotengv], [luong], [makhoa]) VALUES (11, N'Van A                         ', CAST(700.00 AS Decimal(5, 2)), N'01        ')
INSERT [dbo].[GiangVien] ([magv], [hotengv], [luong], [makhoa]) VALUES (12, N'Thi B                         ', CAST(500.00 AS Decimal(5, 2)), N'02        ')
INSERT [dbo].[GiangVien] ([magv], [hotengv], [luong], [makhoa]) VALUES (13, N'Chu An                        ', CAST(650.00 AS Decimal(5, 2)), N'03        ')
INSERT [dbo].[GiangVien] ([magv], [hotengv], [luong], [makhoa]) VALUES (14, N'Le Minh                       ', CAST(500.00 AS Decimal(5, 2)), N'03        ')
INSERT [dbo].[GiangVien] ([magv], [hotengv], [luong], [makhoa]) VALUES (15, N'Tran Nam                      ', CAST(900.00 AS Decimal(5, 2)), N'02        ')
GO
INSERT [dbo].[SinhVien] ([masv], [hotensv], [makhoa], [namsinh], [quequan]) VALUES (1, N'Le Van A                      ', N'03        ', 1991, N'Nghe An                       ')
INSERT [dbo].[SinhVien] ([masv], [hotensv], [makhoa], [namsinh], [quequan]) VALUES (2, N'Nguyen Thi Mai                ', N'01        ', 1999, N'Thanh Hoa                     ')
INSERT [dbo].[SinhVien] ([masv], [hotensv], [makhoa], [namsinh], [quequan]) VALUES (3, N'Bui Nam                       ', N'02        ', 1994, N'Ha Noi                        ')
INSERT [dbo].[SinhVien] ([masv], [hotensv], [makhoa], [namsinh], [quequan]) VALUES (4, N'Nguyen Tung                   ', N'03        ', NULL, N'Ha Tinh                       ')
INSERT [dbo].[SinhVien] ([masv], [hotensv], [makhoa], [namsinh], [quequan]) VALUES (5, N'Le Khanh Linh                 ', N'02        ', 1994, N'Hai Phong                     ')
INSERT [dbo].[SinhVien] ([masv], [hotensv], [makhoa], [namsinh], [quequan]) VALUES (6, N'Tran Khac Trong               ', N'03        ', 1992, N'Thanh Hoa                     ')
INSERT [dbo].[SinhVien] ([masv], [hotensv], [makhoa], [namsinh], [quequan]) VALUES (7, N'Le Van Khoa                   ', N'02        ', NULL, N'Nam Dinh                      ')
INSERT [dbo].[SinhVien] ([masv], [hotensv], [makhoa], [namsinh], [quequan]) VALUES (8, N'Hoang Nam                     ', N'01        ', 1999, N'Nghe An                       ')
GO
INSERT [dbo].[DeTai] ([madt], [tendt], [kinhphi], [NoiThucTap]) VALUES (N'Dt01      ', N'S1                            ', 100, N'Nghe An                       ')
INSERT [dbo].[DeTai] ([madt], [tendt], [kinhphi], [NoiThucTap]) VALUES (N'Dt02      ', N'S2                            ', 900, N'Nam Dinh                      ')
INSERT [dbo].[DeTai] ([madt], [tendt], [kinhphi], [NoiThucTap]) VALUES (N'Dt03      ', N'S3                            ', 200, N'Ha Tinh                       ')
INSERT [dbo].[DeTai] ([madt], [tendt], [kinhphi], [NoiThucTap]) VALUES (N'Dt04      ', N'S4                            ', 100, N'Quang Binh                    ')
GO
INSERT [dbo].[HuongDan] ([masv], [madt], [magv], [ketqua]) VALUES (7, N'Dt04      ', 11, CAST(10.00 AS Decimal(5, 2)))
INSERT [dbo].[HuongDan] ([masv], [madt], [magv], [ketqua]) VALUES (3, N'Dt03      ', 12, CAST(10.00 AS Decimal(5, 2)))
INSERT [dbo].[HuongDan] ([masv], [madt], [magv], [ketqua]) VALUES (1, N'Dt01      ', 13, CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[HuongDan] ([masv], [madt], [magv], [ketqua]) VALUES (6, N'Dt01      ', 13, NULL)
INSERT [dbo].[HuongDan] ([masv], [madt], [magv], [ketqua]) VALUES (2, N'Dt03      ', 14, CAST(0.00 AS Decimal(5, 2)))
INSERT [dbo].[HuongDan] ([masv], [madt], [magv], [ketqua]) VALUES (5, N'Dt04      ', 14, CAST(7.00 AS Decimal(5, 2)))
INSERT [dbo].[HuongDan] ([masv], [madt], [magv], [ketqua]) VALUES (8, N'Dt03      ', 15, CAST(6.00 AS Decimal(5, 2)))
GO

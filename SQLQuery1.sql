create database CSDL
use CSDL
create table CTHD(
SOHD int primary key not null,
MASP char(4)  not null,
SL int,
foreign key (MASP) references SANPHAM(MASP),
foreign key (SOHD) references HOADON(SOHD)
)
create table SANPHAM(
MASP char(4) primary key not null,
TENSP varchar(40) ,
DVT varchar(20),
NUOCSX varchar(40),
GIA money
)

create table HOADON(
SOHD int primary key not null,
NGHD smalldatetime,
MAKH char(4),
MANV char(4),
TRIGIA money,
foreign key (MAKH) references KHACHHANG(MAKH),
foreign key (MANV) references NHANVIEN(MANV)
)

create table KHACHHANG(
MAKH char(4) primary key not null,
HOTEN varchar(40),
DCHI varchar(50),
SODT varchar(20),
NGSINH smalldatetime,
NGDK smalldatetime,
DOANHSO money
)

create table NHANVIEN(
MANV char(4) primary key not null,
HOTEN varchar(40),
SODT varchar(20),
NGVL smalldatetime
)

--a
select MASP,TENSP from SANPHAM
where NUOCSX = 'Trung Quoc';

--b
select MaSP,TENSP from SANPHAM
where DVT ='cay' OR  DVT= 'quyen';
--c
select MASP,TENSP from SANPHAM
where NUOCSX = 'Trung Quoc' AND MASP like 'B%01';
--d
select MASP,TENSP from SANPHAM
where NUOCSX = 'Trung Quoc' AND (GIA BETWEEN 30000 AND 40000);
--e
select MASP,TENSP from SANPHAM
where (NUOCSX = 'Trung Quoc' or NUOCSX='Thai Lan') AND (GIA BETWEEN 30000 AND 40000);
--f
select SOHD,TRIGIA from HOADON
where NGHD='1/1/2007' OR NGHD='2/1/2007'

--g
select SOHD,TRIGIA from HOADON
WHERE MONTH(NGHD)=1 AND YEAR(NGHD)=2007
ORDER BY  NGHD ASC,TRIGIA DESC

--h 
select KHACHHANG.MAKH,HOTEN from KHACHHANG,HOADON
where KHACHHANG.MAKH = HOADON.MAKH  AND NGHD ='1/1/2007';

--i
select SOHD,TRIGIA from HOADON,NHANVIEN
where HOADON.MANV = NHANVIEN.MANV and NGHD ='10/28/2006' and HOTEN='Nguyen Van B';


--j
select CTHD.MASP,TENSP from SANPHAM,KHACHHANG,CTHD,HOADON
where SANPHAM.MASP = CTHD.MASP  and CTHD.SOHD =HOADON.SOHD and KHACHHANG.MAKH = HOADON.MAKH 
AND  MONTH(NGHD)= 10 AND YEAR(NGHD)= 2006 AND HOTEN='Nguyen Van A';


--k
select SOHD
from CTHD,SANPHAM
where CTHD.MASP = SANPHAM.MASP
and (SANPHAM.MASP='BB01' or SANPHAM.MASP ='BB02');

--l
select SOHD
from CTHD,SANPHAM
where CTHD.MASP = SANPHAM.MASP
and (SANPHAM.MASP='BB01' or SANPHAM.MASP ='BB02') and (SL between 10 and 20); 

--m
select SOHD
from CTHD,SANPHAM
where CTHD.MASP = SANPHAM.MASP
and (SANPHAM.MASP='BB01' and SOHD IN (  SELECT SOHD
     FROM  CTHD
     WHERE MASP='BB02')) and (SL between 10 and 20); 


--n
select SANPHAM.MASP,TENSP from SANPHAM, HOADON,CTHD
where SANPHAM.MASP = CTHD.MASP and CTHD.SOHD = HOADON.SOHD
and (NUOCSX='Trung Quoc' or NGHD ='1/1/2007' );

--o
select MASP,TENSP from SANPHAM
where MASP not in (select MASP from CTHD);

--p
select MASP,TENSP from SANPHAM
where  MASP not in 
(select CTHD.MASP from CTHD,HOADON 
where CTHD.SOHD = HOADON.SOHD and YEAR(NGHD) = 2006);

--q
select SOHD from CTHD,SANPHAM
where CTHD.MASP = SANPHAM.MASP and NUOCSX ='Singapore';

drop table CTHD; 
CREATE TABLE CTHD
(
 SOHD  int FOREIGN KEY REFERENCES HOADON(SOHD),
 MASP  char(4) FOREIGN KEY REFERENCES SANPHAM(MASP),
 SL  int,
 CONSTRAINT PK_CTHD PRIMARY KEY (SOHD,MASP)
)
--r
select SOHD from HOADON
where year(NGHD)=2006
and NOT EXISTS
(
    select *
    from SANPHAM
    where NUOCSX = 'Singapore' and MASP NOT IN
    (
        select MASP
        from CTHD
        where CTHD.SOHD = HOADON.SOHD
    )
)

--s

select top 1 HOADON.MAKH, KHACHHANG.HOTEN
from(select top 10 HOADON.MAKH, KHACHHANG.HOTEN
from HOADON, KHACHHANG 
where  HOADON.MAKH = KHACHHANG.MAKH
order by KHACHHANG.DOANHSO DESC

) HOADON, KHACHHANG 
where  HOADON.MAKH = KHACHHANG.MAKH
GROUP BY HOADON.MAKH, KHACHHANG.HOTEN

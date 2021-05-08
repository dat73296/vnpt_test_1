using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Diem
    {
        public int tungdo;
        public int hoanhdo;
        //public Diem(int tungdo,int hoanhdo)
        //{
        //    this.tungdo = tungdo;
        //    this.hoanhdo = hoanhdo;

        //}
        public virtual void Nhap()
        {
            Console.WriteLine("Nhap vao tung do: ");
            tungdo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap vao hoanh do:");
            hoanhdo = Convert.ToInt32(Console.ReadLine());
        }
        public virtual void xuat()
        {
            Console.WriteLine("Tung do: {0}, Hoanh do:{1}", tungdo,hoanhdo);
        }
         public double KhoangCach(Diem d1, Diem d2)
        {
            double kc;
            kc = Math.Sqrt((d1.hoanhdo - d2.hoanhdo) * (d1.hoanhdo - d2.hoanhdo) + (d1.tungdo - d2.tungdo) * (d1.tungdo - d2.tungdo));
            return kc;
        }
       
        public double Chuvi(Diem d1,Diem d2,Diem d3)
        {
            double kc;
            kc = KhoangCach(d1, d2) + KhoangCach(d1, d3) + KhoangCach(d1, d3);
            return kc;
        }
        public double Ham(Diem d1)
        {
            double d = 6 * d1.tungdo + 9 * d1.hoanhdo;
            return d;
        }

    }
}

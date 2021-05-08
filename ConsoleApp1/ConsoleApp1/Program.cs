using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cau1
            /*int n;
            int imax = 0;
            int jmax = 0;
            double kc;
            Console.WriteLine("Nhap vao diem:");
            n = Convert.ToInt32(Console.ReadLine());
            List<Diem> diem = new List<Diem>();
            for(int i=0;i<n;i++)
            {
                Diem d = new Diem();
                d.Nhap();
                diem.Add(d);
            }
            Diem d1 = new Diem();
            for(int i = 0;i<n;i++)
            {
                Console.WriteLine("Thong tin Diem thu {0}", (i + 1));
                diem[i].xuat();
                Console.WriteLine("--------------------------------------");
            }
            double max = d1.KhoangCach(diem[0], diem[1]);
            // double[] a = new double[100];
            for (int i = 0; i < n; i++)
            {
                for (  int j = i + 1; j < n; j++)
                {
                    kc = d1.KhoangCach(diem[i], diem[j]);
                    if (kc >= max)
                    {
                        max = kc;
                        imax = i;
                        jmax = j;
                    }
                }
            }
            double cv;
            Console.WriteLine("Khoang cach 2 diem lon nhat la:{0} cua diem thu {1} va  thu {2} ",max ,imax+1,jmax+1);
            double maxchuvi = d1.Chuvi(diem[0], diem[1], diem[2]);
            for (int i = 0; i < n; i++)
            {
                for (int j = i+2 ; j < n; j++)
                {
                    cv = d1.Chuvi(diem[i], diem[j-1],diem[j]);
                    if (cv >= max)
                    {
                        maxchuvi = cv;
                    }
                }
            }
            Console.WriteLine("Chu vi lon nhat la {0}:",maxchuvi);
            Console.ReadKey();
            Diem da = new Diem();
            Diem db = new Diem();
            Console.WriteLine("Nhap vao Diem A:");
            da.Nhap();
            Console.WriteLine("Nhap vao Diem B:");
            db.Nhap();
            double k;
            Console.WriteLine("Ham so F({0},{1}) cua diem A la:{2} ", da.tungdo, db.hoanhdo, k = da.Ham(da));
            Console.WriteLine("Ham so F({0},{1}) cua diem B la:{2} ", da.tungdo, db.hoanhdo, k = db.Ham(db));
            Console.ReadKey();

           */

            //Cau2
            Vecto a = new Vecto();
            Vecto x = new Vecto();
            Console.WriteLine("Nhap vao vecto A:");
            a.Nhap();
            Vecto b = new Vecto();
            Console.WriteLine("Nhap vao vecto B:");
            b.Nhap();
            Console.WriteLine("Thong tin da nhap:\n");
            a.Xuat();
            b.Xuat();
            Console.WriteLine("Nhap vao goc xen giua:");
            double s = Convert.ToDouble(Console.ReadLine());
            double kc = x.KhoangCach(a, b);
            double tich = Math.Cos(Math.PI * s / 180) * kc;

            Console.WriteLine("Tich vo huong cua 2 vecto tren la: {0}", tich);
            Console.ReadKey();
            Console.WriteLine("Nhap vao so phan tu vec to:");
            int n = Convert.ToInt32(Console.ReadLine());
            List<Vecto> vt = new List<Vecto>();
            for (int i = 0; i < n; i++)
            {
                Vecto d = new Vecto();
                d.nhap();
                vt.Add(d);
            }
            Console.WriteLine("Thong tin cac diem vua nhap vao.");
            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine("Thong tin vecto  thu {}", (i + 1));
                vt[i].Xuat();
                Console.WriteLine("\n");
            }
            double timkc;
            List<double> termsList = new List<double>();
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                {
                    timkc = vt[i].KhoangCach(vt[i], vt[j]);
                    termsList.Add(timkc);
                }
            double[] mang = termsList.ToArray();
            for (int i = 0; i < mang.Length; i++)
            {
                for (int j = i + 1; j < mang.Length; j++)
                {
                    if (mang[i] < mang[j])
                    {
                        double temp = mang[i];
                        mang[i] = mang[j];
                        mang[j] = temp;
                    }
                }
            }

            Console.WriteLine("Cac gia tri can tim la:{0},{1},{2},{3}", mang[0], mang[1], mang[2], mang[3]);
            Console.ReadKey();
        }


    }
}

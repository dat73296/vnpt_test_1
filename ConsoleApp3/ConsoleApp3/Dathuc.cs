using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Dathuc
    {
        public int n=0;
        public  List<double> Heso;
         public double[] a;
        public void nhap()
        {
            Heso = new List<double>();
            Console.WriteLine("Nhap vao bac n:");
             n = Convert.ToInt32(Console.ReadLine());
            double x;
            for (int i = 0;i<=n;i++)
            {
                Console.WriteLine("Nhap vao he so bac thu:{0} ", i );
                x = Convert.ToDouble(Console.ReadLine());
                Heso.Add(x);
            }
            a = Heso.ToArray();

        }
        public void xuat()
        {
            Console.WriteLine("Bac:{0}", n);
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("He so bac {0} la:{1}",i,a[i]);

            }
        }
        public void Gop(Dathuc da1,Dathuc da2)
        {
            if (da1.n == da2.n)
            {
                for (int i = 0; i <= da1.n; i++)
                {
                    da1.a[i] = da1.a[i] + da2.a[i];
                }
            }
            if(da1.n > da2.n)
            {
                for (int i = 0; i <= da2.n; i++)
                {
                    da1.a[i] = da1.a[i] + da2.a[i];
                }
            }

            if (da1.n < da2.n)
            {
                for (int i = 0; i <= da1.n; i++)
                {
                    da2.a[i] = da1.a[i] + da2.a[i];
                }
                
            }
        }
        public void Tru(Dathuc da1, Dathuc da2)
        {
            if (da1.n == da2.n)
            {
                for (int i = 0; i <= da1.n; i++)
                {
                    da1.a[i] = da1.a[i] - da2.a[i];
                }
            }
            if (da1.n > da2.n)
            {
                for (int i = 0; i <= da2.n; i++)
                {
                    da1.a[i] = da1.a[i] - da2.a[i];
                }
            }

            if (da1.n < da2.n)
            {
                for (int i = 0; i <= da1.n; i++)
                {
                    da2.a[i] = da1.a[i] - da2.a[i];
                }
                for (int i = da1.n + 1; i <= da2.n; i++)
                    da2.a[i] = 0 - da2.a[i];

            }
        }
    }
}

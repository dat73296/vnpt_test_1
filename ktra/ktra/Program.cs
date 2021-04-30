using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktra
{
    class Program
    {
        static void Main(string[] args)
        {
            int dem = 0;
            int n1, n;
            double dec = 0, i = 0, d;
            string b="";
            Console.WriteLine("Nhap  vao so Thap phan B:");
            b = Console.ReadLine();

            if (b.Length < 1 && b.Length > 32)
                Console.WriteLine("Ban nhap  sai  do dai  quy dinh cua chuoi B");
            else
            {
                foreach (char c in b)
                {
                    if (c.Equals('0') || c.Equals('1'))
                        dem++;

                }

                if (dem != b.Length)
                {
                    Console.WriteLine("Ban da nhap  sai du lieu!!!");
                }
                else
                {
                    n = Convert.ToInt32(b);
                    n1 = n;
                    while (n != 0)
                    {
                        d = n % 10;
                        dec = dec + d * Math.Pow(2, i); // su dung ham trong C#
                        n = n / 10;
                        i++;
                    }
                    Console.Write("\nSo trong he nhi phan: {0}\nSo thap phan tuong duong la: {1}\n\n", n1, dec);
                }
                Console.ReadKey();
            }
        }
    }
}
 
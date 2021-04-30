using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string x;
            Console.WriteLine("Nhap vao chuoi:");
            x = Console.ReadLine();
            char[] a;
            
            a = x.ToCharArray();
            bool[] b = PhanLoai(a);
            for (int i = 0; i < a.Length; i++)
            {
                if (b[i])
                {
                    int dem = Dem(a, a[i]);
                    Console.WriteLine($"{a[i]} xuat hien {dem} lan");
                }
            }
            Console.ReadKey();
            
        }
        static bool[] PhanLoai(char[] arr)
        {
            bool[] a = new bool[arr.Length];
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                bool x = true;
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        x = false;
                        break;
                    }
                }
                a[i] = x;
            }
            return a;
        }
        static int Dem(char []a,char x)
           
        {
            int dem = 0;
            for(int i=0;i<a.Length;i++)
            {
                if (x == a[i])
                {
                    dem++;
                }
            }
            return dem;
        }
    }
}

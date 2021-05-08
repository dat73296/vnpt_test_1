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
            Dathuc a = new Dathuc();
            a.nhap();
            Console.WriteLine("Da thuc vua nhap vao la:\n ");
            a.xuat();
            Dathuc b = new Dathuc();
            b.nhap();
            Console.WriteLine("Da thuc vua nhap vao la:\n ");
            b.xuat();
            //  a.Gop(a, b);
            a.Tru(a, b);
            Console.WriteLine("Ket qua cua phep cong 2 da thuc tren la: ");
            if (a.n >= b.n)
                a.xuat();
            else
                b.xuat();

            Console.ReadKey();
            

        }
    }
}

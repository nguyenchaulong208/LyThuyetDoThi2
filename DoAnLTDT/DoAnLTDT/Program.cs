using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string filename = "input.txt";
            XL_INPUT.KiemTraFile(filename);
            YC1.Run_YC1();
            //   Xuly.ChuyenDoiMTK(filename);
            ////   Xuly.outputarray(Xuly.data);
            //Console.Read();

            //Thuat toan DFS
            //Nhap dinh bat dau vieng tham
            int dinhBD = YC2.NhapDinhBatDau();
            //Tao mang danh dau
            bool[] DanhDau = new bool[DataDoThi.n];
            //Khoi tao mang danh dau
            for (int i = 0; i < DataDoThi.n; i++)
            {
                DanhDau[i] = false;
            }
            //Duyet do thi theo chieu sau DFS
            XL_YC.YeuCau2();
            YC2.DFS(dinhBD, DanhDau);
            Console.WriteLine($"c. ");
            var result = XL_YC.Vector();
            if(result == true)
            {
                Console.WriteLine("Do thi vo huong");
            }
            else
            {
                Console.WriteLine("Khong la do thi vo huong");
            }

            var checkTrongso = XL_INPUT.Kiemtra_TrongSo(filename);
            if(checkTrongso == false)
            {
                Console.WriteLine($"Do thi khong co trong so");
            }
            else
            {
                Console.WriteLine($"Do thi co trong so");
            }


        }
    }
}

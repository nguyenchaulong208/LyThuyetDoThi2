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
            bool[] DanhDau = new bool[DataDoThi.n + 1];
            //Khoi tao mang danh dau
            for (int i = 0; i < DataDoThi.n+1; i++)
            {
                DanhDau[i] = false;
            }
            //Duyet do thi theo chieu sau DFS
            YC2.DFS(dinhBD, DanhDau);
            
            
        }
    }
}

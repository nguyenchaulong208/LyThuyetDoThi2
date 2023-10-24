﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    public class YC2
    {
        //Duyet do thi theo chieu sau DFS
        //Nhan dinh bat dau
        public static int NhapDinhBatDau()
        {
            Console.WriteLine("Yeu cau 2:");
            Console.Write("Nhap dinh bat dau: ");
            int dinh = int.Parse(Console.ReadLine());
           foreach (var item in DataDoThi.data_ke)
            {
                if (dinh > DataDoThi.n)
                {
                    Console.WriteLine("Dinh khong ton tai");
                    Console.Write("Nhap lai dinh bat dau: ");
                    dinh = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            return dinh;
        }
        //DFS - dung de quy
        public static void DFS(int dinh, bool[] DanhDau)
        {
            //Danh dau dinh da duyet
            DanhDau[dinh] = true;
            //In ra dinh da duyet
            Console.Write(dinh + " ->");
            //Duyet cac dinh ke cua dinh dang xet
            for (int i = 0; i < DataDoThi.n; i++)
            {
                //Neu dinh ke chua duoc duyet thi duyet dinh ke
                if (DataDoThi.data_ke[dinh, i] == 1 && DanhDau[i] == false)
                {
                    DFS(i, DanhDau);
                }
            }
        }
        public static void YeuCau2()
        {

            Console.WriteLine($"a. Danh sach cac dinh vieng tham theo giai thuat duyet theo chieu sau: ");
        }





    }
}
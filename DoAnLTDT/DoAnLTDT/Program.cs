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
            Lua_Chon_YC();
           
           

        }
        static void Lua_Chon_YC()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Lua chon yeu cau tu 0 toi 6");
            Console.WriteLine("0: The hien tat ca yeu cau:");
            Console.WriteLine("1: Yeu Cau 1: Phan tich Thong tin do thi:");
            Console.WriteLine("2: Yeu Cau 2: Duyet do thi:");
            Console.WriteLine("3: Tim cay khung nho nhat:");
            Console.WriteLine("4: Tim duong di ngan nhat:");
            Console.WriteLine("5: Tim chu trinh hoac duong di Euler:");
            Console.WriteLine("6: Exit");
            int key = -1;
            key = int.Parse(Console.ReadLine());

            while (key < 0 || key > 6)
            {
                Console.WriteLine("Lua chon khong dung");
                Console.WriteLine("Nhap lai lua chon:");
                key = int.Parse(Console.ReadLine());
            }
            if(key==0)
            {
                YC1.Run_YC1();
                YC2.Run_YC2();
                YC3.Run_YC3();
                YC4.Run_YC4();
                YC5.Run_YC5();
                Console.WriteLine();

                Lua_Chon_YC();
            }
            if (key == 1)
            {
                YC1.Run_YC1();
                Console.WriteLine();
                Lua_Chon_YC();


            }
            if (key == 2)
            {
                
                YC2.Run_YC2();
                Console.WriteLine();
                Lua_Chon_YC();
            }
            if (key == 3)
            {
              
                YC3.Run_YC3();
                Console.WriteLine();
                Lua_Chon_YC();
            }
            if (key == 4)
            {
              
                YC4.Run_YC4();
                Console.WriteLine();
                Lua_Chon_YC();
            }
            if (key == 5)
            {
                
                YC5.Run_YC5();
                Console.WriteLine();
                Lua_Chon_YC();

            }
        }
    }
}

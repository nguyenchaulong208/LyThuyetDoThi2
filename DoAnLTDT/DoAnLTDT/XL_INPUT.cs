using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DoAnLTDT
{
    public static class XL_INPUT
    {
        


        //Kiem tra file co ton tai hay khong va doc file
        public static bool KiemTraFile(string filename)
        {

            if (!File.Exists(filename))
            {
                Console.WriteLine("File khong ton tai!!!");
                return false;
            }
            string[] lines = File.ReadAllLines(filename);
            DataDoThi.n = int.Parse(lines[0]);

        // Tạo giá trị ban đầu là 0 cho 2 mảng 2 chiều 
            DATA();

            for (int i = 1; i < DataDoThi.n; i++)
            {
                string t = lines[i] + " ";

                string[] Mang = new string[DataDoThi.n];
                Mang = t.Split(' ');
                int k = Convert.ToInt32(Mang[0]);
                for (int j = 1; j < k; j++)
                {
                    DataDoThi.data[(i - 1), Convert.ToInt32(Mang[2 * (j - 1) + 1])] = Convert.ToInt32(Mang[2 * (j - 1) + 2]);
                    DataDoThi.data_ke[(i - 1), Convert.ToInt32(Mang[2 * (j - 1) + 1])] += 1;

                }


            }
            // test ma tran ke co trong so
            for (int m = 0; m < DataDoThi.n; m++)
            {
                for (int r = 0; r < DataDoThi.n; r++)
                {
                    Console.Write(DataDoThi.data[m, r] + " ");
                }
                Console.WriteLine();

            }


            return true;
        }

        //TẠO DỰNG MẢNG 2 CHIỀU VỚI GIÁ TRỊ LÀ 0
        public static void DATA()
        {
            DataDoThi.data_ke = new int[DataDoThi.n, DataDoThi.n];
            DataDoThi.data = new int[DataDoThi.n, DataDoThi.n];
            for (int i = 0; i < DataDoThi.n; i++)
            {
                for (int j = 0; j < DataDoThi.n; j++)
                {
                    DataDoThi.data[i, j] = 0;
                    DataDoThi.data_ke[i, j] = 0;
                }

            }

        }
      
    }

   
}




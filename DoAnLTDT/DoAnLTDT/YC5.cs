using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    public class YC5
    {
        public static void Run_YC5()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Yeu cau 5: Tim chu trinh hoac do thi Euler");
            //Kiem tra do thi co phai la do thi Euler hay khong
            Console.WriteLine("Kiem tra do thi Euler");
            string ktEuler = KtEuler(DataDoThi.data);
            Console.WriteLine(ktEuler);
        }
        //Nhap dinh bat dau
        public static int NhapDinh()
        {
            Console.Write("Nhap dinh bat dau:");
            int Dinh = int.Parse(Console.ReadLine());
            return Dinh;
        }
        //Kiem tra do thi co phai la do thi Euler hay khong
        public static string KtEuler(int[,] doThi)
        {
            int count = 0;
            string reuslt =string.Empty;
            for(int i = 0; i < DataDoThi.n; i++)
            {
                for(int j = 0; j < DataDoThi.n; j++)
                {
                    if (doThi[i,j] == 1)
                    {
                        count++;
                    }
                }
            }
            if (count % 2 == 0) 
            {
                reuslt = "Do thi Euler";
            }
            else
            {
                reuslt = "Khong phai do thi Euler";
            }
            return reuslt;
        }
        
    }
}

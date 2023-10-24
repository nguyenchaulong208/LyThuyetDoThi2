using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    internal class Duyet_Danh_Sach
    {
        
        public static string DS_DFS;
        public static string DS_BFS;


    }
    public class YC2 
    {
        
        

        //DUYET DO THI
        public static void Run_YC2()
        {
            int Dinh_BD = NhapDinhBatDau();
            Console.WriteLine($"a. Danh sach cac dinh vieng tham theo giai thuat duyet theo chieu sau: ");
            Duyet_DFS(Dinh_BD);


        }
        public static int NhapDinhBatDau()
        {
            Console.WriteLine("YEU CAU 2: DUYET DO THI:");
            Console.Write("Nhap dinh bat dau: ");
            int Dinh_BD = int.Parse(Console.ReadLine());

            while (Dinh_BD < 0 || Dinh_BD>= DataDoThi.n)
            {
                Console.WriteLine("Dinh khong ton tai");
                Console.Write("Nhap lai dinh bat dau: ");
                Dinh_BD = int.Parse(Console.ReadLine());
            }
         
            return Dinh_BD;
        }



        //DFS - DE QUY
        public static void Duyet_DFS(int dinh)
        {

            Boolean[] Visit_Dinh = new Boolean[DataDoThi.n];
            Duyet_Danh_Sach.DS_DFS = $"{dinh}";
            for (int i = 0; i < DataDoThi.n; i++)
            {
                Visit_Dinh[i] = false;
            }
            Visit_Dinh[dinh] = true;
            DFS(Visit_Dinh, dinh);
            Console.WriteLine(Duyet_Danh_Sach.DS_DFS);




        }
       public static Boolean[] DFS(Boolean[] bools, int Dinh)
        {
            if(Check_Dinh_Ke(bools, Dinh)==false)
            {
                return bools;
            }
            for (int i = 0; i < DataDoThi.n; i++)
            {
                if (DataDoThi.data_ke[Dinh, i] != 0 && bools[i] == false)
                {
                    bools[i] = true;
                    Duyet_Danh_Sach.DS_DFS += " " + i;
                    DFS(bools, i);
                 
                }
            }



            return bools;
        }
        public static Boolean Check_Dinh_Ke(Boolean[] bools, int Dinh)
        {
            for(int i = 0;i<DataDoThi.n; i++)
            {
                if (DataDoThi.data_ke[Dinh, i] != 0 && bools[i] == false)
                {
                    return true;
                }
            }
            return false;
        }
        public static Boolean Check_Visit(Boolean[] Visit_Dinh)
        {
            
            for(int i=0;i<DataDoThi.n;i++)
            {
                if (Visit_Dinh[i] == false)
                {
                    return false;
                }
            }
            return true;

        }
     

    }
}

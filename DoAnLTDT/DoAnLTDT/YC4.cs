using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    internal class Dijkstra_Data
    {

        public static Boolean[] DS_Dinh = new Boolean[DataDoThi.n];
        public static int[] Trong_So = new int[DataDoThi.n];
        public static int[] Dinh_Lien_Truoc = new int[DataDoThi.n];


    }
    public class YC4
    {
        public static void Run_YC4()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Yeu cau 4: Tim duong di ngan nhat:");
            Console.WriteLine("a.Giai thuat Dijkstra:");

            if (DT_Trong_So_Duong() == true)
            {
                int Dinh_BD = YC2.NhapDinhBatDau();
                Dijkstra(Dinh_BD);
            }
            else
            {
                Console.WriteLine("Do thi co trong so am");
            }
            Console.WriteLine("b. Giai thuat Ford-Bellman");

        }
        public static Boolean DT_Trong_So_Duong()
        {
            Boolean KiemTra = true;
            for (int i = 0; i < DataDoThi.n; i++)
            {
                for (int j = 0; j < DataDoThi.n; j++)
                {
                    if (DataDoThi.data[i, j] < 0)
                    {
                        KiemTra = false;
                    }
                }
            }
           
            return KiemTra;
        }

        public static void Dijkstra(int Dinh_BD)
        {

            Dijkstra_Data.DS_Dinh = Khoi_Tao_Gia_Tri_DS(Dijkstra_Data.DS_Dinh, Dinh_BD);
            Dijkstra_Data.Trong_So = Khoi_Tao_Trong_So(Dijkstra_Data.Trong_So);
            Dijkstra_Data.Dinh_Lien_Truoc = Khoi_Tao_Dinh_LTruoc(Dijkstra_Data.Dinh_Lien_Truoc);
            Dijkstra_Data.Trong_So[Dinh_BD] = 0;
            Dijkstra_Data.Dinh_Lien_Truoc[Dinh_BD] = Dinh_BD;
            int Dem_Dung_While = 0;
            while (Check_Dung(Dijkstra_Data.DS_Dinh) == false)
            {
                    Dem_Dung_While++;
                    int Dinh_TS_Min = Check_Min_Trong_So();
                
                    Dijkstra_Data.DS_Dinh[Dinh_TS_Min] = false;
                    Update_Dinh_Ke(Dinh_TS_Min);

                   

            }
            MinMap_Dinh(Dinh_BD);

            ////check
            //for (int i = 0; i < DataDoThi.n; i++)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();

            //for (int i = 0; i < DataDoThi.n; i++)
            //{
            //    Console.Write(Dijkstra_Data.Trong_So[i] + " ");
            //}
            //Console.WriteLine();

            //for (int i = 0; i < DataDoThi.n; i++)
            //{
            //    Console.Write(Dijkstra_Data.Dinh_Lien_Truoc[i] + " ");
            //}
            //Console.WriteLine();



        }
      
        public static void Update_Dinh_Ke(int Dinh)
        {
            for (int i = 0; i < DataDoThi.n; i++)
            {

                if (DataDoThi.data[Dinh, i] != 0 && Dijkstra_Data.Dinh_Lien_Truoc[i] == -1 && Dijkstra_Data.DS_Dinh[i] == true )
                {
                    Dijkstra_Data.Dinh_Lien_Truoc[i] = Dinh;
                    Dijkstra_Data.Trong_So[i] = DataDoThi.data[Dinh, i]+ Dijkstra_Data.Trong_So[Dijkstra_Data.Dinh_Lien_Truoc[i]];
                   

                }

                if (DataDoThi.data[Dinh, i] != 0 && Dijkstra_Data.Dinh_Lien_Truoc[i] != -1)
                {
                    if (Dijkstra_Data.Trong_So[i] > Dijkstra_Data.Trong_So[Dijkstra_Data.Dinh_Lien_Truoc[i]] + DataDoThi.data[Dinh, i])
                    {
                        Dijkstra_Data.Trong_So[i] = Dijkstra_Data.Trong_So[Dijkstra_Data.Dinh_Lien_Truoc[i]] + DataDoThi.data[Dinh, i];
                        Dijkstra_Data.Dinh_Lien_Truoc[i] = Dinh;
                    }
                }
            }

        }
        public static void MinMap_Dinh(int Dinh_BD)
        {
            for(int i = 0;i<DataDoThi.n;i++)
            {
                Console.WriteLine($"Duong di ngan nhat toi {i}");
                
                int Dinh_Lien_Truoc = Dijkstra_Data.Dinh_Lien_Truoc[i];
                if(i!= Dinh_BD && Dinh_Lien_Truoc != -1)
                {
                    Console.Write("Cost= " + Dijkstra_Data.Trong_So[i] + "   Path=" + i);
                    while (Dinh_BD != Dinh_Lien_Truoc && Dinh_Lien_Truoc !=-1)
                    {

                        Console.Write($"<-{Dinh_Lien_Truoc}");
                        Dinh_Lien_Truoc = Dijkstra_Data.Dinh_Lien_Truoc[Dinh_Lien_Truoc];
                    }
                    Console.WriteLine($"<-{Dinh_BD}");
                }
               
                if(Dinh_Lien_Truoc==-1)
                {
                    Console.WriteLine("Khong co duong di");
                }
                
            }
        }
        public static int Check_Min_Trong_So()
        {
            int Min_TS = int.MaxValue;
            int Dinh_Min = -1;
            for(int i = 0;i< DataDoThi.n;i++)
            {
                if (Dijkstra_Data.Trong_So[i]<Min_TS && Dijkstra_Data.DS_Dinh[i]==true)
                {
                    Dinh_Min = i;
                    Min_TS = Dijkstra_Data.Trong_So[i];
                }
            }
            return Dinh_Min;
        }
        public static Boolean Check_Dung(Boolean[] DS_Dinh)
        {
            for(int i = 0;i<DataDoThi.n;i++)
            {
                if (DS_Dinh[i]==true)
                { return false; }
            }
            return true;
        }
        public static Boolean[] Khoi_Tao_Gia_Tri_DS(Boolean[] DS_Dinh,int Dinh_BD)
        {
           return YC2.DFS(DS_Dinh, Dinh_BD);
         
        }
        public static int[] Khoi_Tao_Trong_So(int[] Trong_So)
        {
            for (int i=0;i<DataDoThi.n; i++)
            {
                Trong_So[i] = int.MaxValue;
            }
            return Trong_So;
        }
        public static int[] Khoi_Tao_Dinh_LTruoc(int[] Dinh_Lien_Truoc)
        {
            for(int i=0;i<DataDoThi.n;i++)
            {

                Dinh_Lien_Truoc[i] = -1;
            }
            return Dinh_Lien_Truoc;
        }
    }
}


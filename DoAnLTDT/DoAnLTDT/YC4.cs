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
    internal class Bellman_Ford_Data
    {
        public static int[] Prev = new int[DataDoThi.n];
        public static int[,] Cost = new int[DataDoThi.n, DataDoThi.n];
        public static int  Step;
        
    }
    public class YC4
    {
        public static void Run_YC4()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Yeu cau 4: Tim duong di ngan nhat:");
            Console.WriteLine("a.Giai thuat Dijkstra:");
            int Dinh_BD = YC2.NhapDinhBatDau();

            if (DT_Trong_So_Duong() == true)
            {
                Dijkstra(Dinh_BD);
            }
            else
            {
                Console.WriteLine("Do thi co trong so am");
            }

            Console.WriteLine("b. Giai thuat Ford-Bellman");
            Bellman_Ford(Dinh_BD);

        }
        // Dijkstra_Data
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
            for (int i = 0; i < Dinh_BD; i++)
            {
                Console.WriteLine(Dijkstra_Data.DS_Dinh + " ");
            }
            while (Check_Dung(Dijkstra_Data.DS_Dinh) == false)
            {
                    Dem_Dung_While++;
                    int Dinh_TS_Min = Check_Min_Trong_So();
                
                    Dijkstra_Data.DS_Dinh[Dinh_TS_Min] = false;
                    Update_Dinh_Ke(Dinh_TS_Min);                 

            }
           
            MinMap_Dinh(Dinh_BD);

        }
        public static void Update_Dinh_Ke(int Dinh)
        {
            for (int i = 0; i < DataDoThi.n; i++)
            {

                if(DataDoThi.data[Dinh, i] != 0 && Dijkstra_Data.DS_Dinh[i] == true)
                {
                    if(Dijkstra_Data.Dinh_Lien_Truoc[i] == -1)
                    {
                        Dijkstra_Data.Dinh_Lien_Truoc[i] = Dinh;
                        Dijkstra_Data.Trong_So[i] = DataDoThi.data[Dinh, i] + Dijkstra_Data.Trong_So[Dinh];
                    }    
                    else
                    {
                        if (Dijkstra_Data.Trong_So[i] > DataDoThi.data[Dinh, i] + Dijkstra_Data.Trong_So[Dinh])
                        {
                            Dijkstra_Data.Dinh_Lien_Truoc[i] = Dinh;
                            Dijkstra_Data.Trong_So[i] = DataDoThi.data[Dinh, i] + Dijkstra_Data.Trong_So[Dinh];
                        }
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
                if(i == Dinh_BD)
                {
                    Console.WriteLine($"Cost= {Dijkstra_Data.Trong_So[i]}     Path= {i}");
                }

                    if (Dinh_Lien_Truoc==-1)
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
            if(Dinh_Min==-1)
            {
                Dinh_Min = 0;
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

        //Bellman_Ford
        public static void Bellman_Ford(int Dinh_BD)
        {
            Tao_Bellman_Ford_Data(Dinh_BD);


          

            while (Bellman_Ford_Data.Step<DataDoThi.n)
            {
               
                for (int i=0;i<DataDoThi.n;i++)
                {
                    if(Bellman_Ford_Data.Cost[Bellman_Ford_Data.Step-1, i]!=int.MaxValue)
                    {
                        Update_Dinh_Step(i);
                    }
                }

              
               
                Bellman_Ford_Data.Step++;

            }

            Console.WriteLine($"Source: {Dinh_BD}");
            if(Check_Mach_Am()==true)
            {
                Console.WriteLine("Do thi co mach am");
            }
            In_Bellman_Ford_Data(Dinh_BD);



        }
        public static void In_Bellman_Ford_Data(int Dinh_BD)
        {
            for(int i=0;i<DataDoThi.n;i++)
            {
                Console.WriteLine($"Duong di ngan nhat tu {Dinh_BD} den {i}");
                Console.Write($"Cost = {Bellman_Ford_Data.Cost[DataDoThi.n - 1, i]}     Path ={i}");
                int Xe_Do_Duong = Bellman_Ford_Data.Prev[i];
                while (Xe_Do_Duong!= Dinh_BD)
                {
                    Console.Write($" <- {Xe_Do_Duong}");
                    Xe_Do_Duong= Bellman_Ford_Data.Prev[Xe_Do_Duong];
                    if(i== Bellman_Ford_Data.Prev[i])
                    {
                        break;
                    }
                }
                if(i== Dinh_BD)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($" <- {Dinh_BD}");
                }

            }


        }
        public static Boolean Check_Mach_Am()
        {
           
            for(int i=0;i<DataDoThi.n;i++)
            {
                if (Bellman_Ford_Data.Cost[DataDoThi.n-1,i]!= Bellman_Ford_Data.Cost[DataDoThi.n - 2, i])
                {
                    
                    return true;
                }
            }
            return false;
        }
        public static void Update_Dinh_Step(int Dinh)
        {
            for (int i = 0; i < DataDoThi.n; i++)
            {
                if (DataDoThi.data[Dinh, i] != 0)
                {
                    if(Bellman_Ford_Data.Cost[Bellman_Ford_Data.Step-1, Dinh]+ DataDoThi.data[Dinh, i]< Bellman_Ford_Data.Cost[Bellman_Ford_Data.Step,i ])
                    {
                        Bellman_Ford_Data.Cost[Bellman_Ford_Data.Step, i] = Bellman_Ford_Data.Cost[Bellman_Ford_Data.Step - 1, Dinh] + DataDoThi.data[Dinh, i];
                        Bellman_Ford_Data.Prev[i] = Dinh;
                      
                    }                

                }
            }
           
        }
      
        public static void Tao_Bellman_Ford_Data(int Dinh_BD)
        {
            for(int i=0; i < DataDoThi.n; i++)
            {
                for(int j=0;j<DataDoThi.n; j++)
                {
                    if (i == Dinh_BD)
                    {
                        Bellman_Ford_Data.Cost[j, i] = 0;
                    }
                    else
                    {
                        Bellman_Ford_Data.Cost[j, i] = int.MaxValue;
                    }
                }
               
                Bellman_Ford_Data.Prev[i] = i;
                Bellman_Ford_Data.Step = 1;
               
            }
        }
    }
}


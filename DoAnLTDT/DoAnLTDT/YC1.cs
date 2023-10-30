using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    public class YC1
    {
        
        //YÊU CẦU 1: PHÂN TÍCH THÔNG TIN ĐỒ THỊ
        public static void Run_YC1()
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("YEU CAU 1: PHAN TICH THONG TIN DO THI:");
                Console.WriteLine("a. Ma tran ke cua do thi:");
                Ma_tran_ke();


                Console.WriteLine("b. xac dinh tinh co huong cua do thi:");

                if (Vector() == true)
                {
                    Console.WriteLine("La do thi vo huong");
                }
                else
                {
                    Console.WriteLine("La do thi co  huong");
                }

                Console.WriteLine($"c. So dinh cua do thi {DataDoThi.n} ");
                Console.WriteLine($"d. So canh cua do thi {Socanh_DT()}");
                Dem_Boi_Khuyen();
                Dinh_T_CL();
                Bac_tung_dinh();



            }
          
        // TÍNH SỐ CẠNH ĐỒ THỊ
        public static int Socanh_DT()
        {
            int KQ = 0;

            int dem = 0;

            if (Vector() == true)
            {
                for (int i = 0; i < DataDoThi.n; i++)
                {
                    for (int j = dem; j < DataDoThi.n; j++)
                    {
                        KQ += DataDoThi.data_ke[i, j];
                    }
                    dem += 1;
                }
                return KQ;
            }
            else
            {
                for (int i = 0; i < DataDoThi.n; i++)
                {
                    for (int j = 0; j < DataDoThi.n; j++)
                    {
                        KQ += DataDoThi.data_ke[i, j];
                    }
                }
                return KQ;
            }
        }

        // DEM CANH BOI VA KHUYEN
        public static void Dem_Boi_Khuyen()
        {
            int[] KQ = new int[2];
            KQ[0] = 0;
            KQ[1] = 0;
            int dem = 0;

            if (Vector() == true)
            {
                for (int i = 0; i < DataDoThi.n; i++)
                {
                    for (int j = dem; j < DataDoThi.n; j++)
                    {
                        if (DataDoThi.data_ke[i, j] == 2)
                        {
                            KQ[0] += 1;
                        }
                        if (DataDoThi.data_ke[i, j] != 0 && i == j)
                        {
                            KQ[1] += DataDoThi.data_ke[i, j];
                        }
                    }
                    dem += 1;
                }

                Console.WriteLine($"e. So luong cap dinh xuat hien canh boi: {KQ[0]}");
                Console.WriteLine($"   So luong cap dinh xuat hien canh khuyen: {KQ[1]}");

            }

            else
            {
                for (int i = 0; i < DataDoThi.n; i++)
                {
                    for (int j = 0; j < DataDoThi.n; j++)
                    {
                        if (DataDoThi.data_ke[i, j] == 2)
                        {
                            KQ[0] += 1;
                        }
                        if (DataDoThi.data_ke[i, j] != 0 && i == j)
                        {
                            KQ[1] += DataDoThi.data_ke[i, j];
                        }
                    }
                }
                Console.WriteLine($"e. So luong cap dinh xuat hien canh boi: {KQ[0]}");
                Console.WriteLine($"   So luong cap dinh xuat hien canh khuyen: {KQ[1]}");
            }

        }

        // BAC CUA DINH
        public static int[,] Bac_Dinh()
        {
            int[,] kq = new int[2, DataDoThi.n];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < DataDoThi.n; j++)
                {
                    kq[i, j] = 0;
                }
            }
            if (Vector() == true)
            {
                for (int i = 0; i < DataDoThi.n; i++)
                {
                    for (int j = 0; j < DataDoThi.n; j++)
                    {
                        if (i == j)
                        {
                            kq[0, i] += 2 * DataDoThi.data_ke[i, j];
                        }
                        else
                        {
                            kq[0, i] += DataDoThi.data_ke[i, j];

                        }

                    }

                }
                return kq;
            }
            else
            {
                for (int i = 0; i < DataDoThi.n; i++)
                {
                    for (int j = 0; j < DataDoThi.n; j++)
                    {
                        if (DataDoThi.data_ke[i, j] != 0)
                        {
                            kq[0, i] += DataDoThi.data_ke[i, j];
                            kq[1, j] += DataDoThi.data_ke[i, j];
                        }
                    }
                }
                return kq;
            }


        }

        //DINH TREO DINH CO LAP
        public static void Dinh_T_CL()
        {
            int dinh_treo = 0, dinh_co_lap = 0;
            int[,] BacDinh = Bac_Dinh();
            for (int i = 0; i < DataDoThi.n; i++)
            {
                if (BacDinh[0, i] + BacDinh[1, i] == 1)
                {
                    dinh_treo += 1;
                }

                if (BacDinh[0, i] + BacDinh[1, i] == 0)
                {
                    dinh_co_lap += 1;
                }
            }
            Console.WriteLine("So dinh treo " + dinh_treo);
            Console.WriteLine("So dinh co lap " + dinh_co_lap);
        }

        // BAC TUNG DINH
        public static void Bac_tung_dinh()
        {
            int[,] BacDinh = Bac_Dinh();
            if (Vector() == true)
            {
                Console.WriteLine("Bac tung dinh la ");
                for (int i = 0; i < DataDoThi.n; i++)
                {
                    Console.Write(i + " " + $"({BacDinh[0, i] + BacDinh[1, i]}) ");

                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("(Bac vao - Bac ra)  tung dinh la ");
                for (int i = 0; i < DataDoThi.n; i++)
                {
                    Console.Write(i + " " + $"({BacDinh[0, i]} - {BacDinh[1, i]}) ");

                }
                Console.WriteLine();
            }

        }

        // MA TRAN KE
        public static void Ma_tran_ke()
        {

            for (int m = 0; m < DataDoThi.n; m++)
            {
                for (int r = 0; r < DataDoThi.n; r++)
                {
                    Console.Write(DataDoThi.data_ke[m, r] + " ");
                }
                Console.WriteLine();

            }


        }

        // DO THI VO HUONG ?
        public static Boolean Vector()
        {


            for (int i = 0; i < DataDoThi.n; i++)
            {
                for (int j = 1; j < DataDoThi.n; j++)
                {
                    if (DataDoThi.data_ke[i, j] != DataDoThi.data_ke[j, i])
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        
    }

}


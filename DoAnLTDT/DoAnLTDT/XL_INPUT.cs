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
        //// n la so dinh
        //public static int n;
        //// ma tran danh sach ke co trong so
        //public static int[,] data;
        //// ma tran lien ke
        //public static int[,] data_ke;


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

            for (int i = 1; i <= DataDoThi.n + 1; i++)
            {
                string t = lines[i] + " ";

                string[] Mang = new string[DataDoThi.n + 1];
                Mang = t.Split(' ');
                int k = Convert.ToInt32(Mang[0]);
                for (int j = 1; j <= k; j++)
                {
                    DataDoThi.data[(i - 1), Convert.ToInt32(Mang[2 * (j - 1) + 1])] = Convert.ToInt32(Mang[2 * (j - 1) + 2]);
                    DataDoThi.data_ke[(i - 1), Convert.ToInt32(Mang[2 * (j - 1) + 1])] += 1;

                }


            }
            // test ma tran ke co trong so
            //for (int m = 0; m <= n; m++)
            //{
            //    for (int r = 0; r <= n; r++)
            //    {
            //        Console.Write(data[m, r] + " ");
            //    }
            //    Console.WriteLine();

            //}


            return true;
        }

        //TẠO DỰNG MẢNG 2 CHIỀU VỚI GIÁ TRỊ LÀ 0
        public static void DATA()
        {
            DataDoThi.data_ke = new int[DataDoThi.n + 1, DataDoThi.n + 1];
            DataDoThi.data = new int[DataDoThi.n + 1, DataDoThi.n + 1];
            for (int i = 0; i <= DataDoThi.n; i++)
            {
                for (int j = 0; j <= DataDoThi.n; j++)
                {
                    DataDoThi.data[i, j] = 0;
                    DataDoThi.data_ke[i, j] = 0;
                }

            }

        }
        // Doc Dinh
        //public static int Doc_So_Dinh()
        //{
        //    return n;
        //}
        // Doc Mang
        //public static int[,] Doc_Mang()
        //{
        //    return data;
        //}

        // So canh
        public static int Socanh_DT()
        {
            int KQ=0 ;
            
            int dem = 0;

            if (Vector() == true)
            {
                for (int i = 0; i <= DataDoThi.n; i++)
                {
                    for (int j = dem; j <= DataDoThi.n; j++)
                    {
                        KQ += DataDoThi.data_ke[i, j];
                    }
                    dem += 1;
                }
                return KQ;
            }
            else
            {
                for (int i = 0; i <= DataDoThi.n; i++)
                {
                    for (int j = 0; j <= DataDoThi.n; j++)
                    {
                        KQ += DataDoThi.data_ke[i, j];
                    }
                }
                return KQ;
            }
        }
        // dem canh boi va khuyen
        public static void Dem_Boi_Khuyen()
        {
            int[] KQ = new int[2];
            KQ[0] = 0;
            KQ[1] = 0;
            int dem = 0;
            
            if (Vector() == true)
            {
                for (int i = 0; i <= DataDoThi.n; i++)
                {
                    for (int j = dem; j <= DataDoThi.n; j++)
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
                for (int i = 0; i <= DataDoThi.n; i++)
                {
                    for (int j = 0; j <= DataDoThi.n; j++)
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
<<<<<<< HEAD
            int[,] kq = new int[2, n + 1];
            
=======
            int[,] KQ = new int[2, DataDoThi.n + 1];
>>>>>>> f5b4c8f1521e1c1b31c748b0a27f9864647a1303
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < DataDoThi.n + 1; j++)
                {
                    kq[i, j] = 0;
                }
            }
<<<<<<< HEAD
            if (Vector() == true)
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= n; j++)
=======

            for (int i = 0; i <= DataDoThi.n; i++)
            {
                for (int j = 0; j <= DataDoThi.n; j++)
                {
                    if (DataDoThi.data[i, j] != 0 && i != j)
>>>>>>> f5b4c8f1521e1c1b31c748b0a27f9864647a1303
                    {
                        if(i==j)
                        {
                            kq[0, i] += 2*data_ke[i, j];
                        }
                        else
                        {
                            kq[0, i] += data_ke[i,j];

                        }
                        
                    }
<<<<<<< HEAD
                 
                }
                return kq;
            }
            else
            {
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= n; j++)
=======
                    if (DataDoThi.data[i, j] != 0 && i == j)
>>>>>>> f5b4c8f1521e1c1b31c748b0a27f9864647a1303
                    {
                        if (data_ke[i,j] != 0)
                        {
                            kq[0,i] += data_ke[i,j];
                            kq[1,j] += data_ke[i,j];
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
            for(int i=0; i<=n; i++)
            {
                if (BacDinh[0, i] + BacDinh[1,i]==1)
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
            if(Vector()==true)
            {
                Console.WriteLine("Bac tung dinh la " );
                for (int i = 0; i <= n; i++)
                {
                    Console.Write(i+" " + $"({BacDinh[0,i]+ BacDinh[1, i]}) ");

                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("(Bac vao - Bac ra)  tung dinh la ");
                for (int i = 0; i <= n; i++)
                {
                    Console.Write(i + " " + $"({BacDinh[0, i]} - {BacDinh[1, i]}) ");

                }
                Console.WriteLine();
            }
            
        }

        // MA TRAN KE
        public static void Ma_tran_ke()
        {

            for (int m = 0; m <= DataDoThi.n; m++)
            {
                for (int r = 0; r <= DataDoThi.n; r++)
                {
                    Console.Write(DataDoThi.data_ke[m, r] + " ");
                }
                Console.WriteLine();

            }


        }


        // DO THI VO HUONG ?
        public static Boolean Vector()
        {


            for (int i = 0; i <= DataDoThi.n; i++)
            {
                for (int j = 1; j <= DataDoThi.n; j++)
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

    class XL_YC_DA
    {
        //YÊU CẦU 1: PHÂN TÍCH THÔNG TIN ĐỒ THỊ
        public static void YC1()
        {
            Console.WriteLine("YEU CAU 1: PHAN TICH THONG TIN DO THI:");
            Console.WriteLine("a. Ma tran ke cua do thi:\n");
            XL_INPUT.Ma_tran_ke();


            Console.WriteLine("b. xac dinh tinh co huong cua do thi:");

            if (XL_INPUT.Vector() == true)
            {
                Console.WriteLine("La do thi vo huong");
            }
            else
            {
                Console.WriteLine("La do thi co  huong");
            }

            Console.WriteLine($"c. So dinh cua do thi {DataDoThi.n + 1} ");
            var soCanh = XL_INPUT.Socanh_DT();
            Console.WriteLine($"d. So canh cua do thi {soCanh}");
            XL_INPUT.Dem_Boi_Khuyen();
            XL_INPUT.Dinh_T_CL();
            XL_INPUT.Bac_tung_dinh();



        }
    }
}





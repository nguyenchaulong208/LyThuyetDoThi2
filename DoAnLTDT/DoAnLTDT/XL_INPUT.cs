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
        // n la so dinh
        public static int n;
        // ma tran danh sach ke co trong so
        public static int[,] data;
        // ma tran lien ke
        public static int[,] data_ke;

       
        //Kiem tra file co ton tai hay khong va doc file
        public static bool KiemTraFile(string filename)
        {

            if (!File.Exists(filename))
            {
                Console.WriteLine("File khong ton tai!!!");
                return false;
            }
            string[] lines = File.ReadAllLines(filename);
            n = int.Parse(lines[0]);
           

            DATA();

            for (int i = 1; i <= n; i++)
            {
                string t = lines[i] + " ";
               
                string[] Mang = new string[n + 1];
                Mang = t.Split(' ');
                int k = Convert.ToInt32(Mang[0]);
                for (int j = 1; j <= k; j++)
                {
                    data[(i - 1), Convert.ToInt32(Mang[2 * (j - 1) + 1])] = Convert.ToInt32(Mang[2 * (j - 1) + 2]);
                    data_ke[(i - 1), Convert.ToInt32(Mang[2 * (j - 1) + 1])] += 1;

                }


            }
            // test ma tran ke co trong so
            for (int m = 0; m <= n; m++)
            {
                for (int r = 0; r <= n; r++)
                {
                    Console.Write(data[m, r] + " ");
                }
                Console.WriteLine();
                
            }
          

            return true;
        }

        //TẠO DỰNG MẢNG 2 CHIỀU VỚI GIÁ TRỊ LÀ 0
        public static void DATA()
        {
            data_ke = new int[n + 1, n + 1];
            data = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    data[i, j] = 0;
                    data_ke[i, j] = 0;
                }
             
            }

        }
        // Doc Dinh
        public static int Doc_So_Dinh()
        {
            return n;
        }
        // Doc Mang
        public static int[,] Doc_Mang()
        {
            return data;
        }

        // So canh
        public static int Socanh_DT()
        {
            int dem = 0;
            for(int i = 0;i<=n;i++)
            {
                for(int j=0; j<=n;j++)
                {
                    if (data_ke[i,j]!=0)
                    {
                        dem += data_ke[i, j];
                    }
                }
            }
            if(Vector()==true)
            {
                return dem / 2;

            }
            else
            {
                return dem;
            }
        }
        // dem canh boi va khuyen
        public static void Dem_Boi_Khuyen()
        {
            int[] KQ = new int[2];
            KQ[0] = 0;
            KQ[1] = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {   
                    if (data_ke[i,j]==2)
                    {
                        KQ[0] += 1;
                    }
                    if (data_ke[i,j]!=0 && i==j)
                    {
                        KQ[1] += data_ke[i, j];
                    }
                }
            }
            if (Vector() == true)
            {
                KQ[0] /= 2;
                Console.WriteLine($"e. So luong cap dinh xuat hien canh boi: {KQ[0]}");
                Console.WriteLine($"   So luong cap dinh xuat hien canh khuyen: {KQ[1]}");

            }
            else
            {
                Console.WriteLine($"e. So luong cap dinh xuat hien canh boi: {KQ[0]}");
                Console.WriteLine($"   So luong cap dinh xuat hien canh khuyen: {KQ[1]}");
            }

        }

       // BAC CUA DINH
        public static int[,] Bac_Dinh()
        {
            int[,] KQ = new int[2, n + 1];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    KQ[i, j] = 0;
                }
            }

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (data[i, j] != 0 && i != j)
                    {
                        KQ[0, i] += 1;
                        KQ[1, j] += 1;
                    }
                    if (data[i, j] != 0 && i == j)
                    {
                        KQ[0, i] += 1;
                        KQ[1, j] += 1;

                    }

                }
            }
            return KQ;
        }
        // MA TRAN KE
        public static void Ma_tran_ke()
        {
          
            for (int m = 0; m <= n; m++)
            {
                for (int r = 0; r <= n; r++)
                {
                    Console.Write(data_ke[m, r] + " ");
                }
                Console.WriteLine();

            }


        }


        // DO THI VO HUONG ?
        public static Boolean Vector()
        {
            
       
            for(int i=0;i<=n;i++)
            {
                for(int j=1;j<=n;j++)
                {
                    if (data_ke[i,j] != data_ke[j,i])
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
            Console.WriteLine("a. Ma tran ke cua do thi:");
            XL_INPUT.Ma_tran_ke();


            Console.WriteLine("b. xac dinh tinh co huong cua do thi:");
          
            if(XL_INPUT.Vector()==true)
            {
                Console.WriteLine("La do thi vo huong");
            }
            else 
            { 
                Console.WriteLine("La do thi co  huong");
            }

            Console.WriteLine($"c. So dinh cua do thi {XL_INPUT.Doc_So_Dinh()+1} ");
            Console.WriteLine($"d. So canh cua do thi {XL_INPUT.Socanh_DT()}");
            XL_INPUT.Dem_Boi_Khuyen();



        }
    }
}

        



using DoAnLTDT;
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
            string result = KtEuler(DataDoThi.data_ke);
            Console.WriteLine(result);
            Console.WriteLine("----");
            //xuat Danhsachcanh
            Console.WriteLine("Danh sach cac canh trong do thi");
            DtEuler[] dsCanh = DanhSachCanh(DataDoThi.data_ke);
            for (int i = 0; i < dsCanh.Length; i++)
            {
                Console.WriteLine("Canh thu {0}: ({1},{2})", i + 1, dsCanh[i]._dinhBdauE, dsCanh[i]._dinhKthucE);
            }
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

            int[] arr = new int[DataDoThi.n];
            string reuslt = string.Empty;
            for (int i = 0; i < DataDoThi.n; i++)
            {
                int count = 0;

                for (int j = 0; j < DataDoThi.n; j++)
                {


                    if (doThi[i, j] == 1)
                    {
                        count++;

                    }

                }
                arr[i] = count;

            }

            //Kiem tra do thi euler
            int dem = 0; int demLe = 1;
            for (int i = 0; i < DataDoThi.n; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    dem++;
                }
                else
                {
                    demLe++;
                }
            }
            if(dem ==DataDoThi.n)
            {
                reuslt = "Do thi Euler";
                
            }
            else if (demLe <= 2)
            {
                reuslt = "Do thi nua Euler";
            }
            else
            {
                reuslt = "Do thi khong phai la do thi Euler";
            }

            return reuslt;
        }
        //Tao mang chua danh sach cac canh trong do thi
        public static DtEuler[] DanhSachCanh(int[,] doThi)
        {
            DtEuler[] dsCanh = new DtEuler[DataDoThi.n * DataDoThi.n - 1];
            int count = 0;

            for (int i = 0; i < DataDoThi.n; i++)
            {
                for (int j = 0; j < DataDoThi.n; j++)
                {
                    if (DataDoThi.data_ke[i, j] != 0)
                    {
                        dsCanh[count] = new DtEuler();
                        dsCanh[count]._dinhBdauE = i;
                        dsCanh[count]._dinhKthucE = j;
                        count++;
                    }
                }
            }



            int countNotNull = 0;
            for (int i = 0; i < count; i++)
            {
                if (dsCanh[i] != null)
                {
                    countNotNull++;
                }
            }

            DtEuler[] NewDsCanh = new DtEuler[countNotNull];
            int count1 = 0;
            for (int i = 0; i < count; i++)
            {
                if (dsCanh[i] != null)
                {
                    NewDsCanh[count1] = dsCanh[i];
                    count1++;
                }
            }

            return NewDsCanh;
        }


        //Kiem tra tinh chu trinh trong do thi tai 1 dinh bat ky
        public static bool KtChuTrinh(int dinh)
        {
            DtEuler[] dsCanh = DanhSachCanh(DataDoThi.data_ke);
            //Kiem tra chu trinh tai dinh trong dsCanh
            //Tao nhan danh dau cac dinh
            return true;
        }


        //dUYET DO THI EULER
        public static void DuyetEuler(int[,] doThi)
        {

        }


    }
}


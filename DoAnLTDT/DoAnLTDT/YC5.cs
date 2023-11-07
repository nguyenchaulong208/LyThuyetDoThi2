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
            int Dinh_BD = YC2.NhapDinhBatDau();
            Kiem_Tra_Tinh_Chat_DT( Dinh_BD);


        }
        /*Note
         * Cac ham su dung trong YC5:
         * Kiem_Tra_Tinh_Chat_DT(int Dinh_BD) và KT_Don_Do_Thi(): dung de kiem tra xem co phai la don do thi hay khong
         * KtEuler(int[,] doThi): dung de kiem tra do thi co phai la do thi Euler hay khong
         * ---
         * Mang_Canh(int[,] doThi): tao danh sach luu cac canh cua do thi
         * KtChuTrinh(DtEuler idx, int[] dsNhan): kiem tra xem co tao chu trinh hay khong
         * Euler(int[,] doThi): tim chu trinh hoac duong đi Euler
         */

        // YC 5a
        public static void Kiem_Tra_Tinh_Chat_DT(int Dinh_BD)
        {
            if (KT_Don_Do_Thi() == true)
            {
                Console.WriteLine(KtEuler(DataDoThi.data_ke));
            }
            else
            {
                Console.WriteLine("Khong phai don do thi");
            }

        }

        // XET DON DO THI
        public static Boolean KT_Don_Do_Thi()
        {


            int[] KQ = new int[2];
            KQ[0] = 0;
            KQ[1] = 0;
            int dem = 0;

            if (YC1.Vector() == true)
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

            }
            if (KQ[0] == 0 && KQ[1] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }


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
            if (dem == DataDoThi.n)
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
       
        #region //Thuat toan tim chu trinh hoac do thi Euler
        //Thuat toan tim chu trinh hoac do thi Euler
        //Tao mang luu cac canh cua do thi
        public static DtEuler[] Mang_Canh(int[,] doThi)
        {
            int count = 0;
            DtEuler[] dsCanh = new DtEuler[DataDoThi.n * (DataDoThi.n - 1)];
            for (int i = 0; i < DataDoThi.n; i++)
            {
                for (int j = 0; j < DataDoThi.n; j++)
                {
                    if (doThi[i, j] != 0)
                    {
                        dsCanh[count] = new DtEuler();
                        dsCanh[count]._dinhBdauE = i;
                        dsCanh[count]._dinhKthucE = j;
                        count++;
                    }
                }
            }

            // Loại bỏ các cạnh null
            List<DtEuler> nonNullEdges = new List<DtEuler>();
            for (int i = 0; i < dsCanh.Length; i++)
            {
                if (dsCanh[i] != null)
                {
                    nonNullEdges.Add(dsCanh[i]);
                }
            }

            // Chuyển danh sách cạnh không null thành mảng và trả về
            return nonNullEdges.ToArray();
        }
        public static bool KtChuTrinh(DtEuler idx, int[] dsNhan)
        {
            int nhanBdau = dsNhan[idx._dinhBdauE];
            int nhanKthuc = dsNhan[idx._dinhKthucE];

            if (nhanBdau == nhanKthuc)
                return true; // Nếu cả hai đỉnh của cạnh đã thuộc cùng một nhóm, tức là sẽ tạo chu trình

            int nhanNhoNhat = Math.Min(nhanBdau, nhanKthuc);
            int nhanLonNhat = Math.Max(nhanBdau, nhanKthuc);

            for (int i = 0; i < dsNhan.Length; i++)
            {
                if (dsNhan[i] == nhanLonNhat)
                    dsNhan[i] = nhanNhoNhat; // Gán nhãn nhỏ hơn cho tất cả các đỉnh có nhãn lớn hơn
            }

            return false; // Không tạo chu trình
        }
        //Thuat toan tim chu trinh hoac do thi Euler
        public static void Euler(int[,] doThi)
        {
            //int canh = 0;
            //Tao danh sach luu cac canh
            List<DtEuler> dsCanh = new List<DtEuler>();
            dsCanh = Mang_Canh(doThi).ToList();
            //tao danh sach luu cac canh cua chu trinh hoac do thi Euler
            List<DtEuler> dsCanhEuler = new List<DtEuler>();
            //Tim chu trinh hoac do thi Euler
            int[] dsNhan = new int[DataDoThi.n];
            for (int i = 0; i < dsNhan.Length; i++)
            {
                dsNhan[i] = i;
            }
            while (dsCanh.Count > 0)
            {
                DtEuler idx = dsCanh[0];
                dsCanh.RemoveAt(0);
                if (KtChuTrinh(idx, dsNhan) == true)
                {
                    dsCanhEuler.Add(idx);
                }

            }

            foreach (DtEuler item in dsCanhEuler)
            {
                Console.WriteLine(item._dinhBdauE + " " + item._dinhKthucE);
            }

        }
        #endregion

    }

}


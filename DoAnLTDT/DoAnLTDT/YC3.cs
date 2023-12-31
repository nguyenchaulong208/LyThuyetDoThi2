using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    public class YC3
    {
        /*
        Yêu cầu 3: Tìm cây khung nhỏ nhất (2 điểm)
        Kiểm tra đồ thị được cho có phải là đồ thị vô hướng liên thông hay không? Nếu không kiểm tra thì 
        trừ 0.5đ.
        Thực hiện các yêu cầu dưới đây nếu đồ thị đã cho là đồ thị vô hướng liên thông.
        a. (1đ) Tìm cây khung nhỏ nhất trên đồ thị đã cho bằng giải thuật Prim. Đỉnh bắt đầu là đỉnh 0.
        Xuất ra màn hình thông tin của cây khung nhỏ nhất tìm được 
        - Danh sách cạnh thuộc cây khung nhỏ nhất theo thứ tự được phát hiện bởi giải thuật. Quy 
        ước: In mỗi cạnh trên một dòng riêng biệt theo mẫu <x>-<y>: <z>, với x và y là hai đỉnh của 
        cạnh và z là trọng số của cạnh.
        - Trọng số của cây khung nhỏ nhất 
        b. (1đ) Tìm cây khung nhỏ nhất trên đồ thị đã cho bằng giải thuật Kruskal. Xuất ra màn hình 
        thông tin của cây khung nhỏ nhất theo quy cách tương tự như ở câu a.
        */
        public static void Run_YC3()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("YEU CAU 3: Tim cay khung nho nhat.");
            
            //Chay thuat toan Prim va Kruskal
            var checkVoHuong = KtDoThi(DataDoThi.data_ke);
            var checkLienThong = kqLienThong();
            if(checkLienThong == true && checkVoHuong == true)
            {
                Console.WriteLine("Thuat toan Prime");
                Prime(DataDoThi.data, 0);
                Console.WriteLine("---");
                Console.WriteLine("Thuat toan Kruskal");
                Kruskal(DataDoThi.data);
            }
            else
            {
                Console.WriteLine("Do thi khong lien thong hoac khong phai la do thi vo huong");
            }
        }
        #region//Kiem tra do thi lien thong va do thi vo huong
        /*
         * Method LienThong(): Xu ly kiem tra do thi lien thong:
         *  - Dung thuat toan DFS de kiem tra tinh lien thong cua do thi
         *      + Lay ket qua duyet DFS de kiem tra
         *      + Neu tat ca cac dinh deu duoc duyet thi do thi lien thong
         *      + Neu khong thi do thi khong lien thong
         *  - Neu do thi lien thong thi tra ve true
         *  - Neu do thi khong lien thong thi tra ve false
         *  Method kqLienThong(): In ket qua kiem tra do thi lien thong
         * */
        public static bool LienThong()
        {
          
                           
                bool[] checkLienThong = new bool[DataDoThi.n];
                for(int i = 0; i < DataDoThi.n; i++)
                {
                    checkLienThong[i] = false;
                }
            //kiem tra tinh lien thong bang dfs
                YC2.Duyet_DFS(0);
                string[] danhSachDfs = Duyet_Danh_Sach.DS_DFS.Split(' ');
                for(int i = 0; i < checkLienThong.Length; i++)
                {
                    for(int j = 0; j < danhSachDfs.Length; j++)
                    {
                        if(i == int.Parse(danhSachDfs[j]))
                        {
                            checkLienThong[i] = true;
                        }
                    }
                }
                for(int i = 0; i < checkLienThong.Length; i++)
                {
                    if (checkLienThong[i] == false)
                    {
                        return false;
                    }
                }
                
            
            return true;
        }
        //Lien thong
        public static bool kqLienThong()
        {
            bool result = false;
            var checkLienThong = LienThong();
            if(checkLienThong == false)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
        //Kiem tra do thi vo huong
        public static Boolean KtDoThi(int[,] doThi)
        {


            for(int i = 0; i < DataDoThi.n; i++)
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
    
        
        #endregion
        #region// Thuat toan Prim
        public static void Prime(int[,] doThi, int dinhBdau)
        {
            CayKhung[] canhCayKhung = new CayKhung[DataDoThi.n -1];
            int canh = 0;
            bool[] dinhDaXet = new bool[DataDoThi.n];
            //Khoi tao gia tri cho dinh da xet
            for(int i = 0; i < DataDoThi.n; i++)
            {
                dinhDaXet[i] = false;
            }
            dinhDaXet[dinhBdau] = true;
            //Thuat toan Prim
            while(canh < DataDoThi.n - 1)
            {
                CayKhung canhNhoNhat = new CayKhung();
                int min = int.MaxValue;
                for(int i = 0; i < DataDoThi.n; i++)
                {
                    if (dinhDaXet[i] == true)
                    {
                        for(int j =0; j < DataDoThi.n; j++)
                        {
                            if(DataDoThi.data[i, j] != 0 && dinhDaXet[j] == false)
                            {
                                if (DataDoThi.data[i, j] < min)
                                {
                                    min = DataDoThi.data[i, j];
                                    canhNhoNhat._dinhBdau = i;
                                    canhNhoNhat._dinhKthuc = j;
                                    canhNhoNhat._trongSo = min;
                                }
                            }

                        }

                    }
                }
                  canhCayKhung[canh] = canhNhoNhat;
                dinhDaXet[canhNhoNhat._dinhKthuc] = true;
                canh++;
            }

            //xuat ket qua thuat toan Prim
            int trongSoCayKhung = 0;
            foreach(var item in canhCayKhung)
            {
                Console.WriteLine($"{item._dinhBdau} - {item._dinhKthuc}: {item._trongSo}");
                trongSoCayKhung += item._trongSo;
            }
            Console.WriteLine($"Trong so nho nhat cua cay khung: {trongSoCayKhung}");
        }


        #endregion

        #region//Thuat toan Kruskal
        /* NOTE:
         * Cac method su dung trong thuat toan Kruskal:
         * NhanDinh(): Tao nhan danh dau cac dinh
         * DanhSachCanh(): Tao mang chua tat ca cac canh cua do thi
         *  - Khi dung method DanhSachCanh() se xuat hien cac gia tri null trong mang dsCanh
         *  o nhung chi muc cuoi cung => khi xuat mang se bao loi "Object reference not set to an instance of an object" => can dung method KhuGiaTriNull() de loai bo nhung gia tri null
         * KtChutrinh(): Kiem tra chu trinh cua do thi
         *  Xet dinh dau va dinh cuoi cua canh trong danh sach canh tai vi tri dinh can xet
         *  -   Neu khong co chu trinh thi tra ve true
         *  -   Neu co chu trinh thi tra ve false va sap xep lai nhan dinh
         * Kruskal(): Thuc hien thuat toan Kruskal
         */

        public static GtKruskal[] DanhSachCanh(int[,] doThi)
        {
            int count = 0;
            GtKruskal[] dsCanh = new GtKruskal[DataDoThi.n * DataDoThi.n];
            for (int i = 0; i < DataDoThi.n; i++)
            {
                for (int j = 0; j < DataDoThi.n; j++)
                {
                    if (DataDoThi.data[i, j] != 0)
                    {
                        dsCanh[count] = new GtKruskal();
                        dsCanh[count]._dinhBdauKr = i;
                        dsCanh[count]._dinhKthucKr = j;
                        dsCanh[count]._trongSoKr = DataDoThi.data[i, j];
                        count++;
                    }
                }
            }
            GtKruskal[] newDsCanh = KhuGiaTriNull(dsCanh);
            return CanhTrung(newDsCanh);
        }
       //Khu cac cac chi muc co gia tri null
        public static GtKruskal[] KhuGiaTriNull(GtKruskal[] danhSach)
        {
            int count = 0;
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i] != null)
                {
                    count++;
                }
            }
            GtKruskal[] dsCanh = new GtKruskal[count];
            for (int i = 0, j = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i] != null)
                {
                    dsCanh[j] = danhSach[i];
                    j++;
                }
            }
            return dsCanh;
        }
        //Loai bo cac canh trung nhau
        public static GtKruskal[] CanhTrung(GtKruskal[] ds)
        {
            for (int i = 0; i < ds.Length; i++)
            {
                if (ds[i] != null)
                {
                    for (int j = i + 1; j < ds.Length; j++)
                    {
                        if (ds[j] != null)
                        {
                            if (ds[i]._dinhBdauKr == ds[j]._dinhKthucKr && ds[i]._dinhKthucKr == ds[j]._dinhBdauKr)
                            {
                                ds[j] = null;
                            }
                        }
                    }
                }
            }
            return KhuGiaTriNull(ds);
        }
        //Sap Xep canh theo thu tu tang dan
        public static GtKruskal[] SapXepCanh(GtKruskal[] ds)
        {
            Array.Sort(ds, (x, y) =>
            {
                if (x == null || y == null) return 0;
                int compareWeight = x._trongSoKr.CompareTo(y._trongSoKr);
                if (compareWeight == 0)
                    return x._dinhBdauKr.CompareTo(y._dinhBdauKr);
                return compareWeight;
            });

            return KhuGiaTriNull(ds);
        }

        //Tao danh sach nhan dinh
        private static int[] NhanDinh()
        {
            
            
            int[] labels = new int[DataDoThi.n];
            for(int i = 0; i < DataDoThi.n; i++)
            {
                labels[i] = i;
            }   
            return labels;
        }
        //Kiem tra chu trinh
        private static bool KtChuTrinh(GtKruskal idx, int[] dsNhan)
        {
            int nhanBdau = dsNhan[idx._dinhBdauKr];
            int nhanKthuc = dsNhan[idx._dinhKthucKr];

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
        //Thuat toan Kruskal
        public static void Kruskal(int[,] Dothi)
        {
            GtKruskal[] dsCanhKr = new GtKruskal[DataDoThi.n - 1];
            GtKruskal[] dsCanh = SapXepCanh(DanhSachCanh(DataDoThi.data));
            int count = 0;
            int canhMin = 0;
            int[] labels = NhanDinh(); // Khởi tạo nhãn cho các đỉnh

            while (count < dsCanhKr.Length && canhMin < dsCanh.Length)
            {
                if (KtChuTrinh(dsCanh[canhMin], labels) == false) // Nếu không tạo chu trình
                {
                    dsCanhKr[count] = dsCanh[canhMin];
                    count++;
                }
                canhMin++;
            }

            // In kết quả
            int trongSoCayKhung = 0;
            foreach (var item in dsCanhKr)
            {
                if (item != null)
                {
                    Console.WriteLine($"{item._dinhBdauKr} - {item._dinhKthucKr}: {item._trongSoKr}");
                    trongSoCayKhung += item._trongSoKr;
                }
            }
            Console.WriteLine("Trong so cua cay khung: " + trongSoCayKhung);
        }


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("------------------");
            Console.WriteLine("YEU CAU 3: Tim cay khung nho nhat.");
            //Kiem tra tinh lien thong
            kqLienThong();
            Console.WriteLine("Thuat toan Prime");
            Prime(DataDoThi.data, 0);
            Console.WriteLine("Thuat toan Kruskal");
            //Xuat ket qua thuat toan Kruskal
            Kruskal(DataDoThi.data);



        }
        #region//Kiem tra do thi lien thong
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
           var checkVoHuong = YC1.Vector();
            if(checkVoHuong == true)
            {
                
                bool[] checkLienThong = new bool[DataDoThi.n];
                for(int i = 0; i < DataDoThi.n; i++)
                {
                    checkLienThong[i] = false;
                }
                //kiem tra tinh lien thong bang dfs
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
                
            }
            return true;
        }
        //Lien thong
        public static void kqLienThong()
        {
            var checkLienThong = LienThong();
            if(checkLienThong == false)
            {
                Console.WriteLine("Do thi khong lien thong");
            }
            else
            {
                Console.WriteLine("Do thi vo huong lien thong");
            }
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

        //Sap xep cac canh theo thu tu tang dan
        public static GtKruskal[] SapXepCanh(int[,] doThi)
        {
            GtKruskal[] dsCanh = new GtKruskal[DataDoThi.n * (DataDoThi.n - 1)];
            int soCanh = 0;
            for(int i = 0; i < DataDoThi.n; i++)
            {
                for(int j = 0; j < DataDoThi.n; j++)
                {
                    if (DataDoThi.data[i,j] != 0)
                    {
                        dsCanh[soCanh] = new GtKruskal();
                        dsCanh[soCanh]._dinhBdauKr = i;
                        dsCanh[soCanh]._dinhKthucKr = j;
                        dsCanh[soCanh]._trongSoKr = DataDoThi.data[i, j];
                        soCanh++;
                    }
                }
            }
            //Sap xep cac canh theo thu tu tang dan
            for(int i = 0; i < soCanh - 1; i++)
            {
                for(int j = i + 1; j < soCanh; j++)
                {
                    if (dsCanh[i]._trongSoKr > dsCanh[j]._trongSoKr)
                    {
                        GtKruskal temp = dsCanh[i];
                        dsCanh[i] = dsCanh[j];
                        dsCanh[j] = temp;
                    }
                }
            }
             return dsCanh;
            
            
        }
        //Kiem tra chu trinh trong do thi
        public bool KtChuTrinh(int canh)
        {
            GtKruskal[] dsCanh = SapXepCanh(DataDoThi.data);
            //Kiem tra nhan dang cua 2 dinh co giong nhau khong, neu co tra ve true, neu khong gan nhan nho hon cho bien lab1 va nhan lon hon cho bien lab2 va cap nhat toan bo dinh co nhan lab2 bang gia tri lab1
            int[] nhanDinh = new int[DataDoThi.n];
            for(int i = 0; i < DataDoThi.n; i++)
            {
                nhanDinh[i] = i;
            }
            int lab1 = nhanDinh[dsCanh[canh]._dinhBdauKr];
            int lab2 = nhanDinh[dsCanh[canh]._dinhKthucKr];
            if (lab1 == lab2)
            {
                return true;
            }
            else
            {
                for(int i = 0; i < DataDoThi.n; i++)
                {
                    if (nhanDinh[i] == lab2)
                    {
                        nhanDinh[i] = lab1;
                    }
                }
            }
            return false;

            
            
        }

        public static void Kruskal(int[,] doThi)
        {
            GtKruskal[] dsCanh = SapXepCanh(doThi);
            GtKruskal[] dsCanhCayKhung = new GtKruskal[DataDoThi.n - 1];
            int soCanh = 0;
            int trongSoCayKhung = 0;
            
            int[] nhanDinh = new int[DataDoThi.n];
            for (int i = 0; i < DataDoThi.n; i++)
            {
                nhanDinh[i] = i;
            }

            // Thực hiện thuật toán Kruskal
            for (int i = 0; i < dsCanh.Length; i++)
            {
                int dinhBdau = dsCanh[i]._dinhBdauKr;
                int dinhKthuc = dsCanh[i]._dinhKthucKr;
                int nhanDinhBdau = nhanDinh[dinhBdau];
                int nhanDinhKthuc = nhanDinh[dinhKthuc];

                if (nhanDinhBdau != nhanDinhKthuc)
                {
                    dsCanhCayKhung[soCanh] = dsCanh[i];
                    soCanh++;
                    trongSoCayKhung += dsCanh[i]._trongSoKr;

                    for (int j = 0; j < DataDoThi.n; j++)
                    {
                        if (nhanDinh[j] == nhanDinhKthuc)
                        {
                            nhanDinh[j] = nhanDinhBdau;
                        }
                    }
                }
            }

            // Xuất kết quả thuật toán Kruskal
            for (int i = 0; i < soCanh; i++)
            {
                Console.WriteLine($"{dsCanhCayKhung[i]._dinhBdauKr} - {dsCanhCayKhung[i]._dinhKthucKr}: {dsCanhCayKhung[i]._trongSoKr}");
            }

            Console.WriteLine($"Trong so nho nhat cua cay khung: {trongSoCayKhung}");
        }







        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    public class DataDoThi
    {
        // n la so dinh
        public static int n;
        // ma tran ke co trong so
        public static int[,] data;
        // ma tran ke
        public static int[,] data_ke;
    }
    #region//Du lieu cay khung nho nhat Thuat toan Prim
    public class CayKhung 
    {
        private int dinhBdau;
        private int dinhKthuc;
        private int trongSo;
        //comtructor
        public int _dinhBdau
        {
            get { return this.dinhBdau; }
            set { dinhBdau = value; }
        }
        public int _dinhKthuc
        {
            get { return this.dinhKthuc; }
            set { dinhKthuc = value; }
        }
        public int _trongSo
        {
            get { return trongSo; }
            set { trongSo = value; }
        }

        
    }
    #endregion

    #region//Du lieu cay khung nho nhat Thuat toan Kruskal
    public class GtKruskal
    {
        private int dinhBdauKr;
        private int dinhKthucKr;
        private int trongSoKr;
        //contructor
        public int _dinhBdauKr
        {
            get { return this.dinhBdauKr; }
            set { dinhBdauKr = value; }
        }
        public int _dinhKthucKr
        {
            get { return this.dinhKthucKr; }
            set { dinhKthucKr = value; }
        }
        public int _trongSoKr
        {
            get { return trongSoKr; }
            set { trongSoKr = value; }
        }
    }

    #endregion

}

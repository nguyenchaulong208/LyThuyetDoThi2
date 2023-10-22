using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    public class YC2
    {
        //Duyet do thi theo chieu sau DFS
        //Nhan dinh bat dau
        public static int NhapDinhBatDau()
        {
            Console.Write("Nhap dinh bat dau: ");
            int dinh = int.Parse(Console.ReadLine());
            return dinh;
        }
        //DFS - dung de quy
        public static void DFS(int dinh, bool[] DanhDau)
        {
            //Danh dau dinh da duyet
            DanhDau[dinh] = true;
            //In ra dinh da duyet
            Console.Write(dinh + " ");
            //Duyet cac dinh ke cua dinh dang xet
            for (int i = 0; i < DataDoThi.n; i++)
            {
                //Neu dinh ke chua duoc duyet thi duyet dinh ke
                if (DataDoThi.data_ke[dinh, i] == 1 && DanhDau[i] == false)
                {
                    DFS(i, DanhDau);
                }
            }
        }
       
            
        

    }
}

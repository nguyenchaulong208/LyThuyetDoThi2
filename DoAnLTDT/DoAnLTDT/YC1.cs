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
                Console.WriteLine("YEU CAU 1: PHAN TICH THONG TIN DO THI:");
                Console.WriteLine("a. Ma tran ke cua do thi:");
                XL_YC.Ma_tran_ke();


                Console.WriteLine("b. xac dinh tinh co huong cua do thi:");

                if (XL_YC.Vector() == true)
                {
                    Console.WriteLine("La do thi vo huong");
                }
                else
                {
                    Console.WriteLine("La do thi co  huong");
                }

                Console.WriteLine($"c. So dinh cua do thi {XL_INPUT.n + 1} ");
                Console.WriteLine($"d. So canh cua do thi {XL_YC.Socanh_DT()}");
                XL_YC.Dem_Boi_Khuyen();
                XL_YC.Dinh_T_CL();
                XL_YC.Bac_tung_dinh();



            }
        
    }
}

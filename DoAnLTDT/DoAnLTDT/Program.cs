using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string filename = "input.txt";
            XL_INPUT.KiemTraFile(filename);
            YC1.Run_YC1();
            YC2.Run_YC2();
            YC3.Run_YC3();
            YC4.Run_YC4();
            YC5.Run_YC5();

            

        }
    }
}

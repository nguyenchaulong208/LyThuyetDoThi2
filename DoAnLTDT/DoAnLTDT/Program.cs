﻿using System;
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
         //   Xuly.ChuyenDoiMTK(filename);
         ////   Xuly.outputarray(Xuly.data);
            Console.Read();
           

        }
    }
}

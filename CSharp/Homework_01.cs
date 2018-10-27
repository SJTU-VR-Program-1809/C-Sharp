using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Determinant
{
    class Program
    {
        static void Main(string[] args)
        {
            determinant  D = new determinant(); //Creating determinant classes
            D.Create(); 	   
            D.Display(D.GetHls(D)); //Console formatting display determinant and its value
            Console.ReadKey();
        }
    }
}

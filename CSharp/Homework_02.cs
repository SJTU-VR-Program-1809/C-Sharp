using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test2
{
    class Homework_02
    {

        static void Main(string[] args)
        {
            float[,] dettest = new float[4, 4] { { 1, 4, -1, 4 }, { 0, -7, 6, -5 }, { 0, -14, 7, -5 }, { 0, -12, 12, -10 } };
            Determinant det = new Determinant();
            det.SetDet(dettest);
            det.PrintDet();
            Console.WriteLine("the result is:" + det.ComputeDet());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Determinant
    {
        private double[,] det;
        private int rank;
        private int permutationNum;

        private Determinant() { }
        public Determinant(double[,] det)
        {
            rank = det.Length;
            permutationNum = 1;
            for (int i = rank; i > 0; i--)
            {
                permutationNum *= i;
            }
        }
        public void print()
        {
            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {
                    Console.Write(det[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public int Rank
        {
            get { return rank; }
            set { }
        }

        private int FindMaxMovableNum(int[] a, bool[] b)
        {
            int MaxMovableNum = 0;
            bool[] movable = new bool[rank];
            for (int i = 0; i < rank; i++)
            {
                if ((b[i] && (a[i] > a[i + 1])) || (!b[i] && (a[i] > a[i - 1])))
                {
                    movable[i] = true;
                }
            }
            for (int i = 0; i < rank; i++)
            {
                if (movable[i] && (i > MaxMovableNum))
                {
                    MaxMovableNum = i;
                }
            }
            return MaxMovableNum;
        }

        private void FindAnotherPermutation(int[] a, bool[] b)
        {
            int tempi, max;

            max = a[FindMaxMovableNum(a, b)];
            tempi = max;
            if (b[max])
            {
                a[max] = a[max + 1];
                a[max + 1] = tempi;
            }
            else
            {
                a[max] = a[max - 1];
                a[max - 1] = tempi;
            }
            for (int i = max + 1; i < rank; i++)
            {
                b[i] = !b[i];
            }
        }

        private int[,] FindAllPermutation()
        {
            int[,] allPermutation = new int[permutationNum, rank];

            int[] array = new int[rank];
            for (int i = rank; i > 0; i--)
            {
                array[rank - i] = i;
            }
            bool[] toRight = new bool[rank];
            for (int i = rank; i > 0; i--)
            {
                toRight[rank - i] = true;
            }
            for (int j = 0; j < permutationNum; j++)
            {
                for (int i = 0; i < rank; i++)
                {
                    allPermutation[j, i] = array[i];
                }
                FindAnotherPermutation(array, toRight);
            }

            return allPermutation;
        }

        private int[] ReverseNum()
        {
            int[] reverseNum = new int[permutationNum];
            for (int i = 0; i < permutationNum; i++)
            {
                int rev = 0;
                for (int j = 0; j < rank - 1; j++)
                {
                    for (int k = j + 1; k < rank; k++)
                    {
                        if (FindAllPermutation()[i, j] > FindAllPermutation()[i, k])
                        {
                            rev++;
                        }
                    }
                }
                reverseNum[i] = rev;
            }
            return reverseNum;
        }

        public double compute()
        {
            double sum = 0.0;
            double[] product = new double[permutationNum];
            for (int i = 0; i < permutationNum; i++)
            {
                double pro = 1.0;
                for (int j = 0; j < rank; j++)
                {
                    pro *= det[j, FindAllPermutation()[i, j]];
                }
                product[i] = pro;
            }

            for (int i = 0; i < permutationNum; i++)
            {
                sum += Math.Pow(-1, ReverseNum()[i] * product[i]);
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double[,] element = { { 1.0, 3.0, 3.0 }, { 1, 2, 3 }, { 4, 4, 4 } };
            Determinant deter = new Determinant(element);
            deter.print();
            //  1 3 3
            //  1 2 3
            //  4 4 4
            Console.WriteLine($"Rank : {deter.Rank}");
            double v = deter.compute();
            Console.WriteLine("deter scalar value" + v);

            Console.ReadKey();
        }
    }
}

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
            int[,] element = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Determinant deter = new Determinant(element);
            deter.print();
            Console.WriteLine("");
            Console.WriteLine($"Rank: {deter.Rank}");
            int value = deter.compute();
            Console.WriteLine("deter scalar value : " + value);
            Console.ReadKey();

        }
        
        class Determinant
        {
            private static int[,] deter;
            private int[] indexarray;
            private bool[] dir;
            public int Rank { get; set; }



            public Determinant(int[,] Deter)
            {
                deter = Deter;
                indexarray = getIndexArray(deter);
                dir = getDirectionArray(deter);
                Rank = Deter.Rank;
            }

            public int compute()
            {

                int detervalue = 0;
                int temp = 1;
                detervalue += sgn(getReverseNumber(indexarray)) * computeValue(deter, indexarray);

                while (temp != -1)
                {
                    temp = maxMoveableValue(indexarray, dir);
                    if (temp != -1)
                    {

                        exchangeLocationandDirection(indexarray, dir, maxMoveableValue(indexarray, dir));
                        detervalue += sgn(getReverseNumber(indexarray)) * computeValue(deter, indexarray);

                    }
                }
                return detervalue;
            }

            //get the index array of input determinant
            static int[] getIndexArray(int[,] deter)
            {

                int[] sortIndex = new int[deter.GetLength(0)];

                //get index array
                for (int i = 0; i < deter.GetLength(0); i++)
                {
                    sortIndex[i] = i;
                }

                return sortIndex;
            }

            //get the direction array of input determinant
            static bool[] getDirectionArray(int[,] deter)
            {
                bool[] dir = new bool[deter.GetLength(0)];

                //assign direction  false=left true=right
                for (int i = 0; i < deter.GetLength(0); i++)
                {
                    dir[i] = false;
                }

                return dir;
            }

            //get the biggest moveable value
            static int maxMoveableValue(int[] sortIndex, bool[] dir)
            {
                int rank = sortIndex.Length;
                int tempmax = 0;
                bool isMoveCount = false;

                for (int i = 0; i < rank; i++)
                {
                    if (i == 0 && dir[0] == false)
                    {
                        continue;
                    }
                    else if (i == rank - 1 && dir[rank - 1] == true)
                    {
                        continue;
                    }
                    else
                    {
                        if (dir[i] == false && i != 0)
                        {
                            if (sortIndex[i] > sortIndex[i - 1] && tempmax < sortIndex[i])
                            {
                                tempmax = sortIndex[i];
                                isMoveCount = true;
                            }
                        }
                        if (dir[i] == true && i != rank - 1)
                        {
                            if (sortIndex[i] > sortIndex[i + 1] && tempmax < sortIndex[i])
                            {
                                tempmax = sortIndex[i];
                                isMoveCount = true;
                            }
                        }
                    }
                }

                if (isMoveCount)
                {
               //   Console.WriteLine("最大可移动数为：{0}", tempmax);
                    return tempmax;
                }
                else
                {
             //      Console.WriteLine("未找到最大可移动数");
                    return -1;
                }
            }



            //get reverse number
            static int getReverseNumber(int[] x)
            {
                int count = 0;
                for (int i = 1; i < x.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (x[j] > x[i])
                        {
                            count++;
                        }
                    }
                }
                return count;
            }

            //get sign of reverse number
            static int sgn(int num)
            {
                if (num % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            //Calculate the product of one term in determinant
            static int computeValue(int[,] deter, int[] array)
            {
                int productvalue = 1;
                int i = 0;
                foreach (var j in array)
                {
                    productvalue *= deter[i, j];
                    i++;
                }
                return productvalue;
            }


            //exchange the location of biggest moveable value and it's direction
            //exchange the location of biggest moveable value and it's direction
            static void exchangeLocationandDirection(int[] array, bool[] dir, int maxValue)
            {
                int i = Array.IndexOf(array, maxValue);
                int tempvalue = array[i];
                bool tempdir = dir[i];

                if (dir[i] == false)
                {
                    array[i] = array[i - 1];
                    array[i - 1] = tempvalue;
                    dir[i] = dir[i - 1];
                    dir[i - 1] = tempdir;
                }
                if (dir[i] == true)
                {
                    array[i] = array[i + 1];
                    array[i + 1] = tempvalue;
                    dir[i] = dir[i + 1];
                    dir[i + 1] = tempdir;
                }
                if (maxValue < array.Length - 1)
                {
                    int tempIndex;
                    for (int j = maxValue + 1; j < array.Length; j++)
                    {
                        tempIndex = Array.IndexOf(array, j);
                        dir[tempIndex] = !dir[tempIndex];
                    }
                }

            }

            //print input determinant
            public void print()
            {
                for (int i = 0; i < deter.GetLength(0); i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < deter.GetLength(1); j++)
                        Console.Write(deter[i, j] + " ");

                }
            }
        }

        
        #region unused code
        ////exchange the location of biggest moveable value and it's direction
        //static void exchangeMoveableValueLocation(int[] array, bool[] dir, int maxValue)
        //{
        //    int i = Array.IndexOf(array, maxValue);
        //    int tempvalue = array[i];
        //    bool tempdir = dir[i];

        //    if (dir[i] == false)
        //    {
        //        array[i] = array[i - 1];
        //        array[i - 1] = tempvalue;
        //        dir[i] = dir[i - 1];
        //        dir[i - 1] = tempdir;
        //    }
        //    if (dir[i] == true)
        //    {
        //        array[i] = array[i + 1];
        //        array[i + 1] = tempvalue;
        //        dir[i] = dir[i + 1];
        //        dir[i + 1] = tempdir;
        //    }

        //}


        ////change direction of value is bigger than the biggest moveable value
        //static void changeDirection(int[] array, bool[] dir, int index)
        //{
        //    int tempIndex;
        //    for (int i = index + 1; i < array.Length; i++)
        //    {
        //        tempIndex = Array.IndexOf(array, i);
        //        dir[tempIndex] = !dir[tempIndex];
        //    }
        //}
        #endregion  
    }

}

 


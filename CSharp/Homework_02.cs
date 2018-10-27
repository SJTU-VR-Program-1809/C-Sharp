using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project1
{
    class Program
    {

        static void Main()
        {
            //Use web:https://matrix.reshish.com/determinant.php for test!!!
            //result is -11
            //double[,] element = { { 2, 0, 1 }, { 0, 1, 3 }, { 3, 2, 2 } };                            
            //result is 2
            //double[,] element = { { 1, 2, 3 }, { 4, 0, 5 }, { 1, 0, 1 } };                           
            //result is 0
            //double[,] element = { { 1, 1, 1, 1 }, { 1, 2, 4, 3 }, { 4, 3, 2, 1 }, { 6, 5, 4, 3 } };   
            //result is -571.87863892
            double[,] element = { { 1.3, 1.2, 1.1, 0.1, 0.2 }, { -0.2, -0.9, 1.1, 0, 2 }, { -0.1, -0.9, 1.4, 4.4, 2.2 }, { 2.1, 7, 2.1, 4, 2.22 }, { 1.012, 2.2, 9.21, 0.98, 0.1 } };

            Determinant deter = new Determinant(element);

            deter.Print();

            Console.WriteLine(string.Format("Rank:{0}",deter.Rank));

            Console.WriteLine(string.Format("deter scalar value:{0}", deter.Compute()));
        }
    }

    class Determinant
    {
        private int rank;
        public int Rank { get { return rank; } }
        private double[,] deter;

        //store index
        private int[] indexArray;
        //store index's direction: true is left,false is right
        private bool[] indexArrayLeftDirection;
        private int biggestIndex = -1;
        public int BiggestIndex 
        {
            get { return biggestIndex; }
            set
            {
                Swap(biggestIndex, value);
                biggestIndex = value;
            }
        }

        private Determinant() { }
        public Determinant(double[,] deter)
        {
            this.deter = deter;
            rank = deter.GetLength(0);

            indexArray = new int[rank];
            indexArrayLeftDirection = new bool[rank];
            for (int i = 0; i < rank; i++)
            {
                indexArray[i] = i;
                indexArrayLeftDirection[i] = true;
            }
            biggestIndex = rank - 1;
        }

        public double Compute()
        {
            double result = 0;
            do
            {
                double mulNum = 1f;
                for (int i = 0; i < rank; i++)
                {
                    mulNum *= deter[i, indexArray[i]];
                }
                if(CalcReversedOrder(indexArray)%2!=0)
                {
                    mulNum *= -1;
                }
                result += mulNum;
            } while (FindBiggest());
            return result;
        }

        public void Print()
        {
            Console.WriteLine("Your Deternimant is:");
            for (int i = 0; i < rank; i++)
            {
                for (int j = 0; j < rank; j++)
                {
                    Console.Write(string.Format("\t{0}", deter[i, j]));
                }
                Console.WriteLine();
            }
            

        }

        /// <summary>
        /// Change indexArray.
        /// If return false,finished!
        /// Else,not yet!
        /// </summary>
        private bool FindBiggest()
        {
            if ((BiggestIndex == 0 && indexArrayLeftDirection[BiggestIndex] == true) ||         //BiggestIndex in leftmost and dirention is left
                (BiggestIndex == rank - 1 && indexArrayLeftDirection[BiggestIndex] == false))   //BiggestIndex in rightmost and direction is right
            {
                //Find less big index and change direction of biggest
                int lessNum=2;
                bool notFind = true;
                //Change Direction
                indexArrayLeftDirection[BiggestIndex] = !indexArrayLeftDirection[BiggestIndex];
                do
                {
                    //Finished!!!
                    if (rank - lessNum == 0)
                        return false;
                    for (int i = 0; i < indexArray.Length; i++)
                    {
                        if(indexArray[i]==rank-lessNum)
                        {
                            if ((i == 0 && indexArrayLeftDirection[i] == true) ||
                                (i == rank - 1 && indexArrayLeftDirection[i] == false) ||
                                (indexArrayLeftDirection[i] && indexArray[i - 1] > indexArray[i]) ||
                                (!indexArrayLeftDirection[i] && indexArray[i + 1] > indexArray[i]))
                            {
                                //find less less big index
                                lessNum++;
                                indexArrayLeftDirection[i] = !indexArrayLeftDirection[i];
                            }
                            else
                            {
                                //find and get less big index
                                notFind = false;
                                if (indexArrayLeftDirection[i])
                                    Swap(i, i - 1);
                                else
                                    Swap(i, i + 1);
                            }
                            break;
                        }
                    }
                } while (notFind);
            }
            else
            {
                if (indexArrayLeftDirection[biggestIndex] == true)
                    BiggestIndex -= 1;
                else
                    BiggestIndex += 1;
            }
            return true;
        }

        /// <summary>
        /// Swap index and direction
        /// </summary>
        private void Swap(int a,int b)
        {
            int tempIndex = indexArray[a];
            bool tempDirection = indexArrayLeftDirection[a];
            indexArray[a] = indexArray[b];
            indexArrayLeftDirection[a] = indexArrayLeftDirection[b];
            indexArray[b] = tempIndex;
            indexArrayLeftDirection[b] = tempDirection;
            //for (int i = 0; i < indexArray.Length; i++)
            //{
            //    Console.Write(indexArray[i] + " ");
            //}
            //Console.WriteLine();
        }

        /// <summary>
        /// Calculate Reverse Number
        /// </summary>
        private int CalcReversedOrder(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                        count++;
                }
            }
            return count;
        }
    }
 
}
    //class Product
    //{
    //    public Product(string name, int newID)
    //    {
    //        ItemName = name;
    //        ItemID = newID;
    //    }
    //    public string ItemName { get; set; }
    //    public int ItemID { get; set; }
    //}

    //static void Main(string[] args)
    //{
    //    //int n = -7 >> 2;
    //    //Console.WriteLine(Convert.ToString(-7, 2));
    //    //Console.WriteLine(Convert.ToString(-7, 2).Length);
    //    DebugDecimalToBinary(7);
    //    DebugDecimalToBinary(-7);
    //    DebugDecimalToBinary(9>>1);
    //    //Console.WriteLine(SetZero(11, 3));
    //    Console.ReadKey();
    //}

    //static void DebugDecimalToBinary(long n)
    //{
    //    Console.WriteLine(string.Format("Your Decimal Number:{0}    Binary Number:{1}", n, Convert.ToString(n, 2)));
    //}

    //static ulong SetZero(ulong n, int i)
    //{
    //    return n & ~(1UL << i);
    //}



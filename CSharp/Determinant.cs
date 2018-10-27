using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class Determinant
    {
        float[,] det;
        int n;

        public void SetDet(float[,] d)
        {
            det = d;
            n = d.GetLength(0);
        }

        public void PrintDet()
        {
            Console.WriteLine("the Determinant is:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(det[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public float ComputeDet()
        {
            float result = 0.0f;

            int[] rank = new int[det.GetLength(0)];//define a sort from small to big
            for (int i = 0; i < n; i++)
            {
                rank[i] = i;
            }

            result += ComputeItem(rank);//compute the first sort part

            while (true) //a endless loop to get all sorts  use exicographical order
            {
                int index1 = -1;
                int index2 = -1;
                int min = -1;
                for (int i = n - 1; i >= 0; i--) //get the first index1 (index1 = i-1,rank[i-1]<rank[i])
                {
                    if (rank[i - 1] < rank[i])
                    {
                        index1 = i - 1;
                        break;
                    }
                }
                min = rank[index1 + 1];
                for (int i = index1 + 1; i < n; i++)//get the index2 (rank[index2]>rank[index1],after index1,rank[index2] is minimum)
                {
                    if (rank[i] > rank[index1] && rank[i] <= min)
                    {
                        min = rank[i];
                        index2 = i;
                    }
                }
                int temp = rank[index2];
                rank[index2] = rank[index1];
                rank[index1] = temp;            //exchange rank[index1] and rank[index2]
                int mid = (int)((n + index1 + 1) / 2);
                for (int i = index1 + 1; i < mid; i++) //reverse the rank after index
                {
                    temp = rank[i];
                    rank[i] = rank[n - (i - index1)];
                    rank[n - (i - index1)] = temp;
                }
                result += ComputeItem(rank); //add every sort

                if (IsCompleteSort(rank)) //if it's the last sort,break loop
                    break;
            }
            return result;
        }

        private float ComputeItem(int[] a)
        {
            float res = 1.0f;
            for (int i = 0; i < a.Length; i++)
                res *= det[i, a[i]];
            return res * GetReverseNumber(a);
        }

        public int GetReverseNumber(int[] a)
        {
            int rev = 0;//计数器

            for (int i = 0; i < (a.Length - 1); i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        rev++;
                    }
                }
            }
            if (rev % 2 == 0)
            {
                return 1;
            }
            else
                return -1;

        }

        private bool IsCompleteSort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] < a[i + 1])
                    return false;
            }
            return true;
        }
    }
}

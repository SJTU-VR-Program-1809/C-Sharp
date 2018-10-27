using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Determinant
{
    class determinant
    {
        private List<int[]> D = new List<int[]>(); //Storage determinant
        public void Create() //Determinant assignment
        {
            D.Clear();
            D.Add(new int[] { 2, 1,-5, 7,2});
            D.Add(new int[] { 8,-3, 0, 8,3});
            D.Add(new int[] { 5, 0,-3, 9,4});
            D.Add(new int[] { 2, 0, 0, 9,5});
            D.Add(new int[] { 1, 0, 0, 0,6});

        }
        public int Get(int index_x, int index_y) //Get elements of line X-1, column Y-1
        {
            return D[index_x - 1][index_y - 1];
        }
        public int GetCount() //Get the number of determinant rows (columns)
        {
            return D.Count;
        }
        public void Display(double Dvalue) //Console formatting display determinant
        {
            for (int i = 0; i < D.Count; i++)
            {
                Console.Write("|");
                for (int j = 0; j < D[i].Length; j++)
                {
                    Console.Write(j == D[i].Length - 1 ? (D[i][j]).ToString() : (D[i][j] + ",").ToString());
                }
                Console.Write("|");
                if (D.Count % 2 == 0)
                {
                    if (i == D.Count / 2 - 1)
                    {
                        Console.Write("=" + Dvalue);
                    }
                }
                else if (i == (D.Count - 1) / 2)
                {
                    Console.Write("=" + Dvalue);
                }
                Console.WriteLine();
            }
        }
        public  double GetHls(determinant D) //A determinant data is passed in, and its value is calculated and returned.
        {
            int[] arr = CollSet(D.GetCount());
            List<int[]> list = new List<int[]>();
            FullArray(list, arr, 0);
            double sum = 0;
            for (int cn = 1; cn <= list.Count; cn++)
            {
                double xg = 1;
                for (int i = 1; i <= D.GetCount(); i++)
                {
                    xg *= D.Get(i, list[cn - 1][i - 1]);
                }
                sum += Math.Pow(-1, N(list[cn - 1])) * xg;
            }
            return sum;
        }

        public  int[] CollSet(int num) //Generating continuous number arrangement
        {
            int[] result = new int[num];
            for (int i = 0; i < num; i++) result[i] = i + 1;
            return result;
        }

        public  int N(int[] arr) //Inverse number calculation
        {
            int N = 0;
            for (int i = 1; i < arr.Length; i++) for (int j = 0; j < i; j++) if (arr[j] > arr[i]) N++;
            return N;
        }

        public  void FullArray(List<int[]> list, int[] arr, int k) //Full Permutation generation
        {
            if (k == arr.Length)
            {
                int[] cp_arr = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++) cp_arr[i] = arr[i];
                list.Add(cp_arr);
            }
            else
            {
                for (int i = k; i < arr.Length; i++)
                {
                    { int t = arr[k]; arr[k] = arr[i]; arr[i] = t; }
                    FullArray(list, arr, k + 1);
                    { int t = arr[k]; arr[k] = arr[i]; arr[i] = t; }
                }
            }
        }


    }
}

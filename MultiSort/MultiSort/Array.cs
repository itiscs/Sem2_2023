using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSort
{
    public class Array
    {
        public int Length { get;}
        public int[] Arr { get; set; }

        public int[] Temp { get; set; }


        public Array(int len)
        {
            Length = len;
            Arr = new int[len];
            Temp = new int[len];
            Init();
        }

        private void Init()
        {
            Random r = new Random();
            for(int i = 0; i < Length; i++)
                Arr[i] = r.Next(-100,100);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Length; i++)
                sb.Append($"{Arr[i]} ");
            return sb.ToString();
        }


        public void Sort(int threadsNum)
        {
            Barrier b = new Barrier(threadsNum);
            Parallel.For(0, threadsNum, i =>
            {
                ParSort(i, threadsNum, b);
            });
        }

        public bool IsSorted(int k1, int k2)
        {
            for(int i = k1; i < k2 - 1; i++)
                if (Arr[i] > Arr[i+1])
                    return false;
            return true;

        }


        public void ParSort(int threadNum, int threads, Barrier b)
        {
            int k = Length/threads;
            int i1 = k * threadNum;
            int i2 = k * (threadNum + 1);
            if (threadNum == threads - 1)
                i2 = Length;

            System.Array.Sort(Arr, i1, i2-i1);
            //Console.WriteLine($"i1 = {i1}  i2 = {i2}  thread = {threadNum} sorted = {IsSorted(i1, i2)} ");

            var iter = 2;
            while(k < Length )
            {
                b.SignalAndWait();
                if (threadNum % iter == 0)
                {
                    int k1 = i1;
                    int k2 = k1 + k;
                    int k3 = k2 + k;
                    if(k3 > Length)
                        k3 = Length;
                    MergeArr(k1, k2, k3);
                    //Console.WriteLine($"{k1} {k2} {k3} --  {threadNum} -- {IsSorted(k1,k3)}");
                }
                k *= 2;
                iter *= 2;
            }

        }


        private void MergeArr(int k1, int k2, int k3)
        {
            //int[] mas = new int[k3 - k1];
            int l = k1;
            int m = k2;
            for(int  i = k1; i < k3; i++)
            {
                if(l >= k2)
                    Temp[i] = Arr[m++];
                else if (m >= k3)
                    Temp[i] = Arr[l++];

                else  if (Arr[l] < Arr[m])
                    Temp[i] = Arr[l++];
                else
                    Temp[i] = Arr[m++];

            }

            for(int i = k1; i < k3; i++)
            {
                //Console.Write($"{mas[i]} ");
                Arr[i] = Temp[i];
            }
            //Console.WriteLine();
        }



    }
}

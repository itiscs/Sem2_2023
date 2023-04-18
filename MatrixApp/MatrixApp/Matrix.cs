using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApp
{
    public class Matrix
    {

        int[,] matr;
        int size;
        

        public Matrix(int n)
        {
            size = n;
            matr = new int[size, size];
            Random r = new Random();

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matr[i, j] = r.Next(-100, 100);
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    sb.Append($" {matr[i, j]}");
                sb.AppendLine();
            }

            return sb.ToString();
        }


        public int PoslSum()
        {
            int posl = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    posl += matr[i, j];
                
            return posl;

        }


        public int ParallelSum(int threadsNum)
        {
            object ob = new object();
            int s = 0;

            Parallel.For(0, threadsNum, i =>
            { 
                int locSum = ParSum(i, threadsNum);

                lock (ob)
                {
                    s += locSum;
                }

            });

            return s;

        }


        public int ParSum(int num, int threadsNum)
        {
            var k = size / threadsNum;
            int i1 = k * num;
            int i2 = k * (num + 1);
            if (num == threadsNum - 1)
                i2 = size;

            //Console.WriteLine($"thread = {num} i1 = {i1} i2 = {i2}");


            int pSum = 0;
            for (int i = i1; i < i2; i++)
                for (int j = 0; j < size; j++)
                    pSum += matr[i, j];

            return (pSum);


        }




    }
}

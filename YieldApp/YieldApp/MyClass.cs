﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldApp
{
    public class MyEnumerator : IEnumerator<int>
    {

        int[] mas;
        int cur;

        public MyEnumerator(int[] arr)
        {
            mas = arr;
            cur = arr.Length;
        }


        public int Current
        {
            get 
            { 
                return mas[cur];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            cur--;
            return cur>=0;
        }

        public void Reset()
        {
            cur = mas.Length;
        }
    }

    public class PrimeEnumerator : IEnumerator<int>
    {

        List<int> mas = new List<int>();
        int cur;

        public PrimeEnumerator(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++) 
            {
                if (arr[i] % 3 == 0)
                    mas.Add(arr[i]);
            }
            cur = -1;
        }


        public int Current
        {
            get
            {
                return mas[cur];
            }
        }
        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            cur++;
            return cur < mas.Count;
        }

        public void Reset()
        {
            cur = -1;
        }
    }



    public class MyClass:IEnumerable<int>
    {

        int[] mas;


        public MyClass(int[] mas)
        {
            this.mas = mas;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new PrimeEnumerator(mas);
            //yield return 0;
            //yield return 10;
            //yield return 20;
            //yield return 30;
            //yield return 40;
            //yield return 50;

            //for (int i = 0; i < 6; i++)
            //{
            //    yield return i * i;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return new MyEnumerator(mas);
        //}
    }
}

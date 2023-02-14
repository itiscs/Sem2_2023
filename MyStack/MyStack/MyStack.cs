using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    internal class MyStack<T>  // where T :  IComparable
    {
        T[] mas;
        int maxSize;
        int top;

        public MyStack(int mSize)
        {
            maxSize = mSize; 
            mas = new T[maxSize];
            top = -1;
        }
        public MyStack():this(10)
        {
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public void Push(T item)
        {
            if (top >= maxSize-1)
                throw new IndexOutOfRangeException("Stack is full!");
            mas[++top] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Stack is empty!");
            return mas[top--];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for(int i = 0; i <= top; i++)
                sb.Append($"{mas[i]} - ");
            return sb.ToString();
        }
    }
}

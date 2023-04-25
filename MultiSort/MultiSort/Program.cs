namespace MultiSort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var n = 10000000;
            var p = 4;

            Console.WriteLine(n*Math.Log2(n));

            Console.WriteLine((n/p) * Math.Log2(n/p) + Math.Log2(p)*n/2);
           
            Array myArr = new Array(n);

            var t1 = DateTime.Now;
            myArr.Sort(1);
            Console.WriteLine(DateTime.Now - t1);

            Console.WriteLine(myArr.IsSorted(0, myArr.Length));

            Array myArr1 = new Array(n);

            t1 = DateTime.Now;
            myArr1.Sort(p);
            Console.WriteLine(DateTime.Now - t1);

            Console.WriteLine(myArr1.IsSorted(0, myArr1.Length));
        }
    }
}
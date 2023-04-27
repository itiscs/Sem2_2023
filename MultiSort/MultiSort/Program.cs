namespace MultiSort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var n = 40000000;
            var p = 2;

            Console.WriteLine(n*Math.Log2(n));

            Console.WriteLine((n/p) * Math.Log2(n/p) + Math.Log2(p)*n/2);
           
            Random r = new Random();
            var myArr = new Array<double>(n);
            myArr.Init(() => r.NextDouble());

            var t1 = DateTime.Now;
            myArr.Sort(1);
            Console.WriteLine(DateTime.Now - t1);

            Console.WriteLine(myArr.IsSorted(0, myArr.Length));

            myArr.Init(() => r.NextDouble());
            t1 = DateTime.Now;
            myArr.Sort(p);
            Console.WriteLine(DateTime.Now - t1);

            Console.WriteLine(myArr.IsSorted(0, myArr.Length));
            
        }
    }
}
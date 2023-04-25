namespace MultiSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Array myArr = new Array(40000000);

            //var t1 = DateTime.Now;
            //myArr.Sort(1);
            //Console.WriteLine(DateTime.Now - t1);

            //Console.WriteLine(myArr.IsSorted(0, myArr.Length));



            Array myArr1 = new Array(40000);

            var t1 = DateTime.Now;
            myArr1.Sort(6);
            Console.WriteLine(DateTime.Now - t1);

            Console.WriteLine(myArr1.IsSorted(0, myArr1.Length));
        }
    }
}
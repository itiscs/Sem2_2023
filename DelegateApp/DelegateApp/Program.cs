using DelegateApp;

public partial class Program
{
    
    public delegate int MyDeleg(int k, int l);
    public delegate void HelloDeleg();

    //public Func<int, int, int> MyFunc;
    //public Action<double> action;
   

    public static void Main()
    {
        ArOper arOper = new ArOper();
        
        MyDeleg oper = new MyDeleg(arOper.Sum);

        Console.WriteLine(oper(5,6));

        Console.WriteLine(oper.Invoke(15, 7));

        oper = arOper.Minus;

        Console.WriteLine(oper(5, 6));

        Console.WriteLine(oper.Invoke(15, 7));

        oper = arOper.Mult;

        Console.WriteLine(oper(5, 6));

        Console.WriteLine(oper.Invoke(15, 7));

        oper = arOper.Div;

        Console.WriteLine(oper(5, 6));

        Console.WriteLine(oper.Invoke(15, 7));

        HelloDeleg d2 = new HelloDeleg(arOper.Hello2);

        //d2();
        //d2.Invoke();
        d2 += arOper.Hello1;
        d2 += delegate
        {
            Console.WriteLine("Hello from anonim method");
        };

        d2 += () => {
            Console.WriteLine("Hello from lambda");
         };

        //d2 += arOper.Hello1;
        //d2 += arOper.Hello1;
        //d2 += arOper.Hello1;
        //d2 += arOper.Hello1;
        //d2 += arOper.Hello1;

        if (d2 == null)
        {
            Console.WriteLine("Delegate is empty!");
        }
        else 
        { 
            d2(); 
        }
        //d2?.Invoke();


        MyClass c = new MyClass(5);

        Console.WriteLine(c);

        Console.WriteLine(c.SomeMethod(
            delegate(int x,int y) { return x + y; }));

        Console.WriteLine(c.SomeMethod( (x,y) => x - y));

        Console.WriteLine(c.SomeMethod((x, y) =>
        {
            int a = x + y;
            return a;
        }));

        Console.WriteLine(c.SomeMethod(arOper.Max));



    }
}







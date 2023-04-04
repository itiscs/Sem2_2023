//using System.Threading;

using System.Runtime.Serialization.Formatters;

object locker = new();

int n = 100000000;
int[] arr = new int[n];
int sum = 0, sump = 0;  
for (int k = 0; k < n; k++)
{
    arr[k] = 1;
//    sump += arr[k];
}



var t1 = DateTime.Now;
for (int k = 0; k < n; k++)
{
    sump += arr[k];
}
var t2 = DateTime.Now;
Console.WriteLine($" Время в одном потоке {t2 - t1}");


void SumArray()
{
    int id = Thread.CurrentThread.ManagedThreadId - 10;
    Console.WriteLine(id);
    int k1 = n / 4;
    int i1 = k1 * id;
    int i2 = k1 * (id + 1);
    int sum1 = 0; 
    for(int i = i1; i < i2; i++)
        sum1 += arr[i];

    Console.WriteLine($"id = {id}    sum1 = {sum1}");


    lock (locker)
    {
        sum += sum1;
    }


}



t1 = DateTime.Now;
Thread myThread1 = new Thread(SumArray);
Thread myThread2 = new Thread(SumArray);
Thread myThread3 = new Thread(SumArray);
Thread myThread4 = new Thread(SumArray);

//Print();

myThread1.Start();
myThread2.Start();
myThread3.Start();
myThread4.Start();


myThread1.Join();
myThread2.Join();
myThread3.Join();
myThread4.Join();
Console.WriteLine($"sump = {sump}   sum = {sum}");
t2 = DateTime.Now;
Console.WriteLine($" Время в 4 потоках {t2 - t1}");




//// получаем текущий поток
Thread currentThread = Thread.CurrentThread;

//Thread myThread1 = new Thread(Print);
//Thread myThread2 = new Thread(new ThreadStart(Print));
//Thread myThread3 = new Thread(Print);// () => Print2(10));
//Thread myThread4 = new Thread(Print);// () => Print2(20));
//Print();

//void Print()
//{
//    var current = Thread.CurrentThread;
//    Thread.Sleep(current.ManagedThreadId * 10);
//    current.Name = $"Thread {current.ManagedThreadId}";
//    Console.WriteLine($"Имя потока: {current.Name}");

//    Console.WriteLine($"Запущен ли поток: {current.IsAlive}");
//    Console.WriteLine($"Id потока: {current.ManagedThreadId}");
//    Console.WriteLine($"Приоритет потока: {current.Priority}");
//    Console.WriteLine($"Статус потока: {current.ThreadState}");
//}
//void Print2(int k)
//{
//    Console.WriteLine($" Hello from {Thread.CurrentThread.ManagedThreadId} " +
//        $"k = {k} ");
//}









////получаем имя потока
//Console.WriteLine($"Имя потока: {currentThread.Name}");
//currentThread.Name = "Метод Main";
//Console.WriteLine($"Имя потока: {currentThread.Name}");

//Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
//Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
//Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
//Console.WriteLine($"Статус потока: {currentThread.ThreadState}");






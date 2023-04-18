

using MatrixApp;

var m = new Matrix(10000);

var t1 = DateTime.Now;
Console.WriteLine(m.PoslSum());
var t2 = DateTime.Now;
Console.WriteLine($"последовательно - {t2 - t1}");



var t11 = DateTime.Now;
int num = 4;
Console.WriteLine(m.ParallelSum(num));
var t12 = DateTime.Now;
Console.WriteLine($"потоков {num} время - {t12 - t11}");

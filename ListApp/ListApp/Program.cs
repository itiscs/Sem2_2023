
using ListApp;

var lst = new MyList<int>();

Console.WriteLine(lst.Count);

for (int i = 0; i < 10; i++)
    lst.AddLast(i);



lst.AddLast(100);
lst.AddFirst(200);
Console.WriteLine(lst);
Console.WriteLine(lst.Count);

for (int i = 0;i<10;i++)
    lst.DeleteLast();

Console.WriteLine(lst);
Console.WriteLine(lst.Count);


var lst2 = new MyList<string>();

lst2.AddLast("aaa");
lst2.AddLast("abc");

lst2.AddLast("zzzz");

lst2.AddLast("xxxx");

Console.WriteLine(lst2);
Console.WriteLine(lst2.Count);




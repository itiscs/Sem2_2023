using YieldApp;

MyClass cl = new MyClass(new int[] { 1,2,3,4,5,6,7,8,9});

foreach (var k in cl)
{
    Console.WriteLine(k);
    if (k == 4)
        break;
}

foreach (var k in cl)
{
    Console.WriteLine(k);
}

List<int> list = new List<int>() { 10,20,30,40,50,60};
ListEnum l = new ListEnum(list);
foreach (var k in list)
{
    Console.WriteLine(k);
}





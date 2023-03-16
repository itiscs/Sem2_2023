
using LinqApp;

List<int> lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 15 };


List<string> strs = new List<string>() {"aaava","bvbbbb","cccccc","zvzzzzz"};

//strs.Where()

var l1 = lst.Where(k => k % 3 == 0 && k > 55);//.Skip(1);


//lst.Intersect(new int[] { 3, 5, 6, 7, 8 });

string s2 = "sfdgsfg fdsgdfg dfgdfh dfh dfh dfh df hdf hd";







var s1 = strs.Where(s => s.Contains('v')).Where(s=>s.Length>5)
    .OrderByDescending(s => s.Length);

lst.Add(39);

//Console.WriteLine(l1);
foreach(var i in l1)
    Console.WriteLine(i);


//Console.WriteLine(lst.Min());



var pers = new List<Person>();
pers.Add(new Person() { Id = 10, Name = "Ivan", Age = 20});
pers.Add(new Person() { Id = 2, Name = "Petr", Age = 30 });
pers.Add(new Person() { Id = 2, Name = "Maksim", Age = 40 });
pers.Add(new Person() { Id = 4, Name = "Pavel", Age = 10 });
pers.Add(new Person() { Id = 5, Name = "Anatoliy", Age = 33 });


var p1 = pers.Where(pers=>pers.Age > 20).OrderBy(p=>p.Id)
    .Select(p => new { p.Id, p.Name });

foreach (var p in p1)
{
    Console.WriteLine(p);
}


//var p = pers.FirstOrDefault(p => p.Id == 20);
//if (p == null)
//    Console.WriteLine("no element");
//else
//    Console.WriteLine(p);


var studs = new List<Student>();
studs.Add(new Student() { Id = 1, Name = "Ivan", Group = "11-208",
        Marks = new List<int> {5,5,2,4 }
});
studs.Add(new Student() { Id = 2, Name = "Petr", Group = "11-208",
    Marks = new List<int> { 5, 5, 5, 4 }
});
studs.Add(new Student() { Id = 3, Name = "Maksim", Group = "11-208",
    Marks = new List<int> { 2, 2, 2, 4 }
});
studs.Add(new Student() { Id = 4, Name = "Pavel", Group = "11-209",
    Marks = new List<int> { 2, 3, 3, 4 }
});
studs.Add(new Student() { Id = 5, Name = "Anatoliy", Group = "11-209",
    Marks = new List<int> { 3 }
});


var st2 = studs.Select(s => new
{
    s.Name,
    AvgMarks = s.Marks.Average(),
    KolvoNeud = s.Marks.Where(m => m == 2).Count(),
    MaxMark = s.Marks.Max()
});

foreach (var st in st2.Where(s=>s.KolvoNeud > 2))
    Console.WriteLine(st);



var gr = studs.GroupBy(s => s.Group);

foreach (var g in gr)
{
    Console.WriteLine($"{g.Key}  {g.Count()}:");
    foreach (var s in g)
        Console.WriteLine(s);
}











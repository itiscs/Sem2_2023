
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

var deps = new List<Department>()
{
    new Department(){Id=11,Name="ITIS",Address="1505"},

    new Department(){Id=13,Name="ISFNK",Address="1512"},

    new Department(){Id=1,Name="Ecology",Address="100"}
};



var studs = new List<Student>();
studs.Add(new Student() { Id = 1, DepartmentId=11, Name = "Ivan", Group = "11-208",
       Semestr = 2, Marks = new List<int> {5,5,2,4 }
});
studs.Add(new Student() { Id = 2,
    DepartmentId = 11,
    Name = "Petr", Group = "11-208",
    Semestr = 1,
    Marks = new List<int> { 5, 5, 5, 4 }
});
studs.Add(new Student() { Id = 3,
    DepartmentId = 11,
    Name = "Maksim", Group = "11-208",
    Semestr = 1,
    Marks = new List<int> { 2, 2, 2, 4, 3 }
});
studs.Add(new Student()
{
    Id = 1,
    Name = "Ivan",
    DepartmentId = 11,
    Group = "11-208",
    Semestr = 1,
    Marks = new List<int> { 5, 5}
});
studs.Add(new Student()
{
    Id = 2,
    DepartmentId = 11,
    Name = "Petr",
    Group = "11-208",
    Semestr = 2,
    Marks = new List<int> { 3, 3, 3 }
});
studs.Add(new Student()
{
    Id = 3,
    DepartmentId = 11,
    Name = "Maksim",
    Group = "11-208",
    Semestr = 2,
    Marks = new List<int> { 2, 2, 2, 4, 3 }
});
studs.Add(new Student() { Id = 4,
    DepartmentId = 11,
    Name = "Pavel", Group = "11-209",
    Semestr = 1,
    Marks = new List<int> { 2, 3, 3, 4 }
});
studs.Add(new Student() { Id = 5,
    DepartmentId = 11,
    Name = "Anatoliy", Group = "11-209",
    Semestr = 1,
    Marks = new List<int> { 3 }
});
studs.Add(new Student()
{
    Id = 8,
    DepartmentId = 13,
    Name = "Maria",
    Group = "13-001",
    Semestr = 1,
    Marks = new List<int> { 2, 3, 3, 4 }
});
studs.Add(new Student()
{
    Id = 9,
    DepartmentId = 13,
    Name = "Anna",
    Group = "13-001",
    Semestr = 1,
    Marks = new List<int> { 5,5,5,5,5 }
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


Console.WriteLine("*************************");


//var gr = studs.OrderByDescending(s=>s.Id).GroupBy(s => s.Group)
//    .Where(g=>g.Key == "11-208");

//foreach (var g in gr)
//{
//    Console.WriteLine($"{g.Key}  {g.Count()}:");
//    foreach (var s in g)
//        Console.WriteLine(s);
//}


Console.WriteLine("*************************");
//var gr2 = studs.GroupBy(s => s.Group).Select(g =>
//                        new { Group = g.Key, Count = g.Count(),
//                        MaxMarks = g.Max(s1=>s1.Marks.Count),
//                        GroupAv = g.Average(s1=>s1.Marks.Average())});

//foreach (var g in gr2)
//{
//    Console.WriteLine(g);
//}

var gr2 = studs.GroupBy(s => new { s.Group, s.Semestr }).Select(g =>
                        new {
                            g.Key.Semestr,
                            g.Key.Group,
                            Count= g.Count(),
                            MaxMarks = g.Max(s1 => s1.Marks.Count),
                            GroupAv = g.Average(s1 => s1.Marks.Average())
                        });

foreach (var g in gr2)
{
    Console.WriteLine(g);
}


Console.WriteLine("*****************************");

//foreach(var st in studs.Select(s=>s.Semestr).Distinct())
//    Console.WriteLine(st);

//foreach (var m in studs.Where(s=>s.Group=="11-208").SelectMany(s=>s.Marks))
//    Console.WriteLine(m);

//foreach (var m in studs.Select(s => s.DepartmentId))
//    Console.WriteLine(m);


var lst3 = studs.Join(deps, s => s.DepartmentId, d => d.Id,
    (s, d) => new { DepName = d.Name, s.Group, s.Semestr, s.Name });

var lst4 = deps.Join(studs, d => d.Id, s => s.DepartmentId, 
    (d, s) => new { DepName = d.Name, s.Group, s.Semestr, s.Name });

foreach (var g in lst4.Distinct())
{
    Console.WriteLine(g);
}











using LinqApp;

List<int> lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 15 };


List<string> strs = new List<string>() {"aaava","bvbbbb","cccccc","zvzzzzz"};

//strs.Where()

var l1 = lst.Where(k => k % 3 == 0 && k > 55);//.Skip(1);


//lst.Intersect(new int[] { 3, 5, 6, 7, 8 });

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




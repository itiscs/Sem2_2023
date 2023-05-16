using System.Reflection;

namespace ReflectionApp
{

    internal class Person
    {
        public string Name { get; set; }
        private int rating;

        public Person()
        {
        }


        public Person(string name, int rate) 
        {
            this.Name = name;
            rating = rate;
        }

        protected static void StatMet()
        {
            Console.WriteLine("Static method");
        }

        public void Method1()
        {
            Console.WriteLine("Hello");
        }

        public void Method1(string n)
        {
            Console.WriteLine($"Hello {n}");
        }


        public int AddRating(int rate)
        {
            rating += rate;
            return rating;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {

            Type type = typeof(Person);

            Person p = new Person("Ivanov", 100);

            var type2 = p.GetType();


            Type typeInt = typeof(int); 

            Type typeOfType = type.GetType();


            Console.WriteLine(type.ToString());


            Console.WriteLine("Methods");
            foreach(var m in type.GetMethods())
            {
                Console.WriteLine(m.Name);
            }

            Console.WriteLine("Fields");
            foreach (var f in type.GetFields(BindingFlags.NonPublic|BindingFlags.Instance))
            {
                Console.WriteLine(f.Name);
            }

            ConstructorInfo ctor = type.GetConstructor(new Type[] {typeof(string), typeof(int) });

            ConstructorInfo defCtor = type.GetConstructor(new Type[] { });

            var pers1 = ctor.Invoke(new object[] { "Petrov", 200 }) as Person;


            var ratingInfo = type.GetField("rating", BindingFlags.NonPublic | BindingFlags.Instance);


            Console.WriteLine($"{pers1.Name} {ratingInfo.GetValue(pers1)}");


            var m1 = type.GetMethod("Method1", new Type[] { typeof(string) });

            var m2 = type.GetMethod("AddRating");

            var m3 = type.GetMethod("StatMet",BindingFlags.NonPublic|BindingFlags.Static);


            m3.Invoke(null, new object[] { });

            m1.Invoke(pers1, new object[] {"xxx"});

            Console.WriteLine(m2.Invoke(p, new object[] { 150 }));



            Console.WriteLine("*********************************");


            Assembly asm = Assembly.LoadFrom("ReflectionApp.dll");

            //Console.WriteLine(asm.FullName);
            // получаем все типы из сборки MyApp.dll
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.Name);
            }


        }
    }
}
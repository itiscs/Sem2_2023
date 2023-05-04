using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp
{
    public class PowerStation
    {
        public string Name { get; set; }
        public int MaxTemp { get; set; }
        public int CurTemp { get; set; }

        public event Action<object> Boom; 

        public PowerStation(string name, int max, int cur) 
        {
            Name = name;
            MaxTemp = max;
            CurTemp = cur;
        }

        public override string ToString()
        {
            return $"Station {Name} current temp - {CurTemp} max temp - {MaxTemp}";
        }


        public void HeatUp(int t)
        {
            if (CurTemp > MaxTemp)
                return;

            CurTemp += t;
            Console.WriteLine(this);
            if (CurTemp > MaxTemp)
                Boom?.Invoke(this);
        }

        public void CoolDown(int t)
        {
            CurTemp -= t;
            Console.WriteLine(this);
        }
    }

    public class FireFighters
    {
        public void Emergency(object sender)
        {
            Console.WriteLine($"Пожарные едут на станцию {sender}");
        }
    }
    public class Police
    {
        public void Emergency(object sender)
        {
            Console.WriteLine($"Полиция едет на станцию {sender}");
        }
    }

    public class Ambulance
    {
        public void Emergency(object sender)
        {
            Console.WriteLine($"Скорая помощь едет на станцию {sender}");
        }
    }



}

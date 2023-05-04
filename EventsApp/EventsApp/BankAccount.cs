using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp
{
    public class BankAccount
    {

        public event Action<string> Notify;   

        public string Name { get; set; }
        public int Sum { get; private set; }
        
        public BankAccount(string name, int sum)
        {
            Name = name;
            Sum = sum;
           // Notify("Создали счёт!");
        }

        public BankAccount(string name):this(name, 0) { }

        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счёт {Name} поступило {sum}");
        }

        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счёта {Name} сняли {sum}");
            }
            else
            {
                Notify?.Invoke($"На счёте {Name} недостаточно средств!");

            }
        }
    }
}

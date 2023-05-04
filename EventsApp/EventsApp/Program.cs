namespace EventsApp
{
    internal class Program
    {
        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }


        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount("Ivanov");
            acc1.Notify += DisplayMessage;
            acc1.Put(100);
            acc1.Take(50);


            BankAccount acc2 = new BankAccount("Петров");
            acc2.Notify += DisplayMessage;
            acc2.Notify -= DisplayMessage;
            acc2.Put(100);
            acc2.Take(150);


            PowerStation p1 = new PowerStation("Станция 1", 1000, 500);
            PowerStation p2 = new PowerStation("Станция 2", 2000, 1500);
            
            FireFighters fireFighters = new FireFighters(); 
            Police police = new Police();
            Ambulance ambulance = new Ambulance();

            p1.Boom += fireFighters.Emergency;
            p1.Boom += police.Emergency;
            p1.Boom += ambulance.Emergency;

            p2.Boom += fireFighters.Emergency;
            p2.Boom += police.Emergency;
            p2.Boom += ambulance.Emergency;


            for (int i = 0; i < 10; i++)
            {
                p1.HeatUp(100);
            }

            for (int i = 0; i < 10; i++)
            {
                p2.HeatUp(100);
            }






        }


    }
}
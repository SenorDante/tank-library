namespace TankInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tank> Tanks = new List<Tank>
            {
                new Tank("T-34", "USSR", "Medium Tank", 500, 1939, 76),
                new Tank("Tiger", "Nazi Germany", "Heavy Tank", 700, 1942, 88),
                new Tank("M4A3E8 Fury", "USA", "Medium Tank", 500, 1944, 76)
            };
            string choice;
            while (true)
            {
                Console.Write("Add a new tank [y/n]? ");
                choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    Tanks.Add(AddTank());
                }
                else
                    break;
            }
            foreach (var Tank in Tanks)
            {
                Tank.ShowTechnicalPassport();
            }
        }

        static Tank AddTank()
        {
            Console.Write("Enter model: ");
            string model = Console.ReadLine();
            Console.Write("Enter nation: ");
            string nation = Console.ReadLine();
            Console.Write("Enter type: ");
            string type = Console.ReadLine();
            Console.Write("Enter horsepower: ");
            int horsePower = int.Parse(Console.ReadLine());
            Console.Write("Enter release year: ");
            int release = int.Parse(Console.ReadLine());
            Console.Write("Enter gun diameter: ");
            int gunDiameter = int.Parse(Console.ReadLine());

            return new Tank(model, nation, type, horsePower, release, gunDiameter);
        }
    }
}

class Tank
{
    public string Model;
    public string Nation;
    public string Type;
    public int HorsePower;
    public int Release;
    public int GunDiameter;

    public Tank(string model, string nation, string type, int horsePower, int release, int gunDiameter)
    {
        Model = model;
        Nation = nation;
        Type = type;
        HorsePower = horsePower;
        Release = release;
        GunDiameter = gunDiameter;
    }

    public void ShowTechnicalPassport()
    {
        Console.WriteLine($"\nName tank: {Model}" +
            $"\nNation: {Nation}" +
            $"\nType: {Type}" +
            $"\nHorsepower: {HorsePower}" +
            $"\nRealese date: {Release}" +
            $"\nDiameter Gun: {GunDiameter}\n");
    }
}
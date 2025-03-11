namespace TankInfo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string path = "C:\\Users\\georg\\OneDrive\\Рабочий стол\\library.txt";
            List<Tank> Tanks = new List<Tank>();

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 7 &&
                        int.TryParse(parts[3], out int horsePower) &&
                        int.TryParse(parts[4], out int release) &&
                        int.TryParse(parts[5], out int gunDiameter) &&
                        int.TryParse(parts[6], out int mass))
                    {
                        Tanks.Add(new Tank(parts[0], parts[1], parts[2], horsePower, release, gunDiameter, mass));
                    }
                }
            }

            string choice;
            while (true)
            {
                Console.Write("Add a new tank [y/n]? ");
                choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    Tank newTank = AddTank();
                    Tanks.Add(newTank);
                    await File.AppendAllTextAsync(path, $"{newTank.Model},{newTank.Nation},{newTank.Type},{newTank.HorsePower},{newTank.Release},{newTank.GunDiameter},{newTank.Mass}\n");
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
            Console.Write("Enter mass: ");
            int mass = int.Parse(Console.ReadLine());

            return new Tank(model, nation, type, horsePower, release, gunDiameter, mass);
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
    public int Mass;

    public Tank(string model, string nation, string type, int horsePower, int release, int gunDiameter, int mass)
    {
        Model = model;
        Nation = nation;
        Type = type;
        HorsePower = horsePower;
        Release = release;
        GunDiameter = gunDiameter;
        Mass = mass;
    }

    public void ShowTechnicalPassport()
    {
        Console.WriteLine($"\nName tank: {Model}" +
            $"\nNation: {Nation}" +
            $"\nType: {Type}" +
            $"\nHorsepower: {HorsePower}" +
            $"\nRealese date: {Release}" +
            $"\nDiameter Gun: {GunDiameter}" +
            $"\nMass: {Mass}\n");
    }
}
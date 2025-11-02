namespace kalandjatek;

class Program
{
    static void Mozgas(List<List<int>> terkep)
    {
        // foreach (var sor in terkep)
        // {
        //     Console.WriteLine(string.Join(" ", sor));
        // }

        int x = 2;
        int y = 2;

        string bekeres = " ";

        while (bekeres != "kilépés")
        {
            Console.WriteLine($"Y: {y}");
            Console.WriteLine($"X: {x}");

            var iranyok = new List<string>();

            if (terkep[y - 1][x] != FAL)
            {
                iranyok.Add("észak");
            }

            if (terkep[y + 1][x] != FAL)
            {
                iranyok.Add(("dél"));
            }

            if (terkep[y][x - 1] != FAL)
            {
                iranyok.Add("nyugat");
            }

            if (terkep[y][x + 1] != FAL)
            {
                iranyok.Add(("kelet"));
            }
            
            Console.Write("A következő irányokba mehet: ");
            
            Console.WriteLine(string.Join(", ", iranyok));
            
            Console.Write("Merre? ");
            bekeres = Console.ReadLine().ToLower().Trim();

            switch (bekeres)
            {
                case "észak" or "é" when (terkep[y - 1][x] != FAL):
                    y--;
                    break;
                
                case "dél" or "d" when (terkep[y + 1][x] != FAL):
                    y++;
                    break;
                
                case "nyugat" or "ny" when (terkep[y][x - 1] != FAL):
                    x--;
                    break;
                
                case "kelet" or "k" when  (terkep[y][x + 1] != FAL):
                    x++;
                    break;
                
                case "kilépés":
                    Console.WriteLine("Viszlát!");
                    break;
                
                default:
                    Console.WriteLine("Hibás input!");
                    break;
                    
            }

            Console.WriteLine();
            
            
            // if ((bekeres == "észak" || bekeres == "é") && (terkep[y - 1][x] != FAL))
            // {
            //     y--;
            // } 
            // else if ((bekeres == "dél" || bekeres == "d") && (terkep[y + 1][x] != FAL))
            // {
            //     y++;
            // }
            // else if ((bekeres == "nyugat" || bekeres == "ny")  && (terkep[y][x - 1] != FAL))
            // {
            //     x--;
            // }
            // else if ((bekeres == "kelet" || bekeres == "k") && (terkep[y][x + 1] != FAL))
            // {
            //     x++;
            // }
            // else if (bekeres == "kilépés")
            // {
            //     Console.WriteLine("Kilépés...");
            // }
            // else
            // {
            //     Console.WriteLine("Hibás input!");
            // }
        }

    }

    public const int FAL = 1;
    public const int UT = 0;
    
    static void Main(string[] args)
    {
        Console.WriteLine("Üdvözöllek a játékban!");

        var terkep = new List<List<int>>
        {
            //       0   1   2   3   4   5  6   7   8   9
            new() { FAL,FAL,FAL,FAL,UT,FAL,FAL,FAL,FAL,FAL},// 0
            new() { FAL,FAL,UT,UT,UT,FAL,UT,UT,UT,FAL},     // 1
            new() { UT,UT,UT,FAL,UT,FAL,UT,FAL,FAL,FAL},    // 2
            new() { UT,FAL,UT,FAL,UT,FAL,UT,FAL,UT,UT},     // 3
            new() { UT,FAL,UT,FAL,FAL,FAL,UT,FAL,FAL,UT},   // 4
            new() { FAL,FAL,UT,FAL,UT,UT,UT,UT,FAL,UT},     // 5
            new() { UT,UT,UT,UT,UT,FAL,FAL,UT,FAL,UT},      // 6
            new() { UT,FAL,FAL,FAL,UT,FAL,FAL,UT,UT,UT},    // 7
            new() { UT,FAL,UT,UT,UT,FAL,FAL,UT,FAL,UT},     // 8
            new() { FAL,FAL,FAL,FAL,UT,FAL,FAL,FAL,FAL,UT}  // 9
        };

        Mozgas(terkep);
    }
}
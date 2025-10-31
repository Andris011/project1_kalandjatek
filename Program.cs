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
            
            Console.WriteLine("Merre?");
            bekeres = Console.ReadLine();
            bekeres = bekeres.ToLower().Trim();
            
            
            if ((bekeres == "észak" || bekeres == "é") && (terkep[y - 1][x] != FAL))
            {
                y--;
            } 
            else if ((bekeres == "dél" || bekeres == "d") && (terkep[y + 1][x] != FAL))
            {
                y++;
            }
            else if ((bekeres == "nyugat" || bekeres == "ny")  && (terkep[y][x - 1] != FAL))
            {
                x--;
            }
            else if ((bekeres == "kelet" || bekeres == "k") && (terkep[y][x + 1] != FAL))
            {
                x++;
            }
            else if (bekeres == "kilépés")
            {
                Console.WriteLine("Kilépés...");
            }
            else
            {
                Console.WriteLine("Hibás input!");
            }
        }

    }

    public const int FAL = 1;
    public const int UT = 0;
    
    static void Main(string[] args)
    {
        Console.WriteLine("Üdvözöllek a játékban!");

        var terkep = new List<List<int>>
        {
            //       0   1   2   3   4   5
            new() { FAL,FAL,FAL,FAL,FAL,FAL }, // 0
            new() { FAL,UT, UT, UT, UT, FAL }, // 1
            new() { FAL,FAL,UT,FAL,UT,FAL }, // 2
            new() { FAL,FAL,FAL,FAL,UT,FAL }, // 3
            new() { FAL,FAL,FAL,FAL,FAL,FAL }  // 4
        };

        Mozgas(terkep);
    }
}
namespace kalandjatek;

class Program
{
    static void Mozgas(List<List<int>> terkep)
    {
        // foreach (var sor in terkep)
        // {
        //     Console.WriteLine(string.Join(" ", sor));
        // }

        int x = 5;
        int y = 10;
        
        int fegyver_van = 0;
        int hp = 60;

        string bekeres = " ";

        while (bekeres != "kilépés")
        {
            var iranyok = new List<string>();

            if (terkep[y - 1][x] != FAL)
            {
                iranyok.Add("észak");
            }

            if (terkep[y + 1][x] != FAL)
            {
                iranyok.Add("dél");
            }

            if (terkep[y][x - 1] != FAL)
            {
                iranyok.Add("nyugat");
            }

            if (terkep[y][x + 1] != FAL)
            {
                iranyok.Add("kelet");
            }

            Console.WriteLine("\t \t \t \t \t \t hp: " + hp);
            Console.Write("A következő irányokba mehet: ");
            
            Console.WriteLine(string.Join(", ", iranyok));
            
            Console.Write("Merre? ");
            bekeres = Console.ReadLine().ToLower().Trim();

            switch (bekeres)
            {
                case "észak" or "é" or "e":
                    if (iranyok.Contains("észak"))
                    {
                        y--;
                    }
                    else
                    {
                        Console.WriteLine("Erre nem mehet, akadály van!");
                    }
                    break;
                
                case "dél" or "d":
                    if (iranyok.Contains("dél"))
                    {
                        y++;
                    }
                    else
                    {
                        Console.WriteLine("Erre nem mehet, akadály van!");
                    }
                    break;
                
                case "nyugat" or "ny" or "n":
                    if (iranyok.Contains("nyugat"))
                    {
                        x--;
                    }
                    else
                    {
                        Console.WriteLine("Erre nem mehet, akadály van!");
                    }
                    break;
                
                case "kelet" or "k":
                    if (iranyok.Contains("kelet"))
                    {
                        x++;
                    }
                    else
                    {
                        Console.WriteLine("Erre nem mehet, akadály van!");
                    }
                    break;
                
                case "kilépés":
                    Console.WriteLine("Viszlát!");
                    break;
                
                default:
                    Console.WriteLine("Hibás input!");
                    break;
                    
            }
            
            

            if (terkep[y][x] == ELLENSEG)
            {
                hp -= 20;

                if (hp == 0)
                {
                    Console.WriteLine("Találtál egy csapdát, meghaltál!");
                    bekeres = "kilépés";
                }
                else
                {
                    Console.WriteLine("Talált egy csapdát és vesztett 20 hp-t!");
                }
            } 
            else if (terkep[y][x] == FEGYVER && fegyver_van == 0)
            {
                Console.WriteLine("Talált egy kardot!");
                fegyver_van++;
            }
            else if (terkep[y][x] == BOSS)
            {
                Console.WriteLine("Megtalálta a kijáratot, amit egy nagy alvó patkány őrzött! Megpróbálja legyőzni?");
                Console.Write("[I]gen [N]em ");
                string valasz = Console.ReadLine().Trim().ToLower();
                
                switch (valasz)
                {
                    case "i":
                        if (fegyver_van == 1)
                        {
                            Console.WriteLine("Sikeresen legyőzte a szörnyet és kijutott a labirintusból! Gratulálok!");
                            bekeres = "kilépés";
                        }
                        else
                        {
                            Console.WriteLine("Fegyver hiányában nem sikerült legyőznie a szörnyet, meghalt. Próbálja újra!");
                            bekeres = "kilépés";
                        }
                        break;
                    
                    case "n":
                        Console.WriteLine("A szörny nem ébredt fel, de az ajtó felé sem tud tovább menni.");
                        break;
                    
                    default:
                        Console.WriteLine("Hibás input!");
                        break;
            }
                
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
    public const int ELLENSEG = 2; //enemy
    public const int FEGYVER = 3; //fegyver
    public const int BOSS = 4; //boss
    
    static void Main(string[] args)
    {
        Console.WriteLine("Üdvözöllek a játékban! \n" +
                          "A kilépésher írja be, hogy 'kilépés'");

        
        var terkep = new List<List<int>>
        {
            //       0   1   2   3   4   5  6   7   8   9   10  11
            new() { FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL},       // 0
            new() { FAL,FAL,FAL,FAL,FAL,BOSS,FAL,FAL,FAL,FAL,FAL,FAL},      // 1
            new() { FAL,FAL,FAL,UT,UT,UT,FAL,UT,UT,ELLENSEG,FAL,FAL},       // 2
            new() { FAL,UT,UT,UT,FAL,UT,FAL,UT,FAL,FAL,FAL,FAL},            // 3
            new() { FAL,UT,FAL,UT,FAL,ELLENSEG,FAL,UT,FAL,FEGYVER,UT,FAL},  // 4
            new() { FAL,ELLENSEG,FAL,UT,FAL,FAL,FAL,UT,FAL,FAL,UT,FAL},     // 5
            new() { FAL,FAL,FAL,UT,FAL,UT,UT,UT,UT,FAL,UT,FAL},             // 6
            new() { FAL,UT,UT,UT,UT,UT,FAL,FAL,UT,FAL,UT,FAL},              // 7
            new() { FAL,UT,FAL,FAL,FAL,UT,FAL,FAL,UT,UT,UT,FAL},            // 8
            new() { FAL,ELLENSEG,FAL,UT,UT,UT,FAL,FAL,ELLENSEG,FAL,UT,FAL}, // 9
            new() { FAL,FAL,FAL,FAL,FAL,UT,FAL,FAL,FAL,FAL,ELLENSEG,FAL},   // 10
            new() { FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL,FAL}        // 11
        };

        Mozgas(terkep);
    }
}
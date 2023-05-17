using Spectre.Console;

public static class ZaverecnyProjekt
{
    public static class Jachym 
    {
        public static void Klir()
        {
            Console.Clear();
        } 
    }
    private class Udaje
    {
        public Udaje(string jmeno, string heslo)
        {
            Heslo = heslo;
            Jmeno = jmeno;
        }
        public static bool cyklus = true;
        public string Jmeno;
        public string Heslo;
    }

    private static class Program
    {
        private static string[] platformy = { "Steam", "Discord", "Spotify", "XBOX", "PlayStation", "EpicGames", "Minecraft", "RiotGames" };
        
        public static void PřidejUdaje(string jmeno, string heslo)
        {
            Jachym.Klir();
            string volbaLauncher = VybraniLauncheru();

            if (!platformy.Contains(volbaLauncher))
            {
                Jachym.Klir();
                AnsiConsole.Markup($"{volbaLauncher} - [red]Špatně zadaná hodnota[/]");
                Console.ReadKey();
                return;
            }

            File.WriteAllText(volbaLauncher + ".txt", jmeno + ";" + heslo);
        }

        public static void UkazVsechnyUdaje()
        {
            Jachym.Klir();
            foreach (var platform in platformy)
            {
                if (!File.Exists(platform + ".txt"))
                {
                    Console.WriteLine($"{platform} - nezadáno");
                    continue;
                }

                string[] data = File.ReadAllText(platform + ".txt").Split(';');
                string jmeno = data[0];
                string heslo = data[1];

                Console.WriteLine($"{platform} - {jmeno}, {heslo}");
            }
            Console.ReadKey();
        }

        public static void SmazUdaje()
        {
            Jachym.Klir();
            string volbaLauncher = VybraniLauncheru();

            if (!platformy.Contains(volbaLauncher))
            {
                Jachym.Klir();
                AnsiConsole.Markup($"{volbaLauncher} - [red]Špatně zadaná hodnota[/]");
                Console.ReadKey();
                return;
            }
            File.Delete(volbaLauncher + ".txt");
        }
        
        public static void UkazUdajePodlePlatformy()
        {
            Jachym.Klir();
            string volbaLauncher = VybraniLauncheru();

            if (!platformy.Contains(volbaLauncher)) {
                Jachym.Klir();
                AnsiConsole.Markup($"{volbaLauncher} - [red]Špatně zadaná hodnota[/]");
                Console.ReadKey();
                return;
            }

            if (!File.Exists(volbaLauncher + ".txt"))
            {
                Jachym.Klir();
                AnsiConsole.Markup($"{volbaLauncher} - [red]nezadáno[/]");
                Console.ReadKey();
                return;
            }

            string[] data = File.ReadAllText(volbaLauncher + ".txt").Split(';');
            string jmeno = data[0];
            string heslo = data[1];

            Console.WriteLine($"{volbaLauncher} - {jmeno}, {heslo}");
            Console.ReadKey();
        }

        private static string VybraniLauncheru() 
        {
            Console.WriteLine($"Vyber launcher:\n");
            foreach (var platform in platformy) Console.WriteLine(platform);
            Console.WriteLine();
            string vyber = Console.ReadLine() ?? "nic";


            return vyber;
        }
    }
    
    private static void UkonciProgram()
    {
        Environment.Exit(0);
    }

    public static void Main()
    {
        while (Udaje.cyklus == true)
        {
            Jachym.Klir();
            try
            {
                char vyber = AnsiConsole.Ask<char>("[green]Přidat (p), Zobrazit (z), Jen vybraná platforma (v), Smazat udaje (s), Ukončit (u): [/]");
                if (vyber == 'p')
                {
                    Jachym.Klir();
                    string jmeno = AnsiConsole.Ask<string>("[blue]Zadej jmeno: [/]");
                    string heslo = AnsiConsole.Ask<string>("[blue]Zadej heslo: [/]");
                    Program.PřidejUdaje(jmeno, heslo);
                }


                else if (vyber == 'z')
                {
                    Program.UkazVsechnyUdaje();
                }
                else if (vyber == 'v')
                {
                    Program.UkazUdajePodlePlatformy();
                }
                else if (vyber == 'u')
                {
                    UkonciProgram();
                }
                else if (vyber == 's')
                {
                    Program.SmazUdaje();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("dal si spatny input si poop"); break;
            }
        }
    }
}
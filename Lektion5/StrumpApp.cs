namespace Lektion5
{
    internal class StrumpApp
    {
        public Strumphanterare strumphanterare;

        public StrumpApp(Strumphanterare s)
        {
            strumphanterare = s;
        }


        public void StrumpAppMeny()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("               HUVUDMENY");
            Console.WriteLine($"{new String('~', 40)}\n");
            Console.WriteLine("   1 - Lägg till strumpor från fil");
            Console.WriteLine("   2 - Lägga till strumpa");
            Console.WriteLine("   3 - Skriv ut strumplista");
            Console.WriteLine("   4 - Spara strumplista");
            Console.WriteLine("   5 - Sortera listan med avseende på storlek");
            Console.WriteLine("   6 - Skriva ut listan grupperad efter betyg");
            Console.WriteLine("   0 - Avsluta");
            Console.WriteLine($"\n{new String('~', 40)}");
            Console.Write(" Välj ett alternativ: ");
            Menyval();
        }

        public String GetFileName()
        {
            Console.Write("\n Ange filnamn: ");
            return Console.ReadLine() ?? "";
        }



        public void Menyval()
        {
            switch (Console.ReadLine() ?? "")
            {
                case "1":
                    MenyvalLaddaFil();
                    break;
                case "2":
                    MenyvalAdderaStrumpa();
                    break;
                case "3":
                    MenyvalSkrivLista();
                    break;
                case "4":
                    MenyvalSparaFil();
                    break;
                case "5":
                    MenyvalSortera();
                    break;
                case "6":
                    MenyvalGrupperaLista();
                    break;
                case "0":
                    break;
                default:
                    Console.Write(" Felinmatning. Försök igen: ");
                    Menyval();
                    break;

            }
        }

        private void MenyvalGrupperaLista()
        {
            Console.Clear();
            Console.WriteLine("\n ~~~~~ Grupperad lista efter betyg ~~~~~\n");

            var strumpListaGrupperad = strumphanterare.Strumpor.GroupBy(s => s.Betyg).OrderByDescending(s => s.Key);
            foreach (var betygsGrupp in strumpListaGrupperad)
            {
                Console.WriteLine($"Strumpor med betyg {betygsGrupp.Key}:");
                foreach (var item in betygsGrupp.OrderByDescending(s => s.Storlek))
                {
                    Console.WriteLine($"  * {item.Färg} strumpa av storlek {item.Storlek}");
                }
            }
            Delay();
        }

        private void MenyvalSortera()
        {
            Console.Clear();
            Console.WriteLine("\n ~~~~~ Sortera listan med strumpor ~~~~~");
            Console.WriteLine(" 1 - sortera lista med minst storlek först");
            Console.WriteLine(" 2 - sortera lista med störst storlek först");
            Console.Write(" Välj ett alternativ ovan: ");
            switch (Console.ReadLine() ?? "")
            {
                case "1":
                    strumphanterare.Strumpor.Sort();
                    break;
                case "2":
                    strumphanterare.Strumpor.Sort();
                    strumphanterare.Strumpor.Reverse();
                    break;
                default:
                    Console.Write("Felaktig inmatning. Försök igen ");
                    Console.WriteLine("\n Tryck på valfri tangent för att fortsätta");
                    Console.ReadKey();
                    MenyvalSortera();
                    break;
            }
            MenyvalSkrivLista();
        }

        private void MenyvalSparaFil()
        {
            Console.Clear();
            Console.WriteLine("\n ~~~~~ Spara listan med strumpor ~~~~~");
            String fileName = GetFileName();
            strumphanterare.SparaStrumpor(fileName);
            Console.WriteLine($"\n Listan med strumpor har sparats i filen {fileName}");
            Delay();
        }

        private void MenyvalSkrivLista()
        {
            Console.Clear();
            Console.WriteLine($"\n{new String('~', 50)}");
            Console.WriteLine("\n Listan av strumpor består av:\n");
            foreach (Strumpa socka in strumphanterare.Strumpor)
            {
                Console.WriteLine($"  * {socka.Färg} strumpa av storlek {socka.Storlek} med betyg {socka.Betyg}");
            }
            Console.WriteLine($"\n{new String('~', 50)}");
            Delay();
        }

        private void MenyvalAdderaStrumpa()
        {
            Console.Clear();
            Console.WriteLine("\n ~~~~~ Lägg till ny strumpa ~~~~~\n");
            Strumpa s = new Strumpa();
            Console.Write(" Ange storlek på strumpan: ");
            s.Storlek = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Ange färg på strumpan: ");
            s.Färg = Console.ReadLine() ?? "";
            Console.Write(" Ange betyg på strumpan (1-5): ");
            s.Betyg = Convert.ToInt32(Console.ReadLine());
            strumphanterare.Strumpor.Add(s);
            Delay();
        }

        private void MenyvalLaddaFil()
        {
            Console.Clear();
            Console.WriteLine("\n ~~~~~ Lägga till strumpor från fil ~~~~~");
            String fileName = GetFileName();
            Console.WriteLine(strumphanterare.LaddaStrumpor(fileName));
            Delay();
        }

        private void Delay()
        {
            Console.WriteLine("\n Tryck på valfri tangent för att fortsätta");
            Console.ReadKey();
            StrumpAppMeny();
        }
    }
}

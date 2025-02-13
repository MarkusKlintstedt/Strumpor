using System.Text.Json;

namespace Lektion5
{
    internal class Strumphanterare
    {
        public List<Strumpa> Strumpor = new List<Strumpa>();
        public StrumpApp app;



        public Strumphanterare()
        {
            app = new StrumpApp(this);
        }

        public String LaddaStrumpor(String filnamn)
        {
            try
            {
                String loadedJson = File.ReadAllText(filnamn);
                List<Strumpa> sockor = JsonSerializer.Deserialize<List<Strumpa>>(loadedJson) ?? new List<Strumpa>();
                Strumpor.AddRange(sockor);
                return $" {sockor.Count} stycken strumpor har lagts till";
            }
            catch (Exception)
            {
                return "Filen saknas. Inga strumpor har lagts till";
            }
        }

        public void SparaStrumpor(String filnamn)
        {
            String toJson = JsonSerializer.Serialize(Strumpor);
            File.WriteAllText(filnamn, toJson);
        }

        public void Start()
        {
            app.StrumpAppMeny();
        }


    }
}

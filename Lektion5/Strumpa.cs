namespace Lektion5
{
    internal class Strumpa : IComparable<Strumpa>
    {
        public int Storlek { get; set; }
        public string Färg { get; set; } = "";
        private int betyg;
        public int Betyg
        {
            get
            {
                return betyg;
            }
            set
            {
                if (value < 0)
                    betyg = 0;
                else if (value > 5)
                    betyg = 5;
                else
                    betyg = value;
            }
        }

        public int CompareTo(Strumpa? other)
        {
            if (!(other is Strumpa)) return 1;
            else if (this.Storlek > other.Storlek) return 1;
            else if (this.Storlek < other.Storlek) return -1;
            else return 0;
        }

        //public Strumpa(int storlek, string färg, int betyg)
        //{
        //    Storlek = storlek;
        //    Färg = färg;
        //    Betyg = betyg;
        //}
    }
}

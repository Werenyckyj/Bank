using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bank
{
    public class Sporici
    {
        public Guid ID { get; set; }
        public string Majitel { get; set; }
        public double Zustatek { get; set; }
        public double Urok { get; set; }
        public Sporici(string majitel, double zustatek, double urok)
        {
            Majitel = majitel;
            Zustatek = zustatek;
            Urok = urok;
        }
        public void Vklad(double castka)
        {
            Zustatek += castka;
        }


        public void Vyber(double castka)
        {
            if (Zustatek >= castka)
            {
                Zustatek -= castka;
            }
            else
            {
                MessageBox.Show("Chyba", "Nemáte dost peněž!", MessageBoxButton.OK);
            }
        }
    }

    
}

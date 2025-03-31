using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class KontoPlus : Konto
    {
        public decimal LimitDebetowy { get; private set; }
        public override decimal Bilans { get; internal set; }
        public KontoPlus(string Klient, decimal limitDebetowy, decimal bilansNaStart = 0) : base(Klient, bilansNaStart)
        {
            LimitDebetowy = limitDebetowy;
        }

        public void ZwiekszLimit(decimal wartosc)
        {
            if (wartosc < 0)
                throw new ArgumentException("Nie można przetworzyć ujemnej wartości");

            LimitDebetowy += wartosc;
        }

        public void ZmniejszLimit(decimal wartosc)
        {
            if (LimitDebetowy - wartosc < 0)
                throw new ArgumentException("Nie można zmniejszyć limitu debetowego do wartosci ujemnej");

            if (wartosc < 0)
                throw new ArgumentException("Nie można przetworzyć ujemnej wartości");

            LimitDebetowy -= wartosc;
        }

        public override void Wyplata(decimal kwota)
        {
            if (Blokada)
                throw new ArgumentException("Nie można dokonać wypłaty z zablokowanego konta");
            if (kwota < 0)
                throw new ArgumentException("Nie można dokonać ujemnej wypłaty");
            if (Bilans + LimitDebetowy < kwota)
                throw new ArgumentException("Nie można wypłacić kwoty większej niż dostępne środki + limit debetowy.");

            Bilans -= kwota;

            if (Bilans < 0) 
                BlokujKonto();

        }

        public override void Wplata(decimal kwota)
        {
            if (kwota < 0)
                throw new ArgumentException("Nie można dokonać ujemnej wpłaty");

            Bilans += kwota;

            if (Bilans > 0)
                OdblokujKonto();
        }
    }
}

#nullable disable
using System.Numerics;

namespace Bank
{
    public class Konto
    {
        private string klient;
        private decimal bilans;
        private bool zablokowane = false;

        public string Nazwa { get; } 
        public decimal Bilans { get; private set; } //Wbrew 7. punktu z kroku 1, musze dać tutaj private set aby testy przeszedły, 
        public bool Blokada { get; private set; }   //gdy jest tylko get (do odczytu) nie mogę zmodyfikować wartości za pomocą metod

        public Konto (string Klient, decimal bilansNaStart = 0)
        {
            klient = Klient;
            bilans = bilansNaStart;
            Nazwa = klient;
            Bilans = bilans;
            Blokada = zablokowane;
        }

        public void Wplata(decimal kwota)
        {
            if (Blokada)
                throw new ArgumentException("Nie można dokonać wpłaty do zablokowanego konta");
            if (kwota < 0)
                throw new ArgumentException("Nie można dokonać ujemnej wpłaty");

            Bilans += kwota;

        }
        public void Wyplata(decimal kwota)
        {
            if (Blokada)
                throw new ArgumentException("Nie można dokonać wypłaty z zablokowanego konta");
            if (kwota < 0)
                throw new ArgumentException("Nie można dokonać ujemnej wypłaty");
            if (Bilans < kwota)
                throw new ArgumentException("Nie można wypłacić więcej środków niż jest na koncie");

            Bilans -= kwota;
        }

        public void BlokujKonto() => Blokada = true;
        public void OdblokujKonto() => Blokada = false;
    }

}

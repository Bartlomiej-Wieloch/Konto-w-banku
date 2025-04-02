using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Bank
{
    public class KontoLimit
    {
        private readonly Konto _konto;
        private decimal _limitDebetowy;

        public KontoLimit(string Klient, decimal limitDebetowy, decimal bilansNaStart = 0)
        {
            _konto = new Konto(Klient, bilansNaStart);
            _limitDebetowy = limitDebetowy;
        }

        public decimal Limit
        {
            get { return _limitDebetowy; }
        }
        public string Nazwa
        {
            get { return _konto.Nazwa; }
        }
        public decimal Bilans
        {
            get { return _konto.Bilans; }
        }
        public bool Blokada
        {
            get { return _konto.Blokada; }
        }

        public void Wyplata(decimal kwota)
        {
            if (kwota < 0)
                throw new ArgumentException("Nie można dokonać ujemnej wypłaty.");
            if (_konto.Blokada)
                throw new ArgumentException("Nie można dokonać wypłaty z zablokowanego konta.");
            if (_konto.Bilans + _limitDebetowy < kwota) 
                throw new ArgumentException("Nie można wypłacić kwoty większej niż dostępne środki + limit debetowy.");

            _konto.Bilans -= kwota;

            if (_konto.Bilans < 0)
                BlokujKonto();
        }
        public void Wplata(decimal kwota)
        {
            if (kwota < 0)
                throw new ArgumentException("Nie można dokonać ujemnej wpłaty.");

            bool byloZablokowane = _konto.Blokada;

            if (byloZablokowane)
            {
                _konto.Bilans += kwota;
            }
            else
            {
                _konto.Wplata(kwota);
            }

            if (byloZablokowane && _konto.Bilans > 0)
                OdblokujKonto();
        }

        public void BlokujKonto()
        {
            _konto.BlokujKonto();
        }
        public void OdblokujKonto()
        {
            _konto.OdblokujKonto();
        }

        public void ZwiekszLimit(decimal wartosc)
        {
            if (wartosc < 0)
                throw new ArgumentException("Nie można zwiększyć limitu o ujemną wartość.");
            _limitDebetowy += wartosc;
        }
        public void ZmniejszLimit(decimal wartosc)
        {
            if (wartosc < 0)
                throw new ArgumentException("Nie można przetworzyć ujemnej wartości");

            if (_limitDebetowy - wartosc < 0)
                throw new ArgumentException("Nie można zmniejszyć limitu debetowego do wartosci ujemnej");



            _limitDebetowy -= wartosc;
        }
    }
}

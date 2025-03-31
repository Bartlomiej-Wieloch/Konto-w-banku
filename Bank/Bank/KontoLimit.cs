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
        private readonly KontoPlus _konto;
        public decimal Limit { get; private set; }

        public KontoLimit(string Klient, decimal limitDebetowy, decimal bilansNaStart = 0)
        {
            _konto = new KontoPlus(Klient, limitDebetowy, bilansNaStart);
            Limit = limitDebetowy;
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
            _konto.Wyplata(kwota);
        }
        public void Wplata(decimal kwota)
        {
            _konto.Wplata(kwota);
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
            decimal aktualnyLimit = _konto.Limit;
            _konto.ZwiekszLimit(wartosc);
            Limit = aktualnyLimit + wartosc;
        }
        public void ZmniejszLimit(decimal wartosc)
        {
            decimal aktualnyLimit = _konto.Limit; 
            _konto.ZmniejszLimit(wartosc);
            Limit = aktualnyLimit - wartosc; 
        }
    }
}

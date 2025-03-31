using Bank;
using Newtonsoft.Json.Converters;


namespace KontoTests
{
    [TestClass]
    public sealed class KontoTests
    {
        [TestMethod]
        public void Konto_Konstruktor_PoprawneDane()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;

            //Act
            var km = new Konto(nazwa, saldo);

            //Assert
            Assert.AreEqual(nazwa, km.Nazwa);
            Assert.AreEqual(saldo, km.Bilans);
            Assert.AreEqual(false, km.Blokada); 
        }
        [TestMethod]
        public void Konto_BlokujKonto_KontoOdblokowane_Powodzenie()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);

            //Act
            km.BlokujKonto();

            //Assert
            Assert.IsTrue(km.Blokada);
        }
        [TestMethod]
        public void Konto_OdblokujKonto_KontoZablokowane_Powodzenie()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);

            //Act
            km.OdblokujKonto();

            //Assert
            Assert.IsFalse(km.Blokada);
        }
        [TestMethod]
        public void Konto_Wplata_KwotaDodatnia_SaldoZwiekszaSie()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);

            //Act
            km.Wplata(500);

            //Assert
            Assert.AreEqual(1000, km.Bilans);
        }
        [TestMethod]
        public void Konto_Wplata_KwotaUjemna_Exception()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() => km.Wplata(-500));
        }
        [TestMethod]
        public void Konto_Wplata_KontoZablokowane_Exception()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);
            km.BlokujKonto();

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() => km.Wplata(500));
        }
        [TestMethod]
        public void Konto_Wyplata_KwotaDodatnia_SaldoZmniejszaSie()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);

            //Act
            km.Wyplata(500);

            //Assert
            Assert.AreEqual(0, km.Bilans);
        }
        [TestMethod]
        public void Konto_Wyplata_KwotaUjemna_Exception()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() => km.Wyplata(-500));
        }
        [TestMethod]
        public void Konto_Wyplata_BrakSrodkow_Exception()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() => km.Wyplata(600));

        }
        [TestMethod]
        public void Konto_Wyplata_KontoZablokowane_Exception()
        {
            //Arange
            string nazwa = "Bartek";
            decimal saldo = 500;
            var km = new Konto(nazwa, saldo);
            km.BlokujKonto();

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() => km.Wyplata(500));

        }

    }
}

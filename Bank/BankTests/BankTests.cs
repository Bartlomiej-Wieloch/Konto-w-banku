using Bank;
using Newtonsoft.Json.Converters;


namespace BankTests
{
    [TestClass]
    public sealed class BankTests
    {
        [TestMethod]
        public void Konstruktor_PoprawneDane()
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
        public void BlokujKonto_KontoOdblokowane_Powodzenie()
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
        public void OdblokujKonto_KontoZablokowane_Powodzenie()
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
        public void Wplata_KwotaDodatnia_SaldoZwiekszaSie()
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
        public void Wplata_KwotaUjemna_Exception()
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
        public void Wplata_KontoZablokowane_Exception()
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
        public void Wyplata_KwotaDodatnia_SaldoZmniejszaSie()
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
        public void Wyplata_KwotaUjemna_Exception()
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
        public void Wyplata_BrakSrodkow_Exception()
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
        public void Wyplata_KontoZablokowane_Exception()
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

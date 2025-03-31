using Bank;

namespace BankTests;

[TestClass]
public class KontoPlusTests
{
    [TestMethod]
    public void KontoPlus_Konstruktor_PoprawneDane()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;

        //Act
        var km = new KontoPlus(nazwa, limit, saldo);

        //Assert
        Assert.AreEqual(limit, km.Limit);
    }

    [DataTestMethod]
    [DataRow(500)]
    [DataRow(0)]
    public void KontoPlus_ZwiekszLimit_Powodzenie(int wartosc)
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;
        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.ZwiekszLimit(wartosc);

        //Assert
        Assert.AreEqual(wartosc + limit, km.Limit);
    }

    [DataTestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void KontoPlus_ZwiekszLimitUjemnaWartosc_ArgumentException()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;
        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.ZwiekszLimit(-500);

        //Assert
    }

    [DataTestMethod]
    [DataRow(1000)]
    [DataRow(500)]
    [DataRow(0)]
    public void KontoPlus_ZmniejszLimit_Powodzenie(int wartosc)
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;
        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.ZmniejszLimit(wartosc);

        //Assert
        Assert.AreEqual(limit - wartosc, km.Limit);
    }

    [DataTestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void KontoPlus_ZmniejszLimit_UjemnaWartosc_ArgumentException()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;
        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.ZmniejszLimit(-500);

        //Assert
    }

    [DataTestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void KontoPlus_ZmniejszLimit_ProbaUstawieniaUjemnegoLimitu_ArgumentException()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;
        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.ZmniejszLimit(99999999999);
        //Assert
    }
    //ts
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void KontoPlus_Wyplata_ZablokowaneKonto_ArgumentException()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.BlokujKonto();
        km.Wyplata(500);
        //Assert
    }


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void KontoPlus_Wyplata_UjemnaKwota_ArgumentException()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.Wyplata(-500);
        //Assert
    }

    [DataTestMethod]
    public void KontoPlus_Wyplata_MiesciSieWDebecie_Powodzenie()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.Wyplata(1500);

        //Assert
        Assert.AreEqual(-1000, km.Bilans);
    }
    [DataTestMethod]
    [DataRow(1000)]
    public void KontoPlus_Wyplata_SaldoSchodziPonizejZera_KontoBlokujeSie(int wartosc)
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.Wyplata(wartosc);

        //Assert
        Assert.IsTrue(km.Blokada);
    }

    [DataTestMethod]
    [DataRow(99999999)]
    [ExpectedException(typeof(ArgumentException))]
    public void KontoPlus_WyplataWiekszaNizDebet_Exception(int wartosc)
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.Wyplata(wartosc);

        //Assert
    }

    [TestMethod]
    public void KontoPlus_Wplata_KwotaUjemna_Exception()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);

        //Act

        //Assert
        Assert.ThrowsException<ArgumentException>(() => km.Wplata(-500));
    }

    [TestMethod]
    public void KontoPlus_Wplata_KwotaDodatnia_SaldoZwiekszaSie()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 500;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);

        //Act
        km.Wplata(500);

        //Assert
        Assert.AreEqual(1000, km.Bilans);
    }

    [TestMethod]
    public void KontoPlus_Wplata_KontoByloZablokowane_KontoOdblokowujeSie()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 300;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);
        km.Wyplata(500);

        //Act
        km.Wplata(400);

        //Assert
        Assert.IsFalse(km.Blokada);
    }

    [TestMethod]
    public void KontoPlus_WplataPartiami_KontoByloZablokowane_KontoOdblokowujeSie()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 300;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);
        km.Wyplata(500);

        //Act
        km.Wplata(100);
        km.Wplata(100);
        km.Wplata(1);

        //Assert
        Assert.IsFalse(km.Blokada);
    }
    //ts
    [TestMethod]
    public void KontoPlus_KontoBlokujeSiePoZejsciuSaldaPonizejZera_PoWplacieKontoOdblokowujeSie_MozliwoscSkorzystaniaZDebetuPrzywrocona()
    {
        //Arange
        string nazwa = "Bartek";
        decimal saldo = 300;
        decimal limit = 1000;

        var km = new KontoPlus(nazwa, limit, saldo);
        km.Wyplata(500);
        km.Wplata(201);

        //Act
        km.Wyplata(500);

        //Assert
        Assert.IsTrue(km.Blokada);
    }
}

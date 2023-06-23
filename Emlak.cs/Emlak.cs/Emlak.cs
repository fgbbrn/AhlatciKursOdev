using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak
{
    public class Emlak
    {
        public long Id;
        public string Fiyat;
        public DateTime IlanTarihi;
        public Musteri Sahibi;
        public decimal M2;
        public Adres Adres;
    }

    public class Konut : Emlak
    {
        public int OdaSayisi;
        public string Cephe;
        public int BinaYasi;
        public bool MerkeziSistemMi;

    }
    public class Ev : Konut
    {
        public int Kat;
        public int BinaKatSayisi;
        
    }

    public class Arsa : Emlak
    {
        public int Ada;
        public int Parsel;
        public bool ImarlıMi;
    }

    public class Villa : Konut
    {
        public int BahceM2;
        public bool HavuzluMu;
        public bool GarajiVarMi;

    }

    public class KiralikEv : Ev
    {
        public KiralikEmlakBilgileri KiralikBilgiler;
    }

    public class SatilikEv : Ev
    {

    }
    public class KiralikArsa : Arsa
    {
        
    }
    public class SatilikArsa : Arsa
    {

    }
    public class KiralikVilla : Villa
    {
        public KiralikEmlakBilgileri KiralikBilgiler;
    }

    public class SatilikVilla : Villa
    {
        
    }
    public class KiralikEmlakBilgileri
    {
        public decimal Depozito;
        public int KontratSuresi;
        public string Kefil;
        public bool EstaliMi;
    }

    public class Adres
    {
        public Semt Semt;
        public string Cadde;
        public string Sokak;
        public int BinaNo;
        public int DaireNo;
    }

    public class Sehir
    {
        public int Kod;
        public string Ad;
    }

    public class Semt
    {
        public int Kod;
        public string Ad;
        public string Sehir;
    }

    public class Musteri
    {
        private string Ad;
        public string soyad;
        public int Yas;
        public IletisimBilgi IletisimBilgi;
   
    }

    public class IletisimBilgi
    {
        public string CepTelNo;
        public string IsTelNo;
        public string EvTelNo;
        public string Email;
    }

}

    
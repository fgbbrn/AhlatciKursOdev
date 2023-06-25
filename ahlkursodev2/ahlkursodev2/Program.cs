using System;
using System.Collections.Generic;

public class Ders
{
    public string dersAdi { get; set; }
    public string dersKodu { get; set; }
    public List<Grup> gruplar { get; set; }

    public Ders(string dersAdi, string dersKodu)
    {
        this.dersAdi = dersAdi;
        this.dersKodu = dersKodu;
        gruplar = new List<Grup>();
    }

    public void GrupEkle(Grup grup)
    {
        gruplar.Add(grup);
    }
}

public class Grup
{
    public int grupId { get; set; }
    public List<Ogrenci> ogrenciler { get; set; }
    public List<Yoklama> yoklamalar { get; set; }

    public Grup(int grupId)
    {
        this.grupId = grupId;
        ogrenciler = new List<Ogrenci>();
        yoklamalar = new List<Yoklama>();
    }

    public void OgrenciEkle(Ogrenci ogrenci)
    {
        ogrenciler.Add(ogrenci);
    }

    public void OgrenciCikar(Ogrenci ogrenci)
    {
        ogrenciler.Remove(ogrenci);
    }

    public void YoklamaEkle(Yoklama yoklama)
    {
        yoklamalar.Add(yoklama);
    }
}

public class Ogrenci
{
    public int ogrenciId { get; set; }
    public string ad { get; set; }
    public string soyad { get; set; }
    public List<Sinav> sinavlar { get; set; }

    public Ogrenci(int ogrenciId, string ad, string soyad)
    {
        this.ogrenciId = ogrenciId;
        this.ad = ad;
        this.soyad = soyad;
        sinavlar = new List<Sinav>();
    }

    public int GetOgrenciId()
    {
        return ogrenciId;
    }

    public string GetAd()
    {
        return ad;
    }

    public string GetSoyad()
    {
        return soyad;
    }

    public void SinavEkle(Sinav sinav)
    {
        sinavlar.Add(sinav);
    }

    public float NotuGetir(int sinavId)
    {
        foreach (Sinav sinav in sinavlar)
        {
            if (sinav.sinavId == sinavId)
            {
                return sinav.NotuGetir(ogrenciId);
            }
        }
        return -1; // SinavId bulunamadı
    }
}

public class Yoklama
{
    public Ogrenci ogrenci { get; set; }
    public DateTime tarih { get; set; }
    public bool durum { get; set; }

    public Yoklama(Ogrenci ogrenci, DateTime tarih, bool durum)
    {
        this.ogrenci = ogrenci;
        this.tarih = tarih;
        this.durum = durum;
    }

    public Ogrenci GetOgrenci()
    {
        return ogrenci;
    }

    public DateTime GetTarih()
    {
        return tarih;
    }

    public bool GetDurum()
    {
        return durum;
    }
}

public class Sinav
{
    public int sinavId { get; set; }
    public Dictionary<int, float> notlar { get; set; }

    public Sinav(int sinavId)
    {
        this.sinavId = sinavId;
        notlar = new Dictionary<int, float>();
    }

    public void NotEkle(int ogrenciId, float not)
    {
        notlar[ogrenciId] = not;
    }

    public float NotuGetir(int ogrenciId)
    {
        if (notlar.ContainsKey(ogrenciId))
        {
            return notlar[ogrenciId];
        }
        return -1; // ÖğrenciId bulunamadı
    }
}

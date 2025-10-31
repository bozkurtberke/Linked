using Profil.Models;
using Profil.Models.Login.cs;
using Profil.Models.KullaniciProfili.cs;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace Profil.Services.ProfileService.cs
{
    public class ProfilServis
    {
        private KullaniciProfili kullaniciProfili;

        public ProfilServis()
        {
            kullaniciProfili = new KullaniciProfili {
            Id = 1,
            Ad="Berke",
            Headline ="Bilgisayar Mühendisliği",
            ProfilResmiUrl= "https://example.com/cem-yilmaz.jpg",
            Konum="Ankara/Öveçler",
            Hakkında="yazılım Hakkında ÇALIŞIYORUM.",
            Deneyimler=new List<Deneyim>
            {
                new Deneyim{Id=1,Baslık="Senior Yazılım Geliştirici",Sirket="APLOG",Konum="Ankara",BaslamaTarihi="2025 EYLÜL",BitisTarihi="BELLİ DEĞİL",Acıklama="PROJE YAPARIM"}
            },
            Egitimler = new List<Egitim>
            {
                new Egitim {Id=1,Okul="Gazi Üniversitesi",Derece="Lisans",CalısmaAlani="Bilgisayar Mühendisliği",BaslamaTarihi="Eylül 2023",BitisTarihi="Haziran 2027"}
            },
           
            Skills=new List<string> { "Nesne Yönelimli programlama ","WEB programlama ","API Server",}
            
            };  

        }

        public KullaniciProfili GetKullaniciProfili()
        {
            return kullaniciProfili;
       }


        public void ProfilGuncelleme(KullaniciProfili profilGuncelleme)
        {
            kullaniciProfili.Ad = profilGuncelleme.Ad;
            kullaniciProfili.Headline = profilGuncelleme.Headline;
            kullaniciProfili.ProfilResmiUrl=profilGuncelleme.ProfilResmiUrl;
            kullaniciProfili.Konum=profilGuncelleme.Konum;
            kullaniciProfili.Hakkında = profilGuncelleme.Hakkında;
        }

        public void deneyimEkleme(Deneyim newdeneyim)
            {
            newdeneyim.Id = kullaniciProfili.Deneyimler.Any() ? kullaniciProfili.Deneyimler.Max(e=>e.Id)+1:1;
            kullaniciProfili.Deneyimler.Add(newdeneyim);
            }

        public void DeneyimSilme(int id)
        {
            var deneyimSilme = kullaniciProfili.Deneyimler.FirstOrDefault(e=>e.Id==id);
            if (deneyimSilme != null) 
            {
                kullaniciProfili.Deneyimler.Remove(deneyimSilme);
            }

        }

        public void EgitimEkleme(Egitim eğitim) 
        {
            eğitim.Id = kullaniciProfili.Egitimler.Any() ? kullaniciProfili.Egitimler.Max(e => e.Id) + 1 : 1;
            kullaniciProfili.Egitimler.Add(eğitim);
        }

        public void EgitimSilme(int id)
        {
            var egitimSilme = kullaniciProfili.Egitimler.FirstOrDefault(e => e.Id == id);
            if (egitimSilme != null)
            {

                kullaniciProfili.Egitimler.Remove(egitimSilme);
            }
        }

        public void AddSkills(String skils)
        {
            if (!string.IsNullOrWhiteSpace(skils) && !kullaniciProfili.Skills.Contains(skils))
            {
                kullaniciProfili.Skills.Add(skils);
            }
        }

        public void DeleteSkills(string skills)
        {
            kullaniciProfili.Skills.Remove(skills);
        }

        


    }
}

using System.Collections.Generic;

namespace Profil.Models.KullaniciProfili.cs
{
    public class KullaniciProfili
    {
        public int Id { get; set; }
        public string Ad { get; set; }= string.Empty;
        public string Headline { get; set; }= string.Empty;
        public string ProfilResmiUrl { get; set; }= string.Empty;
        public string Konum { get; set; }= string.Empty;
        public string Hakkında { get; set; }= string.Empty;
        public List<Deneyim> Deneyimler { get; set; } = new List<Deneyim>();
        public List<Egitim> Egitimler { get; set; } = new List<Egitim>();
        public List<string> Skills { get; set; } = new List<string>();
    }
}

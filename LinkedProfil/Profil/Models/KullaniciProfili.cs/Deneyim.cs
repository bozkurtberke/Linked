using System.Collections.Generic;

namespace Profil.Models.KullaniciProfili.cs
{
    public class Deneyim
    {
        public int Id { get; set; }
        public string Baslık { get; set; }= string.Empty;
        public string Sirket { get; set; }= string.Empty;
        public string Konum { get; set; }= string.Empty;
        public string BaslamaTarihi { get; set; }= string.Empty;
        public string BitisTarihi { get; set; }= string.Empty;
        public string Acıklama { get; set; }= string.Empty;
    }
}

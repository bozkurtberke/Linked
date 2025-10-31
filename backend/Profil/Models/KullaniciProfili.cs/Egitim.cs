namespace Profil.Models.KullaniciProfili.cs
{
    public class Egitim
    {
        public int Id { get; set; }
        public string Okul { get; set; }= string.Empty;
        public string Derece { get; set; }= string.Empty;
        public string CalısmaAlani{ get; set; }= string.Empty;
        public string BaslamaTarihi { get; set; }= string.Empty;
        public string BitisTarihi { get; set; }= string.Empty;
    }
}

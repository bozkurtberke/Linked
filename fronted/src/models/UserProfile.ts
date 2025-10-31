export interface Deneyim {
  Id: number;
  Baslik: string;
  Sirket: string;
  Konum: string;
  BaslamaTarihi: string;
  BitisTarihi: string | null; 
  Aciklama: string;
}

export interface Egitim {
  Id: number;
  Okul: string;
  Derece: string;
  CalismaAlani: string;
  BaslamaTarihi: string;
  BitisTarihi: string | null;
}

export interface KullaniciProfili {
  Ad: string;
  Headline: string;
  ProfilResmiUrl: string;
  Konum: string;
  Hakkinda: string;
  Deneyimler: Deneyim[];
  Egitimler: Egitim[];
  Skills: string[];
}
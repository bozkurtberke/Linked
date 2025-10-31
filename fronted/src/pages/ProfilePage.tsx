import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import axios from 'axios';
import { KullaniciProfili, Deneyim, Egitim } from '../models/UserProfile'; 


const API_BASE_URL = 'http://localhost:5251/api/Profil'; 

const PageContainer = styled.div`
  max-width: 1000px;
  margin: 30px auto;
  padding: 20px;
  background-color: ${(props) => props.theme.colors.cardBackground};
  border-radius: 10px;
`;

const Header = styled.div`
  padding: 20px;
  background-color: ${(props) => props.theme.colors.cardBackground};
  border-bottom: 1px solid ${(props) => props.theme.colors.border};
  display: flex;
  align-items: center;
`;

const ProfileImage = styled.img`
  width: 100px;
  height: 100px;
  border-radius: 50%;
  margin-right: 20px;
  object-fit: cover;
`;

const SectionTitle = styled.h3`
  color: ${(props) => props.theme.colors.secondary};
  margin-top: 25px;
  border-bottom: 2px solid ${(props) => props.theme.colors.border};
  padding-bottom: 5px;
`;

const ProfilePage: React.FC = () => {
  const [profil, setProfil] = useState<KullaniciProfili | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchProfile = async () => {
      try {
       
        const response = await axios.get<KullaniciProfili>(API_BASE_URL);
        setProfil(response.data);
      } catch (err) {
        console.error('Profil yüklenirken hata oluştu:', err);
        setError('Profil bilgileri yüklenemedi. Backend ProfilServis çalışıyor mu?');
      } finally {
        setLoading(false);
      }
    };
    fetchProfile();
  }, []); 

  if (loading) return <PageContainer>Yükleniyor...</PageContainer>;
  if (error) return <PageContainer>Hata: {error}</PageContainer>;
  if (!profil) return <PageContainer>Profil verisi bulunamadı.</PageContainer>;

  return (
    <PageContainer>
      <Header>
        <ProfileImage src={profil.ProfilResmiUrl} alt="Profil Resmi" />
        <div>
          <h2>{profil.Ad}</h2>
          <h4>{profil.Headline}</h4>
          <p>{profil.Konum}</p>
        </div>
      </Header>

      <SectionTitle>Hakkında</SectionTitle>
      <p>{profil.Hakkinda}</p>

      <SectionTitle>Deneyimler</SectionTitle>
      {profil.Deneyimler.map((deneyim: Deneyim, index: number) => (
        <div key={index} style={{ marginBottom: '15px' }}>
          <strong>{deneyim.Baslik}</strong> at {deneyim.Sirket} ({deneyim.Konum})
          <p style={{ fontSize: '0.9em', color: '#666' }}>
            {deneyim.BaslamaTarihi} - {deneyim.BitisTarihi || 'Şu Anda'}
          </p>
          <p>{deneyim.Aciklama}</p>
        </div>
      ))}

      <SectionTitle>Eğitimler</SectionTitle>
      {profil.Egitimler.map((egitim: Egitim, index: number) => (
        <div key={index} style={{ marginBottom: '15px' }}>
          <strong>{egitim.Okul}</strong> - {egitim.Derece} ({egitim.CalismaAlani})
          <p style={{ fontSize: '0.9em', color: '#666' }}>
            {egitim.BaslamaTarihi} - {egitim.BitisTarihi || 'Mezuniyet Bekleniyor'}
          </p>
        </div>
      ))}
      
      <SectionTitle>Yetenekler</SectionTitle>
      <div style={{ display: 'flex', flexWrap: 'wrap', gap: '10px' }}>
        {profil.Skills.map((skills, index) => (
          <span key={index} style={{ padding: '5px 10px', backgroundColor: '#e6e6e6', borderRadius: '4px', fontSize: '0.9em' }}>
            {skills}
          </span>
        ))}
      </div>

    </PageContainer>
  );
};

export default ProfilePage;
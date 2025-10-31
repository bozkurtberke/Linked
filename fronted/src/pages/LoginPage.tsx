import React, { useState } from 'react';
import styled from 'styled-components';
import axios from 'axios';
import { useNavigate } from 'react-router-dom'; 



const FormContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  min-height: 100vh;
  background-color: ${(props) => props.theme.colors.background};
`;

const Form = styled.form`
  display: flex;
  flex-direction: column;
  padding: 40px;
  background-color: ${(props) => props.theme.colors.cardBackground};
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 300px;
`;

const Input = styled.input`
  margin-bottom: 20px;
  padding: 10px;
  border: 1px solid ${(props) => props.theme.colors.border};
  border-radius: 4px;
`;

const Button = styled.button`
  padding: 12px;
  border: none;
  background-color: ${(props) => props.theme.colors.primary};
  color: white;
  border-radius: 4px;
  font-weight: bold;
  cursor: pointer;
  &:hover {
    opacity: 0.9;
  }
`;

const Title = styled.h2`
  text-align: center;
  margin-bottom: 24px;
  color: ${(props) => props.theme.colors.text};
`;

interface LoginPageProps {
  setIsLoggedIn: (isLoggedIn: boolean) => void;
}

const LoginPage: React.FC<LoginPageProps> = ({ setIsLoggedIn }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate(); 

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const response = await axios.post('http://localhost:5253/api/auth/giris', {
        Username: username, 
        Password: password, 
      });

      if (response.status === 200) {
        setIsLoggedIn(true);
        navigate('/'); // 
      }
    } catch (error) {
      console.error('Giriş başarısız:', error);
      alert('Geçersiz kullanıcı adı veya şifre!');
    }
  };

  return (
    <FormContainer>
      <Form onSubmit={handleLogin}>
        <Title>Giriş Yap</Title>
        <Input
          type="text"
          placeholder="Kullanıcı Adı"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
        <Input
          type="password"
          placeholder="Şifre"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <Button type="submit">Giriş Yap</Button>
      </Form>
    </FormContainer>
  );
};

export default LoginPage;
import { useState } from "react";
import { useNavigate } from 'react-router-dom';
import './RegisterLoginAdmin.css';
import axios from '../axios/axios';

const RegisterLoginAdmin = ({ setIsLoggedIn, setUserEmail }) => {
  
  const navigate = useNavigate();
  const [loginData, setLoginData] = useState({ email: '', password: '' });
  const [loginEmailValid, setLoginEmailValid] = useState(true);
  const [loginPasswordValid, setLoginPasswordValid] = useState(true);
  const [loginError, setLoginError] = useState(null);

  const handleLoginChange = (e) => {
    const { name, value } = e.target;

    if (name === 'email') {
      setLoginEmailValid(/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value));
    }

    if (name === 'password') {
      setLoginPasswordValid(value.length >= 6);
    }

    setLoginData({ ...loginData, [name]: value });
  };

  const handleSubmitLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('/api/Admins/login', loginData);
      const { token } = response.data;
      localStorage.setItem('token', response.data); // Stochează token-ul în localStorage
      localStorage.setItem('email', loginData.email); // Stochează emailul în localStorage
      console.log('Logare reușită:', response.data);
      setIsLoggedIn(true);
      setUserEmail(loginData.email);

      // Redirecționează utilizatorul în funcție de email
      if (loginData.email === 'johnnyfdi@fdimobiliare.ro') {
        navigate('/director-menu'); // Redirecționare către pagina directorului
      } else {
        navigate('/consultant-menu'); // Redirecționare către pagina consultantului
      }
    } catch (error) {
      console.error('Eroare la logare:', error);
      setLoginError('Email sau parolă incorectă.');
    }
  };

  return (
    <div className="login-container">
      <div className="login-wrapper">
        <form onSubmit={handleSubmitLogin}>
          <h2>Login</h2>
          <div className="input-field">
            <input 
              type="text"
              name="email"
              autoComplete="off"
              value={loginData.email}
              onChange={handleLoginChange}
              required 
            />
            <label>Enter your email</label>
          </div>
          <div className="input-field">
            <input
              type="password"
              name="password"
              autoComplete="off"
              value={loginData.password}
              onChange={handleLoginChange}
              required 
            />
            <label>Enter your password</label>
          </div>
          
          <button type="submit">Log In</button>
          
        </form>
      </div>
    </div>
  );
};

export default RegisterLoginAdmin;

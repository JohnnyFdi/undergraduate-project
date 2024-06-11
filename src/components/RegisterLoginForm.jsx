import React from 'react';
import { useRef, useState, useEffect } from "react";
import './RegisterLoginForm.css'; // Importați stilurile CSS
import '@fortawesome/fontawesome-free/css/all.min.css';
import { faCheck, faTimes, faInfoCircle } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useNavigate } from 'react-router-dom';

import axios from '../api/axios';
import logphoto from '../images/loginphoto.jpg';
import regphoto from '../images/registerphoto.jpg';

const RegisterLoginForm = ({ setIsLoggedIn }) => {
  

  const [registerData, setRegisterData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    password: ''
  });
  const [firstNameValid, setFirstNameValid] = useState(true);
  const [lastNameValid, setLastNameValid] = useState(true);
  const [emailValid, setEmailValid] = useState(true);
  const [phoneNumberValid, setPhoneNumberValid] = useState(true);
  const [passwordValid, setPasswordValid] = useState(true);

  const [firstNameActive, setFirstNameActive] = useState(false);
  const [lastNameActive, setLastNameActive] = useState(false);
  const [emailActive, setEmailActive] = useState(false);
  const [phoneNumberActive, setPhoneNumberActive] = useState(false);
  const [passwordActive, setPasswordActive] = useState(false);

  const [isSubmitEnabled, setIsSubmitEnabled] = useState(false);

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
      const response = await axios.post('/api/Users/login', loginData);
      const { token } = response.data;
      localStorage.setItem('token', response.data); // Stochează token-ul în localStorage
      console.log('Logare reușită:', response.data);
      setIsLoggedIn(true);
      // Redirecționează utilizatorul după logare
      navigate('/'); // Redirecționare către o pagină protejată
    } catch (error) {
      console.error('Eroare la logare:', error);
      setLoginError('Email sau parolă incorectă.');
    }
  };

  ///---------------------------------------------------------------------------------------------------------------------------------------------------------------
  const handleChange = (e) => {
    const { name, value } = e.target;
    let isValid = true;

    // Verificăm dacă firstName începe cu literă mare și conține doar litere
    if (name === 'firstName') {
      isValid = /^(?=.{3,30}$)[A-Z][a-z]*(?:[-\s][A-Z][a-z]*)*$/.test(value);
      setFirstNameValid(isValid);
    }

    // Verificăm dacă lastName începe cu literă mare și conține doar litere
    if (name === 'lastName') {
      isValid = /^(?=.{3,30}$)[A-Z][a-z]*(?:[-\s][A-Z][a-z]*)*$/.test(value);
      setLastNameValid(isValid);
    }

      // Verificăm validitatea email-ului
  if (name === 'email') {
    isValid = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value);
    setEmailValid(isValid);
  }

  // Verificăm validitatea numărului de telefon
  if (name === 'phoneNumber') {
    isValid = /^\d{10}$/.test(value);
    setPhoneNumberValid(isValid);
  }

  if (name === 'password') {
    isValid = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,20}$/.test(value);
    setPasswordValid(isValid);
  }

    // Actualizăm datele de înregistrare și starea de validare
    setRegisterData({ ...registerData, [name]: value });
  };

  const handleFocus = (e) => {
    const { name } = e.target;

    // Actualizăm starea pentru input-ul activ
    if (name === 'firstName') {
      setFirstNameActive(true);
    }

    if (name === 'lastName') {
      setLastNameActive(true);
    }

    if (name === 'email') {
      setEmailActive(true);
    }

    if (name === 'phoneNumber') {
      setPhoneNumberActive(true);
    }

    if (name === 'password') {
      setPasswordActive(true);
    }
  };

  const handleBlur = (e) => {
    const { name } = e.target;

    // Actualizăm starea pentru input-ul inactiv
    if (name === 'firstName') {
      setFirstNameActive(false);
    }

    if (name === 'lastName') {
      setLastNameActive(false);
    }

    if (name === 'email') {
      setEmailActive(false);
    }

    if (name === 'phoneNumber') {
      setPhoneNumberActive(false);
    }

    if (name === 'password') {
      setPasswordActive(false);
    }

  };

  useEffect(() => {
    setIsSubmitEnabled(
      firstNameValid && lastNameValid && emailValid && phoneNumberValid && passwordValid
    );
  }, [firstNameValid, lastNameValid, emailValid, phoneNumberValid, passwordValid]);


  const handleSubmitRegister = async (e) => {
    e.preventDefault();
    const { firstName, lastName, email, phoneNumber, password } = registerData;

    if (firstName && lastName && email && phoneNumber && password && firstNameValid && lastNameValid && emailValid && phoneNumberValid && passwordValid) {
      try {
        const response = await axios.post('/api/Users/register', registerData);
        console.log('Datele de înregistrare au fost trimise:', response.data);
        // Poți gestiona răspunsul serverului aici, de exemplu, redirecționare sau afișare mesaj
      } catch (error) {
        console.error('Eroare la trimiterea datelor:', error);
      }
    } else {
      alert('Te rugăm să completezi toate câmpurile corect.');
    }
  };

  return (
<div className="register-login-wrapper">
    <div className="container-register-login">
      <input type="checkbox" id="flip" />
      <div className="cover">
        <div className="front">
          <img src={logphoto} alt="" />
          <div className="text">
            <span className="text-1">Cumpara-ti locuinta pe care <br /> ai visat-o mereu!</span>
            <span className="text-2">Intra in cont!</span>
          </div>
        </div>
        <div className="back">
          <img className="backImg" src={regphoto} alt="" /> 
          <div className="text">
            <span className="text-1">Inregistreaza-te si<br /> hai sa discutam!</span>
            <span className="text-2">Nevoile tale sunt prioritatile noastre.</span>
          </div>
        </div>
      </div>
      <div className="forms">
        <div className="form-content">
        <div className="login-form">
      <div className="title">Logare</div>
      <form onSubmit={handleSubmitLogin}>
        <div className="input-boxes">
          <div className={`input-box ${loginEmailValid ? '' : 'invalid'}`}>
            <i className="fas fa-envelope"></i>
            <input
              type="text"
              placeholder="Email"
              name="email"
              autoComplete="off"
              value={loginData.email}
              onChange={handleLoginChange}
              required
            />
            {!loginEmailValid && (
              <div className="popup-message">
                Email invalid.
              </div>
            )}
          </div>
          <div className={`input-box ${loginPasswordValid ? '' : 'invalid'}`}>
            <i className="fas fa-lock"></i>
            <input
              type="password"
              placeholder="Parola"
              name="password"
              autoComplete="off"
              value={loginData.password}
              onChange={handleLoginChange}
              required
            />
            {!loginPasswordValid && (
              <div className="popup-message">
                Parola trebuie să aibă cel puțin 6 caractere.
              </div>
            )}
          </div>
          <div className="button input-box">
            <input type="submit" value="Logare" />
          </div>
          {loginError && (
            <div className="error-message">
              {loginError}
            </div>
          )}
          <div className="text sign-up-text">Nu aveti un cont? <label htmlFor="flip">Signup now</label></div>
        </div>
      </form>
    </div>

        {/* -------------------------------------------------------------------------------------------------------------------------------------------------*/ }

          <div className="signup-form">
            <div className="title">Inregistrare</div>
            <form onSubmit={handleSubmitRegister}>
                <div className="input-boxes">
                  <div className={`input-box ${firstNameValid ? 'valid' : 'invalid'}`}>
                    <i className="fas fa-user"></i>
                    <input
                      type="text"
                      placeholder="Prenume"
                      name="firstName"
                      autoComplete="off"
                      value={registerData.firstName}
                      onChange={handleChange}
                      onFocus={handleFocus}
                      onBlur={handleBlur}
                      required
                    />
                    {firstNameActive && !firstNameValid && (
                    <div className="popup-message">
                      <FontAwesomeIcon icon={faInfoCircle} />
                       Numele trebuie scris cu litera mare, iar lungimea este intre 3-30 caractere.
                    </div>
                    
                  )}
                  </div>
                  

                  <div className={`input-box ${lastNameValid ? 'valid' : 'invalid'}`}>
                    <i className="fas fa-user"></i>
                    <input
                      type="text"
                      placeholder="Nume"
                      name="lastName"
                      autoComplete="off"
                      value={registerData.lastName}
                      onChange={handleChange}
                      onFocus={handleFocus}
                      onBlur={handleBlur}
                      required
                    />
                    {lastNameActive && !lastNameValid && (
                    <div className="popup-message">
                      <FontAwesomeIcon icon={faInfoCircle} />
                      Prenumele trebuie scris cu litera mare, iar lungimea este intre 3-30 caractere.
                    </div>
                  )}
                  </div>
                  <div className={`input-box ${emailValid ? 'valid' : 'invalid'}`}>
                    <i className="fas fa-envelope"></i>
                    <input
                      type="text"
                      placeholder="Email"
                      name="email"
                      autoComplete="off"
                      value={registerData.email}
                      onChange={handleChange}
                      onFocus={handleFocus}
                      onBlur={handleBlur}
                      required
                    />
                    {emailActive && !emailValid && (
                    <div className="popup-message">
                      <FontAwesomeIcon icon={faInfoCircle} />
                      Nu ati introdus corect email-ul. Exemplu: ionpopescu@yahoo.com
                    </div>
                  )}
                  </div>
                  <div className={`input-box ${phoneNumberValid ? 'valid' : 'invalid'}`}>
                    <i className="fas fa-phone"></i>
                    <input
                      type="tel"
                      placeholder="Numar de telefon"
                      name="phoneNumber"
                      autoComplete="off"
                      value={registerData.phoneNumber}
                      onChange={handleChange}
                      onFocus={handleFocus}
                      onBlur={handleBlur}
                      required
                    />
                    {phoneNumberActive && !phoneNumberValid && (
                    <div className="popup-message">
                      <FontAwesomeIcon icon={faInfoCircle} />
                      Nu ati introdus corect numarul de telefon. Exemplu: 0712345678
                    </div>
                  )}
                  </div>
                  <div className={`input-box ${passwordValid ? 'valid' : 'invalid'}`}>
                    <i className="fas fa-lock"></i>
                    <input
                      type="password"
                      placeholder="Parola"
                      name="password"
                      autoComplete="off"
                      value={registerData.password}
                      onChange={handleChange}
                      onFocus={handleFocus}
                      onBlur={handleBlur}
                      required
                    />
                    {passwordActive && !passwordValid && (
                    <div className="popup-message">
                      <FontAwesomeIcon icon={faInfoCircle} />
                      Nu ați introdus parola cum trebuie. Condiții: Are o lungime între 6 și 20 de caractere, cel puțin o literă mică,
                       conține cel puțin o literă mare, 
                       conține cel puțin o cifră. Fara caractere speciale.
                    </div>
                  )}
                  </div>
                  <div className="button input-box">
                    <input type="submit" value="Inregistrare" disabled={!isSubmitEnabled} />
                  </div>
                  <div className="text sign-up-text">Aveti deja un cont? <label htmlFor="flip">Login now</label></div>
                </div>
              </form>
          </div>
        </div>
      </div>
    </div>
</div>
  );
}

export default RegisterLoginForm;

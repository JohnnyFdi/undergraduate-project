import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate, useNavigate } from 'react-router-dom';

import RegisterLoginPage from './pages/RegisterLoginPage';
import DirectorPage from './pages/DirectorPage';
import ConsultantPage from './pages/ConsultantPage';

const App = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [userEmail, setUserEmail] = useState('');

  useEffect(() => {
    const token = localStorage.getItem('token');
    const email = localStorage.getItem('email');
    setIsLoggedIn(!!token); // Setează starea isLoggedIn pe true dacă există un token în localStorage
    setUserEmail(email); // Setează emailul utilizatorului din localStorage
  }, []);

  return (
    <Router>
      <div>
        <Routes>
          <Route path="/" element={<RegisterLoginPage setIsLoggedIn={setIsLoggedIn} setUserEmail={setUserEmail} />} />
          <Route path="/director-menu/*" element={<ProtectedRoute isLoggedIn={isLoggedIn} email={userEmail} requiredEmail="johnnyfdi@fdimobiliare.ro" exactMatch><DirectorPage /></ProtectedRoute>} />
          <Route path="/consultant-menu/*" element={<ProtectedRoute isLoggedIn={isLoggedIn} email={userEmail} notEmail="johnnyfdi@fdimobiliare.ro"><ConsultantPage /></ProtectedRoute>} />
        </Routes>
      </div>
    </Router>
  );
};

const ProtectedRoute = ({ isLoggedIn, email, requiredEmail, notEmail, exactMatch, children }) => {
  const navigate = useNavigate();

  useEffect(() => {
    if (!isLoggedIn || (exactMatch && email !== requiredEmail) || (!exactMatch && notEmail && email === notEmail)) {
      navigate('/');
    }
  }, [isLoggedIn, email, requiredEmail, notEmail, exactMatch, navigate]);

  return isLoggedIn && (!exactMatch || email === requiredEmail) && (!notEmail || email !== notEmail) ? children : null;
};

export default App;

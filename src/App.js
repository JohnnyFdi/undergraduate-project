import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate, useLocation } from 'react-router-dom';
import Navbar from './components/Navbar';
import Footer from './components/Footer';
import './App.css';
import HomePage from './pages/HomePage';
import AboutPage from './pages/AboutPage';
import ProjectsPage from './pages/ProjectsPage';
import ContactPage from './pages/ContactPage';
import Register_LoginPage from './pages/Register_LoginPage';
import CaseConfigPage from './pages/CaseConfigPage';
import ProfilePage from './pages/ProfilePage';
import Drift from 'react-driftjs';

const ScrollToTop = () => {
  const { pathname } = useLocation();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [pathname]);

  return null;
};

const App = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [audioContextAllowed, setAudioContextAllowed] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem('token');
    setIsLoggedIn(!!token); // Set isLoggedIn to true if there is a token in localStorage
  }, []);

  const handleUserGesture = () => {
    // Allow AudioContext to start
    setAudioContextAllowed(true);
  };

  return (
    <Router>
      <div onClick={handleUserGesture} onKeyDown={handleUserGesture} role="button" tabIndex={0}>
        <ScrollToTop />
        {isLoggedIn && audioContextAllowed && <Drift appId="chxw29vrkep9" />}
        <Navbar isLoggedIn={isLoggedIn} />
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/about" element={<AboutPage />} />
          <Route path="/projects/*" element={<ProjectsPage />} />
          <Route path="/register-login" element={isLoggedIn ? <Navigate to="/profile" /> : <Register_LoginPage setIsLoggedIn={setIsLoggedIn} />} />
          <Route path="/contact" element={<ContactPage />} />
          <Route path="/config-casa" element={<CaseConfigPage />} />
          <Route path="/profile" element={isLoggedIn ? <ProfilePage setIsLoggedIn={setIsLoggedIn} /> : <Navigate to="/register-login" />} />
        </Routes>
        <Footer />
      </div>
    </Router>
  );
};

export default App;

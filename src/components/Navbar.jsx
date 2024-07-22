import React, { useState } from 'react';
import { Link, useLocation } from 'react-router-dom';
import './Navbar.css';
import logo from '../images/logomicschimbat.png';

const Navbar = ({ isLoggedIn }) => {
  const [clicked, setClicked] = useState(false);
  const location = useLocation();

  const handleClick = () => {
    setClicked(!clicked);
  };

  return (
    <nav className="navbar fixed">
      <Link to="/">
        <img
          src={logo}
          alt="Logo"
          className="navbar-logo"
        />
      </Link>
      <div>
        <ul id="navbar" className={clicked ? "navbar active" : "navbar"}>
          <li className={location.pathname === "/" ? "active" : ""}>
            <Link to="/">ACASA</Link>
          </li>
          <li className={location.pathname === "/about" ? "active" : ""}>
            <Link to="/about">DESPRE</Link>
          </li>
          <li className={location.pathname === "/projects" ? "active" : ""}>
            <Link to="/projects">PROIECTE</Link>
          </li>
          <li className={location.pathname === "/contact" ? "active" : ""}>
            <Link to="/contact">CONTACT</Link>
          </li>
          {isLoggedIn ? (
            <li className={location.pathname === "/profile" ? "active" : ""}>
              <Link to="/profile">PROFIL</Link>
            </li>
          ) : (
            <li className={location.pathname === "/register-login" ? "active" : ""}>
              <Link to="/register-login">INREGISTRARE/LOGARE</Link>
            </li>
          )}
        </ul>
      </div>

      <div id="mobile" onClick={handleClick}>
        <i id="bar" className={clicked ? 'fas fa-times' : 'fas fa-bars'}></i>
      </div>
    </nav>
  );
};

export default Navbar;

import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './Navbar.css';
import logo from '../images/logomicschimbat.png';

const Navbar = ({ isLoggedIn }) => {
  const [clicked, setClicked] = useState(false);

  const handleClick = () => {
    setClicked(!clicked);
  };

  return (
    <nav className="navbar fixed"> {/* Începe cu clasa fixed activată */}
      <Link to="/">
        <img
          src={logo}
          alt="Logo"
          className="navbar-logo"
        />
      </Link>
      <div>
        <ul id="navbar" className={clicked ? "navbar active" : "navbar"}>
          <li>
            <Link to="/">ACASA</Link>
          </li>
          <li>
            <Link to="/about">DESPRE</Link>
          </li>
          <li>
            <Link to="/projects">PROIECTE</Link>
          </li>
          <li>
            <Link to="/contact">CONTACT</Link>
          </li>
          {isLoggedIn ? (
            <li>
              <Link to="/profile">PROFIL</Link>
            </li>
          ) : (
            <li>
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

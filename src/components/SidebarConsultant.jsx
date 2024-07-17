import React from 'react';
import { Link } from 'react-router-dom';
import './SidebarDirector.css'; // Assuming the CSS file is in the same directory

const SidebarConsultant = () => {
  return (
    <div className="sidebar-container">
      <nav className="main-menu">
        <div>
          <a className="logo"></a>
        </div>
        <div className="settings"></div>
        <div className="scrollbar" id="style-1">
          <ul>
            <li>
            <Link to="/consultant-menu/profil">
                <i className="fa fa-user fa-lg"></i>
                <span className="nav-text">Profil</span>
              </Link>
            </li>
            
            <li>
            <Link to="/consultant-menu/clienti">
                <i className="fa fa-user fa-lg"></i>
                <span className="nav-text">Clienti</span>
                </Link>
            </li>
            <li>
            <Link to="/consultant-menu/contracte">
                <i className="fa fa-align-left fa-lg"></i>
                <span className="nav-text">Contractele mele</span>
                </Link>
            </li>
            <li>
            <Link to="/consultant-menu/configurari">
                <i className="fa fa-user fa-lg"></i>
                <span className="nav-text">Configurari Case Clienti</span>
                </Link>
            </li>
            <li>
            <Link to="/consultant-menu/case">
                <i className="fa fa-home fa-lg"></i>
                <span className="nav-text">Case destinate vanzarii</span>
                </Link>
            </li>
            
          </ul>
        </div>
      </nav>
    </div>
  );
};

export default SidebarConsultant;

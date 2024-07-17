import React from 'react';
import { Link } from 'react-router-dom';
import './SidebarDirector.css'; // Assuming the CSS file is in the same directory

const SidebarDirector = () => {
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
            <Link to="/director-menu/profil">
                <i className="fa fa-user fa-lg"></i>
                <span className="nav-text">Profil</span>
              </Link>
            </li>
            <li>
              <Link to="/director-menu/proiecte">
                <i className="fa fa-home fa-lg"></i>
                <span className="nav-text">Proiecte</span>
              </Link>
            </li>
            <li>
            <Link to="/director-menu/clienti-si-angajati">
                <i className="fa fa-user fa-lg"></i>
                <span className="nav-text">Clienti si angajati</span>
                </Link>
            </li>
            <li>
            <Link to="/director-menu/contracte">
                <i className="fa fa-align-left fa-lg"></i>
                <span className="nav-text">Contracte</span>
                </Link>
            </li>
            <li>
            <Link to="/director-menu/constructii">
                <i className="fa fa-sign-out"></i>
                <span className="nav-text">Asignare echipa constructii</span>
                </Link>
            </li>
          </ul>
        </div>
      </nav>
    </div>
  );
};

export default SidebarDirector;

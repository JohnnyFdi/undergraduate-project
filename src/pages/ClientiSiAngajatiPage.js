import React from 'react';
import Clienti from '../components/Clienti';
import Angajati from '../components/Angajati';
import SidebarDirector from '../components/SidebarDirector';
import './ClientiSiAngajati.css';

const ClientiSiAngajatiPage = () => {
  return (
    <div className="page-container">
      
      <Clienti />
      <Angajati />
    </div>
  );
};

export default ClientiSiAngajatiPage;
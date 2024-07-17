import React from 'react';

import SidebarConsultant from '../components/SidebarConsultant';
import { Routes, Route } from 'react-router-dom';

import ProfilePageConsultant from '../pages/ProfilePageConsultant';

import ClientiPage from './ClientiPage';
import ConfigurariCasePage from './ConfigurariCasePage';
import CasePage from './CasePage';
import ContractePage from './ContractePage';



const ConsultantPage = () => {
  return (
    <div>
      <SidebarConsultant />
      <Routes>
      <Route path="profil" element={<ProfilePageConsultant />} />
      <Route path="clienti" element={<ClientiPage />} />
      <Route path="configurari" element={<ConfigurariCasePage />} />
      <Route path="contracte" element={<ContractePage/>} />
      <Route path="case" element={<CasePage/>} />
      
      
      
      
      
        
      </Routes>
    </div>
  );
};

export default ConsultantPage;
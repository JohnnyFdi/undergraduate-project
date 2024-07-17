// DirectorPage.js
import React from 'react';
import { Routes, Route } from 'react-router-dom';

import SidebarDirector from '../components/SidebarDirector';
import ProiectePage from '../pages/ProiectePage';
import ProfilePage from '../pages/ProfilePage';
import ClientiSiAngajatiPage from './ClientiSiAngajatiPage';
import AsignareConstructoriPage from './AsignareConstructoriPage';
import ContracteDirectorPage from './ContracteDirectorPage';

const DirectorPage = () => {
  return (
    <div>
      <SidebarDirector />
      <Routes>
      <Route path="profil" element={<ProfilePage />} />
      <Route path="proiecte" element={<ProiectePage />} />
      <Route path="clienti-si-angajati" element={<ClientiSiAngajatiPage />} />
      <Route path="constructii" element={<AsignareConstructoriPage />} />
      <Route path="contracte" element={<ContracteDirectorPage />} />
      </Routes>
    </div>
  );
};

export default DirectorPage;

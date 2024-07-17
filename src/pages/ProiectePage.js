import React from 'react';
import Proiecte from '../components/Proiecte';
import SidebarDirector from '../components/SidebarDirector';
import ProiecteView from '../components/ProiecteView';

const ProiectePage = () => {
  return (
    <div className="page-container">
      <ProiecteView />
      <Proiecte />
    </div>
  );
};

export default ProiectePage;
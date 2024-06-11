import React from 'react';
import PrezentareAbout from '../components/PrezentareAbout';
import Despre from '../components/Despre';
import Experienta from '../components/Experienta';
import Despre2 from '../components/Despre2';
import ContactRedirection from '../components/ContactRedirection';
import Angajati from '../components/Angajati';

function HomePage() {
  return (
    <div>
      <PrezentareAbout />
      <Despre />
      <Experienta />
      <Despre2 />
      <ContactRedirection />
      <Angajati />
    </div>
  );
}

export default HomePage;


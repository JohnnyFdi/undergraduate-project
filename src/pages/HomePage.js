import React from 'react';
import Prezentare from '../components/Prezentare';
import CardSlider from '../components/CardSlider';
import FertuDragosIonut from '../components/FertuDragosIonut';
import Prezentare2 from '../components/Prezentare2';
import Experienta from '../components/Experienta';
import PrezentareGalati from '../components/PrezentareGalati';
import Testimoniale from '../components/Testimoniale';
import ContactRedirection from '../components/ContactRedirection';

function HomePage() {
  return (
    <div>
      <Prezentare />
      <CardSlider />
      <FertuDragosIonut />
      <Prezentare2 />
      <Experienta />
      <PrezentareGalati />
      <Testimoniale />
      <ContactRedirection />
    </div>
  );
}

export default HomePage;


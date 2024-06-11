import React from 'react';
import './PrezentareAbout.css'; // Fișierul de stil pentru a gestiona responsive-ul
import prez2 from '../images/houseplanning2.jpg';


function PrezentareAbout() {
    
  return (
    <div className="prezentare-about-container">
      <img src={prez2} alt="Imagine" className="prezentare-about" />
      <div className="image-about-text">
        <h3>
        Construim visul tău. <br />
        Împreună scriem viitorul.</h3> <br />
        <p>Dincolo de locuințe, ne-am propus să le oferim clienților noștri un stil de viață. Comunitățile ridicate de Fine Design Imobiliare în punctele cheie ale Galațiului ajung să arate ca adevărate opere în interiorul orașelor, 
           locuri ideale pentru familii tinere, oaze de liniște pentru vârstnici, oferind o atmosferă de unitate și comuniune.
        </p>
      </div>
    </div>
  );
}

export default PrezentareAbout;
import React from 'react';
import './Prezentare2.css'; // Fișierul de stil pentru a gestiona responsive-ul
import prez2 from '../images/blocnou.jpg';
import { Link } from 'react-router-dom';
function Prezentare2() {
    
  return (
    <div className="prezentare2-container">
      <img src={prez2} alt="Imagine" className="prezentare2" />
      <div className="image2-text">
        <h3>
        Construim visul tău. <br />
        Împreună scriem viitorul.</h3> <br />
        <p>Dincolo de locuințe, ne-am propus să le oferim clienților noștri un stil de viață. Comunitățile ridicate de Fine Design Imobiliare în punctele cheie ale Galațiului ajung să arate ca adevărate opere în interiorul orașelor, 
           locuri ideale pentru familii tinere, oaze de liniște pentru vârstnici, oferind o atmosferă de unitate și comuniune.
        </p> <br /> <br />
        <Link to="/about" className="buton-misto"><span>Află mai multe</span></Link>
      </div>
    </div>
  );
}

export default Prezentare2;
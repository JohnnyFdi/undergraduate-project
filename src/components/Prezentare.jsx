import React from 'react';
import './Prezentare.css'; // Fișierul de stil pentru a gestiona responsive-ul
import prez from '../images/galatipeisaj2.jpg';
function Prezentare() {
    
  return (
    <div className="prezentare-container">
      <img src={prez} alt="Imagine" className="prezentare" />
      <div className="image-text">
        <h2>
        Noi construim visurile tale. <br />
        Povestea ta începe cu <span class="subliniat-prezentare">Fine Design Imobiliare</span></h2>
        <p>Aici începe visul tău. Acum este momentul în care dorințele tale caută forma locului pe care să îl numești „acasă”. <br />
           Lasă-te purtat de experiența FDImobiliare în lumea constructorilor de visuri.
        </p>
        
      </div>
    </div>
  );
}

export default Prezentare;
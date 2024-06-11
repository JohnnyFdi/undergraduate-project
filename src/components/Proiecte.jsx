import './Proiecte.css';
import { Link } from 'react-router-dom';
import casa from '../images/casa/casa.jpg';






const Proiecte = () => {
    
  return (
  <div className="proiecte-wrapper">
    <div className="casa-container">
       <div className="descriere" id="des1">
         <h1>Noi va construim casa!</h1> <br />
         <h3>Oferim mai mult decât apartamente gata-făcute - echipa noastră și materialele de înaltă calitate
           sunt aici pentru a vă ajuta să vă transformați visurile în realitate.
         </h3>
       </div>
       <div className="descriere" id="des2">
        <img src={casa} alt="Casa" /> <br />
        <Link to="/config-casa" className="buton-case"><span>Configurează-ti propria casa!</span></Link>
       </div> 
       <div className="descriere" id="des3">
          <h1>FDImobiliare - Unde fiecare cărămidă spune o poveste.</h1> <br />
         <h3>Descoperă casele noastre personalizate, create cu pasiune pentru a-ți împlini visul de o locuință perfectă!"
         </h3>
       </div>  
    </div>
    
  </div>
  );
}

export default Proiecte;
import React from 'react';
import ReactPlayer from 'react-player';
import './PrezentareGalati.css'; // Fișierul de stil pentru a gestiona responsive-ul
import aer from '../images/cleanairicon.png';
import munca from '../images/workicon.png';
import facilitati from '../images/shopicon.png';
import spatii from '../images/greenpng.png';
import infrastructura from '../images/roadicon.png';
function PrezentareGalati() {
    
  return (
    <div className="prezentare-galati-container">
        <div className="prezentare-galati-1">
            <div className="motive-container">
                <h2>De ce sa alegi Galațiul?</h2>
                <h3>Uite cateva motive pentru care sa alegi Galati in detrimentul altor orase.</h3>
                <br/>

                <div className="motiv">
                  <img src={aer} alt="Aer" />
                  <p>aer curat (poluarea este semnificativ scazuta comparativ cu restul tarii)</p>
                </div>
                <div className="motiv">
                  <img src={munca} alt="Munca" />
                  <p>locuri de munca bine platite (salariul mediu e 5200 lei NET)</p>
                </div>
                <div className="motiv">
                  <img src={facilitati} alt="Facilitati" />
                  <p>facilitati asezate in avantajul dvs</p>
                </div>
                <div className="motiv">
                  <img src={spatii} alt="Spatii" />
                  <p>multe spatii verzi si locuri destinate relaxarii</p>
                </div>
                <div className="motiv">
                  <img src={infrastructura} alt="Infrastructura" />
                  <p>infrastructura realizata cu simt de raspundere</p>
                </div>
                
                
                
                
                
            </div>
        </div>
        <div className="prezentare-galati-2">
          <div className="player-wrapper">
            <ReactPlayer light={true} controls={true} url='https://www.youtube.com/watch?v=T5vqRvfE6Rc&t=447s' 
            height="100%" width="100%"/>
          </div>
        </div>
    </div>
  );
}

export default PrezentareGalati;
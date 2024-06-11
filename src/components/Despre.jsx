import React from 'react';
import './Despre.css'; 


const Despre = () => {
  return (
    <div className="despre-wrapper">
        <div class="despre-container">
            <h2>Planificăm<span id="punct">.</span></h2> <br />
            <p>Nu credem în șabloane aplicabile pentru fiecare proiect în parte. De aceea, planificăm în detaliu fiecare structură, fiecare compartimentare, fiecare bloc,
                pentru a se plia pe nevoile și cerințele tale. Așa se face că ansamblurile noastre poartă amprenta pe care tu ai dat-o proiectelor noastre.</p>
        </div>
        <div class="despre-container">
            <h2>Construim<span id="punct">.</span></h2> <br />
            <p>Ridicăm, în fiecare zi, mai mult decât locuințe. Construim un drum, un model de viață, un model de gândire care să arate că fiecare dintre noi poate să
                fie schimbarea pentru acestă lume. Suntem conștienți de responsabilitatea așezată pe umerii noștri: suntem aici pentru tine, pentru a-ți aduce la lumină visul.</p>
        </div>
        <div class="despre-container" id="chenar">
            <h2>„Am făcut o promisiune și o voi duce la capăt”</h2> <br />
            <p>Realizez în fiecare zi că mii de oameni ne-au oferit încrederea lor, și au pus în mâinile noastre poate unul din cele mai prețioase visuri: acela de a avea un ”acasă”.</p>
            <br /> <p id="nume">Fertu Dragos Ionut</p>
        </div>
    </div>
  );
};

export default Despre;
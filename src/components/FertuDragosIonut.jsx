import React from 'react';
import './FertuDragosIonut.css'; 
import fdi from '../images/eu.jpg';
import semnatura from '../images/semnatura3.png'

const FertuDragosIonut = () => {
  return (
    <div className="container">
    <div className="container-fertu">
      <div className="image-container">
      <img src={fdi} alt="Imagine" />
      </div>
      <div className="text-container">
        <h1>„Învingătorii nu renunță, iar cei care renunță nu ajung învingători”</h1>
        <h2>Aristotel</h2> <br />
        <p>”Într-o lume în care nepăsarea și tendința de a renunța se află la tot pasul, noi am ales să continuăm. În momentele în care ne-am simțit mai vulnerabili, ne-am unit forțele și am găsit în voi toate motivele pentru a ne ridica și pentru a merge mai departe.
        Am pornit la drum împreună, am depășit diverse dificultăți și am crescut continuu. Am devenit o comunitate puternică și unită, la baza căreia au stat miile de visuri devenite, azi, realitate. Muncim să devenim tot mai buni și chiar dacă nu suntem perfecți avem ca obiectiv atingerea perfecțiunii. Ne pasă de ceea ce credeți. Transformăm criticile voastre în opinii constructive care ne oferă avântul să ne autodepășim și să devenim tot mai buni cu fiecare zi ce trece.
        Vocea voastră e importantă! Vocea voastră e ascultată! Avem nevoie de voi! Vă asigur că vă rămân aproape pentru ca această comunitate să înflorească, să capete culoare, să se numească ACASĂ și să fie un loc mai bun pentru copiii noștri.
        Și pentru că suntem o familie, ușa noastră este larg deschisă pentru oricine crede că poate clădi visuri alături de noi”.
        Fă un pas înainte! Viitorul îl putem construi ÎMPREUNĂ.</p> <br />
        <img src={semnatura} alt="semn" />
    </div>
      
    </div>
    </div>
  );
};

export default FertuDragosIonut;

// 
import React, { useRef, useState } from 'react';
// Import Swiper React components
import { Swiper, SwiperSlide } from 'swiper/react';

import casaExemplu2 from '../images/casa/casaexemplu2.jpg';
import casaExemplu1 from '../images/casa/casaexemplu1.webp';
import casaExemplu3 from '../images/casa/casaexemplu3.webp';
import casaExemplu4 from '../images/casa/casaexemplu4.webp';

// Import Swiper styles
import 'swiper/css';
import 'swiper/css/effect-fade';
import 'swiper/css/navigation';
import 'swiper/css/pagination';

import './ConfiguratorCasa.css';

// import required modules
import { EffectFade, Navigation, Pagination, Autoplay } from 'swiper/modules';

export default function ConfiguratorCasa() {
  return (
  <div className="pre-config">
    <div className="slider-wrapper">
      <Swiper
        spaceBetween={30}
        effect={'fade'}
        navigation={true}
        pagination={{
          clickable: true,
        }}
        autoplay={{
          "delay": 7000,
          "disableOnInteraction": false
        }}
        modules={[EffectFade, Navigation, Pagination, Autoplay]}
        className="mySwiper"
      >
        <SwiperSlide>
          <img src={casaExemplu2} alt="Casa Exemplu 2"/>
          <div className="text-overlay">
            <h2>Cladeste casa visurior tale!</h2>
            <p>Stim ca deasupra capului tau doresti un acoperis stabil.</p>
          </div>
        </SwiperSlide>
        <SwiperSlide>
        <img src={casaExemplu1} alt="Casa Exemplu 1"/>
        <div className="text-overlay">
            <h2>Materiale de cea mai inalta calitate!</h2>
            <p>Oferim garantie de 30 de ani pe lucrarile noastre.</p>
          </div>
        </SwiperSlide>
        <SwiperSlide>
        <img src={casaExemplu3} alt="Casa Exemplu 3"/>
        <div className="text-overlay">
            <h2>Preturi corecte si accesibile.</h2>
            <p>Raportul pret calitate este unul de neegalat.</p>
          </div>
        </SwiperSlide>
        <SwiperSlide>
        <img src={casaExemplu4} alt="Casa Exemplu 4"/>
        <div className="text-overlay">
            <h2>Design pe gustul proprietarului.</h2>
            <p>Avem grija ca totul sa iasa exact dupa preferintele tale.</p>
          </div>
        </SwiperSlide>
      </Swiper>
    </div>
    <div className="info-config">
      <div className="info-content">
        <h1>Citeste inainte de a configura!</h1>
        <h2>Acest configurator are ca scop estimarea pretului casei dorite de dumneavoastra.
          <br /> Daca sunteti hotarat si doriti sa incepem demersul lucrarilor puteti apasa butonul de mai jos indata ce
          v-ati creat un cont sau contactati-ne. 
        </h2>
        <h1>ATENTIE!</h1>
        <h2>Casa configurata NU include costuri ce tin de achizitionarea terenului si nici obiectele de mobilier.</h2>
        <h2>Preturile incalzirii, ventilatiei si colectarii de reziduuri sunt medii in acest configurator. Ele se stabilesc de fapt in functie de complexitatea lucrarii. </h2>
        <h1>Informatii:</h1>
        <h3>Pretul de pornire al suprafetei este de 500 de euro pe metru patrat.</h3>

        <h2>Materiale:</h2>
        <h3>BCA</h3>
        <p>Preț: BCA-ul se calculeaza inmultind suprafata cu 1.0 <br />
Avantaje: Este mai ușor, ceea ce facilitează manevrarea și reduce costurile de transport. Are bune proprietăți de izolație termică și poate reduce costurile de încălzire/răcire. <br />
Dezavantaje: Este mai puțin rezistent la compresiune decât cărămida și poate necesita mai multe măsuri pentru a proteja împotriva umidității.</p>
        <h3>Caramida Rosie</h3>
        <p>Preț: Caramida se calculeaza inmultind suprafata cu 1.5 <br />
Avantaje: Este foarte rezistentă la compresiune, oferă o bună izolație fonică și are o durabilitate mare.<br />
Dezavantaje: Este mai grea și necesită mai mult mortar pentru zidire, ceea ce poate crește costurile totale de construcție.</p>

  <h2>Finisaje:</h2>
  <h3>Standard:</h3>
  <p>Caracteristici:<br />

  • Pardoseli laminate de bază sau gresie standard<br />
  • Pereți vopsiți în culori neutre<br />
  • Uși interioare din lemn masiv sau MDF simple<br />
  • Faianta și gresie de calitate medie în băi și bucătării<br />
  • Ferestre termopan standard<br /><br />
  Preț: Finisajul standard se calculeaza inmultind suprafata cu 1.0 
  </p>
  <h3>Premium:</h3>
  <p>Caracteristici:<br />

  • Pardoseli din parchet stratificat de calitate superioară sau gresie porțelanată<br />
  • Pereți vopsiți cu vopsea de calitate superioară, cu eventuale efecte decorative<br />
  • Uși interioare din lemn masiv cu design modern<br />
  • Faianta și gresie de calitate superioară, cu modele contemporane<br />
  • Ferestre termopan cu izolație fonică și termică sporită<br /> <br />
Preț: Finisajul Premium se calculeaza inmultind suprafata cu 2.0 <br /> </p>
<h3>De Lux:</h3>
  <p>Caracteristici:<br />

  • Pardoseli din parchet masiv exotic sau marmură<br />
  • Pereți vopsiți cu vopsea premium sau tapet de designer<br />
  • Uși interioare din lemn masiv sculptat sau cu inserții de sticlă și metal<br />
  • Faianta și gresie de designer, eventual personalizate<br />
  • Ferestre cu geamuri tripan, cu izolație fonică și termică maximă, cadre din lemn stratificat sau aluminiu<br /> <br />
Preț: Finisajul de Lux se calculeaza inmultind suprafata cu 3.5 <br /> </p>

<h2>Incalzire:</h2>
<h3>Centrala termica (pe gaz):</h3>
<p>Caracteristici:<br />

  • Eficiență energetică: Moderată până la ridicată (85%-95%).<br />
  • Costuri de operare: Relativ scăzute datorită prețului mai mic al gazului natural comparativ cu energia electrică.<br />
  • Întreținere: Necesită întreținere anuală pentru siguranță și eficiență optimă.<br />
  • Emisii: Produce emisii de CO2, deci are un impact asupra mediului.<br />
   <br />
Preț (achizitie + instalare): 1500 - 4500 euro<br /> </p>
<h3>Centrala termica (electrica):</h3>
<p>Caracteristici:<br />

  • Eficiență energetică: Foarte ridicată (100% deoarece toată energia electrică este transformată în căldură).<br />
  • Costuri de operare: Mai mari, din cauza prețului ridicat al energiei electrice.<br />
  • Întreținere: Minimală, fără emisii de gaze.<br />
  • Instalare: Ușoară și nu necesită conducte de gaz.<br />
   <br />
Preț (achizitie + instalare): 800 - 3000 euro<br /> </p>
<h3>Pompa de caldura aer-aer:</h3>
<p>Caracteristici:<br />

  • Eficiență energetică: Foarte ridicată (COP 3-5, adică pentru fiecare unitate de energie electrică, produce 3-5 unități de căldură).<br />
  • Costuri de operare: Mai mici comparativ cu centralele electrice, dar mai mari decât cele pe gaz.<br />
  • Versatilitate: Poate fi folosită și pentru răcire vara.<br />
  • Instalare: Moderată în complexitate, cu unități interioare și exterioare.<br />
   <br />
Preț (achizitie + instalare): 4000 - 9000 euro<br /> </p>
<h3>Pompa de caldura aer-apa:</h3>
<p>Caracteristici:<br />

  • Eficiență energetică: Foarte ridicată (COP 3-5).<br />
  • Costuri de operare: Relativ scăzute datorită eficienței ridicate.<br />
  • Versatilitate: Poate furniza atât încălzire cât și apă caldă menajeră.<br />
  • Instalare: Complexă, necesitând o unitate exterioară și una interioară.<br />
   <br />
Preț (achizitie + instalare): 6000 - 15000 euro<br /> </p>
<h3>Pompa de caldura sol-apa:</h3>
<p>Caracteristici:<br />

  • Eficiență energetică: Extrem de ridicată (COP 4-6).<br />
  • Costuri de operare: Cele mai mici pe termen lung datorită eficienței energetice.<br />
  • Fiabilitate: Stabilitate foarte bună a temperaturii pe tot parcursul anului.<br />
  • Instalare: Foarte complexă și costisitoare, necesită foraj sau excavare pentru colectoarele de sol.<br />
   <br />
Preț (achizitie + instalare): 13000 - 30000 euro<br /> </p>
<h3>Soba modernă pe lemne/pellet</h3>
<p>Caracteristici:<br />

  • Eficiență energetică: Moderată (70%-90%).<br />
  • Costuri de operare: Scăzute dacă lemnul sau peleții sunt ieftini și ușor de obținut.<br />
  • Întreținere: Necesită curățarea regulată a cenușii și întreținerea coșului de fum.<br />
  • Impact asupra mediului: Emisii de particule și CO2, dar poate fi considerată neutră din punct de vedere al carbonului dacă este utilizat lemn din surse regenerabile.<br />
   <br />
Preț (achizitie + instalare): 700 - 4000 euro<br /> </p>
<h3>Soba modernă pe gaz</h3>
<p>Caracteristici:<br />

  • Eficiență energetică: Ridicată (80%-90%).<br />
  • Costuri de operare: Moderate datorită prețului gazului.<br />
  • Întreținere: Minimă, fără cenușă și cu întreținere redusă a coșului de fum.<br />
  • Instalare: Necesită conectare la rețeaua de gaz.<br />
   <br />
Preț (achizitie + instalare): 1500 - 5500 euro<br /> </p>

<h2>Ventilatie:</h2>
<h3>Naturala:</h3>
<p>Caracteristici:<br />

  • Utilizează ferestre, grile de ventilație și deschideri pentru a permite circulația aerului.<br />
  • Fără componente mecanice, se bazează pe fluxul natural de aer<br /> <br />
  Avantaje:<br /> 
  • Costuri inițiale și de operare reduse<br />
  • Fără necesitatea unei întrețineri complexe<br /><br />
  Dezavantaje:<br />
  • Ineficientă în controlul calității aerului interior<br />
  • Dependență de condițiile meteorologice<br />
   <br />
Preț (achizitie + instalare): 50 - 200 euro<br /> </p>
<h3>Mecanica Simplă:</h3>
<p>Caracteristici:<br />

  • Utilizează ventilatoare pentru a extrage aerul din încăperi (de obicei din bucătării și băi)<br />
  • Creează un flux de aer prin casă prin intermediul grilelor de admisie<br /> <br />
  Avantaje:<br /> 
  • Îmbunătățește controlul ventilației față de ventilația naturală<br />
  • Relativ ușor de instalat și de întreținut<br /><br />
  Dezavantaje:<br />
  • Poate crea presiune negativă în casă, aducând aer din exterior prin fisuri necontrolate<br />
   <br />
Preț (achizitie + instalare): 300 - 1000 euro<br /> </p>
<h3>Mecanică Controlată (VMC):</h3>
<p>Caracteristici:<br />

  • Utilizează ventilatoare pentru a introduce aer proaspăt și a extrage aerul viciat<br />
  • Sistemele sunt de obicei echipate cu filtre pentru a curăța aerul introdus<br /> <br />
  Avantaje:<br /> 
  • Control mai bun al calității aerului interior<br />
  • Poate include filtre pentru a îmbunătăți calitatea aerului<br /><br />
  Dezavantaje:<br />
  • Consum de energie electrică<br />
  • Necesită întreținere periodică a filtrelor<br />
   <br />
Preț (achizitie + instalare): 1000 - 3000 euro<br /> </p>
<h3>Mecanică cu Recuperare de Căldură (VMC-R)</h3>
<p>Caracteristici:<br />

  • Sistem avansat de ventilație care recuperează căldura din aerul extras pentru a încălzi aerul introdus<br />
  • Eficient energetic, reduce pierderile de căldură<br /> <br />
  Avantaje:<br /> 
  • Cel mai eficient în termeni de economisire a energiei<br />
  • Îmbunătățește semnificativ calitatea aerului interior<br />
  • Reduce costurile de încălzire pe termen lung<br /><br />
  Dezavantaje:<br />
  • Costuri inițiale și de instalare mai mari<br />
  • Necesită întreținere periodică și schimbarea filtrelor<br />
   <br />
Preț (achizitie + instalare): 2500 - 8000 euro<br /> </p>

<h2>Colectare de reziduuri:</h2>
<h3>Canalizare</h3>
<p>Caracteristici:<br />

  • Sistem public de colectare și tratare a apelor uzate<br />
  • Conectează locuințele la rețeaua de canalizare municipală<br />
  • Apele uzate sunt transportate la o stație de epurare pentru tratare<br />  <br />
  Avantaje:<br /> 
  • Gestionare centralizată a apelor uzate<br />
  • Întreținere minimă pentru proprietar<br />
  • Servicii de tratare a apelor uzate asigurate de municipalitate<br /><br />
  Dezavantaje:<br />
  • Disponibilitate limitată în zonele rurale sau izolate<br />
  • Costuri de conectare și utilizare regulate<br />
  • Dependență de infrastructura publică<br />
   <br />
Preț (conectare la retea): 500 - 2000 euro<br /> </p>

<h3>Fosa Septică</h3>
<p>Caracteristici:<br />

  • Sistem individual de tratare a apelor uzate, instalat pe proprietatea privată<br />
  • Apele uzate sunt colectate într-un rezervor subteran (fosa septică), unde sunt separate solidele de lichide<br />
  • Lichidele sunt deversate în sol prin intermediul unui câmp de drenaj (drenaj subteran)<br />  <br />
  Avantaje:<br /> 
  • Independență față de rețeaua de canalizare publică<br />
  • Potrivită pentru zonele rurale sau izolate<br />
  • Costuri de operare mai mici pe termen lung<br /><br />
  Dezavantaje:<br />
  • Necesită teren adecvat pentru instalare<br />
  • Întreținere periodică necesară (vidanjare la fiecare 3-5 ani)<br />
  • Potențial risc de contaminare a apei subterane dacă nu este instalată corect<br />
   <br />
Preț (instalare): 2000 - 10000 euro<br /> </p>

<h3>Incalzirea in pardoseala:</h3>
<h2>Încălzirea în pardoseală cu apă (hidronică):</h2>
<p>Caracteristici:<br />

  • Eficiență energetică: Foarte ridicată, mai ales dacă este combinată cu o sursă de energie eficientă, cum ar fi o pompă de căldură sau un cazan modern.<br />
  • Costuri de instalare: Mai ridicate decât sistemele electrice, între 30-80 euro/m², din cauza complexității sistemului și a necesității unui boiler sau a unei pompe de căldură.<br />
  • Costuri de operare: Scăzute, în special dacă se utilizează gaz natural, peleți sau pompe de căldură, care sunt mai economice pe termen lung. <br />
  • Instalare: Mai complexă, necesită planificare și expertiză specializată, potrivită pentru construcții noi sau renovări majore. <br />
  • Întreținere: Moderată, include verificări periodice ale sistemului și întreținerea boilerului sau a pompei de căldură. <br />
  <br/>
   </p>
<p>Se poate instala in orice camera, dupa preferinte si se calculeaza inmultind suprafata camerei respective cu 1.1 <br />
</p>

      </div>
    </div>
  </div>
  );
}

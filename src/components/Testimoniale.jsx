import React from 'react';
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import './Testimoniale.css'; 
import stefan from '../images/persoane/StefanChirila.jpg';
import ionut from '../images/persoane/IonutAlex.jpg';
import sergiu from '../images/persoane/SergiuDumitrasc3.jpg';
import dorian from '../images/persoane/DorianPopa.jpg';
import pompi from '../images/persoane/AlexPompile.jpg';
import vasile from '../images/persoane/VasileBenea2.jpg';
import Slider from 'react-slick';

function Testimoniale() {
  var settings = {
    dots: true,
    infinite: false,
    speed: 500,
    slidesToShow: 3,
    slidesToScroll: 3,
    initialSlide: 0,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          infinite: true,
          dots: true
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          //initialSlide: 2
        }
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }
    ]
  };
    
  return (
    <div className="testimoniale-wrapper">
        <div className="titlu-container">
          <h1>Ce spun clienții noștri</h1>
          <h3>Îndrăznește. Visează. Crede.</h3>
        </div>
    <div className="slider-container">
      <Slider {...settings}>
        <div className="persoane">
          <div className="profil">
            <img src={stefan} alt="Stefan" />
            <h3>Stefan Chirila</h3>
          </div>
          <div className="pareri">
            <p>Experiența cu FDImobiliare a fost una extraordinară! Am găsit apartamentul perfect pentru familia noastră într-un timp record.
               Echipa lor a fost extrem de profesionistă și amabilă de la prima întâlnire până la semnarea contractului.
                Recomand cu căldură serviciile lor tuturor celor în căutarea unei locuințe de calitate!
            </p>
          </div>
        </div>
        <div className="persoane">
          <div className="profil">
            <img src={ionut} alt="Ionut" />
            <h3>Ionut Necula</h3>
          </div>
          <div className="pareri">
            <p>Am cumpărat recent o casă prin intermediul FDImobiliare și sunt extrem de mulțumit de întregul proces.
               Agentul nostru a fost foarte atent la cerințele noastre și ne-a prezentat mai multe opțiuni care se potriveau perfect nevoilor noastre.
                Totul a decurs fără probleme, iar acum suntem fericiți proprietari ai unei case minunate. Mulțumim FDImobiliare!"
            </p>
          </div>
        </div>
        <div className="persoane">
          <div className="profil">
            <img src={sergiu} alt="Sergiu" />
            <h3>Sergiu Dumitrasc</h3>
          </div>
          <div className="pareri">
            <p>Serviciile oferite de FDImobiliare au depășit cu mult așteptările noastre. Am fost în căutarea unei locuințe potrivite pentru investiție și echipa lor ne-a ghidat pas cu pas în procesul de achiziție.
               Profesionalismul lor și atenția la detalii ne-au convins să lucrăm cu ei și nu am putea fi mai mulțumiți de rezultate.
                Recomandăm cu încredere FDImobiliare tuturor celor în căutarea unei afaceri imobiliare de succes </p>
          
          </div>
        </div>
        <div className="persoane">
          <div className="profil">
            <img src={dorian} alt="Dorian" />
            <h3>Dorian Pompa</h3>
          </div>
        
        <div className="pareri">
            <p>FDImobiliare ne-a ajutat să găsim apartamentul perfect pentru nevoile noastre. Echipa lor a fost mereu disponibilă să răspundă întrebărilor noastre și să ne ofere sfaturi utile pe tot parcursul procesului de achiziție.
               Suntem foarte recunoscători pentru profesionalismul și dedicarea lor și nu ezităm să îi recomandăm și altora în căutarea unei experiențe imobiliare plăcute și fără stres </p>
              </div>
        </div>
        <div className="persoane">
          <div className="profil">
            <img src={pompi} alt="Alex" />
            <h3>Alex Pompi</h3>
          </div>
          <div className="pareri">
            <p>Colaborarea cu FDImobiliare a fost una excepțională! În căutarea unei case potrivite pentru familia noastră, am fost întâmpinați cu răbdare și atenție la fiecare detaliu. Echipa lor a fost mereu promptă și profesionistă,
               iar rezultatul a fost o experiență imobiliară fără probleme și o nouă locuință care ne încântă în fiecare zi. Recomandăm cu încredere FDImobiliare pentru oricine caută o experiență imobiliară de calitate.</p>
          
          </div>
        </div>
        <div className="persoane">
          <div className="profil">
            <img src={vasile} alt="Vasile" />
            <h3>Vasile Benea</h3>
          </div>
          <div className="pareri">
            <p>După câteva experiențe neplăcute cu alte agenții imobiliare, am avut norocul să întâlnim echipa de la FDImobiliare. 
              Profesionalismul și atenția lor la nevoile noastre au făcut întregul proces de achiziție a casei noastre mult mai ușor și mai plăcut.
               Recomandăm cu căldură FDImobiliare tuturor celor în căutarea unei echipe de încredere în domeniul imobiliar.</p>
          
          </div>
        </div>
      </Slider>
    </div>
      
  </div>
  );
}

export default Testimoniale;
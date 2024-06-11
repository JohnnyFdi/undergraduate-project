
import './Contact.css';
import location2 from '../images/location-icon2.png'; 
import phone2 from '../images/phone-icon2.png'; 
import mail2 from '../images/mail2.png';
import support from '../images/support-contact2.png'; 



const Contact = () => {
    
  return (
  <div className="contact-wrapper">
    <div className="contact-mare-container">
      <div className="contact-container" id="ani">
        <div className="icon-div">
        <img src={location2} alt="People" />
        </div>
        <div className="contact-info">
           <br /> <h1>ADRESA</h1>
        </div>
        <div className="contact-text">
            <br />
            <h3>str. Cluj 45 bl. Doja 2, parter, Galați 800288</h3>
            <br /> <p>Ne gasiti vis-a-vis de Liceul Teoretic "Sfanta Maria". </p>
        </div>
      </div>
      <div className="contact-container" id="proiecte">
        <div className="icon-div">
        <img src={phone2} alt="Pencil" />
        </div>
        <div className="contact-info">
            <br />  <h1>TELEFON</h1>
        </div>
        <div className="contact-text">
            <br />  <h3>0268.255.193</h3>
                    <h3>0726.332.222</h3>
            <br />
            <p>Intre orele 08:00 - 20:00 linia noastra telefonica va sta la dispozitie. </p>
        </div>
      </div>
      <div className="contact-container" id="orase">
        <div className="icon-div">
        <img src={mail2} alt="Town" />
        </div>
        <div className="contact-info">
        <br /> <h1>EMAIL</h1>
        </div>
        <div className="contact-text">
            <br /> <h3>office@fdimobiliare.ro</h3>
            <br />
            <p>Pentru discutii mai ample sau care presupun incarcare de documente si imagini, contactati-ne oricand pe aceasta adresa de email. </p>
        </div>
      </div>
    </div>
    <div className="form-contact-container">
      <img src={support} alt="Support-img" className="contact-form" />
      <div className="contact-form">
        <form>
          <h3>Pentru raspunsuri rapide intrati pe contul dvs. FDImobiliare si lasati-ne un mesaj!</h3>
          <br />

                <label htmlFor="subiect">Subiect</label>
                <select id="subiect" name="subiect">
                <option value="apartamente">Apartamente</option>
                <option value="case">Case</option>
                <option value="duratacosturi">Durata si costuri</option>
                <option value="alte curiozitati">Alte curiozitati</option>
            </select>

      <label htmlFor="mesaj">Mesaj</label>
      <textarea id="mesaj" name="mesaj" placeholder="Cu ce va putem ajuta?" style={{ height: "200px" }}></textarea>

        <input type="submit" value="Trimite!" />

        </form>
      </div>
    </div>
  </div>
  );
}

export default Contact;
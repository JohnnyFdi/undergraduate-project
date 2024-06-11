import React from 'react';
import { Link } from 'react-router-dom';
import './Footer.css';
import logo from '../images/logomicschimbat.png';
import yt from '../images/footer_yt.png';
import fb from '../images/footer_fb.png';
import insta from '../images/footer_insta.png';
import tiktok from '../images/footer_tiktok.png';
import loc from '../images/location-icon.png';
import phone from '../images/phone-icon.png';
import fax from '../images/fax-phone-icon.png';
import mail from '../images/mail-icon.png';


const Footer = () => {
  return (
    <div className="footer-wrapper">
        <div className="continut-container">
            <div className="business-container">
                <img
              src={logo} // Utilizează variabila logo pentru a specifica calea către imagine
              alt="Logo"
              className="navbar-logo"
                />
                <p><br /><br />Aici începe visul tău. Acum este momentul în care dorințele tale caută forma locului pe care să îl numești „acasă”.</p>
                <p><br /><br /><br /><Link to="/termeni-si-conditii">Termeni si conditii</Link> / <Link to="/politica-de-cookies">Politica de cookies</Link> /
                 <a href="https://www.anpc.ro"> A.N.P.C</a> / <Link to="/avertizare-de-integritate">Avertizare de integritate</Link></p>
            </div>
            <div className="business-container">
                <h3>Date de contact</h3>
                <p><br />Pentru orice fel de întrebări/sugestii nu ezita să ne contactezi. Echipa noastră îți stă la dispoziție.<br /><br /></p>
                <div className="informatii">
                    <img src={loc} alt="Locatie" />
                    <p>Str. Brailei nr. 5, Galati, România</p>
                </div>
                <div className="informatii">
                    <img src={phone} alt="Phone" />
                    <p>0268.255.193 / 0268.255.195 / 0726.332.222</p>
                </div>
                <div className="informatii">
                    <img src={fax} alt="FaxPhone" />
                    <p>0268.255.183</p>
                </div>
                <div className="informatii">
                    <img src={mail} alt="PMail" />
                    <p>office@fdimobiliare.ro</p>
                </div>
        
            </div>
      
        </div>
        <div className="copyright-container">
            <div className="footer-bar">
                <p>© 2023 FDImobiliare. Toate drepturile rezervate.</p>
                <div className="social-media">
                    <img src={yt} alt="YouTube" />
                    <img src={fb} alt="Facebook" />
                    <img src={insta} alt="Instagram" />
                    <img src={tiktok} alt="Tiktok" />
                </div>
            </div>
        </div>
    </div>
  );
};

export default Footer;
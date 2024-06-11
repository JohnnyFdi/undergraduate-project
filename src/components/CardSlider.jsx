import React from 'react';
import './CardSlider.css';

function CardSlider() {
  return (
    <div className="header">
      <h1>Proiectele <span class="subliniat">noastre</span></h1>
      <h3>Îndrăznește. Visează. Crede.</h3> <br />
      <p>Alege unul dintre proiectele Fine Design Imobiliare pentru a găsi apartamentul tău de vis.<br />
         Suntem aici pentru TINE. Cu noi, visul tău poate deveni realitate.</p>
    <div className="wrapper">
    <div className="container-mic">
        <input type="radio" name="slide" id="c1" defaultChecked />
        <label htmlFor="c1" className="card">
            <div className="row">
                <div className="icon">1</div>
                <div className="description">
                    <h4>Bloc Doja 1</h4>
                    <p>Proiect finalizat</p>
                </div>
            </div>
        </label>
        <input type="radio" name="slide" id="c2" />
        <label htmlFor="c2" className="card">
            <div className="row">
                <div className="icon">2</div>
                <div className="description">
                    <h4>Bloc Doja 2</h4>
                    <p>Proiect finalizat</p>
                </div>
            </div>
        </label>
        <input type="radio" name="slide" id="c3" />
        <label htmlFor="c3" className="card">
            <div className="row">
                <div className="icon">3</div>
                <div className="description">
                    <h4>Bloc Flora</h4>
                    <p>Proiect finalizat</p>
                </div>
            </div>
        </label>
        <input type="radio" name="slide" id="c4" />
        <label htmlFor="c4" className="card">
            <div className="row">
                <div className="icon">4</div>
                <div className="description">
                    <h4>Proiect personalizat</h4>
                    <p>Noi iti construim casa!</p>
                </div>
            </div>
        </label>
            </div>
        </div>
    </div>
  );
}

export default CardSlider;
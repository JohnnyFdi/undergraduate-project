import React, { useState, useEffect } from 'react';
import './ConfiguratorCasa2.css'; // Fișierul de stil pentru a gestiona responsive-ul
import axios from '../api/axios';

import smallstandard from '../images/casa/standardsmall.webp';
import mediumstandard from '../images/casa/standardmedium.webp';
import largestandard from '../images/casa/standardlarge.webp';
import intstandard1 from '../images/casa/standardinterior1.webp';
import intstandard2 from '../images/casa/standardinterior2.webp';

import smallpremium from '../images/casa/premiumsmall.webp';
import mediumpremium from '../images/casa/premiummedium.webp';
import largepremium from '../images/casa/premiumlarge.webp';
import intpremium1 from '../images/casa/premiuminterior2.webp';
import intpremium2 from '../images/casa/premiuminterior3.webp';

import smalllux from '../images/casa/luxsmall.webp';
import mediumlux from '../images/casa/luxmedium.webp';
import largelux from '../images/casa/luxlarge.webp';
import intlux1 from '../images/casa/luxinterior1.webp';
import intlux2 from '../images/casa/luxinterior2.webp';

function ConfiguratorCasa2() {
  const [materials, setMaterials] = useState([]);
  const [finishes, setFinishes] = useState([]);
  const [heatings, setHeatings] = useState([]);
  const [ventilations, setVentilations] = useState([]);
  const [wastes, setWastes] = useState([]);

  const [numarCamere, setNumarCamere] = useState(1);
  const [tabelGenerat, setTabelGenerat] = useState(false);
  const [veziPretul, setVeziPretul] = useState(false);
  const [pretTotal, setPretTotal] = useState(0);
  const [suprafataTotala, setSuprafataTotala] = useState(0);
  const [camere, setCamere] = useState([]);
  const [isValid, setIsValid] = useState(false);
  const [errorMessage, setErrorMessage] = useState('');
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  useEffect(() => {
    axios.get('/api/HouseConfig/materials')
      .then(response => setMaterials(response.data))
      .catch(error => console.error('There was an error fetching the materials!', error));
  }, []);

  useEffect(() => {
    axios.get('/api/HouseConfig/finishes')
      .then(response => setFinishes(response.data))
      .catch(error => console.error('There was an error fetching the finishes!', error));
  }, []);

  useEffect(() => {
    axios.get('/api/HouseConfig/heatings')
      .then(response => setHeatings(response.data))
      .catch(error => console.error('There was an error fetching the heatings!', error));
  }, []);

  useEffect(() => {
    axios.get('/api/HouseConfig/ventilations')
      .then(response => setVentilations(response.data))
      .catch(error => console.error('There was an error fetching the ventilations!', error));
  }, []);

  useEffect(() => {
    axios.get('/api/HouseConfig/wastes')
      .then(response => setWastes(response.data))
      .catch(error => console.error('There was an error fetching the wastes!', error));
  }, []);

  useEffect(() => {
    const token = localStorage.getItem('token');
    setIsLoggedIn(!!token);
  }, []);

  const handleConfigureazaCamerele = () => {
    setTabelGenerat(true);
    setVeziPretul(false);
    setCamere(Array(numarCamere).fill({ numeCamera: 'Bucatarie', suprafata: 10, incalzire: false }));
    setIsValid(true);
    setErrorMessage('');
  };

  const handleVeziPretul = () => {
    if (!camere.every(c => c.suprafata >= 10 && c.suprafata <= 100)) {
      setIsValid(false);
      setErrorMessage('Nu ati introdus bine suprafata');
      return;
    }

    setErrorMessage('');

    const material = materials.find(m => m.materialId === parseInt(document.querySelector('select[name="material"]').value));
    const finish = finishes.find(f => f.finishId === parseInt(document.querySelector('select[name="finish"]').value));
    const heating = heatings.find(h => h.heatingId === parseInt(document.querySelector('select[name="heating"]').value));
    const ventilation = ventilations.find(v => v.ventilationId === parseInt(document.querySelector('select[name="ventilation"]').value));
    const waste = wastes.find(w => w.wasteId === parseInt(document.querySelector('select[name="waste"]').value));

    const SUPRAFATA_COST = 500;
    let totalCost = heating.heatPrice + ventilation.ventPrice + waste.wastePrice;
    let totalSuprafataFaraIncalzire = 0;
    let totalSuprafataCuIncalzire = 0;

    camere.forEach(c => {
      if (c.incalzire) {
        totalSuprafataCuIncalzire += c.suprafata;
      } else {
        totalSuprafataFaraIncalzire += c.suprafata;
      }
    });

    totalCost += SUPRAFATA_COST * totalSuprafataFaraIncalzire * material.material_xm2 * finish.finish_xm2;
    totalCost += SUPRAFATA_COST * totalSuprafataCuIncalzire * material.material_xm2 * finish.finish_xm2 * 1.1;

    setPretTotal(Math.round(totalCost));
    setSuprafataTotala(Math.round(totalSuprafataFaraIncalzire + totalSuprafataCuIncalzire));
    setVeziPretul(true);
  };

  const handleCameraChange = (index, field, value) => {
    const updatedCamere = [...camere];
    updatedCamere[index] = { ...updatedCamere[index], [field]: value };
    setCamere(updatedCamere);
    
    // Validate the form
    setIsValid(updatedCamere.every(c => c.suprafata >= 10 && c.suprafata <= 100));
  };

  const generateRows = () => {
    const camereOptions = ['Bucatarie', 'Sufragerie', 'Baie', 'Dormitor', 'Garaj'];
    return camere.map((camera, index) => (
      <tr key={index}>
        <td>
          <select
            name={`tip-camera-${index}`}
            value={camera.numeCamera}
            onChange={(e) => handleCameraChange(index, 'numeCamera', e.target.value)}
          >
            {camereOptions.map((camera, i) => (
              <option key={i} value={camera}>{camera}</option>
            ))}
          </select>
        </td>
        <td>
          <input
            type="number"
            name={`suprafata-camera-${index}`}
            min="10"
            max="100"
            value={camera.suprafata}
            onChange={(e) => handleCameraChange(index, 'suprafata', parseInt(e.target.value))}
          />
        </td>
        <td>
          <input
            type="checkbox"
            name={`incalzire-camera-${index}`}
            checked={camera.incalzire}
            onChange={(e) => handleCameraChange(index, 'incalzire', e.target.checked)}
          />
        </td>
      </tr>
    ));
  };

  const getImagine1 = (finishType) => {
    if (finishType === "De Lux") {
      if (suprafataTotala > 200) {
        return largelux;
      } else if (suprafataTotala > 100) {
        return mediumlux;
      } else {
        return smalllux;
      }
    } else if (finishType === "Premium") {
      if (suprafataTotala > 200) {
        return largepremium;
      } else if (suprafataTotala > 100) {
        return mediumpremium;
      } else {
        return smallpremium;
      }
    } else {
      if (suprafataTotala > 200) {
        return largestandard;
      } else if (suprafataTotala > 100) {
        return mediumstandard;
      } else {
        return smallstandard;
      }
    }
  };

  const getImagine2 = (finishType) => {
    if (finishType === "De Lux") {
      return intlux1;
    } else if (finishType === "Premium") {
      return intpremium1;
    } else {
      return intstandard1;
    }
  };

  const getImagine3 = (finishType) => {
    if (finishType === "De Lux") {
      return intlux2;
    } else if (finishType === "Premium") {
      return intpremium2;
    } else {
      return intstandard2;
    }
  };

  const getFinishType = () => {
    const finish = finishes.find(f => f.finishId === parseInt(document.querySelector('select[name="finish"]').value));
    return finish ? finish.finName : "Standard";
  };

  const handleSubmitConfig = async () => {
    // Preluare valori string direct din selecte
    const material = document.querySelector('select[name="material"]').selectedOptions[0].text;
    const finish = document.querySelector('select[name="finish"]').selectedOptions[0].text;
    const heating = document.querySelector('select[name="heating"]').selectedOptions[0].text;
    const ventilation = document.querySelector('select[name="ventilation"]').selectedOptions[0].text;
    const waste = document.querySelector('select[name="waste"]').selectedOptions[0].text;
  
    const configData = {
      Material: material,
      Finisaj: finish,
      TipIncalzire: heating,
      Ventilatie: ventilation,
      ColectareReziduri: waste,
      Camere: camere.map(c => ({
        NumeCamera: c.numeCamera, // Utilizează numele selectat din combobox
        Suprafata: c.suprafata,
        IncalzirePardoseala: c.incalzire
      }))
    };
  
    try {
      await axios.post('/api/HouseConfig/addHouseConfig', configData, {
        headers: {
          'Authorization': `Bearer ${localStorage.getItem('token')}`
        }
      });
      alert('Configurația a fost trimisă cu succes!');
    } catch (error) {
      console.error('Eroare la trimiterea configurației:', error);
      alert('A apărut o eroare la trimiterea configurației. Vă rugăm să încercați din nou.');
    }
  };

  return (
    <div className="config-total">
      <div className="background-config1">
        <div className="configurator2-wrapper">
          <div className="config-form">
            <form id="config-form">
              <h3>Afla pretul mediu al casei dorite!</h3>
              <br />

              <label htmlFor="material">Materiale:</label>
              <select name="material">
                {materials.map(material => (
                  <option key={material.materialId} value={material.materialId}>
                    {material.matName}
                  </option>
                ))}
              </select>

              <label htmlFor="finisaje">Finisaje:</label>
              <select name="finish">
                {finishes.map(finish => (
                  <option key={finish.finishId} value={finish.finishId}>
                    {finish.finName}
                  </option>
                ))}
              </select>

              <label htmlFor="incalzire">Tipul de incalzire:</label>
              <select name="heating">
                {heatings.map(heating => (
                  <option key={heating.heatingId} value={heating.heatingId}>
                    {heating.heatName}
                  </option>
                ))}
              </select>

              <label htmlFor="ventilatie-racire">Ventilatie:</label>
              <select name="ventilation">
                {ventilations.map(ventilation => (
                  <option key={ventilation.ventilationId} value={ventilation.ventilationId}>
                    {ventilation.ventName}
                  </option>
                ))}
              </select>

              <label htmlFor="colectare">Colectare de reziduuri:</label>
              <select name="waste">
                {wastes.map(waste => (
                  <option key={waste.wasteId} value={waste.wasteId}>
                    {waste.wasteName}
                  </option>
                ))}
              </select>

              <label htmlFor="camere">Numar de camere (total):</label>
              <input
                type="number"
                id="numar-camere"
                name="numar-camere"
                min="1"
                max="10"
                value={numarCamere}
                onChange={(e) => setNumarCamere(parseInt(e.target.value))}
              />

              <input
                type="button"
                value="Configureaza camerele!"
                onClick={handleConfigureazaCamerele}
              />
            </form>

            {tabelGenerat && (
              <table>
                <thead>
                  <tr>
                    <th>Camera</th>
                    <th>Suprafata (mp)</th>
                    <th>Incalzire in pardoseala</th>
                  </tr>
                </thead>
                <tbody>
                  {generateRows()}
                </tbody>
              </table>
            )}

            {tabelGenerat && (
              <>
                <input
                  type="button"
                  value="Vezi pretul!"
                  onClick={handleVeziPretul}
                  disabled={!isValid}
                />
                {!isValid && <p className="eroare-sup" style={{ color: 'red' }}>{errorMessage}</p>}
              </>
            )}

          </div>
        </div>
      </div>
      {veziPretul && (
      <div className="background-config2">
        {veziPretul && (
          <div className="rezultat" id="rez-text">
            <h4><span className="highlight">Preț Total:</span>  {pretTotal} €</h4> <br />
            <h4><span className="highlight">Suprafață Totală:</span> {suprafataTotala} mp</h4>
          </div>
        )}
        {veziPretul && (
          <div className="rezultat">
            <img src={getImagine1(getFinishType())} alt="Imagine" />
          </div>
        )}
        {veziPretul && (
          <div className="rezultat">
            <img src={getImagine2(getFinishType())} alt="Imagine" />
          </div>
        )}
        {veziPretul && (
          <div className="rezultat">
            <img src={getImagine3(getFinishType())} alt="Imagine" />
          </div>
        )}

      </div>
      )}
      {veziPretul && (
      <div className="background-config2" id="buton-trimitere-config">
      {veziPretul && (
          <input
          type="button"
          id="buton-submit-config"
          value="Incepe constructia visului tau!"
          onClick={handleSubmitConfig}
          disabled={!isLoggedIn}
        />
        )}
      {!isLoggedIn && <p className="eroare-login" style={{ color: 'red' }}>Trebuie să fii logat pentru a începe construcția visului tău!</p>}
      </div>
      )}
    </div>
  );
}

export default ConfiguratorCasa2;

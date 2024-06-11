import './Angajati.css';
import adam from '../images/persoane/AdamFrederic.jpg';
import nicolas from '../images/persoane/NicolasDominic.jpg';
import alex from '../images/persoane/AlexFinu.jpg';





const Angajati = () => {
    
  return (
  <div className="angajati-big-wrapper">
    <div className="angajati-text">
      <h1>Faceti cunostinta cu <span class="subliniat-ang">echipa noastra</span>!</h1>
      <h3>Agentii nostrii va stau la dispozitie oricand
        pentru nevoile dumneavoastra.</h3>
    </div>
    <div className="angajati-wrapper">
        <div className="angajati">
         <img src={adam} alt="Adam"/>
            <br />
            <h3>Adam Rosca <br /> Frederick Maximilian</h3>
            <p>Agent cu experienta</p>
        </div>
        <div className="angajati">
         <img src={nicolas} alt="Nicolas"/>
         <br />
            <h3>Nicolas Dominic <br /> Bosneaga</h3>
            <p>Agent cu experienta</p>
        </div>
        <div className="angajati">
         <img src={alex} alt="Fili"/>
         <br />
            <h3>Alexandru  <br />Filiuta</h3>
            <p>Agent cu experienta</p>
        </div>
    </div>
  </div>
  );
}

export default Angajati;
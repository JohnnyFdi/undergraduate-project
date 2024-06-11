import React, { useState, useRef, useEffect } from 'react';
import { useSpring, animated } from "react-spring";
import './Experienta.css';
import people from '../images/peopleicon.png'; 
import pencil from '../images/pencilicon4.png'; 
import town from '../images/townicon.png'; 
import key from '../images//keyicon.png'; 

function Number({ n }) {
    const [isVisible, setIsVisible] = useState(false);
    const { number } = useSpring({
        from: { number: 0 },
        number: isVisible ? n : 0,
        delay: 200,
        config: { mass: 1, tension: 20, friction: 10 },
    });

    const ref = useRef(null);

    useEffect(() => {
        const observer = new IntersectionObserver(
            ([entry]) => {
                if (entry.isIntersecting) {
                    setIsVisible(true);
                }
            },
            {
                root: null,
                rootMargin: '0px',
                threshold: 0.5, // Change threshold as needed
            }
        );

        if (ref.current) {
            observer.observe(ref.current);
        }

        return () => {
            if (ref.current) {
                observer.unobserve(ref.current);
            }
        };
    }, []);

    return <animated.div ref={ref}>{number.to((n) => n.toFixed(0))}</animated.div>;
}
function Experienta() {
    
  return (
    <div className="experienta-container">
      <div className="icon-container" id="ani">
        <div className="icon-div">
        <img src={people} alt="People" />
        </div>
        <div className="icon-number">
           <br /> <h1><Number n={10} /></h1>
        </div>
        <div className="icon-text">
            <h3>Ani experienta</h3>
        </div>
      </div>
      <div className="icon-container" id="proiecte">
        <div className="icon-div">
        <img src={pencil} alt="Pencil" />
        </div>
        <div className="icon-number">
        <br />  <h1><Number n={20} /></h1>
        </div>
        <div className="icon-text">
            <h3>Proiecte dezvoltate</h3>
        </div>
      </div>
      <div className="icon-container" id="orase">
        <div className="icon-div">
        <img src={town} alt="Town" />
        </div>
        <div className="icon-number">
        <br /> <h1><Number n={1} /></h1>
        </div>
        <div className="icon-text">
            <h3>Orase in care construim</h3>
        </div>
      </div>
      <div className="icon-container" id="locuinte">
        <div className="icon-div">
        <img src={key} alt="Key" />
        </div>
        <div className="icon-number">
        <br />  <h1><Number n={1500} /></h1>
        </div>
        <div className="icon-text">
            <h3>Locuinte vandute</h3>
        </div>
      </div>
    </div>
  );
}

export default Experienta;
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './ContactRedirection.css';

function ContactRedirection() {
    const [hovered, setHovered] = useState(false);

    return (
        <Link to="/contact">
        <div className="contact-page-button" onMouseEnter={() => setHovered(true)} onMouseLeave={() => setHovered(false)}>
            <h1 className={hovered ? "hidden" : ""}>Aici incepe visul tau!</h1>
            <h1 className={hovered ? "show" : "hidden"}>Lasa-ne un mesaj! </h1>
        </div>
        </Link>
    );
}

export default ContactRedirection;
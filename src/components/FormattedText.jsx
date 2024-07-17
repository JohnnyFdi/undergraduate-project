import React from 'react';
import './FormattedText.css'; // Importă fișierul CSS pentru componenta

const FormattedText = ({ text }) => {
  const formattedText = text.split('\r\n').map((line, index) => (
    <React.Fragment key={index}>
      {line}
      <br />
    </React.Fragment>
  ));
  return <div className="formatted-text">{formattedText}</div>;
};

export default FormattedText;

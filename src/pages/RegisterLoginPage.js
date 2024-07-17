import React from 'react';
import RegisterLoginAdmin from '../components/RegisterLoginAdmin';

const RegisterLoginPage = ({ setIsLoggedIn, setUserEmail }) => {
  return (
    <div>
      <RegisterLoginAdmin setIsLoggedIn={setIsLoggedIn} setUserEmail={setUserEmail} />
    </div>
  );
};

export default RegisterLoginPage;
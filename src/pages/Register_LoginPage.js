import React from 'react';
import RegisterLoginForm from '../components/RegisterLoginForm';

const Register_LoginPage = ({ setIsLoggedIn }) => {
  return (
    <div>
      <RegisterLoginForm setIsLoggedIn={setIsLoggedIn} />
    </div>
  );
};

export default Register_LoginPage;

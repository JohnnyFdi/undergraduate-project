import React from 'react';
import { Helmet } from 'react-helmet';
import Profil from '../components/Profil';

const ProfilePage = ({ setIsLoggedIn }) => {
  return (
    <div>
      
      <Profil setIsLoggedIn={setIsLoggedIn} />
    </div>
  );
};

export default ProfilePage;

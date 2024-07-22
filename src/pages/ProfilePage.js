import React from 'react';

import Profil from '../components/Profil';

const ProfilePage = ({ setIsLoggedIn }) => {
  return (
    <div>
      
      <Profil setIsLoggedIn={setIsLoggedIn} />
    </div>
  );
};

export default ProfilePage;

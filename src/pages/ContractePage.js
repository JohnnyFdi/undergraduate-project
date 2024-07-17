import React from 'react';
import ContracteCase from '../components/ContracteCase';
import ContracteApartamente from '../components/ContracteApartamente';
import ProiecteView from '../components/ProiecteView';

const ContractePage = () => {
  return (
    <div className="page-container">
      <ProiecteView />
      <ContracteApartamente />
      <ContracteCase />
    </div>
  );
};

export default ContractePage;
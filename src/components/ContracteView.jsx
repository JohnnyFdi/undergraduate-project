import React, { useEffect, useState } from 'react';
import axios from '../axios/axios'; // Importă instanța axios
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  ArcElement,
  LineElement,
  PointElement,
  Title,
  Tooltip,
  Legend
} from 'chart.js';
import { Pie, Line } from 'react-chartjs-2'; // Importă componentele Pie și Line pentru diagrame
import './ContracteView.css'; // Fișierul de stil pentru a gestiona responsive-ul

ChartJS.register(
  CategoryScale,
  LinearScale,
  ArcElement,
  LineElement,
  PointElement,
  Title,
  Tooltip,
  Legend
);

function ContracteView() {
  const [contracteApartamente, setContracteApartamente] = useState([]);
  const [contracteCase, setContracteCase] = useState([]);
  const [apartamenteChartData, setApartamenteChartData] = useState({
    labels: [],
    datasets: [{
      label: 'Number of Contracts',
      data: [],
      backgroundColor: [
        'rgba(255, 99, 132, 0.6)',
        'rgba(54, 162, 235, 0.6)',
        'rgba(255, 206, 86, 0.6)',
        'rgba(75, 192, 192, 0.6)',
        'rgba(153, 102, 255, 0.6)',
        'rgba(255, 159, 64, 0.6)'
      ],
      borderColor: [
        'rgba(255, 99, 132, 1)',
        'rgba(54, 162, 235, 1)',
        'rgba(255, 206, 86, 1)',
        'rgba(75, 192, 192, 1)',
        'rgba(153, 102, 255, 1)',
        'rgba(255, 159, 64, 1)'
      ],
      borderWidth: 1,
    }],
  });
  const [caseChartData, setCaseChartData] = useState({
    labels: [],
    datasets: [{
      label: 'Number of Contracts',
      data: [],
      backgroundColor: [
        'rgba(255, 99, 132, 0.6)',
        'rgba(54, 162, 235, 0.6)',
        'rgba(255, 206, 86, 0.6)',
        'rgba(75, 192, 192, 0.6)',
        'rgba(153, 102, 255, 0.6)',
        'rgba(255, 159, 64, 0.6)'
      ],
      borderColor: [
        'rgba(255, 99, 132, 1)',
        'rgba(54, 162, 235, 1)',
        'rgba(255, 206, 86, 1)',
        'rgba(75, 192, 192, 1)',
        'rgba(153, 102, 255, 1)',
        'rgba(255, 159, 64, 1)'
      ],
      borderWidth: 1,
    }],
  });
  const [profitData, setProfitData] = useState({
    labels: [],
    datasets: [{
      label: 'Profit',
      data: [],
      fill: false,
      backgroundColor: 'rgba(75, 192, 192, 0.6)',
      borderColor: 'rgba(75, 192, 192, 1)',
      borderWidth: 1,
    }],
  });

  useEffect(() => {
    const updateChartData = (contracte, setChartData) => {
      const emailCounts = contracte.reduce((acc, contract) => {
        const email = contract.adminEmail;
        acc[email] = (acc[email] || 0) + 1;
        return acc;
      }, {});

      const emails = Object.keys(emailCounts);
      const counts = Object.values(emailCounts);

      setChartData({
        labels: emails,
        datasets: [{
          label: 'Number of Contracts',
          data: counts,
          backgroundColor: [
            'rgba(255, 99, 132, 0.6)',
            'rgba(54, 162, 235, 0.6)',
            'rgba(255, 206, 86, 0.6)',
            'rgba(75, 192, 192, 0.6)',
            'rgba(153, 102, 255, 0.6)',
            'rgba(255, 159, 64, 0.6)'
          ],
          borderColor: [
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1,
        }],
      });
    };

    const updateProfitData = (contracteApartamente, contracteCase) => {
      const allContracts = [...contracteApartamente, ...contracteCase];
      const profitByDate = allContracts.reduce((acc, contract) => {
        const date = new Date(contract.dataSemnarii).toLocaleDateString();
        const profit = contract.pretVanzare - contract.costuri;
        if (!acc[date]) {
          acc[date] = 0;
        }
        acc[date] += profit;
        return acc;
      }, {});

      const sortedDates = Object.keys(profitByDate).sort((a, b) => new Date(a) - new Date(b));
      const endDate = new Date();
      const startDate = new Date();
      startDate.setDate(endDate.getDate() - 6);
      const recentDates = sortedDates.filter(date => new Date(date) >= startDate && new Date(date) <= endDate);
      const profits = recentDates.map(date => profitByDate[date]);

      // Adăugarea zilelor lipsă în intervalul de 7 zile pentru a asigura continuitatea
      const allDates = [];
      for (let d = startDate; d <= endDate; d.setDate(d.getDate() + 1)) {
        allDates.push(new Date(d).toLocaleDateString());
      }

      const allProfits = allDates.map(date => profitByDate[date] || 0);

      setProfitData({
        labels: allDates,
        datasets: [{
          label: 'Profit',
          data: allProfits,
          fill: false,
          backgroundColor: 'rgba(75, 192, 192, 0.6)',
          borderColor: 'rgba(75, 192, 192, 1)',
          borderWidth: 1,
        }],
      });
    };

    axios.get('/api/Admins/contracte-apartamente')
      .then(response => {
        const apartamenteData = response.data;
        setContracteApartamente(apartamenteData);
        updateChartData(apartamenteData, setApartamenteChartData);
        updateProfitData(apartamenteData, contracteCase);
      })
      .catch(error => {
        console.error('Error fetching contracte apartamente:', error);
      });

    axios.get('/api/Admins/contracte-case')
      .then(response => {
        const caseData = response.data;
        setContracteCase(caseData);
        updateChartData(caseData, setCaseChartData);
        updateProfitData(contracteApartamente, caseData);
      })
      .catch(error => {
        console.error('Error fetching contracte case:', error);
      });
  }, []);

  return (
    <div className="contracte-view-wrapper">
      <h1>Contracte Apartamente</h1>
      <table className="contract-table">
        <thead>
          <tr>
            <th>Contract ID</th>
            <th>Admin Email</th>
            <th>User Full Name</th>
            <th>Numar Apartament</th>
            <th>Nume Proiect</th>
            <th>Data Semnarii</th>
            <th>Costuri</th>
            <th>Pret Vanzare</th>
          </tr>
        </thead>
        <tbody>
          {contracteApartamente.map(contract => (
            <tr key={contract.contractApId}>
              <td>{contract.contractApId}</td>
              <td>{contract.adminEmail}</td>
              <td>{contract.userFullName}</td>
              <td>{contract.numarApartament}</td>
              <td>{contract.numeProiect}</td>
              <td>{new Date(contract.dataSemnarii).toLocaleDateString()}</td>
              <td>{contract.costuri}</td>
              <td>{contract.pretVanzare}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <h1>Statistici Contracte Apartamente</h1>
      <div className="chart-container">
        <Pie
          data={apartamenteChartData}
          options={{
            responsive: true,
            maintainAspectRatio: false,
          }}
        />
      </div>

      <h1>Contracte Case</h1>
      <table className="contract-table">
        <thead>
          <tr>
            <th>Contract ID</th>
            <th>Admin Email</th>
            <th>User Full Name</th>
            <th>Adresa</th>
            <th>Data Semnarii</th>
            <th>Costuri</th>
            <th>Pret Vanzare</th>
          </tr>
        </thead>
        <tbody>
          {contracteCase.map(contract => (
            <tr key={contract.contractCId}>
              <td>{contract.contractCId}</td>
              <td>{contract.adminEmail}</td>
              <td>{contract.userFullName}</td>
              <td>{contract.adresa}</td>
              <td>{new Date(contract.dataSemnarii).toLocaleDateString()}</td>
              <td>{contract.costuri}</td>
              <td>{contract.pretVanzare}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <h1>Statistici Contracte Case</h1>
      <div className="chart-container">
        <Pie
          data={caseChartData}
          options={{
            responsive: true,
            maintainAspectRatio: false,
          }}
        />
      </div>

      <h1>Profituri pe Zile</h1>
      <div className="chart-container">
        <Line
          data={profitData}
          options={{
            responsive: true,
            maintainAspectRatio: false,
            scales: {
              x: {
                title: {
                  display: true,
                  text: 'Date'
                }
              },
              y: {
                beginAtZero: true,
                title: {
                  display: true,
                  text: 'Profit (RON)'
                }
              }
            }
          }}
        />
      </div>
    </div>
  );
}

export default ContracteView;

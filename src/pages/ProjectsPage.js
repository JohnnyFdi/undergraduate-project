import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Proiecte from '../components/Proiecte';
import Proiecte2 from '../components/Proiecte2';
import ProjectDetailPage from './ProjectDetailPage';

function ProjectsPage() {
  return (
    <div>
      <Routes>
        <Route 
          path="/" 
          element={<ProjectsLayout />} 
        />
        <Route path="/:nume" element={<ProjectDetailPage />} />
      </Routes>
    </div>
  );
}

const ProjectsLayout = () => (
  <>
    <Proiecte />
    <Proiecte2 />
  </>
);

export default ProjectsPage;

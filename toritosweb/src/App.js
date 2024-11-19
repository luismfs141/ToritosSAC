import React from 'react';
import './assetss/css/Generalbar.css';
import { BrowserRouter as Router, Route, Routes, Link, useNavigate } from 'react-router-dom';

import Sidebar from './components/Sidebar';
import Navbar from './components/Navbar';
import Content from './components/Content';

import Grupos from './pages/Grupos';
import Menu from './pages/Menu';
import Estado from './pages/Estado';
import Sorteos from './pages/Sorteos';
import Cronograma from './pages/Cronograma';
import Soporte from './pages/Soporte';
import useSidebar from './assetss/script/Generalbar';

function App() {
  useSidebar();
  return (
    <div>
      <Sidebar />
      <section id="content">
        <Navbar /> 
          <Routes>
          <Route path="/Menu" element={<Menu />} />
            <Route path="/Grupos" element={<Grupos />} />
            <Route path="/Estado" element={<Estado />} />
            <Route path="/Sorteos" element={<Sorteos />} />
            <Route path="/Cronograma" element={<Cronograma />} />
            <Route path="/Soporte" element={<Soporte />} />
          </Routes>
      </section>
    </div>
  );
}

export default App;

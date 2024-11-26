import React, { useState } from 'react';
import './assetss/css/Generalbar.css';
import { Routes, Route, useNavigate } from 'react-router-dom';

import Sidebar from './components/Sidebar';
import Navbar from './components/Navbar';
import Grupos from './pages/Grupos';
import Menu from './pages/Menu';
import Estado from './pages/Estado';
import Sorteos from './pages/Sorteos';
import Cronograma from './pages/Cronograma';
import Soporte from './pages/Soporte';
import LoginForm from './pages/Login';

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const navigate = useNavigate();

  // Función para manejar el login
  const handleLogin = () => {
    setIsAuthenticated(true);
    navigate("/Menu"); // Redirige a la página principal después de iniciar sesión
  };

  return (
    <div>/
      {/* Mostrar el LoginForm solo si no está autenticado */}
      {!isAuthenticated ? (
        <LoginForm onLogin={handleLogin} />
      ) : (
        <>
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
        </>
      )}
    </div>
  );
}

export default App;
import React, { useState, useEffect } from 'react';
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
import RegistroCliente from './pages/RegistroCliente';

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const navigate = useNavigate();

  // Verificar si el usuario está autenticado al montar el componente
  useEffect(() => {
    const clienteData = localStorage.getItem('cliente');
    if (clienteData) {
      setIsAuthenticated(true);
    }
  }, []);

  // Función para manejar el login
  const handleLogin = () => {
    setIsAuthenticated(true);
    navigate("/Menu"); // Redirige a la página principal después de iniciar sesión
  };

  // Función para manejar el logout
  const handleLogout = () => {
    localStorage.removeItem('cliente'); // Eliminar los datos del cliente de localStorage
    setIsAuthenticated(false); // Cambiar el estado de autenticación
    navigate("/Login"); // Redirigir al login
  };

  return (
    <div>
      {/* Mostrar el LoginForm solo si no está autenticado */}
      {!isAuthenticated ? (
        <Routes>
          <Route path="/Login" element={<LoginForm onLogin={handleLogin} />} />
          <Route path="/RegistroCliente" element={<RegistroCliente />} />
        </Routes>
      ) : (
        <>
          <Sidebar />
          <section id="content">
            <Navbar onLogout={handleLogout} />
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
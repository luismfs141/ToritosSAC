import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import '../assetss/css/Generalbar.css';
import { useCliente } from '../hooks/useCliente'; // Importamos el hook

function Navbar({ onLogout }) {
  const [cliente, setCliente] = useState(null); 
  const [nombreCliente, setNombreCliente] = useState(null);
  const [isDropdownVisible, setIsDropdownVisible] = useState(false);
  const [isInitialized, setIsInitialized] = useState(false); // Nuevo estado para evitar el ciclo infinito
  const navigate = useNavigate();
  const { logoutCliente, getClienteFromLocalStorage } = useCliente();

  // Manejar el estado del dropdown
  const toggleDropdown = () => {
    setIsDropdownVisible(!isDropdownVisible);
  };

  // Cargar cliente desde el localStorage cuando el componente se monta
  useEffect(() => {
    if (!isInitialized) {
      const clienteData = getClienteFromLocalStorage();
      if (clienteData) {
        setCliente(clienteData);
        setNombreCliente(clienteData.nombreNv + ' ' + clienteData.apellidoPaternoNv + ' ' + clienteData.apellidoMaternoNv);
      }
      setIsInitialized(true); // Cambiar el estado de isInitialized para que no se actualice nuevamente
    }
  }, [isInitialized, getClienteFromLocalStorage]); // Dependencia de isInitialized para evitar el ciclo infinito

  const handleLogout = () => {
    logoutCliente();
    onLogout();
    navigate("/Login");
  };

  return (
    <nav>
      <i className='bx bx-menu toggle-sidebar'></i>

      <form action="#">
        <div className="form-group">
          {/* Campos si es necesario */}
        </div>
      </form>   

      {/* Si el cliente está logueado, mostramos su nombre */}
      {cliente ? (
        <>
          <a href="#" className="nav-link text-decoration-none">{nombreCliente}</a>
          <span className="divider"></span>
        </>
      ) : (
        <a href="#" className="nav-link text-decoration-none">Invitado</a>
      )}

      <div className="profile">
        <img
          src="https://img.freepik.com/vector-premium/icono-perfil-avatar-predeterminado-imagen-usuario-redes-sociales-icono-avatar-gris-silueta-perfil-blanco-ilustracion-vectorial_561158-3383.jpg?w=740"
          alt="Perfil"
          onClick={toggleDropdown} // El clic en la imagen activa el dropdown
        />

        {/* Mostrar el dropdown solo si isDropdownVisible es true */}
        <ul className={`profile-link ${isDropdownVisible ? 'show' : 'hidden'}`}>
          <li><a href="#" onClick={handleLogout}><i className='bx bxs-log-out-circle text-decoration-none'></i> Cerrar sesión</a></li>
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;
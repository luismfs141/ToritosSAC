import React, { useEffect } from 'react';
import '../assetss/css/Generalbar.css';
import useSidebar from '../assetss/script/Generalbar.jsx';

function Navbar() {
  useSidebar();
  return (
    <nav>
      <i className='bx bx-menu toggle-sidebar'></i>

      <form action="#">
        <div className="form-group">
          <input type="text" placeholder="Buscar..." />
          <i className='bx bx-search icon'></i>
        </div>
      </form>

      <a href="#" className="nav-link text-decoration-none">
        <i className='bx bxs-bell icon'></i>
        <span className="badge">1</span>
      </a>
      
      <a href="#" className="nav-link text-decoration-none">nombre</a>
      <span className="divider"></span>

      <div className="profile">
        <img
          src="https://img.freepik.com/psd-premium/ilustracion-programacion-web-3d-html-css-js_394084-544.jpg?semt=ais_hybrid"
          alt=""
        />
        <ul className="profile-link">
          <li><a href="#"><i className='bx bxs-user-circle icon text-decoration-none'></i> Perfil</a></li>
          <li><a href="#"><i className='bx bxs-cog text-decoration-none'></i> Configuración</a></li>
          <li><a href="#"><i className='bx bxs-log-out-circle text-decoration-none'></i> Cerrar sesión</a></li>
        </ul>
      </div>
    </nav>
  );
}

export default Navbar;

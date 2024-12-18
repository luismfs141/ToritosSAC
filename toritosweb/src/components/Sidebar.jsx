import React from 'react';
import { Link } from 'react-router-dom';
import '../assetss/css/Generalbar.css';
import useSidebar from '../assetss/script/Generalbar';

function Sidebar() {
  useSidebar();

  return (
    <section id="sidebar">
      <br></br>
      <a href="#" className="brand" style={{ textDecoration: 'none' }}>
        <i className='bx bxs-smile icon'></i>ToritosSAC
      </a>

      <ul className="side-menu">
        <li><Link to="/Menu" className="active"><i className='bx bxs-dashboard icon'></i> Menu</Link></li>

        <li className="divider " data-text="Principal">Principal</li>
        <li><Link to="/grupos"><i className='bx bxs-widget icon'></i> Grupos</Link></li>
        <li><Link to="/estado"><i className='bx bxs-widget icon'></i> Estado de cuenta</Link></li>
        <li><Link to="/sorteos"><i className='bx bxs-widget icon'></i> Sorteos</Link></li>
        <li><Link to="/cronograma"><i className='bx bxs-widget icon'></i> Cronograma</Link></li>

        <li className="divider" data-text="Contacto">Contacto</li>
        <li>
          <Link to="/soporte"><i className='bx bxs-notepad icon'></i> Soporte <i className='bx bx-chevron-right icon-right'></i></Link>
          <ul className="side-dropdown">
            <li><a href="/soporte#preguntas-frecuentes">Preguntas frecuentes</a></li>
            <li><a href="/soporte#contacto">Contacto</a></li>
            <li><a href="/soporte#informacion">Información</a></li>
          </ul>
        </li>
      </ul>
    </section>
  );
}

export default Sidebar;

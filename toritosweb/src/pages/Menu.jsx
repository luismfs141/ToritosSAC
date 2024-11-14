import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../assetss/css/Generalbar.css';
import useSidebar from '../assetss/script/Generalbar.jsx';

function App() {
  useSidebar();

  return (
    <div className="container mt-4">
      <div className="row">
        {/* Primer div horizontal */}
        <div className="col-md-4">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Información 1</h5>
              <p className="card-text">Fila 1: Detalle inventado A</p>
              <p className="card-text">Fila 2: Detalle inventado B</p>
            </div>
          </div>
        </div>

        {/* Segundo div horizontal */}
        <div className="col-md-4">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Información 2</h5>
              <p className="card-text">Fila 1: Detalle inventado C</p>
              <p className="card-text">Fila 2: Detalle inventado D</p>
            </div>
          </div>
        </div>

        {/* Tercer div horizontal */}
        <div className="col-md-4">
          <div className="card">
            <div className="card-body">
              <h5 className="card-title">Información 3</h5>
              <p className="card-text">Fila 1: Detalle inventado E</p>
              <p className="card-text">Fila 2: Detalle inventado F</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;

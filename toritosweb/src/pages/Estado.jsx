import React, { useState } from 'react';
import '../assetss/css/Modal.css';

const Estado = () => {
  const [selectedOption, setSelectedOption] = useState('');

  const handleOptionChange = (e) => {
    setSelectedOption(e.target.value);
  };

  return (
    <div className="container mt-4 mb-4">
      <h3 className="mb-4 text-start">Estado de Cuenta</h3>

      <div className="row align-items-center mb-3">
        <div className="col-12 col-md-1 text-start">
          <label htmlFor="searchDropdown" className="form-label">
            Grupo:
          </label>
        </div>
        <div className="col-12 col-md-5 text-start" tyle={{ paddingLeft: '0px' }}>
          <select
            id="searchDropdown"
            className="form-select"
            value={selectedOption}
            onChange={handleOptionChange}
          >
            <option value="">Seleccione un Grupo</option>
            <option value="nombre1">Nombre 1</option>
            <option value="nombre2">Nombre 2</option>
            <option value="nombre3">Nombre 3</option>
          </select>
        </div>
        <div className="col-12 col-md-3 text-start mt-2 mt-md-0 d-flex align-items-center">
          <button className="btn btn-primary me-2">
            Buscar
          </button>
          <button className="btn btn-secondary me-2">
            Filtro
          </button>
        </div>
      </div>

      <div className="table-responsive text-start">
        <table className="table table-striped table-bordered">
          <thead>
            <tr>
              <th>Nro Cuota</th>
              <th>Monto</th>
              <th>Prioridad</th>
              <th>Total</th>
              <th>Fecha de Pago</th>
              <th>Estado</th>
              <th>Vaucher</th>
            </tr>
          </thead>
        </table>
      </div>
    </div>
  );
};

export default Estado;

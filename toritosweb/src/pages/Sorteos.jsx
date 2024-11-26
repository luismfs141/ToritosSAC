import React, { useState } from 'react';

const Sorteos = () => {
  const [selectedOption, setSelectedOption] = useState('');
  const [showModal, setShowModal] = useState(false);

  const handleOptionChange = (e) => {
    setSelectedOption(e.target.value);
  };

  const toggleModal = () => {
    setShowModal(!showModal);
  };

  return (
    <div className="container mt-4 mb-4">
      <h3 className="mb-4 text-start">Sorteos</h3>
      <h5 htmlFor="searchDropdown" className="form-label text-start">
        Próximo Sorteo: 10 de Diciembre de 2024!
      </h5>

      {/* Sección de búsqueda */}
      <div className="row align-items-center mb-3">
        <div className="col-12 col-md-1 text-start">
          <label htmlFor="searchDropdown" className="form-label">
            Grupo:
          </label>
        </div>
        <div className="col-12 col-md-5 text-start" style={{ paddingLeft: '0px' }}>
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
        <div className="col-12 col-md-5 text-start mt-2 mt-md-0 d-flex align-items-center">
          <button className="btn btn-primary me-2">Buscar</button>
          <button className="btn btn-secondary me-2">Realizar Martillazo!</button>
          <button
            className="btn btn-secondary rounded-circle"
            onClick={toggleModal}
            style={{ fontSize: '18px', width: '35px', height: '35px' }}
          >
            !
          </button>
        </div>
      </div>

      <div className="table-responsive text-start">
        <table className="table table-striped table-bordered">
          <thead>
            <tr>
              <th>Numero</th>
              <th>Ganadores</th>
              <th>Fecha</th>
              <th>Modalidad</th>
            </tr>
          </thead>
        </table>
      </div>

      {showModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h5 className="text-start">Información Importante</h5>
            <p className="text-start">
              Instrucciones importantes relacionadas
              con el sorteo o la acción de martillazo.
            </p>
            <button className="btn btn-secondary mt-2" onClick={toggleModal}>
              Cerrar
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Sorteos;

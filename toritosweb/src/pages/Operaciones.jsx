import React, { useState } from 'react';
import '../assetss/css/Modal.css';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';

const Operaciones = () => {
  const [selectedOption, setSelectedOption] = useState('');
  const [tabIndex, setTabIndex] = useState(0);

  const handleOptionChange = (e) => {
    setSelectedOption(e.target.value);
  };

  return (
    <div className="container mt-4 mb-4">
      <h3 className="mb-4 text-start">Operaciones</h3>
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
      <div>
        <Tabs selectedIndex={tabIndex} onSelect={(index) => setTabIndex(index)}>
          <TabList>
            <Tab>Estado de cuenta</Tab>
            <Tab>Cuotas</Tab>
          </TabList>
          <TabPanel>
            <br/>
            <div>
              <div className="row mb-3">
                <div className="col-5">
                  <p><strong>Fecha Apertura:</strong> {}</p>
                  <p><strong>Monto Aportado:</strong> {}</p>
                  <p><strong>Estado:</strong> {}</p>
                </div>
                <div className="col-5">
                  <p><strong>Fecha Finalización:</strong> {}</p>
                  <p><strong>Monto Faltante:</strong> {}</p>
                </div>
              </div>
              <div className="row mb-3">
                <div className="col-12">
                  <table className="table table-striped table-bordered">
                    <thead className="table-dark" style={{ position: 'sticky', top: 0, zIndex: 1 }}>
                      <tr>
                        <th>Nro</th>
                        <th>Tipo Operación</th>
                        <th>Monto</th>
                        <th>Fecha</th>
                        <th>Código Operación</th>
                      </tr>
                    </thead>
                  </table>
                </div>
              </div>
            </div>
          </TabPanel>
          <TabPanel>
            <br/>
            <div className="table-responsive text-start">
              <table className="table table-striped table-bordered">
                <thead className="table-dark" style={{ position: 'sticky', top: 0, zIndex: 1 }}>
                  <tr>
                    <th>Nro</th>
                    <th>Monto Cuota</th>
                    <th>Penalidad</th>
                    <th>Fecha Inicio</th>
                    <th>Fecha Fin</th>
                    <th>Estado</th>
                    <th>Acciones</th>
                  </tr>
                </thead>
              </table>
            </div>
          </TabPanel>
        </Tabs>
      </div>
    </div>
  );
};

export default Operaciones;
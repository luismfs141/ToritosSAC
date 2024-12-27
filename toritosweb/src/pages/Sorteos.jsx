import React, { useState, useEffect } from 'react';
import { useCliente } from '../hooks/useCliente';
import { useGrupo } from '../hooks/useGrupo';

const Sorteos = () => {
  const { getClienteFromLocalStorage } = useCliente();
  const { getGruposPorCliente } = useGrupo();

  const [ clienteData, setClienteData ] = useState();
  const [ gruposCliente, setGruposCliente ] = useState([]);
  const [ grupoSeleccionado, setGrupoSeleccionado] = useState('');
  const [ sorteo, setSorteo] = useState([]);
  const [ isInitialized, setIsInitialized ] = useState(false);

  useEffect(() => {
      if (!isInitialized) {
        const clienteLogin = getClienteFromLocalStorage();
        if (clienteLogin) {
          setClienteData(clienteLogin);
          const listaGrupo = getGruposPorCliente(clienteLogin);
          listaGrupo.then(grupos => {
            setGruposCliente(grupos); 
          });
        }
        setIsInitialized(true);
      }
    }, [isInitialized, getClienteFromLocalStorage,getGruposPorCliente]);

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
            value={grupoSeleccionado}
            onChange={(e) => setGrupoSeleccionado(e.target.value)}
          >
            <option value="">Seleccione un Grupo</option>
            {gruposCliente.map(grupo => (
              <option key={grupo.idGrupoI} value={grupo.codigoC}>
                {grupo.codigoC}
              </option>
            ))}
          </select>
        </div>
      </div>

      {/* Tabla de sorteos */}
      <div className="table-responsive" style={{ maxHeight: '500px', overflowY: 'auto' }}>
      <table className="table table-bordered table table-striped">
        <thead className="table-dark" style={{ position: 'sticky', top: 0, zIndex: 1 }}>
            <tr>
              <th>Numero</th>
              <th>Ganadores</th>
              <th>Fecha</th>
              <th>Modalidad</th>
            </tr>
          </thead>
          <tbody>
            {sorteo.map((sorteo, index) => (
              <tr key={index}>
                <td>{sorteo.numero}</td>
                <td>{sorteo.ganadores}</td>
                <td>{sorteo.fecha}</td>
                <td>{sorteo.modalidad}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Sorteos;
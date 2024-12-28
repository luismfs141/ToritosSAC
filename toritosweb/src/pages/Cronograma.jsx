import React, { useState, useEffect } from 'react';
import '../assetss/css/Modal.css';
import { useCliente } from '../hooks/useCliente';
import { useGrupo } from '../hooks/useGrupo';
import { useCronograma } from '../hooks/useCronograma';

const Cronograma = () => {
  const { getClienteFromLocalStorage } = useCliente();
  const { getGruposPorCliente } = useGrupo();
  const { obtenerCronogramaGrupo } = useCronograma();

  const [ clienteData, setClienteData ] = useState();
  const [ gruposCliente, setGruposCliente ] = useState([]);
  const [ grupoSeleccionado, setGrupoSeleccionado] = useState('');
  const [ cronograma, setCronograma] = useState([]);
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

  //useEffect para la seleccion de grupo.
  useEffect(() => {
    const fetchEstadosCuenta = async () => {
      setCronograma([]);
      if (grupoSeleccionado && clienteData) {
        const datosGrupo = gruposCliente.find(grupo => grupo.codigoC === grupoSeleccionado);
        if (datosGrupo) {
          const listaCronograma = await obtenerCronogramaGrupo(datosGrupo.idGrupoI);
          if (listaCronograma && listaCronograma.exito) {
            setCronograma(listaCronograma.objeto);
          }
        }
      }
    };
    if (grupoSeleccionado && clienteData) {
      fetchEstadosCuenta();
    }
  }, [grupoSeleccionado]);

  return (
    <div className="container mt-4 mb-4">
      <h3 className="mb-4 text-start">Cronograma</h3>

      <div className="row align-items-center mb-3">
        <div className="col-12 col-md-1 text-start">
          <label htmlFor="searchDropdown" className="form-label">
            Grupo:
          </label>
        </div>
        <div className="col-12 col-md-5 text-start">
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
        <div className="col-12 col-md-3 text-start mt-2 mt-md-0 d-flex align-items-center">
          <button className="btn btn-secondary me-2">
            Exportar PDF
          </button>
        </div>
      </div>

      <div className="table-responsive" style={{ maxHeight: '500px', overflowY: 'auto' }}>
      <table className="table table-bordered table table-striped table-auto">
        <thead className="table-dark" style={{ position: 'sticky', top: 0, zIndex: 1 }}>
            <tr>
              <th>Nro</th>
              <th>Fecha</th>
              <th>Cuota Personal</th>
              <th>Cuota Grupal</th>
              <th>Sorteo</th>
              <th>Martillazo</th>
            </tr>
          </thead>
          <tbody>
            {cronograma.map((cronograma, index) => (
              <tr 
                key={cronograma.idCronogramaI}  
                className={
                  cronograma.habilitarMartillazoB && cronograma.habilitarSorteoB === false
                  ?'table-warning'
                    :cronograma.habilitarSorteoB
                  ?'table-success'
                    :''}>
                <td>{index +1}</td>
                <td>{cronograma.fechaD? new Date(cronograma.fechaD).toLocaleDateString() : 'No Disponible'}</td>
                <td>{cronograma.cuotaIndividualN? `S/.${cronograma.cuotaIndividualN.toFixed(2)}`: 'No Disponible'}</td>
                <td>{cronograma.cuotaGrupalN? `S/.${cronograma.cuotaGrupalN.toFixed(2)}`: 'No Disponible'}</td>
                <td>{cronograma.habilitarSorteoB ? "SI" : "NO"}</td>
                <td>{cronograma.habilitarMartillazoB? "SI":"NO"}</td>
              </tr>)
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Cronograma;

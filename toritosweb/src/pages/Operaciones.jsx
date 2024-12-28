import React, { useState, useEffect } from 'react';
import '../assetss/css/Modal.css';
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import { useCliente } from '../hooks/useCliente';
import { useGrupo } from '../hooks/useGrupo';
import { useEstadoCuenta } from '../hooks/useEstadoCuenta';
import { useCuota } from '../hooks/useCuota';

const Operaciones = () => {

  const { getClienteFromLocalStorage } = useCliente();
  const { getGruposPorCliente } = useGrupo();
  const { obtenerEstadoCuentaCliente, obtenerDetallesEstadoCuentaCliente} = useEstadoCuenta();
  const { listarCuotasClienteGrupo } = useCuota();

  const [tabIndex, setTabIndex] = useState(0);
  const [grupoSeleccionado, setGrupoSeleccionado] = useState('');
  const [ clienteData, setClienteData ] = useState();
  const [ gruposCliente, setGruposCliente ] = useState([]);
  const [ isInitialized, setIsInitialized ] = useState(false);
  const [ estadoCuenta, setEstadoCuenta] = useState();
  const [ detalleEstadoCuenta, setDetalleEstadoCuenta] = useState([]);
  const [ cuotas, setCuotas] = useState([]);
  const [ fechaFinalizacion, setFechaFinalizacion] = useState();
  const [ montoFaltante, setMontoFaltante ] = useState();
  const [ fechaInicioMartillazo, setFechaInicioMartillazo ] = useState();
  const [ fechaCierreMartillazo, setFechaCierreMartillazo ] = useState();
  const [ montoMartillazo, setMontoMartillazo ] = useState();
  const [ habilitarMartillazo, setHabilitarMartillazo] = useState(false);

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

  useEffect(()=>{
    const fecthEstados = async() =>{
      const datosGrupo = gruposCliente.find(grupo => grupo.codigoC === grupoSeleccionado);
      if(datosGrupo){
        const x_estCuenta = await obtenerEstadoCuentaCliente(clienteData.idClienteI, datosGrupo.idGrupoI);
        const x_cuotas = await listarCuotasClienteGrupo(clienteData.idClienteI, datosGrupo.idGrupoI);
        if(x_estCuenta && x_cuotas){
          setEstadoCuenta(x_estCuenta.objeto);
          setCuotas(x_cuotas.objeto);
        }
      }
    }
    if(grupoSeleccionado && clienteData){
      fecthEstados();
    }
  },[grupoSeleccionado]);

  useEffect(()=>{
    if(cuotas && estadoCuenta && grupoSeleccionado ){
      const datosGrupo = gruposCliente.find(grupo => grupo.codigoC === grupoSeleccionado);
      let ultimaCuota = cuotas[cuotas.length-1]; 
      let montoFal = datosGrupo.precioUnidadVehiculoM - estadoCuenta.montoRecaudadoN;
      if(ultimaCuota && montoFal){
        setFechaFinalizacion(ultimaCuota.fechaFinD);
        setMontoFaltante(montoFal);
      }  
    }
  },[cuotas, estadoCuenta, grupoSeleccionado]);

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
      <div>
        <Tabs selectedIndex={tabIndex} onSelect={(index) => setTabIndex(index)}>
          <TabList>
            <Tab>Estado de cuenta</Tab>
            <Tab>Cuotas</Tab>
            <Tab>Martillazo</Tab>
          </TabList>
          <TabPanel>
            <br/>
            <div>
              <div className="row mb-3">
                <div className="col-5">
                  <p><strong>Fecha Apertura:</strong> {estadoCuenta? new Date(estadoCuenta.fechaAperturaD).toLocaleDateString():'Grupo no iniciado.'}</p>
                  <p><strong>Monto Aportado:</strong> {estadoCuenta?`S/.${estadoCuenta.montoRecaudadoN.toFixed(2)}`:'Grupo no iniciado.'}</p>
                  <p><strong>Estado:</strong> {estadoCuenta?'En Proceso.':'Grupo no iniciado.'}</p>
                </div>
                <div className="col-5">
                  <p><strong>Fecha Finalización:</strong> {estadoCuenta && fechaFinalizacion?new Date(fechaFinalizacion).toLocaleDateString(): 'Grupo no iniciado.'}</p>
                  <p><strong>Monto Faltante:</strong> {estadoCuenta && montoFaltante?`S/.${montoFaltante.toFixed(2)}`: 'Grupo no iniciado.'}</p>
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
                    <tbody>
                      {/* Mapea los detalles para mostrar en las filas de la tabla */}
                      {estadoCuenta && estadoCuenta.detalleEstadoCuenta && estadoCuenta.detalleEstadoCuenta.length > 0 ? (
                        estadoCuenta.detalleEstadoCuenta.length.map((detalle, index) => (
                          <tr key={detalle.idDetalleEstadoCuentaI}>
                            <td>{index+1}</td>
                            <td>{detalle.tipoOperacionC}</td>
                            <td>{detalle.monto}</td>
                            <td>{detalle.fechaPagoDt}</td>
                            <td>{detalle.codigoPagoV}</td>
                          </tr>
                        ))
                      ) : (
                        <tr>
                          <td colSpan="7" className="text-center">No hay detalles disponibles</td>
                        </tr>
                      )}
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </TabPanel>
          <TabPanel>
            <br/>
            <div className="table-responsive" style={{ maxHeight: '500px', overflowY: 'auto' }}>
              <table className="table table-bordered table table-striped table-auto">
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
                <tbody>
                  {/* Mapea las cuotas para mostrar en las filas de la tabla */}
                  {cuotas.length > 0 ? (
                    cuotas.map((cuota, index) => (
                      <tr key={cuota.idCuotaI}>
                        <td>{cuota.numCuotaI}</td>
                        <td>{`S/. ${cuota.montoCuotaN.toFixed(2)}`}</td>
                        <td>{cuota.penalidadN > 0 ? `S/. ${cuota.penalidadN.toFixed(2)}` : 'Sin Penalidad'}</td>
                        <td>{new Date(cuota.fechaInicioD).toLocaleDateString()}</td>
                        <td>{new Date(cuota.fechaFinD).toLocaleDateString()}</td>
                        <td>{cuota.estadoCuotaC === 'P' ? 'Pendiente' : 'Abonado'}</td>
                        <td>
                          {/* Aquí puedes agregar botones o enlaces para realizar acciones */}
                          <button className="btn btn-warning btn-sm">Pagar Cuota</button>
                        </td>
                      </tr>
                    ))
                  ) : (
                    <tr>
                      <td colSpan="7" className="text-center">No hay cuotas disponibles</td>
                    </tr>
                  )}
                </tbody>
              </table>
            </div>
          </TabPanel>
          <TabPanel>
            <br />
            <div className="container">
              {/* Group Box (fieldset o div con estilo) */}
              <div className="group-box p-3 border rounded col-md-6 mx-auto">
                <legend className="fw-bold">Datos del Martillazo</legend>
                <div className="row">
                  <div className="col-md-12">
                    <div className="mb-3">
                      <label htmlFor="fechaInicio" className="form-label">Fecha de Apertura</label>
                      <input
                        id="fechaInicioMartillazo"
                        type="date"
                        value={fechaInicioMartillazo}
                        onChange={(e) => setFechaInicioMartillazo(e.target.value)}
                        required
                        className="form-control"
                        readOnly
                      />
                    </div>
                  </div>
                  <div className="col-md-12">
                    <div className="mb-3">
                      <label htmlFor="fechaCierreMartillazo" className="form-label">Fecha de Cierre</label>
                      <input
                        id="fechaCierreMartillazo"
                        type="date"
                        value={fechaCierreMartillazo}
                        onChange={(e) => setFechaCierreMartillazo(e.target.value)}
                        required
                        className="form-control"
                        readOnly
                      />
                    </div>
                  </div>
                  <div className="col-md-12">
                    <div className="mb-3">
                      <label htmlFor="montoMartillazo" className="form-label">Monto Martillazo</label>
                      <input
                        id="montoMartillazo"
                        type="number"
                        value={montoMartillazo}
                        onChange={(e) => setMontoMartillazo(e.target.value)}
                        required
                        className="form-control"
                        readOnly
                      />
                    </div>
                  </div>
                  <div className="col-md-12 text-center">
                    <button className="btn btn-warning btn-sm" disabled>Pagar Monto</button>
                  </div>
                </div>
              </div>
            </div>
          </TabPanel>
          
        </Tabs>
      </div>
    </div>
  );
};

export default Operaciones;
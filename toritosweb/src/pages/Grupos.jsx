import React, { useState,useEffect } from 'react';
import '../assetss/css/Modal.css';
import { useCliente } from '../hooks/useCliente';
import { useGrupo } from '../hooks/useGrupo';
import { useModelo } from '../hooks/useModelo';
import { useDocumento } from '../hooks/useDocumento';
import ModalGuardarDocumento from '../components/ModalGuardarDocumento';

const Grupos = () => {
  const [data, setData] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [newEntry, setNewEntry] = useState({ code: '', status: '', startDate: '', fee: '', period: '' });
  const [editId, setEditId] = useState(null);
  const [filterOption, setFilterOption] = useState('');
  const [modalContent, setModalContent] = useState(null);
  const [showCreateJoinModal, setShowCreateJoinModal] = useState(false);
  const [showCreateUModal, setShowCreateUModal] = useState(false);
  const [selectedOption, setSelectedOption] = useState('');
  const [codigoGrupo, setCodigoGrupo] = useState('');
  const [showModal, setShowModal] = useState(false);
  const [grupoSeleccionado, setGrupoSeleccionado] = useState(null);

  //Metodos Hooks
  const { getClienteFromLocalStorage } = useCliente();
  const { getGruposPorCliente, guardarGrupo, buscarGrupoCodigo, agregarListaGrupoCliente } = useGrupo();
  const { getModelos } = useModelo();
  const { guardarDocumento, getDocumentoPorClienteGrupo } = useDocumento();
  
  //Variables de control
  const [gruposCliente, setGruposCliente] = useState([]);
  const [modelos, setModelos] = useState([]);
  const [clienteData,setClienteData] = useState();
  const [isInitialized, setIsInitialized] = useState(false); // Nuevo estado para evitar el ciclo infinito

  //Variables de Objetos
  //Grupo
  const [cantMaxIntegrantes, setCantMaxIntegrantes] = useState('');
  const [cantidadCuotas, setCantidadCuotas] = useState('');
  const [tipoPeriodoPago, setTipoPeriodoPago] = useState('');
  const [modeloVehiculo, setModeloVehiculo] = useState('');
  const [precioVehiculo, setPrecioVehiculo] = useState('');
  const [documentosDisponibles, setDocumentosDisponibles] = useState({});

  //Message Box
  const [message, setMessage] = useState("");
  const [messageType, setMessageType] = useState(""); // Puede ser 'success' o 'error'
  const [showMessage, setShowMessage] = useState(false);

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
      setIsInitialized(true); // Cambiar el estado de isInitialized para que no se actualice nuevamente
    }
  }, [isInitialized, getClienteFromLocalStorage,getGruposPorCliente]); 

  //useEffect para tabla de grupos
  useEffect(() => {
    // Función para obtener los documentos por cliente y grupo
    const checkDocumentosDisponibles = async () => {
      const documentos = {};
      for (const item of gruposCliente) {
        const resultado = await getDocumentoPorClienteGrupo(clienteData, item);
        
        documentos[item.idGrupoI] = resultado; // Guardamos el resultado en el objeto
      }
      setDocumentosDisponibles(documentos); // Actualizamos el estado con los resultados
    };

    checkDocumentosDisponibles();
  }, [gruposCliente, clienteData]);

  const handleDelete = (id) => {
    setData(data.filter((item) => item.id !== id));
  };

  const handleEdit = (item) => {
    setNewEntry({
      code: item.code,
      status: item.status,
      startDate: item.startDate,
      fee: item.fee,
      period: item.period,
    });
    setEditId(item.id);
  };

  const handleSearch = () => {
    setSearchTerm(searchTerm.trim());
  };

  const filteredData = data
    .filter((item) => item.code.toLowerCase().includes(searchTerm.toLowerCase()))
    .filter((item) => (filterOption ? item.status === filterOption : true));

  const handleShowDetails = (content) => {
    setModalContent(content);
  };

  const handleCloseModal = () => {
    setModalContent(null);
    setShowCreateJoinModal(false);
    setShowCreateUModal(false);
    setShowModal(false);
  };

  // Modal Creación de grupo
  const toggleCreateJoinModal = () => {
    setShowCreateJoinModal(!showCreateJoinModal);
    const listaModelos = getModelos();
      listaModelos.then(modelos => {
        setModelos(modelos); 
      });
  };

  const toggleCreateUModal = () => {
    setShowCreateUModal(!showCreateUModal);
  };

  const handleOptionChange = (e) => {
    setSelectedOption(e.target.value);
  };

  const crearGrupoModal = async () =>{
    const response = await guardarGrupo(clienteData,grupo);
    if(response.exito){
      setShowCreateJoinModal(!showCreateJoinModal);
      const listaGrupo = getGruposPorCliente(clienteData);
      listaGrupo.then(grupos => {
        setGruposCliente(grupos); 
      });
      showSuccessMessage("Grupo creado exitosamente!");
    }
    else{
      showErrorMessage("Hubo un error al crear el grupo.");
    }
  };

  const handleModeloVehiculo =(e) =>{
    const idVehiculo = e.target.value;
    setModeloVehiculo(idVehiculo);
    const modeloSeleccionado = modelos.find(m => m.idModeloVehiculoI == idVehiculo);
    if (modeloSeleccionado) {
      setPrecioVehiculo(modeloSeleccionado.precioUnidadVehiculoM);
    } else {
      setPrecioVehiculo(0);
    }
  };

  const handleUnirseGrupo = async (e) => {
    e.preventDefault();  // Si estás usando un formulario, previenes el comportamiento por defecto
  
    // Verifica que el código del grupo no esté vacío
    if (!codigoGrupo || !clienteData?.idClienteI) {
      showErrorMessage("Por favor ingrese un código válido y asegúrese de estar logueado.");
      return;
    }
    try {
      // Busca el grupo con el código ingresado
      const grupoBuscado = await buscarGrupoCodigo(codigoGrupo);
      if (grupoBuscado) {
        // Intentar unirse al grupo
        const response = await agregarListaGrupoCliente(grupoBuscado, clienteData);
        
        if (response.exito) {
          showSuccessMessage("¡Grupo agregado exitosamente!");
          handleCloseModal();  // Si deseas cerrar el modal después del éxito
        } else {
          showErrorMessage("Error al agregar el grupo. Intenta de nuevo.");
        }
      } else {
        showErrorMessage("Error: el grupo no existe.");
      }
    } catch (error) {
      console.error("Error en unirse al grupo:", error);
      showErrorMessage("Ocurrió un error al procesar la solicitud. Intente más tarde.");
    }
  };

  const handleDocumento = (grupo) => {
    setGrupoSeleccionado(grupo); // Establecer el grupo seleccionado
    setShowModal(true); // Mostrar el modal
  };


  const handleSaveDocumentos = async (documentos) => {
    try {
      const response = await guardarDocumento(documentos, clienteData, grupoSeleccionado);
      const listaGrupo = getGruposPorCliente(clienteData);
      listaGrupo.then(grupos => {
        setGruposCliente(grupos); 
      });
      handleCloseModal();
    } catch (error) {
        console.error('Error al guardar documento:', error);
    }
  };

  //Funcion de mensajes
  const showSuccessMessage = (msg) => {
    setMessage(msg);
    setMessageType("success");
    setShowMessage(true);

    // Opcionalmente ocultamos el mensaje después de 3 segundos
    setTimeout(() => {
      setShowMessage(false);
    }, 3000);
  };

  const showErrorMessage = (msg) => {
    setMessage(msg);
    setMessageType("error");
    setShowMessage(true);

    // Opcionalmente ocultamos el mensaje después de 3 segundos
    setTimeout(() => {
      setShowMessage(false);
    }, 3000);
  };

  const grupo = {
    idGrupoI: 0,
    idModeloVehiculoI: modeloVehiculo,
    codigoC: "0",
    cantMaxIntegrantesI: cantMaxIntegrantes,
    fechaCreacionD: new Date().toISOString(), 
    fechaInicioPanderoD: null,
    estadoC: "E",
    cantidadCuotasI: cantidadCuotas,
    tipoPeriodoPagoC: tipoPeriodoPago,
    precioUnidadVehiculoM : precioVehiculo
  };

  return (
    <div className="container mt-4 mb-4">
      <h3 className="mb-4">Grupos</h3>

      {/* Sección de búsqueda */}
      <div className="d-flex flex-column flex-sm-row align-items-center mb-3">
        <label htmlFor="searchDropdown" className="form-label me-2">
          Buscar Grupo:
        </label>
        <select
          id="searchDropdown"
          className="form-select me-2 mb-2 mb-sm-0"
          style={{ width: '250px' }}
          value={selectedOption}
          onChange={handleOptionChange}
        >
          <option value="">Seleccione un Grupo</option>
          <option value="nombre1">Nombre 1</option>
          <option value="nombre2">Nombre 2</option>
          <option value="nombre3">Nombre 3</option>
        </select>
        <button className="btn btn-primary me-2">
          Buscar
        </button>
      </div>

      {/* Botones Crear y Unirse a Grupo */}
      <div className="mb-3 d-flex flex-column flex-sm-row">
        <button className="btn btn-primary me-2 mb-2 mb-sm-0" onClick={() => toggleCreateJoinModal(false)}>
          Crear Grupo
        </button>
        <button className="btn btn-secondary" onClick={() => toggleCreateUModal(true)}>
          Unirse a Grupo
        </button>
      </div>
      {showMessage && (
            <div
              className={`alert ${messageType === "success" ? "alert-success" : "alert-danger"}`}
              role="alert"
            >
              {message}
            </div>
          )}

      {showCreateJoinModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h5>Configuración</h5>
            <form className="mb-4" onSubmit={(e) => e.preventDefault()}>
              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Modelo de Vehículo</label>
                <select 
                  className="form-control w-75"
                  id="modeloVehiculo"
                  value={modeloVehiculo}
                  onChange={handleModeloVehiculo}
                  required>
                  <option value="">Seleccione un modelo</option>
                  {modelos.map((modelo) => (
                    <option key={modelo.idModeloVehiculoI} value={modelo.idModeloVehiculoI}>
                      {modelo.nombreNv}
                    </option>
                  ))}
                </select>
              </div>

              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Precio</label>
                <input
                  id="precioVehiculo"
                  type="number"
                  className="form-control w-75"
                  placeholder="Precio"
                  value={precioVehiculo} // Enlace al estado precioVehiculo
                  readOnly
                />
              </div>

              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Cantidad de Integrantes</label>
                <select 
                  className="form-control w-75"
                  id="cantMaxIntegrantes"
                  value={cantMaxIntegrantes}
                  onChange={(e) => setCantMaxIntegrantes(e.target.value)}
                  required
                  >
                  <option value="">Seleccione cantidad</option>
                  <option value="20">20</option>
                  <option value="25">25</option>
                  <option value="30">30</option>
                </select>
              </div>

              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Número de Cuotas</label>
                <select 
                className="form-control w-75"
                id="cantidadCuotas"
                value={cantidadCuotas}
                onChange={(e) => setCantidadCuotas(e.target.value)}
                required
                >
                  <option value="">Seleccione cuotas</option>
                  <option value="1">1</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                </select>
              </div>

              <div className="mb-3 d-flex flex-column flex-sm-row align-items-center">
                <label className="me-2 w-25">Periodo</label>
                <select 
                className="form-control w-75"
                id="tipoPeriodoPago"
                value={tipoPeriodoPago}
                onChange={(e) => setTipoPeriodoPago(e.target.value)}
                required
                >
                  <option value="">Seleccione periodo</option>
                  <option value="M">Mensual</option>
                  <option value="S">Semestral</option>
                  <option value="A">Anual</option>
                </select>
              </div>

              <div className="mb-3">
                <button className="btn btn-primary me-2" onClick={crearGrupoModal}>
                  Crear Grupo
                </button>
                <button className="btn btn-secondary" onClick={handleCloseModal}>
                  Cancelar
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {showCreateUModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h5>Ingrese Código de Invitación</h5>
            <form className="mb-4" onSubmit={handleUnirseGrupo}>
              <div className="mb-3 d-flex justify-content-center">
                <input
                  type="text"
                  className="form-control w-75 text-center"
                  placeholder="Código"
                  onChange={(e) => setCodigoGrupo(e.target.value)}
                />
              </div>
              <div className="mb-3">
                <button type="submit" className="btn btn-primary me-2">
                  Unirse
                </button>
                <button
                  type="button"
                  className="btn btn-secondary"
                  onClick={handleCloseModal}
                >
                  Cancelar
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      {/* Tabla de grupos */}
      <div className="table-responsive">
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Código</th>
            <th>Estado</th>
            <th>Fecha de Inicio</th>
            <th>Cuota</th>
            <th>Periodo</th>
            <th>Detalles</th>
            <th>Integrantes</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {gruposCliente.map((item) => (
            <tr key={item.idGrupoI}>
              <td>{item.codigoC}</td>
              <td>
                {({
                  'A': 'Abierto',
                  'C': 'Cerrado',
                  'F': 'Funcionando',
                  'T': 'Terminado'
                })[item.estadoC] || 'En Espera'}
              </td>
              <td>{new Date(item.fechaInicioPanderoD).toLocaleDateString()}</td>
              <td>{item.precioUnidadVehiculoM}</td>
              <td>{item.tipoPeriodoPagoC}</td>
              <td>
                <button
                  className={documentosDisponibles[item.idGrupoI]?.estado !== 'A'?"btn btn-secondary":"btn btn-primary"}
                  onClick={() => handleShowDetails('Detalles del grupo')}
                  disabled={documentosDisponibles[item.idGrupoI]?.estado !== 'A'}
                >
                  Ver
                </button>
              </td>
              <td>
                <button
                  className={documentosDisponibles[item.idGrupoI]?.estado !== 'A'?"btn btn-secondary":"btn btn-primary"}
                  onClick={() => handleShowDetails('Integrantes del grupo')}
                  disabled={documentosDisponibles[item.idGrupoI]?.estado !== 'A'}
                >
                  Ver
                </button>
              </td>
              <td>
                {/* Mostrar el botón "Subir Documentos" si no hay documento */}
                {!documentosDisponibles[item.idGrupoI] && (
                  <button
                    className="btn btn-warning"
                    onClick={() => handleDocumento(item)}
                  >
                    Subir Documentos
                  </button>
                )}

                {/* Mostrar "Verificando Documentos" si el estado del documento es "P" */}
                {documentosDisponibles[item.idGrupoI]?.estado === 'P' && (
                  <button
                    className="btn btn-secondary"
                    onClick={() => handleEdit(item)}
                    disabled={true}
                  >
                    Verificando Documentos
                  </button>
                )}

                {/* Mostrar "Unirse al Grupo" si el estado del documento es "A" */}
                {documentosDisponibles[item.idGrupoI]?.estado === 'A' && (
                  <button
                    className="btn btn-success"
                    onClick={() => handleEdit(item)}
                  >
                    Unirse Grupo
                  </button>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
    {/* Modal para guardar documentos */}
    <ModalGuardarDocumento
        show={showModal}
        onClose={handleCloseModal}
        onSave={handleSaveDocumentos}
      />

      {/* Modal de detalles */}
      {modalContent && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h5>{modalContent}</h5>
            <button className="btn btn-secondary" onClick={handleCloseModal}>
              Cerrar
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Grupos;
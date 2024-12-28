import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, StyleSheet } from 'react-native';
import { useCliente } from '../hooks/useCliente';
import { Picker } from '@react-native-picker/picker';
import { useGrupo } from '../hooks/useGrupo';
import { useEstadoCuenta } from '../hooks/useEstadoCuenta';
import { useCuota } from '../hooks/useCuota';
import styles from '../assets/css/Detalles';


const Detalles = () => {
  const { getClienteFromAsyncStorage } = useCliente(); 
  const { getGruposPorCliente } = useGrupo();
  const { obtenerEstadoCuentaCliente, obtenerDetallesEstadoCuentaCliente } = useEstadoCuenta();
  const { listarCuotasClienteGrupo } = useCuota();

  const [grupoSeleccionado, setGrupoSeleccionado] = useState('');
  const [clienteData, setClienteData] = useState();
  const [gruposCliente, setGruposCliente] = useState([]);
  const [estadoCuenta, setEstadoCuenta] = useState();
  const [cuotas, setCuotas] = useState([]);
  const [fechaFinalizacion, setFechaFinalizacion] = useState();
  const [montoFaltante, setMontoFaltante] = useState();

  useEffect(() => {
    const fetchClienteData = async () => {
      const clienteLogin = await getClienteFromAsyncStorage();
      if (clienteLogin) {
        setClienteData(clienteLogin);
        const listaGrupo = await getGruposPorCliente(clienteLogin);
        setGruposCliente(listaGrupo);
      }
    };
    fetchClienteData();
  }, []); 

  useEffect(() => {
    const fetchEstados = async () => {
      const datosGrupo = gruposCliente.find(grupo => grupo.codigoC === grupoSeleccionado);
      if (datosGrupo) {
        const x_estCuenta = await obtenerEstadoCuentaCliente(clienteData.idClienteI, datosGrupo.idGrupoI);
        const x_cuotas = await listarCuotasClienteGrupo(clienteData.idClienteI, datosGrupo.idGrupoI);
        if (x_estCuenta && x_cuotas) {
          setEstadoCuenta(x_estCuenta.objeto);
          setCuotas(x_cuotas.objeto);
        }
      }
    };
    if (grupoSeleccionado && clienteData) {
      fetchEstados();
    }
  }, [grupoSeleccionado, clienteData]);

  useEffect(() => {
    if (cuotas && estadoCuenta && grupoSeleccionado) {
      const datosGrupo = gruposCliente.find(grupo => grupo.codigoC === grupoSeleccionado);
      let ultimaCuota = cuotas[cuotas.length - 1];
      let montoFal = datosGrupo.precioUnidadVehiculoM - estadoCuenta.montoRecaudadoN;
      if (ultimaCuota && montoFal) {
        setFechaFinalizacion(ultimaCuota.fechaFinD);
        setMontoFaltante(montoFal);
      }
    }
  }, [cuotas, estadoCuenta, grupoSeleccionado]);

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Detalles</Text>
      <View style={styles.row}>
        <Text style={styles.label}>Grupo:</Text>
        <Picker
          selectedValue={grupoSeleccionado}
          style={styles.picker}
          onValueChange={itemValue => setGrupoSeleccionado(itemValue)}
        >
          <Picker.Item label="Seleccione un Grupo" value="" />
          {gruposCliente.map(grupo => (
            <Picker.Item key={grupo.idGrupoI} label={grupo.codigoC} value={grupo.codigoC} />
          ))}
        </Picker>
      </View>

      <View>
        <Text style={styles.textBold}>Fecha Apertura:</Text>
        <Text>{estadoCuenta ? new Date(estadoCuenta.fechaAperturaD).toLocaleDateString() : 'Grupo no iniciado.'}</Text>
        
        <Text style={styles.textBold}>Monto Aportado:</Text>
        <Text>{estadoCuenta ? `S/.${estadoCuenta.montoRecaudadoN.toFixed(2)}` : 'Grupo no iniciado.'}</Text>
        
        <Text style={styles.textBold}>Estado:</Text>
        <Text>{estadoCuenta ? 'En Proceso.' : 'Grupo no iniciado.'}</Text>

        <Text style={styles.textBold}>Fecha Finalización:</Text>
        <Text>{estadoCuenta && fechaFinalizacion ? new Date(fechaFinalizacion).toLocaleDateString() : 'Grupo no iniciado.'}</Text>
        
        <Text style={styles.textBold}>Monto Faltante:</Text>
        <Text>{estadoCuenta && montoFaltante ? `S/.${montoFaltante.toFixed(2)}` : 'Grupo no iniciado.'}</Text>

        <FlatList
          data={estadoCuenta?.detalleEstadoCuenta || []}
          keyExtractor={item => item.idDetalleEstadoCuentaI.toString()}
          renderItem={({ item, index }) => (
            <View style={styles.row}>
              <Text>{index + 1}. {item.tipoOperacionC} - {item.monto} - {new Date(item.fechaPagoDt).toLocaleDateString()} - {item.codigoPagoV}</Text>
            </View>
          )}
        />
      </View>

      <View style={styles.cuotasContainer}>
        <FlatList
          data={cuotas || []}
          keyExtractor={item => item.idCuotaI.toString()}
          renderItem={({ item }) => (
            <View style={styles.row}>
              <Text>{item.numCuotaI}. {`S/. ${item.montoCuotaN.toFixed(2)}`} - {item.penalidadN > 0 ? `S/. ${item.penalidadN.toFixed(2)}` : 'Sin Penalidad'} - {new Date(item.fechaInicioD).toLocaleDateString()} - {new Date(item.fechaFinD).toLocaleDateString()} - {item.estadoCuotaC === 'P' ? 'Pendiente' : 'Abonado'}</Text>
            </View>
          )}
          ListEmptyComponent={<Text>No hay cuotas disponibles</Text>}
        />
      </View>
    </View>
  );
};

export default Detalles;

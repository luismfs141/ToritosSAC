import React, { useState, useEffect } from 'react';
import { View, Text, TouchableOpacity, ScrollView, Alert } from 'react-native';
import { Picker } from '@react-native-picker/picker';
import { LinearGradient } from 'expo-linear-gradient';
import styles from '../assets/css/Cronograma';
import { useEstadoCuenta } from '../hooks/useEstadoCuenta';
import { useCliente } from '../hooks/useCliente';
import { useGrupo } from '../hooks/useGrupo';

export default function Cronograma() {
  const { ObtenerEstadosCuentaPorIdClienteGrupo } = useEstadoCuenta();
  const { getClienteFromAsyncStorage } = useCliente();
  const { getGruposPorCliente, getDetallesGrupo } = useGrupo();

  const [clienteData, setClienteData] = useState(null);
  const [estadosCuenta, setEstadosCuenta] = useState([]);
  const [gruposCliente, setGruposCliente] = useState([]);
  const [grupoSeleccionado, setGrupoSeleccionado] = useState('');
  const [detallesGrupo, setDetallesGrupo] = useState(null);
  const [montoSorteo, setMontoSorteo] = useState(0);
  const [isInitialized, setIsInitialized] = useState(false);
  const [numIntegrantes, setNumIntegrantes] = useState(0);

  useEffect(() => {
    const initializeCliente = async () => {
      if (!isInitialized) {
        const clienteLogin = await getClienteFromAsyncStorage();
        if (clienteLogin) {
          setClienteData(clienteLogin);
          const listaGrupo = await getGruposPorCliente(clienteLogin.idClienteI);
          setGruposCliente(listaGrupo);
        }
        setIsInitialized(true);
      }
    };

    initializeCliente();
  }, [isInitialized, getClienteFromAsyncStorage, getGruposPorCliente]);

  useEffect(() => {
    const fetchEstadosCuenta = async () => {
      setEstadosCuenta([]);
      if (grupoSeleccionado && clienteData) {
        const datosGrupo = gruposCliente.find(
          (grupo) => grupo.codigoC === grupoSeleccionado
        );
        if (datosGrupo) {
          const listaEstadosCuentas = await ObtenerEstadosCuentaPorIdClienteGrupo(
            clienteData.idClienteI,
            datosGrupo.idGrupoI
          );
          const detallesGrupo = await getDetallesGrupo(datosGrupo.idGrupoI);
          setDetallesGrupo(detallesGrupo);
          if (listaEstadosCuentas && listaEstadosCuentas.exito) {
            setEstadosCuenta(listaEstadosCuentas.objeto);
          }
        }
      }
    };

    if (grupoSeleccionado && clienteData) {
      fetchEstadosCuenta();
    }
  }, [grupoSeleccionado]);

  useEffect(() => {
    if (detallesGrupo) {
      setMontoSorteo(detallesGrupo.modeloVehiculo.precioUnidadVehiculoM);
      setNumIntegrantes(detallesGrupo.numeroIntegrantes);
    }
  }, [detallesGrupo]);

  let periodo = 1;
  let montoPeriodo = 0;

  const handleSearch = () => {
    Alert.alert('Buscar', `Grupo seleccionado: ${grupoSeleccionado}`);
  };

  const handleExportPDF = () => {
    Alert.alert('Exportar PDF', 'Función de exportación en desarrollo.');
  };

  return (
    <View style={styles.container}>
      <LinearGradient colors={['#50007b', '#50007b']} style={styles.headerContainer}>
        <Text style={styles.headerText}>Cronograma</Text>
      </LinearGradient>

      <View style={styles.dropdownContainer}>
        <Text style={styles.label}>Grupo:</Text>
        <Picker
          selectedValue={grupoSeleccionado}
          style={styles.picker}
          onValueChange={(itemValue) => setGrupoSeleccionado(itemValue)}
        >
          <Picker.Item label="Seleccione un Grupo" value="" />
          {gruposCliente.map((grupo) => (
            <Picker.Item
              key={grupo.idGrupoI}
              label={grupo.codigoC}
              value={grupo.codigoC}
            />
          ))}
        </Picker>
      </View>

      <View style={styles.buttonContainer}>
        <TouchableOpacity style={styles.button} onPress={handleSearch}>
          <Text style={styles.buttonText}>Buscar</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={handleExportPDF}>
          <Text style={styles.buttonText}>Exportar PDF</Text>
        </TouchableOpacity>
      </View>

      <ScrollView style={styles.tableContainer}>
        <View style={styles.tableHeader}>
          <Text style={styles.tableHeaderText}>Nro Cuota</Text>
          <Text style={styles.tableHeaderText}>Fecha de Pago</Text>
          <Text style={styles.tableHeaderText}>Monto</Text>
          <Text style={styles.tableHeaderText}>Cuota Grupal</Text>
          <Text style={styles.tableHeaderText}>Sorteo</Text>
          <Text style={styles.tableHeaderText}>Martillazo</Text>
        </View>
        {estadosCuenta && estadosCuenta.length > 0 ? (
          estadosCuenta.map((estado, index) => {
            const montoAcumulativo = estado.nroCuotaI * estado.montoCuotaM * numIntegrantes;
            const esSorteoExitoso = montoAcumulativo % montoSorteo === 0;

            if (esSorteoExitoso) {
              periodo = periodo + 1;
              montoPeriodo = montoAcumulativo + montoSorteo / 2;
            }

            let activarMartillazo =
              montoPeriodo > 0 && montoPeriodo < montoAcumulativo ? 'SI' : 'NO';

            return (
              <View
                key={index}
                style={[
                  styles.tableRow,
                  esSorteoExitoso && styles.tableRowSuccess,
                ]}
              >
                <Text style={styles.tableRowText}>{estado.nroCuotaI}</Text>
                <Text style={styles.tableRowText}>
                  {estado.fechaPagoProgramadaD
                    ? new Date(estado.fechaPagoProgramadaD).toLocaleDateString()
                    : 'No Disponible'}
                </Text>
                <Text style={styles.tableRowText}>
                  {estado.montoCuotaM
                    ? `S/.${estado.montoCuotaM.toFixed(2)}`
                    : 'No Disponible'}
                </Text>
                <Text style={styles.tableRowText}>
                  {estado.montoCuotaM
                    ? `S/.${montoAcumulativo.toFixed(2)}`
                    : 'No Disponible'}
                </Text>
                <Text style={styles.tableRowText}>
                  {esSorteoExitoso ? 'SI' : 'NO'}
                </Text>
                <Text style={styles.tableRowText}>{activarMartillazo}</Text>
              </View>
            );
          })
        ) : (
          <Text style={styles.noDataText}>No hay datos disponibles</Text>
        )}
      </ScrollView>
    </View>
  );
}

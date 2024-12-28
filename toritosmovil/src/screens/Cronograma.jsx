import React, { useState, useEffect } from 'react';
import { View, Text, FlatList, StyleSheet, TouchableOpacity } from 'react-native';
import { useCliente } from '../hooks/useCliente';
import { Picker } from '@react-native-picker/picker';
import { useGrupo } from '../hooks/useGrupo';
import { useCronograma } from '../hooks/useCronograma';
import styles from '../assets/css/Cronograma';

const Cronograma = () => {
  const { getClienteFromAsyncStorage } = useCliente();
  const { getGruposPorCliente } = useGrupo();
  const { obtenerCronogramaGrupo } = useCronograma();

  const [clienteData, setClienteData] = useState(null);
  const [gruposCliente, setGruposCliente] = useState([]);
  const [grupoSeleccionado, setGrupoSeleccionado] = useState('');
  const [cronograma, setCronograma] = useState([]);

  useEffect(() => {
    const obtenerCliente = async () => {
      const clienteLogin = await getClienteFromAsyncStorage();
      if (clienteLogin) {
        setClienteData(clienteLogin);
        const listaGrupo = await getGruposPorCliente(clienteLogin);
        setGruposCliente(listaGrupo);
      }
    };

    obtenerCliente(); 
  }, []); 

  useEffect(() => {
    const fetchEstadosCuenta = async () => {
      if (!grupoSeleccionado || !clienteData) return; 
      setCronograma([]);

      const datosGrupo = gruposCliente.find(grupo => grupo.codigoC === grupoSeleccionado);
      if (datosGrupo) {
        const listaCronograma = await obtenerCronogramaGrupo(datosGrupo.idGrupoI);
        if (listaCronograma && listaCronograma.exito) {
          if (JSON.stringify(cronograma) !== JSON.stringify(listaCronograma.objeto)) {
            setCronograma(listaCronograma.objeto);
          }
        }
      }
    };

    fetchEstadosCuenta();
  }, [grupoSeleccionado, clienteData, gruposCliente, obtenerCronogramaGrupo]); 

  const handleGrupoChange = (value) => {
    if (value !== grupoSeleccionado) {
      setGrupoSeleccionado(value);
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Cronograma</Text>

      <View style={styles.dropdownContainer}>
        <Text style={styles.label}>Grupo:</Text>
        <Picker
          selectedValue={grupoSeleccionado}
          style={styles.picker}
          onValueChange={handleGrupoChange}>
          <Picker.Item label="Seleccione un Grupo" value="" />
          {gruposCliente.map(grupo => (
            <Picker.Item key={grupo.idGrupoI} label={grupo.codigoC} value={grupo.codigoC} />
          ))}
        </Picker>
      </View>

      <FlatList
        data={cronograma}
        keyExtractor={(item, index) => item.idCronogramaI ? item.idCronogramaI.toString() : String(index)} 
        renderItem={({ item, index }) => (
          <View style={[styles.row, item.habilitarMartillazoB && !item.habilitarSorteoB
            ? styles.warningRow
            : item.habilitarSorteoB
              ? styles.successRow
              : null]}>
            <Text style={styles.cell}>{index + 1}</Text>
            <Text style={styles.cell}>{item.fechaD ? new Date(item.fechaD).toLocaleDateString() : 'No Disponible'}</Text>
            <Text style={styles.cell}>{item.cuotaIndividualN ? `S/.${item.cuotaIndividualN.toFixed(2)}` : 'No Disponible'}</Text>
            <Text style={styles.cell}>{item.cuotaGrupalN ? `S/.${item.cuotaGrupalN.toFixed(2)}` : 'No Disponible'}</Text>
            <Text style={styles.cell}>{item.habilitarSorteoB ? 'SI' : 'NO'}</Text>
            <Text style={styles.cell}>{item.habilitarMartillazoB ? 'SI' : 'NO'}</Text>
          </View>
        )}
      />
    </View>
  );
};


export default Cronograma;

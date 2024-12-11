import React, { useState } from 'react';
import { View, Text, TouchableOpacity, ScrollView, Alert } from 'react-native';
import { Picker } from '@react-native-picker/picker';
import { LinearGradient } from 'expo-linear-gradient';
import styles from '../assets/css/Cronograma';

export default function Cronograma() {
  const [selectedOption, setSelectedOption] = useState('');

  const handleOptionChange = (itemValue) => {
    setSelectedOption(itemValue);
  };

  const handleSearch = () => {
    Alert.alert('Buscar', `Grupo seleccionado: ${selectedOption}`);
  };

  const handleExportPDF = () => {
    Alert.alert('Exportar PDF', 'Función de exportación en desarrollo.');
  };

  return (
    <View style={styles.container}>
      <LinearGradient colors={['#50007b', '#50007b']} style={styles.headerContainer}>
        <Text style={styles.headerText}>Detalles</Text>
      </LinearGradient>

      <View style={styles.dropdownContainer}>
        <Text style={styles.label}>Grupo:</Text>
        <Picker
          selectedValue={selectedOption}
          style={styles.picker}
          onValueChange={handleOptionChange}
        >
          <Picker.Item label="Seleccione un Grupo" value="" />
          <Picker.Item label="Nombre 1" value="nombre1" />
          <Picker.Item label="Nombre 2" value="nombre2" />
          <Picker.Item label="Nombre 3" value="nombre3" />
        </Picker>
      </View>

      <View style={styles.buttonContainer}>
        <TouchableOpacity style={styles.button} onPress={handleSearch}>
          <Text style={styles.buttonText}>Buscar</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.button} onPress={handleExportPDF}>
          <Text style={styles.buttonText}>Filtro</Text>
        </TouchableOpacity>
      </View>

      <ScrollView style={styles.tableContainer} horizontal>
        <View style={styles.tableHeader}>
          <Text style={styles.tableHeaderText}>Nro Cuota</Text>
          <Text style={styles.tableHeaderText}>Monto</Text>
          <Text style={styles.tableHeaderText}>Prioridad</Text>
          <Text style={styles.tableHeaderText}>Total</Text>
          <Text style={styles.tableHeaderText}>Fecha de Pago</Text>
          <Text style={styles.tableHeaderText}>Estado</Text>
          <Text style={styles.tableHeaderText}>Vaucher</Text>
        </View>
        {/* Aquí mapear las filas de la tabla */}
      </ScrollView>
    </View>
  );
}

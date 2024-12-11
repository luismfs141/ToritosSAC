import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import styles from '../assets/css/Login.js';

export default function Login({ navigation }) {
  const [nombre_usuario, setNombreUsuario] = useState('');
  const [contraseña, setContraseña] = useState('');

  const handleLogin = () => {
    if (nombre_usuario && contraseña) {
      Alert.alert('Bienvenido', `Usuario: ${nombre_usuario}`);
      navigation.navigate('Tabs');
    } else {
      Alert.alert('Error', 'Por favor, ingrese usuario y contraseña');
    }
  };

  return (
    <View style={styles.container}>
      <LinearGradient colors={['#50007b', '#1b0030']} style={styles.logoContainer}>
        <View style={styles.logo}>
          <Text style={styles.logoText}>🙂</Text>
        </View>
      </LinearGradient>

      <Text style={styles.header}>ToritosSAC</Text>
      <Text style={styles.subHeader}>Inicia Sesion</Text>

      <TextInput
        style={styles.input}
        placeholder="usuario"
        placeholderTextColor="#aaa"
        value={nombre_usuario}
        onChangeText={setNombreUsuario}
      />
      <TextInput
        style={styles.input}
        placeholder="••••••"
        placeholderTextColor="#aaa"
        secureTextEntry={true}
        value={contraseña}
        onChangeText={setContraseña}
      />

      <TouchableOpacity>
        <Text style={styles.forgotText}>¿Ha olvidado su contraseña?</Text>
      </TouchableOpacity>

      <TouchableOpacity
        style={styles.signInButton}
        onPress={handleLogin}
      >
        <LinearGradient
          colors={['#50007b', '#1b0030']}
          style={styles.signInGradient}
        >
          <Text style={styles.signInText}>
            INICIAR SESIÓN
          </Text>
        </LinearGradient>
      </TouchableOpacity>

      <View style={styles.footer}>
        <Text style={styles.footerText}>¿No tienes una cuenta? </Text>
        <TouchableOpacity>
          <Text style={styles.createText}>Registrar</Text>
        </TouchableOpacity>
      </View>
    </View>
  );
}

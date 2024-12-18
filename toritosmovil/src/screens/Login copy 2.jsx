import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import styles from '../assets/css/Login.js';
import { useCliente } from '../hooks/useCliente';

export default function Login({ navigation }) {
    const [usuario, setUsuario] = useState('');
    const [password, setPassword] = useState('');
    const { loginCliente, loading, error } = useCliente();

    const handleLogin = async () => {
        if (usuario && password) {
            try {
                await loginCliente(usuario, btoa(password));
                navigation.replace('Tabs');
            } catch (err) {
                console.error('Error de inicio de sesión:', err);
                Alert.alert('Error', 'Usuario o contraseña incorrectos');
            }
        } else {
            Alert.alert('Error', 'Por favor, ingrese su usuario y contraseña');
        }
    };

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Iniciar Sesión</Text>
            {error && <Text style={styles.errorText}>{error}</Text>}
            <TextInput
                style={styles.input}
                placeholder="Usuario"
                value={usuario}
                onChangeText={setUsuario}
            />
            <TextInput
                style={styles.input}
                placeholder="Contraseña"
                secureTextEntry
                value={password}
                onChangeText={setPassword}
            />
            <Button
                title={loading ? 'Cargando...' : 'Iniciar sesión'}
                onPress={handleLogin}
                disabled={loading}
            />
        </View>
    );
}
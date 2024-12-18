import React from 'react';
import { View, Text, StyleSheet, ScrollView, TouchableOpacity, Linking } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import styles from '../assets/css/Soporte';

const Soporte = () => {
    return (
        <ScrollView contentContainerStyle={styles.container}>
            <LinearGradient colors={['#50007b', '#50007b']} style={styles.headerContainer}>
                <Text style={styles.header}>Soporte de Toritos SAC</Text>
            </LinearGradient>

            <Text style={styles.subHeader}>Contáctanos</Text>
            <Text style={styles.text}>¿Tienes alguna pregunta o necesitas asistencia? ¡Estamos aquí para ayudarte!</Text>

            <View style={styles.contactContainer}>
                <Text style={styles.contactText}>Teléfono: <Text style={styles.contactDetail}>+51 987 654 321</Text></Text>
                <TouchableOpacity onPress={() => Linking.openURL('mailto:soporte@toritossac.com')}>
                    <Text style={styles.contactText}>Correo electrónico: <Text style={styles.contactDetail}>soporte@toritossac.com</Text></Text>
                </TouchableOpacity>
                <TouchableOpacity onPress={() => Linking.openURL('https://wa.me/51987654321')}>
                    <Text style={styles.contactText}>WhatsApp: <Text style={styles.contactDetail}>+51 987 654 321</Text></Text>
                </TouchableOpacity>
            </View>

            <Text style={styles.subHeader}>Preguntas Frecuentes</Text>
            <View style={styles.faqContainer}>
                <Text style={styles.faqQuestion}>1. ¿Cómo puedo adquirir un mototaxi de Toritos SAC?</Text>
                <Text style={styles.faqAnswer}>Para adquirir un mototaxi, puedes contactar con nuestro equipo de ventas a través de los canales de contacto mencionados arriba. Ofrecemos financiamiento y opciones a medida.</Text>
            </View>

            <View style={styles.faqContainer}>
                <Text style={styles.faqQuestion}>2. ¿Qué tipo de mototaxis ofrecen?</Text>
                <Text style={styles.faqAnswer}>En Toritos SAC ofrecemos mototaxis de alta calidad, con motores de 150cc a 200cc, ideales para el transporte urbano y rural. También contamos con modelos eléctricos.</Text>
            </View>

            <View style={styles.faqContainer}>
                <Text style={styles.faqQuestion}>3. ¿Cómo puedo solicitar mantenimiento para mi mototaxi?</Text>
                <Text style={styles.faqAnswer}>Puedes solicitar mantenimiento a través de nuestros canales de contacto. Nuestro equipo de servicio técnico está disponible para atención presencial o en línea.</Text>
            </View>
        </ScrollView>
    );
};

export default Soporte;

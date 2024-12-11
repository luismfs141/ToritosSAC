import React, { useState } from 'react';
import { View, TouchableOpacity, StyleSheet } from 'react-native';
import { Ionicons, FontAwesome5, MaterialCommunityIcons } from '@expo/vector-icons';
import { useNavigation } from '@react-navigation/native';

const Menu = () => {
  const [activeIndex, setActiveIndex] = useState(0);
  const navigation = useNavigation();

  const handleClick = (index, screen) => {
    setActiveIndex(index);
    navigation.navigate(screen); 
  };

  const menuItems = [
    { icon: <Ionicons name="help-circle-outline" size={24} color="#FFF" />, key: 0, screen: 'Soporte' },
    { icon: <FontAwesome5 name="calendar" size={24} color="#FFF" />, key: 1, screen: 'Cronograma' },
    { icon: <MaterialCommunityIcons name="chart-line" size={24} color="#FFF" />, key: 2, screen: 'Statistics' },
    { icon: <Ionicons name="chatbox-ellipses-outline" size={24} color="#FFF" />, key: 3, screen: 'Chat' },
    { icon: <Ionicons name="settings-outline" size={24} color="#FFF" />, key: 4, screen: 'Settings' },
  ];

  return (
    <View style={styles.menuContainer}>
      <View style={styles.menu}>
        {menuItems.map((item) => (
          <TouchableOpacity
            key={item.key}
            style={[styles.menuItem, activeIndex === item.key && styles.active]}
            onPress={() => handleClick(item.key, item.screen)}
          >
            {item.icon}
          </TouchableOpacity>
        ))}
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  menuContainer: {
    flex: 1,
    justifyContent: 'flex-end',
    alignItems: 'center',
    backgroundColor: '#f5f5f5',
  },
  menu: {
    flexDirection: 'row',
    backgroundColor: '#1b0030',
    paddingVertical: 10,
    width: '100%',
    justifyContent: 'space-around',
  },
  menuItem: {
    justifyContent: 'center',
    alignItems: 'center',
    padding: 10,
  },
  active: {
    backgroundColor: '#320042',
    borderRadius: 10,
  },
});

export default Menu;

import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({
  menuContainer: {
    flex: 1,
    justifyContent: 'flex-end',
    alignItems: 'center',
    backgroundColor: '#f5f5f5',
  },
  menu: {
    flexDirection: 'row',
    position: 'absolute',
    bottom: 20,
    alignItems: 'center',
    backgroundColor: '#1b0030',
    paddingHorizontal: 15,
    height: 70,
    borderRadius: 35,
    width: '90%',
    justifyContent: 'space-between',
  },
  menuItem: {
    justifyContent: 'center',
    alignItems: 'center',
    width: 50,
    height: 50,
  },
  active: {
    width: 60,
    height: 60,
    top: -10,
    backgroundColor: 'transparent',
  },
  iconContainer: {
    justifyContent: 'center',
    alignItems: 'center',
  },
  indicator: {
    position: 'absolute',
    width: 70,
    height: 70,
    borderRadius: 35,
    backgroundColor: '#320042',
    top: -10,
    borderWidth: 4,
    borderColor: '#fff',
  },
});

export default styles;
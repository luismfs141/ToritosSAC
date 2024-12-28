import { StyleSheet } from 'react-native';

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    backgroundColor: '#f4f4f9', 
  },
  title: {
    fontSize: 28,
    fontWeight: 'bold',
    color: '#50007b',
    marginBottom: 20,
    textAlign: 'center',
  },
  row: {
    flexDirection: 'row',
    marginBottom: 15,
    alignItems: 'center',
  },
  picker: {
    height: 50,
    width: '80%',
    backgroundColor: '#fff',
    borderRadius: 8,
    borderWidth: 1,
    borderColor: '#ccc',
    paddingLeft: 10,
    marginLeft: 10,
  },
  label: {
    fontSize: 16,
    color: '#1b0030',
    fontWeight: '500',
  },
  textBold: {
    fontWeight: 'bold',
    color: '#50007b',
  },
  text: {
    fontSize: 16,
    color: '#666',
  },
  cuotasContainer: {
    marginTop: 25,
    backgroundColor: '#fff',
    borderRadius: 8,
    paddingTop: 15,
    paddingBottom: 5,
    paddingLeft: 15,
    paddingRight: 15,
    height: 250,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.1,
    shadowRadius: 6,
    elevation: 5,
  },
  flatListEmpty: {
    textAlign: 'center',
    fontSize: 16,
    color: '#777',
    marginTop: 20,
  },
  separator: {
    height: 1,
    backgroundColor: '#ddd',
    marginVertical: 10,
  },
});

export default styles;

import apiClient from './api';

export const authService = {
  login: (email, password) => {
    return apiClient.post('/auth/login', { email, password });
  },

  logout: () => {
    return apiClient.post('/auth/logout');
  },

  register: (nombre, email, password, rol = 'Usuario') => {
    return apiClient.post('/auth/register', { nombre, email, password, rol });
  }
};

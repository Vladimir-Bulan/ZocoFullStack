import apiClient from './api';

export const userService = {
  getAll: () => {
    return apiClient.get('/usuarios');
  },

  getById: (id) => {
    return apiClient.get(`/usuarios/${id}`);
  }
};

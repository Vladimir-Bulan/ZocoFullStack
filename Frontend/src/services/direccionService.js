import apiClient from './api';

export const direccionService = {
  getAll: () => {
    return apiClient.get('/direcciones');
  },

  getByUsuarioId: (usuarioId) => {
    return apiClient.get(`/direcciones/usuario/${usuarioId}`);
  },

  getById: (id) => {
    return apiClient.get(`/direcciones/${id}`);
  },

  create: (direccion) => {
    return apiClient.post('/direcciones', direccion);
  },

  update: (id, direccion) => {
    return apiClient.put(`/direcciones/${id}`, direccion);
  },

  delete: (id) => {
    return apiClient.delete(`/direcciones/${id}`);
  }
};

import apiClient from './api';

export const estudioService = {
  getAll: () => {
    return apiClient.get('/estudios');
  },

  getByUsuarioId: (usuarioId) => {
    return apiClient.get(`/estudios/usuario/${usuarioId}`);
  },

  getById: (id) => {
    return apiClient.get(`/estudios/${id}`);
  },

  create: (estudio) => {
    return apiClient.post('/estudios', estudio);
  },

  update: (id, estudio) => {
    return apiClient.put(`/estudios/${id}`, estudio);
  },

  delete: (id) => {
    return apiClient.delete(`/estudios/${id}`);
  }
};

import { useState, useEffect } from 'react';
import { estudioService } from '../services/estudioService';

export const EstudioForm = ({ usuarioId, estudio, onClose, onSuccess }) => {
  const [formData, setFormData] = useState({
    institucion: '',
    titulo: '',
    anioInicio: new Date().getFullYear(),
    anioFin: null,
    usuarioId: usuarioId
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  useEffect(() => {
    if (estudio) {
      setFormData({
        institucion: estudio.institucion,
        titulo: estudio.titulo,
        anioInicio: estudio.anioInicio,
        anioFin: estudio.anioFin,
        usuarioId: estudio.usuarioId
      });
    }
  }, [estudio]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');

    try {
      if (estudio) {
        await estudioService.update(estudio.id, formData);
      } else {
        await estudioService.create(formData);
      }
      onSuccess();
    } catch (err) {
      setError('Error al guardar el estudio');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4 z-50">
      <div className="bg-white rounded-lg p-6 max-w-md w-full">
        <h3 className="text-xl font-bold mb-4">
          {estudio ? 'Editar Estudio' : 'Nuevo Estudio'}
        </h3>

        {error && (
          <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-2 rounded mb-4">
            {error}
          </div>
        )}

        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block text-sm font-medium mb-1">Institución</label>
            <input
              type="text"
              value={formData.institucion}
              onChange={(e) => setFormData({...formData, institucion: e.target.value})}
              className="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500"
              required
            />
          </div>

          <div>
            <label className="block text-sm font-medium mb-1">Título</label>
            <input
              type="text"
              value={formData.titulo}
              onChange={(e) => setFormData({...formData, titulo: e.target.value})}
              className="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500"
              required
            />
          </div>

          <div className="grid grid-cols-2 gap-4">
            <div>
              <label className="block text-sm font-medium mb-1">Año Inicio</label>
              <input
                type="number"
                value={formData.anioInicio}
                onChange={(e) => setFormData({...formData, anioInicio: parseInt(e.target.value)})}
                className="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <div>
              <label className="block text-sm font-medium mb-1">Año Fin (opcional)</label>
              <input
                type="number"
                value={formData.anioFin || ''}
                onChange={(e) => setFormData({...formData, anioFin: e.target.value ? parseInt(e.target.value) : null})}
                className="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500"
              />
            </div>
          </div>

          <div className="flex space-x-4 pt-4">
            <button
              type="button"
              onClick={onClose}
              className="flex-1 bg-gray-300 text-gray-700 py-2 rounded hover:bg-gray-400 transition"
            >
              Cancelar
            </button>
            <button
              type="submit"
              disabled={loading}
              className="flex-1 bg-blue-600 text-white py-2 rounded hover:bg-blue-700 transition disabled:opacity-50"
            >
              {loading ? 'Guardando...' : 'Guardar'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

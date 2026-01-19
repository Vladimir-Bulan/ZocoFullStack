import { useState, useEffect } from 'react';
import { direccionService } from '../services/direccionService';

export const DireccionForm = ({ usuarioId, direccion, onClose, onSuccess }) => {
  const [formData, setFormData] = useState({
    calle: '',
    ciudad: '',
    codigoPostal: '',
    pais: '',
    usuarioId: usuarioId
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  useEffect(() => {
    if (direccion) {
      setFormData({
        calle: direccion.calle,
        ciudad: direccion.ciudad,
        codigoPostal: direccion.codigoPostal,
        pais: direccion.pais,
        usuarioId: direccion.usuarioId
      });
    }
  }, [direccion]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');

    try {
      if (direccion) {
        await direccionService.update(direccion.id, formData);
      } else {
        await direccionService.create(formData);
      }
      onSuccess();
    } catch (err) {
      setError('Error al guardar la dirección');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center p-4 z-50">
      <div className="bg-white rounded-lg p-6 max-w-md w-full">
        <h3 className="text-xl font-bold mb-4">
          {direccion ? 'Editar Dirección' : 'Nueva Dirección'}
        </h3>

        {error && (
          <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-2 rounded mb-4">
            {error}
          </div>
        )}

        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block text-sm font-medium mb-1">Calle</label>
            <input
              type="text"
              value={formData.calle}
              onChange={(e) => setFormData({...formData, calle: e.target.value})}
              className="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500"
              required
            />
          </div>

          <div>
            <label className="block text-sm font-medium mb-1">Ciudad</label>
            <input
              type="text"
              value={formData.ciudad}
              onChange={(e) => setFormData({...formData, ciudad: e.target.value})}
              className="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500"
              required
            />
          </div>

          <div className="grid grid-cols-2 gap-4">
            <div>
              <label className="block text-sm font-medium mb-1">Código Postal</label>
              <input
                type="text"
                value={formData.codigoPostal}
                onChange={(e) => setFormData({...formData, codigoPostal: e.target.value})}
                className="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500"
                required
              />
            </div>

            <div>
              <label className="block text-sm font-medium mb-1">País</label>
              <input
                type="text"
                value={formData.pais}
                onChange={(e) => setFormData({...formData, pais: e.target.value})}
                className="w-full px-3 py-2 border rounded focus:ring-2 focus:ring-blue-500"
                required
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

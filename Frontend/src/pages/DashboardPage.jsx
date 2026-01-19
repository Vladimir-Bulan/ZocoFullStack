import { useState, useEffect } from 'react';
import { useAuth } from '../contexts/AuthContext';
import { estudioService } from '../services/estudioService';
import { direccionService } from '../services/direccionService';
import { EstudioForm } from '../components/EstudioForm';
import { DireccionForm } from '../components/DireccionForm';

export const DashboardPage = () => {
  const { user, isAdmin } = useAuth();
  const [estudios, setEstudios] = useState([]);
  const [direcciones, setDirecciones] = useState([]);
  const [loading, setLoading] = useState(true);
  const [showEstudioForm, setShowEstudioForm] = useState(false);
  const [showDireccionForm, setShowDireccionForm] = useState(false);
  const [editingEstudio, setEditingEstudio] = useState(null);
  const [editingDireccion, setEditingDireccion] = useState(null);

  useEffect(() => {
    loadData();
  }, [user]);

  const loadData = async () => {
    try {
      setLoading(true);
      const [estudiosRes, direccionesRes] = await Promise.all([
        estudioService.getByUsuarioId(user.id),
        direccionService.getByUsuarioId(user.id)
      ]);
      setEstudios(estudiosRes.data);
      setDirecciones(direccionesRes.data);
    } catch (error) {
      console.error('Error al cargar datos:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleDeleteEstudio = async (id) => {
    if (window.confirm('¿Estás seguro de eliminar este estudio?')) {
      try {
        await estudioService.delete(id);
        loadData();
      } catch (error) {
        alert('Error al eliminar el estudio');
      }
    }
  };

  const handleDeleteDireccion = async (id) => {
    if (window.confirm('¿Estás seguro de eliminar esta dirección?')) {
      try {
        await direccionService.delete(id);
        loadData();
      } catch (error) {
        alert('Error al eliminar la dirección');
      }
    }
  };

  if (loading) {
    return <div className="flex items-center justify-center h-screen">Cargando...</div>;
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <div className="mb-8">
        <h1 className="text-3xl font-bold text-gray-800">
          Bienvenido, {user.nombre}
        </h1>
        <p className="text-gray-600 mt-2">Gestiona tu perfil, estudios y direcciones</p>
      </div>

      {/* Perfil */}
      <div className="bg-white rounded-lg shadow-md p-6 mb-8">
        <h2 className="text-2xl font-bold mb-4">Mi Perfil</h2>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <div>
            <p className="text-gray-600">Nombre</p>
            <p className="font-semibold">{user.nombre}</p>
          </div>
          <div>
            <p className="text-gray-600">Email</p>
            <p className="font-semibold">{user.email}</p>
          </div>
          <div>
            <p className="text-gray-600">Rol</p>
            <p className="font-semibold">
              <span className={`px-2 py-1 rounded text-white text-sm ${
                isAdmin() ? 'bg-purple-600' : 'bg-blue-600'
              }`}>
                {user.rol}
              </span>
            </p>
          </div>
        </div>
      </div>

      {/* Estudios */}
      <div className="bg-white rounded-lg shadow-md p-6 mb-8">
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-2xl font-bold">Mis Estudios</h2>
          <button
            onClick={() => {
              setEditingEstudio(null);
              setShowEstudioForm(true);
            }}
            className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition"
          >
            + Agregar Estudio
          </button>
        </div>

        {showEstudioForm && (
          <EstudioForm
            usuarioId={user.id}
            estudio={editingEstudio}
            onClose={() => {
              setShowEstudioForm(false);
              setEditingEstudio(null);
            }}
            onSuccess={() => {
              setShowEstudioForm(false);
              setEditingEstudio(null);
              loadData();
            }}
          />
        )}

        {estudios.length === 0 ? (
          <p className="text-gray-500">No tienes estudios registrados</p>
        ) : (
          <div className="space-y-4">
            {estudios.map((estudio) => (
              <div key={estudio.id} className="border border-gray-200 rounded-lg p-4">
                <div className="flex justify-between items-start">
                  <div>
                    <h3 className="font-bold text-lg">{estudio.titulo}</h3>
                    <p className="text-gray-600">{estudio.institucion}</p>
                    <p className="text-sm text-gray-500">
                      {estudio.anioInicio} - {estudio.anioFin || 'Presente'}
                    </p>
                  </div>
                  <div className="flex space-x-2">
                    <button
                      onClick={() => {
                        setEditingEstudio(estudio);
                        setShowEstudioForm(true);
                      }}
                      className="text-blue-600 hover:text-blue-800"
                    >
                      Editar
                    </button>
                    <button
                      onClick={() => handleDeleteEstudio(estudio.id)}
                      className="text-red-600 hover:text-red-800"
                    >
                      Eliminar
                    </button>
                  </div>
                </div>
              </div>
            ))}
          </div>
        )}
      </div>

      {/* Direcciones */}
      <div className="bg-white rounded-lg shadow-md p-6">
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-2xl font-bold">Mis Direcciones</h2>
          <button
            onClick={() => {
              setEditingDireccion(null);
              setShowDireccionForm(true);
            }}
            className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition"
          >
            + Agregar Dirección
          </button>
        </div>

        {showDireccionForm && (
          <DireccionForm
            usuarioId={user.id}
            direccion={editingDireccion}
            onClose={() => {
              setShowDireccionForm(false);
              setEditingDireccion(null);
            }}
            onSuccess={() => {
              setShowDireccionForm(false);
              setEditingDireccion(null);
              loadData();
            }}
          />
        )}

        {direcciones.length === 0 ? (
          <p className="text-gray-500">No tienes direcciones registradas</p>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            {direcciones.map((direccion) => (
              <div key={direccion.id} className="border border-gray-200 rounded-lg p-4">
                <div className="flex justify-between items-start mb-2">
                  <h3 className="font-bold">{direccion.ciudad}</h3>
                  <div className="flex space-x-2">
                    <button
                      onClick={() => {
                        setEditingDireccion(direccion);
                        setShowDireccionForm(true);
                      }}
                      className="text-blue-600 hover:text-blue-800 text-sm"
                    >
                      Editar
                    </button>
                    <button
                      onClick={() => handleDeleteDireccion(direccion.id)}
                      className="text-red-600 hover:text-red-800 text-sm"
                    >
                      Eliminar
                    </button>
                  </div>
                </div>
                <p className="text-gray-600 text-sm">{direccion.calle}</p>
                <p className="text-gray-600 text-sm">
                  {direccion.codigoPostal}, {direccion.pais}
                </p>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
};

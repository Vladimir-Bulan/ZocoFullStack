import { useState, useEffect } from 'react';
import { userService } from '../services/userService';
import { estudioService } from '../services/estudioService';
import { direccionService } from '../services/direccionService';

export const UsuariosPage = () => {
  const [usuarios, setUsuarios] = useState([]);
  const [selectedUser, setSelectedUser] = useState(null);
  const [estudios, setEstudios] = useState([]);
  const [direcciones, setDirecciones] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadUsuarios();
  }, []);

  const loadUsuarios = async () => {
    try {
      const response = await userService.getAll();
      setUsuarios(response.data);
    } catch (error) {
      console.error('Error al cargar usuarios:', error);
    } finally {
      setLoading(false);
    }
  };

  const loadUserDetails = async (userId) => {
    try {
      const [estudiosRes, direccionesRes] = await Promise.all([
        estudioService.getByUsuarioId(userId),
        direccionService.getByUsuarioId(userId)
      ]);
      setEstudios(estudiosRes.data);
      setDirecciones(direccionesRes.data);
    } catch (error) {
      console.error('Error al cargar detalles del usuario:', error);
    }
  };

  const handleSelectUser = (usuario) => {
    setSelectedUser(usuario);
    loadUserDetails(usuario.id);
  };

  if (loading) {
    return <div className="flex items-center justify-center h-screen">Cargando...</div>;
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <h1 className="text-3xl font-bold mb-8">Gestión de Usuarios</h1>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
        {/* Lista de usuarios */}
        <div className="lg:col-span-1">
          <div className="bg-white rounded-lg shadow-md p-6">
            <h2 className="text-xl font-bold mb-4">Usuarios</h2>
            <div className="space-y-2">
              {usuarios.map((usuario) => (
                <div
                  key={usuario.id}
                  onClick={() => handleSelectUser(usuario)}
                  className={`p-4 rounded cursor-pointer transition ${
                    selectedUser?.id === usuario.id
                      ? 'bg-blue-100 border-blue-500 border-2'
                      : 'bg-gray-50 hover:bg-gray-100 border border-gray-200'
                  }`}
                >
                  <div className="font-semibold">{usuario.nombre}</div>
                  <div className="text-sm text-gray-600">{usuario.email}</div>
                  <div className="mt-1">
                    <span className={`px-2 py-1 rounded text-white text-xs ${
                      usuario.rol === 'Admin' ? 'bg-purple-600' : 'bg-blue-600'
                    }`}>
                      {usuario.rol}
                    </span>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>

        {/* Detalles del usuario seleccionado */}
        <div className="lg:col-span-2">
          {selectedUser ? (
            <div className="space-y-6">
              {/* Perfil */}
              <div className="bg-white rounded-lg shadow-md p-6">
                <h2 className="text-2xl font-bold mb-4">Perfil de {selectedUser.nombre}</h2>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div>
                    <p className="text-gray-600">Email</p>
                    <p className="font-semibold">{selectedUser.email}</p>
                  </div>
                  <div>
                    <p className="text-gray-600">Rol</p>
                    <p className="font-semibold">{selectedUser.rol}</p>
                  </div>
                </div>
              </div>

              {/* Estudios */}
              <div className="bg-white rounded-lg shadow-md p-6">
                <h3 className="text-xl font-bold mb-4">Estudios</h3>
                {estudios.length === 0 ? (
                  <p className="text-gray-500">No tiene estudios registrados</p>
                ) : (
                  <div className="space-y-4">
                    {estudios.map((estudio) => (
                      <div key={estudio.id} className="border border-gray-200 rounded-lg p-4">
                        <h4 className="font-bold">{estudio.titulo}</h4>
                        <p className="text-gray-600">{estudio.institucion}</p>
                        <p className="text-sm text-gray-500">
                          {estudio.anioInicio} - {estudio.anioFin || 'Presente'}
                        </p>
                      </div>
                    ))}
                  </div>
                )}
              </div>

              {/* Direcciones */}
              <div className="bg-white rounded-lg shadow-md p-6">
                <h3 className="text-xl font-bold mb-4">Direcciones</h3>
                {direcciones.length === 0 ? (
                  <p className="text-gray-500">No tiene direcciones registradas</p>
                ) : (
                  <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                    {direcciones.map((direccion) => (
                      <div key={direccion.id} className="border border-gray-200 rounded-lg p-4">
                        <h4 className="font-bold">{direccion.ciudad}</h4>
                        <p className="text-gray-600">{direccion.calle}</p>
                        <p className="text-gray-600">
                          {direccion.codigoPostal}, {direccion.pais}
                        </p>
                      </div>
                    ))}
                  </div>
                )}
              </div>
            </div>
          ) : (
            <div className="bg-white rounded-lg shadow-md p-6 text-center text-gray-500">
              Selecciona un usuario para ver sus detalles
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

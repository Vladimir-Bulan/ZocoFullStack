import { Link } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext';

export const Navbar = () => {
  const { user, logout, isAdmin } = useAuth();

  if (!user) return null;

  return (
    <nav className="bg-blue-600 text-white shadow-lg">
      <div className="container mx-auto px-4">
        <div className="flex items-center justify-between h-16">
          <div className="flex items-center space-x-8">
            <Link to="/dashboard" className="text-xl font-bold">
              Zoco
            </Link>
            <div className="hidden md:flex space-x-4">
              <Link
                to="/dashboard"
                className="hover:bg-blue-700 px-3 py-2 rounded transition"
              >
                Dashboard
              </Link>
              {isAdmin() && (
                <Link
                  to="/usuarios"
                  className="hover:bg-blue-700 px-3 py-2 rounded transition"
                >
                  Usuarios
                </Link>
              )}
            </div>
          </div>

          <div className="flex items-center space-x-4">
            <span className="hidden md:block">
              {user.nombre} ({user.rol})
            </span>
            <button
              onClick={logout}
              className="bg-red-500 hover:bg-red-600 px-4 py-2 rounded transition"
            >
              Salir
            </button>
          </div>
        </div>
      </div>
    </nav>
  );
};

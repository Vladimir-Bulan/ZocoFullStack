# Zoco Frontend - React + Vite + Tailwind CSS

Aplicación web desarrollada con React, Vite y Tailwind CSS para la gestión de usuarios, estudios y direcciones.

## 🚀 Tecnologías Utilizadas

- React 18
- Vite
- React Router DOM v6
- Axios
- Tailwind CSS
- Context API para gestión de estado

## 📋 Requisitos Previos

- Node.js 16+ y npm
- Backend corriendo en http://localhost:5000

## 🔧 Instalación y Ejecución

### 1. Instalar dependencias
```bash
npm install
```

### 2. Iniciar en modo desarrollo
```bash
npm run dev
```

La aplicación estará disponible en: `http://localhost:3000`

### 3. Build para producción
```bash
npm run build
```

## 👤 Usuarios de Prueba

**Admin:**
- Email: `admin@zoco.com`
- Password: `admin123`

**Usuario Normal:**
- Email: `user@zoco.com`
- Password: `user123`

## 🎯 Funcionalidades

### Para Usuarios Normales:
- Login/Logout con JWT
- Ver y editar perfil personal
- CRUD de estudios propios
- CRUD de direcciones propias

### Para Administradores:
- Todas las funciones de usuario normal
- Ver listado completo de usuarios
- Ver detalles, estudios y direcciones de cualquier usuario
- Gestionar datos de todos los usuarios

## 📁 Estructura del Proyecto

```
Frontend/
├── public/
├── src/
│   ├── components/       # Componentes reutilizables
│   │   ├── Navbar.jsx
│   │   ├── PrivateRoute.jsx
│   │   ├── EstudioForm.jsx
│   │   └── DireccionForm.jsx
│   ├── contexts/         # Context API
│   │   └── AuthContext.jsx
│   ├── pages/            # Páginas principales
│   │   ├── LoginPage.jsx
│   │   ├── DashboardPage.jsx
│   │   └── UsuariosPage.jsx
│   ├── services/         # Servicios de API
│   │   ├── api.js
│   │   ├── authService.js
│   │   ├── userService.js
│   │   ├── estudioService.js
│   │   └── direccionService.js
│   ├── App.jsx           # Componente principal
│   ├── main.jsx          # Punto de entrada
│   └── index.css         # Estilos globales
├── index.html
├── package.json
├── vite.config.js
└── tailwind.config.js
```

## 🔐 Autenticación

La aplicación usa JWT almacenado en `sessionStorage`:
- Se obtiene al hacer login
- Se envía automáticamente en cada request al backend
- Se elimina al hacer logout o si el token expira

## 🎨 Estilos

- Tailwind CSS para estilos utility-first
- Diseño responsivo mobile-first
- Paleta de colores personalizada

## 🔄 Integración con Backend

El frontend se comunica con el backend mediante Axios:
- Base URL: `http://localhost:5000/api`
- Headers automáticos con JWT
- Interceptors para manejo de errores 401

## 📱 Responsive Design

La aplicación es completamente responsiva:
- Mobile: Diseño vertical optimizado
- Tablet: Grid de 2 columnas
- Desktop: Grid de 3 columnas y navegación completa

## 🧪 Testing Local

1. Asegúrate que el backend esté corriendo
2. Inicia el frontend con `npm run dev`
3. Abre http://localhost:3000
4. Prueba con los usuarios de prueba

## ⚙️ Variables de Entorno

Para producción, crea un archivo `.env`:
```
VITE_API_URL=https://tu-backend-url.com/api
```

Y actualiza `src/services/api.js`:
```javascript
const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5000/api';
```

## 🚀 Deploy

### Vercel (Recomendado)
1. Instalar Vercel CLI: `npm i -g vercel`
2. Ejecutar: `vercel`
3. Seguir las instrucciones
4. Configurar variable de entorno `VITE_API_URL`

### Netlify
1. `npm run build`
2. Subir carpeta `dist/` a Netlify
3. Configurar variable de entorno `VITE_API_URL`

## 🐛 Troubleshooting

### Error de CORS
→ Verificar que el backend tenga CORS habilitado para tu dominio

### 401 Unauthorized
→ Token expirado, hacer logout y login nuevamente

### Backend no responde
→ Verificar que el backend esté corriendo en el puerto 5000

## 📄 Licencia

Este proyecto es parte de una prueba técnica para Zoco.

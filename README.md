# 🚀 Zoco FullStack - Sistema de Gestión de Usuarios

Aplicación Full Stack desarrollada con **.NET 8** en el backend y **React + Vite + Tailwind CSS** en el frontend. Incluye autenticación JWT, control de sesiones, gestión de roles (Admin/Usuario) y CRUD completo de usuarios, estudios y direcciones.

---

## 📋 Prueba Técnica - Zoco

**Desarrollador:** Tu Nombre  
**Fecha:** Enero 2026  
**Stack:** .NET 8 + React + SQLite + JWT

---

## ✨ Características Principales

### Backend (.NET 8)
- ✅ API REST con arquitectura en capas
- ✅ Autenticación JWT
- ✅ Roles: Admin y Usuario
- ✅ Entity Framework Core con SQLite
- ✅ Swagger UI integrado
- ✅ Control de sesiones (SessionLogs)
- ✅ Validaciones de autorización
- ✅ BCrypt para hash de contraseñas

### Frontend (React)
- ✅ React 18 con Hooks
- ✅ React Router DOM v6
- ✅ Context API para autenticación
- ✅ Axios para peticiones HTTP
- ✅ Tailwind CSS para estilos
- ✅ Diseño 100% responsivo
- ✅ Protección de rutas por rol
- ✅ sessionStorage para persistencia

---

## 🛠️ Tecnologías Utilizadas

### Backend
- .NET 8.0 SDK
- Entity Framework Core 8.0
- SQLite
- JWT Bearer Authentication
- BCrypt.Net
- Swagger/OpenAPI

### Frontend
- React 18
- Vite
- React Router DOM v6
- Axios
- Tailwind CSS
- Context API

---

## 📁 Estructura del Proyecto

```
ZocoFullStack/
├── Backend/                    # API .NET
│   ├── Controllers/           # Endpoints REST
│   ├── Services/              # Lógica de negocio
│   ├── Repositories/          # Acceso a datos
│   ├── Models/                # Entidades
│   ├── DTOs/                  # Data Transfer Objects
│   ├── Data/                  # DbContext y configuración
│   ├── Properties/            # Launch settings
│   ├── appsettings.json       # Configuración
│   ├── Program.cs             # Startup
│   └── ZocoAPI.csproj         # Proyecto .NET
│
├── Frontend/                   # Aplicación React
│   ├── src/
│   │   ├── components/        # Componentes reutilizables
│   │   ├── contexts/          # Context API (Auth)
│   │   ├── pages/             # Páginas/Vistas
│   │   ├── services/          # Servicios de API
│   │   ├── App.jsx            # App principal
│   │   └── main.jsx           # Entry point
│   ├── public/
│   ├── index.html
│   ├── package.json
│   ├── vite.config.js
│   └── tailwind.config.js
│
├── COMO_INICIAR_BACKEND.md    # Guía paso a paso Backend
├── COMO_INICIAR_FRONTEND.md   # Guía paso a paso Frontend
└── README.md                   # Este archivo
```

---

## 🚀 Inicio Rápido

### Requisitos Previos
- ✅ .NET SDK 8.0 o superior
- ✅ Node.js 16+ y npm
- ✅ Git

### 1. Clonar el Repositorio
```bash
git clone <tu-repositorio>
cd ZocoFullStack
```

### 2. Iniciar Backend
```bash
cd Backend
dotnet restore
dotnet run
```
Backend disponible en: `http://localhost:5000`  
Swagger: `http://localhost:5000/swagger`

### 3. Iniciar Frontend (en NUEVA terminal)
```bash
cd Frontend
npm install
npm run dev
```
Frontend disponible en: `http://localhost:3000`

### 4. Login
Abre `http://localhost:3000` y usa:
- **Admin:** `admin@zoco.com` / `admin123`
- **Usuario:** `user@zoco.com` / `user123`

---

## 👤 Usuarios de Prueba

La base de datos se inicializa automáticamente con estos usuarios:

| Rol | Email | Password | Permisos |
|-----|-------|----------|----------|
| **Admin** | admin@zoco.com | admin123 | Ver y gestionar todos los usuarios y sus datos |
| **Usuario** | user@zoco.com | user123 | Solo ver y editar su propio perfil y datos |

---

## 📚 Endpoints de la API

### Autenticación
- `POST /api/auth/login` - Iniciar sesión
- `POST /api/auth/logout` - Cerrar sesión
- `POST /api/auth/register` - Registrar usuario (solo Admin)

### Usuarios
- `GET /api/usuarios` - Listar todos (solo Admin)
- `GET /api/usuarios/{id}` - Obtener por ID

### Estudios
- `GET /api/estudios` - Listar todos (solo Admin)
- `GET /api/estudios/usuario/{usuarioId}` - Por usuario
- `POST /api/estudios` - Crear
- `PUT /api/estudios/{id}` - Actualizar
- `DELETE /api/estudios/{id}` - Eliminar

### Direcciones
- `GET /api/direcciones` - Listar todas (solo Admin)
- `GET /api/direcciones/usuario/{usuarioId}` - Por usuario
- `POST /api/direcciones` - Crear
- `PUT /api/direcciones/{id}` - Actualizar
- `DELETE /api/direcciones/{id}` - Eliminar

---

## 🔐 Seguridad Implementada

1. **JWT Authentication**
   - Token en header Authorization: `Bearer {token}`
   - Expiración: 60 minutos
   - Claims: UserId, Email, Name, Role

2. **Autorización por Roles**
   - Admin: Acceso completo
   - Usuario: Solo sus propios datos

3. **Validaciones**
   - Verificación de propiedad de recursos
   - Middleware de autorización
   - Hash BCrypt para contraseñas

4. **Control de Sesiones**
   - Tabla SessionLogs con FechaInicio y FechaFin
   - Cierre automático al logout

---

## 📱 Funcionalidades Frontend

### Autenticación
- Login con validación
- Logout global
- Protección de rutas
- Redirección automática

### Dashboard (Usuario)
- Ver perfil personal
- CRUD de estudios propios
- CRUD de direcciones propias
- Interfaz responsiva

### Gestión de Usuarios (Admin)
- Listado de todos los usuarios
- Ver detalles completos de cualquier usuario
- Ver estudios y direcciones de cualquier usuario
- Interfaz de 3 columnas responsiva

---

## 🎨 Diseño Responsivo

El diseño se adapta a todos los tamaños de pantalla:

- **Mobile (< 768px):** Diseño vertical en una columna
- **Tablet (768px - 1024px):** Grid de 2 columnas
- **Desktop (> 1024px):** Grid de 3 columnas con navegación completa

---

## 🧪 Testing

### Probar Backend con Swagger
1. Ir a `http://localhost:5000/swagger`
2. Expandir `/api/auth/login`
3. Hacer login con `admin@zoco.com`
4. Copiar el token
5. Click en "Authorize" y pegar: `Bearer {token}`
6. Probar todos los endpoints

### Probar Frontend
1. Login con usuario de prueba
2. Verificar dashboard se carga correctamente
3. Crear un estudio
4. Crear una dirección
5. Editar datos
6. Eliminar datos
7. Logout
8. Login como Admin
9. Verificar vista de Usuarios

---

## 🚀 Deploy

### Backend - Opción 1: Azure
1. Crear App Service en Azure
2. Configurar cadena de conexión en Azure
3. Deploy desde Visual Studio o CLI

### Backend - Opción 2: Railway
1. Crear cuenta en railway.app
2. Conectar repositorio
3. Configurar variables de entorno
4. Deploy automático

### Frontend - Vercel (Recomendado)
1. Instalar Vercel CLI: `npm i -g vercel`
2. En carpeta Frontend: `vercel`
3. Configurar `VITE_API_URL` con URL del backend

### Frontend - Netlify
1. `npm run build`
2. Subir carpeta `dist/` a Netlify
3. Configurar variable de entorno

---

## 📝 Guías Detalladas

Para instrucciones paso a paso, ver:
- **Backend:** [COMO_INICIAR_BACKEND.md](./COMO_INICIAR_BACKEND.md)
- **Frontend:** [COMO_INICIAR_FRONTEND.md](./COMO_INICIAR_FRONTEND.md)

---

## 🐛 Troubleshooting

### Backend no inicia
- Verificar que .NET 8 esté instalado: `dotnet --version`
- Ejecutar `dotnet restore`
- Revisar puerto 5000 no esté en uso

### Frontend no inicia
- Verificar Node.js instalado: `node --version`
- Eliminar `node_modules` y ejecutar `npm install`
- Verificar backend esté corriendo primero

### Error 401 en Frontend
- Token expirado, hacer logout y login nuevamente
- Verificar que el backend esté corriendo
- Revisar CORS en el backend

---

## ✅ Checklist de Cumplimiento

### Backend
- [x] .NET Core 6+ (usando .NET 8)
- [x] Entity Framework Core
- [x] SQL Server / SQLite ✓
- [x] Autenticación JWT
- [x] Swagger habilitado
- [x] Inyección de dependencias
- [x] Login y logout con JWT
- [x] CRUD de Usuarios, Estudios, Direcciones
- [x] Validación por rol (Admin/Usuario)
- [x] Tabla SessionLogs
- [x] Middleware de autorización
- [x] Código por capas (Controllers/Services/Repositories)
- [x] Uso de appsettings.json
- [x] Uso de [Authorize]

### Frontend
- [x] React con Hooks
- [x] React Router DOM
- [x] Context API para autenticación
- [x] Axios/Fetch
- [x] Tailwind CSS
- [x] sessionStorage
- [x] Login funcional
- [x] Dashboard con rutas protegidas
- [x] Diferentes vistas según rol
- [x] CRUD de Estudios y Direcciones
- [x] Validación según rol
- [x] Logout global
- [x] Diseño responsivo

---

## 👨‍💻 Autor

**Tu Nombre**  
Desarrollado como prueba técnica para Zoco  
Enero 2026

---

## 📄 Licencia

Este proyecto es parte de una prueba técnica.

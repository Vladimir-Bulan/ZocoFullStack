# 🚀 Zoco - Sistema de Gestión de Usuarios

Sistema Full Stack de gestión de usuarios con autenticación JWT, control de acceso por roles y gestión de estudios y direcciones.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-18-61DAFB?logo=react)](https://reactjs.org/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2025-CC2927?logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

---

## 📋 Tabla de Contenidos

- [Descripción](#-descripción)
- [Stack Tecnológico](#-stack-tecnológico)
- [Características](#-características)
- [Arquitectura](#-arquitectura)
- [Requisitos Previos](#-requisitos-previos)
- [Instalación](#-instalación)
- [Uso](#-uso)
- [API Endpoints](#-api-endpoints)
- [Usuarios de Prueba](#-usuarios-de-prueba)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Screenshots](#-screenshots)


---

## 🎯 Descripción

**Zoco** es un sistema completo de gestión de usuarios que permite:

- ✅ Autenticación segura con JWT
- ✅ Control de acceso basado en roles (Admin/Usuario)
- ✅ CRUD completo de estudios académicos
- ✅ CRUD completo de direcciones
- ✅ Gestión de usuarios (solo Admin)
- ✅ Registro de sesiones
- ✅ Interfaz responsive y moderna
- ✅ API RESTful documentada con Swagger

---

## 🛠️ Stack Tecnológico

### Backend
- **.NET 8.0** - Framework principal
- **Entity Framework Core 8.0** - ORM
- **SQL Server 2025** - Base de datos
- **JWT Bearer** - Autenticación
- **BCrypt.Net** - Hash de contraseñas
- **Swagger/OpenAPI** - Documentación de API

### Frontend
- **React 18** - Biblioteca UI
- **Vite 5** - Build tool
- **React Router v6** - Enrutamiento
- **Axios** - Cliente HTTP
- **Tailwind CSS 3** - Estilos
- **Context API** - Estado global

---

## ✨ Características

### Autenticación y Seguridad
- 🔐 Login con email y contraseña
- 🔑 Tokens JWT con expiración de 60 minutos
- 🔒 Hash de contraseñas con BCrypt
- 🛡️ Validación de roles en cada endpoint
- 📝 Registro de sesiones (login/logout)

### Gestión de Usuarios (Solo Admin)
- 👥 Listado de todos los usuarios
- 👤 Ver detalles de cualquier usuario
- ➕ Registro de nuevos usuarios

### Gestión de Estudios
- 📚 Ver mis estudios (Usuario)
- 📚 Ver todos los estudios (Admin)
- ➕ Agregar nuevo estudio
- ✏️ Editar estudio existente
- 🗑️ Eliminar estudio

### Gestión de Direcciones
- 🏠 Ver mis direcciones (Usuario)
- 🏠 Ver todas las direcciones (Admin)
- ➕ Agregar nueva dirección
- ✏️ Editar dirección existente
- 🗑️ Eliminar dirección

### Interfaz de Usuario
- 📱 Diseño responsive (móvil, tablet, desktop)
- 🎨 Interfaz moderna con Tailwind CSS
- 🔄 Actualización en tiempo real
- 🚪 Logout con limpieza de sesión
- 🎭 Vistas diferenciadas por rol

---

## 🏗️ Arquitectura

### Backend - Arquitectura en Capas

```
┌─────────────────────────────────┐
│       Controllers               │  ← Endpoints REST
├─────────────────────────────────┤
│        Services                 │  ← Lógica de negocio
├─────────────────────────────────┤
│      Repositories               │  ← Acceso a datos
├─────────────────────────────────┤
│   Entity Framework Core         │  ← ORM
├─────────────────────────────────┤
│       SQL Server                │  ← Base de datos
└─────────────────────────────────┘
```

**Ventajas:**
- ✅ Separación de responsabilidades
- ✅ Código testeable
- ✅ Fácil mantenimiento
- ✅ Escalable

### Frontend - Arquitectura React

```
┌─────────────────────────────────┐
│         App.jsx                 │  ← Router principal
├─────────────────────────────────┤
│       AuthContext               │  ← Estado global
├─────────────────────────────────┤
│         Pages                   │  ← Vistas principales
├─────────────────────────────────┤
│       Components                │  ← Componentes reusables
├─────────────────────────────────┤
│        Services                 │  ← Axios API calls
└─────────────────────────────────┘
```

---

## 📦 Requisitos Previos

### Software Necesario

- **Node.js 18+** - [Descargar](https://nodejs.org/)
- **.NET 8 SDK** - [Descargar](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server 2019+** - [Descargar](https://www.microsoft.com/sql-server/sql-server-downloads)
- **Git** - [Descargar](https://git-scm.com/)

### Opcional
- **Visual Studio Code** - [Descargar](https://code.visualstudio.com/)
- **SQL Server Management Studio (SSMS)** - [Descargar](https://learn.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms)

---

## 🚀 Instalación

### 1. Clonar el Repositorio

```bash
git clone https://github.com/tu-usuario/zoco-fullstack.git
cd zoco-fullstack
```

### 2. Configurar la Base de Datos

**Opción A: SQL Server Management Studio**
1. Abrir SSMS
2. Conectarse a tu instancia de SQL Server
3. Crear nueva base de datos: `ZocoDB`

**Opción B: Comando SQL**
```sql
CREATE DATABASE ZocoDB;
```

### 3. Configurar Backend

```bash
cd Backend

# Editar cadena de conexión (si es necesario)
# Archivo: appsettings.json
# "DefaultConnection": "Data Source=.;Initial Catalog=ZocoDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;"

# Restaurar paquetes
dotnet restore

# Ejecutar
dotnet run
```

El backend iniciará en: **http://localhost:5000**

Swagger disponible en: **http://localhost:5000/swagger**

### 4. Configurar Frontend

Abre una **NUEVA terminal** (sin cerrar el backend):

```bash
cd Frontend

# Instalar dependencias
npm install

# Ejecutar en desarrollo
npm run dev
```

El frontend iniciará en: **http://localhost:3000**

---

## 💻 Uso

### Acceso Inicial

1. **Abrir navegador:** http://localhost:3000
2. **Login con credenciales de prueba:**

**Administrador:**
```
Email: admin@zoco.com
Password: admin123
```

**Usuario Normal:**
```
Email: user@zoco.com
Password: user123
```

### Flujo de Uso

#### Como Administrador:
1. Login → Dashboard
2. Ver "Usuarios" en el navbar
3. Gestionar estudios y direcciones de cualquier usuario
4. Registrar nuevos usuarios

#### Como Usuario Normal:
1. Login → Dashboard
2. Ver solo mis datos
3. Gestionar mis propios estudios y direcciones
4. No puedo ver otros usuarios

---

## 🔌 API Endpoints

### Autenticación

| Método | Endpoint | Descripción | Auth |
|--------|----------|-------------|------|
| POST | `/api/Auth/login` | Iniciar sesión | No |
| POST | `/api/Auth/register` | Registrar usuario | Admin |
| POST | `/api/Auth/logout` | Cerrar sesión | Sí |

### Usuarios

| Método | Endpoint | Descripción | Auth |
|--------|----------|-------------|------|
| GET | `/api/Usuarios` | Listar todos los usuarios | Admin |
| GET | `/api/Usuarios/{id}` | Ver usuario por ID | Sí |

### Estudios

| Método | Endpoint | Descripción | Auth |
|--------|----------|-------------|------|
| GET | `/api/Estudios` | Listar todos (Admin) | Admin |
| GET | `/api/Estudios/usuario/{id}` | Estudios de un usuario | Sí |
| POST | `/api/Estudios` | Crear estudio | Sí |
| PUT | `/api/Estudios/{id}` | Actualizar estudio | Sí |
| DELETE | `/api/Estudios/{id}` | Eliminar estudio | Sí |

### Direcciones

| Método | Endpoint | Descripción | Auth |
|--------|----------|-------------|------|
| GET | `/api/Direcciones` | Listar todas (Admin) | Admin |
| GET | `/api/Direcciones/usuario/{id}` | Direcciones de un usuario | Sí |
| POST | `/api/Direcciones` | Crear dirección | Sí |
| PUT | `/api/Direcciones/{id}` | Actualizar dirección | Sí |
| DELETE | `/api/Direcciones/{id}` | Eliminar dirección | Sí |

**Documentación completa:** http://localhost:5000/swagger

---

## 👥 Usuarios de Prueba

La base de datos incluye 2 usuarios pre-configurados:

### Admin
- **Nombre:** Administrador
- **Email:** admin@zoco.com
- **Password:** admin123
- **Rol:** Admin
- **Permisos:** 
  - ✅ Ver todos los usuarios
  - ✅ Registrar nuevos usuarios
  - ✅ Ver todos los estudios y direcciones
  - ✅ Gestionar datos de cualquier usuario

### Usuario Normal
- **Nombre:** Usuario Test
- **Email:** user@zoco.com
- **Password:** user123
- **Rol:** Usuario
- **Permisos:**
  - ✅ Ver solo sus propios datos
  - ✅ Gestionar sus estudios
  - ✅ Gestionar sus direcciones
  - ❌ No puede ver otros usuarios

---

## 📁 Estructura del Proyecto

```
ZocoFullStack/
│
├── Backend/                      # API .NET
│   ├── Controllers/              # Endpoints REST
│   │   ├── AuthController.cs
│   │   ├── UsuariosController.cs
│   │   ├── EstudiosController.cs
│   │   └── DireccionesController.cs
│   │
│   ├── Services/                 # Lógica de negocio
│   │   ├── AuthService.cs
│   │   ├── UserService.cs
│   │   ├── EstudioService.cs
│   │   └── DireccionService.cs
│   │
│   ├── Repositories/             # Acceso a datos
│   │   ├── UserRepository.cs
│   │   ├── EstudioRepository.cs
│   │   ├── DireccionRepository.cs
│   │   └── SessionLogRepository.cs
│   │
│   ├── Models/                   # Entidades
│   │   ├── Usuario.cs
│   │   ├── Estudio.cs
│   │   ├── Direccion.cs
│   │   └── SessionLog.cs
│   │
│   ├── DTOs/                     # Data Transfer Objects
│   ├── Data/                     # DbContext y DbInitializer
│   ├── appsettings.json          # Configuración
│   └── Program.cs                # Punto de entrada
│
├── Frontend/                     # React App
│   ├── src/
│   │   ├── components/           # Componentes reusables
│   │   ├── pages/                # Vistas principales
│   │   │   ├── Login.jsx
│   │   │   ├── Dashboard.jsx
│   │   │   └── Usuarios.jsx
│   │   │
│   │   ├── services/             # API calls
│   │   │   ├── authService.js
│   │   │   ├── userService.js
│   │   │   ├── estudioService.js
│   │   │   └── direccionService.js
│   │   │
│   │   ├── context/              # Estado global
│   │   │   └── AuthContext.jsx
│   │   │
│   │   ├── App.jsx               # Router principal
│   │   └── main.jsx              # Punto de entrada
│   │
│   ├── package.json
│   ├── vite.config.js
│   └── tailwind.config.js
│
├── README.md                     # Este archivo
├── DECISIONES_TECNICAS.md        # Decisiones de diseño
└── .gitignore
```

---

## 📸 Screenshots

### Login
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/05c834f8-cf66-413c-8ec4-054eecf7c990" />


### Dashboard Admin
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/2edb9aae-7505-45df-8649-fd2bc1ad7dd9" />


### Gestión de Usuarios
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/31de4d19-c146-4fe2-a057-3ef086fece58" />


### Swagger API
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/90870653-b544-4dfc-8f24-3fbdf362a26c" />


### SQL Server - Tablas
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/ffe55a50-2c05-49ee-b0e9-cf33e73996db" />


---

## 🧪 Testing

### Backend
```bash
cd Backend
dotnet test
```

### Frontend
```bash
cd Frontend
npm test
```

### API con Thunder Client
Importar colección: `thunder-collection.json`

---

## 🔒 Seguridad

- ✅ Contraseñas hasheadas con BCrypt
- ✅ Tokens JWT con expiración
- ✅ Validación de roles en cada endpoint
- ✅ Validación de propiedad de recursos
- ✅ CORS configurado
- ✅ HTTPS recomendado en producción






</div>

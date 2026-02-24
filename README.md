# 🚀 Zoco - Sistema de Gestión de Usuarios

Sistema Full Stack de gestión de usuarios con autenticación JWT, control de acceso por roles y gestión de estudios y direcciones.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![React](https://img.shields.io/badge/React-18-61DAFB?logo=react)](https://reactjs.org/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2025-CC2927?logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)
[![SOLID](https://img.shields.io/badge/Architecture-SOLID-success)](https://en.wikipedia.org/wiki/SOLID)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

---

## 📋 Tabla de Contenidos

- [Descripción](#-descripción)
- [Stack Tecnológico](#-stack-tecnológico)
- [Características](#-características)
- [Arquitectura](#-arquitectura)
- [Principios SOLID](#-principios-solid)
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
- ✅ **Arquitectura SOLID aplicada**

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
- 🏗️ **Patrón de abstracción para password hashing (SOLID)**

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

## 🎓 Principios SOLID

Este proyecto implementa los **principios SOLID** para garantizar código mantenible, testeable y extensible.

### Dependency Inversion Principle (DIP)

#### 🔐 Password Hashing con Abstracción

**Problema:** AuthService dependía directamente de BCrypt (implementación concreta), violando el principio DIP.

**Solución:** Implementación de la abstracción `IPasswordHasher`.

#### Estructura:

```
Services/
├── IPasswordHasher.cs              # Interfaz (abstracción)
└── BcryptPasswordHasher.cs         # Implementación concreta
```

#### Código:

**Interfaz:**
```csharp
public interface IPasswordHasher
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}
```

**Implementación:**
```csharp
public class BcryptPasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
```

**Inyección en AuthService:**
```csharp
public class AuthService : IAuthService
{
    private readonly IPasswordHasher _passwordHasher;
    
    public AuthService(IPasswordHasher passwordHasher, ...)
    {
        _passwordHasher = passwordHasher;
    }
    
    public async Task<UsuarioDto?> RegisterAsync(RegisterDto dto)
    {
        var usuario = new Usuario
        {
            // ✅ Usa abstracción, no implementación concreta
            PasswordHash = _passwordHasher.HashPassword(dto.Password)
        };
        // ...
    }
}
```

**Registro en DI Container:**
```csharp
// Program.cs
builder.Services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
```

#### Beneficios:

✅ **Testeable**
```csharp
// Unit test fácil con mocking
var mockHasher = new Mock<IPasswordHasher>();
mockHasher.Setup(h => h.HashPassword(It.IsAny<string>()))
          .Returns("hashed_password");
          
var service = new AuthService(mockHasher.Object, ...);
// Test sin dependencia de BCrypt real
```

✅ **Extensible**
```csharp
// Cambiar a Argon2 sin modificar AuthService
public class Argon2PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        return Argon2.Hash(password);
    }
    
    public bool VerifyPassword(string password, string hashedPassword)
    {
        return Argon2.Verify(hashedPassword, password);
    }
}

// En Program.cs, cambiar UNA línea:
builder.Services.AddScoped<IPasswordHasher, Argon2PasswordHasher>();
```

✅ **Mantenible**
- AuthService no conoce detalles de implementación
- Código desacoplado y limpio
- Fácil de entender y modificar

✅ **Cumple SOLID**
- **S**ingle Responsibility: BcryptPasswordHasher solo hashea passwords
- **O**pen/Closed: Abierto a extensión, cerrado a modificación
- **D**ependency Inversion: Depende de abstracción, no de concreción

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
│   │   ├── IPasswordHasher.cs            # ✨ SOLID - Abstracción
│   │   ├── BcryptPasswordHasher.cs       # ✨ SOLID - Implementación
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
│   └── Program.cs                # Punto de entrada + DI
│
├── Frontend/                     # React App
│   ├── src/
│   │   ├── components/           # Componentes reusables
│   │   ├── pages/                # Vistas principales
│   │   │   ├── LoginPage.jsx
│   │   │   ├── DashboardPage.jsx
│   │   │   └── UsuariosPage.jsx
│   │   │
│   │   ├── services/             # API calls
│   │   │   ├── api.js
│   │   │   ├── authService.js
│   │   │   ├── userService.js
│   │   │   ├── estudioService.js
│   │   │   └── direccionService.js
│   │   │
│   │   ├── contexts/             # Estado global
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

### API con Swagger
1. Abrir http://localhost:5000/swagger
2. Hacer login para obtener token
3. Click en "Authorize" y pegar: `Bearer {token}`
4. Probar todos los endpoints

---

## 🔒 Seguridad

### Implementado
- ✅ **Contraseñas hasheadas** con BCrypt (salt automático)
- ✅ **Tokens JWT** con expiración de 60 minutos
- ✅ **Validación de roles** en cada endpoint (`[Authorize(Roles = "Admin")]`)
- ✅ **Validación de propiedad** de recursos (usuarios solo acceden a sus datos)
- ✅ **CORS** configurado apropiadamente
- ✅ **Inyección de dependencias** para password hashing (SOLID)
- ✅ **Claims JWT** completos (UserId, Email, Rol, Nombre)

### Recomendaciones para Producción
- 🔐 Usar **HTTPS** obligatoriamente
- 🔑 Mover secretos a **Azure Key Vault** o variables de entorno
- 📊 Implementar **logging** con Serilog o Application Insights
- 🛡️ Agregar **rate limiting** en endpoints críticos
- 🔍 Implementar **auditoría** de acciones sensibles
- 🚨 Configurar **alertas** de seguridad

---

## 🚀 Deploy

### Backend (Azure App Service)
```bash
# Publicar
dotnet publish -c Release

# Configurar connection string en Azure Portal
# Configurar JWT settings en Application Settings
```

### Frontend (Vercel/Netlify)
```bash
# Build
npm run build

# Deploy con Vercel
vercel --prod

# Configurar variable de entorno:
# VITE_API_URL=https://tu-api.azurewebsites.net/api
```

---

## 📝 Licencia

Este proyecto está bajo la Licencia MIT.

---

## 👨‍💻 Autor

**Tu Nombre**
- GitHub: [@Vladimir-Bulan](https://github.com/Vladimir-Bulan)
- LinkedIn: [@VladimirBulan](https://www.linkedin.com/in/vladimir-bulan-60083b21b)

---

## 🙏 Agradecimientos

- Arquitectura basada en principios **SOLID**
- Inspirado en mejores prácticas de **Clean Architecture**

---

**⭐ Si te gustó este proyecto, dale una estrella en GitHub!**





</div>

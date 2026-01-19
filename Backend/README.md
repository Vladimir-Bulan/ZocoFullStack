# Zoco API - Backend .NET Core

API REST desarrollada con .NET 8, Entity Framework Core, SQLite y JWT para la gestión de usuarios, estudios y direcciones.

## 🚀 Tecnologías Utilizadas

- .NET 8.0
- Entity Framework Core
- SQLite (base de datos)
- JWT Authentication
- BCrypt (hash de contraseñas)
- Swagger/OpenAPI

## 📋 Requisitos Previos

- .NET SDK 8.0 o superior
- Editor de código (Visual Studio Code recomendado)

## 🔧 Instalación y Ejecución

### 1. Clonar el repositorio
```bash
git clone <tu-repositorio>
cd Backend
```

### 2. Restaurar dependencias
```bash
dotnet restore
```

### 3. Ejecutar la aplicación
```bash
dotnet run
```

La API estará disponible en: `http://localhost:5000`
Swagger UI estará en: `http://localhost:5000/swagger`

## 👤 Usuarios de Prueba

La base de datos se inicializa automáticamente con estos usuarios:

**Admin:**
- Email: `admin@zoco.com`
- Password: `admin123`
- Rol: Admin

**Usuario Normal:**
- Email: `user@zoco.com`
- Password: `user123`
- Rol: Usuario

## 📚 Endpoints Principales

### Autenticación
- `POST /api/auth/login` - Iniciar sesión
- `POST /api/auth/register` - Registrar usuario (solo Admin)
- `POST /api/auth/logout` - Cerrar sesión

### Usuarios
- `GET /api/usuarios` - Listar todos (solo Admin)
- `GET /api/usuarios/{id}` - Obtener usuario por ID

### Estudios
- `GET /api/estudios` - Listar todos (solo Admin)
- `GET /api/estudios/usuario/{usuarioId}` - Estudios de un usuario
- `POST /api/estudios` - Crear estudio
- `PUT /api/estudios/{id}` - Actualizar estudio
- `DELETE /api/estudios/{id}` - Eliminar estudio

### Direcciones
- `GET /api/direcciones` - Listar todas (solo Admin)
- `GET /api/direcciones/usuario/{usuarioId}` - Direcciones de un usuario
- `POST /api/direcciones` - Crear dirección
- `PUT /api/direcciones/{id}` - Actualizar dirección
- `DELETE /api/direcciones/{id}` - Eliminar dirección

## 🔐 Autenticación JWT

Para usar los endpoints protegidos:

1. Hacer login en `/api/auth/login`
2. Copiar el `token` de la respuesta
3. En Swagger, hacer clic en "Authorize"
4. Escribir: `Bearer {tu-token}`
5. Click en "Authorize"

## 🏗️ Estructura del Proyecto

```
Backend/
├── Controllers/        # Endpoints de la API
├── Services/          # Lógica de negocio
├── Repositories/      # Acceso a datos
├── Models/            # Entidades del dominio
├── DTOs/              # Data Transfer Objects
├── Data/              # DbContext y configuración
├── Properties/        # Configuración de launch
├── appsettings.json   # Configuración de la app
└── Program.cs         # Punto de entrada
```

## 🔒 Reglas de Autorización

- **Admin**: Puede gestionar todos los usuarios y sus datos
- **Usuario**: Solo puede ver y editar sus propios datos

## 📝 Base de Datos

- Se usa SQLite para facilitar el desarrollo
- La base de datos se crea automáticamente al iniciar la app
- Archivo: `zoco.db` en la raíz del proyecto

## 🧪 Probar con Swagger

1. Ir a `http://localhost:5000/swagger`
2. Hacer login con los usuarios de prueba
3. Copiar el token JWT
4. Click en "Authorize" y pegar: `Bearer {token}`
5. Probar los endpoints

## ⚙️ Configuración JWT

La configuración JWT está en `appsettings.json`:
```json
{
  "Jwt": {
    "Key": "clave-secreta-de-al-menos-32-caracteres",
    "Issuer": "ZocoAPI",
    "Audience": "ZocoClient",
    "ExpiryMinutes": 60
  }
}
```

## 📦 Paquetes NuGet Incluidos

- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
- Swashbuckle.AspNetCore
- BCrypt.Net-Next

## 🐛 Troubleshooting

### Error: No se puede crear la base de datos
```bash
dotnet ef database drop --force
dotnet run
```

### Error: Puerto en uso
Cambiar el puerto en `Properties/launchSettings.json`

## 📄 Licencia

Este proyecto es parte de una prueba técnica para Zoco.

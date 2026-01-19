# 🎯 GUÍA COMPLETA - PROYECTO ZOCO FULLSTACK

## 📦 LO QUE TIENES

Este proyecto incluye:
1. ✅ **Backend completo en .NET 8** con JWT, Entity Framework, SQLite
2. ✅ **Frontend completo en React** con Context API, Tailwind CSS
3. ✅ **Todo el código organizado** y listo para ejecutar
4. ✅ **Usuarios de prueba** pre-configurados
5. ✅ **Documentación completa** con Swagger

---

## ⚡ INICIO RÁPIDO (3 PASOS)

### Paso 1: Instalar .NET SDK 8.0
1. Ve a: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
2. Descarga "**.NET SDK x64**" para Windows
3. Ejecuta el instalador
4. **REINICIA PowerShell** después de instalar
5. Verifica: `dotnet --version` (debe mostrar 8.0.xxx)

### Paso 2: Iniciar el Backend
```powershell
# Navega a la carpeta Backend
cd ZocoFullStack\Backend

# Restaurar dependencias
dotnet restore

# Ejecutar
dotnet run
```

**✅ Debe mostrar:** `Now listening on: http://localhost:5000`  
**✅ Abre Swagger:** http://localhost:5000/swagger

**NO CIERRES** esta ventana de PowerShell.

### Paso 3: Iniciar el Frontend (NUEVA terminal)
```powershell
# Abre NUEVA PowerShell
# Navega a la carpeta Frontend
cd ZocoFullStack\Frontend

# Instalar dependencias
npm install

# Ejecutar
npm run dev
```

**✅ Debe mostrar:** `Local: http://localhost:3000/`  
**✅ Abre el navegador:** http://localhost:3000

---

## 🔑 CREDENCIALES DE PRUEBA

### Administrador
- Email: `admin@zoco.com`
- Password: `admin123`
- Puede: Ver y gestionar TODO

### Usuario Normal
- Email: `user@zoco.com`
- Password: `user123`
- Puede: Solo ver y editar SUS datos

---

## 🧪 PRUEBAS RECOMENDADAS

### 1. Como Usuario Normal
1. ✅ Login con user@zoco.com
2. ✅ Ver tu dashboard
3. ✅ Agregar un estudio
4. ✅ Agregar una dirección
5. ✅ Editar el estudio
6. ✅ Eliminar la dirección
7. ✅ Hacer logout

### 2. Como Admin
1. ✅ Login con admin@zoco.com
2. ✅ Ver dashboard
3. ✅ Click en "Usuarios" (navbar)
4. ✅ Ver lista de usuarios
5. ✅ Click en un usuario
6. ✅ Ver sus estudios y direcciones
7. ✅ Hacer logout

### 3. Verificar Seguridad
1. ✅ Intentar acceder a /dashboard sin login
2. ✅ Intentar acceder a /usuarios como usuario normal
3. ✅ Verificar que el token expira después de 1 hora

---

## 📊 ARQUITECTURA DEL PROYECTO

### Backend (.NET 8)
```
Controllers → Services → Repositories → Database
     ↓           ↓            ↓
   DTOs      Lógica      Entity
             Negocio    Framework
```

**Capas:**
- **Controllers:** Reciben peticiones HTTP, validan autorización
- **Services:** Lógica de negocio, transformación de datos
- **Repositories:** Acceso a base de datos
- **Models:** Entidades del dominio
- **DTOs:** Transferencia de datos (sin exponer entidades)

### Frontend (React)
```
App.jsx → Routes → Pages → Components
                              ↓
                          Services
                              ↓
                         Backend API
```

**Estructura:**
- **AuthContext:** Maneja autenticación y usuario actual
- **Services:** Comunicación con API (Axios)
- **PrivateRoute:** Protege rutas según login/rol
- **Pages:** Vistas principales
- **Components:** Elementos reutilizables

---

## 🔐 SEGURIDAD IMPLEMENTADA

### JWT (JSON Web Tokens)
- ✅ Generado al login
- ✅ Almacenado en sessionStorage
- ✅ Enviado en cada request (header Authorization)
- ✅ Validado en backend
- ✅ Expira en 60 minutos

### Roles y Permisos
| Acción | Admin | Usuario |
|--------|-------|---------|
| Ver todos los usuarios | ✅ | ❌ |
| Ver propio perfil | ✅ | ✅ |
| Editar propios datos | ✅ | ✅ |
| Ver datos de otros | ✅ | ❌ |
| Editar datos de otros | ✅ | ❌ |
| Registrar usuarios | ✅ | ❌ |

### Control de Sesiones
- ✅ Se registra FechaInicio al login
- ✅ Se registra FechaFin al logout
- ✅ Tabla SessionLogs en la base de datos

---

## 📱 CARACTERÍSTICAS RESPONSIVE

### Mobile (< 768px)
- Menú hamburguesa
- Cards verticales
- Formularios de ancho completo

### Tablet (768px - 1024px)
- Grid de 2 columnas
- Navegación horizontal
- Sidebar colapsable

### Desktop (> 1024px)
- Grid de 3 columnas
- Navegación completa
- Sidebar fijo

---

## 🚀 DEPLOY A PRODUCCIÓN

### Backend

**Opción 1: Azure App Service**
```bash
# En Visual Studio
1. Click derecho en el proyecto → Publish
2. Seleccionar Azure App Service
3. Crear nuevo o seleccionar existente
4. Deploy
```

**Opción 2: Railway.app (Gratis)**
```bash
1. Crear cuenta en railway.app
2. New Project → Deploy from GitHub
3. Seleccionar repositorio
4. Railway detecta .NET automáticamente
5. Agregar variables de entorno si necesario
```

### Frontend

**Vercel (Recomendado)**
```bash
# Instalar Vercel CLI
npm i -g vercel

# En carpeta Frontend
vercel

# Configurar variable de entorno
VITE_API_URL=https://tu-backend.railway.app/api
```

**Netlify**
```bash
# Build del proyecto
npm run build

# Subir carpeta dist/ a Netlify
# O conectar GitHub para deploy automático
```

---

## 📚 DOCUMENTACIÓN TÉCNICA

### API Documentation (Swagger)
- URL: http://localhost:5000/swagger
- Documentación interactiva de todos los endpoints
- Puedes probar directamente desde el navegador

### Estructura de DTOs

**LoginDto**
```json
{
  "email": "string",
  "password": "string"
}
```

**EstudioDto**
```json
{
  "id": 0,
  "institucion": "string",
  "titulo": "string",
  "anioInicio": 2020,
  "anioFin": 2024,
  "usuarioId": 0
}
```

**DireccionDto**
```json
{
  "id": 0,
  "calle": "string",
  "ciudad": "string",
  "codigoPostal": "string",
  "pais": "string",
  "usuarioId": 0
}
```

---

## 🔧 CONFIGURACIÓN

### Backend: appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=zoco.db"
  },
  "Jwt": {
    "Key": "tu-clave-secreta-minimo-32-caracteres",
    "Issuer": "ZocoAPI",
    "Audience": "ZocoClient",
    "ExpiryMinutes": 60
  }
}
```

### Frontend: vite.config.js
```javascript
export default defineConfig({
  plugins: [react()],
  server: {
    port: 3000,
    proxy: {
      '/api': {
        target: 'http://localhost:5000',
        changeOrigin: true
      }
    }
  }
})
```

---

## ❌ TROUBLESHOOTING

### "dotnet: no se reconoce el comando"
**Solución:**
1. Instalar .NET SDK 8.0
2. Reiniciar PowerShell
3. Si persiste, agregar manualmente a PATH

### "npm: no se reconoce el comando"
**Solución:**
1. Instalar Node.js desde nodejs.org
2. Reiniciar PowerShell

### "Puerto 5000 en uso"
**Solución:**
Cambiar puerto en `Properties/launchSettings.json`:
```json
"applicationUrl": "http://localhost:5001"
```

### "Error 401 Unauthorized"
**Solución:**
1. Hacer logout
2. Hacer login de nuevo
3. Token probablemente expiró

### "CORS Error" en Frontend
**Solución:**
Verificar que el backend tenga configurado CORS:
```csharp
app.UseCors("AllowAll");
```

### Frontend no carga datos
**Solución:**
1. Verificar backend esté corriendo
2. Abrir DevTools → Network
3. Verificar requests a /api

---

## 📋 CHECKLIST FINAL

### Antes de Entregar
- [ ] Backend compila sin errores
- [ ] Frontend compila sin errores
- [ ] Login funciona
- [ ] Dashboard carga correctamente
- [ ] CRUD de estudios funciona
- [ ] CRUD de direcciones funciona
- [ ] Vista de Admin funciona
- [ ] Logout funciona
- [ ] Diseño es responsivo
- [ ] README está completo
- [ ] Código está en GitHub
- [ ] .gitignore excluye archivos innecesarios

### Para GitHub
- [ ] Repositorio es público
- [ ] README principal está bien
- [ ] Includes README de Backend
- [ ] Includes README de Frontend
- [ ] .gitignore configurado
- [ ] No hay contraseñas en el código
- [ ] No hay archivos .db en el repo

---

## 🎓 CONCEPTOS APRENDIDOS

1. **Backend .NET:**
   - Arquitectura en capas
   - Entity Framework Core
   - JWT Authentication
   - Inyección de dependencias
   - Middleware
   - DTOs y AutoMapper pattern

2. **Frontend React:**
   - Hooks (useState, useEffect, useContext)
   - Context API
   - React Router v6
   - Axios interceptors
   - Tailwind CSS
   - Responsive design

3. **Full Stack:**
   - Comunicación REST API
   - Manejo de autenticación
   - Control de acceso por roles
   - Sesiones y tokens
   - CORS
   - Deploy

---

## 📞 SOPORTE

Si tienes problemas:
1. Revisa esta guía completa
2. Revisa COMO_INICIAR_BACKEND.md
3. Revisa COMO_INICIAR_FRONTEND.md
4. Consulta los README individuales
5. Revisa la documentación de Swagger

---

## ✨ PRÓXIMOS PASOS

1. Ejecutar el proyecto localmente
2. Probar todas las funcionalidades
3. Subir a GitHub
4. Deploy a producción (opcional)
5. Documentar tu experiencia

---

## 🎯 CONTACTO

**Desarrollador:** [Tu Nombre]  
**Email:** [tu-email@ejemplo.com]  
**GitHub:** [tu-usuario]  
**LinkedIn:** [tu-perfil]

**Proyecto desarrollado para:** Zoco  
**Fecha:** Enero 2026

---

¡Éxito con la prueba técnica! 🚀

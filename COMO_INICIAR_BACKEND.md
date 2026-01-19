# 🚀 GUÍA DE INICIO RÁPIDO - BACKEND

## Paso 1: Verificar que .NET esté instalado

Abre PowerShell y ejecuta:
```powershell
dotnet --version
```

Deberías ver algo como: `8.0.xxx`

Si no sale nada, instala .NET 8.0 SDK desde:
https://dotnet.microsoft.com/en-us/download/dotnet/8.0

**IMPORTANTE:** Después de instalar, cierra y abre PowerShell de nuevo.

---

## Paso 2: Navegar a la carpeta del proyecto

```powershell
cd ruta\donde\guardaste\ZocoFullStack\Backend
```

---

## Paso 3: Restaurar paquetes NuGet

```powershell
dotnet restore
```

Esto descargará todas las dependencias necesarias (Entity Framework, JWT, BCrypt, etc.)

---

## Paso 4: Compilar el proyecto

```powershell
dotnet build
```

Si todo está bien, verás: `Build succeeded.`

---

## Paso 5: Ejecutar la API

```powershell
dotnet run
```

Verás algo como:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started.
```

---

## Paso 6: Probar que funciona

### Opción A: Abrir Swagger (Recomendado)

1. Abre tu navegador
2. Ve a: `http://localhost:5000/swagger`
3. Verás la documentación interactiva de la API

### Opción B: Probar el login con PowerShell/CMD

Abre OTRA ventana de PowerShell y ejecuta:

```powershell
curl -X POST http://localhost:5000/api/auth/login `
  -H "Content-Type: application/json" `
  -d '{\"email\":\"admin@zoco.com\",\"password\":\"admin123\"}'
```

Deberías recibir un JSON con el token JWT.

---

## 🎯 Usuarios para Probar

**Administrador:**
- Email: `admin@zoco.com`
- Password: `admin123`

**Usuario Normal:**
- Email: `user@zoco.com`
- Password: `user123`

---

## 📝 Cómo usar Swagger

1. Ve a `http://localhost:5000/swagger`
2. Expande el endpoint `/api/auth/login`
3. Click en "Try it out"
4. Pega este JSON:
```json
{
  "email": "admin@zoco.com",
  "password": "admin123"
}
```
5. Click en "Execute"
6. Copia el `token` de la respuesta
7. Arriba, click en el botón "Authorize" 🔒
8. Escribe: `Bearer {el-token-que-copiaste}`
9. Click en "Authorize"
10. ¡Ahora puedes probar todos los endpoints protegidos!

---

## ❌ Problemas Comunes

### "dotnet: El término 'dotnet' no se reconoce"
→ .NET no está instalado o no reiniciaste PowerShell después de instalar

### Puerto 5000 en uso
→ Cambia el puerto en `Properties/launchSettings.json`, línea 8:
```json
"applicationUrl": "http://localhost:5001",
```

### Error al compilar
→ Ejecuta `dotnet restore` primero
→ Verifica que todos los archivos .cs estén en sus carpetas correctas

---

## ✅ Siguiente Paso

Una vez que el backend esté corriendo correctamente (verás Swagger funcionando), 
¡podemos pasar al Frontend en React! 🎨

**NO CIERRES** la ventana de PowerShell donde está corriendo el backend.
Déjala abierta mientras desarrollamos el frontend.

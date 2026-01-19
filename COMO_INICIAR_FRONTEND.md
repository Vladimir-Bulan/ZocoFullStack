# 🎨 GUÍA DE INICIO RÁPIDO - FRONTEND

## ⚠️ IMPORTANTE: El backend debe estar corriendo primero!

Antes de iniciar el frontend, asegúrate que el backend esté corriendo en http://localhost:5000

---

## Paso 1: Abrir NUEVA ventana de terminal

NO cierres la ventana donde está corriendo el backend. Abre una NUEVA ventana de PowerShell.

---

## Paso 2: Navegar a la carpeta del frontend

```powershell
cd ruta\donde\guardaste\ZocoFullStack\Frontend
```

---

## Paso 3: Instalar dependencias de Node

```powershell
npm install
```

Esto puede tardar 1-2 minutos. Descargará React, Vite, Tailwind CSS, Axios, etc.

---

## Paso 4: Iniciar el servidor de desarrollo

```powershell
npm run dev
```

Verás algo como:
```
  VITE v5.0.8  ready in 500 ms

  ➜  Local:   http://localhost:3000/
  ➜  Network: use --host to expose
  ➜  press h + enter to show help
```

---

## Paso 5: Abrir en el navegador

1. Abre tu navegador (Chrome, Firefox, Edge)
2. Ve a: `http://localhost:3000`
3. Deberías ver la pantalla de login

---

## Paso 6: Probar el login

Usa alguno de estos usuarios:

**Administrador:**
- Email: `admin@zoco.com`
- Password: `admin123`

**Usuario Normal:**
- Email: `user@zoco.com`
- Password: `user123`

---

## 🎯 Funcionalidades a Probar

### Como Usuario Normal:
1. Login
2. Ver tu perfil en el Dashboard
3. Agregar/Editar/Eliminar estudios
4. Agregar/Editar/Eliminar direcciones
5. Logout

### Como Admin:
1. Todo lo anterior +
2. Click en "Usuarios" en el navbar
3. Ver listado de todos los usuarios
4. Click en un usuario para ver sus detalles
5. Ver estudios y direcciones de cualquier usuario

---

## ❌ Problemas Comunes

### "npm: El término 'npm' no se reconoce"
→ Node.js no está instalado. Instalar desde https://nodejs.org

### Puerto 3000 en uso
→ Cambiar puerto en `vite.config.js`:
```javascript
server: {
  port: 3001,  // cambiar a 3001 u otro puerto
  // ...
}
```

### Error 401 o "Network Error"
→ El backend no está corriendo. Iniciar el backend primero.

### Error al instalar dependencias
→ Eliminar `node_modules` y `package-lock.json`, luego `npm install` de nuevo

---

## ✅ Checklist Final

- [ ] Backend corriendo en http://localhost:5000
- [ ] Frontend corriendo en http://localhost:3000
- [ ] Puedes hacer login
- [ ] Puedes ver el dashboard
- [ ] Puedes agregar/editar/eliminar datos
- [ ] El diseño se ve bien (responsivo)

---

## 🚀 Siguiente Paso: Deploy

Una vez que todo funcione localmente, puedes deployar en Vercel:

1. Crear cuenta en https://vercel.com (gratis)
2. Instalar Vercel CLI: `npm i -g vercel`
3. En la carpeta Frontend: `vercel`
4. Seguir las instrucciones

**IMPORTANTE para deploy:**
- Actualizar `VITE_API_URL` en Vercel con la URL de tu backend deployado
- O deployar el backend primero y luego el frontend

---

## 📝 Notas

- El frontend se recarga automáticamente cuando editas archivos
- Los cambios se ven instantáneamente (Hot Module Replacement)
- NUNCA subas tokens o credenciales al repositorio

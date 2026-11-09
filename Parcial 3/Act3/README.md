# 🔎 Actividad: Login con BCrypt
 
**🗓️ Fecha:** 09/11/2026
 
## 📖 Contenido del repositorio
 
Programa en C# con inicio de sesión y registro de usuarios cuya contraseña se guarda hasheada con el algoritmo **BCrypt** (biblioteca `BCrypt.Net-Next`).
 
- **LoginBCrypt:** Proyecto Windows Forms (.NET Framework) con un único formulario (`Form1`) que permite registrar usuarios e iniciar sesión.
- **BaseDeDatos:** Script `logindb.sql` que crea la base de datos con sus tablas, y el backup `backup_logindb.sql` con los datos de prueba.
Tablas de la base de datos `logindb`:
 
| Tabla | Columnas | Uso |
| --- | --- | --- |
| **usuarios** | `id`, `nombre`, `usuario`, `password_hash` | Guarda el usuario y el hash BCrypt de su contraseña. |
| **intentos** | `id`, `usuario`, `exitoso`, `fecha` | Registra cada intento de acceso (exitoso o fallido) con su fecha, para un análisis posterior. |
 
## 💻 Tecnologías
 
C#, Windows Forms (.NET Framework 4.7.2), MySQL 8, BCrypt.Net-Next
 
**Autor:** Rómel Tadeo Rodríguez González
 
## 🧩 Dependencias
 
| Proyecto | Paquete NuGet | Versión |
| --- | --- | --- |
| **LoginBCrypt** | `BCrypt.Net-Next` | 4.0.3 |
| **LoginBCrypt** | `MySql.Data` | 8.0.33 |
 
## 🛠️ Instalación de las tecnologías
 
### Requisitos previos
 
- Sistema operativo **Windows 10 u 11** (Windows Forms con .NET Framework solo se ejecuta en Windows).
- [Git](https://git-scm.com/downloads) para clonar el repositorio (opcional si descargas el ZIP).
- Conexión a internet la primera vez (Visual Studio descarga los paquetes NuGet).
### 1. Instalar Visual Studio
 
1. Descarga **Visual Studio Community** (gratuito) desde <https://visualstudio.microsoft.com/es/downloads/>.
2. En el **Visual Studio Installer**, marca la carga de trabajo **"Desarrollo de escritorio con .NET"**.
3. Haz clic en **Instalar** y reinicia el equipo si el instalador lo solicita.
### 2. Instalar MySQL e importar la base de datos
 
1. Descarga e instala **MySQL Community Server 8.x** desde <https://dev.mysql.com/downloads/mysql/>.
2. Crea la base de datos y las tablas con el script:
```bash
   mysql -u root -p < BaseDeDatos/logindb.sql
```
 
3. Para restaurar el backup con los datos de prueba:
```bash
   mysql -u root -p logindb < BaseDeDatos/backup_logindb.sql
```
 
4. Abre `LoginBCrypt/Form1.cs` y ajusta la contraseña de tu servidor en la cadena de conexión:
```csharp
   const string Cn = "Server=localhost;Database=logindb;Uid=root;Pwd=TU_CLAVE;";
```
 
### 3. Clonar el repositorio
 
```bash
git clone <URL-DEL-REPOSITORIO>
cd <NOMBRE-DEL-REPOSITORIO>
```
 
O bien descarga el repositorio como ZIP desde GitHub (**Code → Download ZIP**) y extráelo.
 
### 4. Abrir y ejecutar el proyecto
 
1. Abre Visual Studio y selecciona **Abrir un proyecto o una solución**.
2. Abre el archivo `LoginBCrypt.sln` de la carpeta raíz.
3. Acepta la restauración de paquetes NuGet (descarga `BCrypt.Net-Next` y `MySql.Data`).
4. Compila con **Ctrl + Shift + B** y ejecuta con **F5**.
### Solución de problemas comunes
 
| Problema | Solución |
| --- | --- |
| No aparece la plantilla de Windows Forms | Instala la carga de trabajo "Desarrollo de escritorio con .NET" desde Visual Studio Installer. |
| Error "targeting pack for .NET Framework not found" | Instala el .NET Framework 4.7.2 (o 4.8) Developer Pack. |
| Error "The type or namespace 'MySql' could not be found" | Clic derecho en la solución → **Restaurar paquetes NuGet** y vuelve a compilar. |
| Aparece "Error: ..." en el formulario al registrar o iniciar sesión | Verifica que MySQL esté en ejecución, que `logindb` exista y que el `Pwd` de `Form1.cs` sea correcto. |
| Error de usuario duplicado al registrar | La columna `usuario` es única; usa otro nombre de usuario. |
 
## 🔐 Información importante
 
- **Registro:** el botón *Registrar* genera el hash con `BCrypt.Net.BCrypt.HashPassword(clave)` y lo guarda en `usuarios.password_hash`. La contraseña original nunca se almacena.
- **Inicio de sesión:** el botón *Iniciar sesión* consulta el hash del usuario y lo compara con `BCrypt.Net.BCrypt.Verify(clave, hash)`.
- **Acceso exitoso:** se muestra el mensaje `Bienvenido, <nombre>` con el nombre del usuario.
- **Intentos:** cada inicio de sesión, exitoso (`exitoso = 1`) o fallido (`exitoso = 0`), se guarda en la tabla `intentos` con el usuario y la fecha automática.
- **Hash:** BCrypt genera un salt aleatorio en cada hash, por lo que dos contraseñas iguales producen hashes distintos. El hash tiene 60 caracteres y empieza con `$2a$` o `$2b$`.
- **Consulta de análisis:**
```sql
  SELECT usuario, exitoso, COUNT(*) AS total FROM intentos GROUP BY usuario, exitoso;
```
 
## 📸 Capturas de resultados
 
### Registro de usuario: Se ingresan nombre, usuario y contraseña; la contraseña se hashea con BCrypt y el hash se guarda en la tabla `usuarios`.
 
<img width="422" height="402" alt="image" src="https://github.com/user-attachments/assets/702224e1-9bdb-4518-9497-f59485294e69" />

### Inicio de sesión: La contraseña ingresada se verifica con `BCrypt.Verify()`, se muestra el nombre del usuario y el intento queda guardado en la tabla `intentos`.
 
<img width="433" height="421" alt="image" src="https://github.com/user-attachments/assets/b5b1c05b-9ae1-4a9b-a2b6-11e4dfb7140f" />


<img width="396" height="331" alt="image" src="https://github.com/user-attachments/assets/4c8f9923-0501-4f13-90f6-617d2f8ae9bb" />


 

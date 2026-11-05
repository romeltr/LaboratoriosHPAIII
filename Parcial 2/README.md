# 🔎 Parcial #2

**🗓️ Fecha:** 05/11/2026

## 📖 Contenido del repositorio

Programación en capas con registro e inicio de sesión de usuarios con contraseña hasheada.

- **Entidades:** Define la entidad final con los datos del usuario (`E_Usuario`).
- **Datos:** Maneja el acceso a MySQL mediante procedimientos almacenados. Encapsula el registro y la consulta de usuarios; no hashea ni valida contraseñas.
- **Negocios:** Conserva las reglas del negocio: política de contraseña segura y la interfaz `IHashService` con dos contratos, uno para hashear al registrar y otro para verificar al iniciar sesión.
- **Forms:** Presentación e interfaz interactiva. Son 3 formularios: inicio de sesión, registro de usuario y formulario principal.
- **BaseDeDatos:** Dump completo de `productosdb` y script de migración para una base ya existente.

## 💻 Tecnologías

C#, Windows Forms (.NET Framework), MySQL 8

**Autor:** Rómel Tadeo Rodríguez González

## 🧩 Dependencias entre capas

| Capa | Referencia a | Paquete NuGet |
| --- | --- | --- |
| **Entidades** | — | — |
| **Datos** | Entidades | `MySql.Data` 8.0.33 |
| **Negocios** | Datos, Entidades | — |
| **Forms** | Negocios, Entidades | — |

Flujo: `Forms → Negocios → Datos → Entidades`. Los formularios no conocen Datos ni MySQL; solo llaman a `N_Usuario`.

## 🛠️ Instalación de las tecnologías

### Requisitos previos

- Sistema operativo **Windows 10 u 11** (Windows Forms con .NET Framework solo se ejecuta en Windows).
- Mínimo 8 GB de RAM y alrededor de 10 GB de espacio libre en disco.
- [Git](https://git-scm.com/downloads) para clonar el repositorio (opcional si descargas el ZIP).
- Conexión a internet la primera vez (Visual Studio descarga el paquete `MySql.Data`).

### 1. Instalar Visual Studio

1. Descarga **Visual Studio Community** (gratuito) desde <https://visualstudio.microsoft.com/es/downloads/>.
2. Ejecuta el instalador (`VisualStudioSetup.exe`) y espera a que cargue el **Visual Studio Installer**.
3. En la pestaña **Cargas de trabajo**, marca **"Desarrollo de escritorio con .NET"**. Esta carga incluye:
   - El compilador y las herramientas de **C#**.
   - El diseñador y las plantillas de **Windows Forms**.
4. En la pestaña **Componentes individuales**, verifica que estén marcados:
   - **.NET Framework 4.8 SDK**
   - **Herramientas de destino de .NET Framework 4.8** (*.NET Framework 4.8 targeting pack*)
5. Haz clic en **Instalar** y espera a que termine (puede tardar varios minutos según tu conexión).
6. Reinicia el equipo si el instalador lo solicita.

> Si ya tienes Visual Studio instalado: abre **Visual Studio Installer → Modificar** y agrega la carga de trabajo "Desarrollo de escritorio con .NET".

### 2. Verificar la instalación de .NET Framework

1. Abre **PowerShell** y ejecuta:

   ```powershell
   Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" | Select-Object Release, Version
   ```

2. Un valor de `Release` igual o mayor a **528040** indica que tienes .NET Framework 4.8 o superior.
3. Si no está instalado, descarga el **.NET Framework 4.8 Developer Pack** desde <https://dotnet.microsoft.com/es-es/download/dotnet-framework/net48>.

### 3. Instalar MySQL e importar la base de datos

1. Descarga e instala **MySQL Community Server 8.x** desde <https://dev.mysql.com/downloads/mysql/> (opcionalmente MySQL Workbench).
2. Abre una terminal y importa el dump completo (crea `productosdb` con sus tablas, datos y procedimientos almacenados):

   ```bash
   mysql -u root -p < BaseDeDatos/productosdb_dump.sql
   ```

   También puedes abrir `productosdb_dump.sql` en MySQL Workbench y ejecutarlo.
3. Si ya tienes `productosdb` y no quieres reimportarla, ejecuta solo `BaseDeDatos/migracion_usuarios.sql`.
4. Abre `Datos/D_Conexion.cs` y ajusta `Uid` y `Pwd` a tu servidor (por defecto `root` / `psswd`):

   ```csharp
   public static string cadenaConexion = "Server=localhost;Database=productosdb;Uid=root;Pwd=psswd";
   ```

### 4. Clonar el repositorio

```bash
git clone <URL-DEL-REPOSITORIO>
cd <NOMBRE-DEL-REPOSITORIO>
```

O bien descarga el repositorio como ZIP desde GitHub (**Code → Download ZIP**) y extráelo.

### 5. Abrir y ejecutar el proyecto

1. Abre Visual Studio y selecciona **Abrir un proyecto o una solución**.
2. Abre el archivo `ProyectoLoginCapas.sln` de la carpeta raíz.
3. Espera a que Visual Studio cargue la solución. Acepta la restauración de paquetes NuGet (descarga `MySql.Data`).
4. Verifica que el destino sea **.NET Framework 4.7.2 o superior** (clic derecho en el proyecto → **Propiedades → Aplicación → Plataforma de destino**).
5. Verifica que el proyecto de inicio sea **Forms** (clic derecho en `Forms` → **Establecer como proyecto de inicio**).
6. Compila con **Ctrl + Shift + B** y ejecuta con **F5** (o el botón ▶ **Iniciar**).

### Solución de problemas comunes

| Problema | Solución |
| --- | --- |
| No aparece la plantilla de Windows Forms | Instala la carga de trabajo "Desarrollo de escritorio con .NET" desde Visual Studio Installer. |
| Error "targeting pack for .NET Framework not found" | Instala el .NET Framework 4.8 Developer Pack o el componente individual en Visual Studio Installer. |
| El diseñador del formulario no abre | Compila la solución primero (**Ctrl + Shift + B**) y reabre el formulario. |
| Error "The type or namespace 'MySql' could not be found" | Clic derecho en la solución → **Restaurar paquetes NuGet** y vuelve a compilar. |
| "Error de conexión o base de datos" al iniciar sesión | Verifica que MySQL esté en ejecución, que `productosdb` esté importada y que `Uid` y `Pwd` de `D_Conexion.cs` sean correctos. |
| El proyecto no abre en Mac o Linux | Windows Forms con .NET Framework requiere Windows; usa una máquina virtual con Windows. |

## 🔐 Información importante

- **Registro:** `FrmRegistro` → `N_Usuario.Registrar` valida la contraseña (mínimo 8 caracteres, sin espacios, con mayúscula, minúscula y número) → `IHashService.HashPassword` → `D_Usuario.Registrar` → `sp_RegistrarUsuario`.
- **Inicio de sesión:** `Form1` → `N_Usuario.Login` → `D_Usuario.ObtenerParaLogin` (trae el hash) → `IHashService.VerifyPassword` compara el texto plano con el hash guardado. Si no coincide, no se abre el formulario principal.
- **Hash:** PBKDF2-HMAC-SHA256 con salt aleatorio. Se guarda en `usuarios.dsPassword` con el formato `PBKDF2-SHA256$iteraciones$salt$hash`.
- **Formulario principal:** barra lateral con botón de tres rayitas (☰), botones sobre un DataGridView de usuarios (listar, buscar, activar, desactivar, limpiar), reloj con fecha y hora, y usuario/cuenta logueada.
- **Cuentas de prueba:** `fulano@gmail.com` y `fulan` tienen la contraseña temporal **`Temporal123`**. Las cuentas `fulano`, `romel`, `romeltr` y `CHEESEr` conservan su contraseña anterior, ahora hasheada.

## 📸 Capturas de resultados

### Form1 (Inicio de sesión): Solicita usuario y contraseña; la contraseña ingresada se hashea y se compara con la almacenada en la base de datos.

<img width="443" height="468" alt="image" src="https://github.com/user-attachments/assets/379cca22-fc3c-46ad-85b4-39c40c588c1b" />

### FrmRegistro (Registro de usuario): Valida la política de contraseña, la hashea desde la capa de negocio y la guarda mediante la capa de datos.

<img width="471" height="606" alt="image" src="https://github.com/user-attachments/assets/5bcaf1ff-c4dc-41f3-9a15-2f9b85b60489" />

### frmPrincipal (Formulario principal): Barra lateral, botones con DataGridView, reloj y datos de la cuenta logueada.

<img width="1372" height="840" alt="image" src="https://github.com/user-attachments/assets/f14b1ca3-063d-4fb9-a0fc-e03473246af6" />

### Base de datos (tabla usuarios): La columna dsPassword almacena el hash, nunca la contraseña en texto plano.

<img width="1091" height="202" alt="image" src="https://github.com/user-attachments/assets/b89436fa-7049-4e7b-b0ee-b4a1e9606c3e" />


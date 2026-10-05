# 🔎 Laboratorio #4

**🗓️ Fecha:** 24/09/2026

## 📖 Contenido del repositorio

Programación por consulta de base de datos (MySQL) desde un formulario de Windows Forms.

- **Lab4Actividad1:** Formulario para registrar productos (nombre, precio, cantidad e imagen) en una base de datos MySQL y visualizarlos en un `DataGridView`.
  - **Registrar:** inserta el producto en la tabla `productos` mediante consultas parametrizadas (`InsertSeguro`).
  - **Búsqueda:** filtra el listado en tiempo real por id, nombre, precio o cantidad.
  - **Selección de fila:** al hacer clic en una fila se cargan sus datos y su imagen en el formulario para editarlos.
  - **Imagen:** se selecciona con un `OpenFileDialog` (jpg, jpeg, png, bmp) y se guarda como `byte[]` en la base de datos.
  - **Limpiar:** reinicia los campos del formulario.
  - **Validaciones:** las clases `ValidatorTexto`, `ValidadorEntero` y `ValidadorDecimal` implementan la interfaz `IValidatorCampo`.
  - **Acceso a datos:** la clase `Conexion` centraliza la conexión (`ObtenerConexion`), la lectura (`GetProductos`) y la escritura (`InsertSeguro`, `UpdateSeguro`).

## 💻 Tecnologías

C#, Windows Forms (.NET Framework 4.7.2), MySQL, MySQL Workbench, paquete NuGet `MySql.Data` 26.7.0

**Autor:** Rómel Tadeo Rodríguez González

## 🛠️ Instalación de las tecnologías

### Requisitos previos

- Sistema operativo **Windows 10 u 11** (Windows Forms con .NET Framework solo se ejecuta en Windows).
- Mínimo 8 GB de RAM y alrededor de 12 GB de espacio libre en disco.
- [Git](https://git-scm.com/downloads) para clonar el repositorio (opcional si descargas el ZIP).

### 1. Instalar Visual Studio

1. Descarga **Visual Studio Community** (gratuito) desde <https://visualstudio.microsoft.com/es/downloads/>.
2. Ejecuta el instalador y, en la pestaña **Cargas de trabajo**, marca **"Desarrollo de escritorio con .NET"**.
3. En la pestaña **Componentes individuales**, verifica que estén marcados:
   - **.NET Framework 4.7.2 SDK**
   - **Herramientas de destino de .NET Framework 4.7.2** (*.NET Framework 4.7.2 targeting pack*)
4. Haz clic en **Instalar** y reinicia el equipo si el instalador lo solicita.

> Este proyecto está configurado para **.NET Framework 4.7.2**. Si tienes instalado solo el 4.8, Visual Studio te pedirá reorientar el proyecto; es preferible instalar el paquete de destino 4.7.2.

### 2. Instalar MySQL Server y MySQL Workbench

1. Descarga **MySQL Installer for Windows** desde <https://dev.mysql.com/downloads/installer/>.
2. Ejecuta el instalador y elige el tipo de instalación **Custom**.
3. Selecciona e instala los productos:
   - **MySQL Server** (versión 8.x o superior)
   - **MySQL Workbench**
4. En la configuración del servidor:
   - Tipo de configuración: **Development Computer**
   - Puerto: **3306** (por defecto)
   - Método de autenticación: **Use Strong Password Encryption**
   - Define una **contraseña para el usuario `root`** y guárdala; la necesitarás para la cadena de conexión.
   - Configura MySQL como **servicio de Windows** con inicio automático.
5. Finaliza la instalación y verifica que el servicio **MySQL80** esté en ejecución (`services.msc`).

### 3. Crear la base de datos

1. Abre **MySQL Workbench** y conéctate a `localhost` con el usuario `root`.
2. Ejecuta el siguiente script. Su estructura se deduce de las consultas del proyecto (`id`, `nombre`, `precio`, `cantidad`, `imagen`); ajústalo si tu tabla original difiere:

   ```sql
   CREATE DATABASE IF NOT EXISTS productosdb;
   USE productosdb;

   CREATE TABLE IF NOT EXISTS productos (
       id       INT AUTO_INCREMENT PRIMARY KEY,
       nombre   VARCHAR(100)  NOT NULL,
       precio   DECIMAL(10,2) NOT NULL,
       cantidad INT           NOT NULL,
       imagen   LONGBLOB      NULL
   );
   ```

### 4. Clonar el repositorio

```bash
git clone https://github.com/romeltr/LaboratoriosHPAIII.git
cd LaboratoriosHPAIII
```

O bien descarga el repositorio como ZIP desde GitHub (**Code → Download ZIP**) y extráelo.

### 5. Configurar la cadena de conexión

1. Abre el archivo `Laboratorio4 (Base de Datos)/Lab4Actividad1/Lab4Actividad1/Conexion.cs`.
2. Localiza la variable `cadenaConexion` y reemplaza los valores por los de tu equipo:

   ```csharp
   private static string cadenaConexion =
       "Server=localhost;Database=productosdb;Uid=root;Pwd=TU_CONTRASEÑA;";
   ```

3. No subas tu contraseña real al repositorio.

### 6. Restaurar paquetes NuGet

El proyecto depende de `MySql.Data` 26.7.0 y de sus paquetes auxiliares (`Google.Protobuf`, `BouncyCastle.Cryptography`, `K4os.Compression.LZ4`, `ZstdSharp.Port`, entre otros), listados en `packages.config`.

1. Abre la solución en Visual Studio.
2. Haz clic derecho sobre la solución → **Restaurar paquetes NuGet**.
3. Si no se restauran, abre **Herramientas → Administrador de paquetes NuGet → Consola** y ejecuta:

   ```powershell
   Update-Package -reinstall
   ```

### 7. Abrir y ejecutar el proyecto

1. Abre Visual Studio y selecciona **Abrir un proyecto o una solución**.
2. Entra a `Laboratorio4 (Base de Datos)/Lab4Actividad1/` y abre `Lab4Actividad1.slnx`.
3. Verifica que el destino sea **.NET Framework 4.7.2** (clic derecho en el proyecto → **Propiedades → Aplicación → Plataforma de destino**).
4. Compila con **Ctrl + Shift + B** y ejecuta con **F5** (o el botón ▶ **Iniciar**).

> El archivo `.slnx` es el nuevo formato de solución de Visual Studio. Si tu versión no lo reconoce, abre directamente `Lab4Actividad1/Lab4Actividad1.csproj`.

### Solución de problemas comunes

| Problema | Solución |
| --- | --- |
| `Unable to connect to any of the specified MySQL hosts` | Verifica que el servicio **MySQL80** esté iniciado y que el puerto 3306 esté libre. |
| `Access denied for user 'root'` | La contraseña de `Conexion.cs` no coincide con la de tu servidor MySQL. |
| `Unknown database 'productosdb'` | Ejecuta el script del paso 3 en MySQL Workbench. |
| `Table 'productosdb.productos' doesn't exist` | Crea la tabla `productos` con el script del paso 3. |
| No se encuentra `MySql.Data` | Restaura los paquetes NuGet (paso 6). |
| Error "targeting pack for .NET Framework 4.7.2 not found" | Instala el componente individual en Visual Studio Installer. |
| `Authentication method 'caching_sha2_password' is not supported` | Actualiza `MySql.Data` o crea el usuario con `mysql_native_password`. |
| El proyecto no abre en Mac o Linux | Windows Forms con .NET Framework requiere Windows; usa una máquina virtual con Windows. |

## 📸 Capturas de resultados

**Lab4Actividad1 (Registro de productos):** Formulario con `DataGridView` que muestra los productos almacenados en MySQL, con sus imágenes, y campos para registrar nuevos productos validados.

<img width="997" height="787" alt="image" src="https://github.com/user-attachments/assets/b372157c-a2de-43da-a0f2-c83fb3e68ec5" />


**Búsqueda y filtrado:** El cuadro de búsqueda filtra el listado mientras el usuario escribe.

<img width="882" height="305" alt="image" src="https://github.com/user-attachments/assets/a61eceb7-380e-45f9-a7a5-dadb67074104" />


**Base de datos en MySQL Workbench:** Tabla `productos` con los registros guardados.

<img width="510" height="606" alt="image" src="https://github.com/user-attachments/assets/c8ed87d5-be83-4734-9ff5-fa70f699fb02" />

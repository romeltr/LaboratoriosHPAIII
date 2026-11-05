# Proyecto Login en Capas (C# WinForms · .NET Framework · MySQL)

Aplicación de escritorio en 4 capas con **registro de usuarios**, **inicio de sesión con contraseña hasheada** y un **formulario principal** (barra lateral, DataGridView, reloj y datos de la cuenta). Todo gira en torno a la entidad **usuario**; productos y departamentos no se tocaron (el departamento solo se lee para el combo del registro y para mostrarlo en pantalla).

---

## 1. Qué se hizo

### Base de datos (`productosdb`, MySQL 8.0)
| Cambio | Detalle |
|---|---|
| `usuarios.dsPassword` | De `VARBINARY(64)` a `VARCHAR(255)`: guarda el hash completo generado en C#. |
| `usuarios.dsSalt` | **Eliminada.** El salt viaja dentro del hash (`PBKDF2-SHA256$iteraciones$salt$hash`). |
| `sp_RegistrarUsuario` | **Reescrito.** Recibe el hash ya calculado (`_dsPasswordHash`) y lo guarda. Antes guardaba la contraseña tal cual llegaba. Códigos de salida: `0` ok · `1` usuario/cuenta repetido · `3` departamento inexistente · `4` datos vacíos · `99` error. |
| `sp_ObtenerUsuarioLogin` | **Nuevo.** Devuelve el usuario *activo* con su hash. MySQL ya no compara contraseñas. |
| `sp_ListarUsuarios` | **Nuevo.** Datos del DataGridView (nunca incluye el hash). Admite filtro por usuario/cuenta. |
| `sp_CambiarEstadoUsuario` | **Nuevo.** Activa/desactiva un usuario. |
| `sp_ValidarLoginHash`, `insert_user` | **Eliminados.** Hasheaban con `SHA2` dentro de MySQL y dependían de `dsSalt`. |

### C# – flujo pedido
* **Registro:** `FrmRegistro` → `N_Usuario.Registrar` valida la política de contraseña → `IHashService.HashPassword` (contrato 1) → `D_Usuario.Registrar` → `sp_RegistrarUsuario`. La contraseña **nunca** llega a la capa de datos en texto plano.
* **Login:** `Form1` → `N_Usuario.Login` → `D_Usuario.ObtenerParaLogin` (trae el hash por usuario) → `IHashService.VerifyPassword` (contrato 2) compara el texto plano ingresado con el hash guardado. Si coincide entra a `frmPrincipal`; si no, mensaje de error y no se abre nada.
* **Interfaz independiente:** `Negocios/IHashService.cs` (dos contratos: `HashPassword` y `VerifyPassword`), implementada por `Negocios/HashService.cs` (PBKDF2-HMAC-SHA256, salt aleatorio de 16 bytes, 100 000 iteraciones, comparación en tiempo constante). Se puede cambiar el algoritmo sin tocar forms ni datos: `new N_Usuario(otraImplementacion)`.
* **Política de contraseña (regla de negocio):** mínimo 8 caracteres, sin espacios, al menos una mayúscula, una minúscula y un número, distinta del nombre de usuario, más campo de confirmación. Se aplica al registrar (el login no la exige, para no bloquear cuentas antiguas).

### Formulario principal (`frmPrincipal`)
* **Barra lateral** con botón de tres rayitas (☰) que la muestra/oculta. Opciones: *Usuarios*, *Mi cuenta*, *Cerrar sesión* (vuelve al login) y *Salir*.
* **Botones + DataGridView** (parte inferior): *Listar usuarios*, *Buscar* (también con Enter), *Activar*, *Desactivar* (sobre la fila seleccionada; no puedes desactivar tu propia cuenta) y *Limpiar*. Los usuarios inactivos se ven en gris.
* **Reloj** con fecha y hora actual (se actualiza cada segundo, barra superior derecha).
* **Usuario y cuenta logueada:** saludo con el usuario y línea con *Usuario · Cuenta (ID) · Departamento*.

### Correcciones al código recibido (necesarias para que compilara/funcionara)
* `FrmRegistro` usaba `SqlParameter` (SQL Server) con `MySqlCommand` y nombres de parámetros que no existían en el procedimiento; además hablaba directo con MySQL desde el form. Ahora solo llama a `N_Usuario`.
* `Form1` y `FrmRegistro` creaban un `Form1` nuevo en cada navegación (el original quedaba oculto y la app no terminaba al cerrar). Ahora el login se oculta/muestra y cerrar la ventana principal termina la aplicación.
* `E_Usuario.cs` no tenía `using System;` (usaba `DateTime`); `IHashService` salió de Entidades hacia Negocios; el `Main` salió de `frmPrincipal` a `Program.cs`; se quitó el `using Org.BouncyCastle...` sin uso; `idUsuarioModificacion` → `dsUsuarioModificacion` (nombre real de la columna).

---

## 2. Estructura y dependencias entre capas

```
ProyectoLoginCapas/
├─ ProyectoLoginCapas.sln
├─ Entidades/   E_Usuario.cs
├─ Datos/       D_Conexion.cs, D_Usuario.cs
├─ Negocios/    IHashService.cs, HashService.cs, N_Usuario.cs
├─ Forms/       Program.cs, Form1 (login), FrmRegistro, frmPrincipal
└─ BaseDeDatos/ productosdb_dump.sql, migracion_usuarios.sql
```

```
Forms ──► Negocios ──► Datos ──► Entidades
  │          │                      ▲
  │          └──────────────────────┤
  └─────────────────────────────────┘
```

| Capa | Referencias de proyecto | Paquete NuGet | Responsabilidad |
|---|---|---|---|
| **Entidades** | — | — | Clase `E_Usuario` (solo datos). |
| **Datos** | Entidades | `MySql.Data` 8.0.33 | Procedimientos almacenados y conexión. No hashea ni valida. |
| **Negocios** | Datos, Entidades | — | Reglas: política de contraseña, hash y verificación (`IHashService`). |
| **Forms** | Negocios, Entidades | — | Vistas: capturan datos, muestran mensajes. **No conoce Datos ni MySQL** (llegan de forma transitiva por Negocios). |

Sobre MVP: las vistas (forms) quedaron sin lógica ni SQL y toda la coordinación vive en `N_Usuario`, que cumple el papel de presentador/modelo. No se añadieron clases Presenter separadas para mantener el cambio simple.

---

## 3. Cómo abrirlo y ejecutarlo

**Requisitos:** Visual Studio 2019 o 2022 (carga de trabajo *Desarrollo de escritorio con .NET*), .NET Framework 4.7.2 o superior y MySQL 8.x.

1. **Base de datos:** importa `BaseDeDatos/productosdb_dump.sql` (crea `productosdb` con tablas, datos y procedimientos). Ejemplo: `mysql -u root -p < BaseDeDatos/productosdb_dump.sql`.
   *Si ya tienes `productosdb` y prefieres no reimportar*, ejecuta solo `BaseDeDatos/migracion_usuarios.sql` (aplica los mismos cambios sobre tu base actual).
2. **Conexión:** edita `Datos/D_Conexion.cs` (`Uid` y `Pwd`; viene con `root` / `psswd`).
3. Abre `ProyectoLoginCapas.sln`. Al compilar, Visual Studio restaura `MySql.Data` solo (requiere internet la primera vez). Proyecto de inicio: **Forms**.
4. Ejecuta (F5).

Los proyectos son estilo SDK (`.csproj` cortos). Para cambiar la versión de .NET Framework edita `TargetFramework` (`net472`, `net48`…) en los cuatro `.csproj`; el hash usa `Rfc2898DeriveBytes` con SHA-256, que requiere 4.7.2+.

---

## 4. Cuentas existentes tras la migración

El dump original guardaba contraseñas de dos formas, ninguna compatible con el nuevo esquema:

* **Texto plano** (usuarios `fulano`, `romel`, `romeltr`, `CHEESEr`): se convirtieron a hash conservando su misma contraseña. Esto corrige un fallo del procedimiento de registro anterior, que guardaba la contraseña sin hashear.
* **SHA-512 sin salt** (usuarios `fulano@gmail.com` y `fulan`): no son recuperables, así que quedaron con la contraseña temporal **`Temporal123`**. Cámbiala o registra usuarios nuevos.

Para probar rápido: inicia sesión con `fulano@gmail.com` / `Temporal123`, o regístrate desde el botón *Registrarse* (la clave debe cumplir la política).

---

## 5. Qué se verificó

* Base de datos probada en **MySQL 8.0**: migración sobre el dump original, importación limpia del dump final y los 4 procedimientos (registro ok, usuario repetido sin distinguir mayúsculas, cuenta repetida, departamento inexistente, datos vacíos, login solo de usuarios activos, activar/desactivar, listado con filtro).
* `HashService`: salt distinto por hash, verificación correcta/incorrecta, formatos inválidos rechazados, y compatibilidad cruzada (un hash generado en C# se verifica en Python y viceversa).
* Las cuatro capas **compilan con Mono** y los tres formularios se renderizaron para revisar el diseño. Esa compilación usó un reemplazo mínimo de `MySql.Data` (el paquete real no se puede descargar en el entorno de pruebas), por lo que **la conexión real C# ↔ MySQL no se ejecutó**: la primera vez abre la solución en Visual Studio, restaura NuGet y prueba login/registro contra tu servidor.

## 6. Notas

* La cadena de conexión sigue en texto plano en `D_Conexion.cs`, como en el proyecto original.
* La búsqueda del grid usa `LIKE`; los caracteres `%` y `_` escritos en el cuadro de búsqueda actúan como comodines.
* El nombre de usuario es único sin distinguir mayúsculas/minúsculas ni acentos (colación `utf8mb4_unicode_ci` de la tabla).

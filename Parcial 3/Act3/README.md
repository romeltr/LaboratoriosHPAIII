# Login con BCrypt (C# WinForms, .NET Framework 4.7.2)

## Requisitos
- Visual Studio 2019/2022 (carga de trabajo "Desarrollo de escritorio con .NET")
- MySQL Server

## Pasos
1. Ejecutar `BaseDeDatos/logindb.sql` en MySQL.
2. Abrir `LoginBCrypt.sln` (los paquetes NuGet BCrypt.Net-Next y MySql.Data se restauran solos).
3. En `LoginBCrypt/Form1.cs` cambiar `TU_CLAVE` por la contraseña de MySQL.
4. Presionar F5.

## Funcionamiento
- Registrar: genera el hash con `BCrypt.HashPassword` y lo guarda en `usuarios`.
- Iniciar sesión: valida con `BCrypt.Verify`, guarda el intento en `intentos` y muestra el nombre del usuario.

## Backup de la BD
    mysqldump -u root -p logindb > BaseDeDatos/backup_logindb.sql

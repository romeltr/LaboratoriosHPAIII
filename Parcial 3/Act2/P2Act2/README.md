# 🔎 Actividad #2 (Serialización JSON)
 
**🗓️ Fecha:** 09/11/2026
 
## 📖 Contenido del repositorio
 
Salida por consola que convierte un objeto de C# a formato **JSON** usando la biblioteca `Newtonsoft.Json`.
 
- **Act2:** Clase con el método `Main`. Crea un objeto anónimo `persona` con los campos `Nombre`, `Edad` y `Ciudad`, lo serializa con `JsonConvert.SerializeObject()` y muestra el texto JSON resultante en la consola.
## 💻 Tecnologías
 
C#, .NET 8 (aplicación de consola), Visual Studio, Newtonsoft.Json.
 
**Autor:** Rómel Tadeo Rodríguez González
 
## 🧩 Dependencias
 
| Proyecto | Paquete NuGet |
| --- | --- |
| **P2Act2** | `Newtonsoft.Json` |
 
## 🛠️ Instalación de las tecnologías
 
### Requisitos previos
 
- Windows, macOS o Linux.
- **.NET 8 SDK** desde <https://dotnet.microsoft.com/es-es/download/dotnet/8.0>.
- Conexión a internet la primera vez (descarga del paquete `Newtonsoft.Json`).
### 1. Instalar la librería
 
Desde la terminal, dentro de la carpeta del proyecto:
 
```bash
dotnet add package Newtonsoft.Json
```
 
O desde Visual Studio: clic derecho en el proyecto → **Administrar paquetes NuGet** → buscar `Newtonsoft.Json` → **Instalar**.
 
### 2. Ejecutar el proyecto
 
```bash
dotnet run
```
 
O desde Visual Studio presiona **F5**.
 
### Solución de problemas comunes
 
| Problema | Solución |
| --- | --- |
| Error "The type or namespace 'Newtonsoft' could not be found" | Instala el paquete `Newtonsoft.Json` y vuelve a compilar. |
| "The name 'Console' does not exist" | Activa `<ImplicitUsings>enable</ImplicitUsings>` en el `.csproj` o agrega `using System;`. |
| Los acentos se ven mal en la consola | Ejecuta la aplicación desde una terminal con codificación UTF-8. |
 
## 🔐 Información importante
 
- `JsonConvert.SerializeObject(persona)` convierte el objeto a una cadena de texto con formato JSON.
- Los nombres de las propiedades del objeto (`Nombre`, `Edad`, `Ciudad`) se convierten en las claves del JSON.
- El programa muestra el JSON en la consola; para guardarlo en un archivo se puede usar `File.WriteAllText("persona.json", json);`.
- Salida esperada:
```json
  {"Nombre":"Rómel","Edad":20,"Ciudad":"Panamá"}
```
 
## 📸 Capturas de resultados
 
### Consola (JSON): Uso de escritura JSON para almacenar datos, utilizando la librería `Newtonsoft.Json`. El objeto `persona` se serializa y se muestra como texto JSON.
 
<img width="686" height="648" alt="image" src="https://github.com/user-attachments/assets/a4becb04-f828-4097-98fe-0d1b89336680" />

 

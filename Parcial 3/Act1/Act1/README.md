# 🔎 Actividad #1 (Figuras geométricas)
 
**🗓️ Fecha:** 09/11/2026
 
## 📖 Contenido del repositorio
 
Salida por consola que aplica **herencia, polimorfismo y clases abstractas** para calcular el área y el perímetro de distintas figuras geométricas.
 
- **Figura:** Clase abstracta base con los métodos abstractos `CalcularArea()` y `CalcularPerimetro()`.
- **Rectangulo:** Hereda de `Figura`; recibe base y altura.
- **Cuadrado:** Hereda de `Figura`; recibe el lado.
- **Triangulo:** Hereda de `Figura`; recibe los tres lados y calcula el área con la fórmula de Herón.
- **Program:** Crea un arreglo de tipo `Figura[]` con una figura de cada clase y recorre el arreglo con un `foreach`, llamando a los mismos métodos en todas.
## 💻 Tecnologías
 
C#, .NET 8 (aplicación de consola), Visual Studio.
 
**Autor:** Rómel Tadeo Rodríguez González
 
## 🧩 Conceptos aplicados
 
| Concepto | Dónde se aplica |
| --- | --- |
| **Clase abstracta** | `Figura` no se puede instanciar; define qué deben implementar sus clases hijas. |
| **Herencia** | `Rectangulo`, `Cuadrado` y `Triangulo` heredan de `Figura`. |
| **Polimorfismo** | El arreglo `Figura[]` guarda objetos distintos y `f.CalcularArea()` ejecuta la versión de cada clase. |
| **Sobrescritura** | Cada clase usa `override` para implementar `CalcularArea()` y `CalcularPerimetro()`. |
 
Fórmulas utilizadas:
 
| Figura | Área | Perímetro |
| --- | --- | --- |
| Rectángulo | base × altura | 2 × (base + altura) |
| Cuadrado | lado × lado | 4 × lado |
| Triángulo | √(s·(s−a)·(s−b)·(s−c)), con s = perímetro / 2 | a + b + c |
 
## 🛠️ Instalación de las tecnologías
 
### Requisitos previos
 
- Windows, macOS o Linux.
- **.NET 8 SDK** desde <https://dotnet.microsoft.com/es-es/download/dotnet/8.0>.
- Visual Studio con la carga de trabajo **"Desarrollo de escritorio con .NET"** (opcional, también puede ejecutarse desde la terminal).
### Ejecutar el proyecto
 
Desde la terminal, dentro de la carpeta del proyecto:
 
```bash
dotnet run
```
 
O desde Visual Studio: abre `Act1.csproj` y presiona **F5**.
 
### Solución de problemas comunes
 
| Problema | Solución |
| --- | --- |
| Error CS0146 "Circular base type dependency" | `Figura` debe estar declarada fuera de `Triangulo`; no puede estar anidada dentro de una clase que hereda de ella. |
| "The name 'Math' / 'Console' does not exist" | Activa `<ImplicitUsings>enable</ImplicitUsings>` en el `.csproj` o agrega `using System;`. |
| El programa se cierra al instante | Ejecuta desde la terminal con `dotnet run`; el `Console.ReadKey()` final mantiene abierta la ventana. |
 
## 🔐 Información importante
 
- Se usa una sola clase `Program` con un único `Main`.
- `f.GetType().Name` muestra el nombre real de la clase de cada objeto, aunque la variable sea de tipo `Figura`.
- Los resultados se muestran con dos decimales usando `ToString("F2")`.
- Salida esperada:
```
  Figura:    Rectangulo
  Área:      15.00
  Perímetro: 16.00
 
  Figura:    Cuadrado
  Área:      16.00
  Perímetro: 16.00
 
  Figura:    Triangulo
  Área:      6.00
  Perímetro: 12.00
```
 
## 📸 Capturas de resultados
 
### Consola (Figuras): Uso de clases aplicando polimorfismo, herencia y clases abstractas. Cada figura calcula su área y perímetro con su propia implementación.
 
<img width="401" height="362" alt="image" src="https://github.com/user-attachments/assets/befa27af-9a37-4148-bf2b-bbf2153c6fac" />

 

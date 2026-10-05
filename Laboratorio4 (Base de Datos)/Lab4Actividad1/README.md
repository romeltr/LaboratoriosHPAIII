# 🔎 Diccionarios, Listas, Sobrecarga, Estadística y Recursividad

**🗓️ Fecha:** 28/09/2026

## 📖 Contenido del repositorio

Prácticas de estructuras de datos y técnicas de programación en C# mediante salida por consola.

- **Diccionarios y listas:** Uso de `Dictionary<string, object>` y `List<string>` para generar de forma dinámica la cláusula `SET` de un `UPDATE` y la sentencia `INSERT` de SQL con parámetros (`@campo`), a partir de los datos de un inventario.
- **Estadística (lanzamiento de dados):** Simula 6000 lanzamientos de un dado con `Random` y un `switch`, y muestra la frecuencia con la que sale cada cara.
- **Sobrecarga de métodos:** La clase `Class1` define dos métodos `Cuadrado`, uno para `int` y otro para `double`, y `ProbarMetodosSobreCargados` los invoca para comprobar cuál se ejecuta según el tipo del argumento.
- **Recursividad:** Cálculo del factorial de 0 a 10 con un método recursivo que define un caso base y un paso de recursividad.

> El proyecto trabaja una práctica a la vez: `Program.cs` ejecuta la de estadística y las demás están incluidas como bloques comentados al final del archivo. Para probar otra práctica, comenta el contenido de `Main` y descomenta el bloque correspondiente.

## 💻 Tecnologías

C#, aplicación de consola en .NET 10 (`net10.0`), Visual Studio 2026

**Autor:** Rómel Tadeo Rodríguez González

## 🛠️ Instalación de las tecnologías

### Requisitos previos

- Sistema operativo **Windows 10 u 11**, macOS o Linux (al ser una aplicación de consola en .NET 10, no depende de Windows).
- Mínimo 8 GB de RAM y alrededor de 10 GB de espacio libre en disco si usas Visual Studio.
- [Git](https://git-scm.com/downloads) para clonar el repositorio (opcional si descargas el ZIP).

### 1. Instalar el SDK de .NET 10

1. Descarga el **SDK de .NET 10** desde <https://dotnet.microsoft.com/es-es/download/dotnet/10.0>.
2. Ejecuta el instalador y sigue los pasos.
3. Abre una terminal nueva y verifica la instalación:

   ```bash
   dotnet --version
   ```

4. El resultado debe comenzar con `10.`

> Este proyecto **no** usa .NET Framework: el archivo `.csproj` apunta a `net10.0`, por lo que no se compila con .NET Framework 4.x.

### 2. Instalar Visual Studio (opcional)

Si prefieres trabajar con editor gráfico en lugar de la terminal:

1. Descarga **Visual Studio** (versión compatible con .NET 10, como Visual Studio 2026) desde <https://visualstudio.microsoft.com/es/downloads/>.
2. En la pestaña **Cargas de trabajo**, marca **"Desarrollo de escritorio con .NET"** (o **"Desarrollo multiplataforma con .NET"**).
3. Verifica en **Componentes individuales** que esté marcado el **SDK de .NET 10**.
4. Haz clic en **Instalar** y reinicia el equipo si el instalador lo solicita.

### 3. Clonar el repositorio

```bash
git clone https://github.com/romeltr/LaboratoriosHPAIII.git
cd LaboratoriosHPAIII/DiccionarioListasSobrecargaEstREcurs
```

O bien descarga el repositorio como ZIP desde GitHub (**Code → Download ZIP**) y extráelo.

### 4. Ejecutar el proyecto

**Desde la terminal:**

```bash
cd DictionarioPracticasDatos/DictionarioPracticasDatos
dotnet run
```

**Desde Visual Studio:**

1. Selecciona **Abrir un proyecto o una solución**.
2. Abre `DictionarioPracticasDatos/DictionarioPracticasDatos.slnx` (o el filtro de solución `DiccionarioPracticasDatos.slnf`).
3. Compila con **Ctrl + Shift + B** y ejecuta con **Ctrl + F5** para que la consola permanezca abierta al terminar.

> El archivo `.slnx` es el nuevo formato de solución de Visual Studio. Si tu versión no lo reconoce, abre directamente `DictionarioPracticasDatos.csproj`.

### Solución de problemas comunes

| Problema | Solución |
| --- | --- |
| `dotnet` no se reconoce como comando | Instala el SDK de .NET 10 y abre una terminal nueva. |
| Error "The current .NET SDK does not support targeting .NET 10.0" | Instala el SDK de .NET 10 o superior. |
| Visual Studio no abre el archivo `.slnx` | Actualiza Visual Studio o abre el `.csproj` directamente. |
| La consola se cierra al terminar | Ejecuta con **Ctrl + F5** o agrega `Console.ReadKey();` al final de `Main`. |
| Las frecuencias del dado cambian en cada ejecución | Es el comportamiento esperado, porque `Random` genera valores distintos cada vez. |

## 📸 Capturas de resultados

**Estadística (lanzamiento de dados):** Se utilizó `Random.Next(1, 7)` dentro de un ciclo `for` de 6000 iteraciones y un `switch` para acumular la frecuencia de cada cara. Los valores se aproximan a 1000 por cara.

<img width="620" height="331" alt="image" src="https://github.com/user-attachments/assets/cd510e20-b690-43c4-a809-07c2ad159491" />

**Diccionarios y listas:** Un `Dictionary<string, object>` con los datos del inventario permite generar la cláusula `SET` y la sentencia `INSERT` de forma dinámica.

<img width="976" height="267" alt="image" src="https://github.com/user-attachments/assets/38977e02-7fc1-4c22-b48d-77482bad6e12" />
<img width="1237" height="240" alt="image" src="https://github.com/user-attachments/assets/0cfd6b5c-fe84-44ff-b426-ae000f76dcfa" />


**Sobrecarga de métodos:** El método `Cuadrado` se ejecuta con la versión de `int` o de `double` según el tipo del argumento.

<img width="662" height="317" alt="image" src="https://github.com/user-attachments/assets/ab2e59ff-e880-4d67-b736-bff77a35840c" />

**Recursividad:** Factorial de los números del 0 al 10 con un método que se llama a sí mismo hasta llegar al caso base.

<img width="508" height="406" alt="image" src="https://github.com/user-attachments/assets/2b8ac070-f283-46a2-bf12-071040255769" />

🔎 Diccionario, Listas, Sobrecarga, Estadisticas y Recursividad.
🗓️ Fecha: 14/09/2026

📖 Contenido del repositorio
Programación con validaciones en la entrada de los usuarios.

EjemploGrid: Formulario que permite validar datos de entrada y registrarlos.
FormsActividad3: Formulario capaz de abrir otro formulario.
JuegodeCraps: Utiliza funciones random para imitar el juego de Craps.
💻 Tecnologías
C#, Windows Forms (.NET Framework)

Autor: Rómel Tadeo Rodríguez González

🛠️ Instalación de las tecnologías
Requisitos previos
Sistema operativo Windows 10 u 11 (Windows Forms con .NET Framework solo se ejecuta en Windows).
Mínimo 8 GB de RAM y alrededor de 10 GB de espacio libre en disco.
Git para clonar el repositorio (opcional si descargas el ZIP).
1. Instalar Visual Studio
Descarga Visual Studio Community (gratuito) desde https://visualstudio.microsoft.com/es/downloads/.
Ejecuta el instalador (VisualStudioSetup.exe) y espera a que cargue el Visual Studio Installer.
En la pestaña Cargas de trabajo, marca "Desarrollo de escritorio con .NET". Esta carga incluye:
El compilador y las herramientas de C#.
El diseñador y las plantillas de Windows Forms.
En la pestaña Componentes individuales, verifica que estén marcados:
.NET Framework 4.8 SDK
Herramientas de destino de .NET Framework 4.8 (.NET Framework 4.8 targeting pack)
Haz clic en Instalar y espera a que termine (puede tardar varios minutos según tu conexión).
Reinicia el equipo si el instalador lo solicita.
Si ya tienes Visual Studio instalado: abre Visual Studio Installer → Modificar y agrega la carga de trabajo "Desarrollo de escritorio con .NET".

2. Verificar la instalación de .NET Framework
Abre PowerShell y ejecuta:

Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" | Select-Object Release, Version
Un valor de Release igual o mayor a 528040 indica que tienes .NET Framework 4.8 o superior.

Si no está instalado, descarga el .NET Framework 4.8 Developer Pack desde https://dotnet.microsoft.com/es-es/download/dotnet-framework/net48.

3. Clonar el repositorio
git clone <URL-DEL-REPOSITORIO>
cd <NOMBRE-DEL-REPOSITORIO>
O bien descarga el repositorio como ZIP desde GitHub (Code → Download ZIP) y extráelo.

4. Abrir y ejecutar cada proyecto
Abre Visual Studio y selecciona Abrir un proyecto o una solución.
Entra a la carpeta del proyecto que quieras probar (EjemploGrid, FormsActividad3 o JuegodeCraps) y abre su archivo .sln.
Espera a que Visual Studio cargue la solución. Si aparece un aviso de restaurar paquetes, acéptalo.
Verifica que el destino sea .NET Framework 4.8 (clic derecho en el proyecto → Propiedades → Aplicación → Plataforma de destino).
Compila con Ctrl + Shift + B y ejecuta con F5 (o el botón ▶ Iniciar).
Solución de problemas comunes
Problema	Solución
No aparece la plantilla de Windows Forms	Instala la carga de trabajo "Desarrollo de escritorio con .NET" desde Visual Studio Installer.
Error "targeting pack for .NET Framework not found"	Instala el .NET Framework 4.8 Developer Pack o el componente individual en Visual Studio Installer.
El diseñador del formulario no abre	Compila la solución primero (Ctrl + Shift + B) y reabre el formulario.
El proyecto no abre en Mac o Linux	Windows Forms con .NET Framework requiere Windows; usa una máquina virtual con Windows.
📸 Capturas de resultados
EjemploGrid: Se utilizaron herramientas como DataGridView para la visualización de los datos validados, ErrorProvider para indicar cuales cajas de texto poseen error image

FormsActividad3: Se utilizó MDIparent para poder asignar un formulario padre, y invocar el formulario hijo asignado. image

JuegodeCraps: Uso de una fucni[on para invocar valores aleatorios y realizar sumas totales para determinar un ganador. image

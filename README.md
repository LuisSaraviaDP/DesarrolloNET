# Mi Proyecto MVC con Consumo de API

Este proyecto es una aplicación web MVC construida con .NET 6 que consume una API externa.

## Configuración del Proyecto

### Requisitos Previos
Asegúrate de tener instalado lo siguiente:
- .NET 6 SDK
- Visual Studio 2022

### Pasos para Configurar el Proyecto
1. Clona este repositorio: `git clone https://github.com/tu-usuario/tu-proyecto.git`
2. Abre la solución en Visual Studio.
3. Restaura los paquetes NuGet: `dotnet restore`
4. Configura la cadena de conexión de la base de datos en `appsettings.json`.
5. Asegúrate de tener las variables de entorno necesarias.

## Ejecución del Proyecto

1. Compila la solución en Visual Studio.
2. Ejecuta la aplicación web.
3. Abre tu navegador y visita [http://localhost:5000](http://localhost:5000).

## Estructura del Proyecto

- `/Controllers`: Contiene los controladores de la aplicación.
- `/Models`: Define los modelos utilizados en la aplicación.
- `/Views`: Contiene las vistas de la aplicación.
- `/Services`: Contiene servicios para la comunicación con la API.

## Consumo de la API

Este proyecto consume datos de una API externa. Asegúrate de tener acceso a la API y configura las URL y claves necesarias en `appsettings.json` o mediante variables de entorno.

## Contribuciones

¡Contribuciones son bienvenidas! Si encuentras problemas o mejoras, por favor abre un issue o envía un pull request.

## Licencia

Este proyecto está bajo la licencia [MIT](LICENSE).

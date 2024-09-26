# API RESTful en ASP.NET Core

Este proyecto es una API RESTful básica construida con **ASP.NET Core 8**. La API permite gestionar una lista de usuarios, realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar), y filtrar usuarios por su dominio de correo electrónico.

## Características

- **Entidad Usuario**: Manejo de una entidad de usuario con las siguientes propiedades:
  - `Id` (int)
  - `Nombre` (string)
  - `CorreoElectronico` (string)
  - `FechaRegistro` (DateTime)

- **Operaciones CRUD**:
  - **GET**: Obtener todos los usuarios.
  - **GET**: Obtener un usuario por ID.
  - **POST**: Agregar un nuevo usuario.
  - **PUT**: Actualizar un usuario existente.
  - **DELETE**: Eliminar un usuario por ID.

- **Filtrado**:
  - Filtrar usuarios por su dominio de correo electrónico (e.g. `@gmail.com`).

- **Validaciones y Manejo de Excepciones**:
  - Validación del modelo, incluyendo validación personalizada para el formato de correo electrónico.
  - Manejo de excepciones con respuestas HTTP adecuadas.

## Requisitos

- **.NET Core SDK 6.0** o superior.
- **Visual Studio 2022** o **Visual Studio Code**.

##  Pruebas usando Swagger
Una vez que el proyecto está corriendo, puedes realizar pruebas de los diferentes endpoints directamente desde la interfaz de Swagger. Swagger te permite:

Ver todos los endpoints disponibles de la API.
Probar los métodos GET, POST, PUT y DELETE.
Enviar parámetros directamente desde la interfaz gráfica y visualizar las respuestas de la API en tiempo real.

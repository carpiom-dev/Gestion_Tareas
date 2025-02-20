# 📌 Proyecto de Gestión de Tareas con .NET 8 y Razor Pages

## 📖 Descripción

Este proyecto es una aplicación web desarrollada en **.NET 8 con Razor Pages**, que permite gestionar tareas mediante un **frontend** conectado a una API mediante **JWT** para autenticación.

## 🚀 Tecnologías Utilizadas

- **.NET 8**
- **Razor Pages**
- **ASP.NET Core Identity** (Autenticación con JWT)
- **HttpClientFactory** (Consumo de API)
- **Bootstrap** (Diseño y estilos)

## 🛠️ Configuración del Proyecto

### 1️⃣ Requisitos Previos

- **.NET 8 SDK** instalado.
- **Visual Studio 2022** o cualquier editor compatible.
- API en funcionamiento con los endpoints necesarios.

### 2️⃣ Configuración de la API

En el archivo **appsettings.json**, agrega la URL base de la API:

```json
{
  "BaseUrl": "https://tu-api.com/api/"
}
```

### 3️⃣ Instalación de Dependencias

Ejecuta el siguiente comando en la terminal:

```sh
dotnet restore
```

### 4️⃣ Ejecución del Proyecto

Para iniciar el servidor, usa:

```sh
dotnet run
```

## 🔑 Autenticación y Sesión

- Inicio de sesión enviando credenciales: `{ "usuario": "string", "clave": "string", "recordarSesion": true }`
- Recepción de **JWT** en la respuesta.
- El token se almacena en la **sesión** del usuario.
- Cierre de sesión al cerrar el navegador.

## 🌟 Funcionalidades Principales

✅ **Login con JWT** ✅ **Listado de tareas** ✅ **Crear una nueva tarea** ✅ **Editar tarea existente** ✅ **Eliminar tarea** ✅ **Consultar tarea por ID**

## 📸 Capturas de Pantalla

### 🔹 Pantalla de Login



### 🔹 Lista de Tareas



### 🔹 Formulario de Creación/Edición



## 📌 API Endpoints Utilizados

| Método | Endpoint                  | Descripción                       |
| ------ | ------------------------- | --------------------------------- |
| POST   | `/login`                  | Autenticación y generación de JWT |
| POST   | `/consultar-task-items`   | Obtener listado de tareas         |
| POST   | `/consultar-task-item-id` | Obtener tarea por ID              |
| POST   | `/crear-task-item`        | Crear una nueva tarea             |
| PUT    | `/actualizar-task-item`   | Actualizar tarea                  |
| DELETE | `/eliminar-task-item`     | Eliminar tarea                    |

## 📄 Licencia

Este proyecto está bajo la licencia **MIT**. ¡Siéntete libre de usarlo y mejorarlo! 🎯

---

📌 **Autor:** *Tu Nombre* 📅 **Última actualización:** *Febrero 2025*


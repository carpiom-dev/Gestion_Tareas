
# 🛠️ Plantilla - Proyecto de Desarrollo Profesional

Bienvenido al repositorio de un proyecto profesional basado en el **patrón de arquitectura hexagonal** y **Entity Framework Core**. Este proyecto se encuentra dividido en varios módulos para facilitar su mantenimiento y escalabilidad.

---

## 📁 Estructura del Proyecto

El proyecto está organizado de la siguiente manera:

* **Orígenes externos:** Contiene dependencias y recursos externos del proyecto.
* **src:** Código fuente principal del proyecto.
    * **Plantilla.Api:** API web construida con **ASP.NET Core**, que expone los endpoints para interactuar con el dominio del negocio.
    * **Plantilla.Dto:** Objetos de transferencia de datos (DTOs) utilizados para comunicar la API con la capa de negocio.
    * **Plantilla.Entidad:** Entidades de dominio que representan los objetos del negocio.
    * **Plantilla.Infraestructura:** Implementación de interfaces y servicios de infraestructura como acceso a datos y logging.
    * **Plantilla.Negocio:** Lógica de negocio y casos de uso del dominio.
    * **Plantilla.RepositorioEfCore:** Implementación de repositorios usando **Entity Framework Core** para el acceso a la base de datos.
* **test:** Proyectos de pruebas unitarias para cada capa del proyecto.
* **Dependencias:** Lista de paquetes NuGet utilizados en el proyecto.
* **Procesos:** Scripts y archivos de configuración para procesos como despliegue, generación de documentación, etc.

---

## 💻 Tecnologías Utilizadas

El proyecto está desarrollado utilizando las siguientes tecnologías:

- **.NET**: Framework de desarrollo principal.
- **ASP.NET Core**: Framework para la construcción de la API web.
- **Entity Framework Core**: ORM (Object-Relational Mapper) para el acceso a la base de datos.
- **SQL Server**: Base de datos utilizada.

---

## 🔧 Migraciones Automáticas y Usuario por Defecto

¡Configura tu base de datos de manera rápida y sencilla! Este proyecto incluye migraciones automáticas de **Entity Framework Core Code First**. La base de datos **PruebaEstructura** se creará automáticamente la primera vez que ejecutes el proyecto con todas las tablas necesarias.

### 👤 Usuario Administrador por Defecto

Puedes acceder al sistema de inmediato con el siguiente usuario administrador:

- **Usuario:** `admin@gmail.com`
- **Contraseña:** `Admin123!`

---

## 🗄️ Configuración de la Base de Datos

Para configurar la base de datos, puedes utilizar Docker para ejecutar una instancia de SQL Server. Aquí tienes el comando para crear el contenedor:

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=TuPassword123!" -p 1434:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

### 🔑 Cadena de Conexión

Asegúrate de configurar correctamente la conexión a la base de datos en el archivo `appsettings.json` de la API:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=MMAPP;Initial Catalog=PruebaEstructura;Integrated Security=True;TrustServerCertificate=True; MultipleActiveResultSets=True"
}
```

---

## 🚀 Cómo Empezar

1. **Clona el repositorio** a tu máquina local.
2. **Configura la base de datos** usando Docker o tu servidor de SQL Server preferido.
3. **Ejecuta las migraciones automáticas** para crear la base de datos.
4. **Inicia el proyecto** en tu entorno de desarrollo.


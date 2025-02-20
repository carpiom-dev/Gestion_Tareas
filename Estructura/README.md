# Plantilla - Proyecto de Desarrollo Profesional

Este repositorio contiene la estructura y código fuente de un proyecto profesional desarrollado utilizando el patrón de arquitectura hexagonal y Entity Framework Core. El proyecto se divide en siete proyectos distintos, cada uno con una responsabilidad específica.

## Estructura del Proyecto

El proyecto está organizado de la siguiente manera:

* **Orígenes externos:**  Contiene dependencias externas y recursos utilizados en el proyecto.
* **src:**  Contiene el código fuente principal del proyecto.
    * **Plantilla.Api:**  Contiene la API web del proyecto, construida con ASP.NET Core.  Expone los endpoints para interactuar con el dominio del negocio.
    * **Plantilla.Dto:**  Contiene los objetos de transferencia de datos (DTOs) utilizados para comunicar la API con la capa de negocio.
    * **Plantilla.Entidad:** Contiene las entidades de dominio que representan los objetos del negocio.
    * **Plantilla.Infraestructura:**  Contiene la implementación de interfaces y servicios de infraestructura, como acceso a datos, logging, etc.
    * **Plantilla.Negocio:**  Contiene la lógica de negocio y los casos de uso del dominio.
    * **Plantilla.RepositorioEfCore:** Contiene la implementación de los repositorios utilizando Entity Framework Core para el acceso a la base de datos.
* **test:**  Contiene las pruebas unitarias del proyecto.
    * **Pruebas Unitarias:**  Contiene los proyectos de pruebas unitarias para cada capa del proyecto.
* **Dependencias:**  Lista las dependencias y paquetes NuGet utilizados en el proyecto.
* **Procesos:**  Contiene scripts y archivos de configuración para procesos como despliegue, generación de documentación, etc.

## Tecnologías Utilizadas

* **.NET:**  Framework de desarrollo principal.
* **ASP.NET Core:**  Framework para la construcción de la API web.
* **Entity Framework Core:**  ORM (Object-Relational Mapper) para el acceso a la base de datos.
* **SQL Server:**  Base de datos utilizada.

## Migraciones Automáticas y Usuario por Defecto

¡Configurar tu base de datos es más fácil que nunca! Este proyecto incluye migraciones automáticas de Entity Framework Core Code First EF. Esto significa que la primera vez que ejecutes el proyecto, la base de datos PruebaEstructura se creará automáticamente con todas las tablas que necesitas.

Además, para que puedas empezar a usar la aplicación de inmediato, hemos creado un usuario administrador por defecto con estas credenciales:

* **Usuario:* admin@gmail.com
* **Contraseña:* Admin123!

## Configuración de la Base de Datos

* **DOCKER:* docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=TuPassword123!" -p 1434:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
        "DefaultConnection": "Data Source=MMAPP;Initial Catalog=PruebaEstructura;Integrated Security=True;TrustServerCertificate=True; MultipleActiveResultSets=True"

El proyecto utiliza SQL Server como base de datos. Se puede configurar la conexión en el archivo `appsettings.json` del proyecto `Plantilla.Api`.

**Cadena de Conexión:**

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=MMAPP;Initial Catalog=PruebaEstructura;Integrated Security=True;TrustServerCertificate=True; MultipleActiveResultSets=True"
}
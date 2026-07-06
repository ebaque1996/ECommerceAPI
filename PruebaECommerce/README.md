# E-Commerce Backend API

API RESTful desarrollada en .NET Core para la gestión de un carrito de compras y productos.

## ⚙️ Configuración Requerida

1. Asegúrate de tener instalado el **.NET SDK** (versión correspondiente, ej. 8.0).
2. Tener acceso a una instancia de **SQL Server**.
3. Configurar la cadena de conexión:
   El proyecto está configurado por defecto para usar **SQL Server LocalDB** (incluido con Visual Studio) para facilitar su revisión. 
   Abre el archivo `appsettings.json` y asegúrate de que el nodo `ConnectionStrings` tenga este valor:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ECommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }


Instrucciones de Ejecución
1. Abre una terminal en la raíz del proyecto.

2. Restaura los paquetes NuGet:
    dotnet restore
        
3. Aplica las migraciones para generar la base de datos local:
    dotnet ef database update

4. Ejecuta el proyecto:
    dotnet run

Consideraciones Técnicas:
Arquitectura: Se implementó una Arquitectura de Capas Lógicas (N-Tier) en un único proyecto para priorizar la agilidad de entrega bajo el límite de tiempo de la prueba. El código cumple estrictamente con los principios SOLID, separando responsabilidades a través del Patrón Repositorio y Capa de Servicios mediante Inyección de Dependencias, lo que permite extraer las capas a proyectos físicos independientes (Clean Architecture) con un esfuerzo mínimo.
Control de Flujo: Se utilizó un patrón Result<T> global para estandarizar las respuestas HTTP de la API y manejar las validaciones de negocio de forma limpia, evitando el uso de excepciones costosas para el control de flujos lógicos.
Autenticación (Pendiente): Debido a las restricciones de tiempo para la entrega, el módulo de seguridad JWT no fue integrado. Para demostrar y evaluar correctamente la funcionalidad lógica del carrito de compras y las órdenes por cliente, el parámetro userId se solicita explícitamente en los endpoints (vía Query Params o Body).

La interfaz de pruebas y documentación está disponible vía Swagger. Al ejecutar la API, navega a https://localhost:<puerto>/swagger.
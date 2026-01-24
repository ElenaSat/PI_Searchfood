# PI_Searchfood

Sistema de búsqueda de comida y gestión de restaurantes desarrollado en .NET.

## 🛠 Tecnologías Utilizadas

### Backend & Core
*   **Lenguaje**: C#
*   **Framework**: .NET Framework 4.6.1
*   **Plataforma Web**: 
    *   ASP.NET Web API 2 (Backend Services)
    *   ASP.NET MVC 5 (Frontend Application)
*   **ORM (Object-Relational Mapping)**: Entity Framework 6.2.0 (Enfoque **Database First**)
*   **Base de Datos**: SQL Server

### Frontend (MVC)
*   **Motor de Vistas**: Razor
*   **Framework CSS**: Bootstrap 3.3.7
*   **Scripting**: jQuery 3.3.1, jQuery Validation

### Herramientas y Librerías Adicionales
*   **Serialización**: Newtonsoft.Json 11.0.2
*   **Monitoreo**: Microsoft Application Insights

## 🏗 Arquitectura y Patrones de Diseño

El proyecto sigue una arquitectura en capas (N-Tier) distribuida en múltiples proyectos dentro de la solución:

### 1. Capa de Presentación (Frontend)
*   **Proyecto**: `PI_SearchfoodF.MVC`
*   **Patrón**: MVC (Model-View-Controller).
*   **Descripción**: Aplicación web encargada de la interfaz de usuario. Contiene su propia lógica de acceso a datos para módulos específicos (ej. Incidencias) en la carpeta `DAL`.

### 2. Capa de Servicios (API)
*   **Proyecto**: `PI_Searchfood.API`
*   **Patrón**: Web API / REST.
*   **Descripción**: Expone endpoints para el consumo de datos y lógica de negocio, sirviendo como interfaz entre el frontend (o clientes externos) y la lógica central.

### 3. Capa de Lógica de Negocio y Datos
*   **Proyecto**: `PI_Searchfood.Logica`
*   **Patrones**: 
    *   **Class/Service Pattern**: Clases encapsuladas en la carpeta `BL` (ej. `clsBuscador.cs`, `clsComida.cs`) que contienen las reglas de negocio.
    *   **Database First**: Mapeo directo de la base de datos usando archivos `.edmx` (Entity Framework) en la carpeta `Entidades`.
*   **Descripción**: Centraliza la lógica core del negocio (Usuarios, Restaurantes, Comidas, Reservas).

## 📂 Estructura del Proyecto

*   **PI_Searchfood.API**: Controladores API y configuración de servicios.
*   **PI_SearchfoodF.MVC**: Controladores MVC, Vistas (.cshtml) y recursos estáticos (CSS/JS).
*   **PI_Searchfood.Logica**:
    *   `BL/`: Clases de lógica de negocio.
    *   `Entidades/`: Modelos generados por Entity Framework (.edmx).
    *   `Models/`: DTOs o modelos auxiliares.

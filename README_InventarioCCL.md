# Inventario CCL

Aplicación web para la gestión de inventario desarrollada como prueba
técnica.

## Tecnologías

-   Backend: .NET 8 Web API
-   Base de datos: PostgreSQL
-   Frontend: Angular (Standalone)
-   Autenticación: JWT

## Funcionalidades

-   Inicio de sesión con usuario en memoria
-   Consulta de inventario
-   Registro de movimientos de productos (entrada y salida)
-   Protección de endpoints mediante JWT

## Configuración del proyecto

### Base de datos

1.  Crear la base de datos:

CREATE DATABASE InventarioCCL;

2.  Conectarse a la base de datos y ejecutar:

CREATE TABLE products ( id INT PRIMARY KEY, name VARCHAR(100) NOT
NULL, quantity INT NOT NULL );

INSERT INTO products (name, quantity) VALUES ('Producto A', 10),
('Producto B', 5), ('Producto C', 20);

### Backend

Ubicación: /backend/InventarioCCL.api

Configurar la conexión en appsettings.json:

"ConnectionStrings": { "DefaultConnection":
"Host=localhost;Port=5432;Database=inventarioccl;Username=postgres;Password=TU_PASSWORD"
}

Ejecutar:

dotnet restore dotnet run

El API estará disponible en: https://localhost:7025/swagger

### Frontend

Ubicación: /frontend/inventario-frontend

Instalar dependencias:

npm install

Ejecutar:

ng serve

Aplicación disponible en: http://localhost:4200

## Credenciales

Usuario: admin\
Contraseña: admin

## Uso

1.  Iniciar sesión
2.  Consultar el inventario
3.  Registrar movimientos de entrada o salida
4.  Ver actualización del inventario

## Notas

-   Se utiliza JWT para la autenticación
-   El frontend envía el token automáticamente mediante un interceptor
-   Se usa Entity Framework Core para el acceso a datos

## Autor

Daniel Felipe Sánchez

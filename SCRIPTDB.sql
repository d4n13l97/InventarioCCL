--se crea la base de datos
CREATE DATABASE "InventarioCCL";

--seleccionar base de datos InventarioCCL


-- se crea la tabla productos
CREATE TABLE products (
    id int PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    quantity INT NOT NULL
);

-- se insertan los datos iniciales
INSERT INTO products (name, quantity) VALUES
('Producto A', 10),
('Producto B', 5),
('Producto C', 20);


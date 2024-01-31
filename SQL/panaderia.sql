CREATE TABLE clientes (
    id INT PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL,
    direccion NVARCHAR(255) NOT NULL,
    telefono VARCHAR(20) NOT NULL
);
GO

CREATE TABLE empleados (
    id INT PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL,
    cargo NVARCHAR(255) NOT NULL,
    salario DECIMAL(10, 2) NOT NULL
);
GO

CREATE TABLE proveedores (
    id INT PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL,
    contacto NVARCHAR(255) NOT NULL,
    direccion NVARCHAR(50) NOT NULL,
    cantidad_pan INT
);
GO

CREATE TABLE categorias (
    id INT PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL
);
GO

CREATE TABLE forma_de_pago (
    id INT PRIMARY KEY,
    tipo_pago NVARCHAR(50) NOT NULL, 
    nombre NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE ventas (
    id INT PRIMARY KEY,
    fecha DATE NOT NULL,
    id_cliente INT NOT NULL,
    id_empleado INT NOT NULL,
    id_forma_de_pago INT NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES clientes(id),
    FOREIGN KEY (id_empleado) REFERENCES empleados(id),
    FOREIGN KEY (id_forma_de_pago) REFERENCES forma_de_pago(id)
);
GO
CREATE TABLE productos (
    id INT PRIMARY KEY,
    nombre NVARCHAR(255) NOT NULL,
    precio DECIMAL(10, 2),
    cantidad INT NOT NULL,
    fecha_vencimiento DATE NOT NULL,
    id_proveedor INT,
    id_categoria INT,
    id_ventas INT,  
    FOREIGN KEY (id_proveedor) REFERENCES proveedores(id),
    FOREIGN KEY (id_categoria) REFERENCES categorias(id),
    FOREIGN KEY (id_ventas) REFERENCES ventas(id)  
);
GO
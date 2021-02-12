--proyecto de un resturant la guarida de profe
CREATE TABLE Usuario (
	id INT IDENTITY(1,1) PRIMARY KEY,
	usuario VARCHAR(20) NOT NULL UNIQUE,
	clave VARCHAR(50) NOT NULL
);

CREATE TABLE Cliente (
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
	apellidos VARCHAR(50) NOT NULL,
	direccion VARCHAR(50) NOT NULL,
	telefono VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	usuarioRegistro VARCHAR(50) DEFAULT SUSER_SNAME(),
	fechaRegistro DATETIME DEFAULT GETDATE(),
	registroActivo BIT DEFAULT 1,
);

CREATE TABLE Pedido (
	id INT IDENTITY(1,1) PRIMARY KEY,
	idProducto INT NOT NULL,
	fecha DATE NOT NULL,
	idCliente INT NOT NULL,
	usuarioRegistro VARCHAR(50) DEFAULT SUSER_SNAME(),
	fechaRegistro DATETIME DEFAULT GETDATE(),
	registroActivo BIT DEFAULT 1,
	CONSTRAINT FK_Pedido_Cliente FOREIGN KEY(idCliente) REFERENCES Cliente(id),
	CONSTRAINT FK_Pedido_Producto FOREIGN KEY(idProducto) REFERENCES Producto(id)
);

CREATE TABLE PedidoDetalle (
	id INT IDENTITY(1,1) PRIMARY KEY,
	cantidad DECIMAL NOT NULL DEFAULT 0,
	precioUnitario  DECIMAL NOT NULL,
	total  DECIMAL NOT NULL,
	idPedido INT NOT NULL,
	idProducto INT NOT NULL,
	usuarioRegistro VARCHAR(50) DEFAULT SUSER_SNAME(),
	fechaRegistro DATETIME DEFAULT GETDATE(),
	registroActivo BIT DEFAULT 1,	
	CONSTRAINT FK_Pago_Pedido FOREIGN KEY(idPedido) REFERENCES Pedido(id),
	CONSTRAINT FK_Pago_Producto FOREIGN KEY(idProducto) REFERENCES Producto(id)
);

CREATE TABLE Producto (
	id INT IDENTITY(1,1) PRIMARY KEY,
	nombreDelPlato VARCHAR(250) NOT NULL,
	precio DECIMAL NOT NULL,
	usuarioRegistro VARCHAR(50) DEFAULT SUSER_SNAME(),
	fechaRegistro DATETIME DEFAULT GETDATE(),
	registroActivo BIT DEFAULT 1,
);



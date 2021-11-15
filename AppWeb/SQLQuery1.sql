

create table ADMINISTRADOR(
Correo_electronico varchar(25) not null,
Cedula decimal not null UNIQUE,
Nombre varchar(15) not null,
Apellido1 varchar(15) not null,
Apellido2 varchar(15),
Direccion varchar(30) not null,
Fecha_nacimiento date not null,
Foto varbinary(MAX),
Contraseña varchar(15),
PRIMARY KEY (Correo_electronico)
);

create table NUTRICIONISTA(
Correo_electronico varchar(25) not null,
Cedula decimal not null UNIQUE,
Nombre varchar(15) not null,
Apellido1 varchar(15) not null,
Apellido2 varchar(15),
Direccion varchar(30) not null,
Fecha_nacimiento date not null,
Foto varbinary(MAX),
Contraseña varchar(15),
IMC decimal not null,
Peso int not null,
Tipo_cobro varchar(7) not null,
Numero_tarjeta decimal(10,0) not null, 
Codigo decimal not null,
PRIMARY KEY (Correo_electronico)
);

create table CLIENTE(
Correo_electronico varchar(25) not null,
Cedula decimal not null UNIQUE,
Nombre varchar(15) not null,
Apellido1 varchar(15) not null,
Apellido2 varchar(15),
Pais varchar(15) not null,
Fecha_nacimiento date not null,
Foto varbinary(MAX),
Contraseña varchar(15),
IMC decimal not null,
Peso_actual int not null,
Peso int not null,
Consumo_calorias int not null,
NCorreo_electronico varchar(25) not null,
Pnombre varchar(15) not null,
PRIMARY KEY (Correo_electronico)
);

create table PRODUCTO(
Nombre varchar(15) not null UNIQUE,
Codigo_barras decimal not null,
Estado varchar(10) not null,
Descripcion varchar(100),
Porcion int not null,
Energia int not null,
Grasa int not null,
Sodio int not null,
Carbohidratos int not null,
Proteina int not null,
Calcio int not null,
Hierro int not null,
Vitaminas varchar(50),
ACorreo_electronico varchar(25) not null,
PRIMARY KEY (Codigo_barras)
);

create table RECETA(
Nombre varchar(15) not null,
Descripcion varchar(100),
Porcion int not null,
Energia int not null,
Grasa int not null,
Sodio int not null,
Carbohidratos int not null,
Proteina int not null,
Calcio int not null,
Hierro int not null,
Vitaminas varchar(50),
CCorreo_electronico varchar(25) not null,
PRIMARY KEY (Nombre)
);

create table PLAN_(
Nombre varchar(15) not null,
NCorreo_electronico varchar(25) not null,
PRIMARY KEY (Nombre)
);

create table MEDIDAS(
CCorreo_electronico varchar(25) not null,
Fecha date not null,
Cintura decimal not null,
Cuello decimal not null,
Caderas decimal not null,
Musculo int not null,
Grasa int not null,
FOREIGN KEY(CCorreo_electronico) REFERENCES CLIENTE(Correo_electronico),
);

create table CLIENTE_RECETA(
Receta_nombre varchar(15) not null,
Ccorreo_electronico varchar(25) not null,
Tiempo varchar(20) not null,
Fecha date not null,
FOREIGN KEY(Ccorreo_electronico) REFERENCES CLIENTE(Correo_electronico),
FOREIGN KEY(Receta_nombre) REFERENCES RECETA(Nombre)
);

create table CLIENTE_PRODUCTOS(
Producto_codigo decimal not null,
Ccorreo_electronico varchar(25) not null,
Tiempo varchar(20) not null,
Fecha date not null,
FOREIGN KEY(Ccorreo_electronico) REFERENCES CLIENTE(Correo_electronico),
FOREIGN KEY(Producto_codigo) REFERENCES PRODUCTO(Codigo_barras)
);

create table RECETA_PRODUCTOS(
Receta_nombre varchar(15) not null,
Producto_codigo decimal not null,
Porcion int not null,
FOREIGN KEY(Receta_nombre) REFERENCES RECETA(Nombre),
FOREIGN KEY(Producto_codigo) REFERENCES PRODUCTO(Codigo_barras)
);


create table PLAN_PRODUCTOS(
Plan_nombre varchar(15) not null,
Producto_codigo decimal not null,
Tiempo varchar(20),
FOREIGN KEY(Plan_nombre) REFERENCES PLAN_(Nombre),
FOREIGN KEY(Producto_codigo) REFERENCES PRODUCTO(Codigo_barras)
);


ALTER TABLE CLIENTE 
ADD FOREIGN KEY(NCorreo_electronico)
REFERENCES NUTRICIONISTA(Correo_electronico)

ALTER TABLE CLIENTE 
ADD FOREIGN KEY(Pnombre)
REFERENCES PLAN_(Nombre)

ALTER TABLE PLAN_
ADD FOREIGN KEY(NCorreo_electronico)
REFERENCES NUTRICIONISTA(Correo_electronico)

ALTER TABLE PRODUCTO 
ADD FOREIGN KEY(ACorreo_electronico)
REFERENCES ADMINISTRADOR(Correo_electronico)

ALTER TABLE RECETA 
ADD FOREIGN KEY(CCorreo_electronico)
REFERENCES CLIENTE(Correo_electronico)
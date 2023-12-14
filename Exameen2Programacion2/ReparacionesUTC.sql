 CREATE DATABASE REPARACIONESUTC
GO

USE ReparacionesUTC
GO

CREATE TABLE Tecnicos
(
	TecnicoID int identity(1,1) PRIMARY KEY,
    Nombre varchar(50),
	Especialidad varchar(50)
)

GO
CREATE TABLE Asignaciones
(
	AsignacionesID int identity(1,1) PRIMARY KEY,
	TecnicoID int,
	ReparacionID varchar(50),
	FechaAsignacion datetime CONSTRAINT df_FechaAsignacion DEFAULT GETDATE(),
	FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID)
)

GO

CREATE TABLE Usuarios
(
    UsuarioID int identity(1,1) PRIMARY KEY,
    Nombre varchar(50) NOT NULL,
    CorreoElectronico varchar(50),
    Telefono varchar(15) CONSTRAINT UQ_Telefono UNIQUE (Telefono)
)

Create table USUARIOCE
(
   ID INT IDENTITY(1,1),
   correo VARCHAR(50) NOT NULL,
   clave VARCHAR(50) NOT NULL,
   nombre VARCHAR(50) NOT NULL,
   CONSTRAINT PK_ID PRIMARY KEY (ID),
   CONSTRAINT UQ_CORREO UNIQUE (CORREO) 
)

CREATE TABLE ROLES
(
   ID INT IDENTITY,
   DESCRIPCION VARCHAR(50) NOT NULL,
   CONSTRAINT PK_IDROL PRIMARY KEY (ID),
)

CREATE TABLE USUARIOROLES
(
  IDUSUARIO INT,
  IDROLES INT,
  CONSTRAINT FK_IDUSUARIO FOREIGN KEY (IDUSUARIO) REFERENCES USUARIOCE(ID),
  CONSTRAINT FK_IDROLES FOREIGN KEY (IDROLES) REFERENCES ROLES(ID)
)

GO

CREATE TABLE Equipo
(
    EquipoID int identity(1,1) PRIMARY KEY,
    TipoEquipo varchar(50) NOT NULL,
    Modelo varchar(50),
    UsuarioID int,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
)

GO

CREATE TABLE Reparaciones
(
    ReparacionesID int identity(1,1) PRIMARY KEY,
    EquipoID int,
    FOREIGN KEY (EquipoID) REFERENCES Equipo(EquipoID),
    FechaSolicitud datetime CONSTRAINT df_FechaSolicitud DEFAULT GETDATE(),
    Estado char(1),
    AsignacionID int,
    FOREIGN KEY (AsignacionID) REFERENCES Asignaciones(AsignacionesID)
)

GO

 CREATE TABLE DetallesReparaciones
(
    DetallesReparacionID int identity(1,1) PRIMARY KEY,
    ReparacionID int,
    FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionesID),
    Descripcion varchar(50),
    FechaInicio datetime CONSTRAINT df_FechaInicio DEFAULT GETDATE(),
    FechaFin datetime CONSTRAINT df_FechaFin DEFAULT GETDATE()
)

GO

INSERT INTO USUARIOCE(correo, clave, nombre) VALUES
('anthony@utc.com', '123', 'Anthony')

INSERT INTO ROLES VALUES('Administrador'),('Tecnico'),('Usuario')

INSERT INTO ASIGNACIONES (FechaAsignacion) VALUES ('2023-12-07 17:18:00:00')

INSERT INTO USUARIOROLES VALUES (1,1)


INSERT INTO Tecnicos(Nombre, Especialidad) VALUES 
('Alex', 'Soporte Técnico'), 
('Gerson', 'Seguridad Informática')
GO

INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES 
('Diego', ' Diegocr@puravida.com', '89154236'), 
('Yuliana', 'Yulianacr@puravida.com', '65789412'), 
('Raquel', 'Raquelcr@puravida.com', '72459816')
GO
Select 'Nombre:' + Nombre + 'Correo Electronico:' + CorreoElectronico +  'Telefono:' + Telefono From Usuarios
GO

create procedure consultaUsuarios
 as
	begin
	Select 'Nombre:' + Nombre + 'Correo Electronico:' + CorreoElectronico +  'Telefono:' + Telefono From Usuarios
	end

INSERT INTO Equipo(TipoEquipo, Modelo, UsuarioID) VALUES
('Servidor', 'HP ProLiant', 1),
('Tablet', 'Samsung Galaxy Tab', 2),
('Monitor', 'LG UltraWide', 3)
GO

INSERT INTO Reparaciones(EquipoID, Estado) VALUES
(1, 'A'),
(2, 'B'),
(3, 'c')
GO

INSERT INTO Asignaciones(ReparacionID, TecnicoID) VALUES
(1, 1 ),
(2, 1),
(3, 2)
GO

INSERT INTO DetallesReparaciones (ReparacionID, Descripcion) VALUES
(1, 'Reemplazar la tarjeta madre en la laptop'),
(2, 'Reparación de píxeles muertos en el monitor'),
(3, 'Configuracion de software')
GO

CREATE PROCEDURE validarusuario
@correo VARCHAR(50),
@clave VARCHAR (50)
as
	begin
		select correo, clave from USUARIOCE where correo = @correo and clave=@clave
	end
GO

CREATE PROCEDURE CONSULTAR_USUARIOS
AS
	BEGIN
		SELECT * FROM Usuarios
	END
GO

CREATE PROCEDURE CONSULTAR_USUARIOS_ID
@ID INT
AS
	BEGIN
		SELECT * FROM Usuarios WHERE UsuarioID = @ID
	END
GO

CREATE PROCEDURE BORRAR_USUARIOS_ID
@ID INT
AS
	BEGIN
		DELETE Usuarios WHERE UsuarioID = @ID
	END
GO

CREATE PROCEDURE INSERTAR_USUARIO
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		INSERT INTO Usuarios(Nombre, CorreoElectronico, Telefono) VALUES (@NOMBRE, @CORREO, @TELEFONO)
	END
GO

CREATE PROCEDURE ACTUALIZAR_USUARIO_ID
@ID INT,
@NOMBRE VARCHAR(50),
@CORREO VARCHAR(50),
@TELEFONO VARCHAR(15)
AS
	BEGIN
		UPDATE Usuarios SET Nombre = @NOMBRE, CorreoElectronico = @CORREO, Telefono = @TELEFONO WHERE UsuarioID = @ID
	END
GO

CREATE PROCEDURE CONSULTAR_TECNICOS
AS
	BEGIN
		SELECT * FROM Tecnicos
	END
GO

CREATE PROCEDURE CONSULTAR_TECNICOS_ID
@ID INT
AS
	BEGIN
		SELECT * FROM Tecnicos WHERE TecnicoID = @ID
	END
GO

CREATE PROCEDURE BORRAR_TECNICOS_ID
@ID INT
AS
	BEGIN
		DELETE Tecnicos WHERE TecnicoID = @ID
	END
GO

CREATE PROCEDURE INSERTAR_TECNICO
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		INSERT INTO Tecnicos(Nombre, Especialidad) VALUES (@NOMBRE, @ESPECIALIDAD)
	END
GO

CREATE PROCEDURE ACTUALIZAR_TECNICO_ID
@ID INT,
@NOMBRE VARCHAR(50),
@ESPECIALIDAD VARCHAR(50)
AS
	BEGIN
		UPDATE Tecnicos SET Nombre = @NOMBRE, Especialidad = @ESPECIALIDAD WHERE TecnicoID = @ID
	END
GO

CREATE PROCEDURE CONSULTAR_EQUIPO
AS
	BEGIN
		SELECT * FROM Equipo
	END
GO

CREATE PROCEDURE CONSULTAR_EQUIPO_ID
@ID INT
AS
	BEGIN
		SELECT * FROM Equipo WHERE EquipoID = @ID
	END
GO

CREATE PROCEDURE BORRAR_EQUIPO_ID
@ID INT
AS
	BEGIN
		DELETE Equipo WHERE EquipoID = @ID
	END
GO

CREATE PROCEDURE INSERTAR_EQUIPO
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
	BEGIN
		INSERT INTO Equipo(TipoEquipo, Modelo, UsuarioID) VALUES (@TIPOEQUIPO, @MODELO, @USUARIOID)
	END
GO

CREATE PROCEDURE ACTUALIZAR_EQUIPO_ID
@ID INT,
@TIPOEQUIPO VARCHAR(50),
@MODELO VARCHAR(50),
@USUARIOID INT
AS
	BEGIN
		UPDATE Equipo SET TipoEquipo = @TIPOEQUIPO, Modelo = @MODELO, UsuarioID = @USUARIOID WHERE EquipoID = @ID
	END
GO

-----------------------PARTE NUEVA---------------------------

CREATE PROCEDURE CONSULTAR_REPARACIONES
AS
BEGIN
    SELECT  ReparacionesID, Equipo.TipoEquipo as Equipo, FechaSolicitud, Estado 
    FROM Reparaciones
    JOIN Equipo ON Equipo.EquipoID = Reparaciones.EquipoID
END
GO

CREATE PROCEDURE CONSULTAR_REPARACIONES_ID
@ID INT
AS
BEGIN
    SELECT ReparacionesID, Equipo.TipoEquipo as Equipo, FechaSolicitud, Estado 
    FROM Reparaciones
    JOIN Equipo ON Equipo.EquipoID = Reparaciones.EquipoID
    WHERE ReparacionesID = @ID
END
GO


CREATE PROCEDURE BORRAR_REPARACIONES_ID
@ID INT
AS
BEGIN
    DELETE FROM Reparaciones WHERE ReparacionesID = @ID
END
GO

CREATE PROCEDURE INSERTAR_REPARACION
@EQUIPOID INT,
@ESTADO CHAR
AS
BEGIN
    INSERT INTO Reparaciones(EquipoID, Estado, FechaSolicitud)
    VALUES (@EQUIPOID, @ESTADO, GETDATE())
END
GO


CREATE PROCEDURE ACTUALIZAR_REPARACION_ID
@ID INT,
@EQUIPOID INT,
@ESTADO CHAR
AS
BEGIN
    UPDATE Reparaciones
    SET EquipoID = @EQUIPOID, Estado = @ESTADO
    WHERE ReparacionesID = @ID
END
GO


CREATE PROCEDURE CONSULTAR_ASIGNACIONES
AS
BEGIN
    SELECT AsignacionID, Reparaciones.Estado as EstadoDeReparacion, Tecnicos.Nombre as Tecnico, FechaAsignacion 
    FROM Asignaciones
    JOIN Reparaciones ON Asignaciones.ReparacionID = Reparaciones.ReparacionesID
    JOIN Tecnicos ON Asignaciones.TecnicoID = Tecnicos.TecnicoID
END
GO


CREATE PROCEDURE CONSULTAR_ASIGNACIONES_ID
@ID INT
AS
BEGIN
    SELECT AsignacionID, Reparaciones.Estado as EstadoDeReparacion, Tecnicos.Nombre as Tecnico, FechaAsignacion
    FROM Asignaciones 
    JOIN Reparaciones ON Asignaciones.ReparacionID = Reparaciones.ReparacionesID
    JOIN Tecnicos ON Asignaciones.TecnicoID = Tecnicos.TecnicoID
    WHERE AsignacionID = @ID
END
GO

CREATE PROCEDURE BORRAR_ASIGNACIONES_ID
@ID INT
AS
BEGIN
    DELETE FROM Asignaciones WHERE AsignacionesID = @ID
END
GO

CREATE PROCEDURE INSERTAR_ASIGNACION
@REPARACIONID INT,
@TECNICOID INT
AS
BEGIN
    INSERT INTO Asignaciones(ReparacionID, TecnicoID, FechaAsignacion)
    VALUES (@REPARACIONID, @TECNICOID, GETDATE())
END
GO


CREATE PROCEDURE ACTUALIZAR_ASIGNACION_ID
@ID INT,
@REPARACIONID INT,
@TECNICOID INT
AS
BEGIN
    UPDATE Asignaciones
    SET ReparacionID = @REPARACIONID, TecnicoID = @TECNICOID
    WHERE AsignacionesID = @ID
END
GO

CREATE PROCEDURE CONSULTAR_DETALLESREPARACION
AS
BEGIN
    SELECT DetallesReparacionID, Reparaciones.ReparacionesID as Reparacion, Descripcion, FechaInicio, FechaFin
    FROM DetallesReparaciones 
    JOIN Reparaciones ON DetallesReparaciones.ReparacionID = Reparaciones.ReparacionesID
END
GO

CREATE PROCEDURE CONSULTAR_DETALLESREPARACION_ID
@ID INT
AS
BEGIN
    SELECT DetallesReparacionID, Reparaciones.ReparacionesID as Reparacion, Descripcion, FechaInicio, FechaFin 
    FROM DetallesReparaciones 
    JOIN Reparaciones ON DetallesReparaciones.ReparacionID = Reparaciones.ReparacionesID
    WHERE DetallesReparacionID = @ID
END
GO


CREATE PROCEDURE BORRAR_DETALLESREPARACION_ID
@ID INT
AS
BEGIN
    DELETE FROM DetallesReparaciones WHERE DetallesReparacionID = @ID
END
GO


CREATE PROCEDURE INSERTAR_DETALLESREPARACION
@REPARACIONID INT,
@DESCRIPCION VARCHAR(50)
AS
BEGIN
    INSERT INTO DetallesReparaciones(ReparacionID, Descripcion, FechaInicio)
    VALUES (@REPARACIONID, @DESCRIPCION, GETDATE())
END
GO

CREATE PROCEDURE ACTUALIZAR_DETALLESREPARACION_ID
@ID INT,
@REPARACIONID INT,
@DESCRIPCION VARCHAR(50),
@FECHAFIN DATE
AS
BEGIN
    UPDATE DetallesReparaciones
    SET ReparacionID = @REPARACIONID, Descripcion = @DESCRIPCION, FechaFin = @FECHAFIN
    WHERE DetallesReparacionID = @ID
END

SELECT Usuarios.Nombre, Usuarios.Telefono, Equipo.Modelo, Tecnicos.Nombre
from Usuarios
inner join Equipo on Usuarios.UsuarioID = Equipo.UsuarioID
inner join Reparaciones on Reparaciones.EquipoID = Equipo.EquipoID
inner join Asignaciones on Asignaciones.ReparacionID = Reparaciones.ReparacionesID
inner join Tecnicos on Tecnicos.TecnicoID = Asignaciones.TecnicoID
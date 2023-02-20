	CREATE DATABASE EMPRESA;
GO
USE EMPRESA;
drop table if exists Usuario ;
CREATE TABLE Usuario (
	Codigo			int PRIMARY KEY IDENTITY ,
	Usuari			varchar(10) Unique,
	Contrasena		varchar(20),
	FechaIngreso	datetime,
	CodigoArea		int
);
drop table if exists Area ;
CREATE TABLE Area (
	Codigo	int PRIMARY KEY IDENTITY ,
	Nombre	varchar(50)
);
ALTER TABLE Usuario
ADD FOREIGN KEY (CodigoArea) REFERENCES Area(Codigo);
---
drop proc if exists SP_Usuario_List
GO
CREATE PROC SP_Usuario_List
	
AS
BEGIN
	SELECT	U.*,
			A.Nombre
	FROM	Usuario U
	INNER JOIN Area A ON (U.CodigoArea = A.Codigo)
END
drop proc if exists SP_Usuario_Reg

GO
CREATE PROC SP_Usuario_Reg
	@Usuari			varchar(10),
	@Contrasena		varchar(20),
	@CodigoArea		int
AS
BEGIN
	insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) 
	values (@Usuari, @Contrasena, GETDATE(), @CodigoArea)
END
drop proc if exists SP_Area_list
GO;	
CREATE PROC SP_Area_list
AS
BEGIN
	SELECT * FROM Area
END
--
INSERT INTO AREA (NOMBRE) VALUES ('ALMACEN')
INSERT INTO AREA (NOMBRE) VALUES ('VENTAS')
INSERT INTO AREA (NOMBRE) VALUES ('COMPRAS')

insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) values ('Rgarcia', '123', '01/01/2013', 1)
insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) values ('Stello', '456', '01/01/2013', 1)
insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) values ('Jflores', '789', '03/02/2013', 1)
insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) values ('Cleon', '147', '03/02/2013', 2)
insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) values ('Ysilva', '258', '06/07/2013', 2)
insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) values ('Asalazar', '369', '06/07/2013', 3)
insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) values ('Cramirez', '963', '06/07/2013', 1)
insert into Usuario(Usuari, Contrasena, FechaIngreso, CodigoArea) values ('Jzapata', '852', '01/01/2013', 3)


--
-- Correr Manual Mente
DECLARE @colnameList varchar(200)
select @colnameList =  COALESCE(@colnameList + ',','') + mes
from  (select distinct DATENAME(MONTH, FechaIngreso) mes  from  Usuario) dt
DECLARE @SQLQuery NVARCHAR(MAX)
SET @SQLQuery = '
SELECT	Nombre , 
		'+@colnameList+'
FROM   (SELECT	A.Nombre Nombre, 
				DATENAME(MONTH, u.FechaIngreso) Mes,
				Usuari
		FROM  Usuario U
		INNER JOIN Area A ON U.CodigoArea = A.Codigo) AS tbl
PIVOT 
( count(Usuari)
FOR Mes IN ('+@colnameList+') ) as pvt'
EXEC(@SQLQuery)
 go;

 SELECT	Nombre , 
		Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Setiembre,Octubre,Noviembre,Diciembre
FROM   (SELECT	A.Nombre Nombre, 
				DATENAME(MONTH, u.FechaIngreso) Mes,
				Usuari
		FROM  Usuario U
		INNER JOIN Area A ON U.CodigoArea = A.Codigo) AS tbl
PIVOT 
( count(Usuari)
FOR Mes IN (Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Setiembre,Octubre,Noviembre,Diciembre) ) as pvt
go;



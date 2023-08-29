USE [CARRERAS]
GO
/****** Object:  Table [dbo].[T_PRODUCTOS]    Script Date: 08/06/2022 17:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ASIGNARTURAS](
	[id_asignatura] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	CONSTRAINT [PK__ASIGNATURAS] PRIMARY KEY CLUSTERED 
(
	[id_asignatura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [ASIGNATURAS] ON --PROBLEMA ACA!!
INSERT [dbo].[ASIGNARTURAS] ([id_asignatura], [nombre]) VALUES (1,'QUIMICA ORGANICA')
INSERT [dbo].[ASIGNARTURAS] ([id_asignatura], [nombre]) VALUES (2, 'FISICA')
SET IDENTITY_INSERT [dbo].[ASIGNATURAS] OFF
/****** Object:  Table [dbo].[T_PRESUPUESTOS]    Script Date: 08/06/2022 17:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CARRERAS](
	[id_carrera] [int] IDENTITY(1,1) NOT NULL,
	[nombre_titulo] [varchar](100) NOT NULL,
 CONSTRAINT [PK__CARRERAS] PRIMARY KEY CLUSTERED 
(
	[id_carrera] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CARRERAS] ON
INSERT [dbo].[CARRERAS] ([id_carrera], [nombre_titulo]) VALUES (2, 'INGENIERO QUIMICO')
INSERT [dbo].[CARRERAS] ([id_carrera], [nombre_titulo]) VALUES (3, 'LIC.FISICA')
INSERT [dbo].[CARRERAS] ([id_carrera], [nombre_titulo]) VALUES (4, 'LIC.COMPUTACION')
SET IDENTITY_INSERT [dbo].[CARRERAS] OFF
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_PRODUCTOS]    Script Date: 08/06/2022 17:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_ASIGNATURAS]
AS
BEGIN
	
	SELECT * from ASIGNARTURAS;
END
GO
/****** Object:  Table [dbo].[T_DETALLES_PRESUPUESTO]    Script Date: 08/06/2022 17:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLES_CARRERA](
	[id_carrera] [int] NOT NULL,
	[id_detalle] [int] NOT NULL,
	[id_asignatura] [int] NOT NULL,
	[anio_curso][varchar](50) NOT NULL,
	[cuatrimestre][varchar](50)
PRIMARY KEY CLUSTERED 
(
	[id_carrera] ASC,
	[id_detalle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DETALLES_CARRERA] ([id_carrera], [id_detalle], [id_asignatura], [anio_curso],[cuatrimestre]) VALUES (2, 0, 1,'SEGUNDO','PRIMERO')
INSERT [dbo].[DETALLES_CARRERA] ([id_carrera], [id_detalle], [id_asignatura], [anio_curso],[cuatrimestre]) VALUES (3, 1, 1,'PRIMERO','SEGUNDO')
/****** Object:  StoredProcedure [dbo].[SP_PROXIMO_ID]    Script Date: 08/06/2022 17:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PROXIMO_ID]
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(id_carrera)+1  FROM CARRERAS);
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 08/06/2022 17:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO] 
	@titulo varchar(200),
	@id_carrera int OUTPUT
AS
BEGIN
	INSERT INTO CARRERAS(nombre_titulo)
    VALUES (@titulo);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @id_carrera = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    /
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE] 
	@id_carrera int,
	@detalle int, 
	@id_asignatura int, 
	@anio varchar(100),
	@cuatrimestre varchar(100)
AS
BEGIN
	INSERT INTO DETALLES_CARRERA(id_carrera,id_detalle, id_asignatura,anio_curso,cuatrimestre)
    VALUES (@id_carrera, @detalle,@id_asignatura,@anio,@cuatrimestre);
  
END
GO
--claves foraneas
ALTER TABLE [dbo].[DETALLES_CARRERA]  WITH CHECK ADD  CONSTRAINT [fk_carrera] FOREIGN KEY([id_carrera])
REFERENCES [dbo].[CARRERAS] ([id_carrera])
GO
ALTER TABLE [dbo].[DETALLES_CARRERA] CHECK CONSTRAINT [fk_carrera]
GO

ALTER TABLE [dbo].[DETALLES_CARRERA]  WITH CHECK ADD  CONSTRAINT [fk_asignatura] FOREIGN KEY([id_asignatura])
REFERENCES [dbo].[ASIGNATURAS] ([id_asignatura])
GO
ALTER TABLE [dbo].[DETALLES_CARRERA] CHECK CONSTRAINT [fk_asignatura]
GO

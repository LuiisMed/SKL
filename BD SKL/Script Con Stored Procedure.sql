USE [SKL]
GO
/****** Object:  Schema [SKL]    Script Date: 12/02/2025 10:24:31 a. m. ******/
CREATE SCHEMA [SKL]
GO
/****** Object:  Table [SKL].[Aspects]    Script Date: 12/02/2025 10:24:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Aspects](
	[id_aspect] [int] IDENTITY(1,1) NOT NULL,
	[aspect_name] [varchar](100) NOT NULL,
 CONSTRAINT [skl_aspects_id_aspect_primary] PRIMARY KEY CLUSTERED 
(
	[id_aspect] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Departments]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Departments](
	[id_department] [int] IDENTITY(1,1) NOT NULL,
	[department_name] [varchar](100) NOT NULL,
 CONSTRAINT [skl_departments_id_department_primary] PRIMARY KEY CLUSTERED 
(
	[id_department] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Eval]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Eval](
	[id_eval] [int] IDENTITY(1,1) NOT NULL,
	[emp_no] [int] NOT NULL,
	[id_fase] [int] NOT NULL,
	[eval] [decimal](8, 2) NOT NULL,
	[comment] [varchar](255) NULL,
	[eval_file] [varchar](255) NOT NULL,
 CONSTRAINT [skl_eval_id_eval_primary] PRIMARY KEY CLUSTERED 
(
	[id_eval] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Evidences]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Evidences](
	[id_evidences] [int] IDENTITY(1,1) NOT NULL,
	[evidences] [varchar](255) NOT NULL,
	[id_task] [int] NULL,
 CONSTRAINT [skl_evidences_id_evidences_primary] PRIMARY KEY CLUSTERED 
(
	[id_evidences] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Fase]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Fase](
	[id_fase] [int] IDENTITY(1,1) NOT NULL,
	[fase_name] [varchar](100) NOT NULL,
	[fase_startdate] [datetime] NOT NULL,
	[fase_enddate] [datetime] NOT NULL,
	[Is_Active] [bit] NOT NULL,
 CONSTRAINT [skl_fase_id_fase_primary] PRIMARY KEY CLUSTERED 
(
	[id_fase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Notifications]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Notifications](
	[id_notification] [int] IDENTITY(1,1) NOT NULL,
	[id_usr] [int] NULL,
	[id_task] [int] NULL,
	[message] [varchar](250) NOT NULL,
	[isReaded] [bit] NOT NULL,
	[EviReaded] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Positions]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Positions](
	[id_position] [int] IDENTITY(1,1) NOT NULL,
	[position_name] [varchar](100) NOT NULL,
 CONSTRAINT [skl_positions_id_position_primary] PRIMARY KEY CLUSTERED 
(
	[id_position] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Shift]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Shift](
	[id_shift] [int] IDENTITY(1,1) NOT NULL,
	[shift_name] [varchar](100) NOT NULL,
	[start] [varchar](100) NOT NULL,
	[end] [varchar](100) NOT NULL,
 CONSTRAINT [skl_shift_id_shift_primary] PRIMARY KEY CLUSTERED 
(
	[id_shift] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Tasks]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Tasks](
	[id_task] [int] IDENTITY(1,1) NOT NULL,
	[id_usr] [int] NOT NULL,
	[id_fase] [int] NOT NULL,
	[accion] [varchar](255) NOT NULL,
	[id_aspect] [int] NOT NULL,
	[isCompleted] [bit] NULL,
	[task_start] [datetime] NULL,
	[task_end] [datetime] NULL,
 CONSTRAINT [skl_tasks_id_task_primary] PRIMARY KEY CLUSTERED 
(
	[id_task] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[UserType]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[UserType](
	[id_usr_type] [int] IDENTITY(1,1) NOT NULL,
	[usr_type_name] [varchar](100) NOT NULL,
 CONSTRAINT [skl_usertype_id_usr_type_primary] PRIMARY KEY CLUSTERED 
(
	[id_usr_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SKL].[Usuarios]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SKL].[Usuarios](
	[id_usr] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[usr_name] [varchar](100) NOT NULL,
	[usr_pass] [varchar](100) NOT NULL,
	[id_usr_type] [int] NOT NULL,
	[id_usr_position] [int] NOT NULL,
	[id_shift] [int] NOT NULL,
	[id_usr_department] [int] NOT NULL,
	[emp_no] [int] NOT NULL,
	[date] [date] NOT NULL,
	[usr_img] [varchar](255) NULL,
	[Email] [varchar](250) NULL,
 CONSTRAINT [skl_usuarios_id_usr_primary] PRIMARY KEY CLUSTERED 
(
	[id_usr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [SKL].[Evidences]  WITH CHECK ADD  CONSTRAINT [FK_Evidences_Tasks1] FOREIGN KEY([id_task])
REFERENCES [SKL].[Tasks] ([id_task])
ON DELETE CASCADE
GO
ALTER TABLE [SKL].[Evidences] CHECK CONSTRAINT [FK_Evidences_Tasks1]
GO
ALTER TABLE [SKL].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Tasks1] FOREIGN KEY([id_task])
REFERENCES [SKL].[Tasks] ([id_task])
ON DELETE CASCADE
GO
ALTER TABLE [SKL].[Notifications] CHECK CONSTRAINT [FK_Notifications_Tasks1]
GO
ALTER TABLE [SKL].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Usuarios] FOREIGN KEY([id_usr])
REFERENCES [SKL].[Usuarios] ([id_usr])
ON DELETE CASCADE
GO
ALTER TABLE [SKL].[Notifications] CHECK CONSTRAINT [FK_Notifications_Usuarios]
GO
ALTER TABLE [SKL].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Fase] FOREIGN KEY([id_fase])
REFERENCES [SKL].[Fase] ([id_fase])
GO
ALTER TABLE [SKL].[Tasks] CHECK CONSTRAINT [FK_Tasks_Fase]
GO
ALTER TABLE [SKL].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Usuarios] FOREIGN KEY([id_usr])
REFERENCES [SKL].[Usuarios] ([id_usr])
GO
ALTER TABLE [SKL].[Tasks] CHECK CONSTRAINT [FK_Tasks_Usuarios]
GO
ALTER TABLE [SKL].[Tasks]  WITH CHECK ADD  CONSTRAINT [skl_tasks_id_aspect_foreign] FOREIGN KEY([id_aspect])
REFERENCES [SKL].[Aspects] ([id_aspect])
GO
ALTER TABLE [SKL].[Tasks] CHECK CONSTRAINT [skl_tasks_id_aspect_foreign]
GO
ALTER TABLE [SKL].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Positions] FOREIGN KEY([id_usr_position])
REFERENCES [SKL].[Positions] ([id_position])
GO
ALTER TABLE [SKL].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Positions]
GO
ALTER TABLE [SKL].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Shift] FOREIGN KEY([id_shift])
REFERENCES [SKL].[Shift] ([id_shift])
GO
ALTER TABLE [SKL].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Shift]
GO
ALTER TABLE [SKL].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_UserType] FOREIGN KEY([id_usr_type])
REFERENCES [SKL].[UserType] ([id_usr_type])
GO
ALTER TABLE [SKL].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_UserType]
GO
ALTER TABLE [SKL].[Usuarios]  WITH CHECK ADD  CONSTRAINT [skl_usuarios_id_usr_department_foreign] FOREIGN KEY([id_usr_department])
REFERENCES [SKL].[Departments] ([id_department])
GO
ALTER TABLE [SKL].[Usuarios] CHECK CONSTRAINT [skl_usuarios_id_usr_department_foreign]
GO
/****** Object:  StoredProcedure [SKL].[SKL_FUNCTIONS]    Script Date: 12/02/2025 10:24:32 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [SKL].[SKL_FUNCTIONS]
    @Option VARCHAR(1000) = NULL, 
    @Param1 VARCHAR(1000) = NULL, 
    @Param2 VARCHAR(1000) = NULL,
    @Param3 VARCHAR(1000) = NULL,
    @Param4 VARCHAR(1000) = NULL,
    @Param5 VARCHAR(1000) = NULL,
    @Param6 VARCHAR(1000) = NULL,
    @Param7 VARCHAR(1000) = NULL,
    @Param8 VARCHAR(1000) = NULL,
    @Param9 VARCHAR(1000) = NULL,
    @Param10 VARCHAR(1000) = NULL,
    @Param11 VARCHAR(1000) = NULL,
    @Param12 VARCHAR(1000) = NULL,
    @Param13 VARCHAR(1000) = NULL,
    @Param14 VARCHAR(1000) = NULL,
    @Param15 VARCHAR(1000) = NULL,
    @Param16 VARCHAR(1000) = NULL,
    @Param17 VARCHAR(1000) = NULL,
    @Param18 VARCHAR(1000) = NULL,
	@Param19 INT = NULL
AS 
BEGIN
	SET NOCOUNT ON;
	----------DEPARTAMENTO----------
	--
	IF @Option = 'INS_DEPARTMENT'
		BEGIN
			INSERT INTO [SKL].[Departments]
			([department_name])
			VALUES	
			(@Param1) 
		END	
	--
	IF @Option = 'UPD_DEPARTMENT'
		BEGIN
			UPDATE [SKL].[Departments]
			SET [department_name] = @Param2
			WHERE [id_department] = @Param1
		END
	--
	IF @Option = 'DEL_DEPARTMENT'
		BEGIN
			DELETE
			FROM [SKL].[Departments]
			WHERE [id_department] = @Param1
		END	
	--
	IF @Option = 'GET_DEPARTMENT'
		BEGIN
			SELECT * FROM [SKL].[Departments]
		END		
	--
	--
	IF @Option = 'GET_ONE_DEPARTMENT'
		BEGIN
			SELECT *
			FROM [SKL].[Departments]
			WHERE [id_department] = @Param1
		END	
	--
		-----------USUARIOS------------
	--
	IF @Option = 'GET_USUARIOS'
	BEGIN
		SELECT 
			A.id_usr, 
			A.[name], 
			A.usr_name, 
			A.usr_pass, 
			A.id_usr_type, 
			B.usr_type_name,
			A.id_usr_position,
			C.position_name,
			A.id_shift,
			D.shift_name,
			A.id_usr_department,
			E.department_name,
			A.emp_no,
			A.usr_img,
			A.Email
		FROM SKL.[Usuarios] A WITH(NOLOCK)
			INNER JOIN SKL.UserType B WITH(NOLOCK) ON A.id_usr_type = B.id_usr_type
			INNER JOIN SKL.Positions C WITH(NOLOCK) ON A.id_usr_position = C.id_position
			INNER JOIN SKL.[Shift] D WITH(NOLOCK) ON A.id_shift = D.id_shift
			INNER JOIN SKL.Departments E WITH(NOLOCK) ON A.id_usr_department = E.id_department
		END
	--
	IF @Option = 'GET_USUARIO'
	BEGIN
		SELECT *
		FROM SKL.[Usuarios]
		WHERE id_usr = @Param1
	END
	--
	IF @Option = 'GET_CREDENTIALS'
	BEGIN
		SELECT 
			A.id_usr, a.[name], a.usr_name, a.usr_pass, a.id_usr_type, B.usr_type_name,a.usr_img
		FROM SKL.[Usuarios] A WITH(NOLOCK)
			INNER JOIN SKL.UserType B WITH(NOLOCK) ON A.id_usr_type = B.id_usr_type
	END
	--
	IF @Option = 'INS_USUARIOS'
		BEGIN
			INSERT INTO [SKL].[Usuarios]
			([name], [usr_name], [usr_pass], [id_usr_type],[id_usr_position],[id_shift],[id_usr_department],[emp_no],[date],[usr_img], [Email])
			VALUES	
			(@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8, GETDATE(), @Param9, @Param10) 
		END	
	--
	IF @Option = 'UPD_USUARIOS'
		BEGIN
			UPDATE [SKL].[Usuarios]
			SET [name] = @Param2,
			[usr_name] = @Param3,
			[usr_pass] = @Param4,
			[id_usr_type] = @Param5,
			[id_usr_position] = @Param6,
			[id_shift] = @Param7,
			[id_usr_department] = @Param8,
			[emp_no] = @Param9,
			[date] = GETDATE(),
			[usr_img] = @Param10,
			[Email] = @Param11
			WHERE [id_usr] = @Param1
		END
	--
	--
	IF @Option = 'DEL_USUARIOS'
		BEGIN
			DELETE 
			FROM [SKL].[Usuarios]
			WHERE [id_usr] = @Param1
		END	
	--
	-------TIPO DE USUARIOS-------
	--
	IF @Option = 'INS_USERTYPE'
		BEGIN
			INSERT INTO [SKL].UserType
			([usr_type_name])
			VALUES	
			(@Param1) 
		END	
	--
	IF @Option = 'UPD_USERTYPE'
		BEGIN
			UPDATE [SKL].[UserType]
			SET [usr_type_name] = @Param2
			WHERE [id_usr_type] = @Param1
		END
	--
	IF @Option = 'DEL_USERTYPE'
		BEGIN
			DELETE
			FROM [SKL].[UserType]
			WHERE [id_usr_type] = @Param1
		END	
	--
	IF @Option = 'GET_USERTYPE'
		BEGIN
			SELECT * FROM [SKL].[UserType]
		END		
	--
	--
	IF @Option = 'GET_ONE_USERTYPE'
	BEGIN
		SELECT *
		FROM SKL.[UserType]
		WHERE [id_usr_type] = @Param1
	END
	--
	------------TURNOS------------
	--
	IF @Option = 'INS_SHIFTS'
	BEGIN
		INSERT INTO [SKL].[Shift]
		([shift_name], [start], [end])
		VALUES	
		(@Param1, @Param2, @Param3) 
	END	
	--
	IF @Option = 'UPD_SHIFTS'
		BEGIN
			UPDATE [SKL].[Shift]
			SET [shift_name] = @Param2,
			[start] = @Param3,
			[end] = @Param4
			WHERE [id_shift] = @Param1
		END
	--
	IF @Option = 'DEL_SHIFTS'
		BEGIN
			DELETE
			FROM [SKL].[Shift]
			WHERE [id_shift] = @Param1
		END	
	--
	IF @Option = 'GET_SHIFTS'
		BEGIN
			SELECT * FROM [SKL].[Shift]
		END	
	--
	--
	IF @Option = 'GET_ONE_SHIFT'
	BEGIN
		SELECT *
		FROM SKL.[Shift]
		WHERE [id_shift] = @Param1
	END
	--
	-----------POSITIONS----------
	--
	IF @Option = 'INS_POSITION'
		BEGIN
			INSERT INTO [SKL].[Positions]
			([position_name])
			VALUES	
			(@Param1) 
		END	
	--
	IF @Option = 'UPD_POSITION'
		BEGIN
			UPDATE [SKL].[Positions]
			SET [position_name] = @Param2
			WHERE [id_position] = @Param1
		END
	--
	IF @Option = 'DEL_POSITION'
		BEGIN
			DELETE
			FROM [SKL].[Positions]
			WHERE [id_position] = @Param1
		END	
	--
	IF @Option = 'GET_POSITION'
		BEGIN
			SELECT * FROM [SKL].[Positions]
		END	
	--
	--
	IF @Option = 'GET_ONE_POSITION'
	BEGIN
		SELECT *
		FROM SKL.[Positions]
		WHERE [id_position] = @Param1
	END
	--
	-----------ASPECTS------------
	--
		IF @Option = 'INS_ASPECT'
		BEGIN
			INSERT INTO [SKL].[Aspects]
			([aspect_name])
			VALUES	
			(@Param1) 
		END	
	--
	IF @Option = 'UPD_ASPECT'
		BEGIN
			UPDATE [SKL].[Aspects]
			SET aspect_name = @Param2
			WHERE id_aspect = @Param1
		END
	--
	IF @Option = 'DEL_ASPECT'
		BEGIN
			DELETE
			FROM [SKL].[Aspects]
			WHERE id_aspect = @Param1
		END	
	--
	IF @Option = 'GET_ASPECT'
		BEGIN
			SELECT * FROM [SKL].[Aspects]
		END	
	--
	--
	IF @Option = 'GET_ONE_ASPECT'
	BEGIN
		SELECT *
		FROM SKL.[Aspects]
		WHERE id_aspect = @Param1
	END
	--
	-----------FASES------------
	---CAMBIAR TIPO DE DATO FASES
	--
		IF @Option = 'INS_FASE'
		BEGIN
			INSERT INTO [SKL].[Fase]
			([fase_name], [fase_startdate], [fase_enddate], [Is_Active])
			VALUES	
			(@Param1, @Param2, @Param3, @Param4) 
		END	
	--
	IF @Option = 'UPD_FASE'
		BEGIN
			UPDATE [SKL].[Fase]
			SET [fase_name] = @Param2,
			[fase_startdate] = @Param3,
			[fase_enddate] = @Param4,
			[Is_Active] = @Param5
			WHERE [id_fase] = @Param1
		END
	--
	IF @Option = 'DEL_FASE'
		BEGIN
			DELETE
			FROM [SKL].[Fase]
			WHERE [id_fase] = @Param1
		END	
	--
	IF @Option = 'GET_FASE'
		BEGIN
			SELECT * FROM [SKL].[Fase]
		END	
	--
	--
	IF @Option = 'GET_ONE_FASE'
	BEGIN
		SELECT *
		FROM SKL.[Fase]
		WHERE [id_fase] = @Param1
	END
	--
		-----------Tasks------------
	IF @Option = 'INS_TASK'
		BEGIN
		    INSERT INTO [SKL].[Tasks]
		    ([id_usr], [id_fase], [accion], [id_aspect], [isCompleted], [task_start], [task_end])
		    VALUES (@Param2, @Param3, @Param4, @Param5, @Param6, GETDATE(), @Param8);
		
		    SELECT SCOPE_IDENTITY() AS NewTaskId;
		END
	--
	IF @Option = 'UPD_TASK'
		BEGIN
			UPDATE [SKL].[Tasks]
			SET 
			[accion] = @Param2,
			[id_aspect] = @Param3,
			[isCompleted] = @Param4,
			[task_start] = GETDATE(),
			[task_end] = @Param6
			WHERE [id_task] = @Param1
		END
	--
		--
	IF @Option = 'UPD_TASK_COMPLETED'
		BEGIN
			UPDATE [SKL].[Tasks]
			SET 
			[accion] = @Param2,
			[id_aspect] = @Param3,
			[isCompleted] = @Param4,
			[task_start] = @Param5,
			[task_end] = @Param6
			WHERE [id_task] = @Param1
		END
	--
	IF @Option = 'DEL_TASK'
		BEGIN
			DELETE
			FROM [SKL].[Tasks]
			WHERE [id_task] = @Param1
		END	
	--
	IF @Option = 'GET_TASK'
		BEGIN
			SELECT * FROM [SKL].[Tasks]
		END	
	--

	IF @Option = 'GET_TASK_PER_USER_FASE'
		BEGIN
			SELECT
				A.[id_task],
				A.[id_usr],
				B.[name],
				A.[id_fase],
				C.[fase_name],
				A.[accion],
				A.[id_aspect],
				D.[aspect_name],
				A.[isCompleted],
				A.[task_start],
				A.[task_end],
				E.id_evidences,
				E.evidences
			FROM SKL.[Tasks] A WITH(NOLOCK)
				INNER JOIN SKL.Usuarios B WITH(NOLOCK) ON A.id_usr = B.id_usr
				INNER JOIN SKL.Fase C WITH(NOLOCK) ON A.id_fase = C.id_fase
				INNER JOIN SKL.Aspects D WITH(NOLOCK) ON A.id_aspect = D.id_aspect
				LEFT JOIN SKL.Evidences E WITH(NOLOCK) ON A.id_task = E.id_task
			WHERE A.[id_usr] = @Param1 AND A.id_fase = @Param2

		END
	--
	--
		IF @Option = 'GET_TASK_PER_USER_FASE'
		BEGIN
			SELECT
				A.[id_task],
				A.[id_usr],
				B.[name],
				A.[id_fase],
				C.[fase_name],
				A.[accion],
				A.[id_aspect],
				D.[aspect_name],
				A.[isCompleted],
				A.[task_start],
				A.[task_end],
				E.id_evidences,
				E.evidences
			FROM SKL.[Tasks] A WITH(NOLOCK)
				INNER JOIN SKL.Usuarios B WITH(NOLOCK) ON A.id_usr = B.id_usr
				INNER JOIN SKL.Fase C WITH(NOLOCK) ON A.id_fase = C.id_fase
				INNER JOIN SKL.Aspects D WITH(NOLOCK) ON A.id_aspect = D.id_aspect
				LEFT JOIN SKL.Evidences E WITH(NOLOCK) ON A.id_task = E.id_task
			WHERE A.[id_usr] = @Param1 AND A.id_fase = @Param2
		END
	--
	IF @Option = 'GET_ONE_TASK'
	BEGIN
		SELECT *
		FROM SKL.[Tasks]
		WHERE [id_task] = @Param1
	END
	--
	--
	IF @Option = 'GET_TASKS_COMPLETED'
	BEGIN
		SELECT
			A.[id_task],
			B.[name],
			A.id_fase,
			C.[fase_name],
			C.[Is_Active],
			A.[accion],
			D.[aspect_name],
			A.[isCompleted]
		FROM SKL.[Tasks] A WITH(NOLOCK)
			INNER JOIN SKL.Usuarios B WITH(NOLOCK) ON A.id_usr = B.id_usr
			INNER JOIN SKL.Fase C WITH(NOLOCK) ON A.id_fase = C.id_fase
			INNER JOIN SKL.Aspects D WITH(NOLOCK) ON A.id_aspect = D.id_aspect
			LEFT JOIN SKL.Evidences E WITH(NOLOCK) ON A.id_task = E.id_task
	END
	--
	--
	IF @Option = 'GET_TASKS_COMPLETED_PER_PHASE'
	BEGIN
		SELECT 
			A.[id_task], 
			A.id_usr,
			B.[name] , 
			B.id_usr_department, 
			F.department_name,
			A.id_fase, 
			C.[fase_name], 
			C.[Is_Active], 
			A.[accion], 
			D.[aspect_name], 
			A.[isCompleted],
			e.id_evidences,
			e.evidences
		FROM 
			SKL.[Tasks] A WITH(NOLOCK)
			INNER JOIN 
			SKL.Usuarios B WITH(NOLOCK) ON A.id_usr = B.id_usr
			INNER JOIN 
			SKL.Fase C WITH(NOLOCK) ON A.id_fase = C.id_fase
			INNER JOIN 
			SKL.Aspects D WITH(NOLOCK) ON A.id_aspect = D.id_aspect
			LEFT JOIN 
			SKL.Evidences E WITH(NOLOCK) ON A.id_task = E.id_task
			LEFT JOIN 
			SKL.Departments F WITH(NOLOCK) ON B.id_usr_department = F.id_department
		WHERE 
			A.[id_fase] = @Param1
	END
	--
		IF @Option = 'GET_TASK_PER_FASE_DEPT'
		BEGIN
			SELECT
				A.[id_task],
				A.[id_usr],
				B.[name],
				B.id_usr_department, 
				F.department_name,
				A.[id_fase],
				C.[fase_name],
				A.[accion],
				A.[id_aspect],
				D.[aspect_name],
				A.[isCompleted],
				A.[task_start],
				A.[task_end],
				E.id_evidences,
				E.evidences
			FROM SKL.[Tasks] A WITH(NOLOCK)
				INNER JOIN SKL.Usuarios B WITH(NOLOCK) ON A.id_usr = B.id_usr
				INNER JOIN SKL.Fase C WITH(NOLOCK) ON A.id_fase = C.id_fase
				INNER JOIN SKL.Aspects D WITH(NOLOCK) ON A.id_aspect = D.id_aspect
				LEFT JOIN SKL.Evidences E WITH(NOLOCK) ON A.id_task = E.id_task
				LEFT JOIN SKL.Departments F WITH(NOLOCK) ON B.id_usr_department = F.id_department
			WHERE A.[id_fase] = @Param1 AND [id_department] = @Param2
		END
	--
	--
			-----------Eval------------
	IF @Option = 'INS_EVAL'
		BEGIN
			INSERT INTO [SKL].[Eval]
			([emp_no], [id_fase], [eval], [comment], [eval_file])
			VALUES	
			(@Param1, @Param2, @Param3, @Param4, @Param5) 
		END	
	--
	IF @Option = 'UPD_EVAL'
		BEGIN
			UPDATE [SKL].[Eval]
			SET [emp_no] = @Param2,
			[id_fase] = @Param3,
			[eval] = @Param4,
			[comment] = @Param5,
			[eval_file] = @Param6
			WHERE [id_eval] = @Param1
		END
	--
	IF @Option = 'DEL_EVAL'
		BEGIN
			DELETE
			FROM [SKL].[Eval]
			WHERE [id_eval] = @Param1
		END	
	--
	IF @Option = 'GET_EVAL'
		BEGIN
			SELECT * FROM [SKL].[Eval]
		END	
	--
	IF @Option = 'GET_ONE_EVAL'
	BEGIN
		SELECT *
		FROM SKL.[Eval]
		WHERE [id_eval] = @Param1
	END
	--
	IF @Option = 'GET_EVAL_PER_USER'
	BEGIN
		SELECT *
		FROM SKL.[Eval]
		WHERE [emp_no] = @Param1 AND [id_fase] = @Param2
	END
				-----------Evidences------------
	IF @Option = 'INS_EVIDENCES'
		BEGIN
			INSERT INTO [SKL].[Evidences]
			([evidences], [id_task])
			VALUES	
			(@Param1, @Param2) 
		END	
	--
	IF @Option = 'UPD_EVIDENCES'
		BEGIN
			UPDATE [SKL].[Evidences]
			SET [evidences] = @Param2,
			[id_task] = @Param3
			WHERE [id_evidences] = @Param1
		END
	--
	IF @Option = 'DEL_EVIDENCES'
		BEGIN
			DELETE
			FROM [SKL].[Evidences]
			WHERE [id_evidences] = @Param1
		END	
	--
	IF @Option = 'GET_EVIDENCES'
		BEGIN
			SELECT * FROM [SKL].[Evidences]
		END	
	--
	IF @Option = 'GET_ONE_EVIDENCE'
		BEGIN
			SELECT * FROM [SKL].[Evidences]
			WHERE [id_evidences] = @Param1
		END	
	--
	IF @Option = 'GET_TASK_EVIDENCE'
	BEGIN
		SELECT id_task FROM SKL.Tasks
		WHERE [id_task] = @Param1
	END
	--
	IF @Option = 'GET_TASK_USER_FASE_EVI'
		BEGIN
			SELECT
				A.[id_task],
				A.[id_usr],
				B.[name],
				A.[id_fase],
				C.[fase_name],
				A.[accion],
				A.[id_aspect],
				D.[aspect_name],
				A.[isCompleted],
				A.[task_start],
				A.[task_end],
				E.id_evidences,
				E.evidences
			FROM SKL.[Tasks] A WITH(NOLOCK)
				INNER JOIN SKL.Usuarios B WITH(NOLOCK) ON A.id_usr = B.id_usr
				INNER JOIN SKL.Fase C WITH(NOLOCK) ON A.id_fase = C.id_fase
				INNER JOIN SKL.Aspects D WITH(NOLOCK) ON A.id_aspect = D.id_aspect
				LEFT JOIN SKL.Evidences E WITH(NOLOCK) ON A.id_task = E.id_task
			WHERE A.[id_usr] = @Param1 AND A.id_fase = @Param2
		END
	--
	IF @Option = 'GET_TASK_OVERDUE'
		BEGIN
			SELECT
				A.[id_task],
				A.[id_usr],
				B.[name],
				B.[Email],
				A.[id_fase],
				C.[fase_name],
				A.[accion],
				A.[isCompleted],
				A.[task_start],
				A.[task_end],
				E.[id_evidences],
				E.[evidences],
				CASE 
					WHEN A.[task_end] >= CAST(GETDATE() AS DATE) 
						 AND A.[task_end] < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
						THEN 0
					WHEN A.[task_end] >= DATEADD(DAY, 1, CAST(GETDATE() AS DATE)) 
						 AND A.[task_end] < DATEADD(DAY, 2, CAST(GETDATE() AS DATE))
						THEN 1
					WHEN A.[task_end] >= DATEADD(DAY, 2, CAST(GETDATE() AS DATE)) 
						 AND A.[task_end] < DATEADD(DAY, 3, CAST(GETDATE() AS DATE))
						THEN 2
					WHEN A.[task_end] >= DATEADD(DAY, 3, CAST(GETDATE() AS DATE)) 
						 AND A.[task_end] < DATEADD(DAY, 4, CAST(GETDATE() AS DATE))
						THEN 3
					ELSE 'Sin alerta'  
				END AS DiasRestantes
			FROM SKL.[Tasks] A WITH (NOLOCK)
				INNER JOIN SKL.Usuarios B WITH (NOLOCK) ON A.id_usr = B.id_usr
				INNER JOIN SKL.Fase C WITH (NOLOCK) ON A.id_fase = C.id_fase
				INNER JOIN SKL.Aspects D WITH (NOLOCK) ON A.id_aspect = D.id_aspect
				LEFT JOIN SKL.Evidences E WITH (NOLOCK) ON A.id_task = E.id_task
			WHERE A.[isCompleted] = 0  
				AND E.[id_evidences] IS NULL  
				AND A.[task_end] < DATEADD(DAY, 4, CAST(GETDATE() AS DATE))
			ORDER BY A.[task_end];

		END
	-----------Notificacions------------
	IF @Option = 'INS_NOTIFICATION'
		BEGIN
			INSERT INTO [SKL].[Notifications]
			([id_task], [id_usr], [isReaded], [message], [EviReaded])
			VALUES	
			(@Param1, @Param2, @Param3, @Param4, @Param5) 
		END	
	--
	IF @Option = 'UPD_NOTIFICATION'
		BEGIN
			UPDATE [SKL].[Notifications]
			SET [isReaded] = @Param2
			WHERE [id_notification] = @Param1
		END
	--
	IF @Option = 'UPD_ADMIN_NOTIFICATION'
		BEGIN
			UPDATE [SKL].[Notifications]
			SET [EviReaded] = @Param2
			WHERE [id_notification] = @Param1
		END
	--!!!!!!!EN LA PARTE DE ELIMINAR LA NOTIFICACION, ESTABLECER UN JOB PARA BORRAR LAS NOTIFICACIONES DESPUES DE UN AÑO O SEIS MESES PARA NO CARGAR LA TABLA!!!!!!
	--IF @Option = 'DEL_NOTIFICATION'
	--	BEGIN
	--		DELETE
	--		FROM [SKL].[Evidences]
	--		WHERE [id_evidences] = @Param1
	--	END	
	--
	IF @Option = 'GET_USER_NOTIFICATION'
		BEGIN
			SELECT
				A.[id_notification],
				A.[id_task],
				A.[id_usr],
				A.[isReaded],
				A.[message],
				F.id_fase,
				F.fase_name
			FROM SKL.[Notifications] A WITH(NOLOCK)
				INNER JOIN SKL.Tasks B WITH(NOLOCK) ON A.[id_task] = B.[id_task]
				LEFT JOIN SKL.Fase F WITH(NOLOCK) ON b.id_fase = F.id_fase
			WHERE A.[id_usr] = @Param1
		END	
	--
	IF @Option = 'GET_ADMIN_NOTIFICATION'
		BEGIN
			SELECT
				A.[id_notification],
				A.[id_task],
				A.[id_usr],
				C.[emp_no],
				C.[name],
				C.id_usr_department,
				A.[isReaded],
				A.[message],
				F.[id_fase],
				F.[fase_name],
				A.[EviReaded],
				E.[id_evidences],
				E.[evidences]
			FROM SKL.[Notifications] A WITH(NOLOCK)
				INNER JOIN SKL.Tasks B WITH(NOLOCK) ON A.[id_task] = B.[id_task]
				INNER JOIN SKL.Usuarios C WITH(NOLOCK) ON A.id_usr = C.id_usr
				LEFT JOIN SKL.Fase F WITH(NOLOCK) ON b.id_fase = F.id_fase
				LEFT JOIN SKL.Evidences E WITH(NOLOCK) ON A.id_task = E.id_task
			WHERE evidences IS NOT NULL
		END	

END
GO

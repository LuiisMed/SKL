USE [SKL]
GO

CREATE SCHEMA [SKL]
GO

CREATE TABLE [SKL].[Aspects](
    [id_aspect] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [aspect_name] [varchar](100) NOT NULL
)
GO

CREATE TABLE [SKL].[Departments](
    [id_department] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [department_name] [varchar](100) NOT NULL
)
GO

CREATE TABLE [SKL].[Eval](
    [id_eval] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [emp_no] [int] NOT NULL,
    [id_fase] [int] NOT NULL,
    [eval] [decimal](8, 2) NOT NULL,
    [comment] [varchar](255) NULL,
    [eval_file] [varchar](255) NOT NULL
)
GO

CREATE TABLE [SKL].[Evidences](
    [id_evidences] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [evidences] [varchar](255) NOT NULL,
    [id_task] [int] NULL
)
GO

CREATE TABLE [SKL].[Fase](
    [id_fase] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [fase_name] [varchar](100) NOT NULL,
    [fase_startdate] [datetime] NOT NULL,
    [fase_enddate] [datetime] NOT NULL,
    [Is_Active] [bit] NOT NULL
)
GO

CREATE TABLE [SKL].[Notifications](
    [id_notification] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [id_usr] [int] NULL,
    [id_task] [int] NULL,
    [message] [varchar](250) NOT NULL,
    [isReaded] [bit] NOT NULL,
    [EviReaded] [bit] NOT NULL
)
GO

CREATE TABLE [SKL].[Positions](
    [id_position] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [position_name] [varchar](100) NOT NULL
)
GO

CREATE TABLE [SKL].[Shift](
    [id_shift] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [shift_name] [varchar](100) NOT NULL,
    [start] [varchar](100) NOT NULL,
    [end] [varchar](100) NOT NULL
)
GO

CREATE TABLE [SKL].[Tasks](
    [id_task] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [id_usr] [int] NOT NULL,
    [id_fase] [int] NOT NULL,
    [accion] [varchar](255) NOT NULL,
    [id_aspect] [int] NOT NULL,
    [isCompleted] [bit] NULL,
    [task_start] [datetime] NULL,
    [task_end] [datetime] NULL
)
GO

CREATE TABLE [SKL].[UserType](
    [id_usr_type] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [usr_type_name] [varchar](100) NOT NULL
)
GO

CREATE TABLE [SKL].[Usuarios](
    [id_usr] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
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
    [Email] [varchar](250) NULL
)
GO

ALTER TABLE [SKL].[Evidences] ADD CONSTRAINT [FK_Evidences_Tasks] FOREIGN KEY([id_task]) REFERENCES [SKL].[Tasks] ([id_task]) ON DELETE CASCADE
GO

ALTER TABLE [SKL].[Notifications] ADD CONSTRAINT [FK_Notifications_Tasks] FOREIGN KEY([id_task]) REFERENCES [SKL].[Tasks] ([id_task]) ON DELETE CASCADE
GO

ALTER TABLE [SKL].[Notifications] ADD CONSTRAINT [FK_Notifications_Usuarios] FOREIGN KEY([id_usr]) REFERENCES [SKL].[Usuarios] ([id_usr]) ON DELETE CASCADE
GO

ALTER TABLE [SKL].[Tasks] ADD CONSTRAINT [FK_Tasks_Fase] FOREIGN KEY([id_fase]) REFERENCES [SKL].[Fase] ([id_fase])
GO

ALTER TABLE [SKL].[Tasks] ADD CONSTRAINT [FK_Tasks_Usuarios] FOREIGN KEY([id_usr]) REFERENCES [SKL].[Usuarios] ([id_usr])
GO

ALTER TABLE [SKL].[Tasks] ADD CONSTRAINT [FK_Tasks_Aspects] FOREIGN KEY([id_aspect]) REFERENCES [SKL].[Aspects] ([id_aspect])
GO

ALTER TABLE [SKL].[Usuarios] ADD CONSTRAINT [FK_Usuarios_Positions] FOREIGN KEY([id_usr_position]) REFERENCES [SKL].[Positions] ([id_position])
GO

ALTER TABLE [SKL].[Usuarios] ADD CONSTRAINT [FK_Usuarios_Shift] FOREIGN KEY([id_shift]) REFERENCES [SKL].[Shift] ([id_shift])
GO

ALTER TABLE [SKL].[Usuarios] ADD CONSTRAINT [FK_Usuarios_UserType] FOREIGN KEY([id_usr_type]) REFERENCES [SKL].[UserType] ([id_usr_type])
GO

ALTER TABLE [SKL].[Usuarios] ADD CONSTRAINT [FK_Usuarios_Departments] FOREIGN KEY([id_usr_department]) REFERENCES [SKL].[Departments] ([id_department])
GO
CREATE TABLE [dbo].[ChucVu]
(
[MaChucVu] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TenChucVu] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChucVu] ADD CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED  ([MaChucVu]) ON [PRIMARY]
GO
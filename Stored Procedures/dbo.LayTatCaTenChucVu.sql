SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROC [dbo].[LayTatCaTenChucVu]
AS
BEGIN
SELECT DISTINCT TenChucVu
FROM dbo.ChucVu
END
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROC [dbo].[SELECT_ALL]
AS 
BEGIN
SELECT MaDangNhapNguoiDung , MatKhau FROM NguoiDung
END
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROC [dbo].[UPDATE_PASS](@MA VARCHAR(10), @PASS VARCHAR(100))
AS BEGIN
	UPDATE NguoiDung
	SET MatKhau = @PASS
	WHERE MaDangNhapNguoiDung = @MA
END
GO
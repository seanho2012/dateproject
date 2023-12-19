DROP PROCEDURE [dbo].[spChangeServerStatus]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
-- =============================================
-- Author:		<SeanHo>
-- Create date: <2023.09.21>
-- Description:	<更新伺服器狀態>
-- History:     <2023.09.21>	[V1.0] New Create
-- Ex.

exec spChangeServerStatus @ServerStatus='1'
-- =============================================
*/
CREATE PROCEDURE [dbo].[spChangeServerStatus]
	 @ServerStatus BIT
AS
BEGIN
    BEGIN TRY
        /** 交易開始 *********************************************/
        BEGIN TRAN
            DECLARE @CurrentServerStatus VARCHAR(10)
            SELECT @CurrentServerStatus = [Status] FROM ServerStatus WHERE IsVaild = 1
            IF @CurrentServerStatus <> @ServerStatus OR @CurrentServerStatus IS NULL BEGIN
                UPDATE ServerStatus SET EndTime = GETDATE(), IsVaild = 0 WHERE IsVaild = 1
                INSERT INTO ServerStatus ([Status], StartTime, EndTime, IsVaild)
                VALUES(@ServerStatus,GETDATE(),NULL,1)
                PRINT 'success'
                COMMIT
            END ELSE BEGIN
                PRINT 'status not change'
                ROLLBACK
            END
    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END
GO

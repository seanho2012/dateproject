DROP PROCEDURE IF EXISTS [dbo].[spCreateNewAccount]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
-- =============================================
-- Author:		<SeanHo>
-- Create date: <2024.01.16>
-- Description:	<新增使用者>
-- History:     <2024.01.16>	[V1.0] New Create
-- Ex.

exec spCreateNewAccount
-- =============================================
*/
CREATE PROCEDURE [dbo].[spCreateNewAccount]
	@CreatedUser NVARCHAR(100) = 'System'
    , @CreatedDate DATETIME = NULL
AS
BEGIN
    BEGIN TRY
        /** 交易開始 *********************************************/
        BEGIN TRAN
            CREATE TABLE #tmp (PersonID BIGINT)
            DECLARE @PersonID BIGINT

            INSERT INTO  #tmp (PersonID)
            EXEC spCreateNewPerson @CreatedUser = @CreatedUser, @CreatedDate = @CreatedDate

            SELECT @PersonID = PersonID FROM #tmp

            EXEC spCreateNewUser @PersonID = @PersonID, @CreatedUser = @CreatedUser, @CreatedDate = @CreatedDate

        COMMIT

    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END
GO

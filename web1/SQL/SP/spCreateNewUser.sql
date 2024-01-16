DROP PROCEDURE IF EXISTS [dbo].[spCreateNewUser]
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

exec spCreateNewUser @PersonID = '1'
-- =============================================
*/
CREATE PROCEDURE [dbo].[spCreateNewUser]
    @PersonID INT
	, @CreatedUser NVARCHAR(100) = 'System'
    , @CreatedDate DATETIME = NULL
AS
BEGIN
    BEGIN TRY
        /** 交易開始 *********************************************/
        BEGIN TRAN

            INSERT INTO UserProfile (PersonID, CreatedDate, CreatedUser, ModifiedDate, ModifiedUser) 
            OUTPUT Inserted.UserID
            VALUES(
                @PersonID
                , CASE WHEN @CreatedDate IS NULL THEN GETDATE() ELSE @CreatedDate END
                , @CreatedUser
                , CASE WHEN @CreatedDate IS NULL THEN GETDATE() ELSE @CreatedDate END
                , @CreatedUser
            )

        COMMIT

    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END
GO

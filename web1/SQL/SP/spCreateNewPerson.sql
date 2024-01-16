DROP PROCEDURE IF EXISTS [dbo].[spCreateNewPerson]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
-- =============================================
-- Author:		<SeanHo>
-- Create date: <2024.01.16>
-- Description:	<新增人頭>
-- History:     <2024.01.16>	[V1.0] New Create
-- Ex.

exec spCreateNewPerson
-- =============================================
*/
CREATE PROCEDURE [dbo].[spCreateNewPerson]
	 @CreatedUser NVARCHAR(100) = 'System'
     ,@CreatedDate DATETIME = NULL
AS
BEGIN
    BEGIN TRY
        /** 交易開始 *********************************************/
        BEGIN TRAN

            INSERT INTO Person (CreatedDate, CreatedUser, ModifiedDate, ModifiedUser) 
            OUTPUT Inserted.PersonID
            VALUES(
                CASE WHEN @CreatedDate IS NULL THEN GETDATE() ELSE @CreatedDate END
                ,@CreatedUser
                ,CASE WHEN @CreatedDate IS NULL THEN GETDATE() ELSE @CreatedDate END
                ,@CreatedUser
            )

        COMMIT

    END TRY
    BEGIN CATCH
        ROLLBACK
    END CATCH
END
GO
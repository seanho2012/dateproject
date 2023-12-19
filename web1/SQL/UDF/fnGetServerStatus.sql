DROP FUNCTION IF EXISTS [dbo].[fnGetServerStatus]
GO
SET ANSI_NULLS ON 
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fnGetServerStatus]
/*
-- =============================================
-- Author:		<SeanHo>
-- Create date: <2023.09.21>
-- Description:	<取得伺服器狀態>
-- History:     <2023.09.21>	[V1.0] New Create
-- Ex.

select * from dbo.fnGetServerStatus()
-- =============================================
*/()
RETURNS TABLE
AS
Return
(
	SELECT B.CodeName AS [ServerStatus]
    FROM ServerStatus A 
    JOIN SystemCode B ON B.SystemCode=A.Status AND B.CodeType = 'ServerStatus'
    WHERE A.IsVaild = 1
)
GO

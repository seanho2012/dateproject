DROP FUNCTION [dbo].[fnGetPayDateByOtherTransferMediaType]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
-- =============================================
-- Author:      <Leo Liu>
-- Create date: <2022.01.19>
-- Description: <取得其他轉存媒體給付日期by資料來源>

-- Ex.          
    select * from dbo.fnGetPayDateByOtherTransferMediaType('T000000009', 94, '1') a
	where 1=1
		and a.PayDate is not null and a.PayDate <> ''
	order by PayDate DESC

-- =============================================
*/
CREATE FUNCTION [dbo].[fnGetPayDateByOtherTransferMediaType] 
(   
 @TenantID                  varchar(20)		--客戶代號
,@CompanyPartyID            bigint		    --公司序號
,@OtherTransferMediaType    varchar(100)	--資料來源 1 = 法院扣款
)
RETURNS @PayDate TABLE 
(
    PayDate date
	, TenantID varchar(20)
)
as 
begin
	
	if @OtherTransferMediaType = '1'	--法院扣款
	begin
		insert into @PayDate(PayDate, TenantID)
		select distinct A.PayDate, A.TenantID
		from vwEN_PaycheckCourtDeduction A
		join vwEN_PaycheckItem B on A.PaycheckItemID = B.PaycheckItemID
		join PaycheckDate C on B.PaycheckDateID = C.PaycheckDateID
		where A.TenantID = @TenantID
			and C.CompanyPartyID = @CompanyPartyID

	end 

    return
end
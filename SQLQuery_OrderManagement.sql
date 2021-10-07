SET QUOTED_IDENTIFIER OFF;
SELECT 
o.OrderID, 
COALESCE(o.Price, 0) AS Price,
CAST(CONVERT(int ,COALESCE(o.Price, 0), 2)AS nvarchar) AS PriceString,
o.[Count] AS [Count],
(o.[Count] * COALESCE(o.Price, 0)) AS Total, 
CAST(CONVERT(int, o.[Count] * COALESCE(o.Price, 0), 2) AS nvarchar) AS TotalString, 
CONVERT(nvarchar, o.DealedDate, 111) AS DealedDate, 
COALESCE(q.ExecuteDate, o.PredictDays, 0) AS PredictDays, 
CAST(DATEADD(day,COALESCE(q.ExecuteDate, o.PredictDays, 0), o.DealedDate) AS nvarchar(50)) AS CompleteDate,
COALESCE(o.OrderStatus, 0) AS OrderStatus, OrderStatusString = CASE COALESCE(o.OrderStatus , 0) WHEN 0 THEN '待付款' WHEN 1 THEN '製作中' WHEN 2 THEN '待驗收' WHEN 3 THEN '已提出撥款需求' WHEN 4 THEN '撥款完成' END,
IIF(COALESCE(o.OrderStatus, 0) = 3, 1, 0) AS IsClientConfirmed, o.ProposerID AS ProposerID,m.Email AS ProposerEmail, 
COALESCE(o.StudioName, "無接案名稱") AS StudioName,
COALESCE(m.CellPhone, "無接案電話") AS ProposerPhone,
COALESCE(m.BankCode, "無銀行行號資料") AS BankCode,
COALESCE(m.BankAccount, "無銀行帳號資料") AS BankAccount,
COALESCE(m.Balance, 0) AS Balance,
CAST(COALESCE(CONVERT(int,COALESCE(m.Balance, 0), 2), 0) AS nvarchar) AS BalanceString,o.[Name] AS ClientName,  o.Tel AS ClientTel, o.Email AS ClientEmail, 
COALESCE(o.Memo, "") AS ClientMemo FROM [Order] as o 
LEFT JOIN Quotation as q ON o.QuotationID = q.QuotationID 
LEFT JOIN MemberInfo as m ON o.ProposerID = m.MemberID

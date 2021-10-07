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
COALESCE(o.OrderStatus, 0) AS OrderStatus, OrderStatusString = CASE COALESCE(o.OrderStatus , 0) WHEN 0 THEN '�ݥI��' WHEN 1 THEN '�s�@��' WHEN 2 THEN '���禬' WHEN 3 THEN '�w���X���ڻݨD' WHEN 4 THEN '���ڧ���' END,
IIF(COALESCE(o.OrderStatus, 0) = 3, 1, 0) AS IsClientConfirmed, o.ProposerID AS ProposerID,m.Email AS ProposerEmail, 
COALESCE(o.StudioName, "�L���צW��") AS StudioName,
COALESCE(m.CellPhone, "�L���׹q��") AS ProposerPhone,
COALESCE(m.BankCode, "�L�Ȧ�渹���") AS BankCode,
COALESCE(m.BankAccount, "�L�Ȧ�b�����") AS BankAccount,
COALESCE(m.Balance, 0) AS Balance,
CAST(COALESCE(CONVERT(int,COALESCE(m.Balance, 0), 2), 0) AS nvarchar) AS BalanceString,o.[Name] AS ClientName,  o.Tel AS ClientTel, o.Email AS ClientEmail, 
COALESCE(o.Memo, "") AS ClientMemo FROM [Order] as o 
LEFT JOIN Quotation as q ON o.QuotationID = q.QuotationID 
LEFT JOIN MemberInfo as m ON o.ProposerID = m.MemberID

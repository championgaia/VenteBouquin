USE [NorthwindDb]
GO

DECLARE @RC int
DECLARE @CustomerID nchar(5)

-- À faire : définir des valeurs de paramètres ici.

EXECUTE @RC = [dbo].[CustOrderHist] 
   'ALFKI'
GO

select top 1 c.ContactName, c.CompanyName, sum(od.UnitPrice*od.Quantity) total
 from Customers c
 inner join Orders o on c.CustomerID = o.CustomerID
 inner join [Order Details] od on o.OrderID = od.OrderID
 inner join Products p on p.ProductID = od.ProductID
 inner join Categories cat on cat.CategoryID = p.CategoryID
 where c.Country = 'France'
 group by c.ContactName, c.CompanyName
 order by total

 if OBJECT_ID('PS_GetTopCustomer') is not null
 drop proc PS_GetTopCustomer
 go
 create proc PS_GetTopCustomer(@nomPays nvarchar(50))
 as
	select top 1 c.ContactName, c.CompanyName, sum(od.UnitPrice*od.Quantity) total
	from Customers c
	inner join Orders o on c.CustomerID = o.CustomerID
	inner join [Order Details] od on o.OrderID = od.OrderID
	inner join Products p on p.ProductID = od.ProductID
	inner join Categories cat on cat.CategoryID = p.CategoryID
	where c.Country = @nomPays
	group by c.ContactName, c.CompanyName
	order by total
 go
 exec PS_GetTopCustomer 'France'
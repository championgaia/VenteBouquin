USE [NorthwindDB]
GO

INSERT INTO [dbo].[Customers]
           ([CustomerID]
           ,[CompanyName]
           ,[ContactName]
           ,[ContactTitle]
           ,[Address]
           ,[City]
           ,[Region]
           ,[PostalCode]
           ,[Country]
           ,[Phone]
           ,[Fax])
     VALUES
           ('abcde'
           ,'ORANGE'
           ,'mouhdiaz@hotmail.com'
           ,'directeur'
           ,'3, Square d athenes'
           ,'Massy'
           ,'Ile-de-France'
           ,'91300'
           ,'FRANCE'
           ,'0761279974'
           ,'0101010101')
GO
select *
from Customers
where CustomerID='abcde'

select *
from customers
where city != 'Berlin'

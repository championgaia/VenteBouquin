select * from Customers;
Select City from Customers;
select Distinct Country 
From Customers;
select * from Customers
Where city='Berlin';
select * from Customers
where CustomerID='WOLZA';

select * 
From Customers 
Where city='Berlin'
and PostalCode='12209';

select *
From Customers
order by City;

select *
From Customers
order by Country,City;


INSERT INTO Customers
           (CustomerID
           ,CompanyName
           ,ContactName
           ,ContactTitle
           ,Address
           ,City
           ,Region
           ,PostalCode
           ,Country
           ,Phone
           ,Fax)
     VALUES
         ('DFTG2',
		 'SARL NAJWA',
		 'SARA ALAMI',
		 'Owner',
		 '14 Rue de la Victoire',
		 'CASABLANCA',
		 Null,
		 '42000',
		 'Maroc'
		 '0021205202452',
		 '0021202523652')
GO

select * 
from Customers
where PostalCode is not null;

select Top 3 *
From Customers;

select ProductName, CategoryName
from Products P Inner Join Categories C
on P.CategoryID=C.CategoryID

select ProductName, UnitPrice, region
From Products P Left join Suppliers S
on P.SupplierID = S.SupplierID
where Country != 'USA'



select E2.FirstName , E2.LastName, E2.ReportsTo , E1.FirstName , E1.LastName
From Employees E1  INNER join Employees E2 on E1.EmployeeID=E2.ReportsTo




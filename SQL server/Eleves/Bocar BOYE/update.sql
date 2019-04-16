update Customers
set city = 'oslow'
where Country='Norway'

select *
from Customers
where Country='Norway'

Delete  
from Customers
where Country='Norway'

create table Person (
				PersonID int,
				LastName varchar(255),
				FirstName varchar(255),
				Adress varchar(255),
				City varchar(255),
				primary key(PersonID)
			)
		
select *
from Customers
where City like'a%' or City like'c%' or City like's%'
order by City

select productName,categoryName
from categories
inner join Products on Products.CategoryID = Categories.CategoryID

select productName,UnitPrice, country
from Products
inner join Suppliers on Suppliers.SupplierID = Products.SupplierID
where Country !='USA'

select LastName,FirstName
from Employees
ReportsTo

select *
from Employees
where ReportsTo is not null

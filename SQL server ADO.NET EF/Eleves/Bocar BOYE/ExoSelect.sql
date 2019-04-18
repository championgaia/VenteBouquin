--SElECT SUITE-----
--1
select * 
from Customers
where City='Berlin' and PostalCode=12209
--2
select * 
from Customers
where City='Berlin' or City='London'
--3
select * 
from Customers
order by City desc
--4
select * 
from Customers
order by Country,City asc
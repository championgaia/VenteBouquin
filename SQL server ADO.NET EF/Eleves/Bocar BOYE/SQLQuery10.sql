select valuet1, valuet3 
from table1 t1
inner join table2 t2 on t1.id = t2.id
inner join table3 t3 on t3.id = t2.id


select country,count(CustomerID) as nbr
from Customers
group by country 
order by nbr desc

create table CustomerLanguage(
								Id int IDENTITY primary key,
								CustomerId nchar(5),
								Langage VARCHAR(20),
							)
--1) ajouter une cle etrangere a la table de la table customers colonne customerID
 
alter table CustomerLanguage 
add foreign key (CustomerID)
references Customers(CustomerID)
--2 Insérer une valeur de language 'Francais' pour 'Blonp'


INSERT INTO [dbo].[CustomerLanguage]
           ([CustomerId]
           ,[Langage])
     VALUES ('BLONP','FRANCAIS')
   
select *
from CustomerLanguage

INSERT INTO [dbo].[CustomerLanguage]
           ([CustomerId]
           ,[Langage])
     VALUES ('TOTO09','FRANCAIS')

	  DELETE FROM Customers
	  where CustomerID='BLONP'
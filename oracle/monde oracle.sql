---------------------create table country--------------------
CREATE TABLE country (
  Code varCHAR(3) NOT NULL,
  Name varCHAR(52) NOT NULL,
  Continent varchar(15)  DEFAULT 'Asia' NOT NULL,
  Region varCHAR(26) NOT NULL,
  SurfaceArea FLOAT(2) DEFAULT 0.00 NOT NULL ,
  IndepYear SMALLINT DEFAULT NULL,
  Population INT DEFAULT 0 NOT NULL ,
  LifeExpectancy FLOAT(1) DEFAULT NULL,
  GNP FLOAT(2) DEFAULT NULL,
  GNPOld FLOAT(2) DEFAULT NULL,
  LocalName varCHAR(45) NOT NULL,
  GovernmentForm varCHAR(45) NOT NULL,
  HeadOfState varCHAR(60),
  Capital INT,
  Code2 varCHAR(2) NOT NULL,
  PRIMARY KEY (Code)
);
alter table country
add constraint country_chk1 check
(Continent in ('Asia','Europe','North America','Africa','Oceania','Antarctica','South America'))
enable;
---------------------create table countrylanguage--------------------

CREATE TABLE countrylanguage (
  CountryCode varCHAR(3) NOT NULL ,
  Language varCHAR(30) NOT NULL ,
  IsOfficial varchar(1) NOT NULL,
  Percentage FLOAT(1) DEFAULT 0.0 NOT NULL ,
  PRIMARY KEY (CountryCode,Language)
);

alter table countrylanguage 
add CONSTRAINT countryLanguage_ibfk_1 FOREIGN KEY (CountryCode) 
REFERENCES country (Code);

alter table countrylanguage
add CONSTRAINT countrylanguage_chk1 check(IsOfficial in ('T','F'))
enable;

---------------------create table city-----------------------------
CREATE TABLE city (
  ID INTEGER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL,
  Name varCHAR(35) NOT NULL ,
  CountryCode varCHAR(3) NOT NULL ,
  District varCHAR(20) NOT NULL ,
  Population INT DEFAULT 0 NOT NULL ,
  PRIMARY KEY (ID)
);
alter table city
add  CONSTRAINT city_ibfk_1 
FOREIGN KEY (CountryCode) REFERENCES country (Code)
;
-------------------------TP2 -----------------------------
-------------------------TP2-2 -----------------------------
--show tables ne marche pas
desc city;
-------------------------TP2-3-1 -----------------------------
select * from (select  name,  population from country
order by population desc)
where rownum <=3
; 
select  name,  population from country
order by population desc
FETCH NEXT 3 ROWS ONLY
;
-------------------------TP2-3-2 -----------------------------
select name, surfacearea from country
order by surfacearea 
FETCH NEXT 10 ROWS ONLY
;
select name, surfacearea from country
order by surfacearea 
offset 20 rows FETCH NEXT 10 ROWS ONLY
;
-------------------------TP2-3-3 -----------------------------
select code from country
where name ='Canada'
;
-------------------------TP2-3-4 -----------------------------
select ci.name, ci.population 
from country co
inner join city ci on co.code = ci.countrycode
where co.name ='Canada'
order by population desc
;
-------------------------TP2-3-5 -----------------------------
select name 
from country 
where name like 'Z%'
;
-------------------------TP2-3-6 -----------------------------
select name, GNP*35 
from country
where name='Ukraine';
-------------------------TP2-3-7 -----------------------------
select count(name)
from country
;
-------------------------TP2-3-8 -----------------------------
select sum(GNP)
from country
;
-------------------------TP2-3-9 -----------------------------
select name, population/surfacearea
from country
where continent = 'Asia'
order by population/surfacearea desc
FETCH NEXT 3 ROWS ONLY
;
-------------------------TP2-3-10 -----------------------------
select continent, sum(population)
from country
group by continent
;
-------------------------TP2-4-1 -----------------------------
select ci.name
from country co
inner join city ci on co.code = ci.countrycode
where co.name ='Japan'
order by ci.name
;
-------------------------TP2-4-2 -----------------------------
select co.name
from country co
inner join city ci on co.code = ci.countrycode
where ci.name = 'Kingston'
order by co.name
;
-------------------------TP2-4-3 -----------------------------
select ci.name, ci.population
from  city ci 
inner join country co on co.code = ci.countrycode
where ci.population>5000000 and  co.continent = 'Asia'
order by population
;
-------------------------TP2-4-4 -----------------------------
select sum(ci.population)
from country co
inner join city ci on co.code = ci.countrycode
where co.continent = 'Africa'
;
-------------------------TP2-5-1 -----------------------------
select name, population
from country
having population>(select avg(population)
                    from country)
group by name, population
order by name
;
-------------------------TP2-5-2 -----------------------------
select name, max(surfacearea) maxSurface, region from country
group by region, name
order by maxSurface desc
fetch next 7 rows only
;
-------------------------TP2-6-1 -----------------------------
update country 
set headOfState = 'Emmanuel Macron'
where name = 'France'
;
-------------------------TP2-6-2 -----------------------------
update country
set population = population*1.1
where continent = 'Europe'
;
-------------------------TP2-6-3 -----------------------------
delete from city
where name = 'Paris'
;
-------------------------TP2-6-4 -----------------------------
delete from city 
where city.Id in (select id from
              city ci
              inner join country co on co.code = ci.countrycode
              where co.continent ='Africa')
;
-------------------------TP3 -----------------------------
-------------------------TP3-1-1 -----------------------------
show autocommit;
set autocommit off;
begin transaction;
------------------tp4-1 PS augmentation de population----------
create or replace procedure augmentPopulation(pourcentage in number)
is 
begin
    update country
    set population = population*(1+pourcentage/100);
    commit;
end;
/
exec augmentPopulation(10);
------------------tp4-2 PS calcul superdicie mondiale-----------
create or replace procedure calculSurperficie
  (nomContinent in varCHAR2, temp in out number)
is
    begin
        select sum(surfacearea)
        into temp
        from country
        where continent = nomContinent;
    end;
/

DECLARE
    amount NUMBER;
BEGIN
    calculSurperficie('Asia', amount);
    dbms_output.put_line(amount);
END;
/
------------------tp4-2 View calcul superdicie mondiale-----------
create or replace view calculSurperficieView(somme) as 
  select sum(surfacearea) somme
        from country;
------------------tp4-2 PS calcul superdicie mondiale avec curseur-----------
create or replace procedure 
  calculSurperficieCurseur2(sommeS in out number)
as
cursor curs1 is 
              select distinct surfacearea
              from country;
begin
      for item in curs1 loop
        sommeS := sommeS + item.surfacearea;
      end loop;
end;
/
set serveroutput on;
DECLARE
    amount NUMBER;
BEGIN
    amount :=0;
    calculSurperficieCurseur2(amount);
    dbms_output.put_line(amount);
END;
/
------------------tp4-2 PS calcul superdicie mondiale avec curseur-----------
create or replace procedure calculSurperficieCurseurWhile(sommeS in out number)
as
surface number;
cursor curs1 is 
             select distinct surfacearea
             from country;
    begin
    sommeS := 0;
    surface :=0;
      open curs1;
        fetch curs1 into surface;
        while curs1%FOUND loop
            sommeS := sommeS + surface;
            fetch curs1 into surface;
        end loop;
      close curs1;
      commit;
      dbms_output.put_line(sommeS);
    end;
/
DECLARE
    amount NUMBER;
BEGIN
    amount :=0;
    calculSurperficieCurseurWhile(amount);
    dbms_output.put_line(amount);
END;
/
-------------------tp4-3 trigger 1 milliard d'habitant-----------
create or replace trigger country_triggeur_insert 
before insert
on country for each row
enable
when (new.population > 1000000000)
declare
    BEGIN
      :new.population := 1000000000;
    end;
/
-------------------tp4-3 trigger 1 milliard d'habitant-----------
create or replace trigger country_triggeur_insert 
before insert
on country for each row
enable
declare
    begin
      if (:new.population > 1000000000) then
        :new.population := 1000000000;
      end if;
    end;
    /
-------------------tp4-4 trigger update une pays-----------
create or replace trigger country_trigger_update
before update
on country for each row
enable
declare
begin
    if (:new.population > 1000000000) then
        :new.population := 1000000000;
    end if;
    if (:new.population > 1.1* :old.population)
       or (:new.population < 0.9*:old.population) then
        :new.population := :old.population;
    end if;
end;
/
-------------------tp4-5 PS calcul a partir nom continent-----------
------------------------getTotalPopulationPS-----------------------------
create or replace procedure getTotalPopulationPS
  (nomContinent in varchar2,
    totalPopulation in out number)
as
regionNom varchar2(255);
cursor curs3  is 
              select distinct region
              from country
              where continent = nomContinent;
    begin
      regionNom := 'Eastern Asia';
        open curs3;
        fetch curs3 into regionNom;
        while curs3%FOUND loop
            getTotalPopulationRegion(regionNom, totalPopulation);
            fetch curs3 into regionNom;
        end loop;
        close curs3;
        commit;
        --dbms_output.put_line(totalPopulation);
    end;
/
DECLARE
    amount NUMBER;
BEGIN
    amount :=0;
    getTotalPopulationPS('Asia',amount);
    dbms_output.put_line(amount);
END;
/
----------------------getTotalPopulationRegion--------------------------
create or replace procedure getTotalPopulationRegion
  (regionNom in varchar2,
    totalPopulationRegion in out number)
  as
  onePopulation number;
  cursor curs2  is 
                select distinct population
                from country
                where region = regionNom;  
    begin
      onePopulation :=0;
        open curs2;
        fetch curs2 into onePopulation;
        while curs2%FOUND loop
            totalPopulationRegion := totalPopulationRegion + onePopulation;
            fetch curs2 into onePopulation;
        end loop;
        close curs2;
        --commit;
    end;  
/
DECLARE
    amount NUMBER;
BEGIN
    amount :=0;
    getTotalPopulationRegion('Western Europe', amount);
    dbms_output.put_line(amount);
END;
/
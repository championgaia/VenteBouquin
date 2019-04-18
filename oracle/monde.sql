-----------------------------monde
--------------------------Creation de bdd-------------------------------------
Create database monde;
Create database societe;
Drop database societe;
use monde;
----------------------------creation table pays------------------------
Create table pays (
    id int auto_increment,
    nom varchar(20) not null,
    population int default 1000,
    continent varchar(20) not null,
    annee_independance date null,
    constraint cle_P_Pays primary key (id)
)
engine = innoDb
;
create unique index nomPays on pays (nom);
----------------------------creation table ville------------------------
create table ville (
    id int auto_increment,
    id_pays int,
    nom varchar(20) not null,
    constraint cle_P_ville primary key (id),
    constraint cle_E_ville_Pays foreign key (id_pays) references pays(id) 
)engine=innoDb;

 ----------------------------creation table langue------------------------
create table langue (
id int auto_increment,
id_pays int,
nom varchar(20) not null,
pourcentage decimal(5,2) null,
groupe varchar(20) not null,
constraint cle_P_langue primary key (id),
constraint cle_E_langue_Pays foreign key (id_pays) references pays(id)
) engine=innoDb;
-----------------------------alter table ville-----------------------------
alter table ville add column population int;
-----------------------------alter table langue-----------------------------
alter table langue drop column groupe;
-----------------------------drop table ville----------------------
drop table ville;
-----------------------------insert into pays----------------------
insert into pays (nom, population, continent, annee_independance) 
values ('France', 67595000, 'Europe', null), ('Mali', 17994837, 'Afrique', 1960), ('Inde', 1251695584, 'Asie', 1947);
-----------------------------insert into langue----------------------
insert into langue (id_pays ,nom, pourcentage) values
(2, 'Bambara', 46.3), (2,'Peul', 9.2) ;
-----------------------------------top 3 world population----------------------
use world;
select name, population from country
order by population desc
limit 3; 
-----------------------------------top 1 world petit surface----------------------
select name, surfacearea from country
order by surfacearea 
limit 10;
---------------------------------code pay de canada----------------
select code from country
where name ='canada'
;
-------------------------------top city canada by population-------
select ci.name, ci.population 
from country co
inner join city ci on co.code = ci.countrycode
where co.name ='canada'
order by population desc
;
---------------------------pays commence par Z--------------
select name 
from country 
where name like 'Z%'
;
-------------------------PNB de Ukraine en Hryvnia----------
select GNP*35, name
from country
where name='Ukraine';
-------------------------count pays-------------------------
select count(name)
from country
;
-------------------------sum pnb----------------------------
select sum(GNP)
from country
;
-------------------------top 3 pays dense en asie------------------
select population/surfacearea, name
from country
where continent = 'asia'
order by population/surfacearea desc
limit 3
;
-------------------------total population par continent----------
select sum(population), continent
from country
group by continent
;
----------------------ville au japon-------------------
select ci.name
from country co
inner join city ci on co.code = ci.countrycode
where co.name ='japan'
order by ci.name
;
------------------------pays de ville Kingston--------
select co.name
from country co
inner join city ci on co.code = ci.countrycode
where ci.name = 'kingston'
order by co.name
;
------------------------pays asie ples 5 millions d'habitant-----
select ci.name, ci.population
from  city ci 
inner join country co on co.code = ci.countrycode
where ci.population>5000000 and  co.continent = 'Asia'
order by population
;
----------------------population total des ville affricane--------
select sum(ci.population)
from country co
inner join city ci on co.code = ci.countrycode
where co.continent = 'Africa'
;
-----------------------pays plus nbr que moyenne--------------
select avg(population)
from country
;

select name, population
from country
having population>(select avg(population)
                    from country)
group by name, population
order by name
;
--------------------------plus grand pays chaque region----------
select name, max(surfacearea), continent from country
group by continent, name
order by surfacearea desc
limit 7
;
select name, surfacearea, continent from country
group by continent
order by surfacearea desc
;
select name, surfacearea, region from country
group by region
order by surfacearea desc
;
------------------------chef etat----------------
update country 
set headOfState = 'Emmanuel Macron'
where name = 'France'
;
--------------------ajouter 10% population europe---------
update country
set population = population*1.1
where continent = 'Europe'
;
-----------------delete  ville paris-----------------
delete from city
where name = 'Paris'
;
---------------delete ville africain-------------
delete ci from city ci
inner join country co on co.code = ci.countrycode
where co.continent ='Africa'
;
--------------------nbr habitant parlent anglais par region et par continent-----
select co.continent, co.region, sum(co.population*cl.percentage/100) nbrHabitant 
from country co 
inner join countrylanguage cl on co.code = cl.countrycode
where cl.language = 'english'
group by co.region, co.continent
order by continent, region
;
--------------------ville qui a plus de 5k personne parle espagnol------
select ci.name ville, ci.population, cl.language
from city ci
inner join country co on co.code = ci.countrycode
inner join countrylanguage cl on co.code = cl.countrycode
where cl.language ='spanish' and (ci.population*cl.percentage)/100>5000
; 
---------------------region (startwith S) a espérent de vie >=74--------
select co.region, avg(co.LifeExpectancy)
from country co
where co.region like 'S%'
group by region
having avg(co.LifeExpectancy)>=74
;
---------------------region a espérent de vie >=74--------
select co.region, avg(co.LifeExpectancy)
from country co
group by region
having avg(co.LifeExpectancy)>=74
;

-------------liste Region ou tous les pays parlent anglais et esperent vie >= 74------------
select co.region 
from country co
where region not in (select  co2.region
                from country co2
                inner join countrylanguage cl2 on co2.code = cl2.countrycode
                where 'English' not in (select cl3.language 
                            from country co3
                            inner join countrylanguage cl3 on cl3.countrycode = co3.code
                            where co3.code = co2.code
                            group by co3.name, cl3.language, co3.region)
                group by co2.region)
group by co.region
having avg(co.LifeExpectancy)>=74
; 
-------------liste Region ou on parle anglais et esperent vie >= 74------------
select co.region 
from country co
where region  in (select  co2.region
                from country co2
                inner join countrylanguage cl2 on co2.code = cl2.countrycode
                where 'English'  in (select cl3.language 
                            from country co3
                            inner join countrylanguage cl3 on cl3.countrycode = co3.code
                            where co3.code = co2.code
                            group by co3.name, cl3.language, co3.region)
                group by co2.region)
group by co.region
having avg(co.LifeExpectancy)>=74
; 
---pays ne parle pas anglais-------
select  co2.region
    from country co2
    inner join countrylanguage cl2 on co2.code = cl2.countrycode
    where 'English' not in (select cl3.language 
                            from country co3
                            inner join countrylanguage cl3 on cl3.countrycode = co3.code
                            where co3.code = co2.code
                            group by co3.name, cl3.language, co3.region)
    group by co2.region
    ;
--------------liste de pays ou on parle fr en oceanie---------------
select co.name, cl.language
from country co
inner join countrylanguage cl on cl.countrycode = co.code
where cl.language = 'French' and co.continent = 'oceania'
group by co.name, cl.language
; 
---------------------Tp3-1-1 Desactive autocommit-------------------
select @@autocommit;
set autocommit = 0;
start transaction;
---------------------Tp3-1-2 supprime les villes ayant code pays FRA-------------------
delete ci 
from city ci 
inner join country co on co.code = ci.countrycode
where co.code = 'FRA'
;
---------------------Tp3-1-3 supprime les villes ayant code pays DEU-------------------
delete ci 
from city ci 
inner join country co on co.code = ci.countrycode
where co.code = 'DEU'
;
---------------------Tp3-1-4  vérifier ligne supprimée-------------------
select * from city 
where countrycode = 'FRA' or countrycode ='DEU'
;
---------------------Tp3-1-5 annuler-------------------
rollback;
---------------------Tp3-1-6  vérifier ligne existant-------------------
select * from city 
where countrycode = 'FRA' or countrycode ='DEU'
;
---------------------Tp3-1-7 supprime les villes ayant code pays FRA-------------------
delete ci 
from city ci 
inner join country co on co.code = ci.countrycode
where co.code = 'FRA'
;
---------------------Tp3-1-8 valider et verifier-------------------
commit;
select * from city 
where countrycode = 'FRA'
;
---------------------Tp3-1-9 Reactive autocommit-------------------
set autocommit = 1;
---------------------Tp3-2-1 Desactive autocommit-------------------
set autocommit = 0;
start transaction;
---------------------Tp3-2-2 supprimer ville de canada-------------------
delete ci 
from city ci 
inner join country co on co.code = ci.countrycode
where co.code = 'CAN'
;
---------------------Tp3-2-3 Creer un jalon-------------
savepoint point1;
---------------------Tp3-2-4 supprimer ville de chine-------------------
delete ci 
from city ci 
inner join country co on co.code = ci.countrycode
where co.code = 'CHN'
;
---------------------Tp3-2-5 Verifier-------------
select * from city 
where countrycode = 'CAN' or countrycode ='CHN'
;
---------------------Tp3-2-6 revenier au jalon etape 3-------------
rollback to point1;
---------------------Tp3-1-8 valider et verifier-------------------
commit;
select * from city 
where countrycode = 'CAN' or countrycode ='CHN'
;

--tp4
------------------tp4-1 PS augmentation de population----------
delimiter $
create procedure augmentPopulation (in pourcentage decimal(4,2))
begin
    update country
    set population = population*(1+pourcentage/100);
end;$
delimiter ;
call augmentPopulation(10);
------------------tp4-2 PS calcul superdicie mondiale-----------
delimiter $
create procedure calculSurperficie()
    begin
        select sum(surfacearea)
        from country;
    end; $   
delimiter ;
call calculSurperficie();
------------------tp4-2 PS calcul superdicie mondiale avec curseur-----------
delimiter $
create procedure calculSurperficieCurseur()
    begin
        declare sommeS decimal(20, 2);
        declare curs1 cursor for 
                            select sum(surfacearea)
                            from country;
        open curs1;
        fetch curs1 into sommeS;
        close curs1;
        select sommeS;
    end; $   
delimiter ;
call calculSurperficieCurseur();
------------------tp4-2 PS calcul superdicie mondiale avec curseur-----------
delimiter $
create procedure calculSurperficieCurseur2()
    begin
        declare surface decimal(20, 2) default 0;
        declare fincurs boolean default 0;
        declare sommeS decimal(20, 2) default 0;
        declare curs1 cursor for 
                            select surfacearea
                            from country;
        declare continue handler for not found set fincurs = 1;
        open curs1;
        fetch curs1 into surface;
        while (not fincurs) do
            set sommeS = sommeS + surface;
            fetch curs1 into surface;
        end while;
        close curs1;
        select sommeS;
    end; $   
delimiter ;
call calculSurperficieCurseur2();
------------------tp4-2 PS calcul superdicie mondiale avec curseur-----------
delimiter $
create procedure calculSurperficieCurseur3()
    begin
        declare surface decimal(20, 2) default 0;
        declare fincurs boolean default 0;
        declare sommeS decimal(20, 2) default 0;
        declare curs1 cursor for 
                            select surfacearea
                            from country;
        declare continue handler for not found set fincurs = 1;
        open curs1;
        repeat
            set sommeS = sommeS + surface;
            fetch curs1 into surface;
        until (fincurs)        end repeat;
        close curs1;
        select sommeS;
    end; $   
delimiter ;
call calculSurperficieCurseur3();
drop procedure calculSurperficieCurseur3;
------------------tp4-2 PS calcul superdicie mondiale avec curseur-----------
delimiter $
create procedure calculSurperficieCurseur4()
    begin
        declare surface decimal(20, 2) default 0;
        declare fincurs boolean default 0;
        declare sommeS decimal(20, 2) default 0;
        declare curs1 cursor for 
                            select surfacearea
                            from country;
        declare continue handler for not found set fincurs = 1;
        open curs1;
        label1 : loop
            fetch curs1 into surface;
            if not fincurs then
                set sommeS = sommeS + surface;
                iterate label1;
            end if;
        leave label1;
        end loop label1;
        close curs1;
        select sommeS;
    end; $   
delimiter ;
call calculSurperficieCurseur4();
drop procedure calculSurperficieCurseur4;
-------------------tp4-3 trigger 1 milliard d'habitant-----------
delimiter $
create trigger country_triggeur_insert 
before insert
on country for each row
    begin
        if new.population > 1000000000 then 
            set new.population = 1000000000;
        end if;    
    end;$
delimiter ;
-------------------tp4-4 trigger update une pays-----------
delimiter $
create trigger country_trigger_update
before update
on country for each row
begin
    if new.population > 1000000000 then
        set new.population = 1000000000;
    end if;
    if new.population > 1.1* old.population or new.population < 0.9*old.population then
        set new.population = old.population;
    end if;
end;$
delimiter ;
-------------------tp4-5 PS calcul a partir nom continent-----------
------------------------totalPopulation-----------------------------
delimiter $
drop procedure if exists totalPopulation;
create procedure totalPopulation(nomContinent varchar(10))
    begin
        declare regionNom varchar(50);
        declare fincurs1 boolean default 0;
        declare curs1 cursor for 
                            select region
                            from country
                            where continent = nomContinent
                            group by region;
        declare continue handler for not found set fincurs1 = 1;
        open curs1;
        fetch curs1 into regionNom;
        while (not fincurs1) do
            call totalPopulationRegion(regionNom);
            fetch curs1 into regionNom;
        end while;
        close curs1;
    end; $   
delimiter ;

call totalPopulation('Asia');
----------------------totalPopulationRegion--------------------------
delimiter $
drop procedure if exists totalPopulationRegion;
create procedure totalPopulationRegion(regionNom varchar(50))
    begin
        declare totalPopulation decimal(20, 2);
        declare onePopulation decimal(20, 2);
        declare fincurs2 boolean default 0;
        declare curs2 cursor for 
                            select population
                            from country
                            where region = regionNom;
        declare continue handler for not found set fincurs2 = 1;
        open curs2;
        fetch curs2 into onePopulation;
        while (not fincurs2) do
            set totalPopulation = totalPopulation + onePopulation;
            fetch curs2 into onePopulation;
        end while;
        close curs2;
        select regionNom,totalPopulation;
    end; $   
delimiter ;   

------------tnbr langues # parlé par pays dans un continent------------
delimiter $
drop procedure if exists totalLangueParle;
create procedure totalLangueParle(nomContinent varchar(10))
    begin
        declare nomCountry nvarchar(20);
        declare codeCountry nvarchar(3);
        declare fincurs3 boolean default 0;
        declare curs3 cursor for 
                            select name, code
                            from country
                            where continent = nomContinent
                            group by name, code;
        declare continue handler for not found set fincurs3 = 1;
        open curs3;
        fetch curs3 into nomCountry,codeCountry;
        while (not fincurs3) do
            call totalLangueParleParPays(nomCountry, codeCountry);
            fetch curs3 into nomCountry, codeCountry;
        end while;
        close curs3;
    end; $   
delimiter ;
call totalLangueParle('Asia');
----------------------nbr langues # parlé par pays--------------------
delimiter $
drop procedure if exists nbreLangueContinent;
create procedure totalLangueParleParPays(nomCountry varchar(20), codeCountry nvarchar(3))
    begin
        declare nbreLanguePays int default 0;
        declare langue varchar(20);
        declare fincurs4 boolean default 0;
        declare curs4 cursor for 
                            select language
                            from countrylanguage
                            where countrycode = codeCountry;
        declare continue handler for not found set fincurs4 = 1;
        open curs4;
        fetch curs4 into langue;
        while (not fincurs4) do
            set nbreLanguePays = nbreLanguePays + 1;
            fetch curs4 into langue;
        end while;
        close curs4;
        select nomCountry,nbreLanguePays;
    end; $   
delimiter ; 
drop procedure totalLangueParleParPays;
call totalLangueParleParPays('China', 'CHN');
----------------nbr langues # parlé par continent--------------------
delimiter $
create procedure nbreLangueContinent(nomContinent varchar(20))
begin
    select count(distinct language) nbre_langue
    from  countrylanguage cl
    inner join country co on co.code = cl.countrycode
    where co.continent = nomContinent;
end; $
delimiter ;
call nbreLangueContinent('Asia');
--------------------collect langue par pays---------------------------
delimiter $
drop procedure if exists getLanguePays;
create procedure getLanguePays(codePays varchar(3))
begin
    declare langue varchar(20);
    declare fincurs5 boolean default 0;
    declare curs5 cursor for 
                            select language
                            from countrylanguage
                            where countrycode = codePays;
    declare continue handler for not found set fincurs5 = 1;
    open curs5;
    fetch curs5 into langue;
    while (not fincurs5) do
            if langue not in (select distinct nomlangue from mylangue) then
            insert into myLangue (nomLangue) values (langue);
        end if;
        fetch curs5 into langue;
    end while;
    close curs5;
end; $
delimiter ;
call getLanguePays('CHN');

----------------collect langue par continent-------------------------
delimiter $
drop procedure  if exists getLangueContinent;
create procedure getLangueContinent(nomContinent varchar(20))
begin
    declare codePays varchar(3);
    declare fincurs6 boolean default 0;
    declare curs6 cursor for 
                            select code
                            from country
                            where continent = nomContinent;
    declare continue handler for not found set fincurs6 = 1;
    drop table if exists myLangue;
    create temporary table myLangue (
        nomLangue nvarchar(20) primary key
    )engine=memory;
    open curs6;
    fetch curs6 into codePays;
    while (not fincurs6) do
        call getLanguePays(codePays);
        fetch curs6 into codePays;
    end while;
    close curs6;
    select count(nomLangue) from myLangue;
    drop table myLangue;
end; $
delimiter ;
call getLangueContinent('Asia');
-----------------PS continent limitevie taux_accroissement-------------
-------------pays anglophone augment la population par taux------------
delimiter $
DROP procedure IF EXISTS augmentPopulationParTauxAnglophone;
create procedure augmentPopulationParTauxAnglophone
            (nomContinent varchar(20),nomLangue varchar(20), limitevie int, taux float(3,1))
begin
    declare codePays varchar(3);
    declare fincurs7 boolean default 0;
    declare curs7 cursor for 
                            select distinct code
                            from country
                            where continent = nomContinent;
    declare continue handler for not found set fincurs7 = 1;
    DROP TABLE IF EXISTS myCodePaysLangue;
    create temporary table myCodePaysLangue (
        codePaysTable varchar(3) not null
    );
    call getCodePaysLanguage(nomLangue);
    open curs7;
    fetch curs7 into codePays;
    while (not fincurs7) do
        if codePays in (select distinct codePaysTable from myCodePaysLangue) then
            update country 
            set population = population*(1+taux/100)
            where code = codePays;
            select codePays;
        end if;
        fetch curs7 into codePays;
    end while;
    close curs7;
    select distinct codePaysTable from myCodePaysLangue;
    drop table myCodePaysLangue;
end;$
delimiter ;
call augmentPopulationParTauxAnglophone('Asia', 'English', 74, 1);

-----------------------------PS get CodePays anglophone---------------------------
delimiter $
drop procedure if exists getCodePaysLanguage;
create procedure getCodePaysLanguage (nomLangue varchar(20))
begin
    declare codePays varchar(3);
    declare fincurs8 boolean default 0;
    declare curs8 cursor for 
                            select distinct countrycode
                            from countrylanguage
                            where language = nomLangue;
    declare continue handler for not found set fincurs8 = 1;
    open curs8;
    fetch curs8 into codePays;
    while (not fincurs8) do
        insert into myCodePaysLangue (codePaysTable) values (codePays);
        fetch curs8 into codePays;
    end while;
    close curs8;
end;$
delimiter ;
call getCodePaysLanguage('English');
--Dire quel est le nombre de locuteurs parlant l’anglais dans les villes du pays et ------
-------------------------donner le nombre de ces villes-----------------------------------
-----------------------------PS getNbreVillePopulationAnglophoneDePays---------------------------
delimiter $
drop procedure if exists getNbreVillePopulationAnglophoneDePays;
create procedure getNbreVillePopulationAnglophoneDePays
    (nomContinent varchar(20), nomLangue varchar(20), limitevie int, taux float(3,1))
begin
    declare fincurs9 boolean default 0;
    declare codePays varchar(3);
    declare nomPays varchar(50);
    declare tauxAnglophone decimal(4,1) default 0;
    declare nbreAnglophoneCity int default 0;
    declare countCity int default 0;
    declare curs9 cursor for 
                            select distinct code, name 
                            from country
                            where continent = nomContinent;
    declare continue handler for not found set fincurs9 = 1;
    drop table if exists myTable;
    create temporary table myTable(
        nomPays varchar(50) not null,
        populationAnglophone int not null,
        nbreVille int default 0
    );
    open curs9;
    fetch curs9 into codePays, nomPays;
    while (not fincurs9) do 
        set nbreAnglophoneCity = 0;
        set countCity = 0;
        call nbreVilleDePays(codePays, countCity);
        call getTauxAnglophoneDePays(codePays, tauxAnglophone);
        call getNbreParlantAnglophonePays(codePays, tauxAnglophone, nbreAnglophoneCity);
        insert into myTable (nomPays, populationAnglophone, nbreVille)
            values (nomPays, nbreAnglophoneCity, countCity);
        fetch curs9 into codePays, nomPays;
    end while;
    close curs9;
    select * from myTable where populationAnglophone>0;
    drop table myTable;
end;$
delimiter ;
call getNbreVillePopulationAnglophoneDePays('Asia', 'English', 74, 1);
-----------------------------PS get nbreParlantAnglophonePays---------------------------
delimiter $
drop procedure if exists getNbreParlantAnglophonePays;
create procedure getNbreParlantAnglophonePays 
        (codePays varchar(3), tauxAnglophone decimal(4,1), inout nbreAnglophoneCity int)
begin
    declare fincurs10 boolean default 0;
    declare populationCity int default 0;
    declare curs10 cursor for 
                            select distinct population
                            from city
                            where Countrycode = codePays;
    declare continue handler for not found set fincurs10 = 1;
    open curs10;
    fetch curs10 into populationCity;
    while (not fincurs10) do
        set nbreAnglophoneCity = nbreAnglophoneCity + populationCity*tauxAnglophone/100;
        fetch curs10 into populationCity;
    end while;
    close curs10;
end;$
delimiter ;

-----------------------------PS get nbreVilleDePays---------------------------
delimiter $
drop procedure if exists nbreVilleDePays;
create procedure nbreVilleDePays (codePays varchar(3), inout countCity int)
begin
    declare fincurs11 boolean default 0;
    declare idCity int default 0;
    declare curs11 cursor for 
                            select distinct ID
                            from city
                            where Countrycode = codePays;
    declare continue handler for not found set fincurs11 = 1;
    open curs11;
    fetch curs11 into idCity;
    while (not fincurs11) do
        set countCity = countCity + 1;
        fetch curs11 into idCity;
    end while;
    close curs11;
end;$
delimiter ;

-----------------------------PS getTauxAnglophoneDePays---------------------------
delimiter $
drop procedure if exists getTauxAnglophoneDePays;
create procedure getTauxAnglophoneDePays 
            (codePays varchar(3), inout tauxAnglophone decimal(4,1))
begin
    declare fincurs12 boolean default 0;
    declare monTaux decimal(4,1) default 0;
    declare curs12 cursor for 
                            select distinct percentage
                            from countrylanguage
                            where Countrycode = codePays;
    declare continue handler for not found set fincurs12 = 1;
    open curs12;
    fetch curs12 into monTaux;
    while (not fincurs12) do
        set tauxAnglophone = monTaux;
        fetch curs12 into monTaux;
    end while;
    close curs12;
end;$
delimiter ;

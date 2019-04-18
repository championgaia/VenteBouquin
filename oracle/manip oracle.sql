-------------------------manip oracle sql -----------------------------
----------------------------drop table if exists----------------------
BEGIN
      EXECUTE IMMEDIATE 'DROP TABLE test';
  EXCEPTION
      WHEN OTHERS THEN NULL;
  END;
  /
  ;
------------------------------create champs identity autoincrement----------
CREATE TABLE test (
  ID INTEGER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL,
  NOM varchar(20)
);
insert into test (nom, prenom) values ('NGuyen', 'viet');
insert into test (nom, prenom) values ('Viet', 'nguyen');
------------------------------truncate table----------------------------
truncate table test;
-------------------------------add colume table-----------------------
--precondition table vide
alter table test add prenom varchar(20) not null;
-------------------------------modify une colonne dans la table--------
alter table test modify nom varchar(50) not null;
alter table city modify id INTEGER GENERATED ALWAYS AS IDENTITY (START WITH 1 INCREMENT BY 1) NOT NULL
drop table test;
-------------------modify affichage longeur de la ligne-------------------
set linesize valeur;
-------------------get datetime-------------------------

SELECT current_date
      FROM DUAL;
SELECT CURRENT_TIMESTAMP
      FROM DUAL;
SELECT LOCALTIMESTAMP
      FROM DUAL;
------------------------PS------------------------------
Create or replace procedure myProc
as 
def sqlString varchar2(1000);
BEGIN
  sqlString := 'select Id from city where Id = 10;';
  execute IMMEDIATE sqlString;
END myProc;
exec myProc;
------------------------PS------------------------------
Create or Replace PROCEDURE Getmarketdetails
AS
temp varchar(100);
BEGIN
  SELECT name
  INTO temp 
  from  city
  where id = 10;
  DBMS_OUTPUT.PUT_LINE(temp);
END Getmarketdetails;
exec Getmarketdetails;
------------------------Function return number------------------------------
Create or replace function myFunc(n in number)
return number
as 
somme int;
BEGIN
  somme := n*n;
  return somme;
END myFunc;
------------------------Function return datetime------------------------------
Create or replace function myFuncDate
return date
as 
myDate date;
BEGIN
  SELECT sysdate into myDate
      FROM DUAL;
  return myDate;
END myFuncDate;
select myFuncDate() from dual;
  
------------------------Function return sum d'un table------------------------------
create or replace type t_numbers as table of number;
/
create or replace function sum_plsql (p_numbers t_numbers) return number
as
  rv number := 0;
begin
  for n in 1..p_numbers.count
  loop
    rv := rv + p_numbers(n);
  end loop;
  return rv;
end;
/
-----------------------------------------------------------------
CREATE or replace FUNCTION factorielle(n IN NUMBER)
RETURN NUMBER
IS BEGIN
  if n=0 then return(1);
  else return((n*factorielle(n‐1)));
  end if;
END;

var x number
exec :x := factorielle(10);
select factorielle(10) from dual;
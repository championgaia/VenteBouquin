/****** Script de la commande SelectTopNRows à partir de SSMS  ******/
SELECT TOP (1000) [Id]
      ,[CustomerId]
      ,[Langage]
  FROM [NorthwindDB].[dbo].[CustomerLanguage]

  DELETE FROM CustomerLanguage


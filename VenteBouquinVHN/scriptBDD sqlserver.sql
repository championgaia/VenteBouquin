-------------------------------------------------------------------------------
--------------------------create dababase VenteBouquin-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('VenteBouquin') is not null
DROP DATABASE VenteBouquin
GO
CREATE DATABASE VenteBouquin
GO
-------------------------------------------------------------------------------
--------------------------use dababase VenteBouquin-------------------------
-------------------------------------------------------------------------------
USE VenteBouquin
GO
-------------------------------------------------------------------------------
--------------------------Create table Adresse-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('Adresse') is not null
DROP TABLE Adresse
GO

CREATE TABLE Adresse(
    IdAdresse INT IDENTITY(1,1),
    NumeroRue INT NOT NULL,
    NomRue NVARCHAR(50) NOT NULL,
    AdresseComplementaire NVARCHAR(250) NULL,
    NomVille NVARCHAR(50) NOT NULL,
    CodePostal NVARCHAR(10) NOT NULL,
    NomPays NVARCHAR(20) NOT NULL,
    CONSTRAINT cle_P_Adresse PRIMARY KEY (IdAdresse)
)

-------------------------------------------------------------------------------
--------------------------Create table LivreCategory-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('LivreCategory') is not null
DROP TABLE LivreCategory
GO

CREATE TABLE LivreCategory(
    IdCategory INT IDENTITY(1,1),
    NomCategory NVARCHAR(50) NOT NULL,
    CONSTRAINT cle_P_LivreCategory PRIMARY KEY (IdCategory)
)
-------------------------------------------------------------------------------
--------------------------Create table Promotion-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('Promotion') is not null
DROP TABLE Promotion
GO

CREATE TABLE Promotion(
    IdPromotion INT IDENTITY(1,1),
    PourcentagePromo DECIMAL(5,2) NOT NULL,
    DateDebut DATE NOT NULL,
    DateFin DATE NOT NULL,
    CONSTRAINT cle_P_Promotion PRIMARY KEY (IdPromotion)
)
-------------------------------------------------------------------------------
--------------------------Create table Description-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('Description') is not null
DROP TABLE Description
GO

CREATE TABLE Description(
    IdDescription INT IDENTITY(1,1),
    CodeISBN NVARCHAR(50) NOT NULL,
    Detail TEXT NULL,
    CONSTRAINT cle_P_Description PRIMARY KEY (IdDescription)
)
-------------------------------------------------------------------------------
--------------------------Create table Personne-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('Personne') is not null
DROP TABLE Personne
GO

CREATE TABLE Personne(
    IdPersonne INT IDENTITY(1,1),
    Nom NVARCHAR(50) NOT NULL,
    Prenom NVARCHAR(50) NOT NULL,
    DateNaissance Date NOT NULL,
    FkAdresse INT NOT NULL,
    CONSTRAINT cle_P_Personne PRIMARY KEY (IdPersonne),
    CONSTRAINT Cle_F_Personne_Adresse FOREIGN KEY (FkAdresse) REFERENCES Adresse(IdAdresse)
)
GO
CREATE UNIQUE INDEX index_Personne ON Personne (Nom, Prenom, DateNaissance)
GO
-------------------------------------------------------------------------------
--------------------------Create table Utilisateur-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('Utilisateur') is not null
DROP TABLE Utilisateur
GO

CREATE TABLE Utilisateur(
    IdUtilisateur INT IDENTITY(1,1),
	CodeUtilisateur NVARCHAR(250) not null,
    Login NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    FkPersonne INT NOT NULL,
    CONSTRAINT cle_P_Utilisateur PRIMARY KEY (IdUtilisateur),
    CONSTRAINT Cle_F_Utilisateur_Personne FOREIGN KEY (FkPersonne) REFERENCES Personne(IdPersonne)
)
-------------------------------------------------------------------------------
--------------------------Create table Livre-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('Livre') is not null
DROP TABLE Livre
GO

CREATE TABLE Livre(
    IdLivre INT IDENTITY(1,1),
    CodeISBN NVARCHAR(50) NOT NULL,
    NomLivre NVARCHAR(250) NOT NULL,
    Auteur NVARCHAR(50) NOT NULL,
    Editeur NVARCHAR(50) NOT NULL,
    CoverImage NVARCHAR(250) NULL,
    Prix DECIMAL(10,2) NOT NULL,
    FkDescription INT NULL,
    FkLivreCategory INT NOT NULL,
    CONSTRAINT cle_P_Livre PRIMARY KEY (IdLivre),
    CONSTRAINT Cle_F_Livre_Adresse FOREIGN KEY (FkLivreCategory) REFERENCES LivreCategory(IdCategory),
    CONSTRAINT cle_F_Livre_Description FOREIGN KEY (FkDescription) REFERENCES Description(IdDescription)
)

-------------------------------------------------------------------------------
--------------------------Create table Commande-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('Commande') is not null
DROP TABLE Commande
GO

CREATE TABLE Commande(
    IdCommande INT IDENTITY(1,1),
    PrixTotal DECIMAL (20,2) NOT NULL,
    FkUtilisateur INT NOT NULL,
    CONSTRAINT cle_P_Commande PRIMARY KEY (IdCommande),
    CONSTRAINT Cle_F_Commande_Utilisateur FOREIGN KEY (FkUtilisateur) REFERENCES Utilisateur(IdUtilisateur)
)
-------------------------------------------------------------------------------
--------------------------Create table LigneDeCommande-------------------------
-------------------------------------------------------------------------------
IF OBJECT_ID('LigneDeCommande') is not null
DROP TABLE LigneDeCommande
GO

CREATE TABLE LigneDeCommande(
    IdLigneDeCommande INT IDENTITY(1,1),
    Quantite INT NOT NULL,
    FkPromotion INT NOT NULL,
    FkLivre INT NOT NULL,
    FkCommande INT NOT NULL,
    CONSTRAINT cle_P_LigneDeCommande PRIMARY KEY (IdLigneDeCommande),
    CONSTRAINT Cle_F_LigneDeCommande_Livre FOREIGN KEY (FkLivre) REFERENCES Livre(IdLivre),
    CONSTRAINT Cle_F_LigneDeCommande_Commande FOREIGN KEY (FkCommande) REFERENCES Commande(IdCommande),
    CONSTRAINT Cle_F_LigneDeCommande_Promotion FOREIGN KEY (FkPromotion) REFERENCES Promotion(IdPromotion)
)
-------------------------------------------------------------------------------
--------------------------Insert donnes table LivreCategory-------------------------
-------------------------------------------------------------------------------
INSERT INTO LivreCategory (NomCategory) VALUES ('Actu, Politique et Société'), ('Adolescents'), ('Art, Musique et Cinéma'),
            ('Dande dessinées'), ('Calendriers et Agendas'), ('Cuisine et Vins'), ('Dicionnaires, langues et enclopédis'),
            ('Droit'), ('Entreprise et Bourse'), ('Etudes supérieures'), ('Famille et bien-être'), ('Fantasy et Terreur'),
            ('Histoire'), ('Humour'), ('Informatique et Internet'), ('Livre pour enfant'), ('Loisir créatifs, décoration et passions'),
            ('Nature et animaux'), ('Religion et Spiritualité'), ('Romance'), ('Science-Fiction'), ('Sciences, Techniques et Medecine'),
            ('Sciences humaines'), ('Scolaire et Parascolaire'), ('Sport'), ('Tourisme et voyage');
-------------------------------------------------------------------------------
--------------------------Insert donnes table Adresse-------------------------
-------------------------------------------------------------------------------
INSERT INTO Adresse (NumeroRue, NomRue, AdresseComplementaire,
    NomVille, CodePostal, NomPays) VALUES
    (37, 'Bd Jourdan', 'chambre 205 RDC', 'Paris', '75014', 'France'),
    (12, 'rue Nationale', 'appt 75', 'Toulouse', '31000', 'France'),
    (11, 'Allée du Professeur Camille Soula', 'chambre 205', 'Toulouse', '31400', 'France'),
    (1, 'Impasse André Marfaing', 'appt 74', 'Toulouse', '31000', 'France'),
    (27, 'Bd Jourdan', 'appt 74 RDC', 'Paris', '75014', 'France'),
    (17, 'rue Dupuytren', 'chamre 3', 'Lille', '59800', 'France'),
    (290, 'Quartier de Belles Portes', 'appt 74', 'Hérouville St Clair', '14200', 'France'),
    (8, 'Allée de la Glacière', 'appt 74 Res Le Parc de Lebisey', 'Hérouville St Clair', '14200', 'France'),
    (14, 'Rue Championnet', '', 'Paris', '75018', 'France');
-------------------------------------------------------------------------------
--------------------------Insert donnes table Promotion-------------------------
-------------------------------------------------------------------------------
INSERT INTO Promotion (PourcentagePromo, DateDebut, DateFin) VALUES
    (10, '2019/01/01', '2019/02/01'),(20, '2019/02/01', '2019/03/01'),
    (30, '2019/03/01', '2019/04/01'),(40, '2019/04/01', '2019/05/01'),
    (50, '2019/05/01', '2019/06/01'),(60, '2019/06/01', '2019/07/01'),
    (70, '2019/07/01', '2019/08/01'),(80, '2019/08/01', '2019/09/01');
-------------------------------------------------------------------------------
--------------------------Insert donnes table Desciption-------------------------
-------------------------------------------------------------------------------
INSERT INTO Description (CodeISBN, Detail) VALUES
    ('9782075094504', 'Découvrez ou redécouvrez le premier volume de l histoire de Harry, décliné en quatre précieuses
     éditions collector cartonnées, aux couleurs des célèbres maisons de la plus grande école de magie 
     de tous les temps. Avec de passionnants bonus illustrés inédits pour tout savoir sur votre maison :
      sa salle commune, ses étudiants célèbres, ses directeurs notables, un quiz sur Poudlard et bien d 
      autres surprises.'),
    ('9782075117548', 'Une rentrée fracassante en voiture volante, une étrange malédiction qui s abat sur les élèves, 
    cette deuxième année à l école des sorciers ne s annonce pas de tout repos! Entre les cours de 
    potion magique, les matches de Quidditch et les combats de mauvais sorts, Harry et ses amis Ron 
    et Hermione trouveront-ils le temps de percer le mystère de la Chambre des Secrets?'),
    ('9782075089302', 'Sirius Black, le dangereux criminel qui s est échappé de la forteresse d Azkaban, recherche 
    Harry Potter. C est donc sous bonne garde que l apprenti sorcier fait sa troisième rentrée. 
    Au programme : des cours de divination, la fabrication d une potion de Ratatinage, le dressage 
    des hippogriffes... Mais Harry est-il vraiment à l abri du danger qui le menace ?'),
    ('9782070585205', 'Harry Potter a quatorze ans et entre en quatrième année à Poudlard. Une grande nouvelle attend
     Harry, Ron et Hermione à leur arrivée : la tenue d un tournoi de magie exceptionnel entre les 
     plus célèbres écoles de sorcellerie. Déjà les délégations étrangères font leur entrée. Harry se 
     réjouit... Trop vite. Il va se trouver plongé au cœur des événements les plus dramatiques qu il 
     ait jamais eu à affronter.'),
    ('9782070585212', 'À quinze ans, Harry entre en cinquième année à Poudlard, mais il n a jamais été si anxieux. 
    L adolescence, la perspective des examens et ces étranges cauchemars... Car Celui-Dont-On-Ne-Doit-Pas-Prononcer-Le-Nom
     est de retour. Le ministère de la Magie semble ne pas prendre cette menace au sérieux, contrairement 
     à Dumbledore. La résistance s organise alors autour de Harry qui va devoir compter sur le courage et
      la fidélité de ses amis de toujours...'),
    ('9782070585229', 'Dans un monde de plus en plus inquiétant, Harry se prépare à retrouver Ron et Hermione. Bientôt, 
    ce sera la rentrée à Poudlard, avec les autres étudiants de sixième année. Mais pourquoi Dumbledore 
    vient-il en personne chercher Harry chez les Dursley ? Dans quels extraordinaires voyages au cœur de 
    la mémoire va-t-il l entraîner ?'),
    ('9782070585236', 'Cette année, Harry a dix-sept ans et ne retourne pas à Poudlard. Avec Ron et Hermione, il se consacre 
    à la dernière mission confiée par Dumbledore. Mais le Seigneur des Ténèbres règne en maître. Traqués, 
    les trois fidèles amis sont contraints à la clandestinité. D épreuves en révélations, le courage, les 
    choix et les sacrifices de Harry seront déterminants dans la lutte contre les forces du Mal.'),
    ('9782070612888','Dans les vertes prairies de la Comté, les Hobbits, ou Semi-hommes, vivaient en paix… Jusqu au jour fatal où l un
    d entre eux, au cours de ses voyages, entra en possession de l Anneau Unique aux immenses pouvoirs. Pour le reconquérir, Sauron, 
    le seigneur ténébreux, va déchaîner toutes les forces du Mal. Frodon, le Porteur de l Anneau, Gandalf, le magicien, et leurs 
    intrépides compagnons réussiront-ils à écarter la menace qui pèse sur la Terre du Milieu ?'),
    ('9782070612895','Dispersée dans les terres de l Ouest, la Communauté de l Anneau affronte les périls de la guerre, tandis
    que Frodon, accompagné du fidèle Samsagace, poursuit une quête presque désespérée : détruire l Anneau Unique en le jetant 
    dans les crevasses d Oradruir, la Montagne du destin. Mais aux frontières du royaume de Mordor, une mystérieuse créature 
    les épie… pour les perdre ou pour les sauver?'),
    ('9782070612901','Le royaume de Gondor s arme contre Sauron, le seigneur des ténèbres, qui veut asservir tous les peuples
    libres, hommes et elfes, nains et hobbits. Mais la vaillance des soldats de Minas Tirith ne peut rien désormais contre la 
    puissance maléfique de Mordor. Un fragile espoir, toutefois, demeure : le Porteur de l Anneau, jour après jour, s approche
    de la montagne où brûle le feu du destin, seul capable de détruire l Anneau Unique et de provoquer la chute de Sauron…'),
    ('9782070645138','Edmond Dantès, un jeune marin, doit épouser la belle Mercédès. Accusé à tort de complot contre le roi, 
    il est enfermé dans la terrible prison du château d If. Quatorze ans plus tard, il parvient à s évader avec la complicité 
    de l abbé Faria qui lui lègue une immense fortune. Devenu le comte de Monte-Cristo, Edmond n a plus qu une obsession : 
    tisser les fils d une implacable vengeance.')
    ;

-------------------------------------------------------------------------------
--------------------------Insert donnes table Personne-------------------------
-------------------------------------------------------------------------------
INSERT INTO Personne (Nom, Prenom, DateNaissance, FkAdresse) VALUES 
    ('Einstein', 'Albert', '1912/02/25', 9), ('Curie', 'Marie', '1889/01/15', 8),
    ('Lavoisier', 'François', '1902/02/21', 7), ('Curie', 'Piere', '1880/09/15', 6),
    ('Darwin', 'Charles', '1602/02/12', 5), ('Newton', 'David', '1580/06/15', 4),
    ('Edison', 'James', '1902/02/21', 3), ('Hart', 'Joe', '1985/09/15', 2);
-------------------------------------------------------------------------------
--------------------------Insert donnes table Livre-------------------------
-------------------------------------------------------------------------------
INSERT INTO Livre(CodeISBN, NomLivre, Auteur, Editeur, Prix, FkDescription, FkLivreCategory) VALUES
    ('9782075094504', 'Harry Potter à l école des sorciers', 'J. K. Rowling', 'Poufsouffle', 10, 1, 16),
    ('9782075117548', 'Harry Potter et la Chambre des Secrets', 'J. K. Rowling', 'Gryffondor', 11, 2, 16),
    ('9782075089302', 'Harry Potter et le prisonnier d Azkaban', 'J. K. Rowling', 'Gryffondor', 12, 3, 16),
    ('9782070585205', 'Harry Potter et la Coupe de Feu', 'J. K. Rowling', 'Gryffondor', 13, 4, 16),
    ('9782070585212', 'Harry Potter et l Ordre du Phénix', 'J. K. Rowling', 'Gryffondor', 14, 5, 16),
    ('9782070585229', 'Harry Potter et le Prince de Sang-Mêlé', 'J. K. Rowling', 'Gryffondor', 15, 6, 16),
    ('9782070585236', 'Harry Potter et les Reliques de la Mort', 'J. K. Rowling', 'Gryffondor', 16, 7, 16),
    ('9782070612888', 'Le Seigneur des Anneaux Tome 1 - La Communauté de lAnneau', 'J. R. R. Tolkien', 'Gallimard Jeunesse', 8.7, 8, 12),
    ('9782070612895', 'Le Seigneur des Anneaux Tome 2 - Les Deux Tours', 'J. R. R. Tolkien', 'Gallimard Jeunesse', 8.7, 9, 12),
    ('9782070612901', 'Le Seigneur des Anneaux Tome 3 - Le Retour du Roi', 'J. R. R. Tolkien', 'Gallimard Jeunesse', 8.7, 10, 12),
    ('9782070645138','Le comte de Monte-Cristo', 'Alexandre Dumas', 'Gallimard Jeunesse', 7.9, 11, 20)
    ;
-------------------------------------------------------------------------------
--------------------------PS GetCategory---------------------------------------
-------------------------------------------------------------------------------
IF (OBJECT_ID('GetCategory') IS NOT NULL) 
DROP PROC GetCategory 
GO
CREATE PROC GetCategory(@idCategory int = 0)
AS
	SELECT IdCategory, NomCategory 
	FROM LivreCategory
	WHERE IdCategory = @idCategory or @idCategory = 0
GO
-------------------------------------------------------------------------------
--------------------------PS GetLivre---------------------------------------
-------------------------------------------------------------------------------
IF (OBJECT_ID('GetLivre') IS NOT NULL) 
DROP PROC GetLivre 
GO
CREATE PROC GetLivre(@idCategory int = 0, @codeISBN nvarchar(50)='0')
AS
	SELECT lc.IdCategory, lc.NomCategory,
		l.Auteur, l.CodeISBN, l.CoverImage, l.Editeur, l.IdLivre, l.NomLivre, l.Prix,
		d.IdDescription, d.Detail 
	FROM LivreCategory lc
	inner join Livre l on l.FkLivreCategory = lc.IdCategory
	inner join Description d on d.IdDescription = l.FkDescription
	WHERE l.CodeISBN = @codeISBN or (IdCategory = @idCategory and @codeISBN = 0)  or @idCategory = 0
GO
-------------------------------------------------------------------------------
--------------------------PS GetCommande---------------------------------------
-------------------------------------------------------------------------------
IF (OBJECT_ID('GetCommande') IS NOT NULL) 
DROP PROC GetCommande 
GO
CREATE PROC GetCommande(@idCommande int = 0, @idPayeur nvarchar(50)=0)
AS
	SELECT c.IdCommande, c.PrixTotal, u.CodeUtilisateur, u.IdUtilisateur,
			p.IdPersonne, p.Nom, p.Prenom, p.DateNaissance
	FROM Commande c
	inner join Utilisateur u on u.IdUtilisateur = c.FkUtilisateur
	inner join Personne p on u.FkPersonne = p.IdPersonne
	WHERE c.IdCommande = @idCommande or (@idCommande = 0 and u.IdUtilisateur = @idPayeur)
		or (@idCommande =0 and @idPayeur = 0)
GO
-------------------------------------------------------------------------------
--------------------------PS GetLigneCommande---------------------------------------
-------------------------------------------------------------------------------
IF (OBJECT_ID('GetLigneCommande') IS NOT NULL) 
DROP PROC GetLigneCommande 
GO
CREATE PROC GetLigneCommande(@idCommande int = 0, @idLigneDeCommande int = 0)
AS
	SELECT c.IdCommande, c.PrixTotal, lc.IdLigneDeCommande, lc.Quantite,
			l.CodeISBN, l.Prix, l.IdLivre, p.IdPromotion, p.PourcentagePromo
	FROM Commande c
	inner join LigneDeCommande lc on lc.FkCommande = c.IdCommande
	inner join Livre l on l.IdLivre = lc.FkCommande
	inner join Promotion p on p.IdPromotion = lc.FkPromotion
	WHERE lc.IdLigneDeCommande = @idLigneDeCommande or 
	(c.IdCommande = @idCommande and @idLigneDeCommande = 0)
GO
-------------------------------------------------------------------------------
--------------------------PS GetPersonne---------------------------------------
-------------------------------------------------------------------------------
IF (OBJECT_ID('GetPersonne') IS NOT NULL) 
DROP PROC GetPersonne 
GO
CREATE PROC GetPersonne(@idPersonne int = 0)
AS
	SELECT p.IdPersonne, p.Nom, p.Prenom, p.DateNaissance, p.FkAdresse,
			a.NumeroRue, a.NomRue, a.NomVille, a.CodePostal,  a.NomPays, a.AdresseComplementaire
	FROM  Personne p
	inner join Adresse a on a.IdAdresse = p.FkAdresse 
	WHERE p.IdPersonne = @idPersonne or @idPersonne = 0
GO
-------------------------------------------------------------------------------
--------------------------PS GetPayeur---------------------------------------
-------------------------------------------------------------------------------
IF (OBJECT_ID('GetPayeur') IS NOT NULL) 
DROP PROC GetPayeur 
GO
CREATE PROC GetPayeur(@idPayeur int = 0, @codeUtilisateur int ='0')
AS
	SELECT p.IdPersonne, p.Nom, p.Prenom, p.DateNaissance, p.FkAdresse,
			u.IdUtilisateur, u.CodeUtilisateur
	FROM  Personne p
	inner join Utilisateur u on u.FkPersonne = p.IdPersonne
	WHERE (u.IdUtilisateur = @idPayeur and @codeUtilisateur ='0') or
		(u.CodeUtilisateur = @codeUtilisateur and @idPayeur =0) or
		(@idPayeur = 0 and @codeUtilisateur ='0')
GO

     
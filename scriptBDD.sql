-------------------------------------------------------------------------------
--------------------------create dababase VenteBouquin-------------------------
-------------------------------------------------------------------------------
DROP DATABASE IF EXISTS VenteBouquin;
CREATE DATABASE VenteBouquin;
-------------------------------------------------------------------------------
--------------------------use dababase VenteBouquin-------------------------
-------------------------------------------------------------------------------
use VenteBouquin;
-------------------------------------------------------------------------------
--------------------------Create table Adresse-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS Adresse;

CREATE TABLE Adresse(
    IdAdresse INT AUTO_INCREMENT,
    NumeroRue INT NOT NULL,
    NomRue VARCHAR(50) NOT NULL,
    AdresseComplementaire VARCHAR(250) NULL,
    NomVille VARCHAR(50) NOT NULL,
    CodePostal VARCHAR(10) NOT NULL,
    NomPays VARCHAR(20) NOT NULL,
    CONSTRAINT cle_P_Adresse PRIMARY KEY (IdAdresse)
)engine=innoDB;
-------------------------------------------------------------------------------
--------------------------Create table LivreCategory-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS LivreCategory;

CREATE TABLE LivreCategory(
    IdCategory INT AUTO_INCREMENT,
    NomCategory VARCHAR(50) NOT NULL,
    CONSTRAINT cle_P_LivreCategory PRIMARY KEY (IdCategory)
)engine=innoDB;
-------------------------------------------------------------------------------
--------------------------Create table Promotion-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS Promotion;

CREATE TABLE Promotion(
    IdPromotion INT AUTO_INCREMENT,
    PourcentagePromo DECIMAL(5,2) NOT NULL,
    DateDebut DATE NOT NULL,
    DateFin DATE NOT NULL,
    CONSTRAINT cle_P_Promotion PRIMARY KEY (IdPromotion)
)engine=innoDB;
-------------------------------------------------------------------------------
--------------------------Create table Description-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS Description;

CREATE TABLE Description(
    IdDescription INT AUTO_INCREMENT,
    CodeISBN VARCHAR(50) NOT NULL,
    Detail TEXT NULL,
    CONSTRAINT cle_P_Description PRIMARY KEY (IdDescription)
)engine=innoDB;
-------------------------------------------------------------------------------
--------------------------Create table Personne-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS Personne;

CREATE TABLE Personne(
    IdPersonne INT AUTO_INCREMENT,
    Nom VARCHAR(50) NOT NULL,
    Prenom VARCHAR(50) NOT NULL,
    DateNaissance Date NOT NULL,
    FkAdresse INT NOT NULL,
    CONSTRAINT cle_P_Personne PRIMARY KEY (IdPersonne),
    CONSTRAINT Cle_F_Personne_Adresse FOREIGN KEY (FkAdresse) REFERENCES Adresse(IdAdresse)
)engine=innoDB;
-------------------------------------------------------------------------------
--------------------------Create table Utilisateur-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS Utilisateur;

CREATE TABLE Utilisateur(
    IdUtilisateur INT AUTO_INCREMENT,
    Login VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Role VARCHAR(50) NOT NULL,
    FkPersonne INT NOT NULL,
    CONSTRAINT cle_P_Utilisateur PRIMARY KEY (IdUtilisateur),
    CONSTRAINT Cle_F_Utilisateur_Personne FOREIGN KEY (FkPersonne) REFERENCES Personne(IdPersonne)
)engine=innoDB;
-------------------------------------------------------------------------------
--------------------------Create table Livre-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS Livre;

CREATE TABLE Livre(
    IdLivre INT AUTO_INCREMENT,
    CodeISBN VARCHAR(50) NOT NULL,
    NomLivre VARCHAR(50) NOT NULL,
    Auteur VARCHAR(50) NOT NULL,
    Editeur VARCHAR(50) NOT NULL,
    CoverImage VARCHAR(250) NULL,
    Prix DECIMAL(10,2) NOT NULL,
    FkDescription INT NULL,
    FkLivreCategory INT NOT NULL,
    CONSTRAINT cle_P_Livre PRIMARY KEY (IdLivre),
    CONSTRAINT Cle_F_Livre_Adresse FOREIGN KEY (FkLivreCategory) REFERENCES LivreCategory(IdCategory),
    CONSTRAINT cle_F_Livre_Description FOREIGN KEY (FkDescription) REFERENCES Description(IdDescription)
)engine=innoDB;

-------------------------------------------------------------------------------
--------------------------Create table Commande-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS Commande;

CREATE TABLE Commande(
    IdCommande INT AUTO_INCREMENT,
    PrixTotal DECIMAL (20,2) NOT NULL,
    FkUtilisateur INT NOT NULL,
    CONSTRAINT cle_P_Commande PRIMARY KEY (IdCommande),
    CONSTRAINT Cle_F_Commande_Utilisateur FOREIGN KEY (FkUtilisateur) REFERENCES Utilisateur(IdUtilisateur)
)engine=innoDB;
-------------------------------------------------------------------------------
--------------------------Create table LigneDeCommande-------------------------
-------------------------------------------------------------------------------
DROP TABLE IF EXISTS LigneDeCommande;

CREATE TABLE LigneDeCommande(
    IdLigneDeCommande INT AUTO_INCREMENT,
    Quantite INT NOT NULL,
    FkPromotion INT NOT NULL,
    FkLivre INT NOT NULL,
    FkCommande INT NOT NULL,
    CONSTRAINT cle_P_LigneDeCommande PRIMARY KEY (IdLigneDeCommande),
    CONSTRAINT Cle_F_LigneDeCommande_Livre FOREIGN KEY (FkLivre) REFERENCES Livre(IdLivre),
    CONSTRAINT Cle_F_LigneDeCommande_Commande FOREIGN KEY (FkCommande) REFERENCES Commande(IdCommande),
    CONSTRAINT Cle_F_LigneDeCommande_Promotion FOREIGN KEY (FkPromotion) REFERENCES Promotion(IdPromotion)
)engine=innoDB;
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
    (10, "2019/01/01", "2019/02/01"),(20, "2019/02/01", "2019/03/01"),
    (30, "2019/03/01", "2019/04/01"),(40, "2019/04/01", "2019/05/01"),
    (50, "2019/05/01", "2019/06/01"),(60, "2019/06/01", "2019/07/01"),
    (70, "2019/07/01", "2019/08/01"),(80, "2019/08/01", "2019/09/01");
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
    choix et les sacrifices de Harry seront déterminants dans la lutte contre les forces du Mal.');

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
    ('9782070585236', 'Harry Potter et les Reliques de la Mort', 'J. K. Rowling', 'Gryffondor', 16, 7, 16);





     
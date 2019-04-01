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
    NomLIvre VARCHAR(50) NOT NULL,
    Auteur VARCHAR(50) NOT NULL,
    Editeur VARCHAR(50) NOT NULL,
    Prix DECIMAL(10,2) NOT NULL,
    Description VARCHAR(250) NULL,
    FkLivreCategory INT NOT NULL,
    CONSTRAINT cle_P_Livre PRIMARY KEY (IdLivre),
    CONSTRAINT Cle_F_Livre_Adresse FOREIGN KEY (FkLivreCategory) REFERENCES LivreCategory(IdCategory)
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
INSERT INTO LivreCategory (NomCategory) values ('Actu, Politique et Société'), ('Adolescents'), ('Art, Musique et Cinéma'),
            ('Dande dessinées'), ('Calendriers et Agendas'), ('Cuisine et Vins'), ('Dicionnaires, langues et enclopédis'),
            ('Droit'), ('Entreprise et Bourse'), ('Etudes supérieures'), ('Famille et bien-être'), ('Fantasy et Terreur'),
            ('Histoire'), ('Humour'), ('Informatique et Internet'), ('Livre pour enfant'), ('Loisir créatifs, décoration et passions'),
            ('Nature et animaux'), ('Religion et Spiritualité'), ('Romance'), ('Science-Fiction'), ('Sciences, Techniques et Medecine'),
            ('Sciences humaines'), ('Scolaire et Parascolaire'), ('Sport'), ('Tourisme et voyage');
            
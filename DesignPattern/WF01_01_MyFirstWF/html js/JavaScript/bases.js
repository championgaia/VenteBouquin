//--------------------
// 1- Commentaires
//--------------------

// permet de faire un commentaire sur 1 seule ligne

/*
  permet de faire des commentaires
  sur plusieurs lignes
*/


//--------------------
// 2- Affichage
//--------------------
document.write('mon premier message');  // affichage dans le navigateur

document.write('<h1>Les bases du JavaScript</h1>'); // on peut mettre des balises HTML : elles sont insérées directement dans le document HTML.

// Toutes les instructions en JS se terminent pas un ";".

// Les boîtes de dialogue :
/*alert('Bonjour !'); // affiche un message
confirm('Etes-vous sûr de vouloir quitter ?'); // boîte de dialogue avec des boutons "ok" et "annuler"
prompt('Quel est votre code postal ?');  // boîte de dialogue avec champ à remplir
*/

//--------------------
// 3- Variables
//--------------------
document.write('<h2> Variables </h2>');
// Définition : une variable est un espace mémoire qui porte un nom et dans lequel on stocke une donnée, une valeur. Cette donnée peut être de n'importe quel type : chiffre, chaîne de caractères, élément du HTML...

// Déclaration d'une variable :
var maBoite; // mot clé var pour déclarer une variable. Caractères acceptés : de a à z, de A à Z, de 0 à 9 (jamais au début), et _ (jamais au début ni à la fin). Convention d'écriture : nomDeMaVariable (1er mot en minuscule, puis  une majuscule à la 1ère lettre de chaque mots).

// Affectation d'une variable :
maBoite = 10; // j'affecte la valeur 10 à la variable avec l'opérateur d'affection "=".

// On peut déclarer et affecter une variable simultanément :
var maBoite = 10; // nous retiendrons cette syntaxe

document.write(maBoite);  // pour afficher le contenu de notre variable, nous l'écrivons sans les quotes. Note : le JS est sensible à la casse. Il faut donc respecter les majuscules et minuscules.
document.write('<br>');

//----
// Déclarer et affecter plusieurs variables en même temps :
var prenom = 'Sylvie',
    nom = 'Robert',
    genre = 'féminin'; // on peut mettre un seul "var" pour déclarer plusieurs variables. Dans ce cas, elles sont séparées par une virgule. On les écrit à la ligne et on indente.

//----
// Changer la valeur d'une variable :
prenom = 'Pierre'; // Pierre remplace Sylvie
document.write(prenom);  // Pierre
document.write('<br>');

prenom = nom;  // on peut affecter le contenu d'une variable à une autre. Ici prenom contient désormais "Robert".
document.write(prenom); // Robert
document.write('<br>');

//----
/*var codePostal = prompt('Confirmez votre code postal !');
document.write(codePostal);*/


//--------------------
// 4- Types de données
//--------------------
document.write('<h2> Types de données </h2>');
// On commence par les 3 types dits primitifs.

// Le type numérique : number
var chiffre = 20;
console.log(typeof(chiffre)); // affiche dans la console (F12 > onglet console) le type de chiffre : number

// Le type chaîne de caractères : string
var texte = "une chaîne de caractères";
console.log(typeof(texte)); // string

var apostrophe = 'pour utiliser une apostrophe dans les quotes simples, il faut mettre un caractère d\'échappement'; // altGr + 8 pour faire l'anti-slash

var numero = '100'; // ici nous avons un string car les quotes ou les guillemets caractérisent le type string.

// Le type booléen : boolean
var choix = true;  // ou false
console.log(typeof(choix));  // boolean


//--------------------
// 5- Concaténation
//--------------------
document.write('<h2> Concaténation </h2>');
// On concatène (faire suivre de) des éléments avec le signe "+" en JS.

prenom = 'Bruce';
nom = 'WAYNE';
document.write('Bonjour ' + prenom + ' ' + nom + '<br>'); // concaténation de strings et de variables

//----
// Concaténation et affectation combinées :
var personne = 'Bruce';
personne += ' WAYNE';  // ajoute une valeur sans remplacer le contenu d'origine. La variable contient désormais 'Bruce WAYNE'.
document.write(personne);  // Bruce WAYNE



//--------------------
// 6- Opérateurs arithmétiques
//--------------------
document.write('<h2> Opérateurs arithmétiques </h2>');

var resultat;

resultat = 10 + 5; // addition
resultat = 10 - 5; // soustraction
resultat = 10 * 5; // multiplication
resultat = 10 / 5; // division
resultat = 10 % 5; // modulo = reste de la division entière (exemple : 10 billes réparties sur 5 joueurs, il m'en reste 0).

//----
// On peut appliquer les opérateurs aux variables :
var chiffre1 = 10,
    chiffre2 = 5;

resultat = chiffre1 + chiffre2; // resultat vaut 15
document.write(resultat + '<br>');  // 15

var chiffre3 = 10;
chiffre3 = chiffre3 + 5; // on ajoute la valeur 5 à chiffre3 puis on lui affecte le resultat de l'addition. Par convention cela s'écrit :
chiffre3 += 5; // chiffre3 vaut 20 ici
// fonctionne avec tous les opérateurs : += -= /= *= et %=

//----
// Incrémenter et décrémenter :
var i = 0;
i++;  // vaut 1. On ajoute 1 à i avec l'opérateur ++
i--;  // vaut 0. On retranche 1 à i avec l'opérateur --


//-------------
// Exercice :
// L'internaute achète sur votre site 0.8kg de pommes et 0.7kg de poires.
// Vous déclarez des variables pour chaque fruits et chaque poids.
// Puis vous affichez la phrase "Vous avez acheté des pommes et des poires pour un poids total de 1.5kg." où les 2 fruits et le poids total sont remplacés par des variables.

var nomFruit1 = 'pommes';
var nomFruit2 = 'poires';
var poidsPom = 0.8;
var poidsPoi = 0.7;

document.write('Vous avez acheté des ' + nomFruit1 + ' et des ' +nomFruit2 + ' pour un poids total de ' + (poidsPom + poidsPoi)    + ' kg.');


//--------------------
// 7- Structures conditionnelles
//--------------------
document.write('<h2> Structures conditionnelles </h2>');

var a = 10,
    b = 5,
    c = 2;

// if / else :
if (a > b) { // si a est supérieur à b, on entre dans le première d'accolades :
	document.write('a est supérieur à b <br>');
} else { // sinon, si l'expression est évalée à false, on entre dans le else :
	document.write('b est supérieur ou égal à a <br>');
}


// if avec l'opérateur AND qui s'écrit && :
if (a > b && b > c) { // si a est supérieur à b ET b supérieur à c, on entre dans les accolades :
	document.write('OK pour les 2 conditions <br>');
}

// if avec l'opérateur OR qui s'écrit || :
if (a == 9 || b > c) { // si a est égal à 9 OU b est supérieur à c, on entre dans les accolades :
	document.write('OK pour au moins une des deux conditions <br>');
}


// if / else if / else :
a = 10;
b = 5;
c = 2;

if (a == 8) {
	document.write('1- a est égal à 8 <br>');
} else if (a != 10) {  // si a est différent de 10. On entre dans le "else if" si le if précédent est false.
	document.write('2- a est différent de 10 <br>');
} else {
	document.write('3- Les 2 conditions précédentes sont fausses <br>');
}


// if avec opérateur not qui s'écrit "!" :
var capitaleFrance = 'Lille';

if (!(capitaleFrance == 'Paris')) { // le "!" est l'opérateur NOT qui est une négation inversant le sens du booléen : !True vaut false, et !False vaut true. Comme l'expression (capitaleFrance == 'Paris') vaut false, avec l'opérateur "!" notre expression devient true. On entre donc dans les accolades :
	document.write('La capitale indiqué NE correspond PAS à Paris <br>');
}


// Comparaison avec == et === :
var varA = 1,  // number
    varB = '1';  // string

if (varA == varB) { // on ne compare que les valeurs
	document.write('Egalité en valeur uniquement <br>');
}


if (varA === varB) { // on compare les valeurs ET les types. Dans cet exemple, on entre dans le else (nous avons un number vs un string)
	document.write('Egalité en valeur ET en type <br>');
} else {
	document.write('Différence en valeur OU en type <br>');
}

//-----
// Condition ternaire :
var voiture = 'bmw';

var origine = (voiture == 'bmw') ?  'origine allemande <br>'  :  'autre origine <br>' ; // dans cette syntaxe, le "?" signifie if, et le ":" signifie else. On affecte à la variable origine la première expression si la condition est vraie, sinon la seconde.

document.write(origine);


//--------
// Exercice :
// Demandez l'âge de l'internaute dans un prompt.
// Si la réponse est vide (on compare avec des quotes vides), on affiche "Vous n'avez pas répondu.".
// Si l'âge est inférieur à 18, on affiche "Vous êtes mineur.".
// Sinon, on affiche "Vous avez répondu avoir X ans" où X est l'âge de l'internaute.

/*var age = prompt('Quel est votre âge ?');
console.log(age);

if (age.trim() == '' || age == null) {
	document.write('Vous n\'avez pas répondu.');
} else if (age < 18) {
	document.write('Vous êtes mineur.');
} else {
	document.write('Vous avez répondu avoir ' + age + ' ans.');
}*/


//--------------------
// 8- Synthèse des opérateurs
//--------------------
document.write('<h2> Synthèse des opérateurs </h2>');

/*
  ==   pour égal en valeur
  !=   pour différent en valeur

  ===  pour strictement égal en valeur ET en type
  !==  pour strictement différent en valeur ou en type

  >    pour strictement supérieur
  <    pour strictement inférieur
  >=   pour supérieur ou égal
  <=   pour inférieur ou égal

Opérateurs logiques :
  &&   pour AND
  ||   pour OR
  !    pour NOT

Pour mémoire :	
  TRUE && FALSE  => FALSE
  TRUE || FALSE  => TRUE

  !TRUE   => FALSE
  !FALSE  => TRUE

*/


//--------------------
// 9- Condition switch
//--------------------
document.write('<h2> Condition switch </h2>');
// Le switch est une autre syntaxe du if / else if / else quand on veut comparer une variable à une multitude de valeurs.

var couleur = 'jaune';

switch (couleur) {
	case 'bleu' : // chaque "case" représente une valeur que prendre la variable couleur. Si elle vaut "bleu", on exécute le code qui suit :
		document.write('Vous avez choisi le bleu <br>');
	break; // obligatoire pour quitter la condition une fois le "case" exécuté
	case 'vert' :
		document.write('Vous avez choisi le vert <br>');
	break;
	case 'rouge' :
		document.write('Vous avez choisi le rouge <br>');
	break;
	default : // cas par défaut dans lequel on entre si aucun des "case" précédent n'est réalisé  (équivalent du else)
		document.write('Vous avez choisi une autre couleur que le bleu, le rouge ou le vert <br>');
}


//--------------------
// 10- Structures itératives
//--------------------
document.write('<h2> Structures itératives </h2>');
// Les boucles sont destinées à répéter des lignes de code de façon automatique.

// while 
document.write('<h3> Boucle while </h3>');

var i = 0;

while (i <= 3) { // condition d'entrée dans la boucle : "tant que i est inférieur ou égal à 3", j'entre dans la boucle
	document.write(i + '---');
	i++; // incrémentation pour faire varier i et ne pas avoir une boucle infinie (ainsi la condition d'entrée finit par devenir false à la valeur 4).
}

document.write('<br>');

// Exercice : sans modifier la condition d'entrée dans la boucle, vous la réécrivez en faisant en sorte de ne pas afficher les "---" après le 3.

i = 0;
while (i <= 3) { 
	if (i <= 2) {
		document.write(i + '---');
	} else {
		document.write(i);
	}
	i++; 
}

// Boucle for :
document.write('<h3> Boucle for </h3>');

for (var i = 0; i <= 3; i++) { // on trouve ici les 3 "paramètres" de la boucle : initialisation; condition d'entrée dans la boucle; variation.
	document.write(i + '---');
}

document.write('<br>');

// Exercice : afficher un menu déroulant avec les années 1900 à 2020.
document.write('<select>');
	for (var i = 1900; i <= 2020; i++) {
		document.write('<option>' + i + '</option>');
	}
document.write('</select>');



//--------------------
// 11- Fonctions utilisateur
//--------------------
document.write('<h2> Fonctions utilisateur </h2>');
// Une fonction est un morceau de code encapsulé dans des accolades, qui porte un nom, et qu'on appelle au besoin pour exécuter le code qui s'y trouve. A chaque fois qu'on répète une action, on voit s'il est possible de faire une fonction : on parle de factoriser son code.

// Deux manières de déclarer une fonction :
// 1° La manière appelée FUNCTION STATEMENT avec le mot clé "function" :
function maFonction() {
	document.write('<p>Nous sommes mardi <br></p>');
}

// 2° La manière appelée FUNCTION OPERATOR avec le mot clé "var" :
var maFonction2 = function () {
	document.write('Nous sommes en mai <br>');
}

// On appel les fonctions pour les exécuter :
maFonction();
maFonction2(); // en appelant un fonction, on exécute le code qui s'y trouve.

// Par convention, on déclare toujours une fonction avant de l'appeler. Cependant, si vous la déclarez après, le code ne fonctionnera que si vous avez déclaré cette fonction avec le mot clé "function" (méthode function statement).

//-----
// Fonctions avec paramètres :
function afficheBonjour(prenom, nom) { // prenom et nom sont les paramètres de la fonction séparés par une virgule.
	document.write('<p>Bonjour ' + prenom + ' ' + nom + '</p>');
}

afficheBonjour('Alice', 'Dupont'); // quand une fonction possède des paramètres, il faut lui fournir les valeurs correspondantes : celles-ci s'appellent des arguments. On les écrits dans le même ordre que les paramètres d'accueil.

//-----
function d(i) { // fonction pour faire un document.write et un <br> à notre place.
	document.write(i + '<br>');
}

d('Test de notre fonction d.');


//-----
// Préambule à l'exercice :
function meteo(saison, temperature) {
	d('Nous sommes en ' + saison + ' et il fait ' + temperature + 'degrés');
}

meteo('été', 22);
meteo('printemps', 1);

// Exercice : écrivez une autre fonction meteo2 et complétez la pour qu'elle affiche "au printemps", "en été", "en automne", "en hiver". De plus, elle affiche degré avec "s" au pluriel et sans au singulier (entre -1 et +1 degré inclus).  

function meteo2(saison, temperature) {
	var determinant = (saison == 'printemps') ? ' au ' : ' en ';
	var degre = (temperature <= 1 && temperature >= -1) ? ' degré' : ' degrés';
	document.write('Nous sommes' + determinant + saison + ' et il fait ' + temperature + degre + '.<br>' );
}

meteo2('été', 22);
meteo2('printemps', -10);


//------
// Le mot clé return :
// "return" permet de sortir une valeur de la fonction et de la renvoyer à l'endroit où cette dernière est appelée.

function somme(a, b) {
	var resultat = a + b;
	return resultat; // return renvoie ici la valeur de resultat à l'endroit où la fonction somme() est appélée
}

d('La somme de 2 plus 4 est de : ' + somme(2, 4)); // affiche la valeur de la variable resultat grâce au return qui se trouve dans la fonction.

//-------
// Fonction fléchée (ECMAScript 6) :
// Une fonction fléchée pemret d'avoir une syntaxe plus courte que les expressions de fonctions vues précédemment. Elles sont souvent anonymes.

/* Syntaxes :

   Pour les paramètres :
   () => { code }    // quand il n'y a pas de paramètre
   x => { code }     // quand il y a qu'un seul paramètre, ici x
   (x, y) => { code } // quand il y a un ou plusieurs paramètres

   Pour le corps de la fonction :
   x => { return x * x }  // ici nous avons un return dans bloc, qui équivaut à la syntaxe suivante :
   x => x * x   // ici le return n'est plus écrit

*/

// Exemple : avec une fonction qui calcule le montant TTC d'un montant fourni
var montantTTC = montantHT => montantHT * 1.2; // équivaut à :

/*function montantTTC(montantHT) {
	return montantHT * 1.2;
}*/

d(montantTTC(100) + '€ TTC');



//--------------------
// 12- Portée des variables (scope)
//--------------------
document.write('<h2> Portée des variables (scope) </h2>');
/*
Selon l'endroit où une variable est déclarée et la façon dont elle l'est, celle-ci pourra être accessible partout dans le script, ou bien uniquement dans une partie limitée du code. On parle de portée des variables ou de scope en anglais.

- Une variable déclarée SANS le mot clé "var", c'est-à-dire de façon implicite : c'est une variable GLOBALE, donc accessible PARTOUT dans le script (y compris dans les fonctions).

- Une variable déclarée AVEC le mot clé "var", c'est-à-dire de façon explicite :
	- à l'extérieur de la fonction : elle sera GLOBALE, donc accessible PARTOUT.
	- à l'intérieur de la fonction : elle sera LOCALE, donc accessible UNIQUEMENT dans cette fonction.
*/

var animal = 'Loup'; // globale
function jungle() {
	var animal = 'Tigre'; // locale
	return animal;
}

d(animal);  // Loup car on est dans l'espace global
d(jungle()); // Tigre grâce au return de la fonction qui nous retourne la valeur de la variable locale
d(animal); // Loup car on est dans l'espace global

//----
var oiseau = 'Aigle'; // globale
function ciel() {
	oiseau = 'Faucon'; // globale
	return oiseau;
}

d(oiseau);  // Aigle car on est dans l'espace global
d(ciel());  // Faucon grâce au return de la fonction 
d(oiseau);  // Faucon car en appelant la fonction ciel() juste avant, nous avons changé la valeur de la globale oiseau dans laquelle Faucon vient remplacer Aigle.

//-------
function ocean() {
	poisson = 'Requin'; // globale
	return poisson;
}

// d(poisson);  // variable indéfinie car la fonction n'a pas encore été appelée : la variable n'est donc pas encore déclarée
d(ocean());  // Requin grâce au return de la fonction
d(poisson);  // Requin car en appelant la fonction ciel() nous avons déclarée la variable globale poisson


//--------------------
// 13- Instruction let
//--------------------
document.write('<h2> Instruction let </h2>');
// Depuis ECMAScript 6, let permet de déclarer une variable dont la portée est celle du bloc dans lequel elle se situe, et de ses sous-blocs si elle n'y est pas rédéfinie avec let. Le bloc est délimité par les accolades de la fonction, de la condition ou de la boucle.

// Exemple :
function letTest() {
	let x = 31; // variable dont la portée est limitée au bloc de la fonction

	if (true) {
		let x = 71; // ce x est une vairable différente de la précédente car sa portée celle du bloc de la condition
		d('x dans le bloc de la condition : ' + x);  // nous affichons donc 71 
	}

	d('x dans le bloc de la fonction : ' + x); // nous nous trouvons dans le bloc de la fonction, nous utilisons la prmeière variable qui lui appartient : affiche 31

}

letTest();

// Note : au niveau le plus haut, en dehors de tout bloc, let crée une variable globale :
let maVariable = 'je suis une globale';

// On ne mélange let et var en particulier au sein d'un même bloc, sinon cela génère une erreur.


//--------------------
// 14- Arrays
//--------------------
document.write('<h2> Arrays </h2>');
// Un array, ou tableau en français, est objet qui contient plusieurs valeurs, appelés items ou éléments. Chaque élément est accessible au moyen d'un indice, dont la numérotation commence à partir de 0.

// Déclaration d'un array :
var monTableau = ['Emilie', 'Magalie', 'Zakir', 'Elric', 96];  // notation avec crochets pour déclarer un array. On peut y mélanger tous les types.

// Accéder à un élément du tableau :
d(monTableau[0]);  // pour afficher Emilie on indique son indice entre crochet après le nom du tableau

// Remplacer Elric par Agnès :
monTableau[3] = 'Agnès';
document.write(monTableau[3] + '<br>'); // affiche Agnès

// Mesurer le nombre d'éléments dans un array :
d(monTableau.length);  // affiche 5 correspond au nombre d'éléments du tableau

// Parcourir un array avec une boucle for :
for (var i = 0, max = monTableau.length; i < max; i++) {
	d(monTableau[i]);  // la variable i prend les valeurs de 0 à 4 successivement à chaque tour de boucle (le 5 est exclu grâce à l'opérateur "<").
}


//------
// Array multidimensionnel :
// Un array qui contient lui même un ou plusieurs arrays est dit multidiemnsionnel. Chaque tableau représente une dimension.

var monFrigo = [
	['bananes', 'pommes', 'fraises'],
	['lait', 'fromages', 'yaourts' ]
];

d(monFrigo[0][1]); // pour accéder à un élément du tableau multidimensionnel, on écrit la succesion d'indices dans des crochets successifs après le nom du tableau. Affiche "pommes".

// Exercice :
// 1- écrire un array avec les tailles S, M, L et XL.
// 2- afficher les tailles de votre tableau dans un menu déroulant à l'aide d'une boucle for.

 var tableau = ['S', 'M', 'L', 'XL'];

 document.write('<select>');
	 for (var i = 0; i < tableau.length; i++) {
	 	document.write('<option>' + tableau[i] + '</option>');
	 }
 document.write('</select>');

//----------
// Ajouter ou supprimer des valeurs au début ou à la fin d'un array :
var tailles = ['S', 'M', 'L', 'XL'];

tailles.push('XXL');  // ajoute "XXL" à la fin de l'array
console.log(tailles);

tailles.unshift('XS');  // ajoute "XS" au début de l'array
console.log(tailles);

tailles.pop(); // retire le dernier élément de l'array
console.log(tailles);

tailles.shift(); // retire le premier élément de l'array
console.log(tailles);


//--------------------
// 15- Objets
//--------------------
document.write('<h2> Objets </h2>');
/* Un objet est un ensemble de propriétés, et une proppriété est une association entre un nom et une valeur. Cette valeur peut être de n'importe quel type : string, number, booléen, array, objet... De plus, la valeur de la propriété peut être une fonction, auquel cas la propriété s'appelle méthode.
*/

// Déclaration d'un objet :
var personnage = {
		nom    : 'Tintin', // propriété de type string
        animal : 'chien',
        amis   : ['Haddock', 'Tournesol', 'Dupont & Dupond'], // propriété de type array
        age    : 30, // propriété de type number
        afficheMetier : function() { // méthode
        	d('Tintin est reporter.');
        }
}; // on sépare les couples nom/valeur par des virgules mais on finit par un ";".

// Accéder à une propriété de l'objet personnage :
d(personnage.animal); // on accède à la valeur d'une propriété en écrivant l'objet suivi d'un point suivi de cette propriété. Affiche "chien".
d(personnage['animal']); // affiche aussi "chien".


// Modifier la valeur "chien" en "milou" :
personnage.animal = 'milou';
personnage['animal'] = 'milou'; // on modifie la valeur d'une propriété selon les 2 mêmes syntaxes que pour afficher.
d(personnage.animal); // affiche "milou"


// Afficher Tournesol :
d(personnage.amis[1]); // pour accéder à Tournesol, on va à la propriété "amis" de personnage, puis à l'indice [1] de l'array qui s'y trouve. Affiche "Tournesol".

// Appeler une méthode d'un objet :
personnage.afficheMetier(); // exécute le code qui se trouve dans la méthode, celle-ci affichant "Tintin est reporter.".

//-------
// Boucle for in :
// La boucle for...in permet de parcourir les objets automatiquement et d'en récupérer les propriétés et leur valeur.

var produit = {
		titre : 'pantalon',
		prix  : 49.00,
		taille: 'L'
};

for (var propriete in produit) {
	d(propriete + ' => ' + produit[propriete]); // dans cette boucle, la variable propriete parcourt le nom de chaque propriété de l'objet produit. produit[propriete] indique la valeur. On ne peut pas utiliser la syntaxe produit.propriete car cette dernière n'existe pas dans l'objet produit.
}


//--------------------
// 16- Constantes
//--------------------
document.write('<h2> Constantes </h2>');
// Une constante possède une valeur qu'on lui affecte et qui ne peut pas être modifiée dans le script.

const CHANGE_PAS = 'ma constante impossible à modifier'; // les constantes s'écrivent en majuscules par convention.

d(CHANGE_PAS); 

// CHANGE_PAS = 'autre valeur';  // erreur de type "invalid assigment constant variable".

// Portée des constantes : les constantes font partie de la portée du bloc dans lequel elle est déclarée, comme les variables définies avec let. En dehors de tout bloc, la constante a une portée globale.

//****************************************************


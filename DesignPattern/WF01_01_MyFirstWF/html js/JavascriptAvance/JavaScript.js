function direBonjour(nom) {
    var texte = 'Bonjour ' + nom; // Variable locale 
    var dire = function () { console.log(texte); }
    return dire;
}
var maFonction = direBonjour('Jean'); maFonction(); // logs Bonjour Jean

function multiplicationParDeux() {
    // Variable locale utilisée pour démontrer la closure 
    var chiffre = 10;
    var fonction = function () { console.log(chiffre * multiplicateur); chiffre = chiffre * 2; }
    var multiplicateur = 10;
    return fonction;
}
var maFonction = multiplicationParDeux();
maFonction(); // Affiche 100 dans la console
var maFonction = multiplicationParDeux();
maFonction(); // Affiche 100 dans la console 
maFonction(); // Affiche 200 dans la console 
maFonction = multiplicationParDeux();
maFonction();

function Client(_nom, _prenom) {
    this.nom = _nom;
    this.prenom = _prenom;
    this.getNomComplet = function () { return this.prenom + ' ' + this.nom; }
}
var c = new Client('Foucault', 'Patrick');
console.log(c.getNomComplet());

function Client(_nom, _prenom) {
    var age = 50;
    this.nom = _nom;
    this.prenom = _prenom;
    this.getNomComplet = function () { return this.prenom + ' ' + this.nom; }
    this.getAge = function () { return age++; }
}
var c = new Client('Foucault', 'Patrick');
console.log(c.getAge());
console.log(c.getAge());
console.log(c.age);

function Animal(_nom) { this.nom = _nom; }
Animal.prototype.crier = function () {
    console.log('Grrrrrrr');
}
var a1 = new Animal('Médor');
a1.crier();
var a2 = new Animal('Simba');
a2.crier();
Animal.prototype.crier = function () {
    console.log('Miaou');
}
a1.crier();
a2.crier();


function Vehicule(_marque, _model) {
    var vitesse = 0;
    this.model = _model;
    this.marque = _marque;
    this.getVitesse = function () {
        return vitesse;
    }
    Vehicule.prototype.accelerer = function (addition) {
        vitesse += addition;
    }
}
var ferrary = new Vehicule('Ferrarie', 'GTO');
console.log('premiere vitesse=' + ferrary.getVitesse());
ferrary.accelerer(10);
console.log(' nouvelle vitesse=' +ferrary.getVitesse());
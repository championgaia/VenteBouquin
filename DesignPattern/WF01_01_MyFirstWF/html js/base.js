document.write('mon message');
document.write('<h1>les balises</h1>');

//les boites de dialogue
//alert('hello');
//confirm('');//boite avec bouton ok oi anuller
//prompt('hello');//boite avec champs a remplir

var age = prompt('enter your age');
if (age < 18)
    document.write('vous etes mineur');
else 
    document.write('vous repondu avoir' + age + ' ans');
var i = 0;
while (i <= 3) {
    document.write(i === 3 ? i : i + '---');
    i++;
    
}

function meteo (saison, temperature) {
    document.write('nous sommes ' +
        saison === 'printemps' ? 'au ' + saison : 'en ' +
        saison +
        ' et il fait' +
        temperature +
        temperature > 1 ? ' dégrés ' : ' dégré ' +
        '<br>');
}

meteo('été', 22);
meteo('printemps', 1);
var my = x => x * x;
document.write(my(12));
var my = x => x * x * x;
document.write(my(12) +'<br>');

var montableau = ['A', 'B', 'C'];
montableau.forEach(function (e) {
    console.log(e);
}); 
tableau1 = Array(5);
tableau = new Array(5);
tableau2 = new Array (1, 2, 3, 4 );
document.write(montableau.length + '<br>');
document.write(tableau2.length + '<br>');
for (var c in montableau) {
    document.write(montableau[c]);
}
for  (var c of montableau) {
    document.write(c);
}
var element = document.getElementById('ddlBox');
function fillCombobox(chaine) {
    //element.innerHTML +='<option>' + chaine + '</option>';
    var newE = document.createElement("option");
    newE.textContent = chaine;
    element.appendChild(newE);
}
for (var c of montableau) {
    fillCombobox(c);
} 
var monObjet = {
    nom: "Tintin",
    prenom: "Tim",
    animal: "chien",
    amis: ["ABC","CDE","EDF"],
    myFunction: function () { alert('ok');}
}
document.write(monObjet.nom + '<br>');
document.write(monObjet['animal'] + '<br>');
monObjet.nom = "milou";
monObjet['animal'] = "milou";
document.write(monObjet.nom + '<br>');
document.write(monObjet.amis[1] + '<br>');
document.write(monObjet['amis'][1] + '<br>');
for (var c in monObjet) {
    document.write(monObjet[c] + '<br>');
} 
for (var c of monObjet) {
    document.write(monObjet.c + '<br>');
} 
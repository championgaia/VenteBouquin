var monTable = [];
var tableBut = [];
var buttonVideId = '';
var buttonCliqueId = '';
$(function () {
    //remplir array
    fillArray(monTable);
    fillArray(tableBut);
    //button Start
    $('.btnStart').click(function () {
        //shuffle array
        shuffle(monTable);
        //remplir le tableau
        remplirTableau(monTable);
        //initialiser la valeur du button Undo
        $('.btnUndo').attr('value','0');
        if (isGagner(tableBut)) {
            alert('vous etes gagne');
        }
    });
    //deplacer les cases
    $('.btnJeu').click(function () {
        if ($(this).html() === '') {
            alert('il faut cliquer sur le button start');
        }
        else {
            //prendre la coordinate de deux buttons
            var coordinateButtonVide = $('#' + buttonVideId).attr('value').split("_");
            var coordinateButtonClique = $(this).attr('value').split("_");
            var differentRow = Math.abs(coordinateButtonVide[0] - coordinateButtonClique[0]);
            var differentColonne = Math.abs(coordinateButtonVide[1] - coordinateButtonClique[1]);
            //check si valable le button cliqué
            if ((differentColonne * differentRow) === 0 && (differentRow + differentColonne) === 1) {
                $('.btnUndo').attr('value', buttonVideId);
                buttonCliqueId = $(this).attr('id');
                echangeValue(buttonCliqueId, buttonVideId);
            }
            else {
                alert('choose autre case');
            }
            if (isGagner(tableBut)) {
                alert('vous etes gagne');
            }
        }
    });
    $('.btnUndo').click(function () {
        if ($(this).attr('value') == null ) {
            alert('il faut cliquer sur le button start');
        }
        else if ($(this).attr('value') === '0') {
            alert('vous n\'avez pas encore joue');
        }
        else {
            buttonCliqueId = $(this).attr('value');
            echangeValue(buttonCliqueId, buttonVideId);
        }
    });
    $('.btnRestart').click(function () {
        $('.btnVide').removeClass('btnVide');
        remplirTableau(monTable);
        
        $('.btnUndo').attr('value', '0');
        if (isGagner(tableBut)) {
            alert('vous etes gagne');
        }
    });
});//fin du document ready
//remplir le tableau de 1-15 et X
function fillArray(array) {
    for (var i = 1; i < 16; i++) {
        array.push(i);
    }
    array.push('X');
}
//mélanger le tableau
function shuffle(array) {
    array.sort(() => Math.random() - 0.5);
}
//remplir le tableau 4*4 de jeu
function remplirTableau(array) {
    for (var i = 0; i < array.length; i++) {
        $('#btn' + (i + 1)).html(array[i]);
        hiddenCase('#btn' + (i + 1));
    }
}
//hide la case vide
function hiddenCase(chain) {
    if ($(chain).html() == 'X') {
        $('.btnVide').removeClass('btnVide');
        $(chain).addClass('btnVide');
        buttonVideId = $(chain).attr('id');
    }
}
//echange value de 2 buttons
function echangeValue(idButtonClique, idButtonVide) {
    var temp = $('#' + idButtonClique).html();
    $('#' + idButtonClique).html('X');
    $('#' + idButtonVide).html(temp);
    hiddenCase('#' + idButtonClique);
}
//check gagne
function isGagner(array) {
    var gagne = false;
    for (var i = 0; i < array.length; i++) {
        if ($('#btn' + (i + 1)).html() != array[i]) {
            gagne = false;
            break;
        }
        else
            gagne = true;
    }
    return gagne;
}
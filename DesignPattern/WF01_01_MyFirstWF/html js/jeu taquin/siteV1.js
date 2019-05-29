var monTable = [];
var tableBut = [];
var buttonVideId = '';
var buttonCliqueId = '';
var rowButtonVide = 0;
var colonneButtonVide = 0;
var rowButtonClick = 0;
var colonneButtonClick = 0;
$(function () {
    //remplir array
    fillArray(monTable);
    console.log('monTable=' + monTable);
    fillArray(tableBut);
    console.log('tableBut=' + tableBut);
    //remplir le tableau
    $('.btnStart').click(function () {
        $('.btnUndo').attr('value', '0');
        console.log('monTable='+monTable);
        //shuffle array
        shuffle(monTable);
        console.log('monTable shuffled='+monTable);
        remplirTableau(monTable);
        if (isGagner(tableBut)) {
            alert('vous etes gagne');
        }
    });
    $('.btnJeu').click(function () {
        if ($(this).html() === '') {
            alert('il faut click sur start');
        }
        else {
            $('.btnUndo').attr('value', buttonVideId);
            buttonCliqueId = $(this).attr('id');
            rowButtonVide = $('#' + buttonVideId).attr('value').split("_")[0];
            colonneButtonVide = $('#' + buttonVideId).attr('value').split("_")[1];
            rowButtonClick = $(this).attr('value').split("_")[0];
            colonneButtonClick = $(this).attr('value').split("_")[1];
            var differentRow = Math.abs(rowButtonClick - rowButtonVide);
            var differentColonne = Math.abs(colonneButtonClick - colonneButtonVide);
            if (differentRow + differentColonne === 1 && differentRow * differentColonne === 0) {
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
        if ($(this).attr('value') === null) {
            alert('il faut click sur start');
        }
        else if ($(this).attr('value') === '0') {
            alert('vous n\'avez pas encore jouer');
        }
        else {
            //buttonVideId : destination
            buttonCliqueId = $(this).attr('value');
            echangeValue(buttonCliqueId, buttonVideId);
        }
    });
});//fin du document ready
//remplir le tableau

function fillArray(array) {
    for (var i = 1; i < 16; i++) {
        array.push(i);
    }
    array.push('X');
}
function shuffle(array) {
    array.sort(() => Math.random() - 0.5);
}
function remplirTableau(array) {
    for (var i = 0; i < array.length; i++) {
        //div
        $('#btn' + (i + 1)).html(array[i]);
        //table
        //$('#btn_' + (i + 1)).html(array[i]);
        hiddenCase('#btn' + (i + 1));
        //hiddenCase('#btn_' + (i + 1));
    }
}
//hide la case vide
function hiddenCase(chain) {
        if ($(chain).html() === 'X') {
            //$(chain).attr('hidden', 'hidden');
                buttonVideId= $(chain).attr('id');
        }
}
//echange value de 2 buttons
function echangeValue(idButtonClique, idButtonVide) {
    var temp = $('#' + idButtonClique).html();
    //$(this).attr('value', 'X');
    $('#' + idButtonClique).html('X');
    //$('#' + idButtonClique).attr('hidden', 'hidden');
    //$('#' + buttonVideId).attr('value', temp);
    $('#' + idButtonVide).html(temp);
    buttonVideId = idButtonClique;
}
function isGagner(array) {
    var gagne = false;
    for (var i = 0; i < array.length; i++) {
        console.log('#btn' + (i + 1));
        console.log($('#btn' + (i + 1)).html());
        console.log(array[i]);
        if ($('#btn' + (i + 1)).html() != array[i]) {
            gagne = false;
            break;
        }
        else
            gagne = true;
    }
    return gagne;
}
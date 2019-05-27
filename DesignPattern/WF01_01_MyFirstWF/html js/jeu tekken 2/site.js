var monTable = [];
var tableBut = [];
var buttonVideId = '';
var rowButtonVide = 0;
var colonneButtonVide = 0;
var rowButtonClick = 0;
var colonneButtonClick = 0;
$(function () {
    fillArray(monTable);
    fillArray(tableBut);
    //remplir le tableau
    $('.btnStart').click(function () {
        //remplir array
        console.log('monTable='+monTable);
        //shuffle array
        //shuffle(monTable);
        console.log('monTable shuffled='+monTable);
        remplirTableau(monTable);
    });
    //verifier gagner
    console.log('tableBut=' + tableBut);
    console.log(isGagner(tableBut));
    if (isGagner(tableBut)) {
        alert('vous etes gagne');
    }
    else {
        //deplacer les cases
        //quand on click detect la case est clicable: 
        // -non : alert(message)
        // oui: déplacer 
        $('.btnJeu').click(function () {
            //var buttonVide = document.getElementById(buttonVideId);
            rowButtonVide = $('#' + buttonVideId).attr('value').split("_")[0];
            console.log('rowButtonVide=' + rowButtonVide);
            colonneButtonVide = $('#' + buttonVideId).attr('value').split("_")[1];
            console.log('colonneButtonVide=' + colonneButtonVide);
            rowButtonClick = $(this).attr('value').split("_")[0];
            console.log('rowButtonClick=' + rowButtonClick);
            colonneButtonClick = $(this).attr('value').split("_")[1];
            console.log('colonneButtonClick=' + colonneButtonClick);
            console.log(rowButtonClick - rowButtonVide);
            console.log(colonneButtonClick - colonneButtonVide);
            if (rowButtonClick - rowButtonVide ==0) {
                if (Math.abs(colonneButtonClick - colonneButtonVide) == 1) {
                    echangeValue($(this).attr('id'), $('#' + buttonVideId).attr('id'));
                }
                else {
                    alert('choose autre case');
                }
            }
            else if (Math.abs(rowButtonClick - rowButtonVide) == 1) {
                if (colonneButtonClick - colonneButtonVide==0) {
                    echangeValue($(this).attr('id'), $('#' + buttonVideId).attr('id'));
                }
            }
            else {
                alert('choose autre case');
            }
        });
    }
    //declare win
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
        if ($(chain).html() == 'X') {
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
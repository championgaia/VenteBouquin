// Fichier en jQuery

//------------------
// Le document ready :
/* Les deux lignes suivantes ont la même signification : exécuter le code JS après avoir chargé le document HTML. Par conséquent, le lien vers ce script JS peut se situer avant la fermeture du <body> comme dans le <head>.

	$(function() {
		// tout votre code JS ou jQuery
	});

	$(document).ready(function() {
		// tout votre code JS ou jQuery
	});
*/

$(function() { // le code qui se trouve ici s'exécutera une fois le document HTML chargé

	//------------
	// Fonction principale de jQuery, alias $, sélecteur, événement :
	$('#monBouton').click(function() {  // on sélectionne avec $() l a balise d'id monBouton et au clic on déclenche la fonction anonyme qui suit : celle-ci sélectionne l'id carre et l'efface avec la méthode hide().
		$('#carre').hide();
	});

	// Peut aussi s'écrire :
	jQuery('#monBouton').click(function() {  
		jQuery('#carre').hide();
	}); // en réalité le $ est l'alias de "jQuery". Cette fonction principale transforme la balise #carre en un objet jQuery, dont click() et hide() sont des méthodes.


	$('#carre').click(function() {
		$('h3').hide();  
	}); // sélectionne la balise #carre et au clic, déclenche la fonction qui suit : elle sélectionne TOUS les h3, et les masque sans avoir à écrire de boucle.

	$('.photo').dblclick(function() {
		$('#carre').show(1000); // hide() et show() peuvent prendre un argument : une durée de transition en ms, ou 'slow' ou 'fast'
	});

	// Alterner hide() et show() avec toggle() :
	$('#interrupteur').click(function() {
		$('#on-off').toggle(); // toggle() alterne hide() et show() selon que l'élément est visble ou pas à son état initial
	});

	//--------------
	// Les méthodes on() et off() pour ajouter ou retirer un événement sur un élément :
	$('#monBouton').on('click.test', function() {
		alert('Déclenchement de la méthode on() !'); // on() permet d'associer un événement à un élément comme le ferait la méthode addEventListener() en JS. La seule différence entre on() et click() directement, réside dans le fait que la première méthode marche aussi sur les éléments créés dynamiquement (non présents dans le HTML initial et ajoutés par le JS).
		
		$('#monBouton').off('click.test');  // on dissocie les clics de #monBouton une fois que nous sommes entrés dans la fonction anonyme. Les clics sur ce bouton sont donc désactivés (exemple : lien de téléchargement). 

	});


	//---------------------
	// Modifier du CSS et événement hover :
	$('#vert').hover(function() { // quand on entre
		$('#rouge').css({
			width      : '300px',
			background : 'yellow',
			transition : 'width 1s'
		});

	}, function() { // quand on sort
		$('#bleu').css({
			width      : '300px',
			background : 'yellow',
			transition : 'width 1s'
		});	

	}); // hover est une combinaison de mouseover et mouseout en JS : 2 fonctions s'exécutent, l'une quand on entre, l'autre quand on sort.
	// La méthode css() permet de modifier les propriétés CSS qui sont passées en argument dans un objet entre {}.

	//--------------
	// Récupérer ou modifier la valeur d'un input de formulaire avec val() :
	$('#mdp1').change(function() { // change se déclenche quand on change la valeur saisie dans l'input et qu'on le désactive. 
		var texte = $('#mdp1').val(); // val() sans argument retourne la valeur du champ (getter).
		console.log(texte);

		$('#mdp2').val(texte);  // val() avec un argument permet de changer la valeur de l'input (setter).

	});

	//----------
	// Le mot clé this :
	// this est nécessaire quand on sélectionne plusieurs éléments simultanément et qu'on a besoin de cibler l'élément sur lequel on agit en particulier (en excluant les autres).
	$('input').focus(function() {
		$(this).css({ border : '2px solid green' });
	});

	$('input').blur(function() {
		$(this).css({ border : '' });
	});

	//------------
	// Accéder aux propriétés CSS avec la méthode css() :
	var position = $('#violet').css('position'); // la méthode css() avec une propriété  CSS écrite en string se comporte comme un getter : elle retourne la valeur de cette propriété CSS. 
	console.log('La propriété position de #violet est : ' + position);


	//------------
	// Accéder aux attributs des balises avec attr() :
	//console.log($('.modifAlt').attr('alt'));
	
	if ($('.modifAlt').attr('alt') == '') {
		//console.log($(this));
		$('.modifAlt').attr('alt', 'paysage');
	} // attr() pour "attribute" avec un seul argument est un getter : il retourne la valeur de l'attribut spécifié. Avec deux arguments, il est un setter : il donne la seconde valeur à l'attribut spécifié en première valeur. Remarque : attr() permet de sélectionner n'importe quel attribut.


	//------------
	//Modifier le contenu d'une balise avec html() ou text() :
	// html() :
	$('.texte').eq(0).html('<span>Texte ajouté avec la méthode html()</span>'); // eq() permet de cibler l'élément de l'indice spécifié, ici la première classe .texte. La méthode html() permet d'ajouter du HTML dans le document : les balises indiquées sont interprétées et insérées dans le code HTML.


	// text() :
	$('.texte').eq(1).text('<span>Texte ajouté avec la méthode text()</span>'); // ici avec la méthode text() le string passé en argument est traité comme du texte brut dans lequel les balises ne sont pas interprétées (elles sont affichées dans le navigateur).


	//----------------
	// Ajouter ou retirer des classes définies en CSS :
	$('#survol').mouseenter(function() {
		$(this).addClass('rouge'); // addClass() ajoute la classe spécifiée
	});

	$('#survol').mouseleave(function() {
		$(this).removeClass('rouge'); // removeClass() retire la classe spécifiée. this peut s'appliquer ici car il se trouve dans un événement (mouseleave) dépendant d'un élément (#survol). this se réfère donc à ce dernier.
	});

	$('#classBleu').click(function() {
		$('#survol').toggleClass('bleu'); // toggleClass() alterne addClass() et removeClass() de la classe spécifiée.
	});


	//--------------
	// Parcourir les éléments avec each() :
	$('h4').each(function(indice, element) { // each() parcourt tous les <h4> et exécute notre fonction (non définie dans jQuery) pour chacun d'entre-eux. La fonction a deux paramètres : le premier reçoit l'indice de l'élément, le second l'élément lui-même (et ceci quelque soit leur nom).

		console.log(element); // pour visualiser les 4 <h4> à chaque tour de boucle

		$(element).text('Ce <h4> a pour indice le numéro ' + indice); // indice contient le numéro de la balise h4 sur laquelle on se situe à chaque tour de boucle.

		if (indice % 2 == 0) {
			$(this).addClass('rouge'); // on ajoute la classe "rouge" sur les <h4> dont l'indice est paire (son modulo de 2 vaut 0). $(this) se réfère à l'élément sur lequel on se trouve à chaque tour de boucle. Il équivaut à $(element).
		}

	});



}); // fin du document ready
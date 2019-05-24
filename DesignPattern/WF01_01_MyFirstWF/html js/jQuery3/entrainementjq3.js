$(function () {
    //----------------------
    //naviguer dans le document html
    //----------------------
    //les méthode next() et children()

    $('#galeries h3').click(function () {
        alert('ffddfdf');
        //$(this).next().fadeOut(1000);
        $(this).next().children().fadeOut(1000);
    });
    $('#galeries img').click(function () {
        //$(this).parent().css({ border: '2px solid red' });
        $(this).parents('#galeries').css({ border: '2px solid red'  });
    });
    $('#galeries p').click(function () {
        $(this).prev().css({ border: '' });
    });

    $('button').eq(0).click(function () {
        //$('#galeries').find('img').each(function () {
        //    $(this).fadeOut(1000);
        //});
        //document, 'html', 'body'
        $('body').find('img').each(function () {
            $(this).fadeOut(1000);
        });
    });

    $('#accordion h3').click(function () {
        $('.on').removeClass('on').addClass('off');
        //$(this).parent().children('div').removeClass('on').addClass('off');
        $(this).next().removeClass('off').addClass('on');
    });
    //Scroll automatique au clic sur un élément
    $('.top').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 'slow');
    });
    //Exercice "scroll vers exercice 1"
    $('.top2').click(function () {
        var positionExo1 = $('#accordion').offset().top;
        //var positionExo1 = $('#accordion').position().top;
        $('html, body').animate({ scrollTop: positionExo1 }, 'slow');
    });
    //Déclencher une action au scroll
    var tailleWindow = $(window).height();
    $(document).scroll(function () {
        //var positionScrolls = $('.scrolls').offset().top;
        //var tailleWindow = $(window).height();

        //if ($(document).scrollTop() >= positionScrolls - tailleWindow) {
        //    $('.scroll').fadeIn(1000);
        //}
        //else {
        //    $('.scroll').fadeOut(1000);
        //}
        $('.scroll').each(function () {
            var positionScroll = $(this).parent().offset().top;
            if ($(document).scrollTop() >= (positionScroll - tailleWindow/2)) {
                $(this).fadeIn(1000);
            }
            else {
                $(this).fadeOut(1000);
            }
        });
    });
});//fin du document ready
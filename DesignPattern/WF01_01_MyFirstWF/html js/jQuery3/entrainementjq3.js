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
        //$(this).next().removeClass('off').addClass('on');
        //$(this).next().next('div').removeClass('on').addClass('off');
        //$(this).next().next().next('div').removeClass('on').addClass('off');
        //$(this).prev('div').removeClass('on').addClass('off');
        //$(this).prev().prev('div').removeClass('on').addClass('off');
        //$(this).parent().children('div').removeClass('on').addClass('off');
    });


});//fin du document ready
$(function () {
    $('#barre').click(function () {
        //$('#rideau').slideDown(1000);
        //$('#rideau').slideUp(1000);
        $('#rideau').stop(true, true).slideToggle(1000);
    });


    $('#anim1').click(function () {
        $('#un').animate({
            top: '-200px'
        }, 1000);
    });
    $('#anim2').click(function () {
        $('#deux').animate({
            top: '-200px',
            left: '200px'
        }, 1000);
    });
    $('#anim3').click(function () {
        $('#trois').animate({
            top: '200px',
            left: '+=200px'
        }, 1000)
            .animate({
                top: '-=200px',
                left: '+=200px'
            }, 1000);
    });
    function anim4() {
        $('#quatre').animate({
                                top: '+=200px',
                                left: '+=200px'
                             }, 1000)
            .delay(500)
            .animate({
                top: '+=200px',
                left: '+=200px'
            }, 1000)
            .delay(500)
            .animate({
                top: '+=200px',
                left: '+=200px'
            }, 1000)
            .delay(500)
            .animate({
                        top: '0px',
                        left: '0px'
                    }, 1000, anim4)
                    .delay(1000);
    }
    $('#anim4').click(anim4);

});//fin document ready
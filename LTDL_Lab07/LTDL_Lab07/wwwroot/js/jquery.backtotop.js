/* Nút "Back to top" */
jQuery(document).ready(function ($) {
    var $btn = $('#backtotop');
    if (!$btn.length) { return; }
    $(window).on('scroll', function () {
        $btn.toggleClass('visible', $(window).scrollTop() > 200);
    });
    $btn.on('click', function (e) {
        e.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, 400);
    });
});

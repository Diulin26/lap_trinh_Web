$(function () {
    $('.menu-tl').on('click', function (e) {
        e.preventDefault();
        var $a = $(this);
        $.get($a.data('url'), function (html) {
            $('#main-content').html(html);
            $('.menu li').removeClass('active');
            $a.closest('li').addClass('active');
        });
    });
});

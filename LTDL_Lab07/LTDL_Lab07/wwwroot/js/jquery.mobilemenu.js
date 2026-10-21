/* Menu thu gọn trên màn hình nhỏ */
jQuery(document).ready(function ($) {
    var $nav = $('#mainav');
    if (!$nav.length) { return; }
    var $toggle = $('<a class="mobilemenu-toggle" href="#"><i class="fas fa-bars"></i> Menu</a>');
    $nav.addClass('mobile-ready').prepend($toggle);
    $toggle.on('click', function (e) {
        e.preventDefault();
        $nav.toggleClass('mobile-open');
    });
});

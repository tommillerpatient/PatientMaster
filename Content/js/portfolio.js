function noo_masonry(){

    "use strict";

    var $container = jQuery('.noo-portfolio');
    $container.imagesLoaded(function(){
        $container.isotope({
            itemSelector : '.masonry-item',
            transitionDuration : '0.8s',
            masonry : {
                'gutter' : 0
            }
        });

    });
}
jQuery(document).ready(function(){

    "use strict";

    var $container = jQuery('.noo-portfolio');
    //Init masonry isotope
    noo_masonry();
    var $filter = jQuery('.masonry-filters a');
    $filter.click(function(e){
        e.stopPropagation();
        e.preventDefault();
        var $this = jQuery(this);
        // don't proceed if already selected
        if ($this.hasClass('selected')) {
            return false;
        }
        var filters = $this.closest('ul');
        filters.find('.selected').removeClass('selected');
        $this.addClass('selected');

        var options = {},
            key = filters.attr('data-option-key'),
            value = $this.attr('data-option-value');

        value = value === 'false' ? false : value;
        options[key] = value;

        $container.isotope(options);

    });

});
jQuery(window).load(function(){
    noo_masonry();
});

jQuery(document).on('noo-layout-changed', function() {
    noo_masonry();
});


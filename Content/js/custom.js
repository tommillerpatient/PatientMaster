$(document).ready(function() {
    "use strict";
	$('.services-slider').owlCarousel({
		items : 3,
		itemsCustom : false,
		itemsDesktop : [1500, 3],
		itemsDesktopSmall : [1200, 2],
		itemsTablet : [768, 2],
		itemsTabletSmall : [767, 1],
		itemsMobile : [479, 1],
		slideSpeed:500,
		paginationSpeed:800,
		rewindSpeed:1000,
		autoHeight: false,
		addClassActive: true,
		autoPlay: true,
		loop:true,
		pagination: true
	});
	
	$('.noo-woo-slider').owlCarousel({
		items : 4,
		itemsCustom : false,
		itemsDesktop : [1320, 4],
		itemsDesktopSmall : [1200, 3],
		itemsTablet : [991, 2],
		itemsTabletSmall : false,
		itemsMobile : [500, 1],
		slideSpeed:500,
		paginationSpeed:800,
		rewindSpeed:1000,
		autoHeight: false,
		addClassActive: true,
		autoPlay: false,
		loop:true,
		pagination: true
	});
	
	$('.noo_our_blog').each(function(){
		$(this).owlCarousel({
			items : 2,
			itemsDesktop : [1199,2],
			itemsDesktopSmall : [979,1],
			itemsTablet: [768, 1],
			itemsMobile: [479, 1],
			slideSpeed:500,
			paginationSpeed:1000,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: false
		});
		var $_parent = $(this);
		$_parent.parent().parent().parent().find('.blog-prev').click(function(){
			$_parent.trigger('owl.prev');
		}) ;
		$_parent.parent().parent().parent().find('.blog-next').click(function(){
			$_parent.trigger('owl.next');
		}) ;
	});
	
	$('.noo_team').each(function(){
		$(this).owlCarousel({
			items : 3,
			itemsDesktop : [1199,3],
			itemsDesktopSmall : [979,2],
			itemsTablet: [767, 2],
			itemsMobile: [480, 1],
			slideSpeed:500,
			paginationSpeed:1000,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: false
		});
		var $_parent = $(this);
		$_parent.parent().parent().parent().find('.team-prev').click(function(){
			$_parent.trigger('owl.prev');
		}) ;
		$_parent.parent().parent().parent().find('.team-next').click(function(){
			$_parent.trigger('owl.next');
		}) ;
	});
	
	$('.noo_clients').each(function(){
	   $(this).owlCarousel({
			items : 5,
			itemsDesktop : [1199,5],
			itemsDesktopSmall : [979,4],
			itemsTablet: [768, 3],
			itemsMobile: [479, 1],
			slideSpeed:500,
			paginationSpeed:1000,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: false
		});
		var $_parent = $(this);
		$_parent.parent().parent().parent().find('.prev-client').click(function(){
		   $_parent.trigger('owl.prev');
		}) ;
		$_parent.parent().parent().parent().find('.next-client').click(function(){
		   $_parent.trigger('owl.next');
		});
	});
	
	$('.noo_testimonial').each(function(){
		$(this).owlCarousel({
			items : 1,
			itemsDesktop : [1199,1],
			itemsDesktopSmall : [979,1],
			itemsTablet: [768, 1],
			slideSpeed:500,
			paginationSpeed:800,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: true
		});
	});
	
	$('.noo_testimonial_three').each(function(){
		$(this).owlCarousel({
			items : 3,
			itemsDesktop : [1199,3],
			itemsDesktopSmall : [979,3],
			itemsTablet: [768, 2],
			slideSpeed:500,
			paginationSpeed:800,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: true
		});
	});
	
	$('.noo_poster_products').each(function(){
		$(this).owlCarousel({
			items : 3,
			itemsDesktop : [1199,3],
			itemsDesktopSmall : [979,2],
			itemsTablet: [768, 2],
			itemsMobile: [479, 1],
			slideSpeed:500,
			paginationSpeed:1000,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: false
		});
		var $_parent = $(this);
		$_parent.parent().parent().parent().find('.poster-prev').click(function(){
			$_parent.trigger('owl.prev');
		}) ;
		$_parent.parent().parent().parent().find('.poster-next').click(function(){
			$_parent.trigger('owl.next');
		}) ;
	});
	
	$('.best_services').each(function(){
		$(this).owlCarousel({
			items : 1,
			itemsDesktop : [1199,1],
			itemsDesktopSmall : [979,1],
			itemsTablet: [768, 1],
			itemsMobile: [479, 1],
			slideSpeed:500,
			paginationSpeed:1000,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: false
		});
		var $_parent = $(this);
		$_parent.parent().parent().find('.best_services-prev').click(function(){
			$_parent.trigger('owl.prev');
		}) ;
		$_parent.parent().parent().find('.best_services-next').click(function(){
			$_parent.trigger('owl.next');
		}) ;
	});
	
	$('.related_projects').each(function(){
		$(this).owlCarousel({
			items : 1,
			itemsDesktop : [1199,1],
			itemsDesktopSmall : [979,1],
			itemsTablet: [768, 1],
			itemsMobile: [479, 1],
			slideSpeed:500,
			paginationSpeed:1000,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: false
		});
		var $_parent = $(this);
		$_parent.parent().parent().find('.projects-prev').click(function(){
			$_parent.trigger('owl.prev');
		}) ;
		$_parent.parent().parent().find('.projects-next').click(function(){
			$_parent.trigger('owl.next');
		}) ;
	});
	
	$('.noo-project-slider').each(function(){
		$(this).owlCarousel({
			items : 4,
			itemsDesktop : [1199,4],
			itemsDesktopSmall : [979,3],
			itemsTablet: [768, 2],
			slideSpeed:500,
			paginationSpeed:800,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: true
		});
	});
	
	$('.noo_testimonial').each(function(){
		$(this).owlCarousel({
			items : 1,
			itemsDesktop : [1199,1],
			itemsDesktopSmall : [979,1],
			itemsTablet: [768, 1],
			slideSpeed:500,
			paginationSpeed:800,
			rewindSpeed:1000,
			autoHeight: false,
			addClassActive: true,
			autoPlay: false,
			loop:true,
			pagination: true
		});
	});
	
	//parallax
	$('.parallax').parallax("50%", 0.4);
	$('.parallax-choose-us').parallax("50%", 0);
	$('.parallax-counter').parallax("50%", 0.1);
	$('.parallax-offers').parallax("50%", 0);
	$('.parallax-client').parallax("50%", 0);
	$('.parallax-blog').parallax("50%", 0);
	$('.parallax-portfolio').parallax("50%", 0);
	$('.parallax-testimonial').parallax("50%", 0);
	
	//service item background
	var bg = "";
	$(".services-slider .slider-item").each(function() {
		bg = $(this).find(".services-background").attr("data-image");
		$(this).find(".services-background").css("background-image", "url('" + bg + "')");
	});
	$(".service-grid .column-services").each(function() {
		bg = $(this).find(".services-background").attr("data-image");
		$(this).find(".services-background").css("background-image", "url('" + bg + "')");
	});
	
	//blog item background
	$(".noo_our_blog .our-blog-item").each(function() {
		bg = $(this).find(".blog-image").attr("data-image");
		$(this).find(".blog-image").css("background-image", "url('" + bg + "')");
	});
	
	$(".noo_our_blog_2 .blog-item-default").each(function() {
		bg = $(this).find(".blog-sh-left").attr("data-image");
		$(this).find(".blog-sh-left").css("background-image", "url('" + bg + "')");
	});
	
	//ajax popup
	$('.ajax-popup-link').magnificPopup({
		type: 'ajax'
	});
	
	$('.control-appoinment').on( "click", function() {
        $('.noo-appoinment').toggleClass('eff');
    });
	
	// seach popup
    $('.icon-search2').click(function(){
       $('.search-header5').fadeIn(1).addClass('search-header-eff');
    });
    $('.search-remove').click(function(){
       $('.search-header5').fadeOut(1).removeClass('search-header-eff');
    });
	
	//date picker
	if($('#noo_timepicker').length > 0) {
		$('#noo_timepicker').timepicker( {
			showAnim: 'blind'
		});
	}
	if($('#noo_datepicker').length > 0) {
		$( "#noo_datepicker" ).datepicker();
	}
	
	//scroll to section when click menu item
	var offset = 0;
    $('.nav-onepage li a[href^="#"]').on( "click", function(event) {

        // Prevent from default action to intitiate
        event.preventDefault();
         
        //remove active from all anchor and add it to the clicked anchor
        $('.nav-onepage li').removeClass("current")
        $(this).parent('li').addClass('current');
        
        // The id of the section we want to go to
        var anchorId = $(this).attr('href');

        // Our scroll target : the top position of the section that has the id referenced by our href
        var target = $(anchorId).offset().top - offset;

        $('html, body').stop().animate({ scrollTop: target }, 500, function () {
            window.location.hash = anchorId;
        });

        return false;
    });
	
	//set fixed menu when scrolling
	$(window).scroll(function(){
		"use strict";
		
		//add fixed class to menu when scrolling
		if($('.noo-revo').length > 0){
			var $_revo      = $('.noo-revo').height();
			var _top        = $(window).scrollTop();
	
			if( _top >= $_revo ){
				$('.noo-onepage').addClass('noo-onepage-eff');
				$('body').addClass('padding-top');
			}else{
				$('.noo-onepage').removeClass('noo-onepage-eff');
				$('body').removeClass('padding-top');
			}
		}
		
		$(document).on("scroll", onScroll);
	});
	
	//SlideShow Revolution
	slideShowInit();
	slideShowFullInit();
});

//Preloader
$(window).load(function() {
	$('#loading').fadeOut(300);
});

function onScroll(event){
    var scrollPos = $(document).scrollTop();
    $('.noo-onepage li a').each(function () {
        var currLink = $(this);
       	var refElement = $(currLink.attr("href"));
        if (refElement.length) {
			if (refElement.position().top <= scrollPos && refElement.position().top + refElement.height() > scrollPos) {
				$('.noo-onepage li').removeClass("current");
				currLink.parent('li').addClass("current");
			}
			else{
				currLink.parent('li').removeClass("current");
			}
		}
    });
}

function slideShowInit(){
	if($("#rev_slider").length > 0){
		$("#rev_slider").show().revolution({
			sliderType:"standard",
			sliderLayout:"auto",
			dottedOverlay:"none",
			delay:9000,
			navigation: {
				keyboardNavigation:"on",
				keyboard_direction: "horizontal",
				mouseScrollNavigation:"on",
				onHoverStop:"on",
				touch:{
					touchenabled:"on",
					swipe_threshold: 75,
					swipe_min_touches: 50,
					swipe_direction: "horizontal",
					drag_block_vertical: false
				}
				,
				arrows: {
					style:"hades",
					enable:true,
					hide_onmobile:true,
					hide_under:600,
					hide_onleave:false,
					hide_delay:200,
					hide_delay_mobile:1200,
					tmp:'<div class="tp-arr-allwrapper"><div class="tp-arr-imgholder"></div></div>',
					left: {
						h_align:"left",
						v_align:"center",
						h_offset:30,
						v_offset:0
					},
					right: {
						h_align:"right",
						v_align:"center",
						h_offset:30,
						v_offset:0
					}
				}
			},
			responsiveLevels:[1240,1024,778,480],
			gridwidth:[1240,1024,778,480],
			gridheight:[760,600,500,400],
			lazyType:"smart",
			parallax: {
				type:"mouse",
				origo:"slidercenter",
				speed:2000,
				levels:[2,3,4,5,6,7,12,16,10,50],
			},
			shadow:0,
			spinner:"off",
			stopLoop:"off",
			stopAfterLoops:-1,
			stopAtSlide:-1,
			shuffle:"off",
			autoHeight:"off",
			hideThumbsOnMobile:"on",
			hideSliderAtLimit:1,
			hideCaptionAtLimit:1,
			hideAllCaptionAtLilmit:1,
			startWithSlide:1,
			debugMode:false,
			fallbacks: {
				simplifyAll:"on",
				nextSlideOnWindowFocus:"on",
				disableFocusListener:"off",
			}
		});
	}
}

function slideShowFullInit(){
	if($("#rev_slider_fullscreen").length > 0){
		$("#rev_slider_fullscreen").show().revolution({
			sliderType:"hero",
			sliderLayout:"fullscreen",
			dottedOverlay:"none",
			delay:9000,
			responsiveLevels:[1240,1024,778,480],
			gridwidth:[1240,1100,778,480],
			gridheight:[700,600,500,400],
			lazyType:"smart",
			parallax: {
				type:"mouse",
				origo:"slidercenter",
				speed:2000,
				levels:[2,3,4,5,6,7,12,16,10,50],
			},
			shadow:0,
			spinner:"off",
			autoHeight:"off",
			fullScreenAlignForce:"off",
			fullScreenOffsetContainer: "",
			fullScreenOffset: "",
			disableProgressBar:"on",
			hideThumbsOnMobile:"off",
			hideSliderAtLimit:0,
			hideCaptionAtLimit:0,
			hideAllCaptionAtLilmit:0,
			debugMode:false,
			fallbacks: {
				simplifyAll:"off",
				disableFocusListener:"off",
			}
		});
	}
}
$(document).on('ready', function () {

	// Header position  //
	jQuery(window).on('scroll', function () {
		if ($(this).scrollTop() > 200) {
			$('#header .header-inner').addClass("sticky");
		} else {
			$('#header .header-inner').removeClass("sticky");
		}
	});


	// Mobile Menu  //
	$(function () {
		$('#nav').slicknav({
			'label': '',
			'prependTo': '.mobile-menu',

		});
	});


	// Testimonial Slider //
	$('.testimonial-slider').owlCarousel({
		items: 1,
		autoplay: true,
		autoplayTimeout: 3500,
		smartSpeed: 1000,
		autoplayHoverPause: true,
		loop: true,
		merge: true,
		nav: false,
		dots: true,
	});

	//  Portfolio //
	$('.single-pf').owlCarousel({
		items: 1,
		autoplay: false,
		autoplayTimeout: 4500,
		smartSpeed: 1000,
		autoplayHoverPause: true,
		margin: 15,
		loop: true,
		merge: true,
		nav: true,
		dots: false,
		navText: ['PREVIOUS', 'NEXT'],
	});


	//  Client Slider //
	$('.clients-slider').owlCarousel({
		autoplay: true,
		autoplayTimeout: 3000,
		margin: 15,
		smartSpeed: 1000,
		autoplayHoverPause: true,
		loop: true,
		nav: false,
		dots: false,
		responsive: {
			300: {
				items: 2,
			},
			480: {
				items: 3,
			},
			768: {
				items: 4,
			},
			1170: {
				items: 6,
			}
		}
	});

	//  Popup JS //
	$('.popup').magnificPopup({
		type: 'image',
		gallery: {
			enabled: true
		}
	});



	// stellar //
	$.stellar({
		horizontalOffset: 0,
		verticalOffset: 0
	});



	// Wow Animate  //
	var wow = new WOW(
		{
			boxClass: 'wow',      // animated element css class (default is wow)
			animateClass: 'animated', // animation css class (default is animated)
			offset: 0,          // distance to the element when triggering the animation (default is 0)
			mobile: false,       // trigger animations on mobile devices (default is true)
			live: true,       // act on asynchronously loaded content (default is true)
			callback: function (box) {
				// the callback is fired every time an animation is started
				// the argument that is passed in is the DOM node being animated
			},
			scrollContainer: null // optional scroll container selector, otherwise use window
		}
	);
	wow.init();


	/*====================================
		Isotop
	======================================*/
	$(window).on('load', function () {

		if ($.fn.isotope) {
			$(".isotop-active").isotope({
				filter: '*',
			});

			$('.works-menu ul li').on('click', function () {
				$(".works-menu ul li").removeClass("active");
				$(this).addClass("active");

				var selector = $(this).attr('data-filter');
				$(".isotop-active").isotope({
					filter: selector,
					animationOptions: {
						duration: 750,
						easing: 'linear',
						queue: true,
					}
				});
				return false;
			});
		}
	});


	// onePageNav  //
	$('#nav').onePageNav({
		changeHash: false,
		scrollSpeed: 1000,
		filter: '',
	});

	// Scroll Up JS  //
	$(function () {
		$.scrollUp({
			scrollName: 'scrollUp', // Element ID
			topDistance: '300', // Distance from top before showing element (px)
			topSpeed: 300, // Speed back to top (ms)
			animation: 'fade', // Fade, slide, none
			animationInSpeed: 200, // Animation in speed (ms)
			animationOutSpeed: 200, // Animation out speed (ms)
			scrollText: ["<i class='fa fa-rocket'></i>"], // Text for element
			activeOverlay: false, // Set CSS color to display scrollUp active point, e.g '#00FFFF'
		});
	});


	// counterUp //
	$('.counter').counterUp({
		delay: 10,
		time: 2500,

	});


	// GMaps //
	var map = new GMaps({
		el: '#map',
		lat: 22.933046,
		lng: 90.827027
	});
	var map = new GMaps({
		el: '#map',
		lat: 22.933046,
		lng: 90.827027,
		scrollwheel: false,
	});
	map.addMarker({
		lat: 22.933046,
		lng: 90.827027,
		title: 'Welcome to SOHEL',
		infoWindow: {
			content: '<p>Welcome To Clipping Hunt</p>'
		}

	});

	// Preloader
	$(window).on('load', function () {
		$('.loader').fadeOut('slow', function () {
			$(this).remove();
		});
	});
})(jQuery);
jQuery(document).ready(function ($) {

	// Header fixed and Back to top button
	$(window).scroll(function () {
		if ($(this).scrollTop() > 100) {
			$('.back-to-top').fadeIn('slow');
			$('#header').addClass('header-fixed');
		} else {
			$('.back-to-top').fadeOut('slow');
			$('#header').removeClass('header-fixed');
		}
	});
	$('.back-to-top').click(function () {
		$('html, body').animate({
			scrollTop: 0
		}, 1500, 'easeInOutExpo');
		return false;
	});

	// Initiate the AOS animation library
	AOS.init();

	// Initiate superfish on nav menu
	$('.nav-menu').superfish({
		animation: {
			opacity: 'show'
		},
		speed: 400
	});

	// Mobile Navigation
	if ($('#nav-menu-container').length) {
		var $mobile_nav = $('#nav-menu-container').clone().prop({
			id: 'mobile-nav'
		});
		$mobile_nav.find('> ul').attr({
			'class': '',
			'id': ''
		});
		$('body').append($mobile_nav);
		$('body').prepend('<button type="button" id="mobile-nav-toggle"><i class="fa fa-bars"></i></button>');
		$('body').append('<div id="mobile-body-overly"></div>');
		$('#mobile-nav').find('.menu-has-children').prepend('<i class="fa fa-chevron-down"></i>');

		$(document).on('click', '.menu-has-children i', function (e) {
			$(this).next().toggleClass('menu-item-active');
			$(this).nextAll('ul').eq(0).slideToggle();
			$(this).toggleClass("fa-chevron-up fa-chevron-down");
		});

		$(document).on('click', '#mobile-nav-toggle', function (e) {
			$('body').toggleClass('mobile-nav-active');
			$('#mobile-nav-toggle i').toggleClass('fa-times fa-bars');
			$('#mobile-body-overly').toggle();
		});

		$(document).click(function (e) {
			var container = $("#mobile-nav, #mobile-nav-toggle");
			if (!container.is(e.target) && container.has(e.target).length === 0) {
				if ($('body').hasClass('mobile-nav-active')) {
					$('body').removeClass('mobile-nav-active');
					$('#mobile-nav-toggle i').toggleClass('fa-times fa-bars');
					$('#mobile-body-overly').fadeOut();
				}
			}
		});
	} else if ($("#mobile-nav, #mobile-nav-toggle").length) {
		$("#mobile-nav, #mobile-nav-toggle").hide();
	}

	// Smoth scroll on page hash links
	$('.nav-menu a, #mobile-nav a, .scrollto').on('click', function () {
		if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') && location.hostname == this.hostname) {
			var target = $(this.hash);
			if (target.length) {
				var top_space = 0;

				if ($('#header').length) {
					top_space = $('#header').outerHeight();

					if (!$('#header').hasClass('header-fixed')) {
						top_space = top_space - 20;
					}
				}

				$('html, body').animate({
					scrollTop: target.offset().top - top_space
				}, 1500, 'easeInOutExpo');

				if ($(this).parents('.nav-menu').length) {
					$('.nav-menu .menu-active').removeClass('menu-active');
					$(this).closest('li').addClass('menu-active');
				}

				if ($('body').hasClass('mobile-nav-active')) {
					$('body').removeClass('mobile-nav-active');
					$('#mobile-nav-toggle i').toggleClass('fa-times fa-bars');
					$('#mobile-body-overly').fadeOut();
				}
				return false;
			}
		}
	});

	// Gallery - uses the magnific popup jQuery plugin
	$('.gallery-popup').magnificPopup({
		type: 'image',
		removalDelay: 300,
		mainClass: 'mfp-fade',
		gallery: {
			enabled: true
		},
		zoom: {
			enabled: true,
			duration: 300,
			easing: 'ease-in-out',
			opener: function (openerElement) {
				return openerElement.is('img') ? openerElement : openerElement.find('img');
			}
		}
	});

	// custom code

});

/*!
 * Site Script.
 */
// =============================================================================

! function(a) {
    "use strict";
    var b = function() {
        var a = window,
            b = "inner";
        return "innerWidth" in window || (b = "client", a = document.documentElement || document.body), {
            width: a[b + "Width"],
            height: a[b + "Height"]
        }
    };
    var d = function() {
        function k() {
            a(".modal").each(function() {
                if (a(this).find(".modal-dialog").hasClass("modal-dialog-center")) {
                    a(this).hasClass("in") === !1 && a(this).show();
                    var c = b().height - 60,
                        d = a(this).find(".modal-dialog-center .modal-header").outerHeight() || 2,
                        e = a(this).find(".modal-dialog-center .modal-footer").outerHeight() || 2;
                    a(this).find(".modal-dialog-center .modal-content").css({
                        "max-height": function() {
                            return c
                        }
                    }), a(this).find(".modal-dialog-center .modal-body").css({
                        "max-height": function() {
                            return c - (d + e)
                        }
                    }), a(this).find(".modal-dialog-center").css({
                        "margin-top": function() {
                            return -(a(this).outerHeight() / 2)
                        },
                        "margin-left": function() {
                            return -(a(this).outerWidth() / 2)
                        }
                    }), a(this).hasClass("in") === !1 && a(this).hide()
                }
            })
        }
        var c = "ontouchstart" in window;
        if (c && a(".carousel-inner").swipe({
                swipeLeft: function() {
                    a(this).parent().carousel("prev")
                },
                swipeRight: function() {
                    a(this).parent().carousel("next")
                },
                threshold: 0
            }), a(".navbar").length) {
            var d = a(window),
                e = a("body"),
                f = a(".navbar").offset().top,
                g = 0;
            e.hasClass("admin-bar") && (g = a("#wpadminbar").outerHeight()), b().height >= 320 && a(window).resize(k).trigger("resize");
            var l = function() {
                if (b().width > 992) {
                    var c = a(window),
                        d = a(".navbar"),
                        h = d.outerHeight();
                    if (d.hasClass("fixed-top")) {
                        var i = "navbar-fixed-top";
                        d.hasClass("shrinkable") && !e.hasClass("one-page-layout") && (i += " navbar-shrink");
                        var j = f;
                        c.scrollTop() + g >= j ? d.hasClass("navbar-fixed-top") || (e.hasClass("page-menu-transparent") ? (d.closest(".noo-header").css({
                            height: "1px"
                        }), d.closest(".noo-header").css({
                            position: "relative"
                        })) : a(".navbar-wrapper").css({
                            "min-height": h + "px"
                        }), d.addClass(i), d.css("top", g)) : (e.hasClass("page-menu-transparent") ? (d.closest(".noo-header").css({
                            height: ""
                        }), d.closest(".noo-header").css({
                            position: ""
                        })) : a(".navbar-wrapper").css({
                            "min-height": ""
                        }), d.removeClass(i))
                    }
                }
            };
            d.bind("scroll", l).resize(l), e.hasClass("one-page-layout") && (a('.navbar-scrollspy > .nav > li > a[href^="#"]').on("click", function(b) {
                b.preventDefault();
                var c = a(this).attr("href").replace(/.*(?=#[^\s]+$)/, "");
                if (c && a(c).length) {
                    var d = Math.max(0, a(c).offset().top);
                    d = Math.max(0, d - (g + a(".navbar").outerHeight()) + 5), a("html, body").animate({
                        scrollTop: d
                    }, {
                        duration: 800,
                        easing: "easeInOutCubic",
                        complete: window.reflow
                    })
                }
            }), e.scrollspy({
                target: ".navbar-scrollspy",
                offset: g + a(".navbar").outerHeight()
            }), a(window).resize(function() {
                e.scrollspy("refresh")
            }))
        }
        a(".cat-mega-menu").each(function() {
            var b = a(this),
                c = b.find(".cat-mega-filters a");
            c.on("mouseenter", function() {
                b.find(".cat-mega-filters li.selected").removeClass("selected"), a(this).closest("li").addClass("selected");
                var c = a(this).data("cat-id");
                b.find(".cat-mega-content").hide(), b.find('[data-control-id="cat-mega-' + c + '"]').show()
            })
        }), a(".navbar-toggle").on("click", function(b) {
            b.stopPropagation(), b.preventDefault(), a("body").hasClass("offcanvas-open") ? a("body").removeClass("offcanvas-open").addClass("offcanvas-close") : a("body").removeClass("offcanvas-close").addClass("offcanvas-open")
        }), a(document).on("click", ".offcanvas-close-btn", function() {
            a("body").removeClass("offcanvas-open").addClass("offcanvas-close")
        }), a("body").on("mousedown", a.proxy(function(b) {
            var c = a(b.target);
            a(".offcanvas").length && a("body").hasClass("offcanvas-open") && (c.is(".offcanvas") || 0 !== c.parents(".offcanvas").length || a("body").removeClass("offcanvas-open"))
        }, this)), a(".noo-slider-revolution-container .noo-slider-scroll-bottom").on("click", function(b) {
            b.preventDefault();
            var c = a(".noo-slider-revolution-container").outerHeight();
            a("html, body").animate({
                scrollTop: c
            }, 900, "easeInOutExpo")
        }), a("body").on("mouseleave ", ".masonry-style-elevated .masonry-portfolio.no-gap .masonry-item", function() {
            a(this).closest(".masonry-container").find(".masonry-overlay").hide(), a(this).removeClass("masonry-item-hover")
        }), a(".masonry.noo-category-featured").length && a(".masonry.noo-category-featured").each(function() {
            var b = a(this);
            b.find("div.pagination").hide(), b.find(".loadmore-loading").hide(), b.nooLoadmore({
                navSelector: b.find("div.pagination"),
                nextSelector: b.find("div.pagination a.next"),
                itemSelector: "div.loadmore-item",
                loading: {
                    speed: 1,
                    start: void 0
                },
                //finishedMsg: nooL10n.ajax_finishedMsg
            }, function(c) {
                if (b.find(".masonry-container").isotope("appended", a(c)), a(window).unbind(".infscr"), b.find(".masonry-filters").length) {
                    var d = b.find(".masonry-filters").find("a.selected").data("option-value");
                    b.find(".masonry-container").isotope({
                        filter: d
                    })
                }
            })
        }), a(".masonry").each(function() {
            var b = a(this),
                c = a(this).find(".masonry-container"),
                d = a(this).find(".masonry-filters a"),
                e = {
                    gutter: 0
                };
            c.isotope({
                itemSelector: ".masonry-item",
                transitionDuration: "0.8s",
                masonry: e
            }), imagesLoaded(b, function() {
                c.isotope("layout")
            }), a(window).resize(function() {
                c.isotope("layout")
            }), d.on("click", function(a) {
                a.stopPropagation(), a.preventDefault();
                var d = jQuery(this);
                if (d.hasClass("selected")) return !1;
                b.find(".masonry-result h3").text(d.text());
                var e = d.closest("ul");
                e.find(".selected").removeClass("selected"), d.addClass("selected");
                var f = {
                        layoutMode: "masonry",
                        transitionDuration: "0.8s",
                        masonry: {
                            gutter: 0
                        }
                    },
                    g = e.attr("data-option-key"),
                    h = d.attr("data-option-value");
                h = "false" === h ? !1 : h, f[g] = h, c.isotope(f)
            })
        }), a(window).scroll(function() {
            a(this).scrollTop() > 500 ? a(".go-to-top").addClass("on") : a(".go-to-top").removeClass("on")
        }), a("body").on("click", ".go-to-top", function() {
            return a("html, body").animate({
                scrollTop: 0
            }, 800), !1
        }), a("body").on("click", ".search-button", function() {
            return a(".searchbar").hasClass("hide") && (a(".searchbar").removeClass("hide").addClass("show"), a(".searchbar #s").focus()), !1
        }), a("body").on("mousedown", a.proxy(function(b) {
            var c = a(b.target);
            c.is(".searchbar") || 0 !== c.parents(".searchbar").length || a(".searchbar").removeClass("show").addClass("hide")
        }, this))
    };
    a(document).ready(function() {
        d()
    }), a(document).bind("noo-layout-changed", function() {
        d()
    })
}(jQuery);
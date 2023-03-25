(function () {
    "use strict"; window.onload = function () { window.setTimeout(fadeout, 500); }
    function fadeout() { document.querySelector('.preloader').style.opacity = '0'; document.querySelector('.preloader').style.display = 'none'; }
    window.onscroll = function () {
        var header_navbar = document.getElementById("header_navbar"); var sticky = header_navbar.offsetTop; var logo = document.querySelector('.navbar-brand img')
        if (window.pageYOffset > sticky) {
            header_navbar.classList.add("sticky")
        } else { header_navbar.classList.remove("sticky") };
        var backToTo = document.querySelector(".back-to-top");
        if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) { backToTo.style.display = "block"; }
        else { backToTo.style.display = "none"; }
    };
    let navbarToggler = document.querySelector(".navbar-toggler"); navbarToggler.addEventListener('click', function () { navbarToggler.classList.toggle("active"); })
    var wow = new WOW({ mobile: false }); wow.init();
})();
var check = false;

function changeVal(el) {
    var qt = parseFloat(el.parent().children(".qt").html());
    var price = parseFloat(el.parent().children(".price").html());
    var eq = Math.round(price * qt * 100) / 100;
    el.parent().children(".full-price").html(eq + '$');
    changeTotal();
}

function changeTotal() {
    var price = 0;
    $(".cart-item:checked").each(function (index) {
        $(".full-price").each(function (index) {
            price += parseFloat($(".full-price").eq(index).html());
        });
    });
    

    price = Math.round(price * 100) / 100;
    var tax = Math.round(price * 0.05 * 100) / 100
    var fullPrice = Math.round((price + tax) * 100) / 100;

    if (price == 0) {
        fullPrice = 0;
    }

    $(".subtotal span").html(price);
    $(".tax span").html(tax);
    $(".total span").html(fullPrice);
}
$(".cart-item").on("change", function () {
    changeTotal();
});
$(document).ready(function () {

    $(".remove").click(function () {
        var el = $(this);
        el.parent().parent().addClass("removed");
        window.setTimeout(
            function () {
                el.parent().parent().slideUp('fast', function () {
                    el.parent().parent().remove();
                    if ($(".product").length == 0) {
                        if (check) {
                            $("#cart").html("<h1>The shop does not function, yet!</h1><p>If you liked my shopping cart, please take a second and heart this Pen on <a href='https://codepen.io/ziga-miklic/pen/xhpob'>CodePen</a>. Thank you!</p>");
                        } else {
                            $("#cart").html("<h1>No products!</h1>");
                        }
                    }
                    changeTotal();
                });
            }, 200);
    });

    $(".qt-plus").click(function () {
        $(this).parent().children(".qt").html(parseInt($(this).parent().children(".qt").html()) + 1);

        $(this).parent().children(".full-price").addClass("added");

        var el = $(this);
        window.setTimeout(function () { el.parent().children(".full-price").removeClass("added"); changeVal(el); }, 150);
    });

    $(".qt-minus").click(function () {

        child = $(this).parent().children(".qt");

        if (parseInt(child.html()) > 1) {
            child.html(parseInt(child.html()) - 1);
        }

        $(this).parent().children(".full-price").addClass("minused");

        var el = $(this);
        window.setTimeout(function () { el.parent().children(".full-price").removeClass("minused"); changeVal(el); }, 150);
    });

    window.setTimeout(function () { $(".is-open").removeClass("is-open") }, 1200);

    $(".btn").click(function () {
        check = true;
        $(".remove").click();
    });
});
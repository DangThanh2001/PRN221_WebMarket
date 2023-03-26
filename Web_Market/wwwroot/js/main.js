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

function chang() {
    const email = document.getElementById('mail').value;
    const pass = document.getElementById('pas').value;
    $.ajax({
        url: '/ForgotPassword?handler=ChangePassword', // URL của Razor Page handler
        type: 'POST',  // phương thức gửi request
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        data: { email: email, password = pass }, // dữ liệu gửi đi
        success: function (result) {
            if (JSON.parse(result) == true) {
                swal("Your password been updated!", "success");
            } else {
                swal("Reset password false!", "error");
            }
        },
        error: function (xhr, status, error) {
            swal("Reset password false!", "error");
        }
    });
}
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
function MyToggle() {
    var x = document.getElementById("btnn");
    if (x.innerHTML === " Show Table ") {
        x.innerHTML = "Hidden Table";
    } else {
        x.innerHTML = " Show Table ";
    }
    $("#Create").toggleClass("hidden");
    $("#Visabile").toggleClass("Hidden-transition");
    $(".left ,.center").toggleClass("left center");
    
}
function addAnotherAddress() {
    $("#Create").toggleClass("hidden");
    var x = document.getElementById("Address");
    if (x.innerHTML === " Add new  address ") {
        x.innerHTML = "Hidden this new fild fod  address";
    } else {
        x.innerHTML = " Add new  address ";
    }
    $("#AddFontAwseam , #hiddFontAwseam").toggleClass("sho hid");
    $("#addressmain").toggleClass("btn-success btn-danger");


}

//slidbar
$(function () {
    $('#side-menu').metisMenu();
});

$(function () {
    $(window).bind("load resize", function () {
        var topOffset = 50;
        var width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        var height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    var url = window.location;
    var element = $('ul.nav a').filter(function () {
        return this.href == url;
    }).addClass('active').parent();
    while (true) {
        if (element.is('li')) {
            element = element.parent().addClass('in').parent();
        } else {
            break;
        }
    }
});
//endslidbar

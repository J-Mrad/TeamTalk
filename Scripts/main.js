$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");
});

var i = 0;

$("#menu-toggle").on("click", function () {

    if (i == 0) {
        $("#tools").css("display", "grid")
        i = 1;
    }
    else {
        $("#tools").css("display", "flex")
        i = 0;
    }
});



$(function () {

    var $landingContent = $("#landing-content"),
        $backButton = $("#goBack");
        
    $landingContent.on("click", function () {

        $(this).addClass("clicked");
    })

    $backButton.on("click", function () {

        $(this).toggleClass("clicked");
    })


});
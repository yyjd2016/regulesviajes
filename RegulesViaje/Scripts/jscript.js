
$(document).ready(function () {
    $("tr.row-hover").on({
        click : function () {
            $(this).css("background-color", "#cccccc");
        },
        blur: function () {
            alert("blur");
            $(this).css("background-color", "#ffffff");
        }
    });
});
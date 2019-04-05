$(document).ready(function () {


    $(document).keydown(function (event) {

        if (event.ctrlKey && event.shiftKey && event.keyCode == 73 || event.keyCode == 85) {
            return false;
        }

    });

    document.oncontextmenu = function () {

        return false;

    }


})
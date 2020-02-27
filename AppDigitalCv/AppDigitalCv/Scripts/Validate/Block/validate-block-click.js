$(document).ready(function () {

    $(document).keydown(function (event) {

        if (event.ctrlKey && event.keyCode == 85) {
            return false;
        } else if (event.ctrlKey && event.shiftKey && event.keyCode == 73) {
            return false;        
        }
    });

    document.oncontextmenu = function () {

        return false;

    }


})